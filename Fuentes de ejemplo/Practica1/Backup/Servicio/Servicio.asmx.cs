using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
namespace Servicio
{
    /// <summary>
    /// Descripción breve de Servicio
    /// </summary>
    [WebService(Namespace = "http://iswug.net/", Description="Servicio para la administracion de contactos")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicio : System.Web.Services.WebService
    {

        [WebMethod(Description="Metodo para guardar un contacto")]
        public string GuardarContacto(string nombre, string direccion, string telefono, string correo)
        {
            string ruta = @"c:\users\omar félix vázquez\documents\visual studio 2010\Projects\Practica1\Servicio\Contactos.xml";
            XmlDataDocument xml = new XmlDataDocument();
            xml.Load(ruta);
            XmlNodeList raiz = xml.GetElementsByTagName("Contactos");
            XmlElement elemento = xml.CreateElement("Elemento");
            raiz[0].AppendChild(elemento);

            XmlElement nombreTag = xml.CreateElement("Nombre");
            nombreTag.InnerText = nombre;
            elemento.AppendChild(nombreTag);

            XmlElement direccionTag = xml.CreateElement("Direccion");
            direccionTag.InnerText = direccion;
            elemento.AppendChild(direccionTag);

            XmlElement telefonoTag = xml.CreateElement("Telefono");
            telefonoTag.InnerText = telefono;
            elemento.AppendChild(telefonoTag);

            XmlElement correoTag = xml.CreateElement("Correo");
            correoTag.InnerText = correo;
            elemento.AppendChild(correoTag);

            xml.Save(ruta);
            
            return "Contacto guardado...";
        }


        [WebMethod(Description = "Obtiene un listado de contactos")]
        public string ObtenerContactos()
        {
            string ruta = @"c:\users\omar félix vázquez\documents\visual studio 2010\Projects\Practica1\Servicio\Contactos.xml";
            XmlDataDocument xml = new XmlDataDocument();
            xml.Load(ruta);
            return xml.InnerXml;
        }
    }
}
