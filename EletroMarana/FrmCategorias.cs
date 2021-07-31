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

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = Global.ConsultaCategorias("");

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();

            txtPesquisa.Clear();

            txtNome.Select();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = Global.ConsultaCategorias(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void DgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verifica se o grid tem linhas
            // se tiver, passa o conteudo do grid para os txt
            if (dgvCategorias.Rows.Count > 0)
            {
                txtID.Text = dgvCategorias.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvCategorias.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
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
            LimpaCampos();

            // atualiza grid
            dgvCategorias.DataSource = Global.ConsultaCategorias("");
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
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
            LimpaCampos();

            // atualiza grid
            dgvCategorias.DataSource = Global.ConsultaCategorias("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvCategorias.DataSource = Global.ConsultaCategorias("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir a categoria " + txtNome.Text + "? Os produtos que " +
                                "pertençam a ela serão automaticamente excluídos.", "Exclusão", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
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
                LimpaCampos();

                // atualiza grid
                dgvCategorias.DataSource = Global.ConsultaCategorias("");
            }
        }
        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
