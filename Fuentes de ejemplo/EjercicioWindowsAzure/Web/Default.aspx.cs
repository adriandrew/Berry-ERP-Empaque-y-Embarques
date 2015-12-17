using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        void Cargar()
        {
            ServiceReference1.ServicioClient s = new ServiceReference1.ServicioClient();
            grvAnuncios.DataSource=s.Listado();
            grvAnuncios.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();   
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServicioClient srv = new ServiceReference1.ServicioClient();
            ServiceReference1.Anuncio a = new ServiceReference1.Anuncio();
            grvAnuncios.DataSource = srv.Listado();
            a.Descripcion = txtDescripcion.Text;
            a.Url = txtUrl.Text;
            a.UrlImagen = txtUrlImagen.Text;
            if(Convert.ToBoolean(Session["editar"])){
                a.Id = Convert.ToInt32(Session["id"]);
                srv.Editar(a);
                grvAnuncios.SelectedIndex = -1;
                Session["editar"] = false;
            }
            else 
                srv.Agregar(a);
            Cargar();
            txtDescripcion.Text = String.Empty;
            txtUrl.Text = String.Empty;
            txtUrlImagen.Text = String.Empty;

        }

        protected void grvAnuncios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceReference1.ServicioClient srv = new ServiceReference1.ServicioClient();
            ServiceReference1.Anuncio a = srv.Obtener(Convert.ToInt32(grvAnuncios.SelectedRow.Cells[0].Text));
            txtDescripcion.Text = a.Descripcion;
            txtUrl.Text = a.Url;
            txtUrlImagen.Text = a.UrlImagen;
            Session["id"] = grvAnuncios.SelectedRow.Cells[0].Text;
            Session["editar"] = true;


        }

        protected void grvAnuncios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = false;
            ServiceReference1.ServicioClient srv = new ServiceReference1.ServicioClient();
            srv.Eliminar(Convert.ToInt32(grvAnuncios.Rows[e.RowIndex].Cells[0].Text));
            Cargar();
        }

       


    }
}