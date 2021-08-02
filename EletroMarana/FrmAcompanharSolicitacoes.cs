using System;
using System.Data;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmAcompanharSolicitacoes : Form
    {
        int idFornecedor;

        public FrmAcompanharSolicitacoes()
        {
            InitializeComponent();
        }

        private void FrmAcompanharSolicitacoes_Load(object sender, System.EventArgs e)
        {
            cboProduto.DisplayMember = "Nome";
            cboProduto.ValueMember = "Código";

            cboProduto.DataSource = Global.ConsultaProdutosDescricao("");
            
            LimpaCampos();

            dgvSolicitacoes.DataSource = Global.ConsultaAbastecimentos("");
        }

        private void LimpaCampos()
        {
            txtID.Clear();

            mtbDataHora.Text = DateTime.Now.ToString();

            cboProduto.SelectedItem = null;
            cboProduto.ResetText();

            txtFornecedor.Clear();

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
                txtFornecedor.Text = dgvSolicitacoes.CurrentRow.Cells[3].Value.ToString();
                txtValorCusto.Text = dgvSolicitacoes.CurrentRow.Cells[4].Value.ToString();
                txtQuantidade.Text = dgvSolicitacoes.CurrentRow.Cells[5].Value.ToString();
                txtValorTotal.Text = dgvSolicitacoes.CurrentRow.Cells[6].Value.ToString();
                chkChegou.Checked = Convert.ToBoolean(dgvSolicitacoes.CurrentRow.Cells[7].Value.ToString());
            }
        }

        private void CboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduto.SelectedItem != null)
            {
                int idProduto = Convert.ToInt16(cboProduto.SelectedValue);

                DataTable datTabela = Global.ConsultaProdutoID(idProduto);

                idFornecedor = Convert.ToInt16(datTabela.Rows[0]["Código Fornecedor"]);
                
                txtFornecedor.Text = datTabela.Rows[0]["Fornecedor"].ToString();

                double custo = Convert.ToDouble(datTabela.Rows[0]["Custo"]);

                txtValorCusto.Text = custo.ToString("0.00");
                
                int minimo = Convert.ToInt16(datTabela.Rows[0]["Minimo"]);

                int qtd = (3 * minimo);

                txtQuantidade.Text = qtd.ToString();

                txtValorTotal.Text = (qtd * custo).ToString("0.00");
            }
        }

        private void TxtValorCusto_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void TxtQuantidade_Leave(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void CalculaTotal()
        {
            if (Double.TryParse(txtValorCusto.Text, out double custo) && int.TryParse(txtQuantidade.Text, out int qtd))
            {
                txtValorTotal.Text = (qtd * custo).ToString("0.00");
            }
        }

        private void BtnIncluir_Click(object sender, System.EventArgs e)
        {
            if (cboProduto.Text == "") return;

            int idProduto = Convert.ToInt16(cboProduto.SelectedValue);

            if (Global.TemSolicitacaoAberta(idProduto) != -1)
            {
                MessageBox.Show("Há uma solicitação do produto ainda aberta. Experimente atualizar ela.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into abastecimentos(data_hora, id_fornecedor, id_produto, valor_custo, qtd, total, chegou) 
                                              values(?data_hora, ?id_fornecedor, ?id_produto, ?valor_custo, ?qtd, ?total, ?chegou)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?data_hora", Convert.ToDateTime(mtbDataHora.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            Global.Comando.Parameters.AddWithValue("?id_fornecedor", idFornecedor);
            Global.Comando.Parameters.AddWithValue("?id_produto", idProduto);
            Global.Comando.Parameters.AddWithValue("?valor_custo", Convert.ToDouble(txtValorCusto.Text));
            Global.Comando.Parameters.AddWithValue("?qtd", Convert.ToInt16(txtQuantidade.Text));
            Global.Comando.Parameters.AddWithValue("?total", Convert.ToDouble(txtValorTotal.Text));
            Global.Comando.Parameters.AddWithValue("?chegou", Convert.ToBoolean(chkChegou.Checked));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvSolicitacoes.DataSource = Global.ConsultaAbastecimentos("");
        }

        private void BtnAtualizar_Click(object sender, System.EventArgs e)
        {
            if (txtID.Text == "") {
                MessageBox.Show("Selecione a solicitação que deseja atualizar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt16(txtID.Text);

            int idProduto = Convert.ToInt16(cboProduto.SelectedValue);

            if (Global.TemSolicitacaoAberta(idProduto) != id)
            {
                MessageBox.Show("Há uma solicitação do produto ainda aberta. Experimente atualizar ela.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update abastecimentos set id_fornecedor = ?id_fornecedor, id_produto = ?id_produto, valor_custo = ?valor_custo, 
                                              qtd = ?qtd, total = ?total, chegou = ?chegou where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?id_fornecedor", idFornecedor);
            Global.Comando.Parameters.AddWithValue("?id_produto", cboProduto.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?valor_custo", Convert.ToDouble(txtValorCusto.Text));
            Global.Comando.Parameters.AddWithValue("?qtd", txtQuantidade.Text);
            Global.Comando.Parameters.AddWithValue("?total", Convert.ToDouble(txtValorTotal.Text));
            Global.Comando.Parameters.AddWithValue("?chegou", Convert.ToBoolean(chkChegou.Checked));
            Global.Comando.Parameters.AddWithValue("?id", id);

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
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione a solicitação que deseja excluir.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir a solicitação de " + cboProduto.Text + " feita em " +
                                mtbDataHora.Text + "?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
