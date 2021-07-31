using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmEstados : Form
    {
        public FrmEstados()
        {
            InitializeComponent();
        }

        private void FrmEstados_Load(object sender, System.EventArgs e)
        {
            dgvEstados.DataSource = Global.ConsultaEstados("");

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
            dgvEstados.DataSource = Global.ConsultaEstados(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void DgvEstados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verifica se o grid tem linhas
            // se tiver, passa o conteudo do grid para os txt
            if (dgvEstados.Rows.Count > 0)
            {
                txtID.Text = dgvEstados.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvEstados.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void BtnIncluir_Click(object sender, System.EventArgs e)
        {
            if (txtNome.Text == "") return;

            // abre a conexão
            Global.Conexao.Open();

            // comando insert
            Global.Comando = new MySqlCommand("insert into estados(nome) values(?nome)", Global.Conexao);

            // criando o parâmetro
            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);

            // executando o comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            LimpaCampos();

            // atualiza grid
            dgvEstados.DataSource = Global.ConsultaEstados("");
        }

        private void BtnAtualizar_Click(object sender, System.EventArgs e)
        {
            if (txtID.Text == "") return;

            // abre a conexão
            Global.Conexao.Open();

            // comando update
            Global.Comando = new MySqlCommand("update estados set nome = ?nome where id = ?id", Global.Conexao);

            // criando os parâmetros
            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            // executa comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            LimpaCampos();

            // atualiza grid
            dgvEstados.DataSource = Global.ConsultaEstados("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvEstados.DataSource = Global.ConsultaEstados("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            // confirma exclusão
            if (MessageBox.Show("Deseja realmente excluir o estado " + txtNome.Text + "?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                // abre a conexão
                Global.Conexao.Open();

                // comando delete
                Global.Comando = new MySqlCommand("delete from estados where id = ?id", Global.Conexao);

                // criando o parâmetro
                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                // executa comando
                Global.Comando.ExecuteNonQuery();

                // fecha a conexão
                Global.Conexao.Close();

                // limpa form
                LimpaCampos();

                // atualiza grid
                dgvEstados.DataSource = Global.ConsultaEstados("");
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
