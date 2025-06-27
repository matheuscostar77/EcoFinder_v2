using EcoFinder.Forms;
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

namespace EcoFinder
{
    public partial class FrmReservar : Form
    {
        private Pessoa pessoa;
        private Endereco endereco;
        //frmColetor coletorTela;
        FrmPrincipalColetor coletorTela;
        private Chamado chamado;
        int numLinha;
        public FrmReservar(FrmPrincipalColetor coletorTela, Pessoa pessoa, Endereco endereco,Chamado chamado, int numLinha)
        {
            InitializeComponent();
            this.coletorTela = coletorTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.chamado = chamado;
            this.numLinha = numLinha;
        }

        private void FrmReservar_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM vw_ver_chamado_reserva WHERE id_chamado = @id_chamado",conn))
                    {
                        cmd.Parameters.AddWithValue("@id_chamado", chamado.idChamado[numLinha]);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblNome.Text = reader["nome"]?.ToString();
                                lblEndereco.Text = reader["endereco_format"]?.ToString();
                                lblAbertura.Text = reader["data_chamado"]?.ToString();
                                lblExpira.Text = reader["data_expiracao"]?.ToString();
                                lblStatus.Text = reader["status"]?.ToString();
                                lblTipoMaterial.Text = reader["tipo"]?.ToString();
                                lblQuantidade.Text = reader["qtde_unitaria"]?.ToString();
                                lblPesoMaterial.Text = reader["kilograma"]?.ToString();
                                lblTamanho.Text = reader["tamanho_material"]?.ToString();
                            }
                        }
                    }
                }
            }        
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbPrevisao_SelectedIndexChanged(object sender, EventArgs e)
        {
            chamado.setPrevisaoColeta(cmbPrevisao.SelectedItem.ToString());
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            chamado.reservarChamado(chamado.idChamado[numLinha], chamado.getPrevisaoColeta());
            var retornarVerChamados = new FrmVerChamados();
            retornarVerChamados.Show();
            this.Close();
        }

        
    }
}
