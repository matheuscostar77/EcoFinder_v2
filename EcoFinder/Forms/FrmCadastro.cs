using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoFinder.Forms;
using MySql.Data.MySqlClient;

namespace EcoFinder
{
    public partial class FrmCadastro : Form
    {


        FrmLogin loginTela;
        FrmPerfil perfilTela;

        Endereco endereco;
        Pessoa pessoa;

        string emailAntigo;

        public FrmCadastro(FrmLogin loginTela, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.loginTela = loginTela;
            this.pessoa = pessoa;
            this.endereco = endereco;

        }

        public FrmCadastro(FrmPerfil perfilTela, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.perfilTela = perfilTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            if (perfilTela != null)
            {
                emailAntigo = pessoa.getEmail();
                lblTipoConta.Visible = false;
                cmbTipoConta.Visible = false;
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            pessoa.setNomeCompleto(txtNome.Text);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            pessoa.setEmail(txtEmail.Text);
        }

        private void txtConfirmarSenha_Leave(object sender, EventArgs e)
        {
            if (pessoa.conferirSenhaIgual(txtSenha.Text, txtConfirmarSenha.Text))
            {
                pessoa.setSenha(txtConfirmarSenha.Text);
            }
            else
            {
                MessageBox.Show("Senha diferente");
            }
        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            pessoa.setSex(cmbGenero.SelectedItem.ToString());
        }

        private void cmbTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            pessoa.setTipoConta(cmbTipoConta.SelectedItem.ToString());
        }

        private void cbxTermos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTermos.Checked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


            if (cbxTermos.Checked == true && txtNome.Text != "" && txtEmail.Text != ""
                && pessoa.conferirSenhaIgual(txtSenha.Text, txtConfirmarSenha.Text)
                && (pessoa.getSex() == "Masculino" || pessoa.getSex() == "Feminino" || pessoa.getSex() == "Outro")
                && (pessoa.getTipoConta() == "Coletor" || pessoa.getTipoConta() == "Usuário Comum"))
            {
                
                string tipo = pessoa.getTipoConta();

                if (perfilTela == null)
                {
                    bool cadastroSucesso = pessoa.CadastrarPessoa();
                    if (cadastroSucesso && tipo == "Coletor" &&
                        (pessoa.getSex() == "Masculino" || pessoa.getSex() == "Feminino" || pessoa.getSex() == "Outro"))
                    {

                        var cadastroEndTela = new frmCadEndereco(loginTela, pessoa, endereco, 1);
                        this.Close();
                        cadastroEndTela.Show();


                    }
                    else if (cadastroSucesso && tipo == "Usuário Comum"
                        && (pessoa.getSex() == "Masculino" || pessoa.getSex() == "Feminino" || pessoa.getSex() == "Outro"))
                    {

                        var cadastroEndTela = new frmCadEndereco(loginTela, pessoa, endereco, 2);
                        this.Close();
                        cadastroEndTela.Show();

                    }
                }
                else if (perfilTela != null)
                {
                    pessoa.alterarDados(emailAntigo);
                    lblTipoConta.Visible = false;
                    cmbTipoConta.Visible = false;
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Falta dados");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var termosTela = new FrmTermos();
            termosTela.Show();
        }
    }
}
