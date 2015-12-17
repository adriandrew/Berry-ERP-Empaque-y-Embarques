using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entidades
{
    public class Ciudad
    {
        public Ciudad(){
        
        }
        public Ciudad(int _id) {
            this.id = _id;
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string pais;

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string localidad;

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public void Agregar()
        {
            try {
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = BaseDatos.conn;
                string sql = "INSERT INTO Ciudad (pais, estado, localidad) VALUES(@pais, @estado, @localidad)";
                cmm.CommandText = sql;
                cmm.Parameters.AddWithValue("@pais", this.Pais);
                cmm.Parameters.AddWithValue("@estado", this.Estado);
                cmm.Parameters.AddWithValue("@localidad", this.Localidad);
                BaseDatos.conn.Open();
                cmm.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Editar()
        {
            try {
                string sql = "UPDATE Ciudad SET pais= @pais, estado = @estado, localidad = @localidad WHERE id=@id";
                SqlCommand cmm = new SqlCommand(sql,BaseDatos.conn);
                cmm.Parameters.AddWithValue("@pais", this.Pais);
                cmm.Parameters.AddWithValue("@estado", this.Estado);
                cmm.Parameters.AddWithValue("@localidad", this.Localidad);
                cmm.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conn.Open();
                cmm.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Eliminar()
        {
            try {
                string sql = "DELETE FROM Ciudad WHERE id = @id";
                SqlCommand cmm = new SqlCommand(sql,BaseDatos.conn);
                cmm.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conn.Open();
                cmm.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
