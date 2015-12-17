using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class Principal : Form
    {

        Entidades.Usuarios usuarios = new Entidades.Usuarios();
        Entidades.Empresas empresas = new Entidades.Empresas();
        Entidades.BaseDatos baseDatos = new Entidades.BaseDatos();
        Logica.DatosEmpresa datosEmpresa = new Logica.DatosEmpresa();
        public int numeroEmpresa;
            
        #region Eventos

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            Centrar();
            AsignarToopltip();
            AsignarFocos();
            ConfigurarConexiones();

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            ValidarSesion();

        }

        private void btnMostrarOpciones_Click(object sender, EventArgs e)
        {

            if (this.panelOpciones.Visible == false)
            {
                this.panelOpciones.Visible = true;
                this.Height = panelContenido.Height + 30;
                this.Width = panelContenido.Width + panelOpciones.Width + 10;
            }
            else
            {
                this.panelOpciones.Visible = false;
                this.Height = panelContenido.Height + 30;
                this.Width = panelContenido.Width + 10;
            }

        }
       
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(this.txtUsuario.Text))
                { 
                    this.txtContraseña.Focus();                
                }            
            }
           
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(this.txtContraseña.Text))
                {
                    this.btnIniciarSesion.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.txtUsuario.Focus();
            }

        }

        private void btnCambiarEmpresa_Click(object sender, EventArgs e)
        {

            this.Hide();            
            new AdministrarEmpresas().Show();

        }

        private void Principal_Shown(object sender, EventArgs e)
        {

            this.txtUsuario.Focus();

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();            

        }

        #endregion

        #region Metodos Privados

        private void ValidarSesion()
        { 
            
            // Falta agregar lo de la empresa.
            if (!string.IsNullOrEmpty(this.txtUsuario.Text) && !string.IsNullOrEmpty(this.txtContraseña.Text))
            {

                if ((txtUsuario.Text.ToUpper().Equals("Admin".ToUpper())) && (txtContraseña.Text.Equals("@berry")))
                {
                    this.Hide();
                    new PanelControl().Show();
                }
                else
                {
                    usuarios.Nombre = this.txtUsuario.Text;
                    usuarios.Empresa = datosEmpresa.Numero;
                    string[] datos = usuarios.ObtenerPorNombre().Split('|');
                    if (this.txtContraseña.Text.Equals(datos[3]))
                    {
                        this.Close();
                    }
                    else
                    {
                        if (datos[1].Equals(string.Empty))
                        {
                            MessageBox.Show("Usuario inexistente en esta empresa.", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtUsuario.Text = string.Empty;
                            this.txtContraseña.Text = string.Empty;
                            this.txtUsuario.Focus();
                        }
                        else
                        {
                            this.txtContraseña.Text = string.Empty;
                            this.txtContraseña.Focus();
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Faltan datos.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
            }

        }

        private void Centrar()
        {
            
            this.CenterToScreen();

        }

        private void AsignarToopltip()
        {

            ToolTip tp = new ToolTip();
            tp.AutoPopDelay = 5000;
            tp.InitialDelay = 0;
            tp.ReshowDelay = 100;
            tp.ShowAlways = true;
            tp.SetToolTip(this.btnCambiarEmpresa, "Cambiar de Empresa.");
            tp.SetToolTip(this.btnIniciarSesion, "Iniciar Sesión.");
            tp.SetToolTip(this.btnMostrarOpciones, "Mostrar Opciones.");

        }

        private void AsignarFocos()
        {

            this.btnIniciarSesion.Focus();            

        }

        private void ConfigurarConexiones() 
        {

            bool esPrueba = true;
            if (esPrueba)
            {
                baseDatos.CadenaConexionPrincipal = "C:\\Berry\\Informacion.mdf";
            }
            else
            {
                baseDatos.CadenaConexionPrincipal = "|DataDirectory|\\Informacion.mdf";
            }
            baseDatos.AbrirConexionPrincipal();
            if (esPrueba)
            {
                baseDatos.CadenaConexionEmpresa = "C:\\Berry\\BD\\PVE\\EYE.mdf";
            }
            else
            {
                baseDatos.CadenaConexionEmpresa = ConsultarInformacionEmpresa();
            }
            baseDatos.AbrirConexionEmpresa();

        }

        private string ConsultarInformacionEmpresa()
        {

            string[] datos = empresas.ObtenerPredeterminada().Split('|');
            datosEmpresa.Numero = Convert.ToInt32(datos[0]);
            datosEmpresa.Nombre = datos[1];
            datosEmpresa.Descripcion = datos[2];
            datosEmpresa.Domicilio = datos[3];
            datosEmpresa.Localidad = datos[4];
            datosEmpresa.Rfc = datos[5];
            datosEmpresa.Directorio = datos[6];
            datosEmpresa.Logo = datos[7];
            datosEmpresa.Activa = Convert.ToBoolean(datos[8]);
            datosEmpresa.Equipo = datos[9];
            return datosEmpresa.Directorio;

        }
        
        #endregion
                 
    }
}