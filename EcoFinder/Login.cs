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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEcoFinder_Click(object sender, EventArgs e)
        {

        }

        private void lblCriarConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cadastro = new FrmCadastro();
            cadastro.Show();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario();
            usuario.Show();
            var coletor = new frmColetor();
            coletor.Show();
        }
    }
}
