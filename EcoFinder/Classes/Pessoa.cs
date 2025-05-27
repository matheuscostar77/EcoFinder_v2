using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFinder
{
    internal class Pessoa
    {
        protected string name;
        protected string email;
        protected string sex;
        protected string senha;
        protected string tipoConta;

        MySqlConnection conn;


        public Pessoa()
        {

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
                string data_source = "datasource=localhost;username=root;password=M@theusdavi26;database=ecofinder";
                conn = new MySqlConnection(data_source);

                string sql = "3";
                if (tipoConta == "Coletor")
                {
                    sql = "INSERT INTO tb_pessoa (nome,email,senha,sexo)" +
                            " values ('" + name + "','" + email + "','" + senha + "','" + sex + "');" +
                            "INSERT INTO tb_coletor(col_email) values('" + email + "');";
                }
                else if (tipoConta == "Usuário Comum")
                {
                     sql = "INSERT INTO tb_pessoa (nome,email,senha,sexo)" +
                            " values ('" + name + "','" + email + "','" + senha + "','" + sex + "');" +
                            "INSERT INTO tb_usuariocomum(user_email) values('" + email + "');";
                }
                else
                {
                    return false;
                }

                    MySqlCommand comando = new MySqlCommand(sql, conn);
                conn.Open();

                try
                { 
                    comando.ExecuteReader();

                    MessageBox.Show("Cadastrado!");
                    conn.Close();

                    return true;

                } 
                catch
                {
                    MessageBox.Show("Email já cadastrado");
                    conn.Close();
                    return false;
                }

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            

        }

        
    }
}