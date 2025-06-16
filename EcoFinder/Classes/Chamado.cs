
using EcoFinder.Classes;
using GeoCoordinatePortable;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
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
        

        private Pessoa pessoa;
        private Endereco endereco;
        List<EnderecoDistancia> distancias = new List<EnderecoDistancia>();

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

        public int totalChamados()
        {
            int numeroDeChamados = 0;
            using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT cont(*) from vw_quant_chamados",conn))
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
                            distancias = distancias.OrderBy(d => d.getDistancia()).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
            }
        }



        public string mostrarEnderecos(int i) // fazer um for no programa principal
        {
            using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
            {

                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(@"SELECT tipo FROM vw_mostrar_material_chamado WHERE id_endereco = id_endereco;",conn))
                    {
                        
                        
                        cmd.Parameters.AddWithValue("@id_endereco", distancias[i].getIdEndereco());
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            material = reader.ToString();
                        }
                    }
                    return material;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
            }
        }
                    

    }
}
