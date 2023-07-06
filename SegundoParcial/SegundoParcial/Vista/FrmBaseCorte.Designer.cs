namespace SegundoParcial.Vista
{
    partial class FrmBaseCorte
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.rtbxDetalle = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(50, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(50, 56);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(135, 23);
            this.tbxNombre.TabIndex = 1;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrecio.Location = new System.Drawing.Point(50, 94);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(93, 17);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio por kilo";
            // 
            // nudPrecio
            // 
            this.nudPrecio.Location = new System.Drawing.Point(50, 114);
            this.nudPrecio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(135, 23);
            this.nudPrecio.TabIndex = 3;
            this.nudPrecio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudStock
            // 
            this.nudStock.Location = new System.Drawing.Point(50, 177);
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(135, 23);
            this.nudStock.TabIndex = 5;
            this.nudStock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStock.Location = new System.Drawing.Point(50, 157);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(39, 17);
            this.lblStock.TabIndex = 4;
            this.lblStock.Text = "Stock";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCategoria.Location = new System.Drawing.Point(50, 223);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(65, 17);
            this.lblCategoria.TabIndex = 6;
            this.lblCategoria.Text = "Categoria";
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(50, 243);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(135, 23);
            this.cbxCategoria.TabIndex = 7;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.Location = new System.Drawing.Point(50, 306);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(135, 33);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(262, 306);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(135, 33);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDetalle.Location = new System.Drawing.Point(262, 36);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(48, 17);
            this.lblDetalle.TabIndex = 10;
            this.lblDetalle.Text = "Detalle";
            // 
            // rtbxDetalle
            // 
            this.rtbxDetalle.Location = new System.Drawing.Point(262, 56);
            this.rtbxDetalle.Name = "rtbxDetalle";
            this.rtbxDetalle.Size = new System.Drawing.Size(135, 144);
            this.rtbxDetalle.TabIndex = 11;
            this.rtbxDetalle.Text = "";
            // 
            // FrmBaseCorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.rtbxDetalle);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cbxCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.nudStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.nudPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.lblNombre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBaseCorte";
            this.ShowIcon = false;
            this.Text = "FrmBaseCorte";
            this.Load += new System.EventHandler(this.FrmBaseCorte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNombre;
        private Label lblPrecio;
        private Label lblStock;
        private Label lblCategoria;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Label lblDetalle;
        protected TextBox tbxNombre;
        protected NumericUpDown nudPrecio;
        protected NumericUpDown nudStock;
        protected ComboBox cbxCategoria;
        protected RichTextBox rtbxDetalle;
    }
}