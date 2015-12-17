using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Circulo") {
                localhost.Service1 srv = new localhost.Service1();
                double r = Convert.ToDouble(txt1.Text);
                lblResultado.Text=srv.ObtenerAreaCirculo(r).ToString();
            
            }else if(DropDownList1.SelectedValue=="Triangulo"){
                localhost.Service1 srv = new localhost.Service1();
                double b=Convert.ToDouble(txt1.Text);
                double a=Convert.ToDouble(txt2.Text);
                lblResultado.Text=srv.ObtenerAreaTriangulo(b,a).ToString();

            }
            else if (DropDownList1.SelectedValue == "Cuadrado") {
                localhost.Service1 srv = new localhost.Service1();
                double l = Convert.ToDouble(txt1.Text);
                lblResultado.Text = srv.ObtenerAreaCuadrado(l).ToString();


            }
        }
    }
}