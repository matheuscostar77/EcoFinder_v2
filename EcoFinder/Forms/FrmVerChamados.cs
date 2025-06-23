using EcoFinder.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
            int total = chamado.totalChamados();

            if (total == 0)
            {
                MessageBox.Show("Não há chamados disponíveis no momento, tente novamente mais tarde!");
                this.Close();
                coletorTela.Show();
                return;
            }

            // Oculta os botões conforme o número de chamados disponíveis
            if (total == 1)
            {
                btnChamado2.Visible = false;
                lblDistancia2.Visible = false;
                btnChamado3.Visible = false;
                lblDistancia3.Visible = false;
            }
            else if (total == 2)
            {
                btnChamado3.Visible = false;
                lblDistancia3.Visible = false;
            }

            try
            {
                for (int i = 0; i < total && i < 3; i++)
                {
                    using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand("pc_ver_chamados", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@pc_email", pessoa.getEmail());
                            cmd.Parameters.AddWithValue("@pc_linha", i);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string tipo = reader["tipo"] as string ?? "N/D";
                                    string distancia = reader["Distancia"] as string ?? "N/D";

                                    switch (i)
                                    {
                                        case 0:
                                            btnChamado1.Text = tipo;
                                            lblDistancia1.Text = distancia;
                                            break;
                                        case 1:
                                            btnChamado2.Text = tipo;
                                            lblDistancia2.Text = distancia;
                                            break;
                                        case 2:
                                            btnChamado3.Text = tipo;
                                            lblDistancia3.Text = distancia;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar chamados: " + ex.Message);
            }
        }

    }
}
