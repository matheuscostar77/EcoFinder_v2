
using EcoFinder.Classes;
using GeoCoordinatePortable;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
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

        private Pessoa pessoa;
        private Endereco endereco;
        List<EnderecoDistancia> distancias;

        public Chamado(Pessoa pessoa, Endereco endereco, List<EnderecoDistancia> distancias)
        {
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.distancias = distancias;

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
            using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = " CALL proc_realizar_chamado(@email,@tipo,@quilograma,@qtdUnidade,@tamanho)";
                    cmd.Parameters.AddWithValue("@email", pessoa.getEmail());
                    cmd.Parameters.AddWithValue("@tipo", material);
                    cmd.Parameters.AddWithValue("@quilograma", quilograma);
                    cmd.Parameters.AddWithValue("@qtdUnidade", qtdUnidade);
                    cmd.Parameters.AddWithValue("@tamanho", tamanho);

                    cmd.ExecuteReader();
                }
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
                                numeroDeChamados = reader.GetInt32(0);
                                return numeroDeChamados;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                return numeroDeChamados;
            }

        }

        public void calcularDistancia(double latCol, double longCol)
        {
            using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
            {
                try
                {
                    double lat2, long2;
                    GeoCoordinate coordColetor = null;

                    coordColetor = new GeoCoordinate(latCol, longCol);

                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM vw_lat_log_user", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idEndereco = reader.GetInt32(0);
                                lat2 = reader.GetDouble(1);
                                long2 = reader.GetDouble(2);

                                var coord = new GeoCoordinate(lat2, long2);
                                double dist = coordColetor.GetDistanceTo(coord);

                                EnderecoDistancia endDist = new EnderecoDistancia();
                                endDist.setIdEndereco(idEndereco);
                                endDist.setDistancia(dist);

                                distancias.Add(endDist);
                            }
                            distancias.Sort((d1, d2) => d1.getDistancia().CompareTo(d2.getDistancia()));
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }



        public string mostrarChamado(int linha, string tipoBotao, string tipomaterial)
        {
            string tipo;
            string distancia;

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
                            idChamado.Add(reader.GetInt32("id_chamado"));


                            if (tipoBotao == "lbl")
                            {
                                return distancia;
                            }
                            else if (tipoBotao == "btn")
                            {
                                return tipo;
                            }


                        }
                        return "";
                    }
                }
            }
        }

        internal void setQtdUnidade(object value)
        {
            throw new NotImplementedException();
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
    }
}
