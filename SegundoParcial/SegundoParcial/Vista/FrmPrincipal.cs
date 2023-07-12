using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcial.Vista
{
    public partial class FrmPrincipal : Form
    {
        FrmLogin frmLogin;
        FrmHeladera frmHeladera;
        FrmCliente frmCliente;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.frmLogin = new FrmLogin();
            this.frmLogin.MdiParent = this;
            this.frmLogin.FormClosed += CerrarLoginYAbrirFormSegunUsuario;
            //frmLogin.Dock = DockStyle.Fill;
            this.frmLogin.Show();
            //frmLogin.WindowState = FormWindowState.Maximized;

        }
        private void CerrarLoginYAbrirFormSegunUsuario(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show($"frmLogin cerrado: {e.CloseReason}");
        }

        private void AbrirLogin()
        {
            this.frmLogin = new FrmLogin();
            this.frmCliente = null;
            this.frmHeladera = null;
        }
        private void AbrirHeladera()
        {

        }
        private void AbrirCliente()
        {

        }
    }
}
