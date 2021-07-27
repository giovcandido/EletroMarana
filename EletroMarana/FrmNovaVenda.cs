using System;
using System.Data;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmNovaVenda : Form
    {
        DataTable datTabelaProduto;
        int linhaAtualProdutos;
        double valorTotal;

        public FrmNovaVenda()
        {
            InitializeComponent();
        }

        void limpaCamposProduto()
        {
            cboProduto.SelectedItem = null;
            cboProduto.ResetText();

            txtValorUnitario.Clear();
            txtQuantidade.Clear();
        }

        void limpaCampos()
        {
            txtID.Clear();

            cboCliente.SelectedItem = null;
            cboCliente.ResetText();

            mtbDataHora.Text = DateTime.Now.ToString();

            valorTotal = 0;
            txtValorTotal.Clear();

            limpaCamposProduto();

            cboTipoPGTO.SelectedItem = null;
            cboTipoPGTO.ResetText();

            dgvProdutos.Rows.Clear();
        }

        private void FrmNovaVenda_Load(object sender, EventArgs e)
        {
            cboCliente.DataSource = Global.consultaClientes("");
            cboCliente.DisplayMember = "Nome";
            cboCliente.ValueMember = "Código";

            datTabelaProduto = Global.consultaProdutos("");

            cboProduto.DataSource = datTabelaProduto;
            cboProduto.DisplayMember = "Nome";
            cboProduto.ValueMember = "Código";

            cboTipoPGTO.DataSource = Global.consultaTiposPGTO("");
            cboTipoPGTO.DisplayMember = "Nome";
            cboTipoPGTO.ValueMember = "Código";

            dgvProdutos.Columns.Add("id", "Código");
            dgvProdutos.Columns.Add("produto", "Produto");
            dgvProdutos.Columns.Add("valor_unit", "Valor Unitário");
            dgvProdutos.Columns.Add("quantidade", "Quantidade");

            limpaCampos();

            dgvVendas.DataSource = Global.consultaVendaCAB("");
        }

        private void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduto.SelectedItem != null)
            {
                string valor_unit = datTabelaProduto.Rows[cboProduto.SelectedIndex]["Valor Venda"].ToString();

                txtValorUnitario.Text = valor_unit;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int id = cboProduto.SelectedIndex;
            string produto = cboProduto.GetItemText(cboProduto.SelectedItem);
            string valor_unit = txtValorUnitario.Text;
            string quantidade = txtQuantidade.Text;

            dgvProdutos.Rows.Add(id, produto, valor_unit, quantidade);

            limpaCamposProduto();

            valorTotal += Convert.ToDouble(valor_unit) * Convert.ToInt16(quantidade);

            txtValorTotal.Text = valorTotal.ToString("0.00");
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string valor_unit = dgvProdutos.Rows[linhaAtualProdutos].Cells[2].Value.ToString();
            string quantidade = dgvProdutos.Rows[linhaAtualProdutos].Cells[3].Value.ToString();

            valorTotal -= Convert.ToDouble(valor_unit) * Convert.ToInt16(quantidade);

            txtValorTotal.Text = valorTotal.ToString("0.00");

            dgvProdutos.Rows.RemoveAt(linhaAtualProdutos);

            limpaCamposProduto();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCamposProduto();
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linhaAtualProdutos = dgvProdutos.CurrentRow.Index;

            cboProduto.Text = dgvProdutos.CurrentRow.Cells[1].Value.ToString();
            txtValorUnitario.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
            txtQuantidade.Text = dgvProdutos.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string valor_unit = dgvProdutos.Rows[linhaAtualProdutos].Cells[2].Value.ToString();
            string quantidade = dgvProdutos.Rows[linhaAtualProdutos].Cells[3].Value.ToString();

            valorTotal -= Convert.ToDouble(valor_unit) * Convert.ToInt16(quantidade);

            dgvProdutos.Rows.RemoveAt(linhaAtualProdutos);

            int id = cboProduto.SelectedIndex;
            string produto = cboProduto.GetItemText(cboProduto.SelectedItem);
            
            valor_unit = txtValorUnitario.Text;
            quantidade = txtQuantidade.Text;

            dgvProdutos.Rows.Add(id, produto, valor_unit, quantidade);

            valorTotal += Convert.ToDouble(valor_unit) * Convert.ToInt16(quantidade);

            txtValorTotal.Text = valorTotal.ToString("0.00");

            limpaCamposProduto();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEfetuarVenda_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem == null) return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("insert into venda_cab(id_usuario, id_cliente, data_hora, total, id_tipo_pgto) " +
                                              "value(?id_usuario, ?id_cliente, ?data_hora, ?total, ?id_tipo_pgto)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?id_usuario", Global.usuarioLogado.Item1);
            Global.Comando.Parameters.AddWithValue("?id_cliente", cboCliente.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?data_hora", Convert.ToDateTime(mtbDataHora.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            Global.Comando.Parameters.AddWithValue("?total", valorTotal);
            Global.Comando.Parameters.AddWithValue("?id_tipo_pgto", cboTipoPGTO.SelectedValue);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            limpaCampos();

            dgvVendas.DataSource = Global.consultaVendaCAB("");
        }

        private void dgvVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVendas.RowCount > 0)
            {
                string id = dgvVendas.CurrentRow.Cells[0].Value.ToString();

                txtID.Text = id;

                cboCliente.Text = dgvVendas.CurrentRow.Cells[2].Value.ToString();
                mtbDataHora.Text = dgvVendas.CurrentRow.Cells[3].Value.ToString();
                txtValorTotal.Text = dgvVendas.CurrentRow.Cells[4].Value.ToString();
                cboTipoPGTO.Text = dgvVendas.CurrentRow.Cells[5].Value.ToString();

                //dgvProdutos.DataSource = Global.consultaVendaDET(Convert.ToInt16(id));
            }
        }

        private void btnAtualizarVenda_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("update venda_cab set id_cliente = ?id_cliente, data_hora = ?data_hora, " +
                                              "total = ?total, id_tipo_pgto = ?id_tipo_pgto where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?id_cliente", cboCliente.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?data_hora", Convert.ToDateTime(mtbDataHora.Text).ToString("yyyy - MM - dd HH: mm:ss"));
            Global.Comando.Parameters.AddWithValue("?total", valorTotal);
            Global.Comando.Parameters.AddWithValue("?id_tipo_pgto", cboTipoPGTO.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?id", txtID.Text);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            limpaCampos();

            dgvVendas.DataSource = Global.consultaVendaCAB("");
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            limpaCampos();

            dgvVendas.DataSource = Global.consultaVendaCAB("");
        }

        private void btnExcluirVenda_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir a venda " + txtID.Text + "?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("delete from venda_cab where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                limpaCampos();

                dgvVendas.DataSource = Global.consultaVendaCAB("");
            }
        }
    }
}
