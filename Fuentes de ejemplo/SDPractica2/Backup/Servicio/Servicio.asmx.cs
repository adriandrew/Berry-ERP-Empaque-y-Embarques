using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidades;

namespace Servicio
{
    /// <summary>
    /// Descripción breve de Servicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicio : System.Web.Services.WebService
    {

        [WebMethod]
        public string GuardarAutomovil(string marca, string modelo, string anio, string descripcion)
        {
            try {
            Automovil auto= new Automovil();
            auto.Marca = marca;
            auto.Modelo = modelo;
            auto.Anio = anio;
            auto.Descripcion = descripcion;
            auto.Guardar();
            return "Elemento Guardado";
            }
            catch(Exception ex){
                return ex.InnerException.Message;
            
            }
        }

        [WebMethod]
        public string EditarAutomovil(int id, string marca, string modelo, string anio, string descripcion)
        {
            try
            {
                Automovil auto = new Automovil();
                auto.Id = id;
                auto.Marca = marca;
                auto.Modelo = modelo;
                auto.Anio = anio;
                auto.Descripcion = descripcion;
                auto.Editar();
                return "Elemento Guardado";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;

            }
        }

        [WebMethod]
        public string EliminarAutomovil(int id)
        {
            try
            {
                Automovil auto = new Automovil();
                auto.Id = id;
                auto.Eliminar();
                return "Elemento eliminado";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;

            }
        }

        [WebMethod]
        public string ObtenerAutomovil(int id)
        {
            try
            {
                Automovil auto = new Automovil();
                auto.Id = id;
                return auto.Obtener();
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;

            }
        }


        [WebMethod]
        public string ObtenerListado()
        {
            try
            {
                Automovil auto = new Automovil();
                return auto.ObtenerListado();
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;

            }
        }
    }
}
