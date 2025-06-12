
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
{
    public class Chamado
    {
        
        private string material;
        private double quilograma = 0;
        private string tamanho;

        private Pessoa pessoa;
        private Endereco endereco;

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

        public void realizarChamado(string email, double quilograma, string tamanho)
        {
            using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "CALL proc_realizar_chamado(@email,@tipo,@quilograma,@tamanho)";
                    cmd.Parameters.AddWithValue("@email", pessoa.getEmail());
                    cmd.Parameters.AddWithValue("@tipo", material);
                    cmd.Parameters.AddWithValue("@quilograma", quilograma);
                    cmd.Parameters.AddWithValue("@tamanho", tamanho);

                    cmd.ExecuteReader();
                }
            }
        }

    }
}
