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

        Entidades.Empresas empresas = new Entidades.Empresas();
        Entidades.BaseDatos baseDatos = new Entidades.BaseDatos();
        Logica.DatosEmpresa datosEmpresa = new Logica.DatosEmpresa();
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

        private void Empresas_Load(object sender, EventArgs e)
        {

            Centrar(); 
            ControlarSpread(spTarimas);
            FormatearSpread();
            FormatearSpreadTarimas();

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

        #endregion

        #region Metodos Privados

        private void Centrar()
        {

            this.CenterToScreen();

        }
         
        private void FormatearSpread()
        {

            spTarimas.Visible = true;
            spTarimas.ActiveSheet.ColumnHeader.Rows[0].Height = 30;
            spTarimas.ActiveSheet.GrayAreaBackColor = Color.White;
            spTarimas.Font = new Font("microsoft sans serif", 11, FontStyle.Bold);
            spTarimas.ActiveSheetIndex = 0;
            tipoEntero.DecimalPlaces = 0;

        }        

        private void FormatearSpreadTarimas()
        {

            spTarimas.ActiveSheetIndex = 0;
            spTarimas.ActiveSheet.Columns.Count = 18;
            spTarimas.ActiveSheet.Columns[0].Tag = "fecha";
            spTarimas.ActiveSheet.Columns[1].Tag = "idProductor";
            spTarimas.ActiveSheet.Columns[2].Tag = "nombreProductor";
            spTarimas.ActiveSheet.Columns[3].Tag = "idTarima";
            spTarimas.ActiveSheet.Columns[4].Tag = "idLote";
            spTarimas.ActiveSheet.Columns[5].Tag = "nombreLote";
            spTarimas.ActiveSheet.Columns[6].Tag = "idProducto";
            spTarimas.ActiveSheet.Columns[7].Tag = "nombreProducto";
            spTarimas.ActiveSheet.Columns[8].Tag = "idVariedad";
            spTarimas.ActiveSheet.Columns[9].Tag = "nombreVariedad";
            spTarimas.ActiveSheet.Columns[10].Tag = "idEnvase";
            spTarimas.ActiveSheet.Columns[11].Tag = "nombreEnvase";
            spTarimas.ActiveSheet.Columns[12].Tag = "idTamano";
            spTarimas.ActiveSheet.Columns[13].Tag = "nombreTamano";
            spTarimas.ActiveSheet.Columns[14].Tag = "idEtiqueta";
            spTarimas.ActiveSheet.Columns[15].Tag = "nombreEtiqueta";
            spTarimas.ActiveSheet.Columns[16].Tag = "pesoBultos";
            spTarimas.ActiveSheet.Columns[17].Tag = "cantidadBultos";
            spTarimas.ActiveSheet.Columns["fecha"].Width = 90;
            spTarimas.ActiveSheet.Columns["idProductor"].Width = 35;
            spTarimas.ActiveSheet.Columns["nombreProductor"].Width = 150;
            spTarimas.ActiveSheet.Columns["idTarima"].Width = 100;
            spTarimas.ActiveSheet.Columns["idLote"].Width = 35;
            spTarimas.ActiveSheet.Columns["nombreLote"].Width = 150;
            spTarimas.ActiveSheet.Columns["idProducto"].Width = 35;
            spTarimas.ActiveSheet.Columns["nombreProducto"].Width = 150;
            spTarimas.ActiveSheet.Columns["idVariedad"].Width = 35;
            spTarimas.ActiveSheet.Columns["nombreVariedad"].Width = 150;
            spTarimas.ActiveSheet.Columns["idEnvase"].Width = 35;
            spTarimas.ActiveSheet.Columns["nombreEnvase"].Width = 150;
            spTarimas.ActiveSheet.Columns["idTamano"].Width = 35;
            spTarimas.ActiveSheet.Columns["nombreTamano"].Width = 150;
            spTarimas.ActiveSheet.Columns["idEtiqueta"].Width = 35;
            spTarimas.ActiveSheet.Columns["nombreEtiqueta"].Width = 150;
            spTarimas.ActiveSheet.Columns["pesoBultos"].Width = 100;
            spTarimas.ActiveSheet.Columns["cantidadBultos"].Width = 100;
            spTarimas.ActiveSheet.Columns["fecha"].CellType = tipoFecha;
            spTarimas.ActiveSheet.Columns["idProductor"].CellType = tipoEntero;
            spTarimas.ActiveSheet.Columns["idTarima"].CellType = tipoEntero;
            spTarimas.ActiveSheet.Columns["idLote"].CellType = tipoEntero;
            spTarimas.ActiveSheet.Columns["idProducto"].CellType = tipoEntero;
            spTarimas.ActiveSheet.Columns["idVariedad"].CellType = tipoEntero;
            spTarimas.ActiveSheet.Columns["idEnvase"].CellType = tipoEntero;
            spTarimas.ActiveSheet.Columns["idTamano"].CellType = tipoEntero;
            spTarimas.ActiveSheet.Columns["idEtiqueta"].CellType = tipoEntero;
            spTarimas.ActiveSheet.Columns["pesoBultos"].CellType = tipoDoble;
            spTarimas.ActiveSheet.Columns["cantidadBultos"].CellType = tipoEntero;
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["fecha"].Index].Value = "Fecha".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["idProductor"].Index].Value = "No.".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["nombreProductor"].Index].Value = "Productor".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["idTarima"].Index].Value = "No. Tarima".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["idLote"].Index].Value = "No.".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["nombreLote"].Index].Value = "Lote".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["idProducto"].Index].Value = "No.".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["nombreProducto"].Index].Value = "Producto".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["idVariedad"].Index].Value = "No.".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["nombreVariedad"].Index].Value = "Variedad".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["idEnvase"].Index].Value = "No.".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["nombreEnvase"].Index].Value = "Envase".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["idTamano"].Index].Value = "No.".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["nombreTamano"].Index].Value = "Tamaño".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["idEtiqueta"].Index].Value = "No.".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["nombreEtiqueta"].Index].Value = "Etiqueta".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["pesoBultos"].Index].Value = "Peso de Bulto".ToUpper();
            spTarimas.ActiveSheet.ColumnHeader.Cells[0, spTarimas.ActiveSheet.Columns["cantidadBultos"].Index].Value = "Cantidad Bultos".ToUpper();

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

        #endregion
        
    }
}
