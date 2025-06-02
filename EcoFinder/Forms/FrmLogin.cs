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
    public partial class FrmLogin : Form
    {
        Pessoa pessoa = new Pessoa();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblCriarConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cadastro = new FrmCadastro();
            cadastro.Show();
            this.Hide();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var usuario = new FrmUsuario();
            usuario.Show();
            this.Hide();
            var coletor = new frmColetor();
            coletor.Show();
            this.Hide();
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            if (tbxEmail.Text != "" && tbxSenha.Text != "")
            {
                string contavalida = pessoa.validarLogin(tbxEmail.Text, tbxSenha.Text);

                if (int.Parse(contavalida) == 1)
                {
                    var coletor = new frmColetor();
                    coletor.Show();
                    this.Hide();
                }
                else if (int.Parse(contavalida) == 2)
                {
                    var usuario = new FrmUsuario();
                    usuario.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Email ou senha invalidos!");
                }
            }
        }
    }
}
