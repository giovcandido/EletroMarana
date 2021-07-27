using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        void limpaCampos() {
            txtID.Clear();
            txtNome.Clear();
            mtbNascimento.Clear();
            txtRenda.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtCEP.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtFone.Clear();
            txtCelular.Clear();
            txtEmail.Clear();

            cboCidade.SelectedItem = null;
            cboCidade.ResetText();

            picFoto.ImageLocation = "";

            txtPesquisa.Clear();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = Global.consultaClientes("");

            txtNome.Select();

            cboCidade.DataSource = Global.consultaCidades("");
            cboCidade.DisplayMember = "Nome";
            cboCidade.ValueMember = "Código";

            limpaCampos();
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.FileName = "";

            ofdArquivo.ShowDialog();

            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("insert into clientes(nome, cep, rua, numero, complemento, bairro, id_cidade, cpf, rg, " +
                                               "fone, celular, email, renda, data_nasc, foto) value(?nome, ?cep, ?rua, ?numero, ?complemento, " +
                                               "?bairro, ?id_cidade, ?cpf, ?rg, ?fone, ?celular, ?email, ?renda, ?data_nasc, ?foto)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?data_nasc", Convert.ToDateTime(mtbNascimento.Text));
            Global.Comando.Parameters.AddWithValue("?renda", Convert.ToDouble(txtRenda.Text));
            Global.Comando.Parameters.AddWithValue("?cpf", txtCPF.Text);
            Global.Comando.Parameters.AddWithValue("?rg", txtRG.Text);
            Global.Comando.Parameters.AddWithValue("?cep", txtCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?fone", txtFone.Text);
            Global.Comando.Parameters.AddWithValue("?celular", txtCelular.Text);
            Global.Comando.Parameters.AddWithValue("?email", txtEmail.Text);
            Global.Comando.Parameters.AddWithValue("?foto", picFoto.ImageLocation);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            limpaCampos();

            dgvClientes.DataSource = Global.consultaClientes("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvClientes.DataSource = Global.consultaClientes(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.RowCount > 0)
            {
                txtID.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                mtbNascimento.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtRenda.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                txtCPF.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                txtRG.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                txtCEP.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
                txtRua.Text = dgvClientes.CurrentRow.Cells[7].Value.ToString();
                txtNumero.Text = dgvClientes.CurrentRow.Cells[8].Value.ToString();
                txtComplemento.Text = dgvClientes.CurrentRow.Cells[9].Value.ToString();
                txtBairro.Text = dgvClientes.CurrentRow.Cells[10].Value.ToString();
                cboCidade.Text = dgvClientes.CurrentRow.Cells[11].Value.ToString();
                txtFone.Text = dgvClientes.CurrentRow.Cells[12].Value.ToString();
                txtCelular.Text = dgvClientes.CurrentRow.Cells[13].Value.ToString();
                txtEmail.Text = dgvClientes.CurrentRow.Cells[14].Value.ToString();
                picFoto.ImageLocation = dgvClientes.CurrentRow.Cells[15].Value.ToString();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("update clientes set nome = ?nome, cep = ?cep, rua = ?rua, numero = ?numero, complemento = ?complemento, bairro = ?bairro, " +
                                              "id_cidade = ?id_cidade, cpf = ?cpf, rg = ?rg, fone = ?fone, celular = ?celular, email = ?email, " +
                                              "renda = ?renda, data_nasc = ?data_nasc, foto = ?foto where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?data_nasc", Convert.ToDateTime(mtbNascimento.Text));
            Global.Comando.Parameters.AddWithValue("?renda", Convert.ToDouble(txtRenda.Text));
            Global.Comando.Parameters.AddWithValue("?cpf", txtCPF.Text);
            Global.Comando.Parameters.AddWithValue("?rg", txtRG.Text);
            Global.Comando.Parameters.AddWithValue("?cep", txtCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?fone", txtFone.Text);
            Global.Comando.Parameters.AddWithValue("?celular", txtCelular.Text);
            Global.Comando.Parameters.AddWithValue("?email", txtEmail.Text);
            Global.Comando.Parameters.AddWithValue("?foto", picFoto.ImageLocation);
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            limpaCampos();

            dgvClientes.DataSource = Global.consultaClientes("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();

            dgvClientes.DataSource = Global.consultaClientes("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir o cliente " + txtNome.Text + "?", "Exclusão",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("delete from clientes where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                limpaCampos();

                dgvClientes.DataSource = Global.consultaClientes("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
