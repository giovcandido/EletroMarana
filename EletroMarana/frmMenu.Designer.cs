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
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EstadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CategoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TiposPGTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NovaVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abastecimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NovaSolicitacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.vendaToolStripMenuItem,
            this.abastecimentoToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CidadesToolStripMenuItem,
            this.EstadosToolStripMenuItem,
            this.CategoriasToolStripMenuItem,
            this.ClientesToolStripMenuItem,
            this.FornecedoresToolStripMenuItem,
            this.ProdutosToolStripMenuItem,
            this.UsuariosToolStripMenuItem,
            this.TiposPGTOToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // CidadesToolStripMenuItem
            // 
            this.CidadesToolStripMenuItem.Name = "CidadesToolStripMenuItem";
            this.CidadesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.CidadesToolStripMenuItem.Text = "Cidades";
            this.CidadesToolStripMenuItem.Click += new System.EventHandler(this.CidadesToolStripMenuItem_Click);
            // 
            // EstadosToolStripMenuItem
            // 
            this.EstadosToolStripMenuItem.Name = "EstadosToolStripMenuItem";
            this.EstadosToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.EstadosToolStripMenuItem.Text = "Estados";
            this.EstadosToolStripMenuItem.Click += new System.EventHandler(this.EstadosToolStripMenuItem_Click);
            // 
            // CategoriasToolStripMenuItem
            // 
            this.CategoriasToolStripMenuItem.Name = "CategoriasToolStripMenuItem";
            this.CategoriasToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.CategoriasToolStripMenuItem.Text = "Categorias";
            this.CategoriasToolStripMenuItem.Click += new System.EventHandler(this.CategoriasToolStripMenuItem_Click);
            // 
            // ClientesToolStripMenuItem
            // 
            this.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem";
            this.ClientesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ClientesToolStripMenuItem.Text = "Clientes";
            this.ClientesToolStripMenuItem.Click += new System.EventHandler(this.ClientesToolStripMenuItem_Click);
            // 
            // FornecedoresToolStripMenuItem
            // 
            this.FornecedoresToolStripMenuItem.Name = "FornecedoresToolStripMenuItem";
            this.FornecedoresToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.FornecedoresToolStripMenuItem.Text = "Fornecedores";
            this.FornecedoresToolStripMenuItem.Click += new System.EventHandler(this.FornecedoresToolStripMenuItem_Click);
            // 
            // ProdutosToolStripMenuItem
            // 
            this.ProdutosToolStripMenuItem.Name = "ProdutosToolStripMenuItem";
            this.ProdutosToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ProdutosToolStripMenuItem.Text = "Produtos";
            this.ProdutosToolStripMenuItem.Click += new System.EventHandler(this.ProdutosToolStripMenuItem_Click);
            // 
            // UsuariosToolStripMenuItem
            // 
            this.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem";
            this.UsuariosToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.UsuariosToolStripMenuItem.Text = "Usuários";
            this.UsuariosToolStripMenuItem.Click += new System.EventHandler(this.UsuariosToolStripMenuItem_Click);
            // 
            // TiposPGTOToolStripMenuItem
            // 
            this.TiposPGTOToolStripMenuItem.Name = "TiposPGTOToolStripMenuItem";
            this.TiposPGTOToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.TiposPGTOToolStripMenuItem.Text = "Tipos de Pagamento";
            this.TiposPGTOToolStripMenuItem.Click += new System.EventHandler(this.TiposPGTOToolStripMenuItem_Click);
            // 
            // vendaToolStripMenuItem
            // 
            this.vendaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NovaVendaToolStripMenuItem});
            this.vendaToolStripMenuItem.Name = "vendaToolStripMenuItem";
            this.vendaToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.vendaToolStripMenuItem.Text = "Vendas";
            // 
            // NovaVendaToolStripMenuItem
            // 
            this.NovaVendaToolStripMenuItem.Name = "NovaVendaToolStripMenuItem";
            this.NovaVendaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.NovaVendaToolStripMenuItem.Text = "Nova Venda";
            this.NovaVendaToolStripMenuItem.Click += new System.EventHandler(this.NovaVendaToolStripMenuItem_Click);
            // 
            // abastecimentoToolStripMenuItem
            // 
            this.abastecimentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NovaSolicitacaoToolStripMenuItem});
            this.abastecimentoToolStripMenuItem.Name = "abastecimentoToolStripMenuItem";
            this.abastecimentoToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.abastecimentoToolStripMenuItem.Text = "Abastecimentos";
            // 
            // NovaSolicitacaoToolStripMenuItem
            // 
            this.NovaSolicitacaoToolStripMenuItem.Name = "NovaSolicitacaoToolStripMenuItem";
            this.NovaSolicitacaoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.NovaSolicitacaoToolStripMenuItem.Text = "Nova Solicitação";
            this.NovaSolicitacaoToolStripMenuItem.Click += new System.EventHandler(this.NovaSolicitacaoToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenu_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CategoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NovaVendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abastecimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NovaSolicitacaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EstadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TiposPGTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}

