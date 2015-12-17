using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entidades
{
    public class Reservacion
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private Vuelo vuelo;

        public Vuelo Vuelo
        {
            get { return vuelo; }
            set { vuelo = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }
        private Tipo tipo;

        public Tipo Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private Estado estado;

        public Estado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public void Reservar()
        {
           try {
                string sql = "INSERT INTO Reservacion VALUES(@idCliente,@idVuelo,@fecha,@tipo,@estado,@total)";
                SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
                cmm.Parameters.AddWithValue("@idCliente", this.Cliente.Id);
                cmm.Parameters.AddWithValue("@idVuelo", this.Vuelo.Id);
                cmm.Parameters.AddWithValue("@fecha", this.Fecha);
                cmm.Parameters.AddWithValue("@tipo",((int)this.Tipo).ToString());
                cmm.Parameters.AddWithValue("@estado", ((int)this.Estado).ToString());
                cmm.Parameters.AddWithValue("@total", this.Total.ToString());
                BaseDatos.conn.Open();
                cmm.ExecuteNonQuery();
                BaseDatos.conn.Close();     
            }

           catch(Exception ex) {
                throw ex;
            }
        }

        public void Cancelar()
        {
            string sql = "UPDATE Reservacion SET estado=@estado";
            SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
          
            cmm.Parameters.AddWithValue("@estado", ((int)this.Estado).ToString());
            
            BaseDatos.conn.Open();
            cmm.ExecuteNonQuery();
            BaseDatos.conn.Close(); 
            
        }

        public void Editar()
        {
            throw new System.NotImplementedException();
        }
    }
}
