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
    public partial class FrmBase : Form
    {
        protected SoundPlayer _playerError;
        protected SoundPlayer _playerClick;
        public FrmBase()
        {
            InitializeComponent();
            this._playerClick = new SoundPlayer(Properties.Resources.click);
            this._playerError = new SoundPlayer(Properties.Resources.error);
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {
            this.ConfigurarForm();
            this.ConfigurarColorForm();

        }

        protected virtual void ConfigurarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.ControlBox = false;
            this.ShowIcon = false;
        }

        protected virtual void ConfigurarColorForm()
        {
            this.BackColor = Color.FromArgb(239, 254, 207);
        }

        protected virtual void MostrarVentanaDeError(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error: {ex.Message}");
            sb.AppendLine("Detalle:");
            sb.AppendLine(ex.StackTrace);

            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
