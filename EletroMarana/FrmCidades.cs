using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmCidades : Form
    {
        public FrmCidades()
        {
            InitializeComponent();
        }

        void limpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();

            cboEstado.SelectedItem = null;
            cboEstado.ResetText();

            txtPesquisa.Clear();
        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            dgvCidades.DataSource = Global.consultaCidades("");

            txtNome.Select();

            cboEstado.DataSource = Global.consultaEstados("");
            cboEstado.DisplayMember = "Nome";
            cboEstado.ValueMember = "Código";

            limpaCampos();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            // abre a conexão
            Global.Conexao.Open();

            // comando insert
            Global.Comando = new MySqlCommand("insert into cidades(nome, id_estado) values(?nome, ?id_estado)", Global.Conexao);

            // criando os parâmetros
            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?id_estado", cboEstado.SelectedValue);

            // executa comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            limpaCampos();

            // atualiza grid
            dgvCidades.DataSource = Global.consultaCidades("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvCidades.DataSource = Global.consultaCidades(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verifica se o grid tem linhas
            // se tiver, passa o conteudo do grid para os txt
            if (dgvCidades.RowCount > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells[1].Value.ToString();
                cboEstado.Text = dgvCidades.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            // abre a conexão
            Global.Conexao.Open();

            // comando update
            Global.Comando = new MySqlCommand("update cidades set nome = ?nome, id_estado = ?id_estado where id = ?id", Global.Conexao);

            // criando os parâmetros
            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboEstado.SelectedValue);

            // executa comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            limpaCampos();

            // atualiza grid
            dgvCidades.DataSource = Global.consultaCidades("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();

            dgvCidades.DataSource = Global.consultaCidades("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            // confirma exclusão
            if (MessageBox.Show("Deseja realmente excluir a cidade de " + txtNome.Text + "?", "Exclusão", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                // abre a conexão
                Global.Conexao.Open();

                // comando delete
                Global.Comando = new MySqlCommand("delete from cidades where id = ?id", Global.Conexao);

                // criando o parâmetro
                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                // executa comando
                Global.Comando.ExecuteNonQuery();

                // fecha a conexão
                Global.Conexao.Close();

                // limpa form
                limpaCampos();

                // atualiza grid
                dgvCidades.DataSource = Global.consultaCidades("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
