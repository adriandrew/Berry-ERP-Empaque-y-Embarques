using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public struct DatosBancarios
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int idCliente;

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        private string noTarjeta;

        public string NoTarjeta
        {
            get { return noTarjeta; }
            set { noTarjeta = value; }
        }
        private string codigoSeguridad;

        public string CodigoSeguridad
        {
            get { return codigoSeguridad; }
            set { codigoSeguridad = value; }
        }
        private string vigencia;

        public string Vigencia
        {
            get { return vigencia; }
            set { vigencia = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
    }
}
