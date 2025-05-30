using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EcoFinder
{
    public partial class FrmCadastro : Form
    {

        Pessoa pessoa = new Pessoa();

        public FrmCadastro()
        {
            InitializeComponent();
            
        }

        private void FrmCadastro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            pessoa.setName(txtNome.Text);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            pessoa.setEmail(txtEmail.Text);
        }

        private void txtConfirmarSenha_Leave(object sender, EventArgs e)
        {
            if (pessoa.conferirSenhaIgual(txtSenha.Text, txtConfirmarSenha.Text))
            {

            }
            else
            {
                MessageBox.Show("Senha diferente");
            }
        }

        private void cmbGenero_Leave(object sender, EventArgs e)
        {
            try
            {
                pessoa.setSex(cmbGenero.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("Por favor, preencha corretamente as informações");
            }
        }

        private void cmbTipoConta_Leave(object sender, EventArgs e)
        {
            try
            {
                pessoa.setTipoConta(cmbTipoConta.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("Por favor, preencha corretamente as informações");
            }
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
                bool cadastroSucesso = pessoa.CadastrarPessoa();
                string tipo = pessoa.getTipoConta();

                if (cadastroSucesso && tipo == "Coletor" && 
                    (pessoa.getSex() == "Masculino" || pessoa.getSex() == "Feminino" || pessoa.getSex() == "Outro"))
                {
                    var coletor = new frmColetor();
                    coletor.Show();
                }
                else if (cadastroSucesso && tipo == "Usuário Comum"
                    && (pessoa.getSex() == "Masculino" || pessoa.getSex() == "Feminino" || pessoa.getSex() == "Outro"))
                {
                    var usuario = new FrmUsuario();
                    usuario.Show();
                }
            }
            else
            {
                
                MessageBox.Show("Falta dados");
            }

        }

        private void cmbGenero_TextUpdate(object sender, EventArgs e)
        {

        }
    }
}
