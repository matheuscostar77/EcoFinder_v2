using SDKBrasilAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViaCep;

namespace EcoFinder
{
    public partial class frmCadEndereco : Form
    {

        FrmLogin loginTela;
        FrmUsuario usuarioTela;
        
        
        Pessoa pessoa;
        Endereco end;

        public frmCadEndereco(FrmLogin loginTela,FrmUsuario usuarioTela, Pessoa pessoa)
        {
            InitializeComponent();
            this.loginTela = loginTela;
            this.usuarioTela = usuarioTela;
            this.pessoa = pessoa;
            this.end = new Endereco(pessoa);
        }

        private async void btnPesquisarCEP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                try
                {
                    using (var brasilAPI = new BrasilAPI())
                    {
                        var endereco = await brasilAPI.CEP_V2(txtCEP.Text);

                        txtCidade.Text = endereco.City;
                        txtEstado.Text = endereco.UF.ToString();
                        txtBairro.Text = endereco.Neighborhood;
                        txtRua.Text = endereco.Street;

                        double latitude = Convert.ToDouble(endereco.Location.Coordinates.Latitude);
                        double longitude = Convert.ToDouble(endereco.Location.Coordinates.Longitude);

                        end.passarCoordenadas(latitude, longitude);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar o CEP: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCadEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                end.cadastrarEndereco();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            end.setCep(txtCEP.Text);
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            end.setCidade(txtCidade.Text);
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            end.setEstado(txtEstado.Text);
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            end.setNomeBairro(txtBairro.Text);
        }

        private void txtRua_TextChanged(object sender, EventArgs e)
        {
            end.setNomeRua(txtRua.Text);
        }

        private void txtNumCasa_TextChanged(object sender, EventArgs e)
        {
            end.setNumeroCasa(txtNumCasa.Text);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            usuarioTela.Show();
        }
    }
}
