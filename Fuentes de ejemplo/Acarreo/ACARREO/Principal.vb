Imports System.Data.OleDb
Public Class Principal

    Public factor As Double = 1

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
        txtHora.Text = Now.ToString("HH:mm")
        mskFechaPiso.Text = Today
        mskHoraPiso.Text = Now.ToString("HH:mm")
        conexion(Conecta & "\empaque.mdb")
        conexionAccess.Open()
        txtFolio.Text = ObtieneNuevoFolio()
        txtFolioPiso.Text = ObtieneNuevoFolioPiso()
        FormatoSpread(1)
        FormatoSpreadVaciado(1)
        FormatoSpreadPiso(1)
        Impresion.CargarConfiguracionImpresora()

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
        spAcarreo.Size = New Size(556, 260)
        'spAcarreo.Location = New Point(14, 140)
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
        spAcarreo.ActiveSheet.ColumnHeader.Cells(0, spAcarreo.ActiveSheet.Columns("peso").Index).Text = "UNIDAD DE MEDIDA"

    End Sub

    Private Sub FormatoSpreadPiso(ByVal filas As Integer)

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

        MapeoSpread(fpPiso)
        fpPiso.Size = New Size(556, 260)
        'fpPiso.Location = New Point(14, 140)
        fpPiso.TabStripInsertTab = False
        fpPiso.Sheets.Count = 1
        fpPiso.ActiveSheet.GrayAreaBackColor = Color.White
        fpPiso.Font = New Font("microsoft sans serif", 8.25, FontStyle.Bold)
        fpPiso.ActiveSheet.RowCount = filas
        fpPiso.ActiveSheet.ColumnCount = 6

        'TAGS DE COLUMNAS
        fpPiso.ActiveSheet.Columns(0).Tag = "cajas"
        fpPiso.ActiveSheet.Columns(1).Tag = "pesobruto"
        fpPiso.ActiveSheet.Columns(2).Tag = "mermacaja"
        fpPiso.ActiveSheet.Columns(3).Tag = "mermatarima"
        fpPiso.ActiveSheet.Columns(4).Tag = "peso"
        fpPiso.ActiveSheet.Columns(5).Tag = "cajasEmpaque"

        fpPiso.ActiveSheet.Columns("pesobruto").Visible = False
        fpPiso.ActiveSheet.Columns("mermacaja").Visible = False
        fpPiso.ActiveSheet.Columns("mermatarima").Visible = False
        'fpPiso.activesheet.columns("pesobruto").Visible = false

        'ALTURA DE FILAS
        fpPiso.ActiveSheet.ColumnHeader.Rows(0).Height = 40

        'ANCHURA DE COLUMNAS
        fpPiso.ActiveSheet.RowHeader.Columns(0).Width = 35
        fpPiso.ActiveSheet.Columns("cajas").Width = 100
        fpPiso.ActiveSheet.Columns("pesobruto").Width = 100
        fpPiso.ActiveSheet.Columns("mermacaja").Width = 100
        fpPiso.ActiveSheet.Columns("mermatarima").Width = 100
        fpPiso.ActiveSheet.Columns("peso").Width = 100
        fpPiso.ActiveSheet.Columns("cajasEmpaque").Width = 100

        'TIPOS DE CELDAS
        fpPiso.ActiveSheet.Columns("cajas").CellType = tipodob
        fpPiso.ActiveSheet.Columns("pesobruto").CellType = tipodob
        fpPiso.ActiveSheet.Columns("mermacaja").CellType = tipodob
        fpPiso.ActiveSheet.Columns("mermatarima").CellType = tipodob
        fpPiso.ActiveSheet.Columns("peso").CellType = tipodob
        fpPiso.ActiveSheet.Columns("cajasEmpaque").CellType = tipodob

        'TEXTO DE ENCABEZADOS
        fpPiso.ActiveSheet.ColumnHeader.Cells(0, fpPiso.ActiveSheet.Columns("cajas").Index).Text = "CAJAS B/G"
        fpPiso.ActiveSheet.ColumnHeader.Cells(0, fpPiso.ActiveSheet.Columns("pesobruto").Index).Text = "KG. TOTAL"
        fpPiso.ActiveSheet.ColumnHeader.Cells(0, fpPiso.ActiveSheet.Columns("mermacaja").Index).Text = "PESO CAJAS"
        fpPiso.ActiveSheet.ColumnHeader.Cells(0, fpPiso.ActiveSheet.Columns("mermatarima").Index).Text = "PESO TARIMA"
        fpPiso.ActiveSheet.ColumnHeader.Cells(0, fpPiso.ActiveSheet.Columns("peso").Index).Text = "UNIDAD DE MEDIDA"
        fpPiso.ActiveSheet.ColumnHeader.Cells(0, fpPiso.ActiveSheet.Columns("cajasEmpaque").Index).Text = "CAJAS CAMPO"

    End Sub

    Sub ManejoSpreadPiso()

        Dim aRow As Integer = fpPiso.ActiveSheet.ActiveRowIndex
        If fpPiso.ActiveSheet.ActiveColumnIndex = fpPiso.ActiveSheet.Columns("cajas").Index Then
            If IsNumeric(fpPiso.ActiveSheet.Cells(aRow, fpPiso.ActiveSheet.Columns("cajas").Index).Text) And IsNumeric(txtIdProductoPiso.Text) Then
                If rbtnCajasBlancas.Checked Or rbtnCajasGrises.Checked Then
                    ' Calcula factor.
                    Dim cajas As Double = CDbl(fpPiso.ActiveSheet.Cells(aRow, fpPiso.ActiveSheet.Columns("cajas").Index).Text)
                    cajas = cajas * factor
                    cajas = Math.Round(cajas)
                    fpPiso.ActiveSheet.Cells(aRow, fpPiso.ActiveSheet.Columns("cajasEmpaque").Index).Text = cajas.ToString
                Else
                    fpPiso.ActiveSheet.Cells(aRow, fpPiso.ActiveSheet.Columns("cajasEmpaque").Index).Text = fpPiso.ActiveSheet.Cells(aRow, fpPiso.ActiveSheet.Columns("cajas").Index).Text
                End If
                ' Se puso al lote 1 ya que no maneja en si piso de un lote especifico.
                If rbtnCajasBlancas.Checked Or rbtnCajasGrises.Checked Then
                    fpPiso.ActiveSheet.Cells(aRow, fpPiso.ActiveSheet.Columns("peso").Index).Text = fpPiso.ActiveSheet.Cells(aRow, fpPiso.ActiveSheet.Columns("cajasEmpaque").Index).Text * ObtenerPesoCampo(1)
                Else
                    fpPiso.ActiveSheet.Cells(aRow, fpPiso.ActiveSheet.Columns("peso").Index).Text = fpPiso.ActiveSheet.Cells(aRow, fpPiso.ActiveSheet.Columns("cajas").Index).Text * ObtenerPesoCampo(1)
                End If
            End If
        ElseIf fpPiso.ActiveSheet.ActiveColumnIndex = fpPiso.ActiveSheet.Columns("mermatarima").Index Then
            Dim pesobruto As Double = 0
            Dim mermacaja As Double = 0
            Dim mermatarima As Double = 0
            If IsNumeric(fpPiso.ActiveSheet.Cells(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("pesobruto").Index).Text) Then
                pesobruto = fpPiso.ActiveSheet.Cells(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("pesobruto").Index).Text
                If IsNumeric(fpPiso.ActiveSheet.Cells(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("mermacaja").Index).Text) Then
                    mermacaja = fpPiso.ActiveSheet.Cells(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("mermacaja").Index).Text
                Else
                    fpPiso.ActiveSheet.Cells(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("mermacaja").Index).Text = 0
                    mermacaja = 0
                End If
                If IsNumeric(fpPiso.ActiveSheet.Cells(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("mermatarima").Index).Text) Then
                    mermatarima = fpPiso.ActiveSheet.Cells(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("mermatarima").Index).Text
                Else
                    fpPiso.ActiveSheet.Cells(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("mermatarima").Index).Text = 0
                    mermatarima = 0
                End If
                fpPiso.ActiveSheet.Cells(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("peso").Index).Text = pesobruto - mermacaja - mermatarima
            Else
                fpPiso.ActiveSheet.SetActiveCell(fpPiso.ActiveSheet.ActiveRowIndex, fpPiso.ActiveSheet.Columns("pesobruto").Index - 1)
            End If
        ElseIf fpPiso.ActiveSheet.ActiveColumnIndex = fpPiso.ActiveSheet.Columns("peso").Index Then
            'txtTotalPiso.Text = Format(SumatoriaPesoPiso(), "###,###.00")
            If fpPiso.ActiveSheet.ActiveRowIndex = fpPiso.ActiveSheet.RowCount - 1 Then
                fpPiso.ActiveSheet.AddRows(fpPiso.ActiveSheet.RowCount, 1)
            End If
        End If

    End Sub

    Private Sub ManejoSpread()

        Dim aRow As Integer = spAcarreo.ActiveSheet.ActiveRowIndex
        If spAcarreo.ActiveSheet.ActiveColumnIndex = spAcarreo.ActiveSheet.Columns("cajas").Index Then
            If IsNumeric(spAcarreo.ActiveSheet.Cells(aRow, spAcarreo.ActiveSheet.Columns("cajas").Index).Text) And IsNumeric(txtIdProducto.Text) Then
                txtTotalCajas.Text = Format(SumatoriaCajas(), "###,###.00")
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
            txtTotalMedida.Text = Format(SumatoriaPeso(), "###,###.00")
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
        " where codigo = " & idlote, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener peso de campo. " & ex.Message, MsgBoxStyle.Critical, "Error de consulta.")
            Return 0
        End Try
        ' Está a 30 porque ellos lo manejan a 30.
        If rst.Tables(0).Rows.Count > 0 Then
            PesoCampo = isnull(rst.Tables(0).Rows(0).Item("pesocampo"), 30)
        Else
            PesoCampo = 30
        End If
        Return PesoCampo

    End Function

    Function ObtieneNuevoFolio() As String
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select max(cint(folio)) from acarreo", conexionAccess)
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

    Function ObtieneNuevoFolioPiso() As String
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select max(cint(folio)) from piso", conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener máximo folio de piso. " & ex.Message)
            Return ""
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            Return CStr(isnull(rst.Tables(0).Rows(0).Item(0), 0) + 1).PadLeft(6, "0")
        Else
            Return "000001"
        End If
    End Function

    Sub CargaAcarreo(ByVal folio As String)

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim cmddet As New OleDbCommand
        Dim adapdet As New OleDbDataAdapter
        Dim rstdet As New DataSet
        'ENCABEZADOS
        Dim consulta$ = "select SUM(aca.Cajas) AS Cajas, aca.folio as folio, aca.fecha as fecha, aca.hora as hora, aca.productor as idproductor, emb.nombre as productor, " & _
        " aca.producto as idproducto, pro.descex as producto, aca.lote as idlote, lot.descri as lote, sum(aca.peso) as peso, aca.Chofer AS idChofer, ChoferesAcarreo.Nombre AS Chofer " & _
        " from acarreo aca, embarcador emb, producto pro, lote lot, ChoferesAcarreo " & _
        " where aca.productor = emb.codigo " & _
        " and aca.producto = pro.codigo " & _
        " and aca.lote = lot.codigo " & _
                " and aca.Chofer = ChoferesAcarreo.codigo " & _
        " and aca.folio = '" & folio & "' " & _
        " group by aca.folio, aca.fecha, aca.hora, aca.productor, emb.nombre, aca.producto, pro.descex, aca.lote, lot.descri, aca.Chofer, ChoferesAcarreo.Nombre"
        cmd = New OleDbCommand(consulta, conexionAccess)
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
            txtHora.Text = isnull(CDate(rst.Tables(0).Rows(0).Item("hora")).ToString("HH:mm"), Now.ToString("HH:mm"))
            txtIdProductor.Text = isnull(rst.Tables(0).Rows(0).Item("idproductor"), 0)
            txtProductor.Text = isnull(rst.Tables(0).Rows(0).Item("productor"), "")
            txtIdProducto.Text = isnull(rst.Tables(0).Rows(0).Item("idproducto"), 0)
            txtProducto.Text = isnull(rst.Tables(0).Rows(0).Item("producto"), "")
            txtIdLote.Text = isnull(rst.Tables(0).Rows(0).Item("idlote"), 0)
            txtLote.Text = isnull(rst.Tables(0).Rows(0).Item("lote"), "")
            txtIdChofer.Text = isnull(rst.Tables(0).Rows(0).Item("idChofer"), 0)
            txtChofer.Text = isnull(rst.Tables(0).Rows(0).Item("Chofer"), "")

            txtTotalCajas.Text = Format(isnull(rst.Tables(0).Rows(0).Item("Cajas"), 0), "###,###.00")
            txtTotalMedida.Text = Format(isnull(rst.Tables(0).Rows(0).Item("peso"), 0), "###,###.00")
            'CARGA DETALLE
            cmddet = New OleDbCommand("select cajas, pesobruto, mermacaja, mermatarima, peso " & _
            " from acarreo " & _
            " where folio = '" & folio & "' " & _
            " order by orden ", conexionAccess)
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

    Sub CargaPiso(ByVal folio As String)

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim cmddet As New OleDbCommand
        Dim adapdet As New OleDbDataAdapter
        Dim rstdet As New DataSet
        'ENCABEZADOS
        cmd = New OleDbCommand("select aca.folio as folio, aca.fecha as fecha, aca.hora as hora, aca.productor as idproductor, emb.nombre as productor, " & _
        " aca.producto as idproducto, pro.descex as producto, FIRST(Aca.Cajas) AS Cajas, sum(aca.peso) as peso, aca.TipoCaja " & _
        " from piso aca, embarcador emb, producto pro, lote lot " & _
        " where aca.productor = emb.codigo " & _
        " and aca.producto = pro.codigo " & _
        " and aca.folio = '" & folio & "' " & _
        " group by aca.folio, aca.fecha, aca.hora, aca.productor, emb.nombre, aca.producto, pro.descex, aca.TipoCaja ", conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener datos de folio. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtFolioPiso.Text = isnull(rst.Tables(0).Rows(0).Item("folio"), "")
            mskFechaPiso.Text = isnull(rst.Tables(0).Rows(0).Item("fecha"), Today.ToShortDateString)
            mskHoraPiso.Text = isnull(CDate(rst.Tables(0).Rows(0).Item("hora")).ToString("HH:mm"), Now.ToString("HH:mm"))
            txtIdProductorPiso.Text = isnull(rst.Tables(0).Rows(0).Item("idproductor"), 0)
            txtProductorPiso.Text = isnull(rst.Tables(0).Rows(0).Item("productor"), "")
            txtIdProductoPiso.Text = isnull(rst.Tables(0).Rows(0).Item("idproducto"), 0)
            txtProductoPiso.Text = isnull(rst.Tables(0).Rows(0).Item("producto"), "")

            Dim tipoCaja As Integer = isnull(rst.Tables(0).Rows(0).Item("TipoCaja"), 0)
            If tipoCaja = 0 Then
                rbtnCajasBlancas.Checked = False
                rbtnCajasGrises.Checked = False
            ElseIf tipoCaja = 1 Then
                rbtnCajasBlancas.Checked = True
            ElseIf tipoCaja = 2 Then
                rbtnCajasGrises.Checked = True
            End If

            txtTotalPiso.Text = Format(isnull(rst.Tables(0).Rows(0).Item("Cajas"), 0), "###,###.00")
            'CARGA DETALLE
            cmddet = New OleDbCommand("select CajasEmpaque, pesobruto, mermacaja, mermatarima, peso, Cajas " & _
            " from piso " & _
            " where folio = '" & folio & "' " & _
            " order by orden ", conexionAccess)
            adapdet.SelectCommand = cmddet
            Try
                adapdet.Fill(rstdet)
            Catch ex As Exception
                MsgBox("Error al obtener detalles de la entrada. " & ex.Message)
                Exit Sub
            End Try
            fpPiso.DataSource = rstdet
            FormatoSpreadPiso(rstdet.Tables(0).Rows.Count + 1)
        Else
            limpiapantalla()
        End If

    End Sub


    Sub GuardaAcarreo()
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim folio As String = ""
        Dim fecha As String = Today.ToShortDateString
        Dim hora As String = txtHora.Text
        Dim productor As Integer = 0
        Dim producto As Integer = 0
        Dim lote As Integer = 0
        Dim chofer As Integer = 0
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
        If IsNumeric(txtIdChofer.Text) Then
            chofer = txtIdChofer.Text
        Else
            MsgBox("Indique un número de chofer válido")
            Exit Sub
        End If
        If IsDate(txtFecha.Text) Then
            fecha = txtFecha.Text
        End If
        If IsDate(txtHora.Text) Then
            hora = txtHora.Text
        End If
        'RESETEA REGISTROS DE ACARREO
        cmd = New OleDbCommand("delete from acarreo where folio = '" & folio & "'", conexionAccess)
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
                " pesobruto, mermacaja, mermatarima, peso, orden, chofer " & _
                " from acarreo " & _
                " where folio = '" & folio & "' and orden = " & orden, conexionAccess)
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
                nueva("chofer") = chofer
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

    Private Sub GuardarPiso()

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim folio As String = ""
        Dim fecha As String = Today.ToShortDateString
        Dim hora As String = txtHora.Text
        Dim productor As Integer = 0
        Dim producto As Integer = 0
        Dim cajas As Double = 0
        Dim sumaCajas As Double = 0
        Dim pesobruto As Double = 0
        Dim mermacaja As Double = 0
        Dim mermatarima As Double = 0
        Dim peso As Double = 0
        Dim orden As Integer = 0
        Dim tipoCaja As Integer = 0

        If IsNumeric(txtFolioPiso.Text) Then
            folio = txtFolioPiso.Text.PadLeft(6, "0")
        Else
            MsgBox("Indique un número de folio válido")
            Exit Sub
        End If
        If IsNumeric(txtIdProductorPiso.Text) Then
            productor = txtIdProductorPiso.Text
        Else
            MsgBox("Indique un número de productor válido")
            Exit Sub
        End If
        If IsNumeric(txtIdProductoPiso.Text) Then
            producto = txtIdProductoPiso.Text
        Else
            MsgBox("Indique un número de producto válido")
            Exit Sub
        End If
        If IsDate(mskFechaPiso.Text) Then
            fecha = mskFechaPiso.Text
        End If
        If IsDate(mskHoraPiso.Text) Then
            hora = mskHoraPiso.Text
        End If

        If Not rbtnCajasBlancas.Checked And Not rbtnCajasGrises.Checked Then
            MsgBox("Favor de escoger el tipo de caja que va a ingresar.", MsgBoxStyle.Information, "Falta tipo de caja.")
            Exit Sub
        ElseIf rbtnCajasBlancas.Checked Then
            tipoCaja = 1
        ElseIf rbtnCajasGrises.Checked Then
            tipoCaja = 2
        End If

        'RESETEA REGISTROS DE ACARREO
        cmd = New OleDbCommand("delete from piso where folio = '" & folio & "'", conexionAccess)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al preparar inserción de piso. " & ex.Message)
        End Try
        For i As Integer = 0 To fpPiso.ActiveSheet.RowCount - 1
            orden = i + 1
            If IsNumeric(fpPiso.ActiveSheet.Cells(i, fpPiso.ActiveSheet.Columns("cajas").Index).Text) Then
                cajas = fpPiso.ActiveSheet.Cells(i, fpPiso.ActiveSheet.Columns("cajas").Index).Text
                If IsNumeric(fpPiso.ActiveSheet.Cells(i, fpPiso.ActiveSheet.Columns("peso").Index).Text) Then
                    peso = fpPiso.ActiveSheet.Cells(i, fpPiso.ActiveSheet.Columns("peso").Index).Text
                Else
                    MsgBox("Coloque un peso  válido")
                    fpPiso.ActiveSheet.SetActiveCell(i, 0)
                    Exit Sub
                End If

                cmd = New OleDbCommand("select folio, fecha, hora, productor, producto, lote, cajas, " & _
                " pesobruto, mermacaja, mermatarima, peso, orden, chofer, TipoCaja, CajasEmpaque " & _
                " from piso " & _
                " where folio = '" & folio & "' and orden = " & orden, conexionAccess)
                adap.SelectCommand = cmd
                Try
                    adap.Fill(rst)
                Catch ex As Exception
                    MsgBox("Error al preparar guardado de folio de piso. " & ex.Message)
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
                nueva("CajasEmpaque") = cajas
                If rbtnCajasBlancas.Checked Or rbtnCajasGrises.Checked Then
                    ' Calcula factor.
                    cajas = cajas * factor
                End If
                cajas = Math.Round(cajas)
                nueva("cajas") = cajas
                nueva("pesobruto") = pesobruto
                nueva("mermacaja") = mermacaja
                nueva("mermatarima") = mermatarima
                nueva("peso") = peso
                nueva("orden") = orden
                nueva("TipoCaja") = tipoCaja
                rst.Tables(0).Rows.Add(nueva)

                Try
                    adap.Update(rst)
                Catch ex As Exception
                    MsgBox("Error al insertar folio de piso. " & ex.Message)
                    Exit Sub
                End Try
                rst.Dispose()
                rst.Clear()
            End If
        Next

        txtFolioPiso.Text = ObtieneNuevoFolioPiso()
        limpiapantalla()

    End Sub

    Sub CargaProductorPiso(ByVal productor As Integer)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select nombre from embarcador where codigo = " & productor, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener productor. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtProductorPiso.Text = isnull(rst.Tables(0).Rows(0).Item(0), "")
            txtIdProductoPiso.Focus()
        Else
            txtIdProductorPiso.Text = ""
            txtProductorPiso.Text = ""
            txtIdProductorPiso.Focus()
        End If
    End Sub


    Sub CargaProductor(ByVal productor As Integer)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select nombre from embarcador where codigo = " & productor, conexionAccess)
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
        cmd = New OleDbCommand("select descex from producto where codigo = " & producto, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener producto. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtProducto.Text = isnull(rst.Tables(0).Rows(0).Item(0), "")
            txtIdChofer.Focus()
        Else
            txtIdProducto.Text = ""
            txtProducto.Text = ""
            txtIdProducto.Focus()
        End If

    End Sub

    Sub CargaProductoPiso(ByVal producto As Integer)

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select descex from producto where codigo = " & producto, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener producto. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtProductoPiso.Text = isnull(rst.Tables(0).Rows(0).Item(0), "")
            fpPiso.Focus()
            fpPiso.ActiveSheet.SetActiveCell(0, 0)
        Else
            txtIdProductoPiso.Text = ""
            txtProductoPiso.Text = ""
            txtIdProductoPiso.Focus()
        End If

    End Sub

    Sub CargaLote(ByVal lote As Integer)

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select descri from lote where codigo = " & lote, conexionAccess)
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

    Sub CargaChofer(ByVal chofer As Integer)

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select Nombre from ChoferesAcarreo where codigo = " & chofer, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener chofer. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtChofer.Text = isnull(rst.Tables(0).Rows(0).Item(0), "")
            spAcarreo.Focus()
            spAcarreo.ActiveSheet.SetActiveCell(0, 0)
        Else
            txtIdChofer.Text = ""
            txtChofer.Text = ""
            txtIdChofer.Focus()
        End If

    End Sub


    Sub limpiapantalla()

        If tbAcarreo1.SelectedIndex = 0 Then
            txtFecha.Text = Today.ToShortDateString
            txtHora.Text = Now.ToString("HH:mm")
            txtIdProductor.Text = ""
            txtProductor.Text = ""
            txtIdProducto.Text = ""
            txtProducto.Text = ""
            txtIdLote.Text = ""
            txtLote.Text = ""
            txtIdChofer.Text = String.Empty
            txtChofer.Text = String.Empty
            txtTotalMedida.Text = "0.00"
            spAcarreo.Reset()
            FormatoSpread(1)
        ElseIf tbAcarreo1.SelectedIndex = 1 Then

            mskFechaVaciado.Text = Today.ToShortDateString
            mskHoraVaciado.Text = Now.Hour.ToString().PadLeft(2, "0") + ":00"
            txtIdProdVaciado.Text = ""
            txtNombreProdVac.Text = ""

            txtTotalVaciado.Text = "0.00"
            fpVaciado.Reset()
            FormatoSpreadVaciado(1)

        ElseIf tbAcarreo1.SelectedIndex = 2 Then
            mskFechaPiso.Text = Today.ToShortDateString
            mskHoraPiso.Text = Now.ToString("HH:mm")
            txtIdProductorPiso.Text = ""
            txtProductorPiso.Text = ""
            txtIdProductoPiso.Text = ""
            txtProductoPiso.Text = ""
            txtTotalPiso.Text = "0.00"
            rbtnCajasBlancas.Checked = False
            rbtnCajasGrises.Checked = False
            fpPiso.Reset()
            FormatoSpreadPiso(1)
        End If

    End Sub

    Function SumatoriaPesoPiso() As Double

        Dim total As Double = 0
        For i As Integer = 0 To fpPiso.ActiveSheet.RowCount - 1
            If IsNumeric(fpPiso.ActiveSheet.Cells(i, fpPiso.ActiveSheet.Columns("peso").Index).Text) Then
                total = total + fpPiso.ActiveSheet.Cells(i, fpPiso.ActiveSheet.Columns("peso").Index).Text
            End If
        Next
        Return total

    End Function

    Function SumatoriaCajasPiso() As Double

        Dim total As Double = 0
        For i As Integer = 0 To fpPiso.ActiveSheet.RowCount - 1
            If IsNumeric(fpPiso.ActiveSheet.Cells(i, fpPiso.ActiveSheet.Columns("cajas").Index).Text) Then
                total = total + fpPiso.ActiveSheet.Cells(i, fpPiso.ActiveSheet.Columns("cajas").Index).Text
            End If
        Next
        Return total

    End Function


    Function SumatoriaPeso() As Double

        Dim total As Double = 0
        For i As Integer = 0 To spAcarreo.ActiveSheet.RowCount - 1
            If IsNumeric(spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("peso").Index).Text) Then
                total = total + spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("peso").Index).Text
            End If
        Next
        Return total

    End Function

    Function SumatoriaCajas() As Double

        Dim total As Double = 0
        For i As Integer = 0 To spAcarreo.ActiveSheet.RowCount - 1
            If IsNumeric(spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("cajas").Index).Text) Then
                total = total + spAcarreo.ActiveSheet.Cells(i, spAcarreo.ActiveSheet.Columns("cajas").Index).Text
            End If
        Next
        Return total

    End Function

    Sub EliminaAcarreo(ByVal folio As String)

        Dim cmd As New OleDbCommand
        cmd = New OleDbCommand("delete from acarreo where folio = '" & folio & "'", conexionAccess)
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
        spHistorial.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Select
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
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("peso").Index).Text = "UNIDAD DE MEDIDA"
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("fecha").Index).Text = "FECHA"

        spHistorial.Visible = True

    End Sub

    Private Sub LlenaHistorial()

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet

        cmd = New OleDbCommand("select folio, fecha, sum(cajas) as cajas, sum(peso) as peso " & _
        " from acarreo " & _
        " group by folio, fecha " & _
        " order by folio, fecha", conexionAccess)
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

    Private Sub LlenaHistorialPiso()

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet

        cmd = New OleDbCommand("select folio, fecha, sum(cajas) as cajas, sum(peso) as peso " & _
        " from Piso " & _
        " group by folio, fecha " & _
        " order by folio, fecha", conexionAccess)
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

    Private Sub txtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown, txtFecha.KeyDown, txtHora.KeyDown, txtIdProductor.KeyDown, txtIdLote.KeyDown, txtIdProducto.KeyDown, txtIdChofer.KeyDown

        If e.KeyData = Keys.Enter Then
            If sender.Equals(txtFolio) Then
                e.SuppressKeyPress = True
                If IsNumeric(txtFolio.Text) Then
                    txtFolio.Text = txtFolio.Text.PadLeft(6, "0")
                    CargaAcarreo(txtFolio.Text)
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
            ElseIf sender.Equals(txtIdChofer) Then
                If IsNumeric(txtIdChofer.Text) Then
                    e.SuppressKeyPress = True
                    CargaChofer(txtIdChofer.Text)
                Else
                    txtIdChofer.Text = ""
                    txtChofer.Text = ""
                    txtIdChofer.Focus()
                End If
            End If
        ElseIf e.KeyData = Keys.F1 Then
            If sender.Equals(txtIdProductor) Then
                opc = 1
                If Catalogos.Visible = True Then
                    Catalogos.Close()
                End If
                Catalogos.Show()
            ElseIf sender.Equals(txtIdProducto) Then
                opc = 2
                If Catalogos.Visible = True Then
                    Catalogos.Close()
                End If
                Catalogos.Show()
            ElseIf sender.Equals(txtIdLote) Then
                opc = 5
                If Catalogos.Visible = True Then
                    Catalogos.Close()
                End If
                Catalogos.Show()
            ElseIf sender.Equals(txtIdChofer) Then
                opc = 10
                If Catalogos.Visible = True Then
                    Catalogos.Close()
                End If
                Catalogos.Show()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            e.SuppressKeyPress = True
            SendKeys.Send("+({TAB})")
        End If
    End Sub
    Private Sub txtFolioPiso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolioPiso.KeyDown, mskFechaPiso.KeyDown, mskHoraPiso.KeyDown, txtIdProductorPiso.KeyDown, txtIdProductoPiso.KeyDown

        If e.KeyData = Keys.Enter Then
            If sender.Equals(txtFolioPiso) Then
                e.SuppressKeyPress = True
                If IsNumeric(txtFolioPiso.Text) Then
                    txtFolioPiso.Text = txtFolioPiso.Text.PadLeft(6, "0")
                    CargaPiso(txtFolioPiso.Text)
                    mskFechaPiso.Focus()
                Else
                    txtFolioPiso.Text = ObtieneNuevoFolioPiso()
                    limpiapantalla()
                End If
            ElseIf sender.Equals(mskFechaPiso) Then
                If IsDate(mskFechaPiso.Text) Then
                    e.SuppressKeyPress = True
                    txtIdProductorPiso.Focus()
                End If
            ElseIf sender.Equals(mskHoraPiso) Then
                If IsDate(mskHoraPiso.Text) Then
                    e.SuppressKeyPress = True
                    txtIdProductorPiso.Focus()
                End If
            ElseIf sender.Equals(txtIdProductorPiso) Then
                If IsNumeric(txtIdProductorPiso.Text) Then
                    e.SuppressKeyPress = True
                    CargaProductorPiso(txtIdProductorPiso.Text)
                Else
                    txtIdProductorPiso.Text = ""
                    txtProductorPiso.Text = ""
                    txtIdProductorPiso.Focus()
                End If
            ElseIf sender.Equals(txtIdProductoPiso) Then
                If IsNumeric(txtIdProductoPiso.Text) Then
                    e.SuppressKeyPress = True
                    CargaProductopiso(txtIdProductoPiso.Text)
                Else
                    txtIdProductoPiso.Text = ""
                    txtProductoPiso.Text = ""
                    txtIdProductoPiso.Focus()
                End If
            End If
        ElseIf e.KeyData = Keys.F1 Then
            If sender.Equals(txtIdProductorPiso) Then
                opc = 1
                If Catalogos.Visible = True Then
                    Catalogos.Close()
                End If
                Catalogos.Show()
            ElseIf sender.Equals(txtIdProductoPiso) Then
                opc = 2
                If Catalogos.Visible = True Then
                    Catalogos.Close()
                End If
                Catalogos.Show()
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

    Private Sub txtFolioPiso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolioPiso.KeyPress, txtIdProductoPiso.KeyPress, txtIdProductorPiso.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        If tbAcarreo1.SelectedIndex = 0 Then
            GuardaAcarreo()
        ElseIf tbAcarreo1.SelectedIndex = 1 Then
            GuardaVaciado()
        ElseIf tbAcarreo1.SelectedIndex = 2 Then
            GuardarPiso()
        End If

    End Sub

    Private Sub spAcarreo_DialogKey(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spAcarreo.DialogKey

        If e.KeyData = Keys.Enter Then
            ManejoSpread()
        ElseIf e.KeyData = Keys.F9 Then
            spAcarreo.ActiveSheet.RemoveRows(spAcarreo.ActiveSheet.ActiveRowIndex, 1)
            spAcarreo.ActiveSheet.AddRows(spAcarreo.ActiveSheet.RowCount, 1)
        End If

    End Sub

    Private Sub fpPiso_DialogKey(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles fpPiso.DialogKey
        If e.KeyData = Keys.Enter Then
            ManejoSpreadPiso()
        ElseIf e.KeyData = Keys.F9 Then
            fpPiso.ActiveSheet.RemoveRows(fpPiso.ActiveSheet.ActiveRowIndex, 1)
            fpPiso.ActiveSheet.AddRows(fpPiso.ActiveSheet.RowCount, 1)
        End If
    End Sub

    Private Sub spAcarreo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles spAcarreo.KeyDown

        If e.KeyData = Keys.Enter Then
            ManejoSpread()
        End If

    End Sub

    Private Sub spPiso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fpPiso.KeyDown
        If e.KeyData = Keys.Enter Then
            ManejoSpreadPiso()
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

        If tbAcarreo1.SelectedIndex = 0 Then
            If spHistorial.Visible Then
                spHistorial.Visible = False
            Else
                FormatoHistorial()
                LlenaHistorial()
            End If
        ElseIf tbAcarreo1.SelectedIndex = 1 Then
            If spHistorial.Visible Then
                spHistorial.Visible = False
            Else
                FormatoHistorial()
                LlenaHistorialVaciado()
            End If
        ElseIf tbAcarreo1.SelectedIndex = 2 Then
            If spHistorial.Visible Then
                spHistorial.Visible = False
            Else
                FormatoHistorial()
                LlenaHistorialPiso()
            End If
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If tbAcarreo1.SelectedIndex = 0 Then
            If MsgBox("¿Desea eliminar el folio en pantalla?", MsgBoxStyle.YesNo, "Eliminar Acarreo") = MsgBoxResult.Yes Then
                EliminaAcarreo(txtFolio.Text.PadLeft(6, "0"))
            End If
        ElseIf tbAcarreo1.SelectedIndex = 1 Then
            If MsgBox("¿Desea eliminar el vaciado en pantalla?", MsgBoxStyle.YesNo, "Eliminar Vaciado") = MsgBoxResult.Yes Then
                EliminaVaciado()
            End If
        ElseIf tbAcarreo1.SelectedIndex = 2 Then
            If MsgBox("¿Desea eliminar el piso en pantalla?", MsgBoxStyle.YesNo, "Eliminar Piso") = MsgBoxResult.Yes Then
                EliminaPiso()
            End If
        End If
    End Sub


    Private Sub spHistorial_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles spHistorial.CellDoubleClick

        If tbAcarreo1.SelectedIndex = 0 Then
            If IsNumeric(spHistorial.ActiveSheet.Cells(spHistorial.ActiveSheet.ActiveRowIndex, spHistorial.ActiveSheet.Columns("folio").Index).Text) Then
                CargaAcarreo(spHistorial.ActiveSheet.Cells(spHistorial.ActiveSheet.ActiveRowIndex, spHistorial.ActiveSheet.Columns("folio").Index).Text)
            End If
        ElseIf tbAcarreo1.SelectedIndex = 2 Then
            If IsNumeric(spHistorial.ActiveSheet.Cells(spHistorial.ActiveSheet.ActiveRowIndex, spHistorial.ActiveSheet.Columns("folio").Index).Text) Then
                CargaPiso(spHistorial.ActiveSheet.Cells(spHistorial.ActiveSheet.ActiveRowIndex, spHistorial.ActiveSheet.Columns("folio").Index).Text)
            End If
        End If

    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        If ReportesAcarreo.Visible = True Then
            ReportesAcarreo.Close()
        End If
        ReportesAcarreo.Show()
    End Sub



    Private Sub mskFechaVaciado_KeyDown(sender As Object, e As KeyEventArgs) Handles mskFechaVaciado.KeyDown
        If e.KeyData = Keys.Enter Then
            If IsDate(mskFechaVaciado.Text) Then
                e.SuppressKeyPress = True
                mskHoraVaciado.Focus()

            End If
        ElseIf e.KeyData = Keys.Escape Then

        End If
    End Sub

    Private Sub txtIdProdVaciado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdProdVaciado.KeyDown

        If e.KeyData = Keys.Enter Then
            If IsNumeric(txtIdProdVaciado.Text) Then
                e.SuppressKeyPress = True
                CargaProductorVac(txtIdProdVaciado.Text)
                CargaVaciado()
            Else
                txtIdProdVaciado.Text = ""
                txtNombreProdVac.Text = ""
                txtIdProdVaciado.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            e.SuppressKeyPress = True
            SendKeys.Send("+({TAB})")
        End If
    End Sub

    Private Sub mskHoraVaciado_KeyDown(sender As Object, e As KeyEventArgs) Handles mskHoraVaciado.KeyDown
        If e.KeyData = Keys.Enter Then
            If mskHoraVaciado.Text <> "  :  " Then
                Dim nuevovalor As String
                e.SuppressKeyPress = True
                nuevovalor = mskHoraVaciado.Text.Substring(0, 2).Replace(" ", "").PadLeft(2, "0") + ":00"
                mskHoraVaciado.Text = ""
                mskHoraVaciado.Text = nuevovalor

                CargaVaciado()
                txtIdProdVaciado.Focus()
            Else
                mskHoraVaciado.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            e.SuppressKeyPress = True
            SendKeys.Send("+({TAB})")
        End If
    End Sub





    Private Sub txtIdProdVaciado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdProdVaciado.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region

#Region "vaciado"

    Sub FormatoHistorialVaciado()
        Dim tipotxt As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tipofecha As New FarPoint.Win.Spread.CellType.DateTimeCellType
        Dim tipodob As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tipoint As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType

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

        tipoHora.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined
        tipoHora.UserDefinedFormat = "HH:mm"

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
        spHistorial.ActiveSheet.Columns(0).Tag = "fecha"
        spHistorial.ActiveSheet.Columns(1).Tag = "hora"
        spHistorial.ActiveSheet.Columns(2).Tag = "cajas"
        spHistorial.ActiveSheet.Columns(3).Tag = "peso"

        'ALTURA DE FILAS
        spHistorial.ActiveSheet.ColumnHeader.Rows(0).Height = 40

        'ANCHURA DE COLUMNAS
        spHistorial.ActiveSheet.RowHeader.Columns(0).Width = 35
        spHistorial.ActiveSheet.Columns("fecha").Width = 80
        spHistorial.ActiveSheet.Columns("hora").Width = 80
        spHistorial.ActiveSheet.Columns("cajas").Width = 90
        spHistorial.ActiveSheet.Columns("peso").Width = 100

        'TIPOS DE CELDAS
        spHistorial.ActiveSheet.Columns("hora").CellType = tipoHora
        spHistorial.ActiveSheet.Columns("peso").CellType = tipodob
        spHistorial.ActiveSheet.Columns("cajas").CellType = tipoint
        spHistorial.ActiveSheet.Columns("fecha").CellType = tipofecha

        'FILTROS Y SORTING
        spHistorial.ActiveSheet.Columns("hora").AllowAutoFilter = True
        spHistorial.ActiveSheet.Columns("fecha").AllowAutoFilter = True
        spHistorial.ActiveSheet.Columns("fecha").AllowAutoSort = True
        spHistorial.ActiveSheet.Columns("hora").AllowAutoSort = True

        'TEXTO DE ENCABEZADOS
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("cajas").Index).Text = "CAJAS"
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("hora").Index).Text = "HORA"
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("peso").Index).Text = "UNIDAD DE MEDIDA"
        spHistorial.ActiveSheet.ColumnHeader.Cells(0, spHistorial.ActiveSheet.Columns("fecha").Index).Text = "FECHA"

        spHistorial.Visible = True
    End Sub

    Sub LlenaHistorialVaciado()
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet

        cmd = New OleDbCommand("select  fecha, hora, sum(cajas) as cajas, sum(peso) as peso " & _
        " from vaciado " & _
        " group by  fecha, hora " & _
        " order by fecha, hora", conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener historial. " & ex.Message)
            Exit Sub
        End Try
        spHistorial.DataSource = rst
        FormatoHistorialVaciado()
    End Sub

    Sub EliminaVaciado()
        Dim cmd As New OleDbCommand
        cmd = New OleDbCommand("delete from vaciado  where productor=" & txtIdProdVaciado.Text & _
                " and fecha=#" & Convert.ToDateTime(mskFechaVaciado.Text).ToString("MM/dd/yyyy") & _
                "# and format(hora,'hh:mm')='" & mskHoraVaciado.Text & "'", conexionAccess)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al eliminar el vaciado. " & ex.Message)
            Exit Sub
        End Try
        limpiapantalla()
    End Sub

    Sub EliminaPiso()
        Dim cmd As New OleDbCommand
        cmd = New OleDbCommand("delete from piso where productor=" & txtIdProductorPiso.Text & _
                " and fecha=#" & Convert.ToDateTime(mskFechaPiso.Text).ToString("MM/dd/yyyy") & _
                "# and format(hora,'hh:mm')='" & mskHoraPiso.Text & "'", conexionAccess)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al eliminar el piso. " & ex.Message)
            Exit Sub
        End Try
        limpiapantalla()
    End Sub

    Sub CargaVaciado()

        If IsNumeric(txtIdProdVaciado.Text) And IsDate(mskFechaVaciado.Text) And mskHoraVaciado.Text <> "  :  " Then
            Dim cmd As New OleDbCommand
            Dim adap As New OleDbDataAdapter
            Dim rst As New DataSet
            Dim cmddet As New OleDbCommand
            Dim adapdet As New OleDbDataAdapter
            Dim rstdet As New DataSet
            'ENCABEZADOS
            cmd = New OleDbCommand("select  vac.fecha as fecha, vac.productor as idproductor, emb.nombre as productor, " & _
            " sum(vac.peso) as peso, SUM(vac.Cajas) AS cajas " & _
            " from vaciado vac, embarcador emb " & _
            " where vac.productor = emb.codigo " & _
            " and vac.productor=" & txtIdProdVaciado.Text & _
            " and vac.fecha=#" & Convert.ToDateTime(mskFechaVaciado.Text).ToString("MM/dd/yyyy") & _
            "# and format(vac.hora,'hh:00')='" & mskHoraVaciado.Text & "'" & _
            " group by vac.fecha, vac.productor, emb.nombre", conexionAccess)
            adap.SelectCommand = cmd
            Try
                adap.Fill(rst)
            Catch ex As Exception
                MsgBox("Error al obtener datos de vaciado. " & ex.Message)
                Exit Sub
            End Try
            If rst.Tables(0).Rows.Count > 0 Then
                txtTotalVaciado.Text = Format(isnull(rst.Tables(0).Rows(0).Item("cajas"), 0), "###,###.00")
                'CARGA DETALLE
                cmddet = New OleDbCommand("select vaciado.folio as folio, vaciado.producto, producto.descex, vaciado.lote, lote.descri, vaciado.banda, vaciado.cajas, vaciado.peso " & _
                " from vaciado  , producto, lote" & _
                " where  vaciado.producto = producto.codigo and vaciado.lote = lote.codigo and vaciado.productor=" & txtIdProdVaciado.Text & _
                 " and vaciado.fecha=#" & Convert.ToDateTime(mskFechaVaciado.Text).ToString("MM/dd/yyyy") & _
                "# and format(vaciado.hora,'hh:00')='" & mskHoraVaciado.Text & "'" & _
                " order by vaciado.orden ", conexionAccess)
                adapdet.SelectCommand = cmddet
                Try
                    adapdet.Fill(rstdet)
                Catch ex As Exception
                    MsgBox("Error al obtener detalles de la vaciado. " & ex.Message)
                    Exit Sub
                End Try

                rstdet.Tables(0).Columns.Add(1)
                fpVaciado.DataSource = rstdet
                ' Se consultan las cajas restantes.
                For index As Integer = 0 To fpVaciado.ActiveSheet.Rows.Count - 1
                    Dim folio As Integer = CInt(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text)
                    Dim cajasRestantes As Integer = CantidadCajasRestantes(folio)
                    fpVaciado.ActiveSheet.Cells(index, 8).Text = cajasRestantes
                    fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("banda").Index).Locked = True
                    'fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).ForeColor = Color.OrangeRed

                Next
                FormatoSpreadVaciado(rstdet.Tables(0).Rows.Count + 1)
            Else
                fpVaciado.Reset()
                FormatoSpreadVaciado(1)
                txtTotalVaciado.Text = "0.00"
            End If
        End If

    End Sub

    Private Function CantidadCajasRestantes(ByVal folio As String) As Integer

        Dim cantidadCajasFolio As Integer = 0
        Dim comando As New OleDbCommand
        Dim adaptador As New OleDbDataAdapter
        Dim resultado As New DataSet
        Dim query As String = "SELECT Acarreo.Folio, Acarreo.Cajas - IIF(ISNULL(SUM(Vaciado.Cajas)), 0, SUM(Vaciado.Cajas)) AS DiferenciaCajas FROM Acarreo LEFT JOIN Vaciado ON (Vaciado.Productor = Acarreo.Productor) AND (Acarreo.Folio = Vaciado.Folio) WHERE CINT(Acarreo.Folio) = " & folio & " GROUP BY Acarreo.Folio, Acarreo.Cajas"
        comando = New OleDbCommand(query, conexionAccess)
        adaptador.SelectCommand = comando
        Try
            adaptador.Fill(resultado)
            If resultado.Tables(0).Rows.Count > 0 Then
                cantidadCajasFolio = isnull(resultado.Tables(0).Rows(0).Item("DiferenciaCajas"), 0)
            Else
                cantidadCajasFolio = 0
            End If
            Return cantidadCajasFolio
        Catch ex As Exception
            MsgBox("Error al obtener cajas restantes. " & ex.Message)
            Return cantidadCajasFolio
            Exit Function
        End Try

    End Function


    Private Function CantidadPermitida(ByVal folio As String, ByVal cantidadTentativa As Integer) As Boolean

        Dim esPermitido As Boolean = False
        Dim cantidadCajasFolio As Integer = 0
        Dim comando As New OleDbCommand
        Dim adaptador As New OleDbDataAdapter
        Dim resultado As New DataSet
        comando = New OleDbCommand("select cajas, peso " & _
        " from acarreo " & _
        " where CINT(folio) = '" & folio & "' " & _
        " order by orden ", conexionAccess)
        adaptador.SelectCommand = comando
        Try
            adaptador.Fill(resultado)
            If resultado.Tables(0).Rows.Count > 0 Then
                cantidadCajasFolio = isnull(resultado.Tables(0).Rows(0).Item("cajas"), 0)
            Else
                cantidadCajasFolio = 0
            End If
            If cantidadTentativa > cantidadCajasFolio Then
                esPermitido = False
            Else
                esPermitido = True
            End If
        Catch ex As Exception
            MsgBox("Error al obtener cajas para validar el máximo permitido. " & ex.Message)
            Exit Function
        End Try
        Return esPermitido

    End Function

    Sub GuardaVaciado()
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
        Dim banda As Integer = 0
        Dim orden As Integer = 0

        If IsNumeric(txtIdProdVaciado.Text) Then
            CargaProductorVac(txtIdProdVaciado.Text)
        End If

        If IsNumeric(txtIdProdVaciado.Text) And txtNombreProdVac.Text.Trim() <> "" Then
            productor = txtIdProdVaciado.Text

        Else
            MsgBox("Indique un número de productor válido")
            Exit Sub
        End If


        If IsDate(mskFechaVaciado.Text) Then
            fecha = mskFechaVaciado.Text
        Else
            MsgBox("Indique una fecha válida")
            Exit Sub
        End If
        If mskHoraVaciado.Text <> "  :  " Then
            hora = mskHoraVaciado.Text
        End If
        If hora.Length <> 5 Then
            MsgBox("Indique una hora válida")
            Exit Sub
        End If

        '' Se valida la cantidad de vaciado vs cajas recibidas.
        'Dim cantidadTentativa As Integer = 0
        'For i As Integer = 0 To fpVaciado.ActiveSheet.RowCount - 1
        '    If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) Then
        '        cantidadTentativa += fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("cajas").Index).Text
        '    End If
        '    Dim folioo As Integer = fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("folio").Index).Text
        'Next
        ''If Not CantidadPermitida(folioo, cantidadTentativa) Then
        'MsgBox("No se pueden vaciar mas cajas de las que se recibieron.", MsgBoxStyle.Critical, "No permitido.")
        'Exit Sub
        ''End If


        If validaDatos() Then
            'RESETEA REGISTROS DE ACARREO
            cmd = New OleDbCommand("delete from vaciado where  " & _
                                   "  productor=" & txtIdProdVaciado.Text & _
                   " and fecha=#" & Convert.ToDateTime(mskFechaVaciado.Text).ToString("MM/dd/yyyy") & _
                    "# and format(hora,'hh:00')='" & mskHoraVaciado.Text & "'", conexionAccess)
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Error al preparar inserción de vaciado. " & ex.Message)
            End Try
            For i As Integer = 0 To fpVaciado.ActiveSheet.RowCount - 1
                orden = i + 1
                If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) Then
                    cajas = fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("cajas").Index).Text
                    folio = fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("folio").Index).Text
                    If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("producto").Index).Text) And fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("nombreproducto").Index).Text <> "" Then
                        producto = fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("producto").Index).Text
                    Else
                        MsgBox("Coloque un producto  válido")
                        fpVaciado.ActiveSheet.SetActiveCell(i, 0)
                        Exit Sub
                    End If

                    If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("lote").Index).Text) And fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("nombrelote").Index).Text <> "" Then
                        lote = fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("lote").Index).Text
                    Else
                        MsgBox("Coloque un lote  válido")
                        fpVaciado.ActiveSheet.SetActiveCell(i, 0)
                        Exit Sub
                    End If

                    If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("banda").Index).Text) Then
                        banda = fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("banda").Index).Text
                    End If
                    If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("peso").Index).Text) Then
                        peso = fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("peso").Index).Text
                    Else
                        MsgBox("Coloque un peso  válido")
                        fpVaciado.ActiveSheet.SetActiveCell(i, 0)
                        Exit Sub
                    End If

                    cmd = New OleDbCommand("select  folio, fecha, hora, productor, producto, lote, cajas, " & _
                    "  peso, orden, banda " & _
                    " from vaciado " & _
                    " where productor=" & txtIdProdVaciado.Text & " and lote=" & lote & _
                    " and producto=" & producto & " and fecha=#" & mskFechaVaciado.Text & _
                    "# and hora=#" & mskHoraVaciado.Text & "#" & " and orden = " & orden, conexionAccess)
                    adap.SelectCommand = cmd
                    Try
                        adap.Fill(rst)
                    Catch ex As Exception
                        MsgBox("Error al preparar guardado de vaciado. " & ex.Message)
                        Exit Sub
                    End Try

                    Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(adap)
                    builder.GetInsertCommand()
                    adap.InsertCommand = builder.GetInsertCommand()
                    Dim nueva As DataRow = rst.Tables(0).NewRow()

                    nueva("fecha") = fecha
                    nueva("hora") = hora
                    nueva("folio") = folio
                    nueva("productor") = productor
                    nueva("producto") = producto
                    nueva("lote") = lote
                    nueva("cajas") = cajas
                    nueva("peso") = peso
                    nueva("orden") = orden
                    nueva("banda") = banda
                    rst.Tables(0).Rows.Add(nueva)
                    Try
                        adap.Update(rst)
                    Catch ex As Exception
                        MsgBox("Error al insertar el vaciado. " & ex.Message)
                        Exit Sub
                    End Try
                    rst.Dispose()
                    rst.Clear()
                End If
            Next


            limpiapantalla()
            mskFechaVaciado.Focus()
        End If
    End Sub

    Function validaDatos() As Boolean
        Dim datosValidos As Boolean = True
        Dim orden As Integer
        For i As Integer = 0 To fpVaciado.ActiveSheet.RowCount - 1
            orden = i + 1
            If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) Then


                If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("producto").Index).Text) And fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("nombreproducto").Index).Text <> "" Then

                Else
                    MsgBox("Coloque un producto  válido")
                    fpVaciado.ActiveSheet.SetActiveCell(i, 0)
                    datosValidos = False
                    Exit Function
                End If

                If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("lote").Index).Text) And fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("nombrelote").Index).Text <> "" Then

                Else
                    MsgBox("Coloque un lote  válido")
                    fpVaciado.ActiveSheet.SetActiveCell(i, 0)
                    datosValidos = False
                    Exit Function
                End If

                If Not IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("banda").Index).Text) Then
                    MsgBox("Coloque una banda  válida")
                    fpVaciado.ActiveSheet.SetActiveCell(i, 0)
                    datosValidos = False
                    Exit Function
                End If
                If Not IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("peso").Index).Text) Then

                    MsgBox("Coloque un peso  válido")
                    fpVaciado.ActiveSheet.SetActiveCell(i, 0)
                    datosValidos = False
                    Exit Function
                End If
            End If
        Next
        Return datosValidos
    End Function

    Function SumatoriaBultosVaciado() As Double

        Dim total As Double = 0
        For i As Integer = 0 To fpVaciado.ActiveSheet.RowCount - 1
            If IsNumeric(fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) Then
                total = total + fpVaciado.ActiveSheet.Cells(i, fpVaciado.ActiveSheet.Columns("cajas").Index).Text
            End If
        Next
        Return total

    End Function

    Private Sub CalculoBorrado()

        If fpVaciado.ActiveSheet.Rows.Count <= 1 Then
            Exit Sub
        End If
        Dim aRow As Integer = fpVaciado.ActiveSheet.ActiveRowIndex

        Dim tamanoCaptura As Integer = 0
        ' For reestructurando todo.
        For index = 0 To fpVaciado.ActiveSheet.Rows.Count - 1
            If Not String.IsNullOrEmpty(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
                tamanoCaptura = index
            End If
        Next

        If IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) And IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("producto").Index).Text) Then
            Dim folioEscrito As Integer = CInt(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("folio").Index).Text)
            Dim conteo As Integer = 0
            Dim cantidadRestante As Integer = CantidadCajasRestantes(folioEscrito)
            ' For reestructurando todo.
            For index = 0 To tamanoCaptura
                If Not IsNumeric(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
                    Exit For
                End If
                Dim folioBuscado As Integer = CInt(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text)
                If folioBuscado = folioEscrito Then
                    If index <> aRow Then
                        If IsNumeric(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) Then
                            If fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).ForeColor = Color.OrangeRed Then
                                Dim cajasIngresadas As Integer = fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajas").Index).Text
                                conteo += cajasIngresadas
                            End If
                        End If
                    End If
                End If
            Next
            ' For reestructurando todo.
            For index = 0 To tamanoCaptura
                If Not IsNumeric(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
                    Exit Sub
                End If
                Dim folioBuscado As Integer = CInt(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text)
                If folioBuscado = folioEscrito Then
                    If IsNumeric(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) Then
                        Dim cantidadTotal As Integer = cantidadRestante - conteo
                        fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text = cantidadTotal
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub CalculoAgregar()

        Dim rowActiva As Integer = fpVaciado.ActiveSheet.ActiveRowIndex
        If Not IsNumeric(fpVaciado.ActiveSheet.Cells(rowActiva, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
            Exit Sub
        End If
        Dim tamanoCaptura As Integer = 0
        ' For filas a trabajar.
        For index = 0 To fpVaciado.ActiveSheet.Rows.Count - 1
            If Not String.IsNullOrEmpty(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
                tamanoCaptura = index
            End If
        Next

        If IsNumeric(fpVaciado.ActiveSheet.Cells(rowActiva, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) And IsNumeric(fpVaciado.ActiveSheet.Cells(rowActiva, fpVaciado.ActiveSheet.Columns("producto").Index).Text) Then
            Dim folioEscrito As Integer = CInt(fpVaciado.ActiveSheet.Cells(rowActiva, fpVaciado.ActiveSheet.Columns("folio").Index).Text)
            Dim conteo As Integer = 0
            Dim cantidadRestante As Integer = CantidadCajasRestantes(folioEscrito)
            ' For total cajas tentativas.
            For index = 0 To tamanoCaptura
                If Not IsNumeric(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
                    Exit For
                End If
                Dim folioBuscado As Integer = CInt(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text)
                If folioBuscado = folioEscrito Then
                    'If IsNumeric(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text) Then
                    '    Dim valor As Integer = CInt(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text)
                    '    If valor <= 0 Then
                    '        MsgBox("No puedes agregar mas cajas en este folio.", MsgBoxStyle.Critical, "No permitido")
                    '        LimpiarRenglonVaciado(rowActiva)
                    '        Exit For
                    '    End If
                    'End If
                    If fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text = "0" Or String.IsNullOrEmpty(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text) Then
                        MsgBox("No puedes agregar mas cajas en este folio.", MsgBoxStyle.Critical, "No permitido")
                        LimpiarRenglonVaciado(rowActiva)
                        Exit For
                    End If
                    If IsNumeric(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) Then
                        If fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).ForeColor = Color.OrangeRed Then
                            Dim cajasIngresadas As Integer = fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajas").Index).Text
                            conteo += cajasIngresadas
                        End If
                    End If
                End If
            Next
            ' For reestructurando todas las cantidades de cajas restantes.
            For index = 0 To tamanoCaptura
                If Not IsNumeric(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
                    Exit Sub
                End If
                Dim folioBuscado As Integer = CInt(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index).Text)
                If folioBuscado = folioEscrito Then
                    If fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text = "0" Or String.IsNullOrEmpty(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text) Then
                        MsgBox("No puedes agregar mas cajas en este folio.", MsgBoxStyle.Critical, "No permitido")
                        LimpiarRenglonVaciado(rowActiva)
                        Exit For
                    End If
                    If IsNumeric(fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) Then
                        Dim cantidadTotal As Integer = cantidadRestante - conteo

                        If cantidadTotal < 0 Then
                            MsgBox("No puedes agregar mas cajas en este folio.", MsgBoxStyle.Critical, "No permitido")
                            LimpiarRenglonVaciado(rowActiva)
                            Exit For
                        End If

                        fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text = cantidadTotal
                    End If
                End If
            Next
        End If

    End Sub


    Private Sub ManejoSpreadVaciado()

        Dim aRow As Integer = fpVaciado.ActiveSheet.ActiveRowIndex
        Dim nombre As String = String.Empty
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        If fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("cajas").Index Then
            If IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) And IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("producto").Index).Text) Then
                txtTotalVaciado.Text = Format(SumatoriaBultosVaciado(), "###,###.00")
                fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("peso").Index).Text = fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("cajas").Index).Text * ObtenerPesoCaja(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("producto").Index).Text)

                CalculoAgregar()

            End If
        ElseIf fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("producto").Index Then
            If IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("producto").Index).Text) Then
                nombre = CargaProductoVac(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("producto").Index).Text)
                If nombre <> String.Empty Then
                    fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombreproducto").Index).Text = nombre
                    fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("nombreproducto").Index
                Else
                    fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("producto").Index).Text = ""
                    fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombreproducto").Index).Text = ""
                    fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("banda").Index
                End If
            Else
                fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("producto").Index).Text = ""
                fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombreproducto").Index).Text = ""
            End If
        ElseIf fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("lote").Index Then
            If IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("lote").Index).Text) Then
                nombre = CargaLoteVac(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("lote").Index).Text)
                If nombre <> String.Empty Then
                    fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombrelote").Index).Text = nombre
                    fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("nombrelote").Index
                Else
                    fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("lote").Index).Text = ""
                    fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombrelote").Index).Text = ""
                    fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("nombreproducto").Index
                End If
            Else
                fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("lote").Index).Text = ""
                fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombrelote").Index).Text = ""
            End If
        ElseIf fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("peso").Index Then
            'txtTotalVaciado.Text = Format(SumatoriaBultosVaciado(), "###,###.00")
        ElseIf fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("folio").Index Then
            Dim folioacarreo As String = ""
            If IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
                fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("folio").Index).Text = fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("folio").Index).Text.PadLeft(6, "0")
                folioacarreo = fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("folio").Index).Text
                If IsNumeric(txtIdProdVaciado.Text) Then
                    cmd = New OleDbCommand("select folio, acarreo.producto as producto, producto.descex as nombreproducto, lote, lote.descri as nombrelote " & _
                    " from acarreo, producto, lote " & _
                    " where acarreo.producto = producto.codigo " & _
                    " and acarreo.lote = lote.codigo " & _
                    " and productor = " & txtIdProdVaciado.Text & _
                    " and folio = '" & folioacarreo & "'", conexionAccess)
                    adap.SelectCommand = cmd
                    Try
                        adap.Fill(rst)
                    Catch ex As Exception
                        MsgBox("Error al obtener folio de acarreo. " & ex.Message)
                    End Try
                    If rst.Tables(0).Rows.Count > 0 Then
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("producto").Index).Text = isnull(rst.Tables(0).Rows(0).Item("producto"), 0)
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombreproducto").Index).Text = isnull(rst.Tables(0).Rows(0).Item("nombreproducto"), "")
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("lote").Index).Text = isnull(rst.Tables(0).Rows(0).Item("lote"), 0)
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombrelote").Index).Text = isnull(rst.Tables(0).Rows(0).Item("nombrelote"), "")
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text = CantidadCajasRestantes(folioacarreo)
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).ForeColor = Color.OrangeRed
                        fpVaciado.ActiveSheet.SetActiveCell(aRow, fpVaciado.ActiveSheet.Columns("nombrelote").Index)
                    Else
                        MsgBox("No existe el folio de acarreo consultado.")
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("folio").Index).Text = ""
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("producto").Index).Text = ""
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombreproducto").Index).Text = ""
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("lote").Index).Text = ""
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("nombrelote").Index).Text = ""
                        fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text = String.Empty
                    End If
                Else
                    MsgBox("indique un productor.")
                End If
            End If

        ElseIf fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("cajasRestantes").Index Then

            If Not IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
                MsgBox("Falta el numero de folio.", MsgBoxStyle.Exclamation, "Advertencia.")
                fpVaciado.ActiveSheet.SetActiveCell(aRow, fpVaciado.ActiveSheet.Columns("folio").Index - 1)
                Exit Sub
            ElseIf Not IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("banda").Index).Text) Then
                MsgBox("Falta el numero de la banda.", MsgBoxStyle.Exclamation, "Advertencia.")
                fpVaciado.ActiveSheet.SetActiveCell(aRow, fpVaciado.ActiveSheet.Columns("banda").Index - 1)
                Exit Sub
            ElseIf Not IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("cajas").Index).Text) Then
                MsgBox("Falta el numero de cajas.", MsgBoxStyle.Exclamation, "Advertencia.")
                fpVaciado.ActiveSheet.SetActiveCell(aRow, fpVaciado.ActiveSheet.Columns("cajas").Index - 1)
                Exit Sub
            End If

            If IsNumeric(fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("folio").Index).Text) Then
                fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("folio").Index).Locked = True
                fpVaciado.ActiveSheet.Cells(aRow, fpVaciado.ActiveSheet.Columns("banda").Index).Locked = True
            End If

            If fpVaciado.ActiveSheet.ActiveRowIndex = fpVaciado.ActiveSheet.RowCount - 1 Then
                fpVaciado.ActiveSheet.AddRows(fpVaciado.ActiveSheet.RowCount, 1)
            End If

        End If

    End Sub

    Private Sub LimpiarRenglonVaciado(ByVal index As Integer)

        fpVaciado.ActiveSheet.Cells(index, fpVaciado.ActiveSheet.Columns("folio").Index, index, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text = String.Empty
        fpVaciado.ActiveSheet.SetActiveCell(index, -1)

    End Sub

    Function ExisteAcarreo(ByVal folio As String, ByVal productor As Integer) As Boolean
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet

        cmd = New OleDbCommand("select folio from acarreo where productor = " & productor & _
        " and folio = '" & folio & "'", conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener folio de acarreo. " & ex.Message)
            Return False
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            MsgBox("No existe el folio de acarreo consultado.")
            Return False
        End If

    End Function

    Function ObtenerPesoCaja(ByVal idProducto As Integer) As Double
        Dim PesoCampo As Double = 0
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet

        cmd = New OleDbCommand("select peso " & _
        " from producto " & _
        " where codigo = " & idProducto, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener peso del producto. " & ex.Message)
            Return 0
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            PesoCampo = isnull(rst.Tables(0).Rows(0).Item("peso"), 0)
        Else
            PesoCampo = 0
        End If
        Return PesoCampo
    End Function

    Sub FormatoSpreadVaciado(ByVal filas As Integer)
        Dim tipotxt As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tipoint As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tiponumero As New FarPoint.Win.Spread.CellType.NumberCellType
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


        tiponumero.DecimalPlaces = 0
        tiponumero.Separator = ""
        tiponumero.MinimumValue = 0
        tiponumero.ShowSeparator = False

        'FORMATO GENERAL SPREAD

        MapeoSpread(fpVaciado)
        fpVaciado.EditModeReplace = True
        'fpVaciado.Size = New Size(780, 327)
        fpVaciado.Location = New Point(17, 85)
        fpVaciado.TabStripInsertTab = False
        fpVaciado.Sheets.Count = 1
        fpVaciado.ActiveSheet.GrayAreaBackColor = Color.White
        fpVaciado.Font = New Font("microsoft sans serif", 8.25, FontStyle.Bold)
        fpVaciado.ActiveSheet.RowCount = filas
        fpVaciado.ActiveSheet.ColumnCount = 9

        'TAGS DE COLUMNAS
        fpVaciado.ActiveSheet.Columns(0).Tag = "folio"
        fpVaciado.ActiveSheet.Columns(1).Tag = "producto"
        fpVaciado.ActiveSheet.Columns(2).Tag = "nombreproducto"
        fpVaciado.ActiveSheet.Columns(3).Tag = "lote"
        fpVaciado.ActiveSheet.Columns(4).Tag = "nombrelote"
        fpVaciado.ActiveSheet.Columns(5).Tag = "banda"
        fpVaciado.ActiveSheet.Columns(6).Tag = "cajas"
        fpVaciado.ActiveSheet.Columns(7).Tag = "peso"
        fpVaciado.ActiveSheet.Columns(8).Tag = "cajasRestantes"


        'ALTURA DE FILAS
        fpVaciado.ActiveSheet.ColumnHeader.Rows(0).Height = 40

        'ANCHURA DE COLUMNAS
        fpVaciado.ActiveSheet.RowHeader.Columns(0).Width = 35
        fpVaciado.ActiveSheet.Columns("folio").Width = 80
        fpVaciado.ActiveSheet.Columns("cajas").Width = 100
        fpVaciado.ActiveSheet.Columns("producto").Width = 75
        fpVaciado.ActiveSheet.Columns("lote").Width = 60
        fpVaciado.ActiveSheet.Columns("nombreproducto").Width = 100
        fpVaciado.ActiveSheet.Columns("nombrelote").Width = 100
        fpVaciado.ActiveSheet.Columns("banda").Width = 100
        fpVaciado.ActiveSheet.Columns("peso").Width = 100
        fpVaciado.ActiveSheet.Columns("cajasRestantes").Width = 100

        'BLOQUEAR COLUMNAS
        fpVaciado.ActiveSheet.Columns("producto").Locked = True
        fpVaciado.ActiveSheet.Columns("nombreproducto").Locked = True
        fpVaciado.ActiveSheet.Columns("lote").Locked = True
        fpVaciado.ActiveSheet.Columns("nombrelote").Locked = True

        'TIPOS DE CELDAS
        fpVaciado.ActiveSheet.Columns("folio").CellType = tipotxt
        fpVaciado.ActiveSheet.Columns("cajas").CellType = tipoint
        fpVaciado.ActiveSheet.Columns("producto").CellType = tiponumero
        fpVaciado.ActiveSheet.Columns("lote").CellType = tiponumero
        fpVaciado.ActiveSheet.Columns("nombreproducto").CellType = tipotxt
        fpVaciado.ActiveSheet.Columns("nombrelote").CellType = tipotxt
        fpVaciado.ActiveSheet.Columns("banda").CellType = tiponumero
        fpVaciado.ActiveSheet.Columns("peso").CellType = tipodob
        fpVaciado.ActiveSheet.Columns("cajasRestantes").CellType = tipotxt

        fpVaciado.ActiveSheet.Columns("nombreproducto").Locked = True
        fpVaciado.ActiveSheet.Columns("nombrelote").Locked = True
        fpVaciado.ActiveSheet.Columns("cajasRestantes").Locked = True

        'TEXTO DE ENCABEZADOS
        fpVaciado.ActiveSheet.ColumnHeader.Cells(0, fpVaciado.ActiveSheet.Columns("folio").Index).Text = "FOLIO ACARREO"
        fpVaciado.ActiveSheet.ColumnHeader.Cells(0, fpVaciado.ActiveSheet.Columns("cajas").Index).Text = "CAJAS"
        fpVaciado.ActiveSheet.ColumnHeader.Cells(0, fpVaciado.ActiveSheet.Columns("banda").Index).Text = "BANDA"
        fpVaciado.ActiveSheet.ColumnHeader.Cells(0, fpVaciado.ActiveSheet.Columns("producto").Index).Text = "PRODUCTO"
        fpVaciado.ActiveSheet.ColumnHeader.Cells(0, fpVaciado.ActiveSheet.Columns("lote").Index).Text = "LOTE"
        fpVaciado.ActiveSheet.ColumnHeader.Cells(0, fpVaciado.ActiveSheet.Columns("nombreproducto").Index).Text = "NOM. PROD"
        fpVaciado.ActiveSheet.ColumnHeader.Cells(0, fpVaciado.ActiveSheet.Columns("nombrelote").Index).Text = "NOM. LOTE"
        fpVaciado.ActiveSheet.ColumnHeader.Cells(0, fpVaciado.ActiveSheet.Columns("peso").Index).Text = "UNIDAD DE MEDIA"
        fpVaciado.ActiveSheet.ColumnHeader.Cells(0, fpVaciado.ActiveSheet.Columns("cajasRestantes").Index).Text = "Cajas Restantes".ToUpper

    End Sub

    Sub CargaProductorVac(ByVal productor As Integer)
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        cmd = New OleDbCommand("select nombre from embarcador where codigo = " & productor, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener productor. " & ex.Message)
            Exit Sub
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            txtNombreProdVac.Text = isnull(rst.Tables(0).Rows(0).Item(0), "")
            fpVaciado.Focus()
        Else
            txtNombreProdVac.Text = ""
            txtIdProdVaciado.Text = ""
            txtIdProdVaciado.Focus()
        End If
    End Sub

    Function CargaProductoVac(ByVal producto As Integer) As String
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim nombre As String = String.Empty
        cmd = New OleDbCommand("select descex from producto where codigo = " & producto, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener producto. " & ex.Message)
            Return ""
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            nombre = isnull(rst.Tables(0).Rows(0).Item(0), "")

        End If
        Return nombre
    End Function

    Function CargaLoteVac(ByVal lote As Integer) As String
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim nombre As String = ""
        cmd = New OleDbCommand("select descri from lote where codigo = " & lote, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener lote. " & ex.Message)
            Return ""
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            nombre = isnull(rst.Tables(0).Rows(0).Item(0), "")

        End If
        Return nombre
    End Function
#End Region

    Private Sub tbAcarreo1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbAcarreo1.SelectedIndexChanged

        If spHistorial.Visible Then
            spHistorial.Visible = False
        End If
        If tbAcarreo1.SelectedIndex = 0 Then
            ToolTip1.SetToolTip(Button5, "Eliminar Folio de Acarreo")
            ToolTip1.SetToolTip(Button12, "Historial de Acarreo")
            txtHora.Text = Now.ToString("HH:mm")
            txtFolio.Focus()
        ElseIf tbAcarreo1.SelectedIndex = 1 Then
            mskFechaVaciado.Text = Today.ToShortDateString
            'mskHoraVaciado.Text = Now.Hour.ToString().PadLeft(2, "0") + ":00"
            mskHoraVaciado.Text = Now.ToString("HH:mm")
            ToolTip1.SetToolTip(Button5, "Eliminar Vaciado")
            ToolTip1.SetToolTip(Button12, "Historial de Vaciado")
            mskFechaVaciado.Focus()
        ElseIf tbAcarreo1.SelectedIndex = 2 Then
            ToolTip1.SetToolTip(Button5, "Eliminar Folio de Piso")
            ToolTip1.SetToolTip(Button12, "Historial de Piso")
            mskHoraPiso.Text = Now.ToString("HH:mm")
            txtFolioPiso.Focus()
            txtFolioPiso.SelectAll()
        End If

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtFolio.Focus()
    End Sub

    Private Sub fpVaciado_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles fpVaciado.DialogKey

        If e.KeyCode = Keys.Enter And Not fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("cajasRestantes").Index Then
            ManejoSpreadVaciado()
        ElseIf e.KeyData = Keys.F9 Then
            CalculoBorrado()
            Try
                fpVaciado.ActiveSheet.RemoveRows(fpVaciado.ActiveSheet.ActiveRowIndex, 1)
            Catch
            End Try
        ElseIf e.KeyData = Keys.Escape Then
                txtIdProdVaciado.Focus()
        End If

    End Sub

    Private Sub fpVaciado_KeyDown(sender As Object, e As KeyEventArgs) Handles fpVaciado.KeyDown

        If e.KeyCode = Keys.Enter And Not fpVaciado.ActiveSheet.ActiveColumnIndex = fpVaciado.ActiveSheet.Columns("folio").Index Then
            ManejoSpreadVaciado()
        End If

    End Sub

    Private Sub fpVaciado_SubEditorOpening(sender As Object, e As FarPoint.Win.Spread.SubEditorOpeningEventArgs) Handles fpVaciado.SubEditorOpening
        e.Cancel = True
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Impresion.contlstpalets = 0
        Impresion.ConsultaInfo(Me.txtFolio.Text, Me.txtLote.Text, Me.spAcarreo.ActiveSheet.Cells(0, 0).Text, Me.txtFecha.Text)
        If Impresion.listInfo.Count > 0 Then
            If Not String.IsNullOrEmpty(Impresion.listInfo.Item(0)) And Not String.IsNullOrEmpty(Impresion.listInfo.Item(1)) And Not String.IsNullOrEmpty(Impresion.listInfo.Item(1)) Then
                Impresion.ComenzarImpresion()
            End If
        End If

    End Sub

    Private Sub btnHerramientas_Click(sender As Object, e As EventArgs) Handles btnHerramientas.Click

        Impresion.Show()
        Me.Hide()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub btnSobrantes_Click(sender As Object, e As EventArgs) Handles btnSobrantes.Click

        GenerarReportesVaciado()

    End Sub

    Private Sub GenerarReportesVaciado()

        ReportesVaciado.Show()

    End Sub

    Private Sub rbtnCajasBlancas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCajasGrises.CheckedChanged, rbtnCajasBlancas.CheckedChanged

        If rbtnCajasBlancas.Checked Then
            lblFactorConversion.Text = "FACTOR DE CONVERSION ACTUAL: " & ObtenerFactorConversionCajaBlanca("Blanca")
            RecalcularCajasConFactor()
        ElseIf rbtnCajasGrises.Checked Then
            lblFactorConversion.Text = "FACTOR DE CONVERSION ACTUAL: " & ObtenerFactorConversionCajaBlanca("Gris")
            RecalcularCajasConFactor()
        End If

    End Sub

    Private Sub RecalcularCajasConFactor()

        For index As Integer = 0 To fpPiso.ActiveSheet.Rows.Count - 1
            If fpPiso.ActiveSheet.Rows.Count > 0 Then
                If IsNumeric(fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("cajas").Index).Text) Then
                    Dim cajas As Double = CDbl(fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("cajas").Index).Text)
                    cajas = cajas * factor
                    fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("cajasEmpaque").Index).Text = cajas.ToString
                    ' Se puso al lote 1 ya que no maneja en si piso de un lote especifico.
                    fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("peso").Index).Text = fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("cajasEmpaque").Index).Text * ObtenerPesoCampo(1)
                End If
            End If
        Next

    End Sub

    ' Obsoleto. Ya no se usa.
    Private Sub RecalcularCajasUnaAUna()

        For index As Integer = 0 To fpPiso.ActiveSheet.Rows.Count - 1
            If fpPiso.ActiveSheet.Rows.Count > 0 Then
                If IsNumeric(fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("cajas").Index).Text) Then
                    fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("cajasEmpaque").Index).Text = fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("cajas").Index).Text
                    fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("peso").Index).Text = fpPiso.ActiveSheet.Cells(index, fpPiso.ActiveSheet.Columns("cajas").Index).Text * ObtenerPesoCampo(1)
                End If
            End If
        Next

    End Sub

    Private Function ObtenerFactorConversionCajaBlanca(ByVal campo As String) As String

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataTable
        Dim query As String = "SELECT " & campo & " FROM FactorCajasCampo"
        cmd = New OleDbCommand(query, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener el factor de conversión. " & ex.Message, MsgBoxStyle.Critical, "Error de consulta.")
            Return 1
        End Try
        If rst.Rows.Count > 0 Then
            factor = isnull(rst.Rows(0).Item(campo), 1)
        Else
            factor = 1
        End If
        Return factor

    End Function

End Class
