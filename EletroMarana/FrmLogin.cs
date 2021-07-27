using System;

using System.Windows.Forms;

namespace _EletroMarana
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Global.criaBanco();
            Global.criaUsuarioPadrao();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String senha = txtSenha.Text;

            if (usuario == "" || senha == "") return;

            Tuple<int, int> usuarioEncontrado = Global.verificaUsuario(usuario, senha);

            if (usuarioEncontrado.Item1 == -1)
            {
                MessageBox.Show("Usuário ou senha inválidos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Global.usuarioLogado = usuarioEncontrado;

                Visible = false;

                FrmMenu form = new FrmMenu(this);
                form.Show();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
