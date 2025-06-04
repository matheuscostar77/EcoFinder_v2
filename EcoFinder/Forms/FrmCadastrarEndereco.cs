using SDKBrasilAPI;
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

        Endereco end = new Endereco();

        public frmCadEndereco()
        {
            InitializeComponent();
        }

        private async void btnPesquisarCEP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                try
                {
                    using (var brasilAPI = new BrasilAPI())
                    {
                        var endereco = await brasilAPI.CEP_V2(txtCEP.Text);

                        txtCidade.Text = endereco.City;
                        txtEstado.Text = endereco.UF.ToString();
                        txtBairro.Text = endereco.Neighborhood;
                        txtRua.Text = endereco.Street;

                        double latitude = Convert.ToDouble(endereco.Location.Coordinates.Latitude);
                        double longitude = Convert.ToDouble(endereco.Location.Coordinates.Longitude);

                        end.passarCoordenadas(latitude, longitude);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar o CEP: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
