namespace SegundoParcial.Vista
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
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblDetalleProductos = new System.Windows.Forms.Label();
            this.gpbxCreditoDebito = new System.Windows.Forms.GroupBox();
            this.rbtnDebito = new System.Windows.Forms.RadioButton();
            this.rbtnCredito = new System.Windows.Forms.RadioButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gpbxCreditoDebito.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProductos.Location = new System.Drawing.Point(57, 37);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(104, 25);
            this.lblProductos.TabIndex = 0;
            this.lblProductos.Text = "Productos";
            // 
            // lblDetalleProductos
            // 
            this.lblDetalleProductos.AutoSize = true;
            this.lblDetalleProductos.Location = new System.Drawing.Point(57, 89);
            this.lblDetalleProductos.Name = "lblDetalleProductos";
            this.lblDetalleProductos.Size = new System.Drawing.Size(110, 15);
            this.lblDetalleProductos.TabIndex = 1;
            this.lblDetalleProductos.Text = "lblDetalleProductos";
            // 
            // gpbxCreditoDebito
            // 
            this.gpbxCreditoDebito.Controls.Add(this.rbtnDebito);
            this.gpbxCreditoDebito.Controls.Add(this.rbtnCredito);
            this.gpbxCreditoDebito.Location = new System.Drawing.Point(343, 32);
            this.gpbxCreditoDebito.Name = "gpbxCreditoDebito";
            this.gpbxCreditoDebito.Size = new System.Drawing.Size(109, 72);
            this.gpbxCreditoDebito.TabIndex = 2;
            this.gpbxCreditoDebito.TabStop = false;
            this.gpbxCreditoDebito.Text = "Credito o Debito";
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
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(343, 136);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(55, 25);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblImporte.ForeColor = System.Drawing.Color.Red;
            this.lblImporte.Location = new System.Drawing.Point(343, 185);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(85, 25);
            this.lblImporte.TabIndex = 4;
            this.lblImporte.Text = "Importe";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.Location = new System.Drawing.Point(343, 242);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(109, 29);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(343, 277);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 29);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.gpbxCreditoDebito);
            this.Controls.Add(this.lblDetalleProductos);
            this.Controls.Add(this.lblProductos);
            this.Name = "FrmDetalleCompra";
            this.Text = "Detalle Compra";
            this.Load += new System.EventHandler(this.FrmDetalleCompra_Load);
            this.gpbxCreditoDebito.ResumeLayout(false);
            this.gpbxCreditoDebito.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblProductos;
        private Label lblDetalleProductos;
        private GroupBox gpbxCreditoDebito;
        private RadioButton rbtnDebito;
        private RadioButton rbtnCredito;
        private Label lblTotal;
        private Label lblImporte;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}