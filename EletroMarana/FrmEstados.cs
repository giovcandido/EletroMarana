using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmEstados : Form
    {
        public FrmEstados()
        {
            InitializeComponent();
        }

        private void FrmEstados_Load(object sender, System.EventArgs e)
        {
            dgvEstados.DataSource = Global.ConsultaEstados("");

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();

            txtPesquisa.Clear();

            txtNome.Select();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            dgvEstados.DataSource = Global.ConsultaEstados(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void DgvEstados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verifica se o grid tem linhas
            // se tiver, passa o conteudo do grid para os txt
            if (dgvEstados.Rows.Count > 0)
            {
                txtID.Text = dgvEstados.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvEstados.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void BtnIncluir_Click(object sender, System.EventArgs e)
        {
            if (txtNome.Text == "" || txtNome.Text.Length != 2 || !Regex.IsMatch(txtNome.Text, @"[A-Z]{2}"))
            {
                MessageBox.Show("O conteúdo do campo é inválido! Por favor, arrume.", "Campo Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return;
            }

            string nome = txtNome.Text;

            if (Global.TemEstado(nome) != -1)
            {
                MessageBox.Show("Não é possível inserir o estado, pois ele já consta no sistema.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // abre a conexão
            Global.Conexao.Open();

            // comando insert
            Global.Comando = new MySqlCommand("insert into estados(nome) values(?nome)", Global.Conexao);

            // criando o parâmetro
            Global.Comando.Parameters.AddWithValue("?nome", nome);

            // executando o comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            LimpaCampos();

            // atualiza grid
            dgvEstados.DataSource = Global.ConsultaEstados("");
        }

        private void BtnAtualizar_Click(object sender, System.EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o estado que deseja atualizar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNome.Text == "" || txtNome.Text.Length != 2 || !Regex.IsMatch(txtNome.Text, @"[A-Z]{2}"))
            {
                MessageBox.Show("O conteúdo do campo é inválido! Por favor, arrume.", "Campo Inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return;
            }

            int id = Convert.ToInt16(txtID.Text);

            string nome = txtNome.Text;

            if (Global.TemEstado(nome) != id)
            {
                MessageBox.Show("Não é possível atualizar o estado, pois ele seria idêntico a outro.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // abre a conexão
            Global.Conexao.Open();

            // comando update
            Global.Comando = new MySqlCommand("update estados set nome = ?nome where id = ?id", Global.Conexao);

            // criando os parâmetros
            Global.Comando.Parameters.AddWithValue("?nome", nome);
            Global.Comando.Parameters.AddWithValue("?id", id);

            // executa comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            LimpaCampos();

            // atualiza grid
            dgvEstados.DataSource = Global.ConsultaEstados("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvEstados.DataSource = Global.ConsultaEstados("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o estado que deseja excluir.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir o estado " + txtNome.Text + "? As cidades que " +
                                "pertençam a ele serão automaticamente excluídas. Como consequência, clientes " +
                                "e fornecedores também serão.", "Exclusão", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                // abre a conexão
                Global.Conexao.Open();

                // comando delete
                Global.Comando = new MySqlCommand("delete from estados where id = ?id", Global.Conexao);

                // criando o parâmetro
                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                // executa comando
                Global.Comando.ExecuteNonQuery();

                // fecha a conexão
                Global.Conexao.Close();

                // limpa form
                LimpaCampos();

                // atualiza grid
                dgvEstados.DataSource = Global.ConsultaEstados("");
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
