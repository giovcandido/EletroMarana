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
            String usuario = txtLogin.Text;
            String senha = txtSenha.Text;

            if (usuario == "" || senha == "")
            {
                MessageBox.Show("Nenhum dos campos podem ser vazios, por favor preencha-os corretamente!", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            Tuple<int, int> usuarioEncontrado = Global.VerificaUsuario(usuario, senha);

            if (usuarioEncontrado.Item1 == -1)
            {
                MessageBox.Show("Usuário ou senha inválidos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Global.usuarioLogado = usuarioEncontrado;

                Visible = false;

                txtLogin.Clear();
                txtSenha.Clear();

                FrmMenu form = new FrmMenu(this);
                form.Show();
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            DialogResult op = MessageBox.Show("Você deseja mesmo sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            
            if(op == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
