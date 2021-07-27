using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        void limpaCampos() {
            txtID.Clear();
            txtNome.Clear();
            txtCodigoBarra.Clear();
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
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            dgvProdutos.DataSource = Global.consultaProdutos("");

            dgvProdutos.Columns[3].Width = 120;
            dgvProdutos.Columns[9].Width = 120;

            txtNome.Select();

            cboCategoria.DataSource = Global.consultaCategorias("");
            cboCategoria.DisplayMember = "Nome";
            cboCategoria.ValueMember = "Código";

            cboFornecedor.DataSource = Global.consultaFornecedores("");
            cboFornecedor.DisplayMember = "Fantasia";
            cboFornecedor.ValueMember = "Código";

            limpaCampos();
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "";

            ofdArquivo.FileName = "";

            ofdArquivo.ShowDialog();

            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("insert into produtos(descricao, codigo_barra, id_categoria, id_fornecedor, prazo_garantia, " +
                                              "estoque, estoque_minimo, valor_venda, valor_custo, foto, fora_linha) " +
                                              "values(?descricao, ?codigo_barra, ?id_categoria, ?id_fornecedor, ?prazo_garantia, ?estoque, " +
                                              "?estoque_minimo, ?valor_venda, ?valor_custo, ?foto, ?fora_linha)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?codigo_barra", txtCodigoBarra.Text);
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

            limpaCampos();

            dgvProdutos.DataSource = Global.consultaProdutos("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvProdutos.DataSource = Global.consultaProdutos(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0) {
                txtID.Text = dgvProdutos.CurrentRow.Cells[0].Value.ToString();
                chkForaLinha.Checked = Convert.ToBoolean(dgvProdutos.CurrentRow.Cells[1].Value.ToString());
                txtNome.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
                txtCodigoBarra.Text = dgvProdutos.CurrentRow.Cells[3].Value.ToString();
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("update produtos set descricao = ?descricao, codigo_barra = ?codigo_barra, " +
                                              "id_categoria = ?id_categoria, id_fornecedor = ?id_fornecedor, prazo_garantia = ?prazo_garantia, " +
                                              "estoque = ?estoque, estoque_minimo = ?estoque_minimo, valor_venda = ?valor_venda, valor_custo = ?valor_custo, " +
                                              "foto = ?foto, fora_linha = ?fora_linha where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?codigo_barra", txtCodigoBarra.Text);
            Global.Comando.Parameters.AddWithValue("?id_categoria", cboCategoria.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?id_fornecedor", cboFornecedor.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?prazo_garantia", txtPrazoGarantia.Text);
            Global.Comando.Parameters.AddWithValue("?estoque", Convert.ToDouble(txtEstoque.Text));
            Global.Comando.Parameters.AddWithValue("?estoque_minimo", Convert.ToDouble(txtEstoqueMinimo.Text));
            Global.Comando.Parameters.AddWithValue("?valor_venda", Convert.ToDouble(txtValorVenda.Text));
            Global.Comando.Parameters.AddWithValue("?valor_custo", Convert.ToDouble(txtValorCusto.Text));
            Global.Comando.Parameters.AddWithValue("?foto", picFoto.ImageLocation);
            Global.Comando.Parameters.AddWithValue("?fora_linha", Convert.ToBoolean(chkForaLinha.Checked));
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            limpaCampos();

            dgvProdutos.DataSource = Global.consultaProdutos("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();

            dgvProdutos.DataSource = Global.consultaProdutos("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir o produto " + txtNome.Text + "?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("delete from produtos where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                limpaCampos();

                dgvProdutos.DataSource = Global.consultaProdutos("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
