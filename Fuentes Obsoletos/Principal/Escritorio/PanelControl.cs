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
    public partial class PanelControl : Form
    {

        FarPoint.Win.Spread.CellType.TextCellType tipoTexto = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.NumberCellType tipoEntero = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.NumberCellType tipoDoble = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.PercentCellType tipoPorcentaje = new FarPoint.Win.Spread.CellType.PercentCellType();
        FarPoint.Win.Spread.CellType.DateTimeCellType tipoHora = new FarPoint.Win.Spread.CellType.DateTimeCellType();
        Entidades.Empresas empresas = new Entidades.Empresas();
        Entidades.Usuarios usuarios = new Entidades.Usuarios();
        
        #region Eventos

        public PanelControl()
        {
            InitializeComponent();
        }

        private void PanelControl_Load(object sender, EventArgs e)
        {

            Centrar();
            ReiniciarControles();
            ControlarSpread(spAdministrar);

        }
       
        private void rbtnUsuarios_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnUsuarios.Checked)
            {
                CargarEmpresasCombobox();
                CargarUsuarios();
                FormatearSpread();
                FormatearSpreadUsuarios();
            }

        }
        
        private void PanelControl_Shown(object sender, EventArgs e)
        {

            ReiniciarControles();

        }
         
        private void spAdministrar_KeyDown(object sender, KeyEventArgs e)
        {

            // Eliminar.
            if (e.KeyData == Keys.F11)
            {
                if (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
                    if (rbtnUsuarios.Checked)
                    {
                        string empresa = cbEmpresas.SelectedValue.ToString();
                        string numero = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
                        if (!string.IsNullOrEmpty(empresa) && !string.IsNullOrEmpty(numero))
                        {
                            usuarios.Empresa = Logica.Funciones.ValidarNumero(empresa);
                            usuarios.Numero = Logica.Funciones.ValidarNumero(numero);
                            usuarios.Eliminar();
                        }
                    }
                    else if (rbtnEmpresas.Checked)
                    {
                        string numero = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
                        if (!string.IsNullOrEmpty(numero))
                        {                            
                            empresas.Numero = Logica.Funciones.ValidarNumero(numero);
                            empresas.Eliminar();
                        }
                    }
                }
            }
            // Guardar o editar.
            else if (e.KeyData == Keys.Enter)
            {
                if (spAdministrar.ActiveSheet.ActiveColumnIndex == spAdministrar.ActiveSheet.Columns.Count - 1)
                {
                    spAdministrar.ActiveSheet.AddRows(spAdministrar.ActiveSheet.Rows.Count, 1);
                    int fila = spAdministrar.ActiveSheet.ActiveRowIndex;
                    if (rbtnUsuarios.Checked)
                    {
                        string empresa = cbEmpresas.SelectedValue.ToString();
                        string numero = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
                        string nombre = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nombre"].Index].Text;
                        string contrasena = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["contrasena"].Index].Text;
                        string nivel = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nivel"].Index].Text;
                        string acceso = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["acceso"].Index].Text;
                        if (!string.IsNullOrEmpty(empresa) && !string.IsNullOrEmpty(numero) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(contrasena) && !string.IsNullOrEmpty(nivel) && !string.IsNullOrEmpty(acceso))
                        {
                            usuarios.Empresa = Convert.ToInt32(empresa);
                            usuarios.Numero = Convert.ToInt32(numero);
                            bool tieneUsuarios = usuarios.ValidarPorNumero();
                            usuarios.Nombre = nombre;
                            usuarios.Contrasena = contrasena;
                            usuarios.Nivel = Convert.ToInt32(nivel);
                            usuarios.Acceso = acceso;
                            if (!tieneUsuarios)
                            {
                                usuarios.Guardar();
                            }
                            else
                            {
                                usuarios.Editar();
                            }
                        }
                    }
                    else if (rbtnEmpresas.Checked)
                    { 
                        string numero = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["numero"].Index].Text;
                        string nombre = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["nombre"].Index].Text;
                        string descripcion = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["descripcion"].Index].Text;
                        string domicilio = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["domicilio"].Index].Text;
                        string localidad = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["localidad"].Index].Text;
                        string rfc = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["rfc"].Index].Text;
                        string directorio = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["directorio"].Index].Text;
                        string logo = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["logo"].Index].Text;
                        bool activa = Convert.ToBoolean(spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["activa"].Index].Value);
                        string equipo = spAdministrar.ActiveSheet.Cells[fila, spAdministrar.ActiveSheet.Columns["equipo"].Index].Text;
                        if (!string.IsNullOrEmpty(numero) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(descripcion) && !string.IsNullOrEmpty(domicilio) && !string.IsNullOrEmpty(rfc) && !string.IsNullOrEmpty(directorio) && !string.IsNullOrEmpty(logo))
                        {
                            empresas.Numero = Convert.ToInt32(numero);
                            bool tieneEmpresas = empresas.ValidarPorNumero();
                            empresas.Nombre = nombre;
                            empresas.Descripcion = descripcion;
                            empresas.Domicilio = domicilio;
                            empresas.Localidad = localidad;
                            empresas.Rfc = rfc;
                            empresas.Directorio = directorio;
                            empresas.Logo = logo;
                            empresas.Activa = activa;
                            empresas.Equipo = equipo;
                            if (!tieneEmpresas)
                            {
                                empresas.Guardar();
                            }
                            else
                            {
                                empresas.Editar();
                            }
                        }
                    }
                }
            }

        }

        private void PanelControl_FormClosed(object sender, FormClosedEventArgs e)
        {

            new Principal().Show();

        }

        private void rbtnEmpresas_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rbtnEmpresas.Checked)
            {
                CargarEmpresasSpread();
                FormatearSpread();
                FormatearSpreadEmpresas();               
            }

        }

        private void cbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargarUsuarios();
            FormatearSpread();
            FormatearSpreadUsuarios();

        }

        #endregion

        #region Metodos Privados

        private void Centrar()
        {

            this.CenterToScreen();

        }
         
        private void ReiniciarControles() 
        {

            spAdministrar.Visible = false;
            rbtnUsuarios.Checked = false;
            rbtnEmpresas.Checked = false;
            rbtnProgramas.Checked = false;            

        }

        private void FormatearSpread()
        {

            spAdministrar.Visible = true;
            spAdministrar.ActiveSheet.ColumnHeader.Rows[0].Height = 30;
            spAdministrar.ActiveSheet.GrayAreaBackColor = Color.White;
            spAdministrar.Font = new Font("microsoft sans serif", 12, FontStyle.Bold);
            spAdministrar.ActiveSheetIndex = 0;
            tipoEntero.DecimalPlaces = 0;

        }
        
        private void FormatearSpreadUsuarios()
        {
             
            spAdministrar.ActiveSheet.Columns[0].Tag = "empresa";
            spAdministrar.ActiveSheet.Columns[1].Tag = "numero";
            spAdministrar.ActiveSheet.Columns[2].Tag = "nombre";
            spAdministrar.ActiveSheet.Columns[3].Tag = "contrasena";
            spAdministrar.ActiveSheet.Columns[4].Tag = "nivel";
            spAdministrar.ActiveSheet.Columns[5].Tag = "acceso";       
            spAdministrar.ActiveSheet.Columns["empresa"].Width = 220;     
            spAdministrar.ActiveSheet.Columns["numero"].Width = 50;
            spAdministrar.ActiveSheet.Columns["nombre"].Width = 220;
            spAdministrar.ActiveSheet.Columns["contrasena"].Width = 180;
            spAdministrar.ActiveSheet.Columns["nivel"].Width = 80;
            spAdministrar.ActiveSheet.Columns["acceso"].Width = 80;
            spAdministrar.ActiveSheet.Columns["empresa"].CellType = tipoEntero;
            spAdministrar.ActiveSheet.Columns["numero"].CellType = tipoEntero;
            spAdministrar.ActiveSheet.Columns["nombre"].CellType = tipoTexto;
            spAdministrar.ActiveSheet.Columns["contrasena"].CellType = tipoTexto;
            spAdministrar.ActiveSheet.Columns["nivel"].CellType = tipoEntero;
            spAdministrar.ActiveSheet.Columns["acceso"].CellType = tipoTexto;
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["empresa"].Index].Value = "Empresa".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["numero"].Index].Value = "No.".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["nombre"].Index].Value = "Nombre".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["contrasena"].Index].Value = "Contraseña".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["nivel"].Index].Value = "Nivel".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["acceso"].Index].Value = "Acceso".ToUpper();
            spAdministrar.ActiveSheet.Columns["empresa"].Visible = false;
            spAdministrar.ActiveSheet.Rows.Count += 1;

        }

        private void CargarEmpresasCombobox()
        {

            cbEmpresas.Visible = true;
            cbEmpresas.DataSource = empresas.ObtenerListado();
            cbEmpresas.ValueMember = "Numero";
            cbEmpresas.DisplayMember = "Nombre";
            try
            {
                cbEmpresas.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
            
        }

        private void CargarUsuarios()
        {

            try
            {
                usuarios.Empresa = Convert.ToInt32(cbEmpresas.SelectedValue.ToString());            
                spAdministrar.DataSource = usuarios.ObtenerListadoDeEmpresa();
            }
            catch (Exception)
            {                             
            }

        }
        
        private void ControlarSpread(FarPoint.Win.Spread.FpSpread spread)
        {

            FarPoint.Win.Spread.InputMap valor1;
            FarPoint.Win.Spread.InputMap valor2;
            valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            valor1.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
            valor1.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
            valor2.Put(new FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            valor2.Put(new FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

        }

        private void CargarEmpresasSpread()
        {
             
            spAdministrar.DataSource = empresas.ObtenerListado();
                       
        }

        private void FormatearSpreadEmpresas()
        {

            cbEmpresas.Visible = false;
            spAdministrar.ActiveSheet.Columns[0].Tag = "numero";
            spAdministrar.ActiveSheet.Columns[1].Tag = "nombre";
            spAdministrar.ActiveSheet.Columns[2].Tag = "descripcion";
            spAdministrar.ActiveSheet.Columns[3].Tag = "domicilio";
            spAdministrar.ActiveSheet.Columns[4].Tag = "localidad";
            spAdministrar.ActiveSheet.Columns[5].Tag = "rfc";
            spAdministrar.ActiveSheet.Columns[6].Tag = "directorio";
            spAdministrar.ActiveSheet.Columns[7].Tag = "logo";
            spAdministrar.ActiveSheet.Columns[8].Tag = "activa";
            spAdministrar.ActiveSheet.Columns[9].Tag = "equipo";
            spAdministrar.ActiveSheet.Columns["numero"].Width = 50;
            spAdministrar.ActiveSheet.Columns["nombre"].Width = 220;
            spAdministrar.ActiveSheet.Columns["descripcion"].Width = 220;
            spAdministrar.ActiveSheet.Columns["domicilio"].Width = 120;
            spAdministrar.ActiveSheet.Columns["localidad"].Width = 120;
            spAdministrar.ActiveSheet.Columns["rfc"].Width = 115;
            spAdministrar.ActiveSheet.Columns["directorio"].Width = 150;
            spAdministrar.ActiveSheet.Columns["logo"].Width = 150;
            spAdministrar.ActiveSheet.Columns["activa"].Width = 130;
            spAdministrar.ActiveSheet.Columns["equipo"].Width = 100;
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["numero"].Index].Value = "No.".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["nombre"].Index].Value = "Nombre".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["descripcion"].Index].Value = "Descripcion".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["domicilio"].Index].Value = "Domicilio".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["localidad"].Index].Value = "Localidad".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["rfc"].Index].Value = "Rfc".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["directorio"].Index].Value = "Directorio".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["logo"].Index].Value = "Logo".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["activa"].Index].Value = "Activa".ToUpper();
            spAdministrar.ActiveSheet.ColumnHeader.Cells[0, spAdministrar.ActiveSheet.Columns["equipo"].Index].Value = "Equipo".ToUpper();            
            spAdministrar.ActiveSheet.Columns[0, spAdministrar.ActiveSheet.Columns.Count-1].Visible = true;
            spAdministrar.ActiveSheet.Rows.Count += 1;

        }

        #endregion

    }
}
