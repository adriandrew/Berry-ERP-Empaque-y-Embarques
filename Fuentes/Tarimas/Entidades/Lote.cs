using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EntidadesTarima
{
    public class Lote
    {

        private int id;
        private string nombre;
        private int idEmpresa;
        private int idCampo;
        private int idProducto;
        private int idVariedad;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        public int IdCampo
        {
            get { return idCampo; }
            set { idCampo = value; }
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

        public void Guardar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "INSERT INTO Lote VALUES (@id, @nombre, @idEmpresa, @idCampo, @idProducto, @idVariedad)";
                comando.Parameters.AddWithValue("@id", this.Id);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idCampo", this.IdCampo);
                comando.Parameters.AddWithValue("@idProducto", this.IdProducto);
                comando.Parameters.AddWithValue("@idVariedad", this.IdVariedad);
                BaseDatos.conexionCatalogo.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionCatalogo.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionCatalogo.Close();
            }

        }

        public void Editar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "UPDATE Lote SET Id=@id, Nombre=@nombre, IdEmpresa=@idEmpresa, IdCampo=@idCampo, IdProducto=@idProducto, IdVariedad=@idVariedad";
                comando.Parameters.AddWithValue("@id", this.Id);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idCampo", this.IdCampo);
                comando.Parameters.AddWithValue("@idProducto", this.IdProducto);
                comando.Parameters.AddWithValue("@idVariedad", this.IdVariedad);
                BaseDatos.conexionCatalogo.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionCatalogo.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionCatalogo.Close();
            }

        }

        public void Eliminar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "DELETE FROM Lote WHERE Id=@id AND IdEmpresa=@idEmpresa AND IdCampo=@idCampo";
                comando.Parameters.AddWithValue("@id", this.Id);
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idCampo", this.IdCampo);
                BaseDatos.conexionCatalogo.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionCatalogo.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionCatalogo.Close();
            }

        }

        public List<Lote> ObtenerListado()
        {

            List<Lote> lista = new List<Lote>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "SELECT * FROM Lote";
                BaseDatos.conexionCatalogo.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Lote productor;
                while (dataReader.Read())
                {
                    productor = new Lote();
                    productor.Id = Convert.ToInt32(dataReader["Id"]);
                    productor.Nombre = dataReader["Nombre"].ToString();
                    productor.IdEmpresa = Convert.ToInt32(dataReader["IdEmpresa"].ToString());
                    productor.IdCampo = Convert.ToInt32(dataReader["IdCampo"].ToString());
                    productor.IdProducto = Convert.ToInt32(dataReader["IdProducto"].ToString());
                    productor.IdVariedad = Convert.ToInt32(dataReader["IdVariedad"]);                     
                    lista.Add(productor);
                }
                BaseDatos.conexionCatalogo.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionCatalogo.Close();
            }

        }

        public bool ValidarPorId()
        {

            try
            {
                bool resultado = false;
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "SELECT * FROM Lote WHERE Id=@id AND IdEmpresa=@idEmpresa AND IdCampo=@idCampo";
                comando.Parameters.AddWithValue("@id", this.Id);
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@idCampo", this.IdCampo);
                BaseDatos.conexionCatalogo.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                    resultado = true;
                else
                    resultado = false;
                BaseDatos.conexionCatalogo.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionCatalogo.Close();
            }

        }

    }
}
