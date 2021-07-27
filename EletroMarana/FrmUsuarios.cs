using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        void limpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtSenha.Clear();

            chkAdm.Checked = false;

            txtPesquisa.Clear();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Global.consultaUsuarios("");

            dgvUsuarios.Columns[2].Visible = false;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("insert into usuarios(nome, senha, adm, ativo) values(?nome, ?senha, ?adm, true)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?senha", txtSenha.Text);
            Global.Comando.Parameters.AddWithValue("?adm", Convert.ToBoolean(chkAdm.Checked));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            limpaCampos();

            dgvUsuarios.DataSource = Global.consultaUsuarios("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Global.consultaUsuarios(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.RowCount > 0) {
                txtID.Text = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                txtSenha.Text = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                chkAdm.Checked = Convert.ToBoolean(dgvUsuarios.CurrentRow.Cells[3].Value.ToString());
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("update usuarios set nome = ?nome, senha = ?senha, adm = ?adm where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?senha", txtSenha.Text);
            Global.Comando.Parameters.AddWithValue("?adm", Convert.ToBoolean(chkAdm.Checked));
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            limpaCampos();

            dgvUsuarios.DataSource = Global.consultaUsuarios("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();

            dgvUsuarios.DataSource = Global.consultaUsuarios("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir o usuário " + txtNome.Text + "?", "Exclusão", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                if (Global.retornaNumeroUsuariosAdm() == 1)
                {
                    MessageBox.Show("Deve haver pelo menos um usuário admin!", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Global.Conexao.Open();

                    Global.Comando = new MySqlCommand("update usuarios set ativo = false where id = ?id", Global.Conexao);

                    Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

                    Global.Comando.ExecuteNonQuery();

                    Global.Conexao.Close();

                    limpaCampos();

                    dgvUsuarios.DataSource = Global.consultaUsuarios("");
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
