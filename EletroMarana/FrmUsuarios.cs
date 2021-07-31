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

        private void LimpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();

            chkAdm.Checked = false;

            txtPesquisa.Clear();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Global.ConsultaUsuarios("");

            dgvUsuarios.Columns[3].Visible = false;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Global.ConsultaUsuarios(txtPesquisa.Text);

            txtPesquisa.Clear();
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.RowCount > 0)
            {
                txtID.Text = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                txtLogin.Text = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                txtSenha.Text = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
                chkAdm.Checked = Convert.ToBoolean(dgvUsuarios.CurrentRow.Cells[4].Value.ToString());
            }
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into usuarios(nome, login, senha, adm, ativo) 
                                              values(?nome, ?login, ?senha, ?adm, true)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?login", txtLogin.Text);
            Global.Comando.Parameters.AddWithValue("?senha", txtSenha.Text);
            Global.Comando.Parameters.AddWithValue("?adm", Convert.ToBoolean(chkAdm.Checked));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvUsuarios.DataSource = Global.ConsultaUsuarios("");
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"update usuarios set nome = ?nome, login = ?login, 
                                              senha = ?senha, adm = ?adm where id = ?id", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?login", txtLogin.Text);
            Global.Comando.Parameters.AddWithValue("?senha", txtSenha.Text);
            Global.Comando.Parameters.AddWithValue("?adm", Convert.ToBoolean(chkAdm.Checked));
            Global.Comando.Parameters.AddWithValue("?id", Convert.ToInt16(txtID.Text));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvUsuarios.DataSource = Global.ConsultaUsuarios("");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            dgvUsuarios.DataSource = Global.ConsultaUsuarios("");
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja realmente excluir o usuário " + txtNome.Text + "?", "Exclusão", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {

                if (Global.RetornaNumeroUsuariosAdm() == 1)
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

                    LimpaCampos();

                    dgvUsuarios.DataSource = Global.ConsultaUsuarios("");
                }
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
