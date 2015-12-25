using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Empresas
    {

        private int numero;
        private string nombre;
        private string descripcion;
        private string domicilio;
        private string localidad;
        private string rfc;
        private string directorio;
        private string logo;
        private bool activa;
        private string equipo;
        
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }
        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        public string Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }
        public string Directorio
        {
            get { return directorio; }
            set { directorio = value; }
        }
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }
        public bool Activa
        {
            get { return activa; }
            set { activa = value; }
        }
        public string Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }

        public void Guardar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionPrincipal;
                comando.CommandText = "INSERT INTO Empresas VALUES (@numero, @nombre, @descripcion, @domicilio, @localidad, @rfc, @directorio, @logo, @activa, @equipo)";                
                comando.Parameters.AddWithValue("@numero", this.Numero);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@descripcion", this.Descripcion);
                comando.Parameters.AddWithValue("@domicilio", this.Domicilio);
                comando.Parameters.AddWithValue("@localidad", this.Localidad);
                comando.Parameters.AddWithValue("@rfc", this.Rfc);
                comando.Parameters.AddWithValue("@directorio", this.Directorio);
                comando.Parameters.AddWithValue("@logo", this.Logo);
                comando.Parameters.AddWithValue("@activa", this.Activa);
                comando.Parameters.AddWithValue("@equipo", this.Equipo);
                BaseDatos.conexionPrincipal.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionPrincipal.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionPrincipal.Close();
            }

        }

        public void Editar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionPrincipal;
                comando.CommandText = "UPDATE Empresas SET Numero=@numero, Nombre=@nombre, Descripcion=@descripcion, Domicilio=@domicilio, Localidad=@localidad, Rfc=@rfc, Directorio=@directorio, Logo=@logo, Activa=@activa, Equipo=@equipo WHERE Numero=@numero";                
                comando.Parameters.AddWithValue("@numero", this.Numero);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@descripcion", this.Descripcion);
                comando.Parameters.AddWithValue("@domicilio", this.Domicilio);
                comando.Parameters.AddWithValue("@localidad", this.Localidad);
                comando.Parameters.AddWithValue("@rfc", this.Rfc);
                comando.Parameters.AddWithValue("@directorio", this.Directorio);
                comando.Parameters.AddWithValue("@logo", this.Logo);
                comando.Parameters.AddWithValue("@activa", this.Activa);
                comando.Parameters.AddWithValue("@equipo", this.Equipo);                
                BaseDatos.conexionPrincipal.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionPrincipal.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionPrincipal.Close();
            }

        }

        public void Eliminar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionPrincipal;
                comando.CommandText = "DELETE FROM Empresas WHERE Numero=@numero";                
                comando.Parameters.AddWithValue("@numero", this.Numero);
                BaseDatos.conexionPrincipal.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionPrincipal.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionPrincipal.Close();
            }

        }

        public bool ValidarPorNumero()
        {

            try
            {
                bool resultado = false;
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionPrincipal;
                comando.CommandText = "SELECT * FROM Empresas WHERE Numero=@numero";                
                comando.Parameters.AddWithValue("@numero", this.Numero);
                BaseDatos.conexionPrincipal.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
                BaseDatos.conexionPrincipal.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionPrincipal.Close();
            }

        }
        
        public List<Empresas> ObtenerListado()
        {

            List<Empresas> lista = new List<Empresas>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionPrincipal;
                comando.CommandText = "SELECT * FROM Empresas";
                BaseDatos.conexionPrincipal.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Empresas empresas;
                while (dataReader.Read())
                {
                    empresas = new Empresas();
                    empresas.Numero = Convert.ToInt32(dataReader["numero"].ToString());
                    empresas.Nombre = dataReader["nombre"].ToString();
                    empresas.Descripcion = dataReader["descripcion"].ToString();
                    empresas.Domicilio = dataReader["domicilio"].ToString();
                    empresas.Localidad = dataReader["localidad"].ToString();
                    empresas.Rfc = dataReader["rfc"].ToString();
                    empresas.Directorio = dataReader["directorio"].ToString();
                    empresas.Logo = dataReader["logo"].ToString();
                    empresas.Activa = Convert.ToBoolean(dataReader["activa"].ToString());
                    empresas.Equipo = dataReader["equipo"].ToString();
                    lista.Add(empresas);
                }
                BaseDatos.conexionPrincipal.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionPrincipal.Close();
            }

        }

        public string ObtenerPredeterminada()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionPrincipal;
                comando.CommandText = "SELECT * FROM Empresas WHERE Activa='TRUE'";
                BaseDatos.conexionPrincipal.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {                    
                    this.Numero = Convert.ToInt32(dataReader["numero"].ToString());
                    this.Nombre = dataReader["nombre"].ToString();
                    this.Descripcion =  dataReader["descripcion"].ToString();
                    this.Domicilio = dataReader["domicilio"].ToString();
                    this.Localidad = dataReader["localidad"].ToString();
                    this.Rfc = dataReader["rfc"].ToString();
                    this.Directorio = dataReader["directorio"].ToString();
                    this.Logo = dataReader["logo"].ToString();
                    this.Activa = Convert.ToBoolean(dataReader["activa"].ToString());
                    this.Equipo = dataReader["equipo"].ToString();
                }
                BaseDatos.conexionPrincipal.Close();
                return this.Numero + "|" + this.Nombre + "|" + this.Descripcion + "|" + this.Domicilio + "|" + this.Localidad + "|" + this.Rfc + "|" + this.Directorio + "|" + this.Logo + "|" + this.Activa + "|" + this.Equipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionPrincipal.Close();
            }

        }

        public void Predeterminar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionPrincipal;
                comando.CommandText = "UPDATE Empresas SET Activa='TRUE' WHERE Numero=@numero";
                comando.Parameters.AddWithValue("@numero", this.Numero);
                BaseDatos.conexionPrincipal.Open();
                comando.ExecuteNonQuery();
                comando.CommandText = "UPDATE Empresas SET Activa='FALSE' WHERE Numero<>@numero";
                comando.ExecuteNonQuery();               
                BaseDatos.conexionPrincipal.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionPrincipal.Close();
            }

        }

    }
}
