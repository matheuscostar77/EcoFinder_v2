using EcoFinder.Classes;
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
    public partial class FrmChamadosAtivos : Form
    {
        Pessoa pessoa;
        Endereco endereco;
        Chamado chamado;
        FrmPrincipalSolicitante homeUsuario;
        FrmPrincipalColetor homeColetor;

        public FrmChamadosAtivos(FrmPrincipalSolicitante homeUsuario, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            this.endereco = endereco;
            chamado = new Chamado(pessoa, endereco);
            this.homeUsuario = homeUsuario;
        }

        public FrmChamadosAtivos(FrmPrincipalColetor homeColetor, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            this.endereco = endereco;
            chamado = new Chamado(pessoa, endereco);
            this.homeColetor = homeColetor;
        }

        private void FrmChamadosAtivos_Load(object sender, EventArgs e)
        {

            if (chamado.chamadosAtivos(pessoa.getEmail(), 1, 0) == null)
            {
                lblEndereco1.Visible = false;
                lblMaterial1.Visible = false;
                lblStatus1.Visible = false;
                gpbChamado1.Visible = false;

                lblEndereco2.Visible = false;
                lblMaterial2.Visible = false;
                lblStatus2.Visible = false;
                gpbChamado2.Visible = false;
            }
            else if (chamado.chamadosAtivos(pessoa.getEmail(), 2, 0) == null)
            {
                lblEndereco2.Visible = false;
                lblMaterial2.Visible = false;
                lblStatus2.Visible = false;
                gpbChamado2.Visible = false;
            }

            lblEndereco1.Text = chamado.chamadosAtivos(pessoa.getEmail(), 1, 0);
            lblMaterial1.Text = chamado.chamadosAtivos(pessoa.getEmail(), 1, 1);
            lblStatus1.Text = chamado.chamadosAtivos(pessoa.getEmail(), 1, 2);
            lblStatus1.ForeColor = Color.DarkSalmon;
            lblExpiraData1.Text = chamado.chamadosAtivos(pessoa.getEmail(), 1, 3);
            lblFeitoData1.Text = chamado.chamadosAtivos(pessoa.getEmail(), 1, 4);
            lblKG1.Text = chamado.chamadosAtivos(pessoa.getEmail(), 1, 5);
            lblQtde1.Text = chamado.chamadosAtivos(pessoa.getEmail(), 1, 6);

            lblEndereco2.Text = chamado.chamadosAtivos(pessoa.getEmail(), 2, 0);
            lblMaterial2.Text = chamado.chamadosAtivos(pessoa.getEmail(), 2, 1);
            lblStatus2.Text = chamado.chamadosAtivos(pessoa.getEmail(), 2, 2);
            lblStatus2.ForeColor = Color.Yellow;
            lblExpiraData2.Text = chamado.chamadosAtivos(pessoa.getEmail(), 2, 3);
            lblFeitoData2.Text = chamado.chamadosAtivos(pessoa.getEmail(), 2, 4);
            lblKG2.Text = chamado.chamadosAtivos(pessoa.getEmail(), 2, 5);
            lblQtde2.Text = chamado.chamadosAtivos(pessoa.getEmail(), 2, 6);

            if (lblStatus1.Text == "Disponivel")
            {
                btnConfirmar1.Visible = false;
                lblStatus1.ForeColor = Color.Green;
                
            }
            else if (lblStatus2.Text == "Disponivel")
            {
                btnConfirmar2.Visible = false;
                lblStatus2.ForeColor = Color.Green;
            }

            if (lblStatus1.Text == "Cancelado" || lblStatus1.Text == "Desistencia")
            {
                btnConfirmar1.Visible = false;
                btnCancelar1.Visible = false;
                lblStatus1.ForeColor = Color.Red;
            }
            else if (lblStatus2.Text == "Cancelado" || lblStatus2.Text == "Desistencia")
            {
                btnConfirmar2.Visible = false;
                btnCancelar2.Visible = false;
                lblStatus2.ForeColor = Color.Red;
            }
        }

        private void btnConfirmar1_Click(object sender, EventArgs e)
        {
            string tipoConta = null;

            if (homeUsuario != null)
            {
                tipoConta = "SOLICITANTE";
            }
            else if (homeColetor != null)
            {
                tipoConta = "COLETOR";
            }

            if (chamado.confirmarChamado(tipoConta, 0))
            {
                MessageBox.Show("Coleta confirmada!");
            }
        }

        private void btnConfirmar2_Click(object sender, EventArgs e)
        {
            string tipoConta = null;

            if (homeUsuario != null)
            {
                tipoConta = "SOLICITANTE";
            }
            else if (homeColetor != null)
            {
                tipoConta = "COLETOR";
            }

            if (chamado.confirmarChamado(tipoConta, 0))
            {
                MessageBox.Show("Coleta confirmada!");
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
            "Certeza que deseja cancelar a reserva?\nVocê estará passivo de strikes caso cancele!",
            "Cancelar reserva",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                chamado.desistirChamado(0);
                MessageBox.Show("Cancelado");
            }
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
            "Certeza que deseja cancelar a reserva?\nVocê estará passivo de strikes caso cancele!",
            "Cancelar reserva",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                chamado.desistirChamado(1);
                MessageBox.Show("Cancelado");
            }
        }
    }
}
