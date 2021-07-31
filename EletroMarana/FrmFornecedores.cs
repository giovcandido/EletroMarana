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

        private void LimpaCampos()
        {
            txtID.Clear();
            txtRazaoSocial.Clear();
            txtFantasia.Clear();
            mtbCEP.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            mtbCNPJ.Clear();
            mtbIE.Clear();
            mtbFone.Clear();
            mtbCelular.Clear();
            txtRepresentante.Clear();
            txtEmail.Clear();

            cboCidade.SelectedItem = null;
            cboCidade.ResetText();

            txtPesquisa.Clear();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            dgvFornecedores.DataSource = Global.ConsultaFornecedores("");

            txtRazaoSocial.Select();

            cboCidade.DataSource = Global.ConsultaCidades("");
            cboCidade.DisplayMember = "Nome";
            cboCidade.ValueMember = "Código";

            LimpaCampos();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            dgvFornecedores.DataSource = Global.ConsultaFornecedores(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void DgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFornecedores.Rows.Count > 0)
            {
                txtID.Text = dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
                txtRazaoSocial.Text = dgvFornecedores.CurrentRow.Cells[1].Value.ToString();
                txtFantasia.Text = dgvFornecedores.CurrentRow.Cells[2].Value.ToString();
                mtbCEP.Text = dgvFornecedores.CurrentRow.Cells[3].Value.ToString();
                txtRua.Text = dgvFornecedores.CurrentRow.Cells[4].Value.ToString();
                txtNumero.Text = dgvFornecedores.CurrentRow.Cells[5].Value.ToString();
                txtComplemento.Text = dgvFornecedores.CurrentRow.Cells[6].Value.ToString();
                txtBairro.Text = dgvFornecedores.CurrentRow.Cells[7].Value.ToString();
                cboCidade.Text = dgvFornecedores.CurrentRow.Cells[8].Value.ToString();
                mtbCNPJ.Text = dgvFornecedores.CurrentRow.Cells[9].Value.ToString();
                mtbIE.Text = dgvFornecedores.CurrentRow.Cells[10].Value.ToString();
                mtbFone.Text = dgvFornecedores.CurrentRow.Cells[11].Value.ToString();
                mtbCelular.Text = dgvFornecedores.CurrentRow.Cells[12].Value.ToString();
                txtEmail.Text = dgvFornecedores.CurrentRow.Cells[13].Value.ToString();
                txtRepresentante.Text = dgvFornecedores.CurrentRow.Cells[14].Value.ToString();
            }
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            if (txtRazaoSocial.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("insert into fornecedores(razao_social, fantasia, cep, rua, numero, complemento, bairro, id_cidade, cnpj, ie, fone, " +
                                              "celular, representante, email) values(?razao_social, ?fantasia, ?cep, ?rua, ?numero, ?complemento, ?bairro, ?id_cidade, " +
                                              "?cnpj, ?ie, ?fone, ?celular, ?representante, ?email)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?razao_social", txtRazaoSocial.Text);
            Global.Comando.Parameters.AddWithValue("?fantasia", txtFantasia.Text);
            Global.Comando.Parameters.AddWithValue("?cep", mtbCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?cnpj", mtbCNPJ.Text);
            Global.Comando.Parameters.AddWithValue("?ie", mtbIE.Text);
            Global.Comando.Parameters.AddWithValue("?fone", mtbFone.Text);
            Global.Comando.Parameters.AddWithValue("?celular", mtbCelular.Text);
            Global.Comando.Parameters.AddWithValue("?representante", txtRepresentante.Text);
            Global.Comando.Parameters.AddWithValue("?email", txtEmail.Text);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvFornecedores.DataSource = Global.ConsultaFornecedores("");
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("update fornecedores set razao_social = ?razao_social, fantasia = ?fantasia, cep = ?cep, rua = ?rua, " + 
                                              "numero = ?numero, complemento = ?complemento, bairro = ?bairro, id_cidade = ?id_cidade, cnpj = ?cnpj, " +
                                              "ie = ?ie, fone = ?fone, celular = ?celular, representante = ?representante, email = ?email where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?razao_social", txtRazaoSocial.Text);
            Global.Comando.Parameters.AddWithValue("?fantasia", txtFantasia.Text);
            Global.Comando.Parameters.AddWithValue("?cep", mtbCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?cnpj", mtbCNPJ.Text);
            Global.Comando.Parameters.AddWithValue("?ie", mtbIE.Text);
            Global.Comando.Parameters.AddWithValue("?fone", mtbFone.Text);
            Global.Comando.Parameters.AddWithValue("?celular", mtbCelular.Text);
            Global.Comando.Parameters.AddWithValue("?representante", txtRepresentante.Text);
            Global.Comando.Parameters.AddWithValue("?email", txtEmail.Text);
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvFornecedores.DataSource = Global.ConsultaFornecedores("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvFornecedores.DataSource = Global.ConsultaFornecedores("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir o fornecedor " + txtFantasia.Text + "?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("delete from fornecedores where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                LimpaCampos();

                dgvFornecedores.DataSource = Global.ConsultaFornecedores("");
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
