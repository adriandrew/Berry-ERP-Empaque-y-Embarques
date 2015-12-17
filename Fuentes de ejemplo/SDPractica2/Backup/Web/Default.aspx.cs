using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        void Cargar() {
            localhost.Servicio srv = new localhost.Servicio();
            StringReader sr = new StringReader(srv.ObtenerListado());
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            grvAutomoviles.DataSource = ds.Tables[0];
            grvAutomoviles.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            localhost.Servicio srv = new localhost.Servicio();
            if (!Convert.ToBoolean(Session["editar"]))
            {
                srv.GuardarAutomovil(txtMarca.Text, txtModelo.Text, txtAnio.Text, txtDescripcion.Text);
            }
            else {
                srv.EditarAutomovil(Convert.ToInt32(Session["id"]), txtMarca.Text, txtModelo.Text, txtAnio.Text, txtDescripcion.Text);
                Session["editar"] = false;
                Session["id"] = 0;
                grvAutomoviles.SelectedIndex = -1;
            }
            txtMarca.Text = String.Empty;
            txtModelo.Text = String.Empty;
            txtAnio.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            Cargar();

        }

        protected void grvAutomoviles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id"] = grvAutomoviles.SelectedRow.Cells[0].Text;
            localhost.Servicio srv = new localhost.Servicio();
            string[] datos = srv.ObtenerAutomovil(Convert.ToInt32(Session["id"])).Split('|');
            txtMarca.Text = datos[0];
            txtModelo.Text = datos[1];
            txtAnio.Text = datos[2];
            txtDescripcion.Text = datos[3];
            Session["editar"] = true;
        }

        protected void grvAutomoviles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            localhost.Servicio srv = new localhost.Servicio();
            srv.EliminarAutomovil(Convert.ToInt32(grvAutomoviles.Rows[e.RowIndex].Cells[0].Text));
            e.Cancel=true;
            Cargar();
        }


    }
}