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
        private Pessoa pessoa;
        public FrmLogin(Pessoa pessoa)
        {
            InitializeComponent();
            this.pessoa = pessoa;
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblCriarConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cadastro = new FrmCadastro(this, pessoa);
            cadastro.Show();
            this.Hide();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var usuario = new FrmUsuario(this, pessoa);
            usuario.Show();
            this.Hide();
            var coletor = new frmColetor(this, pessoa);
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
                    var coletor = new frmColetor(this,pessoa);
                    coletor.Show();
                    this.Hide();
                }
                else if (int.Parse(contavalida) == 2)
                {
                    var usuario = new FrmUsuario(this,pessoa);
                    usuario.Show();
                    this.Hide();
                }
                
            }
        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            pessoa.setEmail(tbxEmail.Text);
        }
    }
}
