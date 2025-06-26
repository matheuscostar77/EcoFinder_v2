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
    public partial class FrmPrincipalColetor : Form
    {
        frmColetor telacoletor;
        FrmReservar telareserva;
        FrmCadastro telacadastro;
        FrmLogin telalogin;
        Pessoa pessoa;
        Endereco endereco;
        FrmPerfilColetor perfil;
        public FrmPrincipalColetor(FrmLogin telalogin, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.telalogin = telalogin;
        }

        private void FrmPrincipalColetor_Load(object sender, EventArgs e)
        {

        }

        private void btnAvisos_Click(object sender, EventArgs e)
        {

        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            if (perfil == null || perfil.IsDisposed)
            {
                perfil = new FrmPerfilColetor();
                perfil.FormClosed += Perfil_FormClosed; ;
                perfil.MdiParent = this;
                perfil.Dock = DockStyle.Fill;
                perfil.Show();
            }
            else
            {
                perfil.WindowState = FormWindowState.Normal;
                perfil.BringToFront();
                perfil.Activate();
            }
        }

        private void Perfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            perfil = null;
        }
    }
}
