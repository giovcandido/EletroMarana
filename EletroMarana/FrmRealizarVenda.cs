﻿using System;
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

            datTabelaProduto = Global.ConsultaProdutosDisponiveisDescricao("");

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

        private Boolean validaCampos1()
        { 
            if(cboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Ocorreu um erro! Você não selecionou nenhum cliente!", "Cliente Inválido",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboProduto.Focus();
                return false;
            }
            else if(cboTipoPGTO.SelectedIndex == -1)
            {
                MessageBox.Show("Ocorreu um erro! Você não selecionou nenhum método de pagamento!", "Métodod de Pagamento Inválido",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboProduto.Focus();
                return false;
            }

            return true;
        }

        private Boolean validaCampos2()
        {
            string quantidade = txtQuantidade.Text;

            if (cboProduto.SelectedIndex == -1)
            {
                MessageBox.Show("Ocorreu um erro! Você não selecionou nenhum produto!", "Produto Inválido",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboProduto.Focus();
                return false;
            }
            else if (quantidade == "" || Int32.Parse(quantidade) < 1)
            {
                MessageBox.Show("Ocorreu um erro! Quantidade para reposição inválida.\n A quantidade deve ser maior ou igual a 1 item.",
                                "Cliente Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboProduto.Focus();
                return false;
            }

            return true;
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            if (!validaCampos1())
            {
                return;
            }

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
            if (!validaCampos2())
            {
                return;
            }

            if (cboProduto.SelectedItem == null)
            {
                return;
            }

            int idProduto = Convert.ToInt16(cboProduto.SelectedValue);

            int qtd = Convert.ToInt16(txtQuantidade.Text);

            if (qtd > Global.ConsultaEstoqueProduto(idProduto))
            {
                MessageBox.Show("Não foi possível adicionar o produto, pois a quantidade supera o estoque disponível.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LimpaCampos();

                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into venda_det(id_venda, id_produto, qtd, vlr_unitario) 
                                              value(?id_venda, ?id_produto, ?qtd, ?vlr_unitario)", Global.Conexao);

            double valor_unit = Convert.ToDouble(txtValorUnitario.Text);
       
            Global.Comando.Parameters.AddWithValue("?id_venda", idVenda);
            Global.Comando.Parameters.AddWithValue("?id_produto", idProduto);
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
            if (!validaCampos2())
            {
                return;
            }

            if (cboProduto.SelectedItem == null)
            {
                return;
            }

            int idProduto = Convert.ToInt16(cboProduto.SelectedValue);

            int qtd = Convert.ToInt16(txtQuantidade.Text);

            if (qtd > Global.ConsultaEstoqueProduto(idProduto))
            {
                MessageBox.Show("Não foi possível adicionar o produto, pois a quantidade supera o estoque disponível.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LimpaCampos();

                return;
            }

            double valor_unit = Convert.ToDouble(dgvProdutos.Rows[linhaAtualProdutos].Cells[3].Value);
            qtd = Convert.ToInt16(dgvProdutos.Rows[linhaAtualProdutos].Cells[4].Value);

            double valorQueSai = valor_unit * qtd;

            valor_unit = Convert.ToDouble(txtValorUnitario.Text);
            qtd = Convert.ToInt16(txtQuantidade.Text);

            double valorQueEntra = valor_unit * qtd;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update venda_det set id_produto = ?id_produto, vlr_unitario = ?valor_unitario, 
                                              qtd = ?qtd where id = ?id", Global.Conexao);

            int id = Convert.ToInt16(dgvProdutos.Rows[linhaAtualProdutos].Cells[0].Value);

            Global.Comando.Parameters.AddWithValue("?id_produto", cboProduto.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?valor_unitario", valor_unit);
            Global.Comando.Parameters.AddWithValue("?qtd", qtd);
            Global.Comando.Parameters.AddWithValue("?id", id);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            dgvProdutos.DataSource = Global.ConsultaVendaDET(idVenda);

            LimpaCamposProduto();

            valorTotal -= valorQueSai;
            valorTotal += valorQueEntra;

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

            double valor_unit = Convert.ToDouble(txtValorUnitario.Text);
            int qtd = Convert.ToInt16(txtQuantidade.Text);

            valorTotal -= valor_unit * qtd;

            LimpaCamposProduto();

            txtValorTotal.Text = valorTotal.ToString("0.00");

            AtualizaTotal();
            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCamposProduto();
        }

        private void dgvProdutos_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvProdutos.DataSource != null)
            {
                dgvProdutos.Columns[0].Visible = false;
            }
        }

        private void DgvVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVendas.RowCount > 0)
            {
                idVenda = Convert.ToInt32(dgvVendas.CurrentRow.Cells[0].Value);

                txtID.Text = idVenda.ToString();

                cboCliente.Text = dgvVendas.CurrentRow.Cells[2].Value.ToString();
                mtbDataHora.Text = dgvVendas.CurrentRow.Cells[3].Value.ToString();

                valorTotal = Convert.ToDouble(dgvVendas.CurrentRow.Cells[4].Value);

                txtValorTotal.Text = valorTotal.ToString();

                cboTipoPGTO.Text = dgvVendas.CurrentRow.Cells[5].Value.ToString();

                dgvProdutos.Columns.Clear();

                dgvProdutos.DataSource = Global.ConsultaVendaDET(idVenda);
            }
        }

        private void BtnFinalizarVenda_Click(object sender, EventArgs e)
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

            LimpaCampos();

            MessageBox.Show("Venda finalizada com sucesso!",
                            "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvVendas.DataSource = Global.ConsultaVendaCAB("");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void BtnCancelarVenda_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                return;
            }

            if (MessageBox.Show("Deseja realmente cancelar a venda?", "Cancelamento", MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ExcluiVenda();

                LimpaCampos();

                dgvVendas.DataSource = Global.ConsultaVendaCAB("");
            }
        }

        private void ExcluiVenda()
        {
            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("delete from venda_cab where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void FrmRealizarVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja mesmo continuar?", "Fechar", MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resp == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if(txtID.Text != "")
            {
                ExcluiVenda();
            }
        }
    }
}
