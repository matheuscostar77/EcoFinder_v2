using EcoFinder.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFinder.Forms
{
    public partial class FrmVerChamados : Form
    {
       // private int quantChamados;

        Pessoa pessoa;
        Endereco endereco;
        frmColetor coletorTela;
        Chamado chamado;
        List<EnderecoDistancia> distancias;
        
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
            int total = chamado.totalChamados();
            

            if (total == 0)
            {
                MessageBox.Show("Não há chamados disponíveis no momento, tente novamente mais tarde!");
                this.Close();
                coletorTela.Show();
                return;
            }

            // Oculta os botões conforme o número de chamados disponíveis
            if (total == 1)
            {
                btnChamado2.Visible = false;
                lblDistancia2.Visible = false;
                btnChamado3.Visible = false;
                lblDistancia3.Visible = false;
            }
            else if (total == 2)
            {
                btnChamado3.Visible = false;
                lblDistancia3.Visible = false;
            }

            try
            {
                btnChamado1.Text = chamado.mostrarChamado(0, "btn", "N");
                lblDistancia1.Text = chamado.mostrarChamado(0, "lbl", "N");
                btnChamado2.Text = chamado.mostrarChamado(1, "btn", "N"); 
                lblDistancia2.Text = chamado.mostrarChamado(1, "lbl", "N");
                btnChamado3.Text = chamado.mostrarChamado(2, "btn", "N");
                lblDistancia3.Text = chamado.mostrarChamado(2, "lbl", "N");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar chamados: " + ex.Message);
            }
        }

        private void cmbClassificar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            coletorTela.Show();
        }

        private void btnChamado1_Click(object sender, EventArgs e)
        {
            var reservarTela = new FrmReservar(coletorTela, pessoa, endereco, chamado, 0);
            reservarTela.Show();
            this.Close();
        }

        private void btnChamado2_Click(object sender, EventArgs e)
        {
            var reservarTela = new FrmReservar(coletorTela, pessoa, endereco, chamado, 1);
            reservarTela.Show();
            this.Close();
        }

        private void btnChamado3_Click(object sender, EventArgs e)
        {
            var reservarTela = new FrmReservar(coletorTela, pessoa, endereco, chamado, 2);
            reservarTela.Show();
            this.Close();
        }

        
    }
}
