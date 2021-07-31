using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmCidades : Form
    {
        public FrmCidades()
        {
            InitializeComponent();
        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            dgvCidades.DataSource = Global.ConsultaCidades("");

            cboEstado.DataSource = Global.ConsultaEstados("");
            cboEstado.DisplayMember = "Nome";
            cboEstado.ValueMember = "Código";

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();

            cboEstado.SelectedItem = null;
            cboEstado.ResetText();

            txtPesquisa.Clear();

            txtNome.Select();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            dgvCidades.DataSource = Global.ConsultaCidades(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void DgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verifica se o grid tem linhas
            // se tiver, passa o conteudo do grid para os txt
            if (dgvCidades.RowCount > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells[1].Value.ToString();
                cboEstado.Text = dgvCidades.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            string nome = txtNome.Text;
            int idEstado = Convert.ToInt16(cboEstado.SelectedValue);

            if (Global.TemCidade(nome, idEstado))
            {
                MessageBox.Show("Não é possível incluir a cidade, pois ela já consta no sistema.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // abre a conexão
            Global.Conexao.Open();

            // comando insert
            Global.Comando = new MySqlCommand(@"insert into cidades(nome, id_estado) 
                                              values(?nome, ?id_estado)", Global.Conexao);

            // criando os parâmetros
            Global.Comando.Parameters.AddWithValue("?nome", nome);
            Global.Comando.Parameters.AddWithValue("?id_estado", idEstado);

            // executa comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            LimpaCampos();

            // atualiza grid
            dgvCidades.DataSource = Global.ConsultaCidades("");
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            string nome = txtNome.Text;
            int idEstado = Convert.ToInt16(cboEstado.SelectedValue);

            if (Global.TemCidade(nome, idEstado))
            {
                MessageBox.Show("Não é possível atualizar a cidade, pois ela seria idêntica a outra.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // abre a conexão
            Global.Conexao.Open();

            // comando update
            Global.Comando = new MySqlCommand(@"update cidades set nome = ?nome, id_estado = ?id_estado 
                                              where id = ?id", Global.Conexao);

            // criando os parâmetros
            Global.Comando.Parameters.AddWithValue("?nome", nome);
            Global.Comando.Parameters.AddWithValue("?id_estado", idEstado);
            Global.Comando.Parameters.AddWithValue("?id", txtID.Text);

            // executa comando
            Global.Comando.ExecuteNonQuery();

            // fecha a conexão
            Global.Conexao.Close();

            // limpa form
            LimpaCampos();

            // atualiza grid
            dgvCidades.DataSource = Global.ConsultaCidades("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvCidades.DataSource = Global.ConsultaCidades("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir a cidade " + txtNome.Text + "? Clientes e fornecedores " +
                                "que residam na cidade serão automaticamente excluídos.", "Exclusão", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            { 
                // abre a conexão
                Global.Conexao.Open();

                // comando delete
                Global.Comando = new MySqlCommand("delete from cidades where id = ?id", Global.Conexao);

                // criando o parâmetro
                Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                // executa comando
                Global.Comando.ExecuteNonQuery();

                // fecha a conexão
                Global.Conexao.Close();

                // limpa form
                LimpaCampos();

                // atualiza grid
                dgvCidades.DataSource = Global.ConsultaCidades("");
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
