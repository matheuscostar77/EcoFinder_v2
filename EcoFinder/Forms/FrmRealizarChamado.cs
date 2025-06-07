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
    public partial class frmRealizarChamado : Form
    {
        Pessoa pessoa;
        FrmUsuario usuarioTela;
        Endereco endereco;
        public frmRealizarChamado(FrmUsuario usuarioTela,Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            this.usuarioTela = usuarioTela;
            this.endereco = endereco;
        }

        private void frmRealizarChamado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

            

        private void cmbEnderecoCham_Click(object sender, EventArgs e)
        {
            try
            {
                string end = endereco.mostrarEnderecos(pessoa.getEmail());
                cmbEnderecoCham.Items.Clear();
                if (!string.IsNullOrEmpty(end))
                {
                    cmbEnderecoCham.Items.Add(end);
                    cmbEnderecoCham.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
