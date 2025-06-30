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
    public partial class FrmPrincipalColetor : Form
    {
        frmColetor telacoletor;
        FrmReservar telareserva;
        FrmCadastro telacadastro;
        FrmLogin telalogin;
        Pessoa pessoa;
        FrmPerfil perfil;
        Endereco endereco;
        frmColetor home;
        FrmChamadosAtivos chamadosAtivos;
        FrmNotificacao avisos;
         FrmVerChamados verChamados;
        public FrmPrincipalColetor(FrmLogin telalogin, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();
            this.pessoa = pessoa;
            this.endereco = endereco;
            this.telalogin = telalogin;

            // Abre a tela home automaticamente ao iniciar
            btnHome_Click(null, null);
        }

        private void btnAvisos_Click(object sender, EventArgs e)
        {
            if (avisos == null || avisos.IsDisposed)
            {
                avisos = new FrmNotificacao(this, pessoa, endereco);
                avisos.FormClosed += Avisos_FormClosed;
                avisos.MdiParent = this;
                avisos.Dock = DockStyle.Fill;
                avisos.Show();
            }
            avisos.BringToFront();
        }

        private void Avisos_FormClosed(object sender, FormClosedEventArgs e)
        {
            avisos = null;
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            if (perfil == null || perfil.IsDisposed)
            {
                perfil = new FrmPerfil(this, pessoa, endereco);
                perfil.FormClosed += Perfil_FormClosed;
                perfil.MdiParent = this;
                perfil.Dock = DockStyle.Fill;
                perfil.Show();
            }
            perfil.BringToFront();
        }

        private void Perfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            perfil = null;
        }

        private void btnChamadosDisponiveis_Click(object sender, EventArgs e)
        {
            if (verChamados == null || verChamados.IsDisposed)
            {
                verChamados = new FrmVerChamados(this, pessoa, endereco);
                verChamados.FormClosed += VerChamados_FormClosed;
                verChamados.MdiParent = this;
                verChamados.Dock = DockStyle.Fill;
                verChamados.Show();
            }
            verChamados.BringToFront();
        }

        private void VerChamados_FormClosed(object sender, FormClosedEventArgs e)
        {
            verChamados = null;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (home == null || home.IsDisposed)
            {
                home = new frmColetor(this, pessoa, endereco);
                home.FormClosed += Home_FormClosed;
                home.MdiParent = this;
                home.Dock = DockStyle.Fill;
                home.Show();
            }
            home.BringToFront();
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            home = null;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            telalogin.Show();
        }

        private void btnMinhasReservas_Click(object sender, EventArgs e)
        {
            if (chamadosAtivos == null || chamadosAtivos.IsDisposed)
            {
                chamadosAtivos = new FrmChamadosAtivos(this, pessoa, endereco);
                chamadosAtivos.FormClosed += ChamadosAtivos_FormClosed; 
                chamadosAtivos.MdiParent = this;
                chamadosAtivos.Dock = DockStyle.Fill;
                chamadosAtivos.Show();
            }
            chamadosAtivos.BringToFront();


        }

        private void ChamadosAtivos_FormClosed(object sender, FormClosedEventArgs e)
        {
            chamadosAtivos = null;
        }
    }
}
