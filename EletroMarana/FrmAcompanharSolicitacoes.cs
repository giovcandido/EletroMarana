using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmAcompanharSolicitacoes : Form
    {
        public FrmAcompanharSolicitacoes()
        {
            InitializeComponent();
        }

        private void FrmAcompanharSolicitacoes_Load(object sender, System.EventArgs e)
        {
            cboProduto.DataSource = Global.ConsultaProdutos("");
            cboProduto.DisplayMember = "Nome";
            cboProduto.ValueMember = "Código";

            cboFornecedor.DataSource = Global.ConsultaFornecedores("");
            cboFornecedor.DisplayMember = "Fantasia";
            cboFornecedor.ValueMember = "Código";

            LimpaCampos();

            dgvSolicitacoes.DataSource = Global.ConsultaAbastecimentos("");
        }

        private void LimpaCampos()
        {
            txtID.Clear();

            mtbDataHora.Text = DateTime.Now.ToString();

            cboProduto.SelectedItem = null;
            cboProduto.ResetText();

            cboFornecedor.SelectedItem = null;
            cboFornecedor.ResetText();

            txtValorCusto.Clear();
            txtQuantidade.Clear();
            txtValorTotal.Clear();

            chkChegou.Checked = false;

            txtPesquisa.Clear();

            cboProduto.Select();
        }

        private void BtnPesquisar_Click(object sender, System.EventArgs e)
        {
            dgvSolicitacoes.DataSource = Global.ConsultaAbastecimentos(cboProduto.Text);

            txtPesquisa.Clear();
        }

        private void DgvSolicitacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSolicitacoes.Rows.Count > 0)
            {
                txtID.Text = dgvSolicitacoes.CurrentRow.Cells[0].Value.ToString();
                mtbDataHora.Text = dgvSolicitacoes.CurrentRow.Cells[1].Value.ToString();
                cboProduto.Text = dgvSolicitacoes.CurrentRow.Cells[2].Value.ToString();
                cboFornecedor.Text = dgvSolicitacoes.CurrentRow.Cells[3].Value.ToString();
                txtValorCusto.Text = dgvSolicitacoes.CurrentRow.Cells[4].Value.ToString();
                txtQuantidade.Text = dgvSolicitacoes.CurrentRow.Cells[5].Value.ToString();
                txtValorTotal.Text = dgvSolicitacoes.CurrentRow.Cells[6].Value.ToString();
                chkChegou.Checked = Convert.ToBoolean(dgvSolicitacoes.CurrentRow.Cells[7].Value.ToString());
            }
        }

        private void BtnIncluir_Click(object sender, System.EventArgs e)
        {
            if (cboProduto.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into abastecimentos(data_hora, id_fornecedor, id_produto, valor_custo, qtd, total, chegou) 
                                              values(?data_hora, ?id_fornecedor, ?id_produto, ?valor_custo, ?qtd, ?total, ?chegou)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?data_hora", Convert.ToDateTime(mtbDataHora.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            Global.Comando.Parameters.AddWithValue("?id_fornecedor", cboFornecedor.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?id_produto", cboProduto.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?valor_custo", txtValorCusto.Text);
            Global.Comando.Parameters.AddWithValue("?qtd", txtQuantidade.Text);
            Global.Comando.Parameters.AddWithValue("?total", txtValorTotal.Text);
            Global.Comando.Parameters.AddWithValue("?chegou", Convert.ToBoolean(chkChegou.Checked));
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvSolicitacoes.DataSource = Global.ConsultaAbastecimentos("");
        }

        private void BtnAtualizar_Click(object sender, System.EventArgs e)
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update abastecimentos set id_fornecedor = ?id_fornecedor, id_produto = ?id_produto, valor_custo = ?valor_custo, 
                                              qtd = ?qtd, total = ?total, chegou = ?chegou where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?id_fornecedor", cboFornecedor.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?id_produto", cboProduto.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?valor_custo", Convert.ToDouble(txtValorCusto.Text));
            Global.Comando.Parameters.AddWithValue("?qtd", txtQuantidade.Text);
            Global.Comando.Parameters.AddWithValue("?total", txtValorTotal.Text);
            Global.Comando.Parameters.AddWithValue("?chegou", Convert.ToBoolean(chkChegou.Checked));
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvSolicitacoes.DataSource = Global.ConsultaAbastecimentos("");
        }

        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            LimpaCampos();

            dgvSolicitacoes.DataSource = Global.ConsultaAbastecimentos("");
        }

        private void BtnExcluir_Click(object sender, System.EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir a solicitação de " + cboProduto.Text + "?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("delete from abastecimentos where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                LimpaCampos();

                dgvSolicitacoes.DataSource = Global.ConsultaAbastecimentos("");
            }
        }

        private void BtnFechar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
