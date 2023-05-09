namespace ParcialCarniceria.Forms
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
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.tbxMail = new System.Windows.Forms.TextBox();
            this.tbxContrasenia = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.gbxUsuario = new System.Windows.Forms.GroupBox();
            this.btnCompletarDatos = new System.Windows.Forms.Button();
            this.rbtnCliente = new System.Windows.Forms.RadioButton();
            this.rbtnVendedor = new System.Windows.Forms.RadioButton();
            this.gbxUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMail.Location = new System.Drawing.Point(170, 72);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(44, 21);
            this.lblMail.TabIndex = 0;
            this.lblMail.Text = "Mail";
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContrasenia.Location = new System.Drawing.Point(170, 151);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(96, 21);
            this.lblContrasenia.TabIndex = 1;
            this.lblContrasenia.Text = "Contraseña";
            // 
            // tbxMail
            // 
            this.tbxMail.Location = new System.Drawing.Point(170, 96);
            this.tbxMail.Name = "tbxMail";
            this.tbxMail.Size = new System.Drawing.Size(143, 23);
            this.tbxMail.TabIndex = 2;
            // 
            // tbxContrasenia
            // 
            this.tbxContrasenia.Location = new System.Drawing.Point(170, 175);
            this.tbxContrasenia.Name = "tbxContrasenia";
            this.tbxContrasenia.PasswordChar = '*';
            this.tbxContrasenia.Size = new System.Drawing.Size(143, 23);
            this.tbxContrasenia.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.Location = new System.Drawing.Point(200, 242);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // gbxUsuario
            // 
            this.gbxUsuario.Controls.Add(this.btnCompletarDatos);
            this.gbxUsuario.Controls.Add(this.rbtnCliente);
            this.gbxUsuario.Controls.Add(this.rbtnVendedor);
            this.gbxUsuario.Location = new System.Drawing.Point(342, 72);
            this.gbxUsuario.Name = "gbxUsuario";
            this.gbxUsuario.Size = new System.Drawing.Size(131, 126);
            this.gbxUsuario.TabIndex = 5;
            this.gbxUsuario.TabStop = false;
            this.gbxUsuario.Text = "Usuario";
            // 
            // btnCompletarDatos
            // 
            this.btnCompletarDatos.Location = new System.Drawing.Point(10, 93);
            this.btnCompletarDatos.Name = "btnCompletarDatos";
            this.btnCompletarDatos.Size = new System.Drawing.Size(112, 27);
            this.btnCompletarDatos.TabIndex = 6;
            this.btnCompletarDatos.Text = "Completar datos";
            this.btnCompletarDatos.UseVisualStyleBackColor = true;
            this.btnCompletarDatos.Click += new System.EventHandler(this.btnCompletarDatos_Click);
            // 
            // rbtnCliente
            // 
            this.rbtnCliente.AutoSize = true;
            this.rbtnCliente.Location = new System.Drawing.Point(10, 58);
            this.rbtnCliente.Name = "rbtnCliente";
            this.rbtnCliente.Size = new System.Drawing.Size(62, 19);
            this.rbtnCliente.TabIndex = 1;
            this.rbtnCliente.TabStop = true;
            this.rbtnCliente.Text = "Cliente";
            this.rbtnCliente.UseVisualStyleBackColor = true;
            // 
            // rbtnVendedor
            // 
            this.rbtnVendedor.AutoSize = true;
            this.rbtnVendedor.Location = new System.Drawing.Point(10, 31);
            this.rbtnVendedor.Name = "rbtnVendedor";
            this.rbtnVendedor.Size = new System.Drawing.Size(75, 19);
            this.rbtnVendedor.TabIndex = 0;
            this.rbtnVendedor.TabStop = true;
            this.rbtnVendedor.Text = "Vendedor";
            this.rbtnVendedor.UseVisualStyleBackColor = true;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 450);
            this.Controls.Add(this.gbxUsuario);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxContrasenia);
            this.Controls.Add(this.tbxMail);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.lblMail);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.gbxUsuario.ResumeLayout(false);
            this.gbxUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMail;
        private Label lblContrasenia;
        private TextBox tbxMail;
        private TextBox tbxContrasenia;
        private Button btnLogin;
        private GroupBox gbxUsuario;
        private RadioButton rbtnCliente;
        private RadioButton rbtnVendedor;
        private Button btnCompletarDatos;
    }
}