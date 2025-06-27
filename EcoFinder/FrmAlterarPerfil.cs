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
    public partial class FrmAlterarPerfil : Form
    {
        Pessoa pessoa;
        Endereco endereco;
        FrmPerfil perfil;
        public FrmAlterarPerfil(FrmPerfil perfil, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.perfil = perfil;
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
