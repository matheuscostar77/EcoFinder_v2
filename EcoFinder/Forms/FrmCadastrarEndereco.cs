using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViaCep;

namespace EcoFinder
{
    public partial class frmCadEndereco : Form
    {
        public frmCadEndereco()
        {
            InitializeComponent();
        }

        private void btnPesquisarCEP_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                
                
                try
                {
                    var endereco = new ViaCepClient().Search(txtCEP.Text);

                    txtCidade.Text = endereco.City;
                    txtEstado.Text = endereco.StateInitials;
                    txtBairro.Text = endereco.Neighborhood;
                    txtBairro.Text = endereco.Street;
                        
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);


                }
                
            }
            else
            {
                MessageBox.Show("Informe um CEP válido!");
            }
        }
    }
}
