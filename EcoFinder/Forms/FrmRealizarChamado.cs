using EcoFinder.Classes;
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
        FrmPrincipalSolicitante p_solicitante;
        Chamado chamado;
        List<EnderecoDistancia> distancias;

        public frmRealizarChamado(FrmPrincipalSolicitante p_solicitante, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            this.p_solicitante = p_solicitante;
             this.endereco = endereco;
            distancias = new List<EnderecoDistancia>();
            chamado = new Chamado(pessoa, endereco,distancias);
        }


        private void frmRealizarChamado_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            try
            {
                string end = endereco.mostrarEnderecos(pessoa.getEmail());
                if (!string.IsNullOrEmpty(end))
                {
                    lblEnderecoFormat.Text = end;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
             
        }


        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
             chamado.setMaterial(cmbMaterial.SelectedItem.ToString());
        }

        private void nmdKG_ValueChanged(object sender, EventArgs e)
        {
            chamado.setQuantKilograma(Convert.ToDouble(nmdKG.Value));
        }

        private void cmbTamanho_SelectedIndexChanged(object sender, EventArgs e)
        {
            chamado.setTamanho(cmbTamanho.SelectedItem.ToString());
        }

        private void btnRealizarChamado_Click(object sender, EventArgs e)
        {
            try
            {
                chamado.realizarChamado(pessoa.getEmail(),chamado.getMaterial(), chamado.getQuilograma(), chamado.getQtdUnidade(),chamado.getTamanho()  );
                MessageBox.Show("Chamado feito!");

                usuarioTela.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void unidades_ValueChanged(object sender, EventArgs e)
        {
            chamado.setQtdUnidade(Convert.ToInt32(nmdKG.Value));
        }
    }
}
