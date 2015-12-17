Imports System.Data.OleDb
Public Class ReportesAcarreo

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
        spReporte.Sheets.Count = 3
        spReporte.Sheets(0).SheetName = "Reporte General"
        spReporte.Sheets(1).SheetName = "Totales por Lote"
        spReporte.Sheets(2).SheetName = "Rendimientos"

        ' Se oculta el reporte de rendimientos de acarreo.
        spReporte.Sheets(2).Visible = False

        'FORMATO DEL REPORTE GENERAL
        spReporte.Sheets(0).ColumnCount = 9
        spReporte.Sheets(0).GrayAreaBackColor = Color.White

        'TAGS DE COLUMNAS
        spReporte.Sheets(0).Columns(0).Tag = "folio"
        spReporte.Sheets(0).Columns(1).Tag = "fecha"
        spReporte.Sheets(0).Columns(2).Tag = "hora"
        spReporte.Sheets(0).Columns(3).Tag = "productor"
        spReporte.Sheets(0).Columns(4).Tag = "lote"
        spReporte.Sheets(0).Columns(5).Tag = "producto"
        spReporte.Sheets(0).Columns(6).Tag = "cajas"
        spReporte.Sheets(0).Columns(7).Tag = "peso"
        spReporte.Sheets(0).Columns(8).Tag = "chofer"

        'TIPOS DE CELDAS
        spReporte.Sheets(0).Columns("folio").CellType = tipotxt
        spReporte.Sheets(0).Columns("productor").CellType = tipotxt
        spReporte.Sheets(0).Columns("lote").CellType = tipotxt
        spReporte.Sheets(0).Columns("producto").CellType = tipotxt
        spReporte.Sheets(0).Columns("cajas").CellType = tipoint
        spReporte.Sheets(0).Columns("peso").CellType = tipodob
        spReporte.Sheets(0).Columns("chofer").CellType = tipotxt
        'spReporte.Sheets(0).Columns("hora").CellType = tipoHora


        'ANCHO DE COLUMNAS
        spReporte.Sheets(0).Columns("folio").Width = 50
        spReporte.Sheets(0).Columns("fecha").Width = 70
        spReporte.Sheets(0).Columns("hora").Width = 65
        spReporte.Sheets(0).Columns("productor").Width = 250
        spReporte.Sheets(0).Columns("lote").Width = 100
        spReporte.Sheets(0).Columns("producto").Width = 90
        spReporte.Sheets(0).Columns("cajas").Width = 50
        spReporte.Sheets(0).Columns("peso").Width = 65
        spReporte.Sheets(0).Columns("chofer").Width = 170
        spReporte.Sheets(0).RowHeader.Columns(0).Width = 35

        'ALTURA DE FILAS
        spReporte.Sheets(0).ColumnHeader.Rows(0).Height = 40

        'ENCABEZADOS DE COLUMNAS
        spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("folio").Index).Value = "FOLIO"
        spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("fecha").Index).Value = "FECHA"
        spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("hora").Index).Value = "HORA"
        spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("productor").Index).Value = "PRODUCTOR"
        spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("lote").Index).Value = "LOTE"
        spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("producto").Index).Value = "PRODUCTO"
        spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("cajas").Index).Value = "CAJAS"
        spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("peso").Index).Value = "PESO"
        spReporte.Sheets(0).ColumnHeader.Cells(0, spReporte.Sheets(0).Columns("chofer").Index).Value = "CHOFER"

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
    End Sub

    Private Sub CalcularTotalesGenerales()

        Dim ultimaFila As Integer = spReporte.Sheets(0).Rows.Count
        spReporte.Sheets(0).AddRows(ultimaFila, 2)
        ultimaFila += 1
        spReporte.Sheets(0).Cells(ultimaFila, 0).Text = "TOTAL"
        For columna = 6 To 7
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

    Sub ReporteAcarreo(ByVal lote As Integer, ByVal desde As String, ByVal hasta As String)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet

        'PROPIEDADES GENERALES DEL SPREAD
        cmd = New OleDbCommand("select acarreo.folio, acarreo.fecha, UCASE(FORMAT(acarreo.Hora, 'Medium Time')), embarcador.nombre, lote.descri, producto.descex, sum(acarreo.cajas) as sumcajas, " & _
        " sum(acarreo.peso) as sumpeso, ChoferesAcarreo.Nombre AS chofer " & _
        " from acarreo, embarcador, lote, producto, ChoferesAcarreo " & _
        " where acarreo.productor = embarcador.codigo " & _
        " and acarreo.lote = lote.codigo " & _
        " and acarreo.producto = producto.codigo " & _
                " AND Acarreo.Chofer = ChoferesAcarreo.Codigo " & _
        ArmaCondicion(lote, desde, hasta) & _
        " group by acarreo.folio,acarreo.fecha, embarcador.nombre, lote.descri, producto.descex, ChoferesAcarreo.Nombre, Acarreo.Hora " & _
        " order by acarreo.fecha, acarreo.folio ", conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener reporte de acarreo. " & ex.Message)
            Exit Sub
        End Try
        spReporte.Sheets(0).DataSource = rst
        FormatoReporte()
        CalcularTotalesGenerales()
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
                ReporteAcarreo(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 1 Then
                ReporteTotales(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 2 Then
                ReporteRendimientos(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            End If
        End If
    End Sub

    Private Sub cboLotes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotes.SelectedIndexChanged
        If IsDate(txtFechaDesde.Text) And IsDate(txtFechaHasta.Text) Then
            If spReporte.ActiveSheetIndex = 0 Then
                ReporteAcarreo(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 1 Then
                ReporteTotales(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
            ElseIf spReporte.ActiveSheetIndex = 2 Then
                ReporteRendimientos(cboLotes.SelectedValue, Mid(txtFechaDesde.Text, 4, 3) & Mid(txtFechaDesde.Text, 1, 3) & Mid(txtFechaDesde.Text, 7, 4), Mid(txtFechaHasta.Text, 4, 3) & Mid(txtFechaHasta.Text, 1, 3) & Mid(txtFechaHasta.Text, 7, 4))
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
        printset.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait
        printset.PrintType = FarPoint.Win.Spread.PrintType.All
        printset.ShowBorder = False
        printset.Centering = FarPoint.Win.Spread.Centering.Horizontal
        printset.Margin.Top = 70
        printset.Margin.Right = 20
        printset.Margin.Bottom = 20
        header4 = "/c/fz""10""" & "/fb1Reporte de Acarreo " & spReporte.ActiveSheet.SheetName & " del " & txtFechaDesde.Text & " al " & txtFechaHasta.Text & ", Lote " & cboLotes.Text & "/fb0" & "/r/fz""8"" Página /p de /pc"
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
    End Sub

#End Region

End Class