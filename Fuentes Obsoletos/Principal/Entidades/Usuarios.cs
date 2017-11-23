using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Usuarios
    {

        private int empresa;
        private int numero;
        private string nombre;
        private string contrasena;
        private int nivel;
        private string acceso;

        public int Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
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
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
        public string Acceso
        {
            get { return acceso; }
            set { acceso = value; }
        }

        public void Guardar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "INSERT INTO Usuarios VALUES (@empresa, @numero, @nombre, @contrasena, @nivel, @acceso)";
                comando.Parameters.AddWithValue("@empresa", this.Empresa);
                comando.Parameters.AddWithValue("@numero", this.Numero);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@contrasena", this.Contrasena);
                comando.Parameters.AddWithValue("@nivel", this.Nivel);
                comando.Parameters.AddWithValue("@acceso", this.Acceso);
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public void Editar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "UPDATE Usuarios SET Nombre=@nombre, Contrasena=@contrasena, Nivel=@nivel, Acceso=@acceso WHERE Empresa=@empresa AND Numero=@numero";
                comando.Parameters.AddWithValue("@empresa", this.Empresa);
                comando.Parameters.AddWithValue("@numero", this.Numero);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@contrasena", this.Contrasena);
                comando.Parameters.AddWithValue("@nivel", this.Nivel);
                comando.Parameters.AddWithValue("@acceso", this.Acceso);
                BaseDatos.conexionInformacion.Close();
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public void Eliminar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "DELETE FROM Usuarios WHERE Empresa=@empresa AND Numero=@numero";
                comando.Parameters.AddWithValue("@empresa", this.Empresa);
                comando.Parameters.AddWithValue("@numero", this.Numero);                
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public string ObtenerPorNombre()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Usuarios WHERE Empresa=@empresa AND Nombre=@nombre";
                comando.Parameters.AddWithValue("@empresa", this.Empresa);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    this.Empresa = Convert.ToInt32(dataReader["empresa"].ToString());
                    this.Numero = Convert.ToInt32(dataReader["numero"].ToString());
                    this.Nombre = dataReader["nombre"].ToString();
                    this.Contrasena = dataReader["contrasena"].ToString();
                    this.Nivel = Convert.ToInt32(dataReader["nivel"].ToString());
                    this.Acceso = dataReader["acceso"].ToString();
                }
                if (!dataReader.HasRows)
                {
                    return string.Empty + "|" + string.Empty + "|" + string.Empty + "|" + string.Empty + "|" + string.Empty + "|" + string.Empty;    
                }
                BaseDatos.conexionInformacion.Close();                
                return this.Empresa + "|" + this.Numero + "|" + this.Nombre + "|" + this.Contrasena + "|" + this.Nivel + "|" + this.Acceso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public bool ValidarPorNumero()
        {

            try
            {
                bool resultado = false;
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Usuarios WHERE Empresa=@empresa AND Numero=@numero";
                comando.Parameters.AddWithValue("@empresa", this.Empresa);
                comando.Parameters.AddWithValue("@numero", this.Numero);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }                
                BaseDatos.conexionInformacion.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public List<Usuarios> ObtenerListadoDeEmpresa()
        {

            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Usuarios WHERE Empresa=@empresa";
                comando.Parameters.AddWithValue("@empresa", this.Empresa);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Usuarios usuarios;
                while (dataReader.Read())
                {
                    usuarios = new Usuarios();
                    usuarios.Empresa = Convert.ToInt32(dataReader["empresa"].ToString());
                    usuarios.Numero = Convert.ToInt32(dataReader["numero"].ToString());
                    usuarios.Nombre = dataReader["nombre"].ToString();
                    usuarios.Contrasena = dataReader["contrasena"].ToString();
                    usuarios.Nivel = Convert.ToInt32(dataReader["nivel"].ToString());
                    usuarios.Acceso = dataReader["acceso"].ToString();
                    lista.Add(usuarios);
                }
                BaseDatos.conexionInformacion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public List<Usuarios> ObtenerListado()
        {

            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Usuarios";
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Usuarios usuarios;
                while (dataReader.Read())
                {
                    usuarios = new Usuarios();
                    usuarios.Empresa = Convert.ToInt32(dataReader["empresa"].ToString());
                    usuarios.Numero = Convert.ToInt32(dataReader["numero"].ToString());
                    usuarios.Nombre = dataReader["nombre"].ToString();
                    usuarios.Contrasena = dataReader["contrasena"].ToString();
                    usuarios.Nivel = Convert.ToInt32(dataReader["nivel"].ToString());
                    usuarios.Acceso = dataReader["acceso"].ToString();
                    lista.Add(usuarios);
                }
                BaseDatos.conexionInformacion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

    }
}
