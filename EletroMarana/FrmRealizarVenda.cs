using System;
using System.Data;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmRealizarVenda : Form
    {
        long idVenda;

        DataTable datTabelaProduto;
        int linhaAtualProdutos;
        double valorTotal;

        public FrmRealizarVenda()
        {
            InitializeComponent();
        }

        private void FrmRealizarVenda_Load(object sender, EventArgs e)
        {
            cboCliente.DataSource = Global.ConsultaClientes("");
            cboCliente.DisplayMember = "Nome";
            cboCliente.ValueMember = "Código";

            datTabelaProduto = Global.ConsultaProdutosDescricao("");

            cboProduto.DataSource = datTabelaProduto;
            cboProduto.DisplayMember = "Nome";
            cboProduto.ValueMember = "Código";

            cboTipoPGTO.DataSource = Global.ConsultaTiposPGTO("");
            cboTipoPGTO.DisplayMember = "Nome";
            cboTipoPGTO.ValueMember = "Código";

            LimpaCampos();

            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
        }

        private void LimpaCampos()
        {
            idVenda = -1;

            txtID.Clear();

            cboCliente.SelectedItem = null;
            cboCliente.ResetText();

            mtbDataHora.Text = DateTime.Now.ToString();

            valorTotal = 0;
            txtValorTotal.Text = valorTotal.ToString("0.00");

            LimpaCamposProduto();

            cboTipoPGTO.SelectedItem = null;
            cboTipoPGTO.ResetText();

            dgvProdutos.DataSource = null;
            dgvProdutos.Rows.Clear();

            cboCliente.Select();
        }

        private void LimpaCamposProduto()
        {
            cboProduto.SelectedItem = null;
            cboProduto.ResetText();

            txtValorUnitario.Clear();
            txtQuantidade.Clear();

            cboProduto.Select();
        }

        private void CboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduto.SelectedItem != null)
            {
                txtValorUnitario.Text = datTabelaProduto.Rows[cboProduto.SelectedIndex]["Valor Venda"].ToString();
            }
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem == null) return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into venda_cab(id_usuario, id_cliente, data_hora, total, id_tipo_pgto) 
                                              value(?id_usuario, ?id_cliente, ?data_hora, ?total, ?id_tipo_pgto)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?id_usuario", Global.usuarioLogado.Item1);
            Global.Comando.Parameters.AddWithValue("?id_cliente", cboCliente.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?data_hora", Convert.ToDateTime(mtbDataHora.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            Global.Comando.Parameters.AddWithValue("?total", valorTotal);
            Global.Comando.Parameters.AddWithValue("?id_tipo_pgto", cboTipoPGTO.SelectedValue);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            idVenda = Global.Comando.LastInsertedId;

            txtID.Text = idVenda.ToString();

            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
            dgvProdutos.DataSource = Global.ConsultaVendaDET(idVenda);
        }

        private void DgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVendas.RowCount > 0)
            {
                linhaAtualProdutos = dgvProdutos.CurrentRow.Index;

                cboProduto.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
                txtValorUnitario.Text = dgvProdutos.CurrentRow.Cells[3].Value.ToString();
                txtQuantidade.Text = dgvProdutos.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (cboProduto.SelectedItem == null) return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into venda_det(id_venda, id_produto, qtd, vlr_unitario) 
                                              value(?id_venda, ?id_produto, ?qtd, ?vlr_unitario)", Global.Conexao);

            double valor_unit = Convert.ToDouble(txtValorUnitario.Text);
            int qtd = Convert.ToInt16(txtQuantidade.Text);

            Global.Comando.Parameters.AddWithValue("?id_venda", idVenda);
            Global.Comando.Parameters.AddWithValue("?id_produto", cboProduto.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?vlr_unitario", valor_unit);
            Global.Comando.Parameters.AddWithValue("?qtd", qtd);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCamposProduto();

            dgvProdutos.DataSource = Global.ConsultaVendaDET(idVenda);
           
            valorTotal += valor_unit * qtd;

            txtValorTotal.Text = valorTotal.ToString("0.00");

            AtualizaTotal();
            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
        }

        private void AtualizaTotal()
        {
            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update venda_cab set total = ?total where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?total", valorTotal);
            Global.Comando.Parameters.AddWithValue("?id", idVenda);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (cboProduto.SelectedItem == null) return;

            double valor_unit = Convert.ToDouble(dgvProdutos.Rows[linhaAtualProdutos].Cells[3].Value.ToString());
            int qtd = Convert.ToInt16(dgvProdutos.Rows[linhaAtualProdutos].Cells[4].Value.ToString());

            valorTotal -= valor_unit * qtd;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update venda_det set id_produto = ?id_produto, valor_unitario = ?valor_unitario, 
                                              qtd = ?qtd where id = ?id", Global.Conexao);

            valor_unit = Convert.ToDouble(txtValorUnitario.Text);
            qtd = Convert.ToInt16(txtQuantidade.Text);

            Global.Comando.Parameters.AddWithValue("?id_produto", cboProduto.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?qtd", qtd);
            Global.Comando.Parameters.AddWithValue("?vlr_unitario", valor_unit);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            dgvProdutos.DataSource = Global.ConsultaVendaDET(idVenda);

            LimpaCamposProduto();

            valorTotal += valor_unit * qtd;

            txtValorTotal.Text = valorTotal.ToString("0.00");

            AtualizaTotal();
            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            if (cboProduto.SelectedItem == null) return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"delete from venda_det where id_venda = ?id_venda 
                                              and id_produto = ?id_produto", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?id_venda", idVenda);
            Global.Comando.Parameters.AddWithValue("?id_produto", cboProduto.SelectedValue);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            dgvProdutos.DataSource = Global.ConsultaVendaDET(idVenda);

            string valor_unit = dgvProdutos.Rows[linhaAtualProdutos].Cells[3].Value.ToString();
            string qtd = dgvProdutos.Rows[linhaAtualProdutos].Cells[4].Value.ToString();

            valorTotal -= Convert.ToDouble(valor_unit) * Convert.ToInt16(qtd);

            txtValorTotal.Text = valorTotal.ToString("0.00");

            AtualizaTotal();
            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCamposProduto();
        }

        private void DgvVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVendas.RowCount > 0)
            {
                string id = dgvVendas.CurrentRow.Cells[0].Value.ToString();

                txtID.Text = id;

                cboCliente.Text = dgvVendas.CurrentRow.Cells[2].Value.ToString();
                mtbDataHora.Text = dgvVendas.CurrentRow.Cells[3].Value.ToString();
                txtValorTotal.Text = dgvVendas.CurrentRow.Cells[4].Value.ToString();
                cboTipoPGTO.Text = dgvVendas.CurrentRow.Cells[5].Value.ToString();

                dgvProdutos.Columns.Clear();

                dgvProdutos.DataSource = Global.ConsultaVendaDET(Convert.ToInt16(id));
            }
        }

        private void BtnFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            AtualizaVendaCAB();

            LimpaCampos();

            MessageBox.Show("Venda finalizada com sucesso!",
                            "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
        }

        private void AtualizaVendaCAB()
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update venda_cab set id_cliente = ?id_cliente, total = ?total, 
                                              id_tipo_pgto = ?id_tipo_pgto where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?id_cliente", cboCliente.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?total", valorTotal);
            Global.Comando.Parameters.AddWithValue("?id_tipo_pgto", cboTipoPGTO.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?id", txtID.Text);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();
        }

        private void BtnAtualizarVenda_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            AtualizaVendaCAB();

            LimpaCampos();

            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
        }

        private void BtnCancelarVenda_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
        }

        private void BtnExcluirVenda_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir a venda feita ao cliente " + cboCliente.Text + " em " +
                                mtbDataHora.Text + "?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("delete from venda_cab where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                LimpaCampos();

                dgvVendas.DataSource = Global.ConsultaVendaCAB("");
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
