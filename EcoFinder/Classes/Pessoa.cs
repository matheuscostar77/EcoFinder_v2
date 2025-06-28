using MySql.Data.MySqlClient;
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
        protected string name;
        protected string email;
        protected string sex;
        protected string senha;
        protected string tipoConta;
 
        private string stringConexao = "datasource=localhost;username=root;password=mysqlpassword;database=ecofinder";


        public Pessoa()
        {

        }
        public string getSenha()
        {
            return senha;
        }

        public void setSenha(string senha)
        {
            this.senha = senha;
        }
        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
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
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@genero", sex);
                    cmd.ExecuteNonQuery();

                    string tabela = tipoConta == "Coletor" ? "tb_coletor" : "tb_usuariocomum";
                    string coluna = tipoConta == "Coletor" ? "id_coletor" : "id_usuarioComum";

                    cmd = new MySqlCommand($"INSERT INTO {tabela}({coluna}) VALUES (LAST_INSERT_ID());", conn);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show($"Bem-vindo(a), {name}! Sua conta foi criada com sucesso.");
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
                var cmd = new MySqlCommand("SELECT ecofinder.f_identificar_tipo_conta(@email, @senha);", conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);

                var result = cmd.ExecuteScalar();
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

        public bool alterarDados(string emailAntigo)
        {
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                {
                    conn.Open();

                    int idPessoa = -1;
                    var buscarCmd = new MySqlCommand("SELECT f_identificar_a_conta(@email);", conn);
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

                    updateCmd.Parameters.AddWithValue("@nome", name);
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
    }

}

