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
        FrmPrincipalSolicitante telasolicitante;
        FrmPrincipalColetor telacoletor;
        public FrmPerfil(FrmPrincipalSolicitante telasolicitante, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.telasolicitante = telasolicitante;
            this.pessoa = pessoa;
            this.endereco = endereco;
        }
        public FrmPerfil(FrmPrincipalColetor telacoletor, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.telacoletor = telacoletor;
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            txbEmail.Text = pessoa.getEmail();
            txbNome.Text = pessoa.getName();
            txbGenero.Text = pessoa.getSex();
            txbCep.Text = endereco.getCep();
            txbCidade.Text = endereco.getCidade();
            txbEstado.Text = endereco.getEstado();
            txbRua.Text = endereco.getNomeRua();
            txbnumerocasa.Text = endereco.getNumeroCasa();
            txbBairro.Text = endereco.getNomeBairro();

        }

        private void btnalterarEndereco_Click(object sender, EventArgs e)
        {
            var cadastrarEndereco = new frmCadEndereco(this, pessoa, endereco);
            cadastrarEndereco.Show();
            this.Hide();
        }
        
        private void btnAlterarPerfil_Click(object sender, EventArgs e)
        {
            var cadastro = new FrmAlterarPerfil(this, pessoa, endereco);
            cadastro.Show();
        }
    }
}
