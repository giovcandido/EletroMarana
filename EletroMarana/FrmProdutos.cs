using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            dgvProdutos.DataSource = Global.ConsultaProdutosDescricao("");

            dgvProdutos.Columns[3].Width = 120;
            dgvProdutos.Columns[9].Width = 120;

            cboCategoria.DataSource = Global.ConsultaCategorias("");
            cboCategoria.DisplayMember = "Nome";
            cboCategoria.ValueMember = "Código";

            cboFornecedor.DataSource = Global.ConsultaFornecedores("");
            cboFornecedor.DisplayMember = "Fantasia";
            cboFornecedor.ValueMember = "Código";

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            mtbCodigoBarra.Clear();
            txtPrazoGarantia.Clear();
            txtEstoque.Clear();
            txtEstoqueMinimo.Clear();
            txtValorCusto.Clear();
            txtValorVenda.Clear();

            cboCategoria.SelectedItem = null;
            cboCategoria.ResetText();

            cboFornecedor.SelectedItem = null;
            cboFornecedor.ResetText();

            picFoto.ImageLocation = "";

            chkForaLinha.Checked = false;

            txtPesquisa.Clear();

            txtNome.Select();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            dgvProdutos.DataSource = Global.ConsultaProdutosDescricao(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void DgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                txtID.Text = dgvProdutos.CurrentRow.Cells[0].Value.ToString();
                chkForaLinha.Checked = Convert.ToBoolean(dgvProdutos.CurrentRow.Cells[1].Value.ToString());
                txtNome.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
                mtbCodigoBarra.Text = dgvProdutos.CurrentRow.Cells[3].Value.ToString();
                cboCategoria.Text = dgvProdutos.CurrentRow.Cells[4].Value.ToString();
                cboFornecedor.Text = dgvProdutos.CurrentRow.Cells[5].Value.ToString();
                txtValorVenda.Text = dgvProdutos.CurrentRow.Cells[6].Value.ToString();
                txtValorCusto.Text = dgvProdutos.CurrentRow.Cells[7].Value.ToString();
                txtPrazoGarantia.Text = dgvProdutos.CurrentRow.Cells[8].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells[9].Value.ToString();
                txtEstoqueMinimo.Text = dgvProdutos.CurrentRow.Cells[10].Value.ToString();
                picFoto.ImageLocation = dgvProdutos.CurrentRow.Cells[11].Value.ToString();
            }
        }

        private void PicFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "";

            ofdArquivo.FileName = "";

            ofdArquivo.ShowDialog();

            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private Boolean validaCampos()
        {
            //Falta acabar as validações

            String nome = txtNome.Text, cod_barra = mtbCodigoBarra.Text,
                   prazo_garantia = txtPrazoGarantia.Text, valor_venda = txtValorVenda.Text,
                   valor_custo = txtValorCusto.Text, estoque = txtEstoque.Text,
                   estoque_minimo = txtEstoqueMinimo.Text;

            if (nome == "")
            {
                MessageBox.Show("Ocorreu um erro! Nome do Produto inválido!", "Nome do Produto Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }

            if (cod_barra.Length != 15)
            {
                MessageBox.Show("Ocorreu um erro! Código de Barras inválido!", "Código de Barras Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbCodigoBarra.Focus();
                return false;
            }

            if (prazo_garantia == "" || Int32.Parse(prazo_garantia) < 1)
            {
                MessageBox.Show("Ocorreu um erro! Prazo de Garantia inválido!",
                                "Prazo de Garantia Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrazoGarantia.Focus();
                return false;
            }

            if (cboCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Ocorreu um erro! Você não selecionou nenhuma categoria",
                                "Categoria Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCategoria.Focus();
                return false;
            }

            if (valor_venda == "" || Double.Parse(valor_venda) < 0)
            {
                MessageBox.Show("Ocorreu um erro! Valor de venda inválido",
                                "Valor de Venda Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValorVenda.Focus();
                return false;
            }

            if (cboFornecedor.SelectedIndex == -1)
            {
                MessageBox.Show("Ocorreu um erro! Você não selecionou nenhum fornecedor!", "Fornecedor Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboFornecedor.Focus();
                return false;
            }

            if (valor_custo == "" || Double.Parse(valor_custo) < 0)
            {
                MessageBox.Show("Ocorreu um erro! Valor de custo inválido",
                                "Valor de Custo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValorCusto.Focus();
                return false;
            }

            if (estoque == "" || Int32.Parse(estoque) < 0)
            {
                MessageBox.Show("Ocorreu um erro! Estoque inválido!",
                                "Estoque Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEstoque.Focus();
                return false;
            }

            if (estoque_minimo == "" || Int32.Parse(estoque_minimo) < 0)
            {
                MessageBox.Show("Ocorreu um erro! Estoque Mínimo inválido!",
                                "Estoque Mínimo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEstoqueMinimo.Focus();
                return false;
            }

            return true;
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            if (!validaCampos())
            {
                return;
            }

            string codigoBarra = mtbCodigoBarra.Text;

            if (Global.TemProduto(codigoBarra) != -1)
            {
                MessageBox.Show("Não é possível inserir o produto, pois o código de barra já consta no sistema.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into produtos(descricao, codigo_barra, id_categoria, id_fornecedor, prazo_garantia, 
                                              estoque, estoque_minimo, valor_venda, valor_custo, foto, fora_linha) values(?descricao, ?codigo_barra, 
                                              ?id_categoria, ?id_fornecedor, ?prazo_garantia, ?estoque, ?estoque_minimo, ?valor_venda, ?valor_custo, 
                                              ?foto, ?fora_linha)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?codigo_barra", codigoBarra);
            Global.Comando.Parameters.AddWithValue("?id_categoria", cboCategoria.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?id_fornecedor", cboFornecedor.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?prazo_garantia", txtPrazoGarantia.Text);
            Global.Comando.Parameters.AddWithValue("?estoque", Convert.ToDouble(txtEstoque.Text));
            Global.Comando.Parameters.AddWithValue("?estoque_minimo", Convert.ToDouble(txtEstoqueMinimo.Text));
            Global.Comando.Parameters.AddWithValue("?valor_venda", Convert.ToDouble(txtValorVenda.Text));
            Global.Comando.Parameters.AddWithValue("?valor_custo", Convert.ToDouble(txtValorCusto.Text));
            Global.Comando.Parameters.AddWithValue("?foto", picFoto.ImageLocation);
            Global.Comando.Parameters.AddWithValue("?fora_linha", Convert.ToBoolean(chkForaLinha.Checked));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvProdutos.DataSource = Global.ConsultaProdutosDescricao("");
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o produto que deseja atualizar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt16(txtID.Text);

            if (!validaCampos())
            {
                return;
            }

            string codigoBarra = mtbCodigoBarra.Text;

            if (Global.TemProduto(codigoBarra) != id && Global.TemProduto(codigoBarra) != -1)
            {
                MessageBox.Show("Não é possível atualizar o produto, pois o código de barra colide com o de outro.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update produtos set descricao = ?descricao, codigo_barra = ?codigo_barra, 
                                              id_categoria = ?id_categoria, id_fornecedor = ?id_fornecedor, prazo_garantia = ?prazo_garantia, 
                                              estoque = ?estoque, estoque_minimo = ?estoque_minimo, valor_venda = ?valor_venda, valor_custo = ?valor_custo, 
                                              foto = ?foto, fora_linha = ?fora_linha where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?codigo_barra", codigoBarra);
            Global.Comando.Parameters.AddWithValue("?id_categoria", cboCategoria.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?id_fornecedor", cboFornecedor.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?prazo_garantia", txtPrazoGarantia.Text);
            Global.Comando.Parameters.AddWithValue("?estoque", Convert.ToDouble(txtEstoque.Text));
            Global.Comando.Parameters.AddWithValue("?estoque_minimo", Convert.ToDouble(txtEstoqueMinimo.Text));
            Global.Comando.Parameters.AddWithValue("?valor_venda", Convert.ToDouble(txtValorVenda.Text));
            Global.Comando.Parameters.AddWithValue("?valor_custo", Convert.ToDouble(txtValorCusto.Text));
            Global.Comando.Parameters.AddWithValue("?foto", picFoto.ImageLocation);
            Global.Comando.Parameters.AddWithValue("?fora_linha", Convert.ToBoolean(chkForaLinha.Checked));
            Global.Comando.Parameters.AddWithValue("?id", id);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvProdutos.DataSource = Global.ConsultaProdutosDescricao("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvProdutos.DataSource = Global.ConsultaProdutosDescricao("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o produto que deseja excluir.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir o produto " + txtNome.Text + "? O produto será removido " +
                                "automaticamente das vendas e das solicitações de abastecimento em que " +
                                "ele aparece.", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("delete from produtos where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                LimpaCampos();

                dgvProdutos.DataSource = Global.ConsultaProdutosDescricao("");
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)32)
            {
                e.Handled = true;
            }
        }

        private void txtPrazoGarantia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }

        private void txtValorCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtEstoqueMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }

}
