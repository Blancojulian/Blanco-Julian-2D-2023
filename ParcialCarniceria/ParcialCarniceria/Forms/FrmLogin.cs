﻿using BibliotecaEntidades.Entidades;
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
    public partial class FrmLogin : Form
    {
        private SoundPlayer _playerError;
        private SoundPlayer _playerClick;
        public FrmLogin()
        {
            InitializeComponent();
            this._playerClick = new SoundPlayer(Properties.Resources.click);
            this._playerError = new SoundPlayer(Properties.Resources.error);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.ConfiguarForm();
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
                this._playerError.Play();
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
            this._playerClick.Play();
            Usuario? usuario = Carniceria.GetUsuario(this.tbxMail.Text, this.tbxContrasenia.Text);
            FrmDinero frmDinero;
            

            if (usuario is Cliente)
            {
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
                FrmHeladera frmHeladera = new FrmHeladera((Vendedor)usuario, this);
                this.Hide();
                frmHeladera.Show();
            }
            else
            {
                this._playerError.Play();
                MessageBox.Show("El mail o contraseña es INCORECTO");
            }
        }

        private void btnCompletarDatos_Click(object sender, EventArgs e)
        {
            this._playerClick.Play();
            this.CompletarDatos();
        }

        private void ConfiguarForm()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.ControlBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.FromArgb(239, 254, 207);
        }
    }
}
