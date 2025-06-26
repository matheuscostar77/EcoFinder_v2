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
    public partial class FrmUsuario : Form
    {
        FrmLogin loginTela;
        Pessoa pessoa;
        Endereco endereco;
        FrmPrincipalSolicitante p_solicitante;
        public FrmUsuario(FrmPrincipalSolicitante p_solicitante, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();

            this.p_solicitante = p_solicitante;
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

        }

        private void FrmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
