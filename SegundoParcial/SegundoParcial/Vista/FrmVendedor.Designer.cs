namespace SegundoParcial.Vista
{
    partial class FrmVendedor
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
            this.dtgvDatos = new System.Windows.Forms.DataGridView();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblListadoVentas = new System.Windows.Forms.Label();
            this.btnRealizarVenta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvDatos
            // 
            this.dtgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDatos.Location = new System.Drawing.Point(12, 87);
            this.dtgvDatos.Name = "dtgvDatos";
            this.dtgvDatos.RowTemplate.Height = 25;
            this.dtgvDatos.Size = new System.Drawing.Size(776, 251);
            this.dtgvDatos.TabIndex = 0;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVendedor.Location = new System.Drawing.Point(12, 18);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(100, 25);
            this.lblVendedor.TabIndex = 1;
            this.lblVendedor.Text = "Vendedor";
            // 
            // lblListadoVentas
            // 
            this.lblListadoVentas.AutoSize = true;
            this.lblListadoVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblListadoVentas.Location = new System.Drawing.Point(12, 63);
            this.lblListadoVentas.Name = "lblListadoVentas";
            this.lblListadoVentas.Size = new System.Drawing.Size(189, 21);
            this.lblListadoVentas.TabIndex = 2;
            this.lblListadoVentas.Text = "Listado ventas pendientes";
            // 
            // btnRealizarVenta
            // 
            this.btnRealizarVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRealizarVenta.Location = new System.Drawing.Point(508, 41);
            this.btnRealizarVenta.Name = "btnRealizarVenta";
            this.btnRealizarVenta.Size = new System.Drawing.Size(137, 40);
            this.btnRealizarVenta.TabIndex = 3;
            this.btnRealizarVenta.Text = "Realizar Venta";
            this.btnRealizarVenta.UseVisualStyleBackColor = true;
            this.btnRealizarVenta.Click += new System.EventHandler(this.btnRealizarVenta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(651, 41);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(137, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRealizarVenta);
            this.Controls.Add(this.lblListadoVentas);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.dtgvDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVendedor";
            this.ShowIcon = false;
            this.Text = "FrmVendedor";
            this.Load += new System.EventHandler(this.FrmVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dtgvDatos;
        private Label lblVendedor;
        private Label lblListadoVentas;
        private Button btnRealizarVenta;
        private Button btnSalir;
    }
}