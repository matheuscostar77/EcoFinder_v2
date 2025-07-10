using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EcoFinder
{

    public partial class FrmPerfil : Form
    {
        Pessoa pessoa;
        Endereco endereco;
        FrmPrincipalSolicitante solicitanteTela;
        FrmPrincipalColetor coletorTela;
        int tipoConta;

        public FrmPerfil() { }
        public FrmPerfil(FrmPrincipalSolicitante solicitanteTela, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
             this.solicitanteTela = solicitanteTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
            tipoConta = 2;
        }
        public FrmPerfil(FrmPrincipalColetor coletorTela, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
             this.coletorTela = coletorTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
            tipoConta = 1;
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            PreencherCamposPerfil();

        }

        public void PreencherCamposPerfil()
        {
            try
            {
                string[] dados = pessoa.ObterDadosPerfil();
                if (dados == null || dados.Length < 9)
                {
                    MessageBox.Show("Não foi possível carregar seus dados de perfil.", "Erro ao Carregar Perfil",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txbNome.Text = dados[0];
                txbEmail.Text = dados[1];
                txbGenero.Text = dados[2];
                txbCep.Text = dados[3];
                txbEstado.Text = dados[4];
                txbCidade.Text = dados[5];
                txbBairro.Text = dados[6];
                txbRua.Text = dados[7];
                txbnumerocasa.Text = dados[8];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar perfil: " + ex.Message,
                                "Erro Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnalterarEndereco_Click(object sender, EventArgs e)
        {
            var alterarEndereco = new frmCadEndereco(this, pessoa, endereco, tipoConta);
            alterarEndereco.Show();
         }
        
        private void btnAlterarPerfil_Click(object sender, EventArgs e)
        {
            var alterarDados = new FrmCadastro(this, pessoa, endereco);
            alterarDados.Show();
         }

        private void FrmPerfil_Activated(object sender, EventArgs e)
        {
            PreencherCamposPerfil();
        }
    }
}
