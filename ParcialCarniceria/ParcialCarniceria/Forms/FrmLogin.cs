using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialCarniceria.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void CompletarDatos()
        {
            bool respuesta = false;
            string mail = string.Empty;
            string contrasenia = string.Empty;
            if (this.rbtnVendedor.Checked)
            {
                respuesta = Carniceria.GetUsuario(Usuarios.Vendedor, out mail, out contrasenia);
            }
            else if (this.rbtnCliente.Checked)
            {
                respuesta = Carniceria.GetUsuario(Usuarios.Cliente, out mail, out contrasenia);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opcion");
            }

            if (respuesta)
            {
                this.tbxMail.Text = mail;
                this.tbxContrasenia.Text = contrasenia;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario? usuario = Carniceria.GetUsuario(this.tbxMail.Text, this.tbxContrasenia.Text);
            FrmDinero frmDinero;
            

            if (usuario is Cliente)
            {
                MessageBox.Show("el usuario es Cliente");
                frmDinero = new FrmDinero((Cliente)usuario);
                frmDinero.ShowDialog();

                if(frmDinero.DialogResult == DialogResult.OK)
                {
                    FrmVenta frmVenta = new FrmVenta((Cliente)usuario, this);
                    this.Hide();
                    frmVenta.Show();

                }

            }
            else if (usuario is Vendedor)
            {
                MessageBox.Show("el usuario es Vendedor");
                FrmHeladera frmHeladera = new FrmHeladera((Vendedor)usuario, this);
                this.Hide();
                frmHeladera.Show();
            }
            else
            {
                MessageBox.Show("El mail o contraseña es INCORECTO");
            }
        }

        private void btnCompletarDatos_Click(object sender, EventArgs e)
        {
            this.CompletarDatos();
        }
    }
}
