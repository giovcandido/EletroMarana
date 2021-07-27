using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmTiposPGTO : Form
    {
        public FrmTiposPGTO()
        {
            InitializeComponent();
        }

        void limpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();

            chkBaixaAutomatica.Checked = false;

            txtPesquisa.Clear();
        }

        private void FrmTiposPGTO_Load(object sender, EventArgs e)
        {
            dgvTiposPGTO.DataSource = Global.consultaTiposPGTO("");

            limpaCampos();

            txtNome.Select();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            // abre a conexão
            Global.Conexao.Open();

            // comando insert
            Global.Comando = new MySqlCommand("insert into tipos_pgto(descricao, baixa_aut) values(?descricao, ?baixa_aut)", Global.Conexao);

            // criando o parâmetro
            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?baixa_aut", Convert.ToBoolean(chkBaixaAutomatica.Checked));

            // executando o comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            limpaCampos();

            // atualiza grid
            dgvTiposPGTO.DataSource = Global.consultaTiposPGTO("");
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            // abre a conexão
            Global.Conexao.Open();

            // comando update
            Global.Comando = new MySqlCommand("update tipos_pgto set descricao = ?descricao, baixa_aut = ?baixa_aut where id = ?id", Global.Conexao);

            // criando os parâmetros
            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?baixa_aut", Convert.ToBoolean(chkBaixaAutomatica.Checked));
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            // executa comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            limpaCampos();

            // atualiza grid
            dgvTiposPGTO.DataSource = Global.consultaTiposPGTO("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();

            dgvTiposPGTO.DataSource = Global.consultaTiposPGTO("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            // confirma exclusão
            if (MessageBox.Show("Deseja realmente excluir o tipo de pagamento " + txtNome.Text + "?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                // abre a conexão
                Global.Conexao.Open();

                // comando delete
                Global.Comando = new MySqlCommand("delete from tipos_pgto where id = ?id", Global.Conexao);

                // criando o parâmetro
                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                // executa comando
                Global.Comando.ExecuteNonQuery();

                // fecha a conexão
                Global.Conexao.Close();

                // limpa form
                limpaCampos();

                // atualiza grid
                dgvTiposPGTO.DataSource = Global.consultaTiposPGTO("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvTiposPGTO.DataSource = Global.consultaTiposPGTO(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void dgvTiposPGTO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verifica se o grid tem linhas
            // se tiver, passa o conteudo do grid para os txt
            if (dgvTiposPGTO.Rows.Count > 0)
            {
                txtID.Text = dgvTiposPGTO.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvTiposPGTO.CurrentRow.Cells[1].Value.ToString();
                chkBaixaAutomatica.Checked = Convert.ToBoolean(dgvTiposPGTO.CurrentRow.Cells[2].Value.ToString());
            }
        }
    }
}
