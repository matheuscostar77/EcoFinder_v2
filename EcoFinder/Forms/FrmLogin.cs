using EcoFinder.Forms;
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
        private Endereco endereco;
        public FrmLogin() { }
        public FrmLogin(Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var coletor = new FrmPrincipalColetor(this, pessoa, endereco);
            

        }
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblCriarConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cadastroTela = new FrmCadastro(this, pessoa, endereco);
            cadastroTela.Show();
            this.Hide();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var usuario = new FrmPrincipalSolicitante(this, endereco, pessoa);
            usuario.Show();
            this.Hide();
            
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            if (tbxEmail.Text != "" && tbxSenha.Text != "")
            {
                string contavalida = pessoa.validarLogin(tbxEmail.Text, tbxSenha.Text);

                if (int.Parse(contavalida) == 1)
                {
                    var coletor = new FrmPrincipalColetor(this,pessoa, endereco);
                    coletor.Show();
                    this.Hide();
                }
                else if (int.Parse(contavalida) == 2)
                {
                    var usuario = new FrmPrincipalSolicitante(this, endereco, pessoa);
                    usuario.Show();
                    this.Hide();
                }
                  
            }
            tbxEmail.Text = "";
            tbxSenha.Text = "";
        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            pessoa.setEmail(tbxEmail.Text);
        }

        
    }
}
