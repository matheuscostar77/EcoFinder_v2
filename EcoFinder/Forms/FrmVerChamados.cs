using EcoFinder.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFinder.Forms
{
    public partial class FrmVerChamados : Form
    {
        private int quantChamados;

        Pessoa pessoa;
        Endereco endereco;
        frmColetor coletorTela;
        Chamado chamado;
        List<EnderecoDistancia> distancias;
        
        public FrmVerChamados(frmColetor coletorTela, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();

            this.pessoa = pessoa;
            this.endereco = endereco;
            this.coletorTela = coletorTela;
            distancias = new List<EnderecoDistancia>();
            chamado = new Chamado(pessoa,endereco,distancias);
        }

        private void FrmVerChamados_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT latitude,longitude FROM vw_lat_log_col WHERE email = @email", conn))
                    {
                        cmd.Parameters.AddWithValue("@email", pessoa.getEmail());

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                endereco.setLatitude(reader.GetDouble(0));
                                endereco.setLongitude(reader.GetDouble(1));
                            }
                        }
                    }
                }

                quantChamados = chamado.totalChamados();
                chamado.calcularDistancia(endereco.getLatitude(), endereco.getLongitude());

                if (quantChamados == 1)
                {
                    btnChamado2.Visible = false;
                    btnChamado3.Visible = false;

                    btnChamado1.Text = chamado.mostrarMaterialChamado(0);
                    lblDistancia1.Text = distancias[0].getDistancia().ToString("F0");
                }
                else if (quantChamados == 2)
                {
                    btnChamado1.Text = chamado.mostrarMaterialChamado(0);
                    btnChamado2.Text = chamado.mostrarMaterialChamado(1);

                    lblDistancia1.Text = distancias[0].getDistancia().ToString("F0");
                    lblDistancia2.Text = distancias[1].getDistancia().ToString("F0");

                    btnChamado3.Visible = false;
                }
                else if (quantChamados == 0)
                {
                    MessageBox.Show("Não há chamados disponíveis no momento!");
                    this.Close();
                    coletorTela.Show();
                }
                else
                {

                    btnChamado1.Text = chamado.mostrarMaterialChamado(0);
                    btnChamado2.Text = chamado.mostrarMaterialChamado(1);
                    btnChamado3.Text = chamado.mostrarMaterialChamado(2);

                    lblDistancia1.Text = distancias[0].getDistancia().ToString("F0");
                    lblDistancia2.Text = distancias[1].getDistancia().ToString("F0");
                    lblDistancia3.Text = distancias[2].getDistancia().ToString("F0");
                }

                lblDistancia1.Text += "m";
                lblDistancia2.Text += "m";
                lblDistancia3.Text += "m";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
