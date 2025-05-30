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
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var cadastrarEndereco = new frmCadEndereco();
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
            var login = new FrmLogin();
            login.Show();

            this.Hide();
        }

        
    }
}
