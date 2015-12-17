using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entidades
{
    public class Empleado : IUsuario
    {
        private string nss;

        public string Nss
        {
            get { return nss; }
            set { nss = value; }
        }
        private string rfc;

        public string Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        public string Contrasena
        {
            get
            {
                return contrasena;
            }
            set
            {
                contrasena = value;
            }
        }

        public void Agregar()
        {
            string sql = "INSERT INTO Empleado (nombre,direccion,telefono,nss,rfc,usuario,contrasena) VALUES(@nombre,@direccion,@telefono,@nss,@rfc,@usuario,@contrasena)";
            SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
            cmm.Parameters.AddWithValue("@nombre", this.Nombre);
            cmm.Parameters.AddWithValue("@direccion", this.Direccion);
            cmm.Parameters.AddWithValue("@telefono", this.Telefono);
            cmm.Parameters.AddWithValue("@nss", this.Nss);
            cmm.Parameters.AddWithValue("@rfc", this.Rfc);
            cmm.Parameters.AddWithValue("@usuario", this.Usuario);
            cmm.Parameters.AddWithValue("@contrasena", this.Contrasena);
            BaseDatos.conn.Open();
            cmm.ExecuteNonQuery();
            BaseDatos.conn.Close();


        }

        public void Editar()
        {
            string sql = "UPDATE Empleado SET nombre=@nombre,direccion=@direccion,telefono=@telefono,nss=@nss,rfc=@rfc,usuario=@usuario,contrasena=@contrasena WHERE id=@id";
            SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
            cmm.Parameters.AddWithValue("@nombre", this.Nombre);
            cmm.Parameters.AddWithValue("@direccion", this.Direccion);
            cmm.Parameters.AddWithValue("@telefono", this.Telefono);
            cmm.Parameters.AddWithValue("@nss", this.Nss);
            cmm.Parameters.AddWithValue("@rfc", this.Rfc);
            cmm.Parameters.AddWithValue("@usuario", this.Usuario);
            cmm.Parameters.AddWithValue("@contrasena", this.Contrasena);
            cmm.Parameters.AddWithValue("@id", this.Id);
            BaseDatos.conn.Open();
            cmm.ExecuteNonQuery();
            BaseDatos.conn.Close();
            
        }

        public void Eliminar()
        {
            string sql = "DELETE FROM Empleado WHERE id=@id";
            SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
            cmm.Parameters.AddWithValue("@id",this.Id);
            BaseDatos.conn.Open();
            cmm.ExecuteNonQuery();
            BaseDatos.conn.Close();
        }

        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private string usuario;
        private string contrasena;
    }
}
