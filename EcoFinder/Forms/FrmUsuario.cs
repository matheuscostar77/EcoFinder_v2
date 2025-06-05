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
        public FrmUsuario(FrmLogin loginTela, Pessoa pessoa)
        {
            InitializeComponent();

            this.loginTela = loginTela;
            this.pessoa = pessoa;
        }

        private void FrmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var cadastrarEndereco = new frmCadEndereco(loginTela, pessoa);
            cadastrarEndereco.Show();
        }

        private void btnRealizarChamado_Click(object sender, EventArgs e)
        {
            var realizarChamado = new frmRealizarChamado();
            realizarChamado.Show();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            loginTela.Show();
            
        }

        
    }
}
