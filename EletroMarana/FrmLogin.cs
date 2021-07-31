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
            Global.CriaBanco();
        }

        private void BtnLogar_Click(object sender, EventArgs e)
        {
            String login = txtLogin.Text;
            String senha = txtSenha.Text;

            if (login == "" || senha == "")
            {
                MessageBox.Show("Nenhum dos campos podem ser vazios, por favor preencha-os corretamente!", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!AutentificaUsuario(login, senha))
            {
                MessageBox.Show("Usuário ou senha inválidos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Hide();

            LimpaCampos();

            AbreMenuPrincipal();
        }

        private bool AutentificaUsuario(string login, string senha) {
            Tuple<int, int> usuarioEncontrado = Global.VerificaUsuario(login, senha);

            if (usuarioEncontrado.Item1 == -1)
            {
                return false;     
            }

            Global.usuarioLogado = usuarioEncontrado;

            return true;
        }

        private void LimpaCampos()
        {
            txtLogin.Clear();
            txtSenha.Clear();

            txtLogin.Select();
        }

        private void AbreMenuPrincipal()
        {
            FrmMenu Menu = new FrmMenu(this);
            Menu.Show();
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
