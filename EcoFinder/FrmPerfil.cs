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
        public FrmPerfil()
        {
            InitializeComponent();
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnalterarEndereco_Click(object sender, EventArgs e)
        {
            var cadastrarEndereco = new frmCadEndereco(this, pessoa, endereco);
            cadastrarEndereco.Show();
            this.Hide();
        }
    }
}
