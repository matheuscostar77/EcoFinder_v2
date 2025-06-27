using EcoFinder.Forms;
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
    public partial class frmColetor : Form
    {
        FrmLogin loginTela;
        Pessoa pessoa;
        FrmPrincipalColetor telacoletor;
        Endereco endereco;
         public frmColetor(FrmPrincipalColetor telacoletor, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();

            this.telacoletor = telacoletor;
            this.pessoa = pessoa;
            this.endereco = endereco;
         }

        private void frmColetor_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        
    }
}
