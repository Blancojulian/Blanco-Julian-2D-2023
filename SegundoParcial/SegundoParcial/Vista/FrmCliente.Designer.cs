namespace SegundoParcial.Vista
{
    partial class FrmCliente
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
            this.lblSaludo = new System.Windows.Forms.Label();
            this.lblDinero = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.tbxBuscar = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnLimpiarCarrito = new System.Windows.Forms.Button();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dtgvDatos = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msiCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSaludo
            // 
            this.lblSaludo.AutoSize = true;
            this.lblSaludo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSaludo.Location = new System.Drawing.Point(48, 43);
            this.lblSaludo.Name = "lblSaludo";
            this.lblSaludo.Size = new System.Drawing.Size(123, 30);
            this.lblSaludo.TabIndex = 0;
            this.lblSaludo.Text = "Bienvenido";
            // 
            // lblDinero
            // 
            this.lblDinero.AutoSize = true;
            this.lblDinero.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDinero.Location = new System.Drawing.Point(48, 109);
            this.lblDinero.Name = "lblDinero";
            this.lblDinero.Size = new System.Drawing.Size(171, 25);
            this.lblDinero.TabIndex = 1;
            this.lblDinero.Text = "Dinero disponible";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMonto.ForeColor = System.Drawing.Color.Red;
            this.lblMonto.Location = new System.Drawing.Point(225, 109);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(23, 25);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "0";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.Location = new System.Drawing.Point(48, 137);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(123, 23);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar dinero";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblBuscar.Location = new System.Drawing.Point(51, 172);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(48, 17);
            this.lblBuscar.TabIndex = 4;
            this.lblBuscar.Text = "Buscar";
            // 
            // tbxBuscar
            // 
            this.tbxBuscar.Location = new System.Drawing.Point(51, 192);
            this.tbxBuscar.Name = "tbxBuscar";
            this.tbxBuscar.Size = new System.Drawing.Size(142, 23);
            this.tbxBuscar.TabIndex = 5;
            this.tbxBuscar.TextChanged += new System.EventHandler(this.tbxBuscar_TextChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiar.Location = new System.Drawing.Point(199, 192);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(87, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(334, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(403, 166);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(110, 23);
            this.nudCantidad.TabIndex = 8;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.Location = new System.Drawing.Point(334, 191);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(87, 23);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.Location = new System.Drawing.Point(427, 192);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(87, 23);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(520, 192);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 23);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroFactura.Location = new System.Drawing.Point(628, 24);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(186, 30);
            this.lblNumeroFactura.TabIndex = 12;
            this.lblNumeroFactura.Text = "Factura 00000000";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.Location = new System.Drawing.Point(628, 109);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(89, 51);
            this.btnConfirmar.TabIndex = 13;
            this.btnConfirmar.Text = "Confirmar compra";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnLimpiarCarrito
            // 
            this.btnLimpiarCarrito.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiarCarrito.ForeColor = System.Drawing.Color.Red;
            this.btnLimpiarCarrito.Location = new System.Drawing.Point(723, 109);
            this.btnLimpiarCarrito.Name = "btnLimpiarCarrito";
            this.btnLimpiarCarrito.Size = new System.Drawing.Size(89, 51);
            this.btnLimpiarCarrito.TabIndex = 14;
            this.btnLimpiarCarrito.Text = "Limpiar Carrito";
            this.btnLimpiarCarrito.UseVisualStyleBackColor = true;
            this.btnLimpiarCarrito.Click += new System.EventHandler(this.btnLimpiarCarrito_Click);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(628, 192);
            this.lblDetalle.MaximumSize = new System.Drawing.Size(280, 0);
            this.lblDetalle.MinimumSize = new System.Drawing.Size(280, 0);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(280, 15);
            this.lblDetalle.TabIndex = 15;
            this.lblDetalle.Text = "Detalle";
            // 
            // dtgvDatos
            // 
            this.dtgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDatos.Location = new System.Drawing.Point(48, 221);
            this.dtgvDatos.Name = "dtgvDatos";
            this.dtgvDatos.RowTemplate.Height = 25;
            this.dtgvDatos.Size = new System.Drawing.Size(559, 230);
            this.dtgvDatos.TabIndex = 16;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(628, 64);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(61, 30);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Total";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMontoTotal.ForeColor = System.Drawing.Color.Red;
            this.lblMontoTotal.Location = new System.Drawing.Point(695, 64);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(25, 30);
            this.lblMontoTotal.TabIndex = 18;
            this.lblMontoTotal.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiCerrarSesion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(922, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msiCerrarSesion
            // 
            this.msiCerrarSesion.Name = "msiCerrarSesion";
            this.msiCerrarSesion.Size = new System.Drawing.Size(88, 20);
            this.msiCerrarSesion.Text = "Cerrar Sesion";
            this.msiCerrarSesion.Click += new System.EventHandler(this.msiCerrarSesion_Click);
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 463);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dtgvDatos);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.btnLimpiarCarrito);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblNumeroFactura);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.tbxBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblDinero);
            this.Controls.Add(this.lblSaludo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCliente";
            this.ShowIcon = false;
            this.Text = "FrmCliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCliente_FormClosing);
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblSaludo;
        private Label lblDinero;
        private Label lblMonto;
        private Button btnActualizar;
        private Label lblBuscar;
        private TextBox tbxBuscar;
        private Button btnLimpiar;
        private Label label1;
        private NumericUpDown nudCantidad;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Label lblNumeroFactura;
        private Button btnConfirmar;
        private Button btnLimpiarCarrito;
        private Label lblDetalle;
        private DataGridView dtgvDatos;
        private Label lblTotal;
        private Label lblMontoTotal;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem msiCerrarSesion;
    }
}