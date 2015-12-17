using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            localhost.Servicio servicio = new localhost.Servicio();
            StringReader sr = new StringReader(servicio.ObtenerContactos());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            grvContactos.DataSource = ds.Tables[0];
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            localhost.Servicio servicio = new localhost.Servicio();
            lblMensaje.Text = servicio.GuardarContacto(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text);
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            CargarDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
