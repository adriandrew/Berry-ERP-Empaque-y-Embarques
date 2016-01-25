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
    public partial class Catalogos : Form
    {

        EntidadesTarima.Productor productor = new EntidadesTarima.Productor();
        public static int opcionSeleccionada;
        FarPoint.Win.Spread.CellType.TextCellType tipotexto = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.NumberCellType tipoEntero = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.NumberCellType tipoDoble = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.PercentCellType tipoPorcentaje = new FarPoint.Win.Spread.CellType.PercentCellType();
        FarPoint.Win.Spread.CellType.DateTimeCellType tipoHora = new FarPoint.Win.Spread.CellType.DateTimeCellType();
        FarPoint.Win.Spread.CellType.TextCellType tipoTexto = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.DateTimeCellType tipoFecha = new FarPoint.Win.Spread.CellType.DateTimeCellType();

        public Catalogos()
        {
            InitializeComponent();
        }

        private void Catalogos_Load(object sender, EventArgs e)
        {

            Centrar();
            AsignarTooltips();
            Principal.ControlarSpread(spCatalogo);
            if (Catalogos.opcionSeleccionada == (int)LogicaTarima.NumeracionCatalogos.Numeracion.productor)
            {
                CargarProductores();
                FormatearSpread();
            }

        }

        private void Centrar()
        {

            this.CenterToScreen();

        }

        private void CargarProductores() 
        {

            this.spCatalogo.DataSource = productor.ObtenerListado();
            
        }

        private void FormatearSpread()
        {

            spCatalogo.ActiveSheet.ColumnHeader.Rows[0].Height = 30;
            spCatalogo.ActiveSheet.GrayAreaBackColor = Color.White;
            spCatalogo.Font = new Font("microsoft sans serif", 11, FontStyle.Bold);
            spCatalogo.ActiveSheetIndex = 0;            
            spCatalogo.ActiveSheet.Rows.Count += 1;
            tipoEntero.DecimalPlaces = 0;

        }

        private void AsignarTooltips()
        {

            ToolTip tp = new ToolTip();
            tp.AutoPopDelay = 5000;
            tp.InitialDelay = 0;
            tp.ReshowDelay = 100;
            tp.ShowAlways = true;
            //tp.SetToolTip(this.btnGuardar, "Guardar Tarima.");

        }

        private void ControlarProductores()
        {

            int filaActiva = spCatalogo.ActiveSheet.ActiveRowIndex;
            int columnaActiva = spCatalogo.ActiveSheet.ActiveColumnIndex;
            string id = spCatalogo.ActiveSheet.Cells[filaActiva, 0].Text;
            string nombre = spCatalogo.ActiveSheet.Cells[filaActiva, 1].Text;
            string domicilio = spCatalogo.ActiveSheet.Cells[filaActiva, 2].Text;
            string ciudad = spCatalogo.ActiveSheet.Cells[filaActiva, 3].Text;
            string estado = spCatalogo.ActiveSheet.Cells[filaActiva, 4].Text;
            string codigoPostal = spCatalogo.ActiveSheet.Cells[filaActiva, 5].Text;
            string rfc = spCatalogo.ActiveSheet.Cells[filaActiva, 6].Text;
            string telefono = spCatalogo.ActiveSheet.Cells[filaActiva, 7].Text;
            string representante = spCatalogo.ActiveSheet.Cells[filaActiva, 8].Text;
            string fda = spCatalogo.ActiveSheet.Cells[filaActiva, 9].Text;
            string gs1 = spCatalogo.ActiveSheet.Cells[filaActiva, 10].Text;
            string immex = spCatalogo.ActiveSheet.Cells[filaActiva, 11].Text;
            string claveTomate = spCatalogo.ActiveSheet.Cells[filaActiva, 12].Text;

            if (columnaActiva == 0)
            {
                if (LogicaTarima.Funciones.ValidarNumero(id) == 0)
                    spCatalogo.ActiveSheet.SetActiveCell(filaActiva, columnaActiva - 1);
            }
            else if (columnaActiva == 1)
            {
                if (LogicaTarima.Funciones.ValidarString(nombre))
                    spCatalogo.ActiveSheet.SetActiveCell(filaActiva, columnaActiva - 1);
            }
            else if (columnaActiva == spCatalogo.ActiveSheet.Columns.Count - 1)
            {
                if (LogicaTarima.Funciones.ValidarNumero(id) > 0 && !string.IsNullOrEmpty(nombre))
                {
                    productor.Id = Convert.ToInt32(id);
                    productor.Nombre = nombre;
                    productor.Domicilio = domicilio;
                    productor.Ciudad = ciudad;
                    productor.Estado = estado;
                    if (LogicaTarima.Funciones.ValidarNumero(codigoPostal) > 0)
                        productor.CodigoPostal = Convert.ToInt32(codigoPostal);
                    productor.Rfc = rfc;
                    if (LogicaTarima.Funciones.ValidarNumero(telefono) > 0)
                        productor.Telefono = Convert.ToInt32(telefono);
                    productor.Representante = representante;
                    if (LogicaTarima.Funciones.ValidarNumero(fda) > 0)
                        productor.Fda = Convert.ToInt32(fda); if (LogicaTarima.Funciones.ValidarNumero(gs1) > 0)
                        productor.Gs1 = Convert.ToInt32(gs1);
                    if (LogicaTarima.Funciones.ValidarNumero(immex) > 0)
                        productor.Immex = Convert.ToInt32(immex);
                    productor.ClaveTomate = claveTomate;
                    bool tieneProductor = productor.ValidarPorId();
                    if (!tieneProductor)
                        productor.Guardar();
                    else
                        productor.Editar();
                    CargarProductores();
                    FormatearSpread();
                }
            } 

        }
        
        private void ControlarSpread() 
        {

            if (Catalogos.opcionSeleccionada == (int)LogicaTarima.NumeracionCatalogos.Numeracion.productor)
            {
                ControlarProductores();
            }

        }

        private void AumentarFila(int fila)
        {

            spCatalogo.ActiveSheet.AddRows(fila, 1);

        }

        private void LimpiarFila(int fila)
        {

            spCatalogo.ActiveSheet.ClearRange(fila, 0, fila, spCatalogo.ActiveSheet.Columns.Count-1, true);

        }

        private void spCatalogo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                ControlarSpread();
            }
            else if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }

        }

        private void spCatalogo_DialogKey(object sender, FarPoint.Win.Spread.DialogKeyEventArgs e)
        {

            if (e.KeyData == Keys.F10)
            {
                int filaActiva = spCatalogo.ActiveSheet.ActiveRowIndex;
                string id = spCatalogo.ActiveSheet.Cells[filaActiva, 0].Text;
                if (LogicaTarima.Funciones.ValidarNumero(id) > 0)
                {
                    if (MessageBox.Show("Estás seguro de eliminar este registro?", "Confirmar.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Catalogos.opcionSeleccionada == (int)LogicaTarima.NumeracionCatalogos.Numeracion.productor)
                        {
                            productor.Id = Convert.ToInt32(id);
                            productor.Eliminar();
                            CargarProductores();
                            FormatearSpread();
                        }
                    }
                }
            }

        }

    }
}
