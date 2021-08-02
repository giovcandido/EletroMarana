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
                itemCategorias.Available = false;
                itemFornecedores.Available = false;
                itemProdutos.Available = false;
                itemTiposPGTO.Available = false;
            }
        }

        private void ItemCidades_Click(object sender, EventArgs e)
        {
            FrmCidades form = new FrmCidades();
            form.ShowDialog();
        }

        private void ItemEstados_Click(object sender, EventArgs e)
        {
            FrmEstados form = new FrmEstados();
            form.ShowDialog();
        }

        private void ItemCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias form = new FrmCategorias();
            form.ShowDialog();
        }

        private void ItemClientes_Click(object sender, EventArgs e)
        {
            FrmClientes form = new FrmClientes();
            form.ShowDialog();
        }

        private void ItemFornecedores_Click(object sender, EventArgs e)
        {
            FrmFornecedores form = new FrmFornecedores();
            form.ShowDialog();
        }

        private void ItemProdutos_Click(object sender, EventArgs e)
        {
            FrmProdutos form = new FrmProdutos();
            form.ShowDialog();
        }

        private void ItemUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios form = new FrmUsuarios(this);
            form.ShowDialog();
        }

        private void ItemTiposPGTO_Click(object sender, EventArgs e)
        {
            FrmTiposPGTO form = new FrmTiposPGTO();
            form.ShowDialog();
        }

        private void ItemRealizarVenda_Click(object sender, EventArgs e)
        {
            FrmRealizarVenda form = new FrmRealizarVenda();
            form.ShowDialog();
        }

        private void ItemAcompanharSolicitacoes_Click(object sender, EventArgs e)
        {
            FrmAcompanharSolicitacoes form = new FrmAcompanharSolicitacoes();
            form.ShowDialog();
        }

        private void MenuLogout_Click(object sender, EventArgs e)
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
