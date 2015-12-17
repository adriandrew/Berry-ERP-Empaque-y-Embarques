using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioOptativa" en el código, en svc y en el archivo de configuración a la vez.
    public class ServicioOptativa : IServicioOptativa
    {
        public void Agregar(Alumno a){
            a.Agregar();

        }

        public List<Alumno> Listado() {
            return Alumno.Listado();
        
        }
    }

    public class Alumno {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }


        public void Agregar() {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Alumno VALUES(@nombre,@correo)";
            cmd.Parameters.AddWithValue("@nombre",this.Nombre);
            cmd.Parameters.AddWithValue("@correo", this.Correo);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public static List<Alumno> Listado()
        {
            List<Alumno> lista = new List<Alumno>();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tblAlumno";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Alumno a;
            while (dr.Read()) {
                a = new Alumno();
                a.Id = Convert.ToInt32(dr["id"].ToString());
                a.Nombre = dr["nombre"].ToString();
                a.Correo = dr["correo"].ToString();
                lista.Add(a);
            }
            con.Close();
            return lista;
        }
    }
}
