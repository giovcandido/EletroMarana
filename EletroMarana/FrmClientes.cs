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

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = Global.ConsultaClientes("");

            cboCidade.DataSource = Global.ConsultaCidades("");
            cboCidade.DisplayMember = "Nome";
            cboCidade.ValueMember = "Código";

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            mtbNascimento.Clear();
            txtRenda.Clear();
            mtbCPF.Clear();
            mtbRG.Clear();
            mtbCEP.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            mtbFone.Clear();
            mtbCelular.Clear();
            txtEmail.Clear();

            cboCidade.SelectedItem = null;
            cboCidade.ResetText();

            picFoto.ImageLocation = "";

            txtPesquisa.Clear();

            txtNome.Select();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            dgvClientes.DataSource = Global.ConsultaClientes(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.RowCount > 0)
            {
                txtID.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                mtbNascimento.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtRenda.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                mtbCPF.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                mtbRG.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                mtbCEP.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
                txtRua.Text = dgvClientes.CurrentRow.Cells[7].Value.ToString();
                txtNumero.Text = dgvClientes.CurrentRow.Cells[8].Value.ToString();
                txtComplemento.Text = dgvClientes.CurrentRow.Cells[9].Value.ToString();
                txtBairro.Text = dgvClientes.CurrentRow.Cells[10].Value.ToString();
                cboCidade.Text = dgvClientes.CurrentRow.Cells[11].Value.ToString();
                mtbFone.Text = dgvClientes.CurrentRow.Cells[12].Value.ToString();
                mtbCelular.Text = dgvClientes.CurrentRow.Cells[13].Value.ToString();
                txtEmail.Text = dgvClientes.CurrentRow.Cells[14].Value.ToString();
                picFoto.ImageLocation = dgvClientes.CurrentRow.Cells[15].Value.ToString();
            }
        }

        private void PicFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.FileName = "";

            ofdArquivo.ShowDialog();

            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            string cpf = mtbCPF.Text;

            if (Global.TemCliente(cpf) != -1)
            {
                MessageBox.Show("Não é possível incluir o cliente, pois o CPF inserido já consta no sistema.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into clientes(nome, cep, rua, numero, complemento, bairro, id_cidade, cpf, rg,
                                              fone, celular, email, renda, data_nasc, foto) value(?nome, ?cep, ?rua, ?numero, ?complemento,
                                              ?bairro, ?id_cidade, ?cpf, ?rg, ?fone, ?celular, ?email, ?renda, ?data_nasc, ?foto)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?data_nasc", Convert.ToDateTime(mtbNascimento.Text));

            if (txtRenda.Text == "")
            {
                Global.Comando.Parameters.AddWithValue("?renda", null);
            }
            else
            {
                Global.Comando.Parameters.AddWithValue("?renda", Convert.ToDouble(txtRenda.Text));
            }

            Global.Comando.Parameters.AddWithValue("?cpf", cpf);
            Global.Comando.Parameters.AddWithValue("?rg", mtbRG.Text);
            Global.Comando.Parameters.AddWithValue("?cep", mtbCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?fone", mtbFone.Text);
            Global.Comando.Parameters.AddWithValue("?celular", mtbCelular.Text);
            Global.Comando.Parameters.AddWithValue("?email", txtEmail.Text);
            Global.Comando.Parameters.AddWithValue("?foto", picFoto.ImageLocation);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvClientes.DataSource = Global.ConsultaClientes("");
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o cliente que deseja atualizar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt16(txtID.Text);

            string cpf = mtbCPF.Text;

            if (Global.TemCliente(cpf) != id)
            {
                MessageBox.Show("Não é possível atualizar o cliente, o CPF já consta no sistema.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update clientes set nome = ?nome, cep = ?cep, rua = ?rua, numero = ?numero, complemento = ?complemento, 
                                              bairro = ?bairro, id_cidade = ?id_cidade, cpf = ?cpf, rg = ?rg, fone = ?fone, celular = ?celular, email = ?email, 
                                              renda = ?renda, data_nasc = ?data_nasc, foto = ?foto where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?data_nasc", Convert.ToDateTime(mtbNascimento.Text));

            if (txtRenda.Text == "")
            {
                Global.Comando.Parameters.AddWithValue("?renda", null);
            }
            else
            {
                Global.Comando.Parameters.AddWithValue("?renda", Convert.ToDouble(txtRenda.Text));
            }

            Global.Comando.Parameters.AddWithValue("?cpf", cpf);
            Global.Comando.Parameters.AddWithValue("?rg", mtbRG.Text);
            Global.Comando.Parameters.AddWithValue("?cep", mtbCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?fone", mtbFone.Text);
            Global.Comando.Parameters.AddWithValue("?celular", mtbCelular.Text);
            Global.Comando.Parameters.AddWithValue("?email", txtEmail.Text);
            Global.Comando.Parameters.AddWithValue("?foto", picFoto.ImageLocation);
            Global.Comando.Parameters.AddWithValue("?id", id);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvClientes.DataSource = Global.ConsultaClientes("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvClientes.DataSource = Global.ConsultaClientes("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o cliente que deseja excluir.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir o cliente " + txtNome.Text + "? Como consequência, as " +
                                "vendas feitas a ele serão automaticamente excluídas.", "Exclusão", MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("delete from clientes where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                LimpaCampos();

                dgvClientes.DataSource = Global.ConsultaClientes("");
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
