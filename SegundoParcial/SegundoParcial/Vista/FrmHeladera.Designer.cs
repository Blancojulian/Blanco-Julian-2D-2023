namespace SegundoParcial.Vista
{
    partial class FrmHeladera
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msiVender = new System.Windows.Forms.ToolStripMenuItem();
            this.msiHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.msiSerializacion = new System.Windows.Forms.ToolStripMenuItem();
            this.msiAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.msiSerializar = new System.Windows.Forms.ToolStripMenuItem();
            this.msiCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblFiltroProductos = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbxFiltro = new System.Windows.Forms.ComboBox();
            this.tbxBuscar = new System.Windows.Forms.TextBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnReponer = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dtgvDatos = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSeleccionarTodos = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.tbxFiltrar = new System.Windows.Forms.TextBox();
            this.btnLimpiarFiltro = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDeseleccionarTodos = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnGuardarComo = new System.Windows.Forms.Button();
            this.lblFiltroBuscado = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiVender,
            this.msiHistorial,
            this.msiSerializacion,
            this.msiCerrarSesion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(906, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msiVender
            // 
            this.msiVender.Name = "msiVender";
            this.msiVender.Size = new System.Drawing.Size(55, 20);
            this.msiVender.Text = "Vender";
            this.msiVender.Click += new System.EventHandler(this.msiVender_Click);
            // 
            // msiHistorial
            // 
            this.msiHistorial.Name = "msiHistorial";
            this.msiHistorial.Size = new System.Drawing.Size(63, 20);
            this.msiHistorial.Text = "Historial";
            this.msiHistorial.Click += new System.EventHandler(this.msiHistorial_Click);
            // 
            // msiSerializacion
            // 
            this.msiSerializacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiAbrir,
            this.msiSerializar});
            this.msiSerializacion.Name = "msiSerializacion";
            this.msiSerializacion.Size = new System.Drawing.Size(84, 20);
            this.msiSerializacion.Text = "Serialización";
            // 
            // msiAbrir
            // 
            this.msiAbrir.Name = "msiAbrir";
            this.msiAbrir.Size = new System.Drawing.Size(120, 22);
            this.msiAbrir.Text = "Abrir";
            this.msiAbrir.Click += new System.EventHandler(this.msiAbrir_Click);
            // 
            // msiSerializar
            // 
            this.msiSerializar.Name = "msiSerializar";
            this.msiSerializar.Size = new System.Drawing.Size(120, 22);
            this.msiSerializar.Text = "Serializar";
            this.msiSerializar.Click += new System.EventHandler(this.msiSerializar_Click);
            // 
            // msiCerrarSesion
            // 
            this.msiCerrarSesion.Name = "msiCerrarSesion";
            this.msiCerrarSesion.Size = new System.Drawing.Size(88, 20);
            this.msiCerrarSesion.Text = "Cerrar Sesion";
            this.msiCerrarSesion.Click += new System.EventHandler(this.msiCerrarSesion_Click);
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVendedor.Location = new System.Drawing.Point(12, 45);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(84, 21);
            this.lblVendedor.TabIndex = 1;
            this.lblVendedor.Text = "Vendedor";
            // 
            // lblFiltroProductos
            // 
            this.lblFiltroProductos.AutoSize = true;
            this.lblFiltroProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblFiltroProductos.Location = new System.Drawing.Point(12, 80);
            this.lblFiltroProductos.Name = "lblFiltroProductos";
            this.lblFiltroProductos.Size = new System.Drawing.Size(120, 21);
            this.lblFiltroProductos.TabIndex = 2;
            this.lblFiltroProductos.Text = "Filtro Productos";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblBuscar.Location = new System.Drawing.Point(428, 107);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(123, 21);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar Producto";
            // 
            // cbxFiltro
            // 
            this.cbxFiltro.FormattingEnabled = true;
            this.cbxFiltro.Location = new System.Drawing.Point(12, 104);
            this.cbxFiltro.Name = "cbxFiltro";
            this.cbxFiltro.Size = new System.Drawing.Size(111, 23);
            this.cbxFiltro.TabIndex = 4;
            this.cbxFiltro.SelectedValueChanged += new System.EventHandler(this.cbxFiltro_SelectedValueChanged);
            // 
            // tbxBuscar
            // 
            this.tbxBuscar.Location = new System.Drawing.Point(428, 131);
            this.tbxBuscar.Name = "tbxBuscar";
            this.tbxBuscar.Size = new System.Drawing.Size(139, 23);
            this.tbxBuscar.TabIndex = 5;
            this.tbxBuscar.TextChanged += new System.EventHandler(this.tbxBuscar_TextChanged);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(648, 130);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 23);
            this.nudCantidad.TabIndex = 6;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnReponer
            // 
            this.btnReponer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReponer.Location = new System.Drawing.Point(774, 128);
            this.btnReponer.Name = "btnReponer";
            this.btnReponer.Size = new System.Drawing.Size(120, 25);
            this.btnReponer.TabIndex = 7;
            this.btnReponer.Text = "Reponer Stock";
            this.btnReponer.UseVisualStyleBackColor = true;
            this.btnReponer.Click += new System.EventHandler(this.btnReponer_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiar.Location = new System.Drawing.Point(573, 129);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(66, 25);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.Location = new System.Drawing.Point(648, 82);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 42);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar Producto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.Location = new System.Drawing.Point(774, 80);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 42);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar Producto";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dtgvDatos
            // 
            this.dtgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dtgvDatos.Location = new System.Drawing.Point(12, 162);
            this.dtgvDatos.Name = "dtgvDatos";
            this.dtgvDatos.RowTemplate.Height = 25;
            this.dtgvDatos.Size = new System.Drawing.Size(882, 169);
            this.dtgvDatos.TabIndex = 11;
            this.dtgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDatos_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(774, 32);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 42);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar Producto";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSeleccionarTodos
            // 
            this.btnSeleccionarTodos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSeleccionarTodos.Location = new System.Drawing.Point(284, 35);
            this.btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            this.btnSeleccionarTodos.Size = new System.Drawing.Size(127, 25);
            this.btnSeleccionarTodos.TabIndex = 13;
            this.btnSeleccionarTodos.Text = "Seleccionar Todos";
            this.btnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodos.Click += new System.EventHandler(this.btnSeleccionarTodos_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.Location = new System.Drawing.Point(129, 111);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(66, 45);
            this.btnFiltrar.TabIndex = 15;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // tbxFiltrar
            // 
            this.tbxFiltrar.Location = new System.Drawing.Point(12, 133);
            this.tbxFiltrar.Name = "tbxFiltrar";
            this.tbxFiltrar.Size = new System.Drawing.Size(111, 23);
            this.tbxFiltrar.TabIndex = 14;
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(201, 111);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(66, 45);
            this.btnLimpiarFiltro.TabIndex = 16;
            this.btnLimpiarFiltro.Text = "Limpiar Filtro";
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(417, 35);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(79, 25);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(526, 66);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 25);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnDeseleccionarTodos
            // 
            this.btnDeseleccionarTodos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeseleccionarTodos.Location = new System.Drawing.Point(284, 66);
            this.btnDeseleccionarTodos.Name = "btnDeseleccionarTodos";
            this.btnDeseleccionarTodos.Size = new System.Drawing.Size(127, 25);
            this.btnDeseleccionarTodos.TabIndex = 19;
            this.btnDeseleccionarTodos.Text = "Deseleccionar";
            this.btnDeseleccionarTodos.UseVisualStyleBackColor = true;
            this.btnDeseleccionarTodos.Click += new System.EventHandler(this.btnDeseleccionarTodos_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMensaje.Location = new System.Drawing.Point(502, 39);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(240, 17);
            this.lblMensaje.TabIndex = 20;
            this.lblMensaje.Text = "Seleccione los corte que desea guardar";
            // 
            // btnGuardarComo
            // 
            this.btnGuardarComo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarComo.Location = new System.Drawing.Point(417, 66);
            this.btnGuardarComo.Name = "btnGuardarComo";
            this.btnGuardarComo.Size = new System.Drawing.Size(103, 25);
            this.btnGuardarComo.TabIndex = 21;
            this.btnGuardarComo.Text = "Guardar como";
            this.btnGuardarComo.UseVisualStyleBackColor = true;
            this.btnGuardarComo.Click += new System.EventHandler(this.btnGuardarComo_Click);
            // 
            // lblFiltroBuscado
            // 
            this.lblFiltroBuscado.AutoSize = true;
            this.lblFiltroBuscado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFiltroBuscado.Location = new System.Drawing.Point(138, 93);
            this.lblFiltroBuscado.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblFiltroBuscado.MinimumSize = new System.Drawing.Size(300, 0);
            this.lblFiltroBuscado.Name = "lblFiltroBuscado";
            this.lblFiltroBuscado.Size = new System.Drawing.Size(300, 15);
            this.lblFiltroBuscado.TabIndex = 22;
            // 
            // FrmHeladera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 343);
            this.Controls.Add(this.lblFiltroBuscado);
            this.Controls.Add(this.btnGuardarComo);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnDeseleccionarTodos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiarFiltro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.tbxFiltrar);
            this.Controls.Add(this.btnSeleccionarTodos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dtgvDatos);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnReponer);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.tbxBuscar);
            this.Controls.Add(this.cbxFiltro);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblFiltroProductos);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHeladera";
            this.ShowIcon = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmHeladera_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem msiVender;
        private ToolStripMenuItem msiHistorial;
        private ToolStripMenuItem msiSerializacion;
        private ToolStripMenuItem msiAbrir;
        private ToolStripMenuItem msiSerializar;
        private Label lblVendedor;
        private Label lblFiltroProductos;
        private Label lblBuscar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox cbxFiltro;
        private TextBox tbxBuscar;
        private NumericUpDown nudCantidad;
        private Button btnReponer;
        private Button btnLimpiar;
        private Button btnAgregar;
        private Button btnModificar;
        private DataGridView dtgvDatos;
        private Button btnEliminar;
        private DataGridViewCheckBoxColumn Seleccionar;
        private Button btnSeleccionarTodos;
        private Button btnFiltrar;
        private TextBox tbxFiltrar;
        private Button btnLimpiarFiltro;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnDeseleccionarTodos;
        private Label lblMensaje;
        private Button btnGuardarComo;
        private Label lblFiltroBuscado;
        private ToolStripMenuItem msiCerrarSesion;
    }
}