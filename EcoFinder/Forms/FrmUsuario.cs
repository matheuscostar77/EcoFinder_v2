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
    public partial class FrmUsuario : Form
    {
        FrmLogin loginTela;
        Pessoa pessoa;
        Endereco endereco;
        public FrmUsuario(FrmLogin loginTela, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();

            this.loginTela = loginTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

        }

        private void FrmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var cadastrarEndereco = new frmCadEndereco(this, pessoa, endereco,1);
            cadastrarEndereco.Show();
        }

        private void btnRealizarChamado_Click(object sender, EventArgs e)
        {
            this.Hide();
            var realizarChamado = new frmRealizarChamado(this, pessoa,endereco);
            realizarChamado.Show();
        }

        

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            loginTela.Show();
            
        }

        private void btnAlterarEndereco_Click(object sender, EventArgs e)
        {
            var cadastrarEndereco = new frmCadEndereco(this, pessoa, endereco, 2);
            cadastrarEndereco.Show();
            this.Hide();
        }
    }
}
