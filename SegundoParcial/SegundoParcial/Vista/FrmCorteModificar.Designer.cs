namespace SegundoParcial.Vista
{
    partial class FrmCorteModificar
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
            this.chbxNombre = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();
            // 
            // nudPrecio
            // 
            this.nudPrecio.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // nudStock
            // 
            this.nudStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.DataSource = new Categorias[] {
        Categorias.Primera,
        Categorias.Segunda,
        Categorias.Tercera};/*
            this.cbxCategoria.Items.AddRange(new object[] {
            Categorias.Primera,
            Categorias.Segunda,
            Categorias.Tercera});*/
            // 
            // chbxNombre
            // 
            this.chbxNombre.AutoSize = true;
            this.chbxNombre.Location = new System.Drawing.Point(262, 247);
            this.chbxNombre.Name = "chbxNombre";
            this.chbxNombre.Size = new System.Drawing.Size(124, 19);
            this.chbxNombre.TabIndex = 12;
            this.chbxNombre.Text = "Modificar Nombre";
            this.chbxNombre.UseVisualStyleBackColor = true;
            this.chbxNombre.CheckedChanged += new System.EventHandler(this.chbxNombre_CheckedChanged);
            // 
            // FrmCorteModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 450);
            this.ControlBox = false;
            this.Controls.Add(this.chbxNombre);
            this.Name = "FrmCorteModificar";
            this.Text = "FrmCorteModificar";
            this.Load += new System.EventHandler(this.FrmCorteModificar_Load);
            this.Controls.SetChildIndex(this.tbxNombre, 0);
            this.Controls.SetChildIndex(this.nudPrecio, 0);
            this.Controls.SetChildIndex(this.nudStock, 0);
            this.Controls.SetChildIndex(this.cbxCategoria, 0);
            this.Controls.SetChildIndex(this.rtbxDetalle, 0);
            this.Controls.SetChildIndex(this.chbxNombre, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox chbxNombre;
    }
}