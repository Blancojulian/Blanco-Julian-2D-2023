using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial.Vista
{
    public partial class FrmLogin : FrmBase
    {

        public FrmLogin() : base()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            Usuario? usuario = Login.GetUsuario(this.tbxMail.Text, this.tbxContrasenia.Text);
            FrmDinero frmDinero;


            if (usuario is Cliente)
            {
                frmDinero = new FrmDinero((Cliente)usuario);
                frmDinero.ShowDialog();

                if (frmDinero.DialogResult == DialogResult.OK)
                {//antes era FrmVenta
                    FrmCliente frmVenta = new FrmCliente((Cliente)usuario);
                    frmVenta.OnAbrirLogin += MostrarFormLogin;
                    this.Hide();
                    frmVenta.Show();

                }

            }
            else if (usuario is Vendedor)
            {
                FrmHeladera frmHeladera = new FrmHeladera((Vendedor)usuario);
                frmHeladera.OnAbrirLogin += MostrarFormLogin;
                this.Hide();
                frmHeladera.Show();
            }
            else
            {
                this.PlayError();
                MessageBox.Show("El mail o contraseña es INCORECTO");
            }
        }

        private void btnCompletarDatos_Click(object sender, EventArgs e)
        {
            this.PlayClick();
            this.CompletarDatos();
        }

        private void CompletarDatos()
        {
            bool respuesta = false;
            string mail = string.Empty;
            string contrasenia = string.Empty;

            try
            {
                if (this.rbtnVendedor.Checked)
                {
                    respuesta = Login.GetUsuario(Usuarios.Vendedor, out mail, out contrasenia);
                }
                else if (this.rbtnCliente.Checked)
                {
                    respuesta = Login.GetUsuario(Usuarios.Cliente, out mail, out contrasenia);
                }
                else
                {
                    this.PlayError();
                    MessageBox.Show("Debe seleccionar una opcion");
                }

                if (respuesta)
                {
                    this.tbxMail.Text = mail;
                    this.tbxContrasenia.Text = contrasenia;
                }
            }
            catch (Exception ex)
            {
                this.PlayError();
                MostrarVentanaDeError(ex);

            }   
        }

        protected override void ConfigurarForm()
        {
            base.ConfigurarForm();
            //para cuando sea mdiChildren de FrmPrincipal, probar
            //this.ControlBox = false;
            //this.FormBorderStyle = FormBorderStyle.None;
            /*
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(255, 255, 255);
            this.Dock = DockStyle.Fill;

            this.WindowState = FormWindowState.Maximized;
            */

        }
        protected override void ConfigurarColorForm()
        {
            this.BackColor = Color.FromArgb(239, 254, 207);
        }

        private void MostrarFormLogin()
        {
            this.Show();
        }
    }
}
