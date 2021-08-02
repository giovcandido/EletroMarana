
namespace _EletroMarana
{
    partial class FrmAcompanharSolicitacoes
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSolicitacoes = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorCusto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.chkChegou = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mtbDataHora = new System.Windows.Forms.MaskedTextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSolicitacoes);
            this.groupBox2.Controls.Add(this.btnPesquisar);
            this.groupBox2.Controls.Add(this.txtPesquisa);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(13, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 199);
            this.groupBox2.TabIndex = 144;
            this.groupBox2.TabStop = false;
            // 
            // dgvSolicitacoes
            // 
            this.dgvSolicitacoes.AllowUserToAddRows = false;
            this.dgvSolicitacoes.AllowUserToDeleteRows = false;
            this.dgvSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitacoes.Location = new System.Drawing.Point(9, 62);
            this.dgvSolicitacoes.Name = "dgvSolicitacoes";
            this.dgvSolicitacoes.ReadOnly = true;
            this.dgvSolicitacoes.Size = new System.Drawing.Size(501, 125);
            this.dgvSolicitacoes.TabIndex = 16;
            this.dgvSolicitacoes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSolicitacoes_CellClick);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(435, 17);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 15;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(68, 19);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(346, 20);
            this.txtPesquisa.TabIndex = 14;
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 145;
            this.label13.Text = "Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 148;
            this.label2.Text = "Código";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(91, 8);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 1;
            this.txtID.TabStop = false;
            // 
            // cboProduto
            // 
            this.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(91, 60);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(443, 21);
            this.cboProduto.TabIndex = 3;
            this.cboProduto.SelectedIndexChanged += new System.EventHandler(this.CboProduto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 149;
            this.label1.Text = "Fornecedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 152;
            this.label5.Text = "Valor Custo";
            // 
            // txtValorCusto
            // 
            this.txtValorCusto.Location = new System.Drawing.Point(92, 113);
            this.txtValorCusto.Name = "txtValorCusto";
            this.txtValorCusto.Size = new System.Drawing.Size(130, 20);
            this.txtValorCusto.TabIndex = 5;
            this.txtValorCusto.TextChanged += new System.EventHandler(this.TxtValorCusto_TextChanged);
            this.txtValorCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorCusto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 140;
            this.label4.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(393, 113);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(141, 20);
            this.txtQuantidade.TabIndex = 6;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            this.txtQuantidade.Leave += new System.EventHandler(this.TxtQuantidade_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 154;
            this.label3.Text = "Valor Total";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(92, 139);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(130, 20);
            this.txtValorTotal.TabIndex = 7;
            this.txtValorTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorTotal_KeyPress);
            // 
            // chkChegou
            // 
            this.chkChegou.AutoSize = true;
            this.chkChegou.Location = new System.Drawing.Point(255, 141);
            this.chkChegou.Name = "chkChegou";
            this.chkChegou.Size = new System.Drawing.Size(63, 17);
            this.chkChegou.TabIndex = 8;
            this.chkChegou.Text = "Chegou";
            this.chkChegou.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 157;
            this.label6.Text = "Data e Horário";
            // 
            // mtbDataHora
            // 
            this.mtbDataHora.Location = new System.Drawing.Point(91, 34);
            this.mtbDataHora.Mask = "00/00/0000 00:00";
            this.mtbDataHora.Name = "mtbDataHora";
            this.mtbDataHora.ReadOnly = true;
            this.mtbDataHora.Size = new System.Drawing.Size(126, 20);
            this.mtbDataHora.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(297, 207);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(216, 207);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 10;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(378, 207);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 12;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(135, 207);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 9;
            this.btnIncluir.Text = "Inserir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.BtnIncluir_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(459, 207);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 13;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(91, 87);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(443, 20);
            this.txtFornecedor.TabIndex = 4;
            // 
            // FrmAcompanharSolicitacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 473);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mtbDataHora);
            this.Controls.Add(this.chkChegou);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtValorCusto);
            this.Controls.Add(this.cboProduto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAcompanharSolicitacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acompanhar Solicitações";
            this.Load += new System.EventHandler(this.FrmAcompanharSolicitacoes_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSolicitacoes;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorCusto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.CheckBox chkChegou;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtbDataHora;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TextBox txtFornecedor;
    }
}