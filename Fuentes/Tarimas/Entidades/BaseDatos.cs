using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace EntidadesTarima
{
   public class BaseDatos
    {

        private string cadenaConexionInformacion;
        private string cadenaConexionEYE;
        private string cadenaConexionCatalogo;
        public static SqlConnection conexionInformacion = new SqlConnection();
        public static SqlConnection conexionEYE = new SqlConnection();
        public static SqlConnection conexionCatalogo = new SqlConnection();
        public string CadenaConexionInformacion
        {
            get { return cadenaConexionInformacion; }
            set { cadenaConexionInformacion = value; }
        }
        public string CadenaConexionEYE
        {
            get { return cadenaConexionEYE; }
            set { cadenaConexionEYE = value; }
        }
        public string CadenaConexionCatalogo
        {
            get { return cadenaConexionCatalogo; }
            set { cadenaConexionCatalogo = value; }
        }       

        public void AbrirConexionInformacion()
        {

            this.CadenaConexionInformacion = string.Format("Data Source=.\\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30", this.CadenaConexionInformacion);
            conexionInformacion.ConnectionString = this.CadenaConexionInformacion;

        }

        public void AbrirConexionEYE()
        {

            this.CadenaConexionEYE = string.Format("Data Source=.\\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30", this.CadenaConexionEYE);
            conexionEYE.ConnectionString = this.CadenaConexionEYE;

        }

        public void AbrirConexionCatalogo()
        {

            this.CadenaConexionCatalogo = string.Format("Data Source=.\\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30", this.CadenaConexionCatalogo);
            conexionCatalogo.ConnectionString = this.CadenaConexionCatalogo;

        }
        
    }
    
}
