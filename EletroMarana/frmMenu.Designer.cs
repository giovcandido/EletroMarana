namespace _EletroMarana
{
    partial class FrmMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCidades = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEstados = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.itemClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.itemProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.itemUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTiposPGTO = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRealizarVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbastecimentos = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAcompanharSolicitacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastros,
            this.menuVenda,
            this.menuAbastecimentos,
            this.menuLogout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuCadastros
            // 
            this.menuCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCidades,
            this.itemEstados,
            this.itemCategorias,
            this.itemClientes,
            this.itemFornecedores,
            this.itemProdutos,
            this.itemUsuarios,
            this.itemTiposPGTO});
            this.menuCadastros.Name = "menuCadastros";
            this.menuCadastros.Size = new System.Drawing.Size(71, 20);
            this.menuCadastros.Text = "Cadastros";
            // 
            // itemCidades
            // 
            this.itemCidades.Name = "itemCidades";
            this.itemCidades.Size = new System.Drawing.Size(182, 22);
            this.itemCidades.Text = "Cidades";
            this.itemCidades.Click += new System.EventHandler(this.CidadesToolStripMenuItem_Click);
            // 
            // itemEstados
            // 
            this.itemEstados.Name = "itemEstados";
            this.itemEstados.Size = new System.Drawing.Size(182, 22);
            this.itemEstados.Text = "Estados";
            this.itemEstados.Click += new System.EventHandler(this.EstadosToolStripMenuItem_Click);
            // 
            // itemCategorias
            // 
            this.itemCategorias.Name = "itemCategorias";
            this.itemCategorias.Size = new System.Drawing.Size(182, 22);
            this.itemCategorias.Text = "Categorias";
            this.itemCategorias.Click += new System.EventHandler(this.CategoriasToolStripMenuItem_Click);
            // 
            // itemClientes
            // 
            this.itemClientes.Name = "itemClientes";
            this.itemClientes.Size = new System.Drawing.Size(182, 22);
            this.itemClientes.Text = "Clientes";
            this.itemClientes.Click += new System.EventHandler(this.ClientesToolStripMenuItem_Click);
            // 
            // itemFornecedores
            // 
            this.itemFornecedores.Name = "itemFornecedores";
            this.itemFornecedores.Size = new System.Drawing.Size(182, 22);
            this.itemFornecedores.Text = "Fornecedores";
            this.itemFornecedores.Click += new System.EventHandler(this.FornecedoresToolStripMenuItem_Click);
            // 
            // itemProdutos
            // 
            this.itemProdutos.Name = "itemProdutos";
            this.itemProdutos.Size = new System.Drawing.Size(182, 22);
            this.itemProdutos.Text = "Produtos";
            this.itemProdutos.Click += new System.EventHandler(this.ProdutosToolStripMenuItem_Click);
            // 
            // itemUsuarios
            // 
            this.itemUsuarios.Name = "itemUsuarios";
            this.itemUsuarios.Size = new System.Drawing.Size(182, 22);
            this.itemUsuarios.Text = "Usuários";
            this.itemUsuarios.Click += new System.EventHandler(this.UsuariosToolStripMenuItem_Click);
            // 
            // itemTiposPGTO
            // 
            this.itemTiposPGTO.Name = "itemTiposPGTO";
            this.itemTiposPGTO.Size = new System.Drawing.Size(182, 22);
            this.itemTiposPGTO.Text = "Tipos de Pagamento";
            this.itemTiposPGTO.Click += new System.EventHandler(this.TiposPGTOToolStripMenuItem_Click);
            // 
            // menuVenda
            // 
            this.menuVenda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemRealizarVenda});
            this.menuVenda.Name = "menuVenda";
            this.menuVenda.Size = new System.Drawing.Size(56, 20);
            this.menuVenda.Text = "Vendas";
            // 
            // itemRealizarVenda
            // 
            this.itemRealizarVenda.Name = "itemRealizarVenda";
            this.itemRealizarVenda.Size = new System.Drawing.Size(180, 22);
            this.itemRealizarVenda.Text = "Realizar Venda";
            this.itemRealizarVenda.Click += new System.EventHandler(this.NovaVendaToolStripMenuItem_Click);
            // 
            // menuAbastecimentos
            // 
            this.menuAbastecimentos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAcompanharSolicitacoes});
            this.menuAbastecimentos.Name = "menuAbastecimentos";
            this.menuAbastecimentos.Size = new System.Drawing.Size(104, 20);
            this.menuAbastecimentos.Text = "Abastecimentos";
            // 
            // itemAcompanharSolicitacoes
            // 
            this.itemAcompanharSolicitacoes.Name = "itemAcompanharSolicitacoes";
            this.itemAcompanharSolicitacoes.Size = new System.Drawing.Size(208, 22);
            this.itemAcompanharSolicitacoes.Text = "Acompanhar Solicitações";
            this.itemAcompanharSolicitacoes.Click += new System.EventHandler(this.NovaSolicitacaoToolStripMenuItem_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuLogout.Size = new System.Drawing.Size(57, 20);
            this.menuLogout.Text = "Logout";
            this.menuLogout.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EletroMarana - Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenu_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCadastros;
        private System.Windows.Forms.ToolStripMenuItem itemCidades;
        private System.Windows.Forms.ToolStripMenuItem itemCategorias;
        private System.Windows.Forms.ToolStripMenuItem itemClientes;
        private System.Windows.Forms.ToolStripMenuItem itemFornecedores;
        private System.Windows.Forms.ToolStripMenuItem itemProdutos;
        private System.Windows.Forms.ToolStripMenuItem itemUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuVenda;
        private System.Windows.Forms.ToolStripMenuItem itemRealizarVenda;
        private System.Windows.Forms.ToolStripMenuItem menuAbastecimentos;
        private System.Windows.Forms.ToolStripMenuItem itemAcompanharSolicitacoes;
        private System.Windows.Forms.ToolStripMenuItem itemEstados;
        private System.Windows.Forms.ToolStripMenuItem itemTiposPGTO;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
    }
}

