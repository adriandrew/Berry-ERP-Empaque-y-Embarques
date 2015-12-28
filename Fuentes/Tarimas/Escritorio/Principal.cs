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

        EntidadesTarima.BaseDatos baseDatos = new EntidadesTarima.BaseDatos();
        EntidadesTarima.Tarima tarima = new EntidadesTarima.Tarima();
        LogicaTarima.DatosEmpresa datosEmpresa = new LogicaTarima.DatosEmpresa(); 
        FarPoint.Win.Spread.CellType.TextCellType tipotexto = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.NumberCellType tipoEntero = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.NumberCellType tipoDoble = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.PercentCellType tipoPorcentaje = new FarPoint.Win.Spread.CellType.PercentCellType();
        FarPoint.Win.Spread.CellType.DateTimeCellType tipoHora = new FarPoint.Win.Spread.CellType.DateTimeCellType();
        FarPoint.Win.Spread.CellType.TextCellType tipoTexto = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.DateTimeCellType tipoFecha = new FarPoint.Win.Spread.CellType.DateTimeCellType();
        ProcessStartInfo ejecutarProgramaPrincipal = new ProcessStartInfo();

        #region Eventos

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            Centrar();
            ControlarSpread(spTarima);
            FormatearSpread();
            FormatearSpreadTarimas();
            //string[] parametros = datosEmpresa.RetornarParametros();
            //for (int i = 1; i <= parametros.Length - 1; i++)
            //{
            //    MessageBox.Show(parametros[i].Replace("|", " "));
            //}            
            ConfigurarConexiones();
            CargarTitulosEmpresa();

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {

            ejecutarProgramaPrincipal.UseShellExecute = true;
            ejecutarProgramaPrincipal.FileName = "PrincipalBerry.exe";
            ejecutarProgramaPrincipal.WorkingDirectory = Directory.GetCurrentDirectory(); 
            try
            {
                Process.Start(ejecutarProgramaPrincipal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede abrir el programa principal en la ruta : " + ejecutarProgramaPrincipal.WorkingDirectory + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void spTarimas_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                ControlarSpread();
            }

        }

        private void spTarima_DialogKey(object sender, FarPoint.Win.Spread.DialogKeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                ControlarSpread();
            }

        }

        #endregion

        #region Metodos Privados

        private void Centrar()
        {

            this.CenterToScreen();

        }

        private void FormatearSpread()
        {

            spTarima.Visible = true;
            spTarima.ActiveSheet.ColumnHeader.Rows[0].Height = 30;
            spTarima.ActiveSheet.GrayAreaBackColor = Color.White;
            spTarima.Font = new Font("microsoft sans serif", 11, FontStyle.Bold);
            spTarima.ActiveSheetIndex = 0;
            tipoEntero.DecimalPlaces = 0;

        }

        private void FormatearSpreadTarimas()
        {

            spTarima.ActiveSheetIndex = 0;
            spTarima.ActiveSheet.Columns.Count = 18;
            spTarima.ActiveSheet.Columns[0].Tag = "fecha";
            spTarima.ActiveSheet.Columns[1].Tag = "idProductor";
            spTarima.ActiveSheet.Columns[2].Tag = "nombreProductor";
            spTarima.ActiveSheet.Columns[3].Tag = "idTarima";
            spTarima.ActiveSheet.Columns[4].Tag = "idLote";
            spTarima.ActiveSheet.Columns[5].Tag = "nombreLote";
            spTarima.ActiveSheet.Columns[6].Tag = "idProducto";
            spTarima.ActiveSheet.Columns[7].Tag = "nombreProducto";
            spTarima.ActiveSheet.Columns[8].Tag = "idVariedad";
            spTarima.ActiveSheet.Columns[9].Tag = "nombreVariedad";
            spTarima.ActiveSheet.Columns[10].Tag = "idEnvase";
            spTarima.ActiveSheet.Columns[11].Tag = "nombreEnvase";
            spTarima.ActiveSheet.Columns[12].Tag = "idTamano";
            spTarima.ActiveSheet.Columns[13].Tag = "nombreTamano";
            spTarima.ActiveSheet.Columns[14].Tag = "idEtiqueta";
            spTarima.ActiveSheet.Columns[15].Tag = "nombreEtiqueta";
            spTarima.ActiveSheet.Columns[16].Tag = "pesoBultos";
            spTarima.ActiveSheet.Columns[17].Tag = "cantidadBultos";
            spTarima.ActiveSheet.Columns["fecha"].Width = 90;
            spTarima.ActiveSheet.Columns["idProductor"].Width = 35;
            spTarima.ActiveSheet.Columns["nombreProductor"].Width = 150;
            spTarima.ActiveSheet.Columns["idTarima"].Width = 100;
            spTarima.ActiveSheet.Columns["idLote"].Width = 35;
            spTarima.ActiveSheet.Columns["nombreLote"].Width = 150;
            spTarima.ActiveSheet.Columns["idProducto"].Width = 35;
            spTarima.ActiveSheet.Columns["nombreProducto"].Width = 150;
            spTarima.ActiveSheet.Columns["idVariedad"].Width = 35;
            spTarima.ActiveSheet.Columns["nombreVariedad"].Width = 150;
            spTarima.ActiveSheet.Columns["idEnvase"].Width = 35;
            spTarima.ActiveSheet.Columns["nombreEnvase"].Width = 150;
            spTarima.ActiveSheet.Columns["idTamano"].Width = 35;
            spTarima.ActiveSheet.Columns["nombreTamano"].Width = 150;
            spTarima.ActiveSheet.Columns["idEtiqueta"].Width = 35;
            spTarima.ActiveSheet.Columns["nombreEtiqueta"].Width = 150;
            spTarima.ActiveSheet.Columns["pesoBultos"].Width = 100;
            spTarima.ActiveSheet.Columns["cantidadBultos"].Width = 100;
            spTarima.ActiveSheet.Columns["fecha"].CellType = tipoFecha;
            spTarima.ActiveSheet.Columns["idProductor"].CellType = tipoEntero;
            spTarima.ActiveSheet.Columns["idTarima"].CellType = tipoEntero;
            spTarima.ActiveSheet.Columns["idLote"].CellType = tipoEntero;
            spTarima.ActiveSheet.Columns["idProducto"].CellType = tipoEntero;
            spTarima.ActiveSheet.Columns["idVariedad"].CellType = tipoEntero;
            spTarima.ActiveSheet.Columns["idEnvase"].CellType = tipoEntero;
            spTarima.ActiveSheet.Columns["idTamano"].CellType = tipoEntero;
            spTarima.ActiveSheet.Columns["idEtiqueta"].CellType = tipoEntero;
            spTarima.ActiveSheet.Columns["pesoBultos"].CellType = tipoDoble;
            spTarima.ActiveSheet.Columns["cantidadBultos"].CellType = tipoEntero;
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["fecha"].Index].Value = "Fecha".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["idProductor"].Index].Value = "No.".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["nombreProductor"].Index].Value = "Productor".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["idTarima"].Index].Value = "No. Tarima".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["idLote"].Index].Value = "No.".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["nombreLote"].Index].Value = "Lote".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["idProducto"].Index].Value = "No.".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["nombreProducto"].Index].Value = "Producto".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["idVariedad"].Index].Value = "No.".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["nombreVariedad"].Index].Value = "Variedad".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["idEnvase"].Index].Value = "No.".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["nombreEnvase"].Index].Value = "Envase".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["idTamano"].Index].Value = "No.".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["nombreTamano"].Index].Value = "Tamaño".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["idEtiqueta"].Index].Value = "No.".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["nombreEtiqueta"].Index].Value = "Etiqueta".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["pesoBultos"].Index].Value = "Peso de Bulto".ToUpper();
            spTarima.ActiveSheet.ColumnHeader.Cells[0, spTarima.ActiveSheet.Columns["cantidadBultos"].Index].Value = "Cantidad Bultos".ToUpper();

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
        
        private void ControlarSpread()
        {

            int filaActiva = spTarima.ActiveSheet.ActiveRowIndex;
            int columnaActiva = spTarima.ActiveSheet.ActiveColumnIndex;
            string fecha = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["fecha"].Index].Text;
            string idProductor = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idProductor"].Index].Text;
            string idLote = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idLote"].Index].Text;
            string idProducto = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idProducto"].Index].Text;
            string idVariedad = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idVariedad"].Index].Text;
            string idEnvase = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idEnvase"].Index].Text;
            string idTamano = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idTamano"].Index].Text;
            string idEtiqueta = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idEtiqueta"].Index].Text;
            string pesoBultos = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["pesoBultos"].Index].Text;
            string cantidadBultos = spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["cantidadBultos"].Index].Text; 

            if (columnaActiva == spTarima.ActiveSheet.Columns["fecha"].Index)
            {
                if (!LogicaTarima.Funciones.ValidarFecha(fecha))
                { 
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["fecha"].Index].Text = DateTime.Now.ToShortDateString();
                }
            } 
            else if (columnaActiva == spTarima.ActiveSheet.Columns["idProductor"].Index)
            {
                if (LogicaTarima.Funciones.ValidarNumero(idProductor) > 0)
                {
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idTarima"].Index].Text = ObtenerIdTarimaConsecutiva(Convert.ToInt32(idProductor)).ToString();
                    //spTarima.ActiveSheet.AddRows(spTarima.ActiveSheet.RowCount, 1);                    
                }
                else
                {                    
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idProductor"].Index].Text = string.Empty;
                    spTarima.ActiveSheet.SetActiveCell(filaActiva, spTarima.ActiveSheet.Columns["idProductor"].Index - 1);
                }

            }
            else if (columnaActiva == spTarima.ActiveSheet.Columns["idLote"].Index)
            {
                if (LogicaTarima.Funciones.ValidarNumero(idLote) <= 0)
                {
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idLote"].Index].Text = string.Empty;
                    spTarima.ActiveSheet.SetActiveCell(filaActiva, spTarima.ActiveSheet.Columns["idLote"].Index - 1);
                }
            }
            else if (columnaActiva == spTarima.ActiveSheet.Columns["idProducto"].Index)
            {
                if (LogicaTarima.Funciones.ValidarNumero(idProducto) <= 0)
                {
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idProducto"].Index].Text = string.Empty;
                    spTarima.ActiveSheet.SetActiveCell(filaActiva, spTarima.ActiveSheet.Columns["idProducto"].Index - 1);
                }
            }
            else if (columnaActiva == spTarima.ActiveSheet.Columns["idVariedad"].Index)
            {
                if (LogicaTarima.Funciones.ValidarNumero(idVariedad) <= 0)
                {
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idVariedad"].Index].Text = string.Empty;
                    spTarima.ActiveSheet.SetActiveCell(filaActiva, spTarima.ActiveSheet.Columns["idVariedad"].Index - 1);
                }
            }
            else if (columnaActiva == spTarima.ActiveSheet.Columns["idEnvase"].Index)
            {
                if (LogicaTarima.Funciones.ValidarNumero(idEnvase) <= 0)
                {
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idEnvase"].Index].Text = string.Empty;
                    spTarima.ActiveSheet.SetActiveCell(filaActiva, spTarima.ActiveSheet.Columns["idEnvase"].Index - 1);
                }
            }
            else if (columnaActiva == spTarima.ActiveSheet.Columns["idTamano"].Index)
            {
                if (LogicaTarima.Funciones.ValidarNumero(idTamano) <= 0)
                {
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idTamano"].Index].Text = string.Empty;
                    spTarima.ActiveSheet.SetActiveCell(filaActiva, spTarima.ActiveSheet.Columns["idTamano"].Index - 1);
                }
            }
            else if (columnaActiva == spTarima.ActiveSheet.Columns["idEtiqueta"].Index)
            {
                if (LogicaTarima.Funciones.ValidarNumero(idEtiqueta) <= 0)
                {
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["idEtiqueta"].Index].Text = string.Empty;
                    spTarima.ActiveSheet.SetActiveCell(filaActiva, spTarima.ActiveSheet.Columns["idEtiqueta"].Index - 1);
                }
            }
            else if (columnaActiva == spTarima.ActiveSheet.Columns["pesoBultos"].Index)
            {
                if (LogicaTarima.Funciones.ValidarDouble(pesoBultos) <= 0)
                {
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["pesoBultos"].Index].Text = string.Empty;
                    spTarima.ActiveSheet.SetActiveCell(filaActiva, spTarima.ActiveSheet.Columns["pesoBultos"].Index - 1);
                }
            }
            else if (columnaActiva == spTarima.ActiveSheet.Columns["cantidadBultos"].Index)
            {
                if (LogicaTarima.Funciones.ValidarNumero(cantidadBultos) > 0)
                {
                    GuardarTarima();
                }
                else
                {
                    spTarima.ActiveSheet.Cells[filaActiva, spTarima.ActiveSheet.Columns["cantidadBultos"].Index].Text = string.Empty;
                    spTarima.ActiveSheet.SetActiveCell(filaActiva, spTarima.ActiveSheet.Columns["cantidadBultos"].Index - 1);
                }
            }
        }

        private void GuardarTarima(DateTime fecha, int idProductor, int idLote, int idProducto, int idVariedad, int idEnvase, int idTamano, int idEtiqueta, double pesoBultos, int cantidadBultos)
        {

            tarima.FechaEmpaque = fecha;
            tarima.IdProductor = idProductor;
            tarima.IdLote = idLote;
            tarima.IdProducto = idProducto;
            tarima.IdVariedad = idVariedad;
            tarima.IdEnvase = idEnvase;
            tarima.IdTamano = idTamano;
            tarima.IdEtiqueta = idEtiqueta;
            tarima.PesoBultos = pesoBultos;

            tarima.Guardar();

        }

        private int ObtenerIdTarimaConsecutiva(int idProductor)
        {

            tarima.IdProductor = idProductor;
            return tarima.ObtenerIdTarimaConsecutiva();
            
        }

        private void ConfigurarConexiones()
        {

            bool esPrueba = true;
            if (esPrueba)
            {
                baseDatos.CadenaConexionEYE = "C:\\Berry\\BD\\PVE\\EYE.mdf";
            }
            else
            {
                datosEmpresa.ObtenerParametrosInformacionEmpresa();
                baseDatos.CadenaConexionEYE = datosEmpresa.Directorio;
            }
            baseDatos.AbrirConexionEYE(); 

        }

        private void CargarTitulosEmpresa()
        {
            this.Text += ": " + datosEmpresa.Numero + " - " + datosEmpresa.Nombre;
        }

        #endregion
        
    }
}
