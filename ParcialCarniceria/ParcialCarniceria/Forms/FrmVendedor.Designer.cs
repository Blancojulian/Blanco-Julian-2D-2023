﻿namespace ParcialCarniceria.Forms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgvDatos = new System.Windows.Forms.DataGridView();
            this.VerCompras = new System.Windows.Forms.DataGridViewButtonColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvDatos
            // 
            this.dtgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VerCompras,
            this.check});
            this.dtgvDatos.Location = new System.Drawing.Point(42, 77);
            this.dtgvDatos.Name = "dtgvDatos";
            this.dtgvDatos.RowTemplate.Height = 25;
            this.dtgvDatos.Size = new System.Drawing.Size(497, 150);
            this.dtgvDatos.TabIndex = 0;
            this.dtgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDatos_CellContentClick);
            // 
            // VerCompras
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "ver";
            this.VerCompras.DefaultCellStyle = dataGridViewCellStyle1;
            this.VerCompras.HeaderText = "Ver Compras";
            this.VerCompras.Name = "VerCompras";
            // 
            // check
            // 
            this.check.HeaderText = "eliminar";
            this.check.Name = "check";
            // 
            // FrmVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 323);
            this.Controls.Add(this.dtgvDatos);
            this.Name = "FrmVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVendedor_FormClosing);
            this.Load += new System.EventHandler(this.FrmVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dtgvDatos;
        private DataGridViewButtonColumn VerCompras;
        private DataGridViewCheckBoxColumn check;
    }
}