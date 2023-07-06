using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Excepciones;
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
    public partial class FrmDinero : FrmBase
    {
        private Cliente _cliente;
        public FrmDinero(Cliente cliente) : base()
        {
            InitializeComponent();
            this._cliente = cliente;
        }

        private void FrmDinero_Load(object sender, EventArgs e)
        {
            this.lblBienvenida.Text = $"Bienvenido {this._cliente.MostrarNombreApellido()}";
            this.nudDinero.Value = (decimal)this._cliente.Dinero;
        }

        private void ConfirmarDineroDisponible()
        {
            decimal monto = nudDinero.Value;

            try
            {
                
                this._cliente.ActulizarDinero((double)monto);
                this.DialogResult = DialogResult.OK;
                this.Close();
               
            }
            catch (DineroExcepcion ex)
            {
                this._playerError.Play();
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                this._playerError.Play();
                MostrarVentanaDeError(ex);
            }
            
        }
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.ConfirmarDineroDisponible();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void ConfigurarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.ShowIcon = false;
        }

        protected override void ConfigurarColorForm()
        {
            this.BackColor = Color.FromArgb(209, 157, 250);

        }

    }
}
