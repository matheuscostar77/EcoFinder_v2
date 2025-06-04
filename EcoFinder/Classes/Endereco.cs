using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
{
    internal class Endereco
    {
        private string cep;
        private string nomeBairro;
        private string cidade;
        private string estado;
        private string nomeRua;
        private int numeroCasa;
        private double latitude;
        private double longitude;

        private string stringConexao = "datasource=127.0.0.1;username=root;password=mysqlpassword;database=ecofinder";

        public Endereco() { }

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
        public int getNumeroCasa()
        {
            return numeroCasa;
        }
        public void setNumeroCasa(int numeroCasa)
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
            this.latitude = latitude;
            this.longitude = longitude;

        }

        public bool cadastrarEndereco()
        {

            using(MySqlConnection conn = new MySqlConnection(stringConexao))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {

                }
            }
            return true;
        }
    }
}
