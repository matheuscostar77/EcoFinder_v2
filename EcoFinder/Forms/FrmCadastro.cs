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

        MySqlConnection conn;
        Pessoa pessoa = new Pessoa();
        public FrmCadastro()
        {
            InitializeComponent();
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

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            pessoa.setSex(cmbGenero.SelectedItem.ToString());
        }

        private void cmbTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipoConta.SelectedItem.ToString() == "Coletor")
            {
                pessoa.setTipoConta("Coletor");
            }
            else
            {
                pessoa.setTipoConta("Usuario");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pessoa.CadastrarPessoa();
        }

        
    }
}
