namespace SegundoParcial.Vista
{
    partial class FrmHistorial
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
            this.dtgvHistorial = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbxBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblTextoBuscado = new System.Windows.Forms.Label();
            this.lblEstadoVenta = new System.Windows.Forms.Label();
            this.cbxEstadoVenta = new System.Windows.Forms.ComboBox();
            this.btnSeleccionarTodas = new System.Windows.Forms.Button();
            this.btnDeseleccionarTodas = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnGuardarComo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(12, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(86, 25);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // dtgvHistorial
            // 
            this.dtgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dtgvHistorial.Location = new System.Drawing.Point(12, 116);
            this.dtgvHistorial.Name = "dtgvHistorial";
            this.dtgvHistorial.RowTemplate.Height = 25;
            this.dtgvHistorial.Size = new System.Drawing.Size(712, 228);
            this.dtgvHistorial.TabIndex = 1;
            this.dtgvHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHistorial_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // tbxBuscar
            // 
            this.tbxBuscar.Location = new System.Drawing.Point(12, 87);
            this.tbxBuscar.Name = "tbxBuscar";
            this.tbxBuscar.Size = new System.Drawing.Size(138, 23);
            this.tbxBuscar.TabIndex = 2;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblBuscar.Location = new System.Drawing.Point(12, 67);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(89, 17);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar filtros";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.Location = new System.Drawing.Point(156, 85);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 25);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiar.Location = new System.Drawing.Point(237, 85);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 25);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblTextoBuscado
            // 
            this.lblTextoBuscado.AutoSize = true;
            this.lblTextoBuscado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTextoBuscado.Location = new System.Drawing.Point(107, 67);
            this.lblTextoBuscado.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblTextoBuscado.MinimumSize = new System.Drawing.Size(300, 0);
            this.lblTextoBuscado.Name = "lblTextoBuscado";
            this.lblTextoBuscado.Size = new System.Drawing.Size(300, 17);
            this.lblTextoBuscado.TabIndex = 6;
            // 
            // lblEstadoVenta
            // 
            this.lblEstadoVenta.AutoSize = true;
            this.lblEstadoVenta.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblEstadoVenta.Location = new System.Drawing.Point(632, 67);
            this.lblEstadoVenta.Name = "lblEstadoVenta";
            this.lblEstadoVenta.Size = new System.Drawing.Size(88, 17);
            this.lblEstadoVenta.TabIndex = 7;
            this.lblEstadoVenta.Text = "Estado Venta";
            // 
            // cbxEstadoVenta
            // 
            this.cbxEstadoVenta.FormattingEnabled = true;
            this.cbxEstadoVenta.Location = new System.Drawing.Point(599, 87);
            this.cbxEstadoVenta.Name = "cbxEstadoVenta";
            this.cbxEstadoVenta.Size = new System.Drawing.Size(121, 23);
            this.cbxEstadoVenta.TabIndex = 8;
            this.cbxEstadoVenta.SelectedValueChanged += new System.EventHandler(this.cbxEstadoVenta_SelectedValueChanged);
            // 
            // btnSeleccionarTodas
            // 
            this.btnSeleccionarTodas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSeleccionarTodas.Location = new System.Drawing.Point(597, 9);
            this.btnSeleccionarTodas.Name = "btnSeleccionarTodas";
            this.btnSeleccionarTodas.Size = new System.Drawing.Size(123, 25);
            this.btnSeleccionarTodas.TabIndex = 9;
            this.btnSeleccionarTodas.Text = "Seleccionar todas";
            this.btnSeleccionarTodas.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodas.Click += new System.EventHandler(this.btnSeleccionarTodas_Click);
            // 
            // btnDeseleccionarTodas
            // 
            this.btnDeseleccionarTodas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeseleccionarTodas.Location = new System.Drawing.Point(597, 40);
            this.btnDeseleccionarTodas.Name = "btnDeseleccionarTodas";
            this.btnDeseleccionarTodas.Size = new System.Drawing.Size(123, 25);
            this.btnDeseleccionarTodas.TabIndex = 10;
            this.btnDeseleccionarTodas.Text = "Deseleccionar";
            this.btnDeseleccionarTodas.UseVisualStyleBackColor = true;
            this.btnDeseleccionarTodas.Click += new System.EventHandler(this.btnDeseleccionarTodas_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(468, 9);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(123, 25);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnGuardarComo
            // 
            this.btnGuardarComo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarComo.Location = new System.Drawing.Point(468, 40);
            this.btnGuardarComo.Name = "btnGuardarComo";
            this.btnGuardarComo.Size = new System.Drawing.Size(123, 25);
            this.btnGuardarComo.TabIndex = 12;
            this.btnGuardarComo.Text = "Guardar como";
            this.btnGuardarComo.UseVisualStyleBackColor = true;
            this.btnGuardarComo.Click += new System.EventHandler(this.btnGuardarComo_Click);
            // 
            // FrmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 356);
            this.Controls.Add(this.btnGuardarComo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnDeseleccionarTodas);
            this.Controls.Add(this.btnSeleccionarTodas);
            this.Controls.Add(this.cbxEstadoVenta);
            this.Controls.Add(this.lblEstadoVenta);
            this.Controls.Add(this.lblTextoBuscado);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.tbxBuscar);
            this.Controls.Add(this.dtgvHistorial);
            this.Controls.Add(this.lblNombre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHistorial";
            this.ShowIcon = false;
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.FrmHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNombre;
        private DataGridView dtgvHistorial;
        private TextBox tbxBuscar;
        private Label lblBuscar;
        private Button btnFiltrar;
        private Button btnLimpiar;
        private Label lblTextoBuscado;
        private Label lblEstadoVenta;
        private ComboBox cbxEstadoVenta;
        private DataGridViewCheckBoxColumn Seleccionar;
        private Button btnSeleccionarTodas;
        private Button btnDeseleccionarTodas;
        private Button btnGuardar;
        private Button btnGuardarComo;
    }
}