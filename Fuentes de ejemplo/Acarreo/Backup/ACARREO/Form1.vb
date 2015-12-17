Imports System.Data.OleDb
Public Class Form1

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Shell("\ASYS21\sys21.exe", AppWinStyle.NormalFocus)
            End
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()
        ConsultaPuntoRetorno()
        Encabezado1.Text = Enc1
        Encabezado2.Text = Enc2
        Encabezado3.Text = Enc3
        Try
            PictureBox1.Image = Image.FromFile(Logodir)
        Catch
            PictureBox1.Image = Nothing
        End Try
        txtFecha.Text = Today
        txtHora.Text = Now.ToShortTimeString
        conexion(Conecta & "\empaque.mdb")
        cnn.Open()
        txtFolio.Text = ObtieneNuevoFolio()
        FormatoSpread(1)
    End Sub

#Region "Métodos"

    Sub MapeoSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)
        Dim im As FarPoint.Win.Spread.InputMap
        Dim im2 As FarPoint.Win.Spread.InputMap
        im = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        im = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        im2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        im2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
    End Sub

    Sub FormatoSpread(ByVal filas As Integer)
        Dim tipotxt As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tipoint As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tipodob As New FarPoint.Win.Spread.CellType.NumberCellType

        'PROPIEDADES DE CELDAS
        tipotxt.WordWrap = True
        tipoint.DecimalPlaces = 0
        tipoint.Separator = ","
        tipoint.MinimumValue = 0
        tipoint.ShowSeparator = True
        tipodob.DecimalPlaces = 2
        tipodob.MinimumValue = 0
        tipodob.ShowSeparator = True
        tipodob.Separator = ","

        'FORMATO GENERAL SPREAD

        MapeoSpread(spAcarreo)
        spAcarreo.Size = New Size(556, 304)
        spAcarreo.Location = New Point(14, 283)
        spAcarreo.TabStripInsertTab = False
        spAcarreo.Sheets.Count = 1
        spAcarreo.ActiveSheet.GrayAreaBackColor = Color.White
        spAcarreo.Font = New Font("microsoft sans serif", 8.25, FontStyle.Bold)
        spAcarreo.ActiveSheet.RowCount = filas
        spAcarreo.ActiveSheet.ColumnCount = 5

        'TAGS DE COLUMNAS
        spAcarreo.ActiveSheet.Columns(0).Tag = "cajas"
        spAcarreo.ActiveSheet.Columns(1).Tag = "pesobruto"
        spAcarreo.ActiveSheet.Columns(2).Tag = "mermacaja"
        spAcarreo.ActiveSheet.Columns(3).Tag = "mermatarima"
        spAcarreo.ActiveSheet.Columns(4).Tag = "peso"

        spAcarreo.ActiveSheet.Columns("pesobruto").Visible = False
        spAcarreo.ActiveSheet.Columns("mermacaja").Visible = False
        spAcarreo.ActiveSheet.Columns("mermatarima").Visible = False
        'spAcarreo.activesheet.columns("pesobruto").Visible = false

        'ALTURA DE FILAS
        spAcarreo.ActiveSheet.ColumnHeader.Rows(0).Height = 40

        'ANCHURA DE COLUMNAS
        spAcarreo.ActiveSheet.RowHeader.Columns(0).Width = 35
        spAcarreo.ActiveSheet.Columns("cajas").Width = 100
        spAcarreo.ActiveSheet.Columns("pesobruto").Width = 100
        spAcarreo.ActiveSheet.Columns("mermacaja").Width = 100
        spAcarreo.ActiveSheet.Columns("mermatarima").Width = 100
        spAcarreo.ActiveSheet.Columns("peso").Width = 100

        'TIPOS DE CELDAS
        spAcarreo.ActiveSheet.Columns("cajas").CellType = tipoint
        spAcarreo.ActiveSheet.Columns("pesobruto").CellType = tipodob
        spAcarreo.ActiveSheet.Columns("mermacaja").CellType = tipodob
        spAcarreo.ActiveSheet.Columns("mermatarima").CellType = tipodob
        spAcarreo.ActiveSheet.Columns("peso").CellType = tipodob

        'TEXTO DE ENCABEZADOS
        spAcarreo.ActiveSheet.ColumnHeader.Cells(0, spAcarreo.ActiveSheet.Columns("cajas").Index).Text = "CAJAS"
        spAcarreo.ActiveSheet.ColumnHeader.Cells(0, spAcarreo.ActiveSheet.Columns("pesobruto").Index).Text = "KG. TOTAL"
        spAcarreo.ActiveSheet.ColumnHeader.Cells(0, spAcarreo.ActiveSheet.Columns("mermacaja").Index).Text = "PESO CAJAS"
        spAcarreo.ActiveSheet.ColumnHeader.Cells(0, spAcarreo.ActiveSheet.Columns("mermatarima").Index).Text = "PESO TARIMA"
        spAcarreo.ActiveSheet.ColumnHeader.Cells(0, spAcarreo.ActiveSheet.Columns("peso").Index).Text = "PESO TOTAL"

    End Sub

    Sub ManejoSpread()
        Dim aRow As Integer = spAcarreo.ActiveSheet.ActiveRowIndex
        If spAcarreo.ActiveSheet.ActiveColumnIndex = spAcarreo.ActiveSheet.Columns("cajas").Index Then
            If IsNumeric(spAcarreo.ActiveSheet.Cells(aRow, spAcarreo.ActiveSheet.Columns("cajas").Index).Text) And IsNumeric(txtIdProducto.Text) Then
                spAcarreo.ActiveSheet.Cells(aRow, spAcarreo.ActiveSheet.Columns("peso").Index).Text = spAcarreo.ActiveSheet.Cells(aRow, spAcarreo.ActiveSheet.Columns("cajas").Index).Text * ObtenerPesoCampo(txtIdLote.Text)
            End If
        ElseIf spAcarreo.ActiveSheet.ActiveColumnIndex = spAcarreo.ActiveSheet.Columns("mermatarima").Index Then
            Dim pesobruto As Double = 0
            Dim mermacaja As Double = 0
            Dim mermatarima As Double = 0
            If IsNumeric(spAcarreo.ActiveSheet.Cells(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("pesobruto").Index).Text) Then
                pesobruto = spAcarreo.ActiveSheet.Cells(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("pesobruto").Index).Text
                If IsNumeric(spAcarreo.ActiveSheet.Cells(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("mermacaja").Index).Text) Then
                    mermacaja = spAcarreo.ActiveSheet.Cells(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("mermacaja").Index).Text
                Else
                    spAcarreo.ActiveSheet.Cells(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("mermacaja").Index).Text = 0
                    mermacaja = 0
                End If
                If IsNumeric(spAcarreo.ActiveSheet.Cells(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("mermatarima").Index).Text) Then
                    mermatarima = spAcarreo.ActiveSheet.Cells(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("mermatarima").Index).Text
                Else
                    spAcarreo.ActiveSheet.Cells(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("mermatarima").Index).Text = 0
                    mermatarima = 0
                End If
                spAcarreo.ActiveSheet.Cells(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("peso").Index).Text = pesobruto - mermacaja - mermatarima
            Else
                spAcarreo.ActiveSheet.SetActiveCell(spAcarreo.ActiveSheet.ActiveRowIndex, spAcarreo.ActiveSheet.Columns("pesobruto").Index - 1)
            End If
        ElseIf spAcarreo.ActiveSheet.ActiveColumnIndex = spAcarreo.ActiveSheet.Columns("peso").Index Then
            txtTotal.Text = Format(Sumatoria(), "###,###.00")
            If spAcarreo.ActiveSheet.ActiveRowIndex = spAcarreo.ActiveSheet.RowCount - 1 Then
                spAcarreo.ActiveSheet.AddRows(spAcarreo.ActiveSheet.RowCount, 1)
            End If
        End If
    End Sub

    Function ObtenerPesoCampo(ByVal idlote As Integer) As Double
        Dim PesoCampo As Double = 0
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet

        cmd = New OleDbCommand("select pesocampo " & _
        " from lote " & _
        " where codigo = " & idlote, cnn)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener peso de campo. " & ex.Message)
            Return 0
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            PesoCampo = isnull(rst.Tables(0).Rows(0).Item("pesocampo"), 0)
        Else
            PesoCampo = 0
        End If
        Return PesoCampo
    End Function

    Function ObtieneNuevoFolio() As String
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select max(cint(folio)) from acarreo", cnn)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener máximo folio de acarreo. " & ex.Message)
            Return ""
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            Return CStr(isnull(rst.Tables(0).Rows(0).Item(0), 0) + 1).PadLeft(6, "0")
        Else
            Return "000001"
        End If
    End Function

    Sub CargaFolio(ByVal folio As String)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim cmddet As New OleDbCommand
        Dim adapdet As New OleDbDataAdapter
        Dim rstdet As New DataSet
        'ENCABEZADOS
        cmd = New OleDbCommand("select aca.folio as folio, aca.fecha as fecha, aca.hora as hora, aca.productor as idproductor, emb.nombre as productor, " & _
        " aca.producto as idproducto, pro.descex as producto, aca.lote as idlote, lot.descri as lote, sum(peso) as peso " & _
        " from acarreo aca, embarcador emb, producto pro, lote lot " & _
        " where aca.productor = emb.codigo " & _
        " and aca.producto = pro.codigo " & _
        " and aca.lote = lot.codigo " & _
        " and aca.folio = '" & folio & "' " & _
        " group by aca.folio, aca.fecha, aca.hora, aca.productor, emb.nombre, aca.producto, pro.descex, aca.lote, lot.descri", cnn)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener datos de folio. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtFolio.Text = isnull(rst.Tables(0).Rows(0).Item("folio"), "")
            txtFecha.Text = isnull(rst.Tables(0).Rows(0).Item("fecha"), Today.ToShortDateString)
            txtHora.Text = isnull(rst.Tables(0).Rows(0).Item("hora"), Now.ToShortTimeString)
            txtIdProductor.Text = isnull(rst.Tables(0).Rows(0).Item("idproductor"), 0)
            txtProductor.Text = isnull(rst.Tables(0).Rows(0).Item("productor"), "")
            txtIdProducto.Text = isnull(rst.Tables(0).Rows(0).Item("idproducto"), 0)
            txtProducto.Text = isnull(rst.Tables(0).Rows(0).Item("producto"), "")
            txtIdLote.Text = isnull(rst.Tables(0).Rows(0).Item("idlote"), 0)
            txtLote.Text = isnull(rst.Tables(0).Rows(0).Item("lote"), "")
            txtTotal.Text = Format(isnull(rst.Tables(0).Rows(0).Item("peso"), 0), "###,###.00")
            'CARGA DETALLE
            cmddet = New OleDbCommand("select cajas, pesobruto, mermacaja, mermatarima, peso " & _
            " from acarreo " & _
            " where folio = '" & folio & "' " & _
            " order by orden ", cnn)
            adapdet.SelectCommand = cmddet
            Try
                adapdet.Fill(rstdet)
            Catch ex As Exception
                MsgBox("Error al obtener detalles de la entrada. " & ex.Message)
                Exit Sub
            End Try
            spAcarreo.DataSource = rstdet
            FormatoSpread(rstdet.Tables(0).Rows.Count + 1)
        Else
            limpiapantalla()
        End If

    End Sub

    Sub GuardaFolio()
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim folio As String = ""
        Dim fecha As String = Today.ToShortDateString
        Dim hora As String = Now.ToShortTimeString
        Dim productor As Integer = 0
        Dim producto As Integer = 0
        Dim lote As Integer = 0
        Dim cajas As Integer = 0
        Dim pesobruto As Double = 0
        Dim mermacaja As Double = 0
        Dim mermatarima As Double = 0
        Dim peso As Double = 0
        Dim orden As Integer = 0

        If IsNumeric(txtFolio.Text) Then
            folio = txtFolio.Text.PadLeft(6, "0")
        Else
            MsgBox("Indique un número de folio válido")
            Exit Sub
        End If
        If IsNumeric(txtIdProductor.Text) Then
            productor = txtIdProductor.Text
        Else
            MsgBox("Indique un número de productor válido")
            Exit Sub
        End If
        If IsNumeric(txtIdProducto.Text) Then
            producto = txtIdProducto.Text
        Else
            MsgBox("Indique un número de producto válido")
            Exit Sub
        End If
        If IsNumeric(txtIdLote.Text) Then
            lote = txtIdLote.Text
        Else
            MsgBox("Indique un número de lote válido")
            Exit Sub
        End If
        If IsDate(txtFecha.Text) Then
            fecha = txtFecha.Text
        End If
        If IsDate(txtHora.Text) Then
            hora = txtHora.Text
        End If
        'RESETEA REGISTROS DE ACARREO
        cmd = New OleDbCommand("delete from acarreo where folio = '" & folio & "'", cnn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al preparar inserción de acarreo. " & ex.Message)
        End Try
        For i As Integer = 0 To spAcarreo.ActiveSheet.RowCount - 1
            orden = i + 1
            If IsNumeric(spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("cajas").Index).Text) Then
                cajas = spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("cajas").Index).Text
                If IsNumeric(spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("peso").Index).Text) Then
                    peso = spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("peso").Index).Text
                Else
                    MsgBox("Coloque un peso  válido")
                    spAcarreo.ActiveSheet.SetActiveCell(i, 0)
                    Exit Sub
                End If

                cmd = New OleDbCommand("select folio, fecha, hora, productor, producto, lote, cajas, " & _
                " pesobruto, mermacaja, mermatarima, peso, orden " & _
                " from acarreo " & _
                " where folio = '" & folio & "' and orden = " & orden, cnn)
                adap.SelectCommand = cmd
                Try
                    adap.Fill(rst)
                Catch ex As Exception
                    MsgBox("Error al preparar guardado de folio de acarreo. " & ex.Message)
                    Exit Sub
                End Try

                Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(adap)
                builder.GetInsertCommand()
                adap.InsertCommand = builder.GetInsertCommand()
                Dim nueva As DataRow = rst.Tables(0).NewRow()
                nueva("folio") = folio
                nueva("fecha") = fecha
                nueva("hora") = hora
                nueva("productor") = productor
                nueva("producto") = producto
                nueva("lote") = lote
                nueva("cajas") = cajas
                nueva("pesobruto") = pesobruto
                nueva("mermacaja") = mermacaja
                nueva("mermatarima") = mermatarima
                nueva("peso") = peso
                nueva("orden") = orden
                rst.Tables(0).Rows.Add(nueva)
                Try
                    adap.Update(rst)
                Catch ex As Exception
                    MsgBox("Error al insertar folio de acarreo. " & ex.Message)
                    Exit Sub
                End Try
                rst.Dispose()
                rst.Clear()
            End If
        Next

        txtFolio.Text = ObtieneNuevoFolio()
        limpiapantalla()
    End Sub

    Sub CargaProductor(ByVal productor As Integer)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select nombre from embarcador where codigo = " & productor, cnn)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener productor. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtProductor.Text = isnull(rst.Tables(0).Rows(0).Item(0), "")
            txtIdLote.Focus()
        Else
            txtIdProductor.Text = ""
            txtProductor.Text = ""
            txtIdProductor.Focus()
        End If
    End Sub

    Sub CargaProducto(ByVal producto As Integer)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select descex from producto where codigo = " & producto, cnn)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener producto. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtProducto.Text = isnull(rst.Tables(0).Rows(0).Item(0), "")
            spAcarreo.Focus()
            spAcarreo.ActiveSheet.SetActiveCell(0, 0)
        Else
            txtIdProducto.Text = ""
            txtProducto.Text = ""
            txtIdProducto.Focus()
        End If
    End Sub

    Sub CargaLote(ByVal lote As Integer)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select descri from lote where codigo = " & lote, cnn)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener lote. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtLote.Text = isnull(rst.Tables(0).Rows(0).Item(0), "")
            txtIdProducto.Focus()
        Else
            txtIdLote.Text = ""
            txtLote.Text = ""
            txtIdLote.Focus()
        End If
    End Sub

    Sub limpiapantalla()
        txtFecha.Text = Today.ToShortDateString
        txtHora.Text = Now.ToShortTimeString
        txtIdProductor.Text = ""
        txtProductor.Text = ""
        txtIdProducto.Text = ""
        txtProducto.Text = ""
        txtIdLote.Text = ""
        txtLote.Text = ""
        txtTotal.Text = "0.00"
        spAcarreo.Reset()
        FormatoSpread(1)
    End Sub

    Function Sumatoria() As Double
        Dim total As Double = 0
        For i As Integer = 0 To spAcarreo.ActiveSheet.RowCount - 1
            If IsNumeric(spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("peso").Index).Text) Then
                total = total + spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("peso").Index).Text
            End If
        Next
        Return total
    End Function

    Sub EliminaAcarreo(ByVal folio As String)
        Dim cmd As New OleDbCommand
        cmd = New OleDbCommand("delete from acarreo where folio = '" & folio & "'", cnn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al eliminar folio de acarreo. " & ex.Message)
            Exit Sub
        End Try
        limpiapantalla()
    End Sub

    Sub FormatoHistorial()
        Dim tipotxt As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tipofecha As New FarPoint.Win.Spread.CellType.DateTimeCellType
        Dim tipodob As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tipoint As New FarPoint.Win.Spread.CellType.NumberCellType

        'PROPIEDADES DE CELDAS
        tipotxt.WordWrap = True
        tipodob.DecimalPlaces = 2
        tipodob.MinimumValue = 0
        tipodob.ShowSeparator = True
        tipodob.Separator = ","
        tipoint.DecimalPlaces = 0
        tipoint.Separator = ","
        tipoint.MinimumValue = 0
        tipoint.ShowSeparator = True

        'FORMATO GENERAL SPREAD

        MapeoSpread(spAcarreo)
        spHistorial.Size = New Size(405, 420)
        spHistorial.Location = New Point(573, 167)
        spHistorial.TabStripInsertTab = False
        spHistorial.Sheets.Count = 1
        spHistorial.ActiveSheet.GrayAreaBackColor = Color.White
        spHistorial.Font = New Font("microsoft sans serif", 8.25, FontStyle.Bold)
        spHistorial.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        spHistorial.ActiveSheet.ColumnCount = 4

        'TAGS DE COLUMNAS
        spHistorial.ActiveSheet.Columns(0).Tag = "folio"
        spHistorial.ActiveSheet.Columns(1).Tag = "fecha"
        spHistorial.ActiveSheet.Columns(2).Tag = "cajas"
        spHistorial.ActiveSheet.Columns(3).Tag = "peso"

        'ALTURA DE FILAS
        spHistorial.ActiveSheet.ColumnHeader.Rows(0).Height = 40

        'ANCHURA DE COLUMNAS
        spHistorial.ActiveSheet.RowHeader.Columns(0).Width = 35
        spHistorial.ActiveSheet.Columns("folio").Width = 80
        spHistorial.ActiveSheet.Columns("fecha").Width = 80
        spHistorial.ActiveSheet.Columns("cajas").Width = 90
        spHistorial.ActiveSheet.Columns("peso").Width = 100

        'TIPOS DE CELDAS
        spHistorial.ActiveSheet.Columns("folio").CellType = tipotxt
        spHistorial.ActiveSheet.Columns("peso").CellType = tipodob
        spHistorial.ActiveSheet.Columns("cajas").CellType = tipoint
        spHistorial.ActiveSheet.Columns("fecha").CellType = tipofecha

        'FILTROS Y SORTING
        spHistorial.ActiveSheet.Columns("folio").AllowAutoFilter = True
        spHistorial.ActiveSheet.Columns("fecha").AllowAutoFilter = True
        spHistorial.ActiveSheet.Columns("folio").AllowAutoSort = True
        spHistorial.ActiveSheet.Columns("fecha").AllowAutoSort = True

        'TEXTO DE ENCABEZADOS
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("cajas").Index).Text = "CAJAS"
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("folio").Index).Text = "FOLIO"
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("peso").Index).Text = "PESO"
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("fecha").Index).Text = "FECHA"

        spHistorial.Visible = True
    End Sub

    Sub LlenaHistorial()
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet

        cmd = New OleDbCommand("select folio, fecha, sum(cajas) as cajas, sum(peso) as peso " & _
        " from acarreo " & _
        " group by folio, fecha " & _
        " order by folio, fecha", cnn)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener historial. " & ex.Message)
            Exit Sub
        End Try
        spHistorial.DataSource = rst
        FormatoHistorial()
    End Sub

#End Region

#Region "Eventos"
    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Me.Close()
    End Sub

    Private Sub txtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown, txtFecha.KeyDown, txtHora.KeyDown, txtIdProductor.KeyDown, txtIdLote.KeyDown, txtIdProducto.KeyDown
        If e.KeyData = Keys.Enter Then
            If sender.Equals(txtFolio) Then
                e.SuppressKeyPress = True
                If IsNumeric(txtFolio.Text) Then
                    txtFolio.Text = txtFolio.Text.PadLeft(6, "0")
                    CargaFolio(txtFolio.Text)
                    txtFecha.Focus()
                Else
                    txtFolio.Text = ObtieneNuevoFolio()
                    limpiapantalla()
                End If
            ElseIf sender.Equals(txtFecha) Then
                If IsDate(txtFecha.Text) Then
                    e.SuppressKeyPress = True
                    txtIdProductor.Focus()
                End If
            ElseIf sender.Equals(txtHora) Then
                If IsDate(txtHora.Text) Then
                    e.SuppressKeyPress = True
                    txtIdProductor.Focus()
                End If
            ElseIf sender.Equals(txtIdProductor) Then
                If IsNumeric(txtIdProductor.Text) Then
                    e.SuppressKeyPress = True
                    CargaProductor(txtIdProductor.Text)
                Else
                    txtIdProductor.Text = ""
                    txtProductor.Text = ""
                    txtIdProductor.Focus()
                End If
            ElseIf sender.Equals(txtIdProducto) Then
                If IsNumeric(txtIdProducto.Text) Then
                    e.SuppressKeyPress = True
                    CargaProducto(txtIdProducto.Text)
                Else
                    txtIdProducto.Text = ""
                    txtProducto.Text = ""
                    txtIdProducto.Focus()
                End If
            ElseIf sender.Equals(txtIdLote) Then
                If IsNumeric(txtIdLote.Text) Then
                    e.SuppressKeyPress = True
                    CargaLote(txtIdLote.Text)
                Else
                    txtIdLote.Text = ""
                    txtLote.Text = ""
                    txtIdLote.Focus()
                End If
            End If
        ElseIf e.KeyData = Keys.F1 Then
            If sender.Equals(txtIdProductor) Then
                opc = 1
                If Form2.Visible = True Then
                    Form2.Close()
                End If
                Form2.Show()
            ElseIf sender.Equals(txtIdProducto) Then
                opc = 2
                If Form2.Visible = True Then
                    Form2.Close()
                End If
                Form2.Show()
            ElseIf sender.Equals(txtIdLote) Then
                opc = 5
                If Form2.Visible = True Then
                    Form2.Close()
                End If
                Form2.Show()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            e.SuppressKeyPress = True
            SendKeys.Send("+({TAB})")
        End If
    End Sub

    Private Sub txtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress, txtIdLote.KeyPress, txtIdProducto.KeyPress, txtIdProductor.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        GuardaFolio()
    End Sub

    Private Sub spAcarreo_DialogKey(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spAcarreo.DialogKey
        If e.KeyData = Keys.Enter Then
            ManejoSpread()
        ElseIf e.KeyData = Keys.F9 Then
            spAcarreo.ActiveSheet.RemoveRows(spAcarreo.ActiveSheet.ActiveRowIndex, 1)
            spAcarreo.ActiveSheet.AddRows(spAcarreo.ActiveSheet.RowCount, 1)
        End If
    End Sub

    Private Sub spAcarreo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles spAcarreo.KeyDown
        If e.KeyData = Keys.Enter Then
            ManejoSpread()
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If spHistorial.Visible Then
            spHistorial.Visible = False
        Else
            FormatoHistorial()
            LlenaHistorial()
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If MsgBox("¿Desea eliminar el folio en pantalla?", MsgBoxStyle.YesNo, "Eliminar Acarreo") = MsgBoxResult.Yes Then
            EliminaAcarreo(txtFolio.Text.PadLeft(6, "0"))
        End If
    End Sub
#End Region

    Private Sub spHistorial_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles spHistorial.CellDoubleClick
        If IsNumeric(spHistorial.ActiveSheet.Cells(spHistorial.ActiveSheet.ActiveRowIndex, spHistorial.ActiveSheet.Columns("folio").Index).Text) Then
            CargaFolio(spHistorial.ActiveSheet.Cells(spHistorial.ActiveSheet.ActiveRowIndex, spHistorial.ActiveSheet.Columns("folio").Index).Text)
        End If
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        If Form4.Visible = True Then
            Form4.Close()
        End If
        Form4.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
