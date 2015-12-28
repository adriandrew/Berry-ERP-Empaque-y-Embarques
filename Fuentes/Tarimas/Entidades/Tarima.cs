using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EntidadesTarima
{
    public class Tarima
    {

        private int id;
        private int idProductor;
        private int idEmbarcador;
        private int idCliente;
        private int idProducto;
        private int idVariedad;
        private int idEnvase;
        private int idTamano;
        private int idEtiqueta;
        private int idLote;
        private int cantidadBultos;
        private DateTime fechaEmpaque;
        private DateTime fechaEmbarque;
        private int idEmbarque;
        private int tipoEmbarque;
        private bool chep;
        private double pesoBultos;
        private int ordenEmbarque;
        private bool sobrante;
        private int orden;
        private bool subidaTrazabilidad;
        private string posicion;
        private int numeroHandHeld;
        private string nombreHandHeld;
        private double temperatura;
        private bool estaEmbarcado;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdProductor
        {
            get { return idProductor; }
            set { idProductor = value; }
        }
        public int IdEmbarcador
        {
            get { return idEmbarcador; }
            set { idEmbarcador = value; }
        }
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        public int IdVariedad
        {
            get { return idVariedad; }
            set { idVariedad = value; }
        }
        public int IdEnvase
        {
            get { return idEnvase; }
            set { idEnvase = value; }
        }
        public int IdTamano
        {
            get { return idTamano; }
            set { idTamano = value; }
        }
        public int IdEtiqueta
        {
            get { return idEtiqueta; }
            set { idEtiqueta = value; }
        }
        public int IdLote
        {
            get { return idLote; }
            set { idLote = value; }
        }
        public int CantidadBultos
        {
            get { return cantidadBultos; }
            set { cantidadBultos = value; }
        }
        public DateTime FechaEmpaque
        {
            get { return fechaEmpaque; }
            set { fechaEmpaque = value; }
        }
        public DateTime FechaEmbarque
        {
            get { return fechaEmbarque; }
            set { fechaEmbarque = value; }
        }
        public int IdEmbarque
        {
            get { return idEmbarque; }
            set { idEmbarque = value; }
        }
        public int TipoEmbarque
        {
            get { return tipoEmbarque; }
            set { tipoEmbarque = value; }
        }
        public bool Chep
        {
            get { return chep; }
            set { chep = value; }
        }
        public double PesoBultos
        {
            get { return pesoBultos; }
            set { pesoBultos = value; }
        }
        public int OrdenEmbarque
        {
            get { return ordenEmbarque; }
            set { ordenEmbarque = value; }
        }
        public bool Sobrante
        {
            get { return sobrante; }
            set { sobrante = value; }
        }
        public int Orden
        {
            get { return orden; }
            set { orden = value; }
        }
        public bool SubidaTrazabilidad
        {
            get { return subidaTrazabilidad; }
            set { subidaTrazabilidad = value; }
        }
        public string Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        public int NumeroHandHeld
        {
            get { return numeroHandHeld; }
            set { numeroHandHeld = value; }
        }
        public string NombreHandHeld
        {
            get { return nombreHandHeld; }
            set { nombreHandHeld = value; }
        }
        public double Temperatura
        {
            get { return temperatura; }
            set { temperatura = value; }
        }
        public bool EstaEmbarcado
        {
            get { return estaEmbarcado; }
            set { estaEmbarcado = value; }
        }

        public void Guardar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionEYE;
                comando.CommandText = "INSERT INTO Tarima VALUES (@id, @idProductor, @idEmbarcador, @idCliente, @idProducto, @idVariedad, @idEnvase, @idTamano, @idEtiqueta, @idLote, @cantidadBultos, @fechaEmpaque, @fechaEmbarque, @idEmbarque, @tipoEmbarque, @chep, @peso, @ordenEmbarque, @sobrante, @orden, @subidaTrazabilidad, @posicion, @numeroHandHeld, @nombreHandHeld, @temperatura, @estaEmbarcado)";
                comando.Parameters.AddWithValue("@id", this.Id);
                comando.Parameters.AddWithValue("@idProductor", this.IdProductor);
                comando.Parameters.AddWithValue("@idEmbarcador", this.IdEmbarcador);
                comando.Parameters.AddWithValue("@idCliente", this.IdCliente);
                comando.Parameters.AddWithValue("@idProducto", this.IdProducto);
                comando.Parameters.AddWithValue("@idVariedad", this.IdVariedad);
                comando.Parameters.AddWithValue("@idEnvase", this.IdEnvase);
                comando.Parameters.AddWithValue("@idTamano", this.IdTamano);
                comando.Parameters.AddWithValue("@idEtiqueta", this.IdEtiqueta);
                comando.Parameters.AddWithValue("@idLote", this.IdLote);
                comando.Parameters.AddWithValue("@cantidadBultos", this.CantidadBultos);
                comando.Parameters.AddWithValue("@fechaEmpaque", this.FechaEmpaque);
                comando.Parameters.AddWithValue("@fechaEmbarque", this.FechaEmbarque);
                comando.Parameters.AddWithValue("@idEmbarque", this.IdEmbarque);
                comando.Parameters.AddWithValue("@tipoEmbarque", this.TipoEmbarque);
                comando.Parameters.AddWithValue("@chep", this.Chep);
                comando.Parameters.AddWithValue("@peso", this.PesoBultos);
                comando.Parameters.AddWithValue("@ordenEmbarque", this.OrdenEmbarque);
                comando.Parameters.AddWithValue("@sobrante", this.Sobrante);
                comando.Parameters.AddWithValue("@orden", this.Orden);
                comando.Parameters.AddWithValue("@subidaTrazabilidad", this.SubidaTrazabilidad);
                comando.Parameters.AddWithValue("@posicion", this.Posicion);
                comando.Parameters.AddWithValue("@numeroHandHeld", this.NumeroHandHeld);
                comando.Parameters.AddWithValue("@nombreHandHeld", this.NombreHandHeld);
                comando.Parameters.AddWithValue("@temperatura", this.Temperatura);
                comando.Parameters.AddWithValue("@estaEmbarcado", this.EstaEmbarcado);
                BaseDatos.conexionEYE.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionEYE.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionEYE.Close();
            }

        }

        public int ObtenerIdTarimaConsecutiva()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionEYE;
                comando.CommandText = "SELECT MAX(Id) AS Id FROM Tarima WHERE IdProductor=@idProductor";
                comando.Parameters.AddWithValue("@idProductor", this.IdProductor);
                BaseDatos.conexionEYE.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                if (!dataReader.HasRows)
                {
                    return 1;
                }
                while (dataReader.Read())
                {
                    if (string.IsNullOrEmpty(dataReader["Id"].ToString()))
                    {
                        this.id = 1;
                    }
                    else
                    {
                        this.Id = Convert.ToInt32(dataReader["Id"].ToString());                    
                    }
                }                
                BaseDatos.conexionEYE.Close();
                return this.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionEYE.Close();
            }

        }
        
    }
}
     
