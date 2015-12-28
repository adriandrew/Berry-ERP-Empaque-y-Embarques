using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaTarima
{
    public class DatosEmpresa
    {

        private int numero;
        private string nombre;
        private string descripcion;
        private string domicilio;
        private string localidad;
        private string rfc;
        private string directorio;
        private string logo;
        private bool activa;
        private string equipo;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }
        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        public string Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }
        public string Directorio
        {
            get { return directorio; }
            set { directorio = value; }
        }
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }
        public bool Activa
        {
            get { return activa; }
            set { activa = value; }
        }
        public string Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }

        public void ObtenerParametrosInformacionEmpresa()
        {
             
            string[] parametros = Environment.GetCommandLineArgs().ToArray();
            if (parametros.Length > 0)
            {
                this.Numero = Convert.ToInt32(parametros[1].Replace("|", " "));
                this.Nombre = parametros[2].Replace("|", " ");
                this.Descripcion = parametros[3].Replace("|", " ");
                this.Domicilio = parametros[4].Replace("|", " ");
                this.Localidad = parametros[5].Replace("|", " ");
                this.Rfc = parametros[6].Replace("|", " ");
                this.Directorio = parametros[7].Replace("|", " ");
                this.Logo = parametros[8].Replace("|", " ");
                this.Activa = true; //Convert.ToBoolean(parametros[9].Replace("|", " "));
                this.Equipo = parametros[10].Replace("|", " ");
            }

        }

        public string[] RetornarParametros()
        {

            string[] parametros = Environment.GetCommandLineArgs().ToArray();
            return parametros;

        }
        
    }
}
