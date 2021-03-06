﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EntidadesTarima
{
    public class Productor
    {

        private int id;
        private string nombre;
        private string domicilio;
        private string ciudad;
        private string estado;
        private int codigoPostal;
        private string rfc;
        private int telefono;
        private string representante;
        private int fda;
        private int gs1;
        private int immex;
        private string claveTomate;        
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
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public int CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }
        public string Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Representante
        {
            get { return representante; }
            set { representante = value; }
        }
        public int Fda
        {
            get { return fda; }
            set { fda = value; }
        }
        public int Gs1
        {
            get { return gs1; }
            set { gs1 = value; }
        }
        public int Immex
        {
            get { return immex; }
            set { immex = value; }
        }
        public string ClaveTomate
        {
            get { return claveTomate; }
            set { claveTomate = value; }
        }

        public void Guardar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "INSERT INTO Productor VALUES (@id, @nombre, @domicilio, @ciudad, @estado, @codigoPostal, @rfc, @telefono, @representante, @fda, @gs1, @immex, @claveTomate)";
                comando.Parameters.AddWithValue("@id", this.Id);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@domicilio", this.Domicilio);
                comando.Parameters.AddWithValue("@ciudad", this.Ciudad);
                comando.Parameters.AddWithValue("@estado", this.Estado);
                comando.Parameters.AddWithValue("@codigoPostal", this.CodigoPostal);
                comando.Parameters.AddWithValue("@rfc", this.Rfc);
                comando.Parameters.AddWithValue("@telefono", this.Telefono);
                comando.Parameters.AddWithValue("@representante", this.Representante);
                comando.Parameters.AddWithValue("@fda", this.Fda);
                comando.Parameters.AddWithValue("@gs1", this.Gs1);
                comando.Parameters.AddWithValue("@immex", this.Immex);
                comando.Parameters.AddWithValue("@claveTomate", this.ClaveTomate); 
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
                comando.CommandText = "UPDATE Productor SET Id=@id, Nombre=@nombre, Domicilio=@domicilio, Ciudad=@ciudad, Estado=@estado, CodigoPostal=@codigoPostal, Rfc=@rfc, Telefono=@telefono, Representante=@representante, Fda=@fda, Gs1=@gs1, Immex=@immex, ClaveTomate=@claveTomate";
                comando.Parameters.AddWithValue("@id", this.Id);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@domicilio", this.Domicilio);
                comando.Parameters.AddWithValue("@ciudad", this.Ciudad);
                comando.Parameters.AddWithValue("@estado", this.Estado);
                comando.Parameters.AddWithValue("@codigoPostal", this.CodigoPostal);
                comando.Parameters.AddWithValue("@rfc", this.Rfc);
                comando.Parameters.AddWithValue("@telefono", this.Telefono);
                comando.Parameters.AddWithValue("@representante", this.Representante);
                comando.Parameters.AddWithValue("@fda", this.Fda);
                comando.Parameters.AddWithValue("@gs1", this.Gs1);
                comando.Parameters.AddWithValue("@immex", this.Immex);
                comando.Parameters.AddWithValue("@claveTomate", this.ClaveTomate); 
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
                comando.CommandText = "DELETE FROM Productor WHERE Id=@id";
                comando.Parameters.AddWithValue("@id", this.Id); 
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

        public List<Productor> ObtenerListado()
        {

            List<Productor> lista = new List<Productor>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionCatalogo;
                comando.CommandText = "SELECT * FROM Productor";                
                BaseDatos.conexionCatalogo.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Productor productor;
                while (dataReader.Read())
                {
                    productor = new Productor();
                    productor.Id = Convert.ToInt32(dataReader["Id"]);
                    productor.Nombre = dataReader["Nombre"].ToString();
                    productor.Domicilio = dataReader["Domicilio"].ToString();
                    productor.Ciudad = dataReader["Ciudad"].ToString();
                    productor.Estado = dataReader["Estado"].ToString();
                    productor.CodigoPostal = Convert.ToInt32(dataReader["CodigoPostal"]);
                    productor.Rfc = dataReader["Rfc"].ToString();
                    productor.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                    productor.Representante = dataReader["Representante"].ToString();
                    productor.Fda = Convert.ToInt32(dataReader["Fda"]);
                    productor.Gs1 = Convert.ToInt32(dataReader["Gs1"]);
                    productor.Immex = Convert.ToInt32(dataReader["Immex"]);
                    productor.ClaveTomate = dataReader["ClaveTomate"].ToString(); 
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
                comando.CommandText = "SELECT * FROM Productor WHERE Id=@id";
                comando.Parameters.AddWithValue("@id", this.Id);                
                BaseDatos.conexionCatalogo.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
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
