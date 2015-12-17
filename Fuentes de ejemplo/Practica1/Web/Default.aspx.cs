using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Data;
namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos() {
            localhost.Servicio servicio = new localhost.Servicio();
            StringReader sr = new StringReader(servicio.ObtenerContactos());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            grvContactos.DataSource = ds.Tables[0];
            grvContactos.DataBind();
        
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            localhost.Servicio servicio = new localhost.Servicio();
            lblMensaje.Text= servicio.GuardarContacto(txtNombre.Text,txtDireccion.Text,txtTelefono.Text,txtCorreo.Text);
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            CargarDatos();
        }
    }
}