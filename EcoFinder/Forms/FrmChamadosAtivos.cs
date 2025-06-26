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

        public FrmChamadosAtivos(Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        private void FrmChamadosAtivos_Load(object sender, EventArgs e)
        {

            Chamado chamado = new Chamado(pessoa, endereco);
            lblEndereco1.Text = chamado.chamadosAtivos(pessoa.getEmail(), 1, 1);
            lblMaterial1.Text = chamado.chamadosAtivos(pessoa.getEmail(), 1, 2);
            lblEndereco2.Text = chamado.chamadosAtivos(pessoa.getEmail(), 2, 1);
            lblMaterial2.Text = chamado.chamadosAtivos(pessoa.getEmail(), 2, 2);

        }
    }
}
