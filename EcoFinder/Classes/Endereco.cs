﻿using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFinder
{
    public class Endereco
    {
        
        private string cep;
        private string nomeBairro;
        private string cidade;
        private string estado;
        private string nomeRua;
        private string numeroCasa;
        private double latitude;
        private double longitude;

        private string stringConexao = "datasource=localhost;username=root;password=M@theusdavi26;database=ecofinder";

        Pessoa pessoa;

        public Endereco(Pessoa pessoa) 
        {
            this.pessoa = pessoa;
        }

        public string getNomeBairro()
        {
            return nomeBairro;
        }
        public void setNomeBairro(string nomeBairro)
        {
            this.nomeBairro = nomeBairro;
        }

        public string getCidade()
        {
            return cidade;
        }
        public void setCidade(string cidade)
        {
            this.cidade = cidade;
        }

        public string getNomeRua()
        {
            return nomeRua;
        }
        public void setNomeRua(string nomeRua)
        {
            this.nomeRua = nomeRua;
        }
        public string getNumeroCasa()
        {
            return numeroCasa;
        }
        public void setNumeroCasa(string numeroCasa)
        {
            this.numeroCasa = numeroCasa;
        }
        public string getCep()
        {
            return cep;
        }
        public void setCep(string cep)
        {
            this.cep = cep;
        }
        public string getEstado()
        {
            return estado;
        }
        public void setEstado(string estado)
        {
            this.estado = estado;
        }


        public void passarCoordenadas(double latitude, double longitude)
        {
            this.latitude = latitude / 1e7;
            this.longitude = longitude / 1e7;

        }

        public bool cadastrarEndereco()
        {

            using(MySqlConnection conn = new MySqlConnection(stringConexao))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    int idpessoa;

                    conn.Open();
                    cmd.CommandText = "SELECT f_identificar_a_conta(@email)";
                    cmd.Parameters.AddWithValue("@email",pessoa.getEmail());
                    
                    
                    idpessoa = Convert.ToInt32(cmd.ExecuteScalar());
                    
                    cmd.Parameters.Clear();

                    cmd.CommandText = @"INSERT INTO tb_endereco(id_pessoa_endereco,cep,estado,
                                        cidade,bairro,rua,numerocasa,latitude,longitude) " +
                                            "VALUES (@id_pessoa_endereco,@cep,@estado," +
                                            "@cidade,@bairro,@rua,@numerocasa,@latitude,@longitude);";
                    cmd.Parameters.AddWithValue("@id_pessoa_endereco",idpessoa);
                    cmd.Parameters.AddWithValue("@cep", cep);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@cidade", cidade);
                    cmd.Parameters.AddWithValue("@bairro", nomeBairro);
                    cmd.Parameters.AddWithValue("@rua", nomeRua);
                    cmd.Parameters.AddWithValue("@numerocasa", numeroCasa);
                    cmd.Parameters.AddWithValue("@longitude", longitude);
                    cmd.Parameters.AddWithValue("@latitude", latitude);

                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public string mostrarEnderecos(string email)
        {
            string endereco = "";

            using (MySqlConnection conn = new MySqlConnection(stringConexao))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT endereco_format FROM vw_verendereco WHERE email = @email";
                    cmd.Parameters.AddWithValue("@email", email);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            endereco = reader["endereco_format"].ToString();
                            return endereco;
                        }
                    }
                }
            }

            return endereco;
        }

    }
}
