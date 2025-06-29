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
        private int tipoConta;

        FrmLogin loginTela;
         FrmUsuario usuarioTela; // apagar
        frmColetor coletorTela; // apagar

        FrmPerfil perfilTela;
        FrmPrincipalSolicitante p_solicitante;

        FrmPrincipalColetor p_coletor;


        Pessoa pessoa;
        Endereco endereco;

        public frmCadEndereco(FrmPerfil perfilTela, Pessoa pessoa, Endereco endereco, int tipoConta)
        {
            InitializeComponent();
            this.perfilTela = perfilTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.tipoConta = tipoConta;
        }

        public frmCadEndereco(FrmLogin loginTela, Pessoa pessoa, Endereco endereco, int tipoConta)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.tipoConta = tipoConta;
        }


        private void btnCadEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                if (perfilTela == null)
                {
                    if (endereco.cadastrarEndereco())
                    {

                        MessageBox.Show("Endereço cadastrado!");

                        if (tipoConta == 1)
                        {
                            p_coletor = new FrmPrincipalColetor(loginTela, pessoa, endereco);
                            p_coletor.Show();// por home
                            this.Close();
                        }
                        else if (tipoConta == 2)
                        {
                            p_solicitante = new FrmPrincipalSolicitante(loginTela, endereco, pessoa);
                            p_solicitante.Show(); // home tbm
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Endereço já foi cadastrado anteriormente, tente novamente");
                    }
                }
                else if (perfilTela != null)
                {
                    if (endereco.alterarEndereco())
                    {
                        MessageBox.Show("Endereço atualizado com sucesso.");
                        this.Close();
                        perfilTela.PreencherCamposPerfil();
                        perfilTela.Show(); // vorta novamente a tela de perfil
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar o endereço. Tente novamente com dados diferentes.");
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
            perfilTela.Show();
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
