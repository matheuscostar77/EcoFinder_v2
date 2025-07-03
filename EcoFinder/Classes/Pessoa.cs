using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFinder
{
    public class Pessoa
    {
        protected string nomeCompleto;
        protected string primeiroNome;
        protected string email;
        protected string sex;
        protected string senha;
        protected string tipoConta;

        private string stringConexao = "datasource=localhost;username=root;password=M@theusdavi26;database=ecofinder";


        public Pessoa()
        {
        }

        public void setSenha(string senha)
        {
            this.senha = senha;
        }
        public string getNomeCompleto()
        {
            return nomeCompleto;
        }

        public string getPrimeiroNome()
        {
            return primeiroNome;
        }

        public void setPrimeiroNome(string nomeCompleto)
        {
            if (nomeCompleto.Contains(" "))
            {
                primeiroNome = nomeCompleto.Substring(0, nomeCompleto.IndexOf(" "));
            }
            else
            {
                primeiroNome = nomeCompleto;
            }
        }
        public void setNomeCompleto(string nomeCompleto)
        {
            this.nomeCompleto = nomeCompleto;
            
            
        }
        public string getEmail()
        {
            return email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getSex()
        {
            return sex;
        }

        public void setSex(string sex)
        {
            this.sex = sex;
        }

        public void setTipoConta(string tipoConta)
        {
            this.tipoConta = tipoConta;

        }

        public string getTipoConta()
        {
            return tipoConta;
        }

        public string getStringConexao()
        {
            return stringConexao;
        }
        public bool conferirSenhaIgual(string senha1, string senha2)
        {
            if (senha1 == senha2)
            {
                senha = senha1;
                return true;
            }

            return false;
        }

        public bool CadastrarPessoa()
        {
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                {
                    conn.Open();

                    var cmd = new MySqlCommand("INSERT INTO tb_pessoa(nome,email,senha,genero) VALUES (@name,@email,@senha,@genero);", conn);
                    cmd.Parameters.AddWithValue("@name", nomeCompleto);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@genero", sex);
                    cmd.ExecuteNonQuery();

                    string tabela = tipoConta == "Coletor" ? "tb_coletor" : "tb_usuariocomum";
                    string coluna = tipoConta == "Coletor" ? "id_coletor" : "id_usuarioComum";

                    cmd = new MySqlCommand($"INSERT INTO {tabela}({coluna}) VALUES (LAST_INSERT_ID());", conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show($"Bem-vindo(a), {primeiroNome}! Sua conta foi criada com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
                return false;
            }
        }

        public string validarLogin(string email, string senha)
        {
            using (var conn = new MySqlConnection(stringConexao))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT ecofinder.f_identificar_tipo_conta(@email, @senha);", conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    var result = cmd.ExecuteScalar();

                    using (var cmd2 = new MySqlCommand("SELECT nome FROM tb_pessoa WHERE email = @email;",conn))
                    {
                        cmd2.Parameters.AddWithValue("@email", email);
                        using (MySqlDataReader reader = cmd2.ExecuteReader())
                        {
                            if(reader.Read()) 
                            {
                                setPrimeiroNome(reader.GetString(0)); 
                            }
                        }
                    }


                        if (result != null && result != DBNull.Value)
                        {
                            int tipo = int.Parse(result.ToString());


                            return tipo.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Email ou senha incorretos!");
                            return "0";
                        }
                }

                
            }
        }

        public bool alterarDados(string emailAntigo)
        {
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                {
                    conn.Open();

                    int idPessoa = -1;
                    var buscarCmd = new MySqlCommand("SELECT f_identificar_id_conta(@email);", conn);
                    buscarCmd.Parameters.AddWithValue("@email", emailAntigo);

                    var result = buscarCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        idPessoa = int.Parse(result.ToString());
                    else
                    {
                        MessageBox.Show("Conta não encontrada.");
                        return false;
                    }

                    var updateCmd = new MySqlCommand(@"
                        UPDATE tb_pessoa
                        SET nome = @nome, email = @novoEmail, senha = @senha, genero = @genero
                        WHERE id_pessoa = @id;", conn);

                    updateCmd.Parameters.AddWithValue("@nome", nomeCompleto);
                    updateCmd.Parameters.AddWithValue("@novoEmail", email);
                    updateCmd.Parameters.AddWithValue("@senha", senha);
                    updateCmd.Parameters.AddWithValue("@genero", sex);
                    updateCmd.Parameters.AddWithValue("@id", idPessoa);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Dados atualizados com sucesso.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar dados: " + ex.Message);
                return false;
            }
        }


        public string[] ObterDadosPerfil()
        {
            string[] dados = new string[9];
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SELECT p.nome, p.email, p.genero,
                                               e.cep, e.estado, e.cidade,
                                               e.bairro, e.rua, e.numerocasa
                                        FROM tb_pessoa p
                                        JOIN tb_endereco e ON e.id_pessoa_endereco = p.id_pessoa
                                        WHERE p.id_pessoa = (
                                            SELECT f_identificar_id_conta(@emailParam)
                                        )";
                    cmd.Parameters.AddWithValue("@emailParam", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dados[0] = reader.GetString(0);
                            dados[1] = reader.GetString(1);
                            dados[2] = reader.GetString(2);
                            dados[3] = reader.GetString(3);
                            dados[4] = reader.GetString(4);
                            dados[5] = reader.GetString(5);
                            dados[6] = reader.GetString(6);
                            dados[7] = reader.GetString(7);
                            dados[8] = reader.GetString(8);
                        }
                        else
                        {
                            MessageBox.Show("Não encontramos seus dados de perfil. Por favor, tente novamente mais tarde.",
                                            "Perfil Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }
                    }
                }
                return dados;
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Houve um problema ao acessar suas informações. Verifique sua conexão de internet ou tente novamente mais tarde.\n\nDetalhes técnicos: " + mysqlEx.Message,
                                "Erro de Conexão ao Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Desculpe, ocorreu um erro inesperado ao carregar seu perfil:\n" + ex.Message + "\nPor favor, contate o suporte.",
                                "Erro Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        
    }

}

