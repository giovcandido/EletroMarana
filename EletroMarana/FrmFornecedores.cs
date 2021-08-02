using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            dgvFornecedores.DataSource = Global.ConsultaFornecedores("");

            cboCidade.DataSource = Global.ConsultaCidades("");
            cboCidade.DisplayMember = "Nome";
            cboCidade.ValueMember = "Código";

            LimpaCampos();
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

            txtRazaoSocial.Select();
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
        private Boolean validaCampos()
        {
            //Falta acabar as validações

            String razaoSocial = txtRazaoSocial.Text, nomeFantasia = txtFantasia.Text,
                   cep = mtbCEP.Text, rua = txtRua.Text, numero = txtNumero.Text,
                   bairro = txtBairro.Text, cidade = cboCidade.Text, cnpj = mtbCNPJ.Text,
                   ie = mtbIE.Text, fone = mtbFone.Text, celular = mtbCelular.Text,
                   email = txtEmail.Text, representante = txtRepresentante.Text;

            if (razaoSocial == "")
            {
                MessageBox.Show("Ocorreu um erro! A Razão Social é inválida!", "Razão Social Inválida",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazaoSocial.Focus();
                return false;
            }

            if (nomeFantasia == "")
            {
                MessageBox.Show("Ocorreu um erro! O nome fantasia é inválido!", "Nome Fantasia Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazaoSocial.Focus();
                return false;
            }

            if (cep.Length != 9) //8 dígitos + 1 operador
            {
                MessageBox.Show("Ocorreu um erro! O CEP não está completo",
                                "CEP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbCEP.Focus();
                return false;
            }

            if (rua == "")
            {
                MessageBox.Show("Ocorreu um erro! Conteúdo do campo rua inválido!", "Conteúdo Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRua.Focus();
                return false;
            }

            if (numero == "")
            {
                MessageBox.Show("Ocorreu um erro! Conteúdo do campo número inválido!", "Conteúdo Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRua.Focus();
                return false;
            }

            if (bairro == "")
            {
                MessageBox.Show("Ocorreu um erro! Conteúdo do campo bairro inválido!", "Conteúdo Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBairro.Focus();
                return false;
            }

            if (cboCidade.SelectedIndex == -1)
            {
                MessageBox.Show("Ocorreu um erro! Você não selecionou nenhuma cidade!", "Cidade Inválida",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCidade.Focus();
                return false;
            }

            if (cnpj.Length != 18) //14 dígitos + 4 operadores
            {
                MessageBox.Show("Ocorreu um erro! O CNPJ não está completo",
                                "CNPJ Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbCNPJ.Focus();
                return false;
            }

            if (ie.Length != 11)
            {
                MessageBox.Show("Ocorreu um erro! A Inscrição Estadual é inválida!", "Inscrição Estadual Inválida",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRua.Focus();
                return false;
            }

            if (fone.Length != 14) //10 dígitos + 3 operadores
            {
                MessageBox.Show("Ocorreu um erro! O fone não está completo",
                                "Fone Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbFone.Focus();
                return false;
            }

            if (celular.Length != 15)
            {
                MessageBox.Show("Ocorreu um erro! O celular não está completo",
                                "Celular Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbCelular.Focus();
                return false;
            }

            if (email == "" || !Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Ocorreu um erro! Conteúdo do campo email inválido!", "Email Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            if (representante == "")
            {
                MessageBox.Show("Ocorreu um erro! Nome de representante é inválido!", "Representante Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRua.Focus();
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

            string cnpj = mtbCNPJ.Text;

            if (Global.TemFornecedor(cnpj) != -1)
            {
                MessageBox.Show("Não é possível inserir o fornecedor, pois o CNPJ já consta no sistema.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LimpaCampos();

                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into fornecedores(razao_social, fantasia, cep, rua, numero, complemento, bairro, id_cidade, cnpj, ie, fone, 
                                              celular, representante, email) values(?razao_social, ?fantasia, ?cep, ?rua, ?numero, ?complemento, ?bairro, ?id_cidade,
                                              ?cnpj, ?ie, ?fone, ?celular, ?representante, ?email)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?razao_social", txtRazaoSocial.Text);
            Global.Comando.Parameters.AddWithValue("?fantasia", txtFantasia.Text);
            Global.Comando.Parameters.AddWithValue("?cep", mtbCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?cnpj", cnpj);
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
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o fornecedor que deseja atualizar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt16(txtID.Text);

            string cnpj = mtbCNPJ.Text;

            if (Global.TemFornecedor(cnpj) != id && Global.TemFornecedor(cnpj) != -1)
            {
                MessageBox.Show("Não é possível atualizar o fornecedor, pois o CNPJ colide com o de outro fornecedor.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LimpaCampos();

                return;
            }

            if (!validaCampos())
            {
                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update fornecedores set razao_social = ?razao_social, fantasia = ?fantasia, cep = ?cep, rua = ?rua, 
                                              numero = ?numero, complemento = ?complemento, bairro = ?bairro, id_cidade = ?id_cidade, cnpj = ?cnpj, 
                                              ie = ?ie, fone = ?fone, celular = ?celular, representante = ?representante, email = ?email where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?razao_social", txtRazaoSocial.Text);
            Global.Comando.Parameters.AddWithValue("?fantasia", txtFantasia.Text);
            Global.Comando.Parameters.AddWithValue("?cep", mtbCEP.Text);
            Global.Comando.Parameters.AddWithValue("?rua", txtRua.Text);
            Global.Comando.Parameters.AddWithValue("?numero", txtNumero.Text);
            Global.Comando.Parameters.AddWithValue("?complemento", txtComplemento.Text);
            Global.Comando.Parameters.AddWithValue("?bairro", txtBairro.Text);
            Global.Comando.Parameters.AddWithValue("?id_cidade", cboCidade.SelectedValue);
            Global.Comando.Parameters.AddWithValue("?cnpj", cnpj);
            Global.Comando.Parameters.AddWithValue("?ie", mtbIE.Text);
            Global.Comando.Parameters.AddWithValue("?fone", mtbFone.Text);
            Global.Comando.Parameters.AddWithValue("?celular", mtbCelular.Text);
            Global.Comando.Parameters.AddWithValue("?representante", txtRepresentante.Text);
            Global.Comando.Parameters.AddWithValue("?email", txtEmail.Text);
            Global.Comando.Parameters.AddWithValue("?id", id);

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
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o fornecedor que deseja excluir.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir o fornecedor " + txtFantasia.Text + "? Os produtos fornecidos " +
                                "por ele e as solicitações de abastecimento serão automaticamente excluídas.", "Exclusão", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

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

        private void txtRepresentante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)32)
            {
                e.Handled = true;
            }
        }

        private void txtRazaoSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)32)
            {
                e.Handled = true;
            }
        }
    }
}
