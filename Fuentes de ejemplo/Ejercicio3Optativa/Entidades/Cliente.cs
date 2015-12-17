using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entidades
{
    public class Cliente : IUsuario
    {
        public Cliente() { }
        public Cliente(int _id) {
            this.id = _id;
        }
        private DatosBancarios datosBancarios;

        public DatosBancarios DatosBancarios
        {
            get { return datosBancarios; }
            set { datosBancarios = value; }
        }
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private string usuario;
        private string contrasena;
        private string nss;
        private string rfc;
     
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

      

        public string Nss
        {
            get { return nss; }
            set { nss = value; }
        }
       

        public string Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }

        public void Agregar()
        {
            try {
                string sql = "INSERT INTO Cliente VALUES(@nombre,@direccion,@telefono,@nss,@rfc,@usuario,@contrasena); INSERT INTO DatosBancarios VALUES(SCOPE_IDENTITY(), @noTarjeta, @codigoSeguridad, @vigencia, @direccionTarjeta)";
                SqlCommand cmm = new SqlCommand(sql,BaseDatos.conn);
                cmm.Parameters.AddWithValue("@nombre", this.Nombre);
                cmm.Parameters.AddWithValue("@direccion", this.Direccion);
                cmm.Parameters.AddWithValue("@telefono", this.Telefono);
                cmm.Parameters.AddWithValue("@nss", this.Nss);
                cmm.Parameters.AddWithValue("@rfc",this.Rfc);
                cmm.Parameters.AddWithValue("@usuario", this.Usuario);
                cmm.Parameters.AddWithValue("@contrasena", this.Contrasena);
                cmm.Parameters.AddWithValue("@noTarjeta", this.DatosBancarios.NoTarjeta);
                cmm.Parameters.AddWithValue("@codigoSeguridad", this.DatosBancarios.CodigoSeguridad);
                cmm.Parameters.AddWithValue("@vigencia", this.DatosBancarios.Vigencia);
                cmm.Parameters.AddWithValue("@direccionTarjeta", this.DatosBancarios.Direccion);
                BaseDatos.conn.Open();
                cmm.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            
            catch(Exception ex) {
                throw ex;
            }
            
        }

        public void Editar()
        {
            string sql = "Update Cliente SET nombre = @nombre,direccion = @direccion,telefono = @telefono,nss = @nss,rfc = @rfc,usuario = @usuario,contrasena = @contrasena WHERE id=@id; UPDATE DatosBancarios SET noTarjeta = @noTarjeta,codigoSeguridad = @codigoSeguridad,vigencia = @vigencia,direccion = @direccionTarjeta WHERE idCliente=@id";
            SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
            cmm.Parameters.AddWithValue("@nombre", this.Nombre);
            cmm.Parameters.AddWithValue("@direccion", this.Direccion);
            cmm.Parameters.AddWithValue("@telefono", this.Telefono);
            cmm.Parameters.AddWithValue("@nss", this.Nss);
            cmm.Parameters.AddWithValue("@rfc", this.Rfc);
            cmm.Parameters.AddWithValue("@usuario", this.Usuario);
            cmm.Parameters.AddWithValue("@contrasena", this.Contrasena);
            cmm.Parameters.AddWithValue("@noTarjeta", this.DatosBancarios.NoTarjeta);
            cmm.Parameters.AddWithValue("@codigoSeguridad", this.DatosBancarios.CodigoSeguridad);
            cmm.Parameters.AddWithValue("@vigencia", this.DatosBancarios.Vigencia);
            cmm.Parameters.AddWithValue("@direccionTarjeta", this.DatosBancarios.Direccion);
            cmm.Parameters.AddWithValue("@id", this.Id);
            BaseDatos.conn.Open();
            cmm.ExecuteNonQuery();
            BaseDatos.conn.Close();

          
        }

        public void Eliminar()
        {
            string sql = "DELETE FROM Cliente WHERE id=@id; DELETE FROM DatosBancarios WHERE id=@id";
            SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
            cmm.Parameters.AddWithValue("@id",this.id);
            BaseDatos.conn.Open();
            cmm.ExecuteNonQuery();
            BaseDatos.conn.Close();


        }
    }
}
