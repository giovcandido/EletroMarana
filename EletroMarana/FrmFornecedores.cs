using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        void limpaCampos()
        {
            txtID.Clear();
            txtRazaoSocial.Clear();
            txtFantasia.Clear();
            txtCEP.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCNPJ.Clear();
            txtIE.Clear();
            txtFone.Clear();
            txtCelular.Clear();
            txtRepresentante.Clear();
            txtEmail.Clear();

            cboCidade.SelectedItem = null;
            cboCidade.ResetText();

            txtPesquisa.Clear();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            dgvFornecedores.DataSource = Global.consultaFornecedores("");

            txtRazaoSocial.Select();

            cboCidade.DataSource = Global.consultaCidades("");
            cboCidade.DisplayMember = "Nome";
            cboCidade.ValueMember = "Código";

            limpaCampos();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtRazaoSocial.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("insert into fornecedores(razao_social, fantasia, cep, rua, numero, complemento, bairro, id_cidade, cnpj, ie, fone, " +
                                              "celular, representante, email) values(?razao_social, ?fantasia, ?cep, ?rua, ?numero, ?complemento, ?bairro, ?id_cidade, " +
                                              "?cnpj, ?ie, ?fone, ?celular, ?representante, ?email)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?razao_social", txtRazaoSocial.Text);
            Global.Comando.Parameters.AddWithValue("?fantasia", txtFantasia.Text);
            Global.Comando.Parameters.AddWithValue("?cep", txtCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?cnpj", txtCNPJ.Text);
            Global.Comando.Parameters.AddWithValue("?ie", txtIE.Text);
            Global.Comando.Parameters.AddWithValue("?fone", txtFone.Text);
            Global.Comando.Parameters.AddWithValue("?celular", txtCelular.Text);
            Global.Comando.Parameters.AddWithValue("?representante", txtRepresentante.Text);
            Global.Comando.Parameters.AddWithValue("?email", txtEmail.Text);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            limpaCampos();

            dgvFornecedores.DataSource = Global.consultaFornecedores("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvFornecedores.DataSource = Global.consultaFornecedores(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFornecedores.Rows.Count > 0)
            {
                txtID.Text = dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
                txtRazaoSocial.Text = dgvFornecedores.CurrentRow.Cells[1].Value.ToString();
                txtFantasia.Text = dgvFornecedores.CurrentRow.Cells[2].Value.ToString();
                txtCEP.Text = dgvFornecedores.CurrentRow.Cells[3].Value.ToString();
                txtRua.Text = dgvFornecedores.CurrentRow.Cells[4].Value.ToString();
                txtNumero.Text = dgvFornecedores.CurrentRow.Cells[5].Value.ToString();
                txtComplemento.Text = dgvFornecedores.CurrentRow.Cells[6].Value.ToString();
                txtBairro.Text = dgvFornecedores.CurrentRow.Cells[7].Value.ToString();
                cboCidade.Text = dgvFornecedores.CurrentRow.Cells[8].Value.ToString();
                txtCNPJ.Text = dgvFornecedores.CurrentRow.Cells[9].Value.ToString();
                txtIE.Text = dgvFornecedores.CurrentRow.Cells[10].Value.ToString();
                txtFone.Text = dgvFornecedores.CurrentRow.Cells[11].Value.ToString();
                txtCelular.Text = dgvFornecedores.CurrentRow.Cells[12].Value.ToString();
                txtEmail.Text = dgvFornecedores.CurrentRow.Cells[13].Value.ToString();
                txtRepresentante.Text = dgvFornecedores.CurrentRow.Cells[14].Value.ToString();
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("update fornecedores set razao_social = ?razao_social, fantasia = ?fantasia, cep = ?cep, rua = ?rua, " + 
                                              "numero = ?numero, complemento = ?complemento, bairro = ?bairro, id_cidade = ?id_cidade, cnpj = ?cnpj, " +
                                              "ie = ?ie, fone = ?fone, celular = ?celular, representante = ?representante, email = ?email where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?razao_social", txtRazaoSocial.Text);
            Global.Comando.Parameters.AddWithValue("?fantasia", txtFantasia.Text);
            Global.Comando.Parameters.AddWithValue("?cep", txtCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?cnpj", txtCNPJ.Text);
            Global.Comando.Parameters.AddWithValue("?ie", txtIE.Text);
            Global.Comando.Parameters.AddWithValue("?fone", txtFone.Text);
            Global.Comando.Parameters.AddWithValue("?celular", txtCelular.Text);
            Global.Comando.Parameters.AddWithValue("?representante", txtRepresentante.Text);
            Global.Comando.Parameters.AddWithValue("?email", txtEmail.Text);
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            limpaCampos();

            dgvFornecedores.DataSource = Global.consultaFornecedores("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();

            dgvFornecedores.DataSource = Global.consultaFornecedores("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir o fornecedor " + txtFantasia.Text + "?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("delete from fornecedores where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                limpaCampos();

                dgvFornecedores.DataSource = Global.consultaFornecedores("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFantasia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
