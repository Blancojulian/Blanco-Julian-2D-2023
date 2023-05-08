namespace ParcialCarniceria.Forms
{
    partial class FrmDetalleCompra
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
            this.gbxCreditoDebito = new System.Windows.Forms.GroupBox();
            this.rbtnDebito = new System.Windows.Forms.RadioButton();
            this.rbtnCredito = new System.Windows.Forms.RadioButton();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblDetalleProductos = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.gbxCreditoDebito.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCreditoDebito
            // 
            this.gbxCreditoDebito.Controls.Add(this.rbtnDebito);
            this.gbxCreditoDebito.Controls.Add(this.rbtnCredito);
            this.gbxCreditoDebito.Location = new System.Drawing.Point(356, 46);
            this.gbxCreditoDebito.Name = "gbxCreditoDebito";
            this.gbxCreditoDebito.Size = new System.Drawing.Size(110, 75);
            this.gbxCreditoDebito.TabIndex = 0;
            this.gbxCreditoDebito.TabStop = false;
            this.gbxCreditoDebito.Text = "Credito o Debito";
            // 
            // rbtnDebito
            // 
            this.rbtnDebito.AutoSize = true;
            this.rbtnDebito.Location = new System.Drawing.Point(6, 47);
            this.rbtnDebito.Name = "rbtnDebito";
            this.rbtnDebito.Size = new System.Drawing.Size(60, 19);
            this.rbtnDebito.TabIndex = 1;
            this.rbtnDebito.TabStop = true;
            this.rbtnDebito.Text = "Debito";
            this.rbtnDebito.UseVisualStyleBackColor = true;
            this.rbtnDebito.CheckedChanged += new System.EventHandler(this.rbtnDebito_CheckedChanged);
            // 
            // rbtnCredito
            // 
            this.rbtnCredito.AutoSize = true;
            this.rbtnCredito.Location = new System.Drawing.Point(6, 22);
            this.rbtnCredito.Name = "rbtnCredito";
            this.rbtnCredito.Size = new System.Drawing.Size(64, 19);
            this.rbtnCredito.TabIndex = 0;
            this.rbtnCredito.TabStop = true;
            this.rbtnCredito.Text = "Credito";
            this.rbtnCredito.UseVisualStyleBackColor = true;
            this.rbtnCredito.CheckedChanged += new System.EventHandler(this.rbtnCredito_CheckedChanged);
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProductos.Location = new System.Drawing.Point(55, 46);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(91, 21);
            this.lblProductos.TabIndex = 1;
            this.lblProductos.Text = "Productos:";
            // 
            // lblDetalleProductos
            // 
            this.lblDetalleProductos.AutoSize = true;
            this.lblDetalleProductos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDetalleProductos.Location = new System.Drawing.Point(55, 81);
            this.lblDetalleProductos.MaximumSize = new System.Drawing.Size(280, 300);
            this.lblDetalleProductos.Name = "lblDetalleProductos";
            this.lblDetalleProductos.Size = new System.Drawing.Size(127, 19);
            this.lblDetalleProductos.TabIndex = 2;
            this.lblDetalleProductos.Text = "lblDetalleProductos";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.Location = new System.Drawing.Point(362, 253);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(104, 35);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(362, 309);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 35);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(362, 144);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(52, 21);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total:";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblImporte.ForeColor = System.Drawing.Color.Red;
            this.lblImporte.Location = new System.Drawing.Point(362, 182);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(85, 25);
            this.lblImporte.TabIndex = 6;
            this.lblImporte.Text = "Importe";
            // 
            // FrmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 450);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblDetalleProductos);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.gbxCreditoDebito);
            this.Name = "FrmDetalleCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Compra";
            this.Load += new System.EventHandler(this.FrmDetalleCompra_Load);
            this.gbxCreditoDebito.ResumeLayout(false);
            this.gbxCreditoDebito.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox gbxCreditoDebito;
        private RadioButton rbtnDebito;
        private RadioButton rbtnCredito;
        private Label lblProductos;
        private Label lblDetalleProductos;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label lblTotal;
        private Label lblImporte;
    }
}