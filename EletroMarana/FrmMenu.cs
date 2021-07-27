using System;

using System.Windows.Forms;

namespace _EletroMarana
{
    public partial class FrmMenu : Form
    {
        Form frmLogin;

        public FrmMenu(Form frmLogin)
        {
            this.frmLogin = frmLogin;

            InitializeComponent();

            if (Global.usuarioLogado.Item2 != 1)
            {
                usuariosToolStripMenuItem.Available = false;
                abastecimentoToolStripMenuItem.Available = false;
            }
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidades form = new FrmCidades();
            form.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias form = new FrmCategorias();
            form.ShowDialog();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios form = new FrmUsuarios();
            form.ShowDialog();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFornecedores form = new FrmFornecedores();
            form.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes form = new FrmClientes();
            form.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutos form = new FrmProdutos();
            form.ShowDialog();
        }

        private void estadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstados form = new FrmEstados();
            form.ShowDialog();
        }
        private void tiposPGTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposPGTO form = new FrmTiposPGTO();
            form.ShowDialog();
        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Close();
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNovaVenda form = new FrmNovaVenda();
            form.ShowDialog();
        }

        private void novaSolicitaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNovaSolicitacao form = new FrmNovaSolicitacao();
            form.ShowDialog();
        }
    }
}
