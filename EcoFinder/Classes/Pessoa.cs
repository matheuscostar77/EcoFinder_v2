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

        string stringConexao = "datasource=localhost;username=root;password=M@theusdavi26;database=ecofinder";


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
            if(sex == "Masculino" || sex == "Feminino" || sex == "Outro")
            {
                this.sex = sex;
            }
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
            int numSex;
            switch (sex)
            {
                case "Masculino":
                    numSex = 1;
                    break;
                case "Feminino":
                    numSex = 2;
                    break;
                default:
                    numSex = 3;
                    break;
            }


            
            using (MySqlConnection conn = new MySqlConnection(stringConexao))
            {

                using(MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "INSERT INTO tb_pessoa(nome,email,senha,id_genero) " +
                                        "VALUES (@name,@email,@senha,@idgenero);";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@idgenero", numSex);

                    if (tipoConta == "Coletor") 
                    {
                        cmd.CommandText += @"INSERT INTO tb_coletor(id_coletor) " +
                                            "VALUES (LAST_INSERT_ID());";
                    }
                    else if(tipoConta == "Usuário Comum")
                    {
                        cmd.CommandText += @"INSERT INTO tb_usuariocomum(id_usuarioComum) " +
                                            "VALUES (LAST_INSERT_ID());";
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cadastrado");
                        return true;
                    }
                    catch 
                    {
                        MessageBox.Show("Email já cadastrado");
                        return false;
                    }
                }


            }
        }

        
    }
}