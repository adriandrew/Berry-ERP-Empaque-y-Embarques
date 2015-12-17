using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entidades
{
    public class Vuelo
    {
         public Vuelo() { }
        public Vuelo(int _id) {
            this.id = _id;
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int noAvion;

        public int NoAvion
        {
            get { return noAvion; }
            set { noAvion = value; }
        }
        private Ciudad origen;

        public Ciudad Origen
        {
            get { return origen; }
            set { origen = value; }
        }
        private Ciudad destino;

        public Ciudad Destino
        {
            get { return destino; }
            set { destino = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public void Agregar()
        {
            try{
                string sql = "INSERT INTO Vuelo (noAvion, origen, destino, fecha) VALUES (@noAvion, @origen, @destino, @fecha)";
                SqlCommand cmm = new SqlCommand(sql,BaseDatos.conn);
                cmm.Parameters.AddWithValue("@noAvion",this.NoAvion);
                cmm.Parameters.AddWithValue("@origen", this.Origen.Id);
                cmm.Parameters.AddWithValue("@destino", this.Destino.Id);
                cmm.Parameters.AddWithValue("@fecha", this.Fecha);
                BaseDatos.conn.Open();
                cmm.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch(Exception ex){ throw ex;}
        }

        public void Editar()
        {
            string sql = "UPDATE Vuelo SET noAvion=@noAvion, origen=@origen, destino=@destino, fecha=@fecha WHERE id=@id";
            SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
            cmm.Parameters.AddWithValue("@noAvion", this.NoAvion);
            cmm.Parameters.AddWithValue("@origen", this.Origen.Id);
            cmm.Parameters.AddWithValue("@destino", this.Destino.Id);
            cmm.Parameters.AddWithValue("@fecha", this.Fecha);
            BaseDatos.conn.Open();
            cmm.ExecuteNonQuery();
            BaseDatos.conn.Close();
        }

        public void Eliminar()
        {
            string sql = "DELETE FROM Ciudad WHERE id=@id";
            SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
            BaseDatos.conn.Open();
            cmm.ExecuteNonQuery();
            BaseDatos.conn.Close();
        }
    }
}
