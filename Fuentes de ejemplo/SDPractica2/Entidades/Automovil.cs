using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
namespace Entidades
{
    public class Automovil
    {

        private int id;
        private string marca;
        private string modelo;
        private string anio;
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public void Guardar() {
        try {
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = BaseDatos.conn;
             cmd.CommandText="INSERT INTO tblAutomovil VALUES (@marca, @modelo, @anio, @descripcion)";
             cmd.Parameters.AddWithValue("@marca", this.Marca);
             cmd.Parameters.AddWithValue("@modelo", this.Modelo);
             cmd.Parameters.AddWithValue("@anio", this.Anio);
             cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
             BaseDatos.conn.Close();
             BaseDatos.conn.Open();
             cmd.ExecuteNonQuery();
             BaseDatos.conn.Close();
   
          }
          catch(Exception ex){
                throw ex;
            }
        
        }


        public void Editar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "UPDATE tblAutomovil SET marca=@marca, modelo=@modelo, anio=@anio, descripcion=@descripcion WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", this.Id);
                cmd.Parameters.AddWithValue("@marca", this.Marca);
                cmd.Parameters.AddWithValue("@modelo", this.Modelo);
                cmd.Parameters.AddWithValue("@anio", this.Anio);
                cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                BaseDatos.conn.Close();
                BaseDatos.conn.Open();
                cmd.ExecuteNonQuery();
                BaseDatos.conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void Eliminar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "DELETE FROM tblAutomovil WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conn.Close();
                BaseDatos.conn.Open();
                cmd.ExecuteNonQuery();
                BaseDatos.conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally {

                BaseDatos.conn.Close();
            }

        }


        public string Obtener()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM tblAutomovil WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conn.Close();
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read()){
                    this.Marca = dr["marca"].ToString();
                    this.Modelo = dr["modelo"].ToString();
                    this.Anio = dr["anio"].ToString();
                    this.Descripcion = dr["descripcion"].ToString();
                }
                BaseDatos.conn.Close();
                return this.Marca + "|" + this.Modelo + "|" + this.Anio + "|" + this.Descripcion;

            }
            catch (Exception ex)
            {
                throw ex;
             }
            finally
            {
                BaseDatos.conn.Close();
            }

        }

        public string ObtenerListado()
        {
            List<Automovil> autos = new List<Automovil>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM tblAutomovil";
                BaseDatos.conn.Close();
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Automovil auto = new Automovil();

                while (dr.Read())
                {
                    auto = new Automovil();
                    auto.Id = Convert.ToInt32(dr["id"].ToString());
                    auto.Marca = dr["marca"].ToString();
                    auto.Modelo = dr["modelo"].ToString();
                    auto.Anio = dr["anio"].ToString();
                    auto.Descripcion = dr["descripcion"].ToString();
                    autos.Add(auto);
                }
                BaseDatos.conn.Close();
                XmlDocument xmlDoc = new XmlDocument();
                XPathNavigator nav = xmlDoc.CreateNavigator();
                using (XmlWriter writer = nav.AppendChild()) {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Automovil>), new XmlRootAttribute("Autos"));
                    ser.Serialize(writer, autos);
                }
                return xmlDoc.InnerXml;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conn.Close();
            }

        }


    }
}
