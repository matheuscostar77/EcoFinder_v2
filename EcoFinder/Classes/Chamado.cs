
using EcoFinder.Classes;
using GeoCoordinatePortable;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFinder
{
    public class Chamado
    {

        private string material;
        private double quilograma = 0;
        private string tamanho;
        private int qtdUnidade = 0;
        public List<int> idChamado = new List<int>();
        private string previsaoColeta;
        private int tipoConta;

        private Pessoa pessoa;
        private Endereco endereco;


        public Chamado(Pessoa pessoa, Endereco endereco, int tipoConta)
        {
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.tipoConta = tipoConta;
        }

        public Chamado(Pessoa pessoa, Endereco endereco)
        {
            this.pessoa = pessoa;
            this.endereco = endereco;
        }
        public string getMaterial()
        {
            return material;
        }
        public void setMaterial(string material)
        {
            this.material = material;
        }

        public double getQuilograma()
        {
            return quilograma;
        }

        public void setQuantKilograma(double quilograma)
        {
            this.quilograma = quilograma;
        }

        public string getTamanho()
        {
            return tamanho;
        }
        public void setTamanho(string tamanho)
        {
            this.tamanho = tamanho;
        }
        public int getQtdUnidade()
        {
            return qtdUnidade;
        }
        public void setQtdUnidade(int qtdUnidade)
        {
            this.qtdUnidade = qtdUnidade;
        }

        public string getPrevisaoColeta()
        {
            return previsaoColeta;
        }

        public void setPrevisaoColeta(string previsaoColeta)
        {
            this.previsaoColeta = previsaoColeta;
        }
        public void realizarChamado(string email, string material, double quilograma, int qtdUnidade, string tamanho)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
                {
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.CommandText = "CALL proc_realizar_chamado(@email,@tipo,@quilograma,@qtdUnidade,@tamanho)";
                        cmd.Parameters.AddWithValue("@email", pessoa.getEmail());
                        cmd.Parameters.AddWithValue("@tipo", material);
                        cmd.Parameters.AddWithValue("@quilograma", quilograma);
                        cmd.Parameters.AddWithValue("@qtdUnidade", qtdUnidade);
                        cmd.Parameters.AddWithValue("@tamanho", tamanho);

                        cmd.ExecuteNonQuery(); // Alterado para ExecuteNonQuery
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        public int totalChamados()
        {
            int numeroDeChamados = 0;
            using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT count(id_dispo) from vw_quant_chamados", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                numeroDeChamados = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erro no banco de dados: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                return numeroDeChamados;
            }
        }

        public string mostrarChamado(int linha, string tipoBotao, string tipomaterial)
        {
            

            string tipo = "N/D";
            string distancia = "N/D";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("pc_ver_chamados", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pc_email", pessoa.getEmail());
                        cmd.Parameters.AddWithValue("@pc_linha", linha);
                        cmd.Parameters.AddWithValue("@pc_material", tipomaterial);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tipo = reader["tipo"] as string ?? "N/D";
                                distancia = reader["Distancia"] as string ?? "N/D";

                                if (!reader.IsDBNull(reader.GetOrdinal("id_chamado")))
                                {
                                    idChamado.Add(reader.GetInt32("id_chamado"));
                                }

                                return tipoBotao == "lbl" ? distancia : tipo;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
            return "";
        }

        public void reservarChamado(int idChamado, string previsaoColeta)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("proc_realizar_reserva", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_email", pessoa.getEmail());
                        cmd.Parameters.AddWithValue("@p_id_chamado", idChamado);
                        cmd.Parameters.AddWithValue("@p_previsao_coleta", previsaoColeta);

                        var resultadoParam = new MySqlParameter("@RESULTADO", MySqlDbType.Bit);
                        resultadoParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(resultadoParam);

                        // Executa a procedure
                        cmd.ExecuteNonQuery();

                        // Captura o valor retornado
                        bool resultado = false;
                        if (resultadoParam.Value != DBNull.Value)
                        {
                            resultado = Convert.ToBoolean(resultadoParam.Value);
                        }

                        // Usa o resultado como quiser
                        if (resultado)
                        {
                            MessageBox.Show("Reserva realizada com sucesso.");
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível realizar a reserva.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar reservar: " + ex.Message);
            }
        }


        public string chamadosAtivos(string email, int numGroup, int endOuMaterial)
        {
            

            try
            {
                using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
                {
                    conn.Open();

                    int idpessoa;
                    using (MySqlCommand cmdId = new MySqlCommand("SELECT f_identificar_id_conta(@email)", conn))
                    {
                        cmdId.Parameters.AddWithValue("@email", email);
                        var result = cmdId.ExecuteScalar();
                        idpessoa = (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
                    }

                    if (idpessoa == 0) return "Usuário não encontrado";

                    string query = @"SELECT * FROM vw_ver_chamado_reserva_usuario
                                   WHERE id_pessoa = @id_pessoa AND status NOT IN ('Concluido','Cancelado')
                                   LIMIT @offset, 1";
                    if (tipoConta == 1)
                    {
                        query = @"SELECT * FROM vw_ver_chamado_reserva_coletor 
                                   WHERE id_coletor = @id_pessoa AND status_reserva NOT IN ('Concluida','Cancelada')
                                   LIMIT @offset, 1";
                    }
                    
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_pessoa", idpessoa);
                            cmd.Parameters.AddWithValue("@offset", numGroup - 1);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal("id_chamado")))
                                    {
                                        idChamado.Add(reader.GetInt32("id_chamado"));
                                    }

                                    switch (endOuMaterial)
                                    {
                                        case 0: return reader["endereco_format"].ToString();
                                        case 1: return reader["tipo"].ToString();
                                        case 2: return reader["status"].ToString();
                                        case 3: return reader["data_expiracao"].ToString();
                                        case 4: return reader["data_chamado"].ToString();
                                        case 5: return reader["kilograma"].ToString() + "KG";
                                        case 6: return reader["qtde_unitaria"].ToString() + " uni.";
                                        default: return "N/D";
                                    }
                                }
                            }
                        }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro MySQL: {ex.Number} - {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro geral: {ex.Message}");
            }
            return null;
        }

        public bool confirmarChamado(string tipoConta, int numColecao)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("p_confirmar_coleta", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_id_chamado_reservado", idChamado[numColecao]);
                        cmd.Parameters.AddWithValue("@p_tipo_usuario", tipoConta);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return false;
            }
        }

        public bool desistirChamado(int numColecao)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("PR_CANCELANDO_RESERVA", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_ID_CHAMADO", idChamado[numColecao]);

                        var resultadoParam = new MySqlParameter("@RESULT", MySqlDbType.Bit);
                        resultadoParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(resultadoParam);

                        cmd.ExecuteNonQuery();

                        return resultadoParam.Value != DBNull.Value && Convert.ToBoolean(resultadoParam.Value);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return false;
            }
        }
    }
}





