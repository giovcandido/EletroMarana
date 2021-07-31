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

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            dgvProdutos.DataSource = Global.ConsultaProdutos("");

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
            dgvProdutos.DataSource = Global.ConsultaProdutos(txtPesquisa.Text);

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

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("insert into produtos(descricao, codigo_barra, id_categoria, id_fornecedor, prazo_garantia, " +
                                              "estoque, estoque_minimo, valor_venda, valor_custo, foto, fora_linha) " +
                                              "values(?descricao, ?codigo_barra, ?id_categoria, ?id_fornecedor, ?prazo_garantia, ?estoque, " +
                                              "?estoque_minimo, ?valor_venda, ?valor_custo, ?foto, ?fora_linha)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?codigo_barra", mtbCodigoBarra.Text);
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

            dgvProdutos.DataSource = Global.ConsultaProdutos("");
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("update produtos set descricao = ?descricao, codigo_barra = ?codigo_barra, " +
                                              "id_categoria = ?id_categoria, id_fornecedor = ?id_fornecedor, prazo_garantia = ?prazo_garantia, " +
                                              "estoque = ?estoque, estoque_minimo = ?estoque_minimo, valor_venda = ?valor_venda, valor_custo = ?valor_custo, " +
                                              "foto = ?foto, fora_linha = ?fora_linha where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?descricao", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?codigo_barra", mtbCodigoBarra.Text);
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

            LimpaCampos();

            dgvProdutos.DataSource = Global.ConsultaProdutos("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvProdutos.DataSource = Global.ConsultaProdutos("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

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

                dgvProdutos.DataSource = Global.ConsultaProdutos("");
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
