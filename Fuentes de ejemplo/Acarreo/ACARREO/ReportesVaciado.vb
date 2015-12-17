Imports System.Data.OleDb

Public Class ReportesVaciado

    Dim columnasBandas As Integer = 0

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()
        LlenaLotes()
        txtFechaDesde.Text = Today.ToShortDateString
        txtFechaHasta.Text = Today.ToShortDateString
        FormatoReporte()
        spReporte.ActiveSheetIndex = 0
    End Sub

#Region "MÉTODOS"

    Sub LlenaLotes()
        Dim cmd As New OleDb.OleDbCommand
        Dim adap As New OleDb.OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("Select Codigo as Id, Descri as Descripcion from Lote order by Codigo" & _
                               " Union Select -1, 'TODOS' from Lote", conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception

        End Try

        If rst.Tables.Count > 0 Then
            cboLotes.ValueMember = "Id"
            cboLotes.DisplayMember = "Descripcion"
            cboLotes.DataSource = rst.Tables(0)
        End If
        cmd.Dispose()
        adap.Dispose()
        rst.Dispose()
    End Sub

    Sub LlenaGrupoLotes()
        Dim cmd As New OleDb.OleDbCommand
        Dim adap As New OleDb.OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("Select Codigo as Id, Nombre as Descripcion from LOTE order by Codigo" & _
                               " Union Select -1, 'TODOS' from Lote", conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception

        End Try

        If rst.Tables.Count > 0 Then
            cboLotes.ValueMember = "ID"
            cboLotes.DisplayMember = "Descripcion"
            cboLotes.DataSource = rst.Tables(0)
        End If
        cmd.Dispose()
        adap.Dispose()
        rst.Dispose()
    End Sub

    Sub FormatoReporte()

        Dim tipotxt As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tipoint As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tipodob As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tipoporcent As New FarPoint.Win.Spread.CellType.PercentCellType
        Dim tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType

        'PROPIEDADES DE TIPOS DE CELDAS
        tipoint.DecimalPlaces = 0
        tipoint.Separator = ","
        tipoint.ShowSeparator = True
        tipodob.DecimalPlaces = 2
        tipodob.Separator = ","
        tipodob.ShowSeparator = True
        tipoporcent.DecimalPlaces = 2

        'spReporte.Reset()

        spReporte.Size = New Size(950, 500)
        spReporte.Location = New Point(23, 91)
        spReporte.Font = New Font("microsoft sans serif", 8.25, FontStyle.Bold)
        spReporte.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spReporte.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spReporte.TabStripInsertTab = False
        spReporte.Sheets.Count = 4
        spReporte.Sheets(0).SheetName = "Reporte Por Hora"
        spReporte.Sheets(1).SheetName = "Totales Por Lote"
        spReporte.Sheets(2).SheetName = "Rendimientos"
        spReporte.Sheets(3).SheetName = "Reporte de Piso"


        spReporte.Sheets(1).Visible = False
        spReporte.Sheets(2).Visible = False


        'FORMATO DEL REPORTE GENERAL
        spReporte.Sheets(0).ColumnCount = columnasBandas
        spReporte.Sheets(0).GrayAreaBackColor = Color.White

        'TAGS DE COLUMNAS
        'spReporte.Sheets(0).Columns(0).Tag = "folio"
        'spReporte.Sheets(0).Columns(1).Tag = "fecha"
        'spReporte.Sheets(0).Columns(2).Tag = "hora"
        'spReporte.Sheets(0).Columns(3).Tag = "productor"
        'spReporte.Sheets(0).Columns(4).Tag = "lote"
        'spReporte.Sheets(0).Columns(5).Tag = "producto"
        'spReporte.Sheets(0).Columns(6).Tag = "cajas"
        'spReporte.Sheets(0).Columns(7).Tag = "peso"
        'spReporte.Sheets(0).Columns(8).Tag = "chofer"

        'TIPOS DE CELDAS
        'spReporte.Sheets(0).Columns("folio").CellType = tipotxt
        'spReporte.Sheets(0).Columns("productor").CellType = tipotxt
        'spReporte.Sheets(0).Columns("lote").CellType = tipotxt
        'spReporte.Sheets(0).Columns("producto").CellType = tipotxt
        'spReporte.Sheets(0).Columns("cajas").CellType = tipoint
        'spReporte.Sheets(0).Columns("peso").CellType = tipodob
        'spReporte.Sheets(0).Columns("chofer").CellType = tipotxt
        'spReporte.Sheets(0).Columns("hora").CellType = tipoHora

        Try
            If spReporte.Sheets(0).Columns.Count > 1 Then
                spReporte.Sheets(0).Columns(1, spReporte.Sheets(0).Rows.Count - 1).CellType = tipoint
            End If
        Catch ex As Exception
        End Try



        If spReporte.Sheets(0).Columns.Count > 1 Then
            spReporte.Sheets(0).Columns(0, spReporte.Sheets(0).Columns.Count - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        End If


        spReporte.Sheets(0).Columns(spReporte.Sheets(0).Columns.Count - 1).Font = New Font("microsoft sans serif", 9.25, FontStyle.Bold)

        'ANCHO DE COLUMNAS
        'spReporte.Sheets(0).Columns("folio").Width = 50
        'spReporte.Sheets(0).Columns("fecha").Width = 70
        'spReporte.Sheets(0).Columns("hora").Width = 65
        'spReporte.Sheets(0).Columns("productor").Width = 250
        'spReporte.Sheets(0).Columns("lote").Width = 100
        'spReporte.Sheets(0).Columns("producto").Width = 90
        'spReporte.Sheets(0).Columns("cajas").Width = 50
        'spReporte.Sheets(0).Columns("peso").Width = 65
        'spReporte.Sheets(0).Columns("chofer").Width = 170
        If columnasBandas > 0 Then
            spReporte.Sheets(0).Columns(0, columnasBandas - 1).Width = 60
        End If

        'ALTURA DE FILAS
        spReporte.Sheets(0).ColumnHeader.Rows(0).Height = 40

        'ENCABEZADOS DE COLUMNAS
        'spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("folio").Index).Value = "FOLIO"
        'spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("fecha").Index).Value = "FECHA"
        'spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("hora").Index).Value = "HORA"
        'spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("productor").Index).Value = "PRODUCTOR"
        'spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("lote").Index).Value = "LOTE"
        'spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("producto").Index).Value = "PRODUCTO"
        'spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("cajas").Index).Value = "CAJAS"
        'spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("peso").Index).Value = "PESO"
        'spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("chofer").Index).Value = "CHOFER"

        spReporte.Sheets(0).AlternatingRows.Count = 2
        spReporte.Sheets(0).AlternatingRows(0).BackColor = Color.White
        spReporte.Sheets(0).AlternatingRows(0).BackColor = Color.Azure

        'FORMATO DEL REPORTE DE TOTALES

        spReporte.Sheets(1).ColumnCount = 5
        spReporte.Sheets(1).GrayAreaBackColor = Color.White

        'TAGS DE COLUMNAS
        spReporte.Sheets(1).Columns(0).Tag = "productor"
        spReporte.Sheets(1).Columns(1).Tag = "lote"
        spReporte.Sheets(1).Columns(2).Tag = "producto"
        spReporte.Sheets(1).Columns(3).Tag = "cajas"
        spReporte.Sheets(1).Columns(4).Tag = "peso"

        spReporte.Sheets(1).Columns("productor").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        spReporte.Sheets(1).Columns("lote").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        spReporte.Sheets(1).Columns("producto").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        spReporte.Sheets(1).Columns("cajas").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        spReporte.Sheets(1).Columns("peso").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right

        'TIPOS DE CELDAS
        spReporte.Sheets(1).Columns("productor").CellType = tipotxt
        spReporte.Sheets(1).Columns("lote").CellType = tipotxt
        spReporte.Sheets(1).Columns("producto").CellType = tipotxt
        spReporte.Sheets(1).Columns("cajas").CellType = tipoint
        spReporte.Sheets(1).Columns("peso").CellType = tipodob

        'ANCHO DE COLUMNAS
        spReporte.Sheets(1).Columns("productor").Width = 320
        spReporte.Sheets(1).Columns("lote").Width = 150
        spReporte.Sheets(1).Columns("producto").Width = 150
        spReporte.Sheets(1).Columns("cajas").Width = 100
        spReporte.Sheets(1).Columns("peso").Width = 100
        spReporte.Sheets(1).RowHeader.Columns(0).Width = 35

        'ALTURA DE FILAS
        spReporte.Sheets(1).ColumnHeader.Rows(0).Height = 40

        'ENCABEZADOS DE COLUMNAS
        spReporte.Sheets(1).ColumnHeader.Cells(0, spReporte.Sheets(1).Columns("productor").Index).Value = "PRODUCTOR"
        spReporte.Sheets(1).ColumnHeader.Cells(0, spReporte.Sheets(1).Columns("lote").Index).Value = "LOTE"
        spReporte.Sheets(1).ColumnHeader.Cells(0, spReporte.Sheets(1).Columns("producto").Index).Value = "PRODUCTO"
        spReporte.Sheets(1).ColumnHeader.Cells(0, spReporte.Sheets(1).Columns("cajas").Index).Value = "CAJAS"
        spReporte.Sheets(1).ColumnHeader.Cells(0, spReporte.Sheets(1).Columns("peso").Index).Value = "PESO"

        spReporte.Sheets(1).AlternatingRows.Count = 2
        spReporte.Sheets(1).AlternatingRows(0).BackColor = Color.White
        spReporte.Sheets(1).AlternatingRows(0).BackColor = Color.Azure

        'FORMATO DE REPORTE DE RENDIMIENTOS

        spReporte.Sheets(2).ColumnCount = 9
        spReporte.Sheets(2).ColumnHeader.RowCount = 2
        spReporte.Sheets(2).GrayAreaBackColor = Color.White

        'TAGS DE COLUMNAS
        spReporte.Sheets(2).Columns(0).Tag = "grupolote"
        spReporte.Sheets(2).Columns(1).Tag = "idproducto"
        spReporte.Sheets(2).Columns(2).Tag = "producto"
        spReporte.Sheets(2).Columns(3).Tag = "cajasrecibidas"
        spReporte.Sheets(2).Columns(4).Tag = "cajasprocesadas"
        spReporte.Sheets(2).Columns(5).Tag = "cajasporcentaje"
        spReporte.Sheets(2).Columns(6).Tag = "pesorecibido"
        spReporte.Sheets(2).Columns(7).Tag = "pesoprocesado"
        spReporte.Sheets(2).Columns(8).Tag = "pesoporcentaje"

        'TIPOS DE CELDAS
        spReporte.Sheets(2).Columns("grupolote").CellType = tipotxt
        spReporte.Sheets(2).Columns("idproducto").CellType = tipoint
        spReporte.Sheets(2).Columns("producto").CellType = tipotxt
        spReporte.Sheets(2).Columns("cajasrecibidas").CellType = tipoint
        spReporte.Sheets(2).Columns("cajasprocesadas").CellType = tipoint
        spReporte.Sheets(2).Columns("cajasporcentaje").CellType = tipoporcent
        spReporte.Sheets(2).Columns("pesorecibido").CellType = tipodob
        spReporte.Sheets(2).Columns("pesoprocesado").CellType = tipodob
        spReporte.Sheets(2).Columns("pesoporcentaje").CellType = tipoporcent

        'ANCHO DE COLUMNAS
        spReporte.Sheets(2).Columns("grupolote").Width = 100
        spReporte.Sheets(2).Columns("idproducto").Width = 40
        spReporte.Sheets(2).Columns("producto").Width = 150
        spReporte.Sheets(2).Columns("cajasrecibidas").Width = 100
        spReporte.Sheets(2).Columns("cajasprocesadas").Width = 100
        spReporte.Sheets(2).Columns("cajasporcentaje").Width = 100
        spReporte.Sheets(2).Columns("pesorecibido").Width = 100
        spReporte.Sheets(2).Columns("pesoprocesado").Width = 100
        spReporte.Sheets(2).Columns("pesoporcentaje").Width = 100
        spReporte.Sheets(2).RowHeader.Columns(0).Width = 35

        'COMBINACIONES DE ENCABEZADOS
        spReporte.Sheets(2).AddColumnHeaderSpanCell(0, spReporte.Sheets(2).Columns("grupolote").Index, 2, 1)
        spReporte.Sheets(2).AddColumnHeaderSpanCell(0, spReporte.Sheets(2).Columns("idproducto").Index, 1, 2)
        spReporte.Sheets(2).AddColumnHeaderSpanCell(0, spReporte.Sheets(2).Columns("cajasrecibidas").Index, 1, 3)
        spReporte.Sheets(2).AddColumnHeaderSpanCell(0, spReporte.Sheets(2).Columns("pesorecibido").Index, 1, 3)

        'ENCABEZADOS DE COLUMNAS
        spReporte.Sheets(2).ColumnHeader.Cells(0, spReporte.Sheets(2).Columns("grupolote").Index).Value = "LOTES"
        spReporte.Sheets(2).ColumnHeader.Cells(0, spReporte.Sheets(2).Columns("idproducto").Index).Value = "PRODUCTO"
        spReporte.Sheets(2).ColumnHeader.Cells(1, spReporte.Sheets(2).Columns("idproducto").Index).Value = "No."
        spReporte.Sheets(2).ColumnHeader.Cells(1, spReporte.Sheets(2).Columns("producto").Index).Value = "NOMBRE"
        spReporte.Sheets(2).ColumnHeader.Cells(0, spReporte.Sheets(2).Columns("cajasrecibidas").Index).Value = "CAJAS"
        spReporte.Sheets(2).ColumnHeader.Cells(1, spReporte.Sheets(2).Columns("cajasrecibidas").Index).Value = "RECIBIDAS"
        spReporte.Sheets(2).ColumnHeader.Cells(1, spReporte.Sheets(2).Columns("cajasprocesadas").Index).Value = "PROCESADAS"
        spReporte.Sheets(2).ColumnHeader.Cells(1, spReporte.Sheets(2).Columns("cajasporcentaje").Index).Value = "RENDIMIENTO"
        spReporte.Sheets(2).ColumnHeader.Cells(0, spReporte.Sheets(2).Columns("pesorecibido").Index).Value = "PESO"
        spReporte.Sheets(2).ColumnHeader.Cells(1, spReporte.Sheets(2).Columns("pesorecibido").Index).Value = "RECIBIDO"
        spReporte.Sheets(2).ColumnHeader.Cells(1, spReporte.Sheets(2).Columns("pesoprocesado").Index).Value = "PROCESADO"
        spReporte.Sheets(2).ColumnHeader.Cells(1, spReporte.Sheets(2).Columns("pesoporcentaje").Index).Value = "RENDIMIENTO"

        spReporte.Sheets(2).AlternatingRows.Count = 2
        spReporte.Sheets(2).AlternatingRows(0).BackColor = Color.White
        spReporte.Sheets(2).AlternatingRows(0).BackColor = Color.Azure


        ' FORMATO DEL REPORTE DE PISO.
        spReporte.Sheets(3).ColumnCount = 13
        spReporte.Sheets(3).GrayAreaBackColor = Color.White

        'TAGS DE COLUMNAS
        spReporte.Sheets(3).Columns(0).Tag = "folio"
        spReporte.Sheets(3).Columns(1).Tag = "fecha"
        spReporte.Sheets(3).Columns(2).Tag = "fechaVaciado"
        spReporte.Sheets(3).Columns(3).Tag = "hora"
        spReporte.Sheets(3).Columns(4).Tag = "productor"
        spReporte.Sheets(3).Columns(5).Tag = "lote"
        spReporte.Sheets(3).Columns(6).Tag = "producto"
        spReporte.Sheets(3).Columns(7).Tag = "cajas"
        spReporte.Sheets(3).Columns(8).Tag = "cajasVaciado"
        spReporte.Sheets(3).Columns(9).Tag = "cajasPiso"
        spReporte.Sheets(3).Columns(10).Tag = "peso"
        spReporte.Sheets(3).Columns(11).Tag = "pesoVaciado"
        spReporte.Sheets(3).Columns(12).Tag = "chofer"

        'TIPOS DE CELDAS
        spReporte.Sheets(3).Columns("folio").CellType = tipotxt
        spReporte.Sheets(3).Columns("productor").CellType = tipotxt
        spReporte.Sheets(3).Columns("lote").CellType = tipotxt
        spReporte.Sheets(3).Columns("producto").CellType = tipotxt
        spReporte.Sheets(3).Columns("cajas").CellType = tipoint
        spReporte.Sheets(3).Columns("cajasVaciado").CellType = tipoint
        spReporte.Sheets(3).Columns("cajasPiso").CellType = tipoint
        spReporte.Sheets(3).Columns("peso").CellType = tipodob
        spReporte.Sheets(3).Columns("pesoVaciado").CellType = tipodob
        spReporte.Sheets(3).Columns("chofer").CellType = tipotxt
        'spReporte.Sheets(0).Columns("hora").CellType = tipoHora


        'ANCHO DE COLUMNAS
        spReporte.Sheets(3).Columns("folio").Width = 50
        spReporte.Sheets(3).Columns("fecha").Width = 70
        spReporte.Sheets(3).Columns("fechaVaciado").Width = 70
        spReporte.Sheets(3).Columns("hora").Width = 65
        spReporte.Sheets(3).Columns("productor").Width = 250
        spReporte.Sheets(3).Columns("lote").Width = 100
        spReporte.Sheets(3).Columns("producto").Width = 90
        spReporte.Sheets(3).Columns("cajas").Width = 80
        spReporte.Sheets(3).Columns("cajasVaciado").Width = 75
        spReporte.Sheets(3).Columns("cajasPiso").Width = 60
        spReporte.Sheets(3).Columns("peso").Width = 65
        spReporte.Sheets(3).Columns("pesoVaciado").Width = 65
        spReporte.Sheets(3).Columns("chofer").Width = 170
        spReporte.Sheets(3).RowHeader.Columns(0).Width = 35

        'ALTURA DE FILAS
        spReporte.Sheets(3).ColumnHeader.Rows(0).Height = 40

        'ENCABEZADOS DE COLUMNAS
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("folio").Index).Value = "FOLIO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("fecha").Index).Value = "FECHA ACARREO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("fechaVaciado").Index).Value = "FECHA VACIADO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("hora").Index).Value = "HORA ACARREO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("productor").Index).Value = "PRODUCTOR"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("lote").Index).Value = "LOTE"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("producto").Index).Value = "PRODUCTO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("cajas").Index).Value = "CAJAS ACARREO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("cajasVaciado").Index).Value = "CAJAS VACIADO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("cajasPiso").Index).Value = "CAJAS PISO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("peso").Index).Value = "PESO ACARREO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("pesoVaciado").Index).Value = "PESO VACIADO"
        spReporte.Sheets(3).ColumnHeader.Cells(0, spReporte.Sheets(3).Columns("chofer").Index).Value = "CHOFER"

        spReporte.Sheets(3).AlternatingRows.Count = 2
        spReporte.Sheets(3).AlternatingRows(0).BackColor = Color.White
        spReporte.Sheets(3).AlternatingRows(0).BackColor = Color.Azure

    End Sub

    Sub ReportePiso(ByVal lote As Integer, ByVal desde As String, ByVal hasta As String)

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataTable

        Dim consulta As String = String.Empty

        If rbtnCompleto.Checked Then
            consulta = "SELECT Acarreo.Folio, Acarreo.Fecha, LAST(Vaciado.Fecha) AS fechaVaciado, UCASE(FORMAT(acarreo.Hora, 'Medium Time')), embarcador.nombre, lote.descri, producto.descex, Acarreo.Cajas as sumcajas, SUM(Vaciado.cajas) as CajasVaciado, Acarreo.Cajas-IIf(IsNull(SUM(Vaciado.Cajas)),0,SUM(Vaciado.Cajas)) AS CajasPiso, Acarreo.Peso as sumpeso, SUM(Vaciado.Peso) as pesoVaciado, ChoferesAcarreo.Nombre AS chofer FROM ((((Acarreo LEFT JOIN Vaciado ON (Acarreo.Folio = Vaciado.Folio) AND (Acarreo.Productor = Vaciado.Productor)) INNER JOIN ChoferesAcarreo ON Acarreo.Chofer = ChoferesAcarreo.CODIGO) INNER JOIN Embarcador ON Acarreo.Productor = Embarcador.Codigo) INNER JOIN Lote ON Acarreo.Lote = Lote.CODIGO) INNER JOIN Producto ON Acarreo.Producto = Producto.CODIGO " & ArmaCondicion(lote, String.Empty, desde, hasta) & " GROUP BY acarreo.folio, acarreo.fecha, embarcador.nombre, lote.descri, producto.descex, Acarreo.Cajas, ChoferesAcarreo.Nombre, Acarreo.Hora, Acarreo.Folio, Acarreo.Cajas, Acarreo.Peso"
        Else
            consulta = "SELECT Acarreo.Folio, Acarreo.fecha, LAST(Vaciado.Fecha) AS fechaVaciado, UCASE(FORMAT(acarreo.Hora, 'Medium Time')), embarcador.nombre, lote.descri, producto.descex, Acarreo.Cajas as sumcajas, SUM(Vaciado.cajas) as CajasVaciado, Acarreo.Cajas-IIf(IsNull(SUM(Vaciado.Cajas)),0,SUM(Vaciado.Cajas)) AS CajasPiso, Acarreo.Peso as sumpeso, SUM(Vaciado.Peso) as pesoVaciado, ChoferesAcarreo.Nombre AS chofer FROM ((((Acarreo LEFT JOIN Vaciado ON (Acarreo.Folio = Vaciado.Folio) AND (Acarreo.Productor = Vaciado.Productor)) INNER JOIN ChoferesAcarreo ON Acarreo.Chofer = ChoferesAcarreo.CODIGO) INNER JOIN Embarcador ON Acarreo.Productor = Embarcador.Codigo) INNER JOIN Lote ON Acarreo.Lote = Lote.CODIGO) INNER JOIN Producto ON Acarreo.Producto = Producto.CODIGO " & ArmaCondicion(lote, " Vaciado.Cajas > 0") & " GROUP BY acarreo.folio, acarreo.fecha, embarcador.nombre, lote.descri, producto.descex, Acarreo.Cajas, ChoferesAcarreo.Nombre, Acarreo.Hora, Acarreo.Folio, Acarreo.Cajas, Acarreo.Peso"
        End If

        'PROPIEDADES GENERALES DEL SPREAD
        cmd = New OleDbCommand(consulta, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
            If rbtnParciales.Checked Then
                ' Se borran los que existen con ceros o menor a cero.
                Dim contador As Integer = 0
                For Each row As DataRow In rst.Select
                    contador += 1
                    Dim valor As Integer = row("CajasPiso")
                    If valor <= 0 Then
                        rst.AcceptChanges()
                        rst.Rows.Remove(row)
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("Error al obtener reporte de piso. " & ex.Message)
            Exit Sub
        End Try
        spReporte.Sheets(3).DataSource = rst
        FormatoReporte()

    End Sub


    Sub ReporteVaciado(ByVal lote As Integer, ByVal desde As String, ByVal hasta As String)

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataTable

        Dim consulta As String = "SELECT Format(Hora,'HH:00') as Hora " & ArmaBandasVaciado(desde, hasta) & " FROM Vaciado WHERE " & ArmaCondicionVaciado(desde, hasta) & " GROUP BY Format(Hora,'HH:00') "

        'PROPIEDADES GENERALES DEL SPREAD
        cmd = New OleDbCommand(consulta, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener reporte de vaciado por horas y bandas. " & ex.Message)
            Exit Sub
        End Try
        If rst.Rows.Count > 0 Then
            rst.Columns.Add("TOTAL")

            For columna = 0 To rst.Columns.Count - 1
                'Dim valor As String = rst.Columns(columna).ToString
                rst.Columns(columna).ColumnName = rst.Columns(columna).ToString.Replace("_", " ")
            Next

            spReporte.Sheets(0).DataSource = rst
            FormatoReporte()
            CalcularTotalesBanda()
            CalcularTotalesHora()
        Else
            rst.Clear()
            spReporte.Sheets(0).DataSource = rst
        End If


    End Sub

    Private Sub CalcularTotalesBanda()

        Dim ultimaFila As Integer = spReporte.Sheets(0).Rows.Count
        spReporte.Sheets(0).AddRows(ultimaFila, 2)
        ultimaFila += 1
        spReporte.Sheets(0).Cells(ultimaFila, 0).Text = "TOTAL"
        For columna = 1 To spReporte.Sheets(0).Columns.Count - 1
            Dim contadorBanda As Integer = 0
            For fila = 0 To ultimaFila - 1
                Dim valor As String = spReporte.Sheets(0).Cells(fila, columna).Text
                If IsNumeric(valor) Then
                    contadorBanda += spReporte.Sheets(0).Cells(fila, columna).Text
                End If
            Next
            spReporte.Sheets(0).Cells(ultimaFila, columna).Text = contadorBanda
        Next

    End Sub

    Private Sub CalcularTotalesHora()

        Dim ultimaColumna As Integer = spReporte.Sheets(0).Columns.Count - 1
        'spReporte.Sheets(0).AddColumns(ultimaColumna, 1)
        'spReporte.Sheets(0).ColumnHeader.Cells(0, ultimaColumna).Text = "TOTAL"
        For fila = 0 To spReporte.Sheets(0).Rows.Count - 1
            Dim contadorHora As Integer = 0
            For columna = 1 To ultimaColumna - 1
                Dim valor As String = spReporte.Sheets(0).Cells(fila, columna).Text
                If IsNumeric(valor) Then
                    contadorHora += spReporte.Sheets(0).Cells(fila, columna).Text
                End If
            Next
            spReporte.Sheets(0).Cells(fila, ultimaColumna).Text = contadorHora
        Next

        ' Para quitar el cero de la penultima fila de los totales.
        spReporte.Sheets(0).Cells(spReporte.Sheets(0).Rows.Count - 2, ultimaColumna).Text = String.Empty

    End Sub

    Sub ReporteTotales(ByVal lote As Integer, ByVal desde As String, ByVal hasta As String)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim lRow As Integer = 0

        spReporte.Sheets(1).ClearRange(0, 0, spReporte.ActiveSheet.RowCount, spReporte.ActiveSheet.ColumnCount, False)
        spReporte.Sheets(1).ClearSpanCells()

        'PROPIEDADES GENERALES DEL SPREAD
        cmd = New OleDbCommand("select embarcador.nombre, lote.descri, producto.descex, sum(acarreo.cajas) as sumcajas, " & _
        " sum(acarreo.peso) as sumpeso " & _
        " from acarreo, embarcador, lote, producto " & _
        " where acarreo.productor = embarcador.codigo " & _
        " and acarreo.lote = lote.codigo " & _
        " and acarreo.producto = producto.codigo " & _
        ArmaCondicion(lote, desde, hasta) & _
        " group by embarcador.nombre, lote.descri, producto.descex, embarcador.codigo, lote.codigo " & _
        " order by embarcador.codigo, lote.codigo ", conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener reporte de totales. " & ex.Message)
            Exit Sub
        End Try
        spReporte.Sheets(1).DataSource = rst
        FormatoReporte()

        spReporte.Sheets(1).AddRows(spReporte.Sheets(1).RowCount, 2)

        lRow = spReporte.Sheets(1).RowCount - 1

        'COMBINACION DE CELDAS
        spReporte.Sheets(1).AddSpanCell(lRow, 0, 1, 3)

        'FORMATO
        spReporte.Sheets(1).Cells(lRow, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right

        spReporte.Sheets(1).Cells(lRow, 0).Text = "TOTAL:"

        'CONSULTA DE TOTAL GENERAL
        rst = New DataSet
        cmd = New OleDbCommand("select sum(cajas) as sumcajas, sum(peso) as sumpeso " & _
        " from acarreo " & _
        " where folio <> '' " & _
        ArmaCondicion(lote, desde, hasta), conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener total general. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            spReporte.Sheets(1).Cells(lRow, spReporte.Sheets(1).Columns("cajas").Index).Text = isnull(rst.Tables(0).Rows(0).Item("sumcajas"), 0)
            spReporte.Sheets(1).Cells(lRow, spReporte.Sheets(1).Columns("peso").Index).Text = isnull(rst.Tables(0).Rows(0).Item("sumpeso"), 0)
        End If

    End Sub

    Sub ReporteRendimientos(ByVal grupolote As Integer, ByVal desde As String, ByVal hasta As String)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet

        'PROPIEDADES GENERALES DEL SPREAD
        cmd = New OleDbCommand("select  lote.descri as nombre, palets.producto, producto.descex, sum(iif(tipo = 2, sumbultos, 0)) as cajasacarreo, sum(iif(tipo = 1, sumbultos, 0)) as bultospalets, " & _
        " iif(cajasacarreo = 0, 0, bultospalets/cajasacarreo) as rendimientobultos, " & _
        " sum(iif(tipo = 2, sumpeso, 0)) as pesoacarreo, sum(iif(tipo = 1, sumpeso, 0)) as pesopalets, " & _
        " iif(pesoacarreo = 0, 0, pesopalets/pesoacarreo) as rendimientopeso " & _
        " from (select sum(palets.bultos) as sumbultos, sum(palets.peso*palets.bultos) as sumpeso, lote.descri, producto.descex, palets.lote, palets.producto, palets.fechaempaque as fecha,  " & _
        " 1 as tipo " & _
        " from palets, lote,  producto " & _
        " where palets.lote = lote.codigo " & _
        " and palets.producto = producto.codigo " & _
         ArmaCondicionRendimientosPallets(grupolote, desde, hasta) & _
        " group by palets.lote, palets.productor, palets.producto, palets.fechaempaque, lote.descri, palets.lote, producto.descex " & _
        " UNION " & _
        " select sum(acarreo.cajas) as sumbultos, sum(acarreo.peso) as sumpeso, lote.descri, producto.descex, acarreo.lote, acarreo.producto, acarreo.fecha, 2 as tipo  " & _
        " from acarreo, lote,  producto " & _
        " where acarreo.lote = lote.codigo " & _
        " and acarreo.producto = producto.codigo " & _
        ArmaCondicionRendimientosAcarreo(grupolote, desde, hasta) & _
        " group by acarreo.lote, acarreo.productor, acarreo.producto, acarreo.fecha,  lote.descri, acarreo.lote, producto.descex) as tabla1 " & _
        " group by lote.descri, palets.producto, producto.descex " & _
        " order by lote.descri ", conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener reporte de rendimientos. " & ex.Message)
            Exit Sub
        End Try
        spReporte.Sheets(2).DataSource = rst
        FormatoReporte()
    End Sub

    Function ArmaCondicion(ByVal lote As Integer, ByVal where As String, ByVal desde As String, ByVal hasta As String) As String

        Dim condicion As String = String.Empty
        If lote > -1 Then
            condicion = " WHERE Acarreo.Lote = " & lote

            If Not String.IsNullOrEmpty(where) Then
                condicion &= " AND " & where
            End If
        Else
            If Not String.IsNullOrEmpty(where) Then
                condicion &= " WHERE " & where
            End If
        End If

        If Not String.IsNullOrEmpty(condicion) Then
            condicion &= " and Acarreo.fecha >= #" & desde & "# "
            condicion &= " and Acarreo.fecha <= #" & hasta & "# "
        Else
            condicion &= " WHERE Acarreo.fecha >= #" & desde & "# "
            condicion &= " and Acarreo.fecha <= #" & hasta & "# "
        End If

        Return condicion

    End Function

    Function ArmaCondicion(ByVal lote As Integer, ByVal where As String) As String

        Dim condicion As String = String.Empty
        If lote > -1 Then
            condicion = " WHERE Acarreo.Lote = " & lote

            If Not String.IsNullOrEmpty(where) Then
                condicion &= " AND " & where
            End If
        Else
            If Not String.IsNullOrEmpty(where) Then
                condicion &= " WHERE " & where
            End If
        End If
        Return condicion

    End Function


    Function ArmaCondicionVaciado(ByVal desde As String, ByVal hasta As String) As String

        Dim condicion As String = String.Empty
        condicion = condicion & " fecha >= #" & desde & "# "
        condicion = condicion & " and fecha <= #" & hasta & "# "
        Return condicion

    End Function

    Function ArmaBandasVaciado(ByVal desde As String, ByVal hasta As String) As String

        Dim condicion As String = String.Empty
        Dim condicionsuma As String = String.Empty
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim consulta As String = "SELECT Banda, SUM(Cajas) AS Cajas FROM Vaciado WHERE Fecha BETWEEN #" & String.Format(desde, "MM/dd/yyyy") & "# AND #" & String.Format(hasta, "MM/dd/yyyy") & "# GROUP BY Banda ORDER BY Banda ASC "
        cmd = New OleDbCommand(consulta, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener bandas en las fechas indicadas. " & ex.Message)
            Return ""
        End Try
        For i As Integer = 0 To rst.Tables(0).Rows.Count - 1
            condicionsuma &= ", SUM(IIF(Banda = " & rst.Tables(0).Rows(i).Item("Banda") & ", Cajas, null)) AS Banda_" & rst.Tables(0).Rows(i).Item("Banda") & ""
        Next
        If rst.Tables(0).Rows.Count > 0 Then
            columnasBandas = rst.Tables(0).Rows.Count + 2
        Else
            columnasBandas = -1
        End If
        Return condicionsuma

    End Function


    Function ArmaCondicion(ByVal lote As Integer, ByVal desde As String, ByVal hasta As String) As String
        Dim condicion As String = ""

        If lote > -1 Then
            condicion = " and lote = " & lote
        End If
        condicion = condicion & " and fecha >= #" & desde & "# "
        condicion = condicion & " and fecha <= #" & hasta & "# "

        Return condicion
    End Function

    Function ArmaCondicionRendimientosPallets(ByVal grupolote As Integer, ByVal desde As String, ByVal hasta As String)
        Dim condicion As String = ""
        If grupolote > -1 Then
            condicion = " and lote.codigo = " & grupolote
        End If
        condicion = condicion & " and palets.fechaempaque >= #" & desde & "# "
        condicion = condicion & " and palets.fechaempaque <= #" & hasta & "# "
        Return condicion
    End Function

    Function ArmaCondicionRendimientosAcarreo(ByVal grupolote As Integer, ByVal desde As String, ByVal hasta As String)
        Dim condicion As String = ""
        If grupolote > -1 Then
            condicion = " and lote.codigo = " & grupolote
        End If
        condicion = condicion & " and acarreo.fecha >= #" & desde & "# "
        condicion = condicion & " and acarreo.fecha <= #" & hasta & "# "
        Return condicion
    End Function

#End Region

#Region "EVENTOS"

    Private Sub btnAtrasPalletsDesde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtrasPalletsDesde.Click, btnAdelantePalletsDesde.Click, btnAtrasPalletsHasta.Click, btnAdelantePalletsHasta.Click
        'INCREMENTA DIA EN FECHA INICIAL y realiza consulta
        If sender.Equals(btnAdelantePalletsDesde) Then
            If IsDate(txtFechaDesde.Text) Then
                txtFechaDesde.Text = CDate(txtFechaDesde.Text).AddDays(1)
            Else
                MsgBox("Fecha invalida")
                txtFechaDesde.Focus()
                Exit Sub
            End If
            'DECREMENTA DIA EN FECHA INICIAL y realiza consulta
        ElseIf sender.Equals(btnAtrasPalletsDesde) Then
            If IsDate(txtFechaDesde.Text) Then
                txtFechaDesde.Text = CDate(txtFechaDesde.Text).AddDays(-1)
            Else
                MsgBox("Fecha invalida")
                txtFechaDesde.Focus()
                Exit Sub
            End If
            'DECREMENTA DIA EN FECHA FINAL y realiza consulta
        ElseIf sender.Equals(btnAtrasPalletsHasta) Then
            If IsDate(txtFechaHasta.Text) Then
                txtFechaHasta.Text = CDate(txtFechaHasta.Text).AddDays(-1)
            Else
                MsgBox("Fecha invalida")
                txtFechaHasta.Focus()
                Exit Sub
            End If
            'INCREMENTA DIA EN FECHA FINAL y realiza consulta
        ElseIf sender.Equals(btnAdelantePalletsHasta) Then
            If IsDate(txtFechaHasta.Text) Then
                txtFechaHasta.Text = CDate(txtFechaHasta.Text).AddDays(1)
            Else
                MsgBox("Fecha invalida")
                txtFechaHasta.Focus()
                Exit Sub
            End If
        End If
        If IsDate(txtFechaDesde.Text) And IsDate(txtFechaHasta.Text) Then
            If spReporte.ActiveSheetIndex = 0 Then
                ReporteVaciado(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 1 Then
                ReporteTotales(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 2 Then
                ReporteRendimientos(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 3 Then
                'rbtnCompleto.Visible = True
                'rbtnParciales.Visible = True
                ReportePiso(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
                'Exit Sub
            End If

            'rbtnCompleto.Visible = False
            'rbtnParciales.Visible = False
        End If
    End Sub

    Private Sub cboLotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotes.SelectedIndexChanged
        If IsDate(txtFechaDesde.Text) And IsDate(txtFechaHasta.Text) Then
            If spReporte.ActiveSheetIndex = 0 Then
                ReporteVaciado(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 1 Then
                ReporteTotales(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 2 Then
                ReporteRendimientos(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 3 Then
                ReportePiso(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Dim header1 As String = ""
        Dim header2 As String = ""
        Dim header3 As String = ""
        Dim header4 As String = ""
        Dim printset As New FarPoint.Win.Spread.PrintInfo()
        header1 = "/c/fz""12""" & "/fb1" & Enc1 & "/fb0" & "/r/fz""10"" Fecha: " & Today.ToShortDateString
        header2 = "/c/fz""10""" & MenuDomicilioEmpresa & "/r/fz""8"" Hora: " & Now.ToShortTimeString
        header3 = "/c/fz""10""" & MenuLocalidadEmpresa & "/r/fz""8"" Usuario: " & Usuar
        printset.Orientation = FarPoint.Win.Spread.PrintOrientation.Auto
        printset.PrintType = FarPoint.Win.Spread.PrintType.All
        printset.ShowBorder = False
        printset.Centering = FarPoint.Win.Spread.Centering.Horizontal
        printset.Margin.Top = 70
        printset.Margin.Right = 20
        printset.Margin.Bottom = 20
        header4 = "/c/fz""10""" & "/fb1 " & spReporte.ActiveSheet.SheetName & " del " & txtFechaDesde.Text & " al " & txtFechaHasta.Text & ", Lote " & cboLotes.Text & "/fb0" & "/r/fz""8"" Página /p de /pc"

        If spReporte.ActiveSheetIndex = 3 And spReporte.Sheets(3).Columns.Count > 8 Then
            printset.Margin.Top = 20
            printset.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape
            If spReporte.Sheets(3).Columns.Count > 10 Then
                printset.ZoomFactor = 0.8
            End If
        End If


        If spReporte.ActiveSheetIndex = 3 And rbtnCompleto.Checked Then
            header4 = "/c/fz""10""" & "/fb1 Reporte Completo De Vaciado del " & txtFechaDesde.Text & " al " & txtFechaHasta.Text & ", Lote " & cboLotes.Text & "/fb0" & "/r/fz""8"" Página /p de /pc"
        ElseIf spReporte.ActiveSheetIndex = 3 And rbtnParciales.Checked Then
            header4 = "/c/fz""10""" & "/fb1 " & spReporte.ActiveSheet.SheetName & ", Lote " & cboLotes.Text & "/fb0" & "/r/fz""8"" Página /p de /pc"
        End If

        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            printset.Header = header1 & "/n" & header2 & "/n" & header3 & "/n" & header4
            printset.Footer = "/l/fb1/fz""12"" Desarrollado por SYS21/fb0"
            printset.Printer = PrintDialog1.PrinterSettings.PrinterName
            spReporte.ActiveSheet.PrintInfo = printset
            spReporte.PrintSheet(spReporte.ActiveSheetIndex)
        End If

    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim Ruta As String
        SaveFileDialog1.Reset()
        SaveFileDialog1.Filter = "(*.xls)|*.xls"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Ruta = SaveFileDialog1.FileName
            spReporte.Sheets(0).ColumnCount = spReporte.Sheets(0).ColumnCount + 1
            spReporte.Sheets(1).ColumnCount = spReporte.Sheets(0).ColumnCount + 1
            spReporte.Sheets(0).RowCount = spReporte.Sheets(0).RowCount + 1
            spReporte.Sheets(1).RowCount = spReporte.Sheets(0).RowCount + 1
            spReporte.SaveExcel(Ruta, FarPoint.Win.Spread.Model.IncludeHeaders.BothCustomOnly)
            MsgBox(("SE GUARDO EXCEL EN:") & vbCrLf & UCase(Ruta), MsgBoxStyle.Information, "REPORTE EMPAQUE")
        End If
        spReporte.Sheets(0).ColumnCount = spReporte.Sheets(0).ColumnCount - 1
        spReporte.Sheets(1).ColumnCount = spReporte.Sheets(0).ColumnCount - 1
        spReporte.Sheets(0).RowCount = spReporte.Sheets(0).RowCount - 1
        spReporte.Sheets(1).RowCount = spReporte.Sheets(0).RowCount - 1
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub spReporte_SheetTabClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.SheetTabClickEventArgs) Handles spReporte.SheetTabClick
        If e.SheetTabIndex = 2 Then
            LlenaGrupoLotes()
        Else
            LlenaLotes()
        End If


        If e.SheetTabIndex = 3 Then
            MostrarTodo()
            ReportePiso(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))

        ElseIf e.SheetTabIndex = 0 Then
            Mostrar()
            ReporteVaciado(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
        Else
            OcultarTodo()
        End If


    End Sub

#End Region

    Private Sub MostrarTodo()

        rbtnCompleto.Visible = True
        rbtnParciales.Visible = True
        Label8.Visible = False
        txtFechaDesde.Visible = False
        btnAtrasPalletsDesde.Visible = False
        btnAdelantePalletsDesde.Visible = False
        Label7.Visible = False
        txtFechaHasta.Visible = False
        btnAtrasPalletsHasta.Visible = False
        btnAdelantePalletsHasta.Visible = False

    End Sub

    Private Sub OcultarTodo()

        rbtnCompleto.Visible = False
        rbtnParciales.Visible = False
        Label8.Visible = True
        txtFechaDesde.Visible = True
        btnAtrasPalletsDesde.Visible = True
        btnAdelantePalletsDesde.Visible = True
        Label7.Visible = True
        txtFechaHasta.Visible = True
        btnAtrasPalletsHasta.Visible = True
        btnAdelantePalletsHasta.Visible = True

    End Sub

   
    Private Sub rbtnParciales_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnParciales.CheckedChanged

        Ocultar()
        Try
            ReportePiso(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
        Catch
        End Try

    End Sub

    Private Sub rbtnCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCompleto.CheckedChanged

        Mostrar()
        Try
            ReportePiso(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
        Catch
        End Try

    End Sub

    Private Sub Mostrar()

        Label8.Visible = True
        txtFechaDesde.Visible = True
        btnAtrasPalletsDesde.Visible = True
        btnAdelantePalletsDesde.Visible = True
        Label7.Visible = True
        txtFechaHasta.Visible = True
        btnAtrasPalletsHasta.Visible = True
        btnAdelantePalletsHasta.Visible = True

    End Sub

    Private Sub Ocultar()

        Label8.Visible = False
        txtFechaDesde.Visible = False
        btnAtrasPalletsDesde.Visible = False
        btnAdelantePalletsDesde.Visible = False
        Label7.Visible = False
        txtFechaHasta.Visible = False
        btnAtrasPalletsHasta.Visible = False
        btnAdelantePalletsHasta.Visible = False

    End Sub

    Private Sub ReportesVaciado_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        If spReporte.ActiveSheetIndex = 0 Then
            OcultarTodo()
            'MostrarTodo()
            ReporteVaciado(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
        ElseIf spReporte.ActiveSheetIndex = 3 Then
            If rbtnCompleto.Checked Then
                Mostrar()
            Else
                Ocultar()
            End If
        Else
            Ocultar()
        End If

    End Sub

End Class