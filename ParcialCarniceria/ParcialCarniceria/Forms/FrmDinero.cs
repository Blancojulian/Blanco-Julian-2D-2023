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

namespace ParcialCarniceria.Forms
{
    public partial class FrmDinero : Form
    {
        private Cliente _cliente;
        private SoundPlayer _playerError;
        private SoundPlayer _playerClick;
        public FrmDinero(Cliente cliente)
        {
            InitializeComponent();
            this._cliente = cliente;
            this._playerClick = new SoundPlayer(Properties.Resources.click);
            this._playerError = new SoundPlayer(Properties.Resources.error);
        }  

        private void FrmDinero_Load(object sender, EventArgs e)
        {
            this.ConfiguarForm();
            this.lblBienvenida.Text = $"Bienvenido {this._cliente.Nombre} {this._cliente.Apellido}";
            this.nudDinero.Value = (decimal)this._cliente.Dinero;
        }

        private void ConfirmarDineroDisponible()
        {
            decimal monto = nudDinero.Value;

            if(monto > 0)
            {
                this._cliente.Dinero = (double)monto;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese un monto mayor a cero");
                //this.DialogResult = DialogResult.No;
                this._playerError.Play();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();

            this.ConfirmarDineroDisponible();
        }

        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.FromArgb(209, 157, 250);
        }
    }
}
