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
    public partial class FrmPerfil : Form
    {
        Pessoa pessoa;
        Endereco endereco;
        FrmPrincipalSolicitante solicitanteTela;
        FrmPrincipalColetor coletorTela;
        int tipoConta;
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

            /*txbEmail.Text = pessoa.getEmail();
            txbNome.Text = pessoa.getName();
            txbGenero.Text = pessoa.getSex();
            txbCep.Text = endereco.getCep();
            txbCidade.Text = endereco.getCidade();
            txbEstado.Text = endereco.getEstado();
            txbRua.Text = endereco.getNomeRua();
            txbnumerocasa.Text = endereco.getNumeroCasa();
            txbBairro.Text = endereco.getNomeBairro();*/

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
    }
}
