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
        public frmColetor()
        {
            InitializeComponent();
        }

        private void frmColetor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            var login = new FrmLogin();
            login.Show();

            this.Hide();
        }

        
    }
}
