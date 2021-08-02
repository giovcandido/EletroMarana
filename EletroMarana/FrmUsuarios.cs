using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace _EletroMarana
{
    public partial class FrmUsuarios : Form
    {
        private readonly FrmMenu FrmMenuPrincipal;

        public FrmUsuarios(FrmMenu FrmMenuPrincipal)
        {
            this.FrmMenuPrincipal = FrmMenuPrincipal;

            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Global.ConsultaUsuarios("");

            dgvUsuarios.Columns[3].Visible = false;

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();

            chkAdm.Checked = false;

            txtPesquisa.Clear();

            txtNome.Select();
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

            string login = txtLogin.Text;

            if (Global.TemUsuario(login) != -1)
            {
                MessageBox.Show("Não é possível incluir o usuário, pois o login escolhido já consta no sistema.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand(@"insert into usuarios(nome, login, senha, adm) 
                                              values(?nome, ?login, ?senha, ?adm)", Global.Conexao);

            Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
            Global.Comando.Parameters.AddWithValue("?login", login);
            Global.Comando.Parameters.AddWithValue("?senha", txtSenha.Text);
            Global.Comando.Parameters.AddWithValue("?adm", Convert.ToBoolean(chkAdm.Checked));

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            LimpaCampos();

            dgvUsuarios.DataSource = Global.ConsultaUsuarios("");
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") {
                MessageBox.Show("Selecione o usuário que deseja atualizar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt16(txtID.Text);

            string login = txtLogin.Text;

            if (Global.TemUsuario(login) != id && Global.TemUsuario(login) != -1)
            {
                MessageBox.Show("Não é possível atualizar o usuário, pois o login escolhido já consta no sistema.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Global.TemUnicoAdm() == id)
            {
                MessageBox.Show("Não é possível atualizar o usuário, pois deve haver ao menos um usuário administrador.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Global.Conexao.Open();

                Global.Comando = new MySqlCommand(@"update usuarios set nome = ?nome, login = ?login, 
                                                  senha = ?senha, adm = ?adm where id = ?id", Global.Conexao);

                Global.Comando.Parameters.AddWithValue("?nome", txtNome.Text);
                Global.Comando.Parameters.AddWithValue("?login", login);
                Global.Comando.Parameters.AddWithValue("?senha", txtSenha.Text);
                Global.Comando.Parameters.AddWithValue("?adm", Convert.ToBoolean(chkAdm.Checked));
                Global.Comando.Parameters.AddWithValue("?id", id);

                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();
            }

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
            if (txtID.Text == "")
            {
                MessageBox.Show("Selecione o usuário que deseja excluir.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir o usuário " + txtNome.Text + "? Como consequência, as " +
                                "vendas feitas por ele serão automaticamente excluídas.", "Exclusão", MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (Global.TemUnicoAdm() != -1)
            {
                MessageBox.Show("Não é possível excluir o usuário, pois deve haver ao menos um usuário administrador.", 
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Global.Conexao.Open();

            Global.Comando = new MySqlCommand("delete from usuarios where id = ?id", Global.Conexao);

            int idUsuario = Convert.ToInt16(txtID.Text);

            Global.Comando.Parameters.AddWithValue("?id", idUsuario);

            Global.Comando.ExecuteNonQuery();

            Global.Conexao.Close();

            if (Global.usuarioLogado.Item1 == idUsuario)
            {
                MessageBox.Show("Seu login foi excluído! Você será desconectado do sistema.",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmMenuPrincipal.Logout();
            }

            LimpaCampos();

            dgvUsuarios.DataSource = Global.ConsultaUsuarios("");
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
