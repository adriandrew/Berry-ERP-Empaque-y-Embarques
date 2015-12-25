using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Entidades
{
   public class BaseDatos
    {

        private string cadenaConexionPrincipal;
        private string cadenaConexionEmpresa;
        public static SqlConnection conexionPrincipal = new SqlConnection();
        public static SqlConnection conexionEmpresa = new SqlConnection();
        //public static SqlConnection conexionPrincipal = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionPrincipal"].ConnectionString);

        public string CadenaConexionPrincipal
        {
            get { return cadenaConexionPrincipal; }
            set { cadenaConexionPrincipal = value; }
        }
        public string CadenaConexionEmpresa
        {
            get { return cadenaConexionEmpresa; }
            set { cadenaConexionEmpresa = value; }
        }
              
        public void AbrirConexionPrincipal()
        {

            this.CadenaConexionPrincipal = string.Format("Data Source=.\\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30", this.CadenaConexionPrincipal);
            conexionPrincipal.ConnectionString = this.CadenaConexionPrincipal;

        }

        public void AbrirConexionEmpresa()
        {

            this.CadenaConexionEmpresa = string.Format("Data Source=.\\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30", this.CadenaConexionEmpresa);
            conexionEmpresa.ConnectionString = this.CadenaConexionEmpresa;

        }
        
    }
    
}
