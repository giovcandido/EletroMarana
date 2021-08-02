
namespace _EletroMarana
{
    partial class FrmRealizarVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mtbDataHora = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAtualizarItem = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRemoverItem = new System.Windows.Forms.Button();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.cboTipoPGTO = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Código";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(92, 8);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(99, 20);
            this.txtID.TabIndex = 70;
            this.txtID.TabStop = false;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(92, 34);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(442, 21);
            this.cboCliente.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Cliente";
            // 
            // mtbDataHora
            // 
            this.mtbDataHora.Location = new System.Drawing.Point(92, 61);
            this.mtbDataHora.Mask = "00/00/0000 00:00";
            this.mtbDataHora.Name = "mtbDataHora";
            this.mtbDataHora.ReadOnly = true;
            this.mtbDataHora.Size = new System.Drawing.Size(126, 20);
            this.mtbDataHora.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Data e Horário";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(393, 61);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(141, 20);
            this.txtValorTotal.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Valor Total";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAtualizarItem);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnRemoverItem);
            this.groupBox1.Controls.Add(this.btnAdicionarItem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtValorUnitario);
            this.groupBox1.Controls.Add(this.dgvProdutos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtQuantidade);
            this.groupBox1.Controls.Add(this.cboProduto);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(13, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 294);
            this.groupBox1.TabIndex = 136;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adicionar Produtos";
            // 
            // btnAtualizarItem
            // 
            this.btnAtualizarItem.Location = new System.Drawing.Point(273, 101);
            this.btnAtualizarItem.Name = "btnAtualizarItem";
            this.btnAtualizarItem.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizarItem.TabIndex = 145;
            this.btnAtualizarItem.Text = "Atualizar";
            this.btnAtualizarItem.UseVisualStyleBackColor = true;
            this.btnAtualizarItem.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(435, 101);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 144;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnRemoverItem
            // 
            this.btnRemoverItem.Location = new System.Drawing.Point(354, 101);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverItem.TabIndex = 143;
            this.btnRemoverItem.Text = "Remover";
            this.btnRemoverItem.UseVisualStyleBackColor = true;
            this.btnRemoverItem.Click += new System.EventHandler(this.BtnRemover_Click);
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Location = new System.Drawing.Point(192, 101);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarItem.TabIndex = 142;
            this.btnAdicionarItem.Text = "Adicionar";
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.BtnAdicionar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 141;
            this.label5.Text = "Valor Unitário";
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(78, 46);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.ReadOnly = true;
            this.txtValorUnitario.Size = new System.Drawing.Size(130, 20);
            this.txtValorUnitario.TabIndex = 140;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(9, 148);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.Size = new System.Drawing.Size(501, 125);
            this.dgvProdutos.TabIndex = 139;
            this.dgvProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProdutos_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 138;
            this.label4.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(380, 46);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(130, 20);
            this.txtQuantidade.TabIndex = 137;
            // 
            // cboProduto
            // 
            this.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(78, 19);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(432, 21);
            this.cboProduto.TabIndex = 137;
            this.cboProduto.SelectedIndexChanged += new System.EventHandler(this.CboProduto_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Produto";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(46, 489);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(86, 23);
            this.btnFinalizar.TabIndex = 139;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.BtnFinalizarVenda_Click);
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.Location = new System.Drawing.Point(352, 489);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(101, 23);
            this.btnCancelarVenda.TabIndex = 140;
            this.btnCancelarVenda.Text = "Cancelar";
            this.btnCancelarVenda.UseVisualStyleBackColor = true;
            this.btnCancelarVenda.Click += new System.EventHandler(this.BtnCancelarVenda_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(459, 489);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 141;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(138, 489);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(101, 23);
            this.btnAtualizar.TabIndex = 142;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.BtnAtualizarVenda_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvVendas);
            this.groupBox2.Controls.Add(this.btnPesquisar);
            this.groupBox2.Controls.Add(this.txtPesquisa);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(13, 535);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 202);
            this.groupBox2.TabIndex = 143;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultar Vendas";
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.AllowUserToDeleteRows = false;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Location = new System.Drawing.Point(9, 62);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.ReadOnly = true;
            this.dgvVendas.Size = new System.Drawing.Size(501, 125);
            this.dgvVendas.TabIndex = 19;
            this.dgvVendas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVenda_CellClick);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(435, 17);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 18;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(68, 19);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(346, 20);
            this.txtPesquisa.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Pesquisar";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(245, 489);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(101, 23);
            this.btnExcluir.TabIndex = 144;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluirVenda_Click);
            // 
            // cboTipoPGTO
            // 
            this.cboTipoPGTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipoPGTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoPGTO.FormattingEnabled = true;
            this.cboTipoPGTO.Location = new System.Drawing.Point(92, 87);
            this.cboTipoPGTO.Name = "cboTipoPGTO";
            this.cboTipoPGTO.Size = new System.Drawing.Size(442, 21);
            this.cboTipoPGTO.TabIndex = 145;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 146;
            this.label9.Text = "Pagamento no";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(448, 126);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(86, 23);
            this.btnIniciar.TabIndex = 147;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // FrmRealizarVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(576, 467);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.cboTipoPGTO);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnCancelarVenda);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtbDataHora);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRealizarVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Realizar Venda";
            this.Load += new System.EventHandler(this.FrmRealizarVenda_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mtbDataHora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRemoverItem;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelarVenda;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAtualizarItem;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.ComboBox cboTipoPGTO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnIniciar;
    }
}