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

        private void FrmTiposPGTO_Load(object sender, EventArgs e)
        {
            dgvTiposPGTO.DataSource = Global.ConsultaTiposPGTO("");

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();

            chkBaixaAutomatica.Checked = false;

            txtPesquisa.Clear();

            txtNome.Select();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            dgvTiposPGTO.DataSource = Global.ConsultaTiposPGTO(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void DgvTiposPGTO_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void BtnIncluir_Click(object sender, EventArgs e)
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
            LimpaCampos();

            // atualiza grid
            dgvTiposPGTO.DataSource = Global.ConsultaTiposPGTO("");
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
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
            LimpaCampos();

            // atualiza grid
            dgvTiposPGTO.DataSource = Global.ConsultaTiposPGTO("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvTiposPGTO.DataSource = Global.ConsultaTiposPGTO("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir o tipo de pagamento " + txtNome.Text + "? As vendas realizadas " +
                                "com este tipo serão excluídas automaticamente.", "Exclusão", MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                LimpaCampos();

                // atualiza grid
                dgvTiposPGTO.DataSource = Global.ConsultaTiposPGTO("");
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
