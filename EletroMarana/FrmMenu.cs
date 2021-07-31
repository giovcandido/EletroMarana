using System;

using System.Windows.Forms;

namespace _EletroMarana
{
    public partial class FrmMenu : Form
    {
        private readonly Form FrmLogin;

        public FrmMenu(Form frmLogin)
        {
            FrmLogin = frmLogin;

            InitializeComponent();

            if (Global.usuarioLogado.Item2 != 1)
            {
                itemUsuarios.Available = false;
                menuAbastecimentos.Available = false;
            }
        }

        private void CidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidades form = new FrmCidades();
            form.ShowDialog();
        }

        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias form = new FrmCategorias();
            form.ShowDialog();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios form = new FrmUsuarios(this);
            form.ShowDialog();
        }

        private void FornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFornecedores form = new FrmFornecedores();
            form.ShowDialog();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes form = new FrmClientes();
            form.ShowDialog();
        }

        private void ProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutos form = new FrmProdutos();
            form.ShowDialog();
        }

        private void EstadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstados form = new FrmEstados();
            form.ShowDialog();
        }

        private void TiposPGTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposPGTO form = new FrmTiposPGTO();
            form.ShowDialog();
        }

        private void NovaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNovaVenda form = new FrmNovaVenda();
            form.ShowDialog();
        }

        private void NovaSolicitacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNovaSolicitacao form = new FrmNovaSolicitacao();
            form.ShowDialog();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Você deseja mesmo sair?", "Sair", MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resp == DialogResult.Yes)
            {
                Logout();
            }
        }

        public void Logout()
        {
            FrmLogin.Show();
            Dispose();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja realmente fechar a aplicação?", "Fechar", MessageBoxButtons.YesNo, 
                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resp == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                FrmLogin.Close();
            }
        }
    }
}
