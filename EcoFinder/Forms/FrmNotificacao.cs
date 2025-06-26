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
    public partial class FrmNotificacao : Form
    {
        Pessoa pessoa;
        Endereco endereco;
        frmColetor coletorTela;
        FrmUsuario usuarioTela;
        public FrmNotificacao(frmColetor coletorTela, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();

            lstNotificacao.View = View.Details;
            
            lstNotificacao.GridLines = true;

            
            this.coletorTela = coletorTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        public FrmNotificacao(FrmUsuario usuarioTela, Pessoa pessoa, Endereco endereco)
        {
            InitializeComponent();

            this.usuarioTela = usuarioTela;
            this.pessoa = pessoa;
            this.endereco = endereco;
        }

        private void FrmNotificacao_Load(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(pessoa.getStringConexao()))
            {
                int idpessoa;
                conn.Open();
                if (coletorTela != null)
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT f_identificar_a_conta(@email)", conn))
                    {
                        cmd.Parameters.AddWithValue("@email", pessoa.getEmail());

                        idpessoa = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.Clear();

                        cmd.CommandText = "SELECT mensagem FROM tb_notifica_coletor WHERE id_coletor = @id_pessoa";
                        cmd.Parameters.AddWithValue("@id_pessoa", idpessoa);

                        lstNotificacao.Items.Clear();

                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string row = reader.GetString(0);

                                var linha_listview = new ListViewItem(row);

                                lstNotificacao.Items.Add(linha_listview);
                            }

                            
                        }
                    }
                }
                else if (usuarioTela != null)
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT f_identificar_a_conta(@email)", conn))
                    {
                        cmd.Parameters.AddWithValue("@email", pessoa.getEmail());

                        idpessoa = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.Clear();

                        cmd.CommandText = "SELECT mensagem FROM tb_notifica_solicitante WHERE id_usuariocomum = @id_pessoa";
                        cmd.Parameters.AddWithValue("@id_pessoa", idpessoa);
                    }
                }
            }
        }
        private void lstNotificacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
