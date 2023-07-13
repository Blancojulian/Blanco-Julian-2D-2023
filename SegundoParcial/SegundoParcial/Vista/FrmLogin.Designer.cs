namespace SegundoParcial.Vista
{
    partial class FrmLogin
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
            this.lblMail = new System.Windows.Forms.Label();
            this.tbxMail = new System.Windows.Forms.TextBox();
            this.tbxContrasenia = new System.Windows.Forms.TextBox();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.gpbxUsuarios = new System.Windows.Forms.GroupBox();
            this.btnCompletarDatos = new System.Windows.Forms.Button();
            this.rbtnVendedor = new System.Windows.Forms.RadioButton();
            this.rbtnCliente = new System.Windows.Forms.RadioButton();
            this.gpbxUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMail.Location = new System.Drawing.Point(266, 80);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(50, 25);
            this.lblMail.TabIndex = 0;
            this.lblMail.Text = "Mail";
            // 
            // tbxMail
            // 
            this.tbxMail.Location = new System.Drawing.Point(266, 108);
            this.tbxMail.Name = "tbxMail";
            this.tbxMail.Size = new System.Drawing.Size(147, 23);
            this.tbxMail.TabIndex = 1;
            // 
            // tbxContrasenia
            // 
            this.tbxContrasenia.Location = new System.Drawing.Point(266, 176);
            this.tbxContrasenia.Name = "tbxContrasenia";
            this.tbxContrasenia.PasswordChar = '*';
            this.tbxContrasenia.Size = new System.Drawing.Size(147, 23);
            this.tbxContrasenia.TabIndex = 3;
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContrasenia.Location = new System.Drawing.Point(266, 148);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(113, 25);
            this.lblContrasenia.TabIndex = 2;
            this.lblContrasenia.Text = "Contraseña";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.Location = new System.Drawing.Point(266, 232);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(147, 32);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // gpbxUsuarios
            // 
            this.gpbxUsuarios.Controls.Add(this.btnCompletarDatos);
            this.gpbxUsuarios.Controls.Add(this.rbtnVendedor);
            this.gpbxUsuarios.Controls.Add(this.rbtnCliente);
            this.gpbxUsuarios.Location = new System.Drawing.Point(479, 90);
            this.gpbxUsuarios.Name = "gpbxUsuarios";
            this.gpbxUsuarios.Size = new System.Drawing.Size(129, 99);
            this.gpbxUsuarios.TabIndex = 5;
            this.gpbxUsuarios.TabStop = false;
            this.gpbxUsuarios.Text = "Usuarios";
            // 
            // btnCompletarDatos
            // 
            this.btnCompletarDatos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCompletarDatos.Location = new System.Drawing.Point(6, 72);
            this.btnCompletarDatos.Name = "btnCompletarDatos";
            this.btnCompletarDatos.Size = new System.Drawing.Size(117, 23);
            this.btnCompletarDatos.TabIndex = 2;
            this.btnCompletarDatos.Text = "Completar Datos";
            this.btnCompletarDatos.UseVisualStyleBackColor = true;
            this.btnCompletarDatos.Click += new System.EventHandler(this.btnCompletarDatos_Click);
            // 
            // rbtnVendedor
            // 
            this.rbtnVendedor.AutoSize = true;
            this.rbtnVendedor.Location = new System.Drawing.Point(6, 47);
            this.rbtnVendedor.Name = "rbtnVendedor";
            this.rbtnVendedor.Size = new System.Drawing.Size(75, 19);
            this.rbtnVendedor.TabIndex = 1;
            this.rbtnVendedor.TabStop = true;
            this.rbtnVendedor.Text = "Vendedor";
            this.rbtnVendedor.UseVisualStyleBackColor = true;
            // 
            // rbtnCliente
            // 
            this.rbtnCliente.AutoSize = true;
            this.rbtnCliente.Location = new System.Drawing.Point(6, 22);
            this.rbtnCliente.Name = "rbtnCliente";
            this.rbtnCliente.Size = new System.Drawing.Size(62, 19);
            this.rbtnCliente.TabIndex = 0;
            this.rbtnCliente.TabStop = true;
            this.rbtnCliente.Text = "Cliente";
            this.rbtnCliente.UseVisualStyleBackColor = true;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 331);
            this.Controls.Add(this.gpbxUsuarios);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxContrasenia);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.tbxMail);
            this.Controls.Add(this.lblMail);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.gpbxUsuarios.ResumeLayout(false);
            this.gpbxUsuarios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMail;
        private TextBox tbxMail;
        private TextBox tbxContrasenia;
        private Label lblContrasenia;
        private Button btnLogin;
        private GroupBox gpbxUsuarios;
        private RadioButton rbtnVendedor;
        private RadioButton rbtnCliente;
        private Button btnCompletarDatos;
    }
}