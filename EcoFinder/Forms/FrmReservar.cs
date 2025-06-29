using EcoFinder.Forms;
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

namespace EcoFinder
{
    public partial class FrmReservar : Form
    {
        private Pessoa pessoa;
        private Endereco endereco;
        //frmColetor coletorTela;
        FrmPrincipalColetor coletorTela;
        private Chamado chamado;
        int numLinha;
        public FrmReservar(FrmPrincipalColetor coletorTela, Pessoa pessoa, Endereco endereco,Chamado chamado, int numLinha)
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
            try
            {
                // Verificação segura do índice
                if (chamado.idChamado == null || numLinha < 0 || numLinha >= chamado.idChamado.Count)
                {
                    MessageBox.Show("Não foi possível carregar os dados da coleta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                using (var conn = new MySqlConnection(pessoa.getStringConexao()))
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT * FROM vw_ver_chamado_reserva_usuario WHERE id_chamado = @id_chamado", conn);
                    cmd.Parameters.AddWithValue("@id_chamado", chamado.idChamado[numLinha]);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblNome.Text = reader["nome"] as string ?? "Não informado";
                        lblEndereco.Text = reader["endereco_format"] as string ?? "Endereço não disponível";
                        lblAbertura.Text = reader["data_chamado"] as string ?? "Não disponível";
                        lblExpira.Text = reader["data_expiracao"] as string ?? "Não definido";
                        lblStatus.Text = reader["status"] as string ?? "Indisponível";
                        lblTipoMaterial.Text = reader["tipo"] as string ?? "Não especificado";
                        lblQuantidade.Text = reader["qtde_unitaria"] as string ?? "0";
                        lblPesoMaterial.Text = reader["kilograma"] as string ?? "0";
                        lblTamanho.Text = reader["tamanho_material"] as string ?? "Não informado";
                    }
                    else
                    {
                        MessageBox.Show("Coleta não encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados da coleta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void cmbPrevisao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrevisao.SelectedItem != null)
            {
                chamado.setPrevisaoColeta(cmbPrevisao.SelectedItem.ToString());
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (cmbPrevisao.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma data para a coleta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                chamado.setPrevisaoColeta(cmbPrevisao.SelectedItem.ToString());
                chamado.reservarChamado(chamado.idChamado[numLinha], chamado.getPrevisaoColeta());

                MessageBox.Show("Reserva realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var retornarVerChamados = new FrmVerChamados(coletorTela, pessoa, endereco);
                retornarVerChamados.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao realizar reserva.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
