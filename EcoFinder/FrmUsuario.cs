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
    }
}
