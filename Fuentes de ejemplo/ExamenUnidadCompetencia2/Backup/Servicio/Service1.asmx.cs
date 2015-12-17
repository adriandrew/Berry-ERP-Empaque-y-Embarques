using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Servicio
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public double ObtenerAreaCirculo(double radio)
        {
            return (Math.PI * radio * radio) / 2;              
        }

        [WebMethod]
        public double ObtenerAreaTriangulo(double b,double a)
        {
            return (b * a) / 2;
        }


        [WebMethod]
        public double ObtenerAreaCuadrado(double lado)
        {
            return lado * lado;

        }
    }
}