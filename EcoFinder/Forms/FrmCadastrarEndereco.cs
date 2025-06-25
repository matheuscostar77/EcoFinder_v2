using MySql.Data.MySqlClient;
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

        private int alterarOuCadastrar;
        FrmUsuario usuarioTela;
        frmColetor coletorTela;
        
        Pessoa pessoa;
        Endereco endereco;

        public frmCadEndereco(FrmUsuario usuarioTela, Pessoa pessoa, Endereco endereco,int alterarOuCadastrar)
        {
            InitializeComponent();
            this.usuarioTela = usuarioTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.alterarOuCadastrar = alterarOuCadastrar;
        }

        public frmCadEndereco(frmColetor coletorTela, Pessoa pessoa, Endereco endereco,int alterarOuCadastrar)
        {
            InitializeComponent();
            this.coletorTela = coletorTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.alterarOuCadastrar = alterarOuCadastrar;

        }


        private void btnCadEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                if (alterarOuCadastrar == 1)
                {
                    if (endereco.cadastrarEndereco())
                    {

                        MessageBox.Show("Endereço cadastrado!");

                        if (usuarioTela == null)
                        {
                            coletorTela.Show();
                            this.Close();
                        }
                        else
                        {
                            usuarioTela.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Endereço já foi cadastrado anteriormente, tente novamente");
                    }
                }
                else if (alterarOuCadastrar == 2)
                {
                    if (endereco.alterarEndereco())
                    {

                        MessageBox.Show("Endereço alterado!");

                        if (usuarioTela == null)
                        {
                            coletorTela.Show();
                            this.Close();
                        }
                        else
                        {
                            usuarioTela.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Endereço já foi cadastrado anteriormente, tente novamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            endereco.setCep(txtCEP.Text);
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            endereco.setCidade(txtCidade.Text);
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            endereco.setEstado(txtEstado.Text);
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            endereco.setNomeBairro(txtBairro.Text);
        }

        private void txtRua_TextChanged(object sender, EventArgs e)
        {
            endereco.setNomeRua(txtRua.Text);
        }

        private void txtNumCasa_TextChanged(object sender, EventArgs e)
        {
            endereco.setNumeroCasa(txtNumCasa.Text);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            usuarioTela.Show();
        }
        private async void btnPesquisarCEP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                try
                {
                    using (var brasilAPI = new BrasilAPI())
                    {
                        var end = await brasilAPI.CEP_V2(txtCEP.Text);

                        txtCidade.Text = end.City;
                        txtEstado.Text = end.UF.ToString();
                        txtBairro.Text = end.Neighborhood;
                        txtRua.Text = end.Street;

                        double latitude = Convert.ToDouble(end.Location.Coordinates.Latitude);
                        double longitude = Convert.ToDouble(end.Location.Coordinates.Longitude);

                        endereco.passarCoordenadas(latitude, longitude);

                        

                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
