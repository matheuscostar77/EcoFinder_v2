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
        frmColetor telacoeltor;
        public FrmReservar(frmColetor telacoletor , Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.telacoeltor = telacoletor;
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        private void FrmReservar_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxIDS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
