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
    public partial class frmColetor : Form
    {
        FrmLogin loginTela;
        Pessoa pessoa;

        public frmColetor(FrmLogin loginTela, Pessoa pessoa)
        {
            InitializeComponent();

            this.loginTela = loginTela;
            this.pessoa = pessoa;
        }

        private void frmColetor_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

            loginTela.Show();
            this.Close();

            
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            btnReservar.FlatStyle = FlatStyle.Flat;
            btnReservar.FlatAppearance.BorderSize = 0;

        }
    }
}
