using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data.SqlClient;

namespace Negocio
{
    [DataContract]
    public class Producto
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string cantidad;

        [DataMember]
        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        
        [DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        
        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

 public void Guardar() {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO tblProducto VALUES(@nombre,@descripcion,@cantidad)";
                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
                BaseDatos.conn.Open();
                cmd.ExecuteNonQuery();
            }finally { 
                BaseDatos.conn.Close(); 
            }
      
        }
 public List<Producto> Listado() {
       List<Producto> lista = new List<Producto>();
       try
       {
           SqlCommand cmd = new SqlCommand();
           cmd.Connection = BaseDatos.conn;
           cmd.CommandText = "SELECT * FROM tblProducto";
           BaseDatos.conn.Open();
           SqlDataReader dr = cmd.ExecuteReader();
           Producto p;
           while (dr.Read())
           {
               p = new Producto();
               p.Id = Convert.ToInt32(dr["id"].ToString());
               p.Nombre = dr["nombre"].ToString();
               p.Descripcion = dr["descripcion"].ToString();
               p.Cantidad = dr["cantidad"].ToString();
               lista.Add(p);
           }

       }finally {
           BaseDatos.conn.Close();
       }
       return lista;
   }

    }
}
