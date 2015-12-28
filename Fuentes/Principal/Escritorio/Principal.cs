using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        ProcessStartInfo ejecutarProgramaPrincipal = new ProcessStartInfo();
        public int numeroEmpresa;
        public bool ocupaParametros;
            
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
            ConsultarInformacionEmpresa();
            this.ocupaParametros = false;
            CargarTitulosEmpresa();

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.ocupaParametros)
            {
                ejecutarProgramaPrincipal.UseShellExecute = true;
                ejecutarProgramaPrincipal.FileName = "Tarimas.exe";
                ejecutarProgramaPrincipal.WorkingDirectory = Directory.GetCurrentDirectory();
                ejecutarProgramaPrincipal.Arguments = datosEmpresa.Numero.ToString().Trim().Replace(" ", "|") + " " + datosEmpresa.Nombre.Trim().Replace(" ", "|") + " " + datosEmpresa.Descripcion.Trim().Replace(" ", "|") + " " + datosEmpresa.Domicilio.Trim().Replace(" ", "|") + " " + datosEmpresa.Localidad.Trim().Replace(" ", "|") + " " + datosEmpresa.Rfc.Trim().Replace(" ", "|") + " " + datosEmpresa.Directorio.Trim().Replace(" ", "|") + " " + datosEmpresa.Logo.Trim().Replace(" ", "|") + " " + datosEmpresa.Activa.ToString().Trim().Replace(" ", "|") + " " + datosEmpresa.Equipo.Trim().Replace(" ", "|") + " " + "Aquí terminan ;)";
                //MessageBox.Show(ejecutarProgramaPrincipal.Arguments);
                try
                {
                    Process.Start(ejecutarProgramaPrincipal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede abrir el programa principal en la ruta : " + ejecutarProgramaPrincipal.WorkingDirectory + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                Application.Exit();
            }

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
                        this.ocupaParametros = true;
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

            bool esPrueba = false;
            if (esPrueba)
            {
                baseDatos.CadenaConexionInformacion = "C:\\Berry\\Informacion.mdf";
            }
            else
            {
                baseDatos.CadenaConexionInformacion = "|DataDirectory|\\Informacion.mdf";
            }
            baseDatos.AbrirConexionInformacion();            

        }

        private void ConsultarInformacionEmpresa()
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

        }

        private void CargarTitulosEmpresa()
        {
            this.Text += ": " + datosEmpresa.Numero + " - " + datosEmpresa.Nombre;
        }
        
        #endregion
                 
    }
}