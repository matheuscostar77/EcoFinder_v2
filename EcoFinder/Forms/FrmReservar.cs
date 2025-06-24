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
    public partial class FrmReservar : Form
    {
        private Pessoa pessoa;
        private Endereco endereco;
        frmColetor coletorTela;
        private Chamado chamado;
        int numLinha;
        public FrmReservar(frmColetor coletorTela , Pessoa pessoa, Endereco endereco,Chamado chamado, int numLinha)
        {
            InitializeComponent();
            this.coletorTela = coletorTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.chamado = chamado;
            this.numLinha = numLinha;
        }

        private void FrmReservar_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxIDS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
