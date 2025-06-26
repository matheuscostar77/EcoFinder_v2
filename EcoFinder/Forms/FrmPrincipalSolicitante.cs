using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoFinder.Forms;

namespace EcoFinder 
{
    public partial class FrmPrincipalSolicitante : Form
    {
        Endereco endereco;
        Pessoa pessoa;
        FrmLogin loginTela;
        FrmPerfil perfil;
        frmRealizarChamado fazerChamado;
        FrmUsuario home;
        FrmNotificacao avisos;
         public FrmPrincipalSolicitante(FrmLogin loginTela,Endereco endereco, Pessoa pessoa)
        {
            InitializeComponent();
            this.loginTela = loginTela;
            this.endereco = endereco;
            this.pessoa = pessoa;
            mdiProp();
         }
         private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor =  Color.White;
        }

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 47)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 180)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    panel6.Width = sidebar.Width;
                    panel4.Width = sidebar.Width;
                    panel5.Width = sidebar.Width;
                    panel3.Width = sidebar.Width;

                }
            }
            panel6.Width = sidebar.Width;
            panel4.Width = sidebar.Width;
            panel5.Width = sidebar.Width;
            panel3.Width = sidebar.Width;

        }
        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            var notificaoTela = new FrmChamadosAtivos(pessoa, endereco);
            notificaoTela.Show();
            if (perfil == null || perfil.IsDisposed)
            {
                perfil = new FrmPerfil();
                perfil.FormClosed += Perfil_FormClosed;
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

        private void btnCriarChamado_Click(object sender, EventArgs e)
        {

            if (fazerChamado == null)
            {
                fazerChamado = new frmRealizarChamado(this, pessoa, endereco);
                fazerChamado.FormClosed += FazerChamado_FormClosed; 
                fazerChamado.MdiParent = this;
                fazerChamado.Show();

            }
            else
            {
                if (fazerChamado == null || fazerChamado.IsDisposed)
                {
                    fazerChamado = new frmRealizarChamado(this, pessoa, endereco);
                    fazerChamado.FormClosed += FazerChamado_FormClosed;
                    fazerChamado.MdiParent = this;
                    fazerChamado.StartPosition = FormStartPosition.Manual;
                     fazerChamado.Dock = DockStyle.Fill;
                    fazerChamado.Show();
                }
                else
                {
                    fazerChamado.WindowState = FormWindowState.Normal;
                    fazerChamado.BringToFront();
                    fazerChamado.Activate();
                }

            }

        }

        private void FazerChamado_FormClosed(object sender, FormClosedEventArgs e)
        {
            fazerChamado = null;
        }

        private void FrmPrincipalSolicitante_Load(object sender, EventArgs e)
        {

        }

        private void btnAvisos_Click(object sender, EventArgs e)
        {
            if (avisos == null || avisos.IsDisposed)
            {
                avisos = new FrmNotificacao(this,pessoa,endereco);
                avisos.FormClosed += Avisos_FormClosed; ;
                avisos.MdiParent = this;
                avisos.Dock = DockStyle.Fill;
                avisos.Show();
            }
            else
            {
                avisos.WindowState = FormWindowState.Normal;
                avisos.BringToFront();
                avisos.Activate();
            }
        }

        private void Avisos_FormClosed(object sender, FormClosedEventArgs e)
        {
            avisos = null;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            loginTela.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (home == null || home.IsDisposed)
            {
                home = new FrmUsuario(this, pessoa,endereco);
                home.FormClosed += Home_FormClosed; ;
                home.MdiParent = this;
                home.Dock = DockStyle.Fill;
                home.Show();
            }
            else
            {
                home.WindowState = FormWindowState.Normal;
                home.BringToFront();
                home.Activate();
            }
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            home = null; ;
        }
    }

}
