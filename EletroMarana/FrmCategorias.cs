using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        void limpaCampos() {
            txtID.Clear();
            txtNome.Clear();

            txtPesquisa.Clear();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = Global.consultaCategorias("");

            limpaCampos();

            txtNome.Select();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            // abre a conexão
            Global.Conexao.Open();

            // comando insert
            Global.Comando = new MySqlCommand("insert into categorias(descricao) values(?descricao)", Global.Conexao);

            // criando o parâmetro
            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);

            // executando o comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            limpaCampos();

            // atualiza grid
            dgvCategorias.DataSource = Global.consultaCategorias("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = Global.consultaCategorias(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verifica se o grid tem linhas
            // se tiver, passa o conteudo do grid para os txt
            if (dgvCategorias.Rows.Count > 0)
            {
                txtID.Text = dgvCategorias.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvCategorias.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            // abre a conexão
            Global.Conexao.Open();

            // comando update
            Global.Comando = new MySqlCommand("update categorias set descricao = ?descricao where id = ?id", Global.Conexao);

            // criando os parâmetros
            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            // executa comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            limpaCampos();

            // atualiza grid
            dgvCategorias.DataSource = Global.consultaCategorias("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();

            dgvCategorias.DataSource = Global.consultaCategorias("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            // confirma exclusão
            if (MessageBox.Show("Deseja realmente excluir a categoria " + txtNome.Text + "?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                // abre a conexão
                Global.Conexao.Open();
                
                // comando delete
                Global.Comando = new MySqlCommand("delete from categorias where id = ?id", Global.Conexao);

                // criando o parâmetro
                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                // executa comando
                Global.Comando.ExecuteNonQuery();

                // fecha a conexão
                Global.Conexao.Close();

                // limpa form
                limpaCampos();

                // atualiza grid
                dgvCategorias.DataSource = Global.consultaCategorias("");
            }
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
