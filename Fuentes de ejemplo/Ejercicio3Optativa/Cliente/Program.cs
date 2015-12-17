using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace ClienteConsola
{
    class Program
    {
        static void Main(string[] args)  {

          /*  Ciudad ciudad = new Ciudad(4);
            
            //ciudad.Pais = "México";
            //ciudad.Estado = "29-Sonora";
            //ciudad.Localidad = "Guaymas- Colinas";
            //ciudad.Agregar();
            
            Ciudad ciudad2 = new Ciudad(5);
            
            //ciudad2.Pais = "México";
            //ciudad2.Estado = "29-Sonora";
            //ciudad2.Localidad = "Hermosillo";
            //ciudad2.Agregar();


            Vuelo vuelo = new Vuelo();
            
            vuelo.NoAvion = 666;
            vuelo.Origen = ciudad;
            vuelo.Destino = ciudad2;
            vuelo.Fecha = DateTime.Now;
            vuelo.Agregar();*/

            /*Empleado emp = new Empleado();
            emp.Nombre = "OmarFLX";
            emp.Direccion = "Colinas,Guaymas";
            emp.Telefono = "123456";
            emp.Nss ="111111-2222222";
            emp.Rfc = "FEVO123456";
            emp.Usuario = "Omar";
            emp.Contrasena = "FlxVz";
            emp.Id=1;
            emp.Eliminar();*/


            Cliente cliente = new Cliente();
           /* cliente.Nombre = "Omar";
            cliente.Direccion = "Colinas";
            cliente.Telefono = "123345";
            cliente.Nss = "123";
            cliente.Rfc = "lalal0a";
            cliente.Usuario = "Omar";
            cliente.Contrasena = "alo";*/
            cliente.Id = 1;
           /* DatosBancarios db = new DatosBancarios();
           db.NoTarjeta = "120";
            db.CodigoSeguridad = "0812";
            db.Vigencia = "120";
            db.Direccion = "lala";
            cliente.DatosBancarios = db;*/
            //cliente.Eliminar();

            Reservacion r = new Reservacion();
            r.Tipo = Tipo.Sencillo;
            r.Estado = Estado.Activo;
            r.Total = 1300;
            r.Fecha = DateTime.Now;
            r.Cliente = new Cliente(2);
            r.Vuelo = new Vuelo(2);
            r.Reservar();
        }
    }
}
