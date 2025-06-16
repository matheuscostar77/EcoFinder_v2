using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFinder.Forms
{
    public partial class FrmVerChamados : Form
    {
        Pessoa pessoa;
        Endereco endereco;
        frmColetor coletorTela;
        Chamado chamado;
        public FrmVerChamados(frmColetor coletorTela, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();

            this.pessoa = pessoa;
            this.endereco = endereco;
            this.coletorTela = coletorTela;
            chamado = new Chamado(pessoa,endereco);
        }

        private void FrmVerChamados_Load(object sender, EventArgs e)
        {
            if(chamado.totalChamados() == 1)
            {
                btnChamado2.Visible = false;
                btnChamado3.Visible = false;
            }
            else if(chamado.totalChamados() == 2)
            {
                btnChamado3.Visible=false;
            }
            else if(chamado.totalChamados() == 0)
            {
                MessageBox.Show("Não há chamados disponíveis no momento!");
                this.Close();
                coletorTela.Show();
            }
                
        }
    }
}
