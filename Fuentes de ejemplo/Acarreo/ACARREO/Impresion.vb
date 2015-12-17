Imports System.Data.OleDb
Imports System.Threading

Public Class Impresion

    Public contlstpalets As Integer = 0
    Public listInfo As List(Of String)
    Dim CmargenIzquierdo As Integer
    Dim CmargenSuperior As Integer
    Dim PmargenIzquierdo As Integer
    Dim PmargenSuperior As Integer

#Region "Eventos"

    Private Sub Impresion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Principal.Show()
        Me.Hide()

    End Sub

    Private Sub Impresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterToScreen()
        txtFecha.Text = Today
        CargarConfiguracionImpresora()

    End Sub

    Private Sub sp6_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles spImpresoras.CellDoubleClick
        Dim cmd As New OleDb.OleDbCommand
        Dim adap As New OleDb.OleDbDataAdapter
        Dim rst As New DataSet
        If OPK = 1 Then
            If spImpresoras.Sheets(0).Cells(spImpresoras.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
                txtImpresoraPalet.Text = spImpresoras.Sheets(0).Cells(spImpresoras.Sheets(0).ActiveRowIndex, 1).Text
                cmd = New OleDbCommand("update infosys set pathAcarreo = '" & txtImpresoraPalet.Text & "'", conexionAccess)
                If conexionAccess.State = ConnectionState.Closed Then
                    conexionAccess.Open()
                End If
                cmd.ExecuteNonQuery()
                conexionAccess.Close()
                cmd.Dispose()
                spImpresoras.Visible = False
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, Button1.Click
        If sender.Equals(Button1) Then
            OPK = 1
        Else
            OPK = 2
        End If
        spImpresoras.Sheets(0).ClearRange(0, 0, 50, 50, True)
        spImpresoras.Font = New System.Drawing.Font("microsoft sans serif", 8.25, FontStyle.Bold)
        For R As Integer = 0 To System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
            spImpresoras.Sheets(0).Cells(R, 0).Text = R + 1
            spImpresoras.Sheets(0).Cells(R, 1).Text = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Item(R)
        Next
        If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count < 10 Then
            spImpresoras.Sheets(0).Rows.Count = 10
        Else
            spImpresoras.Sheets(0).Rows.Count = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count
        End If
        spImpresoras.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spImpresoras.Size = New Size(421, 224)
        spImpresoras.Location = New Point(15, 169)
        spImpresoras.Sheets(0).ColumnHeader.Cells(0, 0).Text = "No."
        spImpresoras.Sheets(0).ColumnHeader.Cells(0, 1).Text = "IMPRESORA"
        spImpresoras.Sheets(0).Columns(0).Width = 40
        spImpresoras.Sheets(0).Columns(1).Width = 325
        spImpresoras.Sheets(0).Columns.Count = 2
        spImpresoras.Sheets(0).OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly

        If spImpresoras.Visible Then
            spImpresoras.Hide()
        Else
            spImpresoras.Show()
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim TH As New Thread(AddressOf imetiquetas)
        'lstetiquetaspalet = New List(Of System.Data.DataRow)
        listInfo.Clear()
        txtFecha.Text = Today
        TH.Start()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click

        Principal.Show()
        Me.Hide()

    End Sub

    Private Sub txtImpresoraPalet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImpresoraPalet.TextChanged

        nombreImpresora = txtImpresoraPalet.Text

    End Sub

#End Region

#Region "Metodos Privados Imprimir etiquetas"

    Public Sub CargarConfiguracionImpresora()

        Dim cmd As New OleDb.OleDbCommand
        Dim adap As New OleDb.OleDbDataAdapter
        Dim rst As New DataSet
        Dim cmd1 As New OleDbCommand
        Dim adap1 As New OleDbDataAdapter
        Dim rst1 As New DataSet
        Try
            cmd = New OleDbCommand("select pathAcarreo, printtraz, prefijo, pmargenl, pmargent, cmargenl, cmargent, paletrandom, sscc from infosys", conexionAccess)
            adap.SelectCommand = cmd
            adap.Fill(rst)
            If rst.Tables(0).Rows.Count > 0 Then
                txtImpresoraPalet.Text = rst.Tables(0).Rows(0).Item(0)
                nombreImpresora = rst.Tables(0).Rows(0).Item(0)
                txtImpresoraCajas.Text = rst.Tables(0).Rows(0).Item(1)
            Else
                txtImpresoraPalet.Text = ""
                nombreImpresora = String.Empty
                txtImpresoraCajas.Text = ""
            End If
        Catch ex As Exception
            cmd.Dispose()
            adap.Dispose()
            rst.Dispose()
            rst.Reset()
            rst.Clear()
            txtImpresoraPalet.Text = ""
            nombreImpresora = String.Empty
            txtImpresoraCajas.Text = ""
        End Try

        If cbTipoImpresion.SelectedIndex = -1 Then
            cbTipoImpresion.SelectedIndex = 0
        End If

    End Sub

    Public Sub ComenzarImpresion()

        imetiquetas()
        listInfo = New List(Of String)
        listInfo.Clear()


    End Sub

    Private Sub EtiquetaPaletDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles EtiquetaPaletDocument.PrintPage

        If IsNumeric(Principal.txtCantidadImprimir.Text) Then
            Dim numeroImpresiones As Integer = CInt(Principal.txtCantidadImprimir.Text)
            If obtenerTipoEtiquetaPaletTag() = 0 Then
                CrearEtiqueta4x2(e)
            ElseIf obtenerTipoEtiquetaPaletTag() = 1 Then
                CrearEtiquetaTresPuntoCincoPorTres(e)
            End If
        End If

    End Sub

    Sub imetiquetas()

        txtImpresoraPalet.Text = nombreImpresora
        EtiquetaPaletDocument.PrinterSettings.PrinterName = nombreImpresora
        Try
            EtiquetaPaletDocument.Print()
        Catch ex As Exception
            MsgBox("Error de impresion. " & ex.Message)
        End Try

    End Sub

    Delegate Function getTipoPaletTag() As Integer

    Function obtenerTipoEtiquetaPaletTag() As Integer

        If cbTipoImpresion.InvokeRequired Then
            Dim getPaletTag As New getTipoPaletTag(AddressOf obtenerTipoEtiquetaPaletTag)
            Return Invoke(getPaletTag)
        Else
            Return cbTipoImpresion.SelectedIndex
        End If

    End Function

    Private Function ObtenerLogo() As System.Drawing.Image

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        Dim rutaLogo As String = String.Empty
        Dim img As System.Drawing.Image
        'OBTIENE RUTA DEL LOGO
        cmd = New OleDbCommand("select rutalogo from tipoetiqueta where codigo = " & 1 & " AND Productor = " & Principal.txtIdProductor.Text, conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener ruta de logo " & ex.Message)
            Return img
            Exit Function
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            rutaLogo = isnull(rst.Tables(0).Rows(0).Item("rutalogo"), "")
        Else
            rutaLogo = ""
        End If
        If IO.File.Exists(rutaLogo) Then
            img = System.Drawing.Image.FromFile(rutaLogo)
        Else
            img = Nothing
        End If
        Return img

    End Function

    Sub CrearEtiquetaTresPuntoCincoPorTres(ByRef e As System.Drawing.Printing.PrintPageEventArgs)

        Dim fuenteCodigoBarrasChico As New Font("microsoft sans serif", 7, FontStyle.Bold)
        Dim fuenteDescripcionChico As New Font("microsoft sans serif", 6, FontStyle.Bold)
        Dim fuenteHandHeld As New Font("microsoft sans serif", 5, FontStyle.Bold)
        Dim fuentedescripcion As New Font("microsoft sans serif", 8, FontStyle.Bold)
        Dim fuenteCodigoBarras As New Font("microsoft sans serif", 23, FontStyle.Bold)
        Dim fuenteDescripcionExtraChico As New Font("microsoft sans serif", 4, FontStyle.Bold)
        Dim img As System.Drawing.Image = Nothing
        Dim strFormat As New StringFormat()
        strFormat.Alignment = StringAlignment.Center

        'If System.IO.File.Exists("\asys21\sys21bn.jpg") Then
        '    img = System.Drawing.Image.FromFile("\asys21\sys21bn.jpg")
        'Else
        '    img = Nothing
        'End If

        'INICIAN IMPRESIONES 
        img = ObtenerLogo()

        If Not img Is Nothing Then
            e.Graphics.DrawImage(img, PmargenIzquierdo + 185, PmargenSuperior + 250, 80, 80) 'LOGO
        End If

        e.Graphics.DrawImage(Barras(isnull(listInfo.Item(0), "00000")), PmargenIzquierdo + 51, PmargenSuperior + 63, 173, 33) ' Codigo de barras Folio
        e.Graphics.DrawString("Folio: " & isnull(listInfo.Item(0), "folio"), fuenteCodigoBarras, Brushes.Black, PmargenIzquierdo + 140, PmargenSuperior + 96, strFormat) ' Folio 
        e.Graphics.DrawString("Lote: " & isnull(listInfo.Item(1), "lote"), fuenteCodigoBarras, Brushes.Black, PmargenIzquierdo + 140, PmargenSuperior + 146, strFormat) ' Lote
        e.Graphics.DrawString("Bultos: " & isnull(listInfo.Item(2), "bultos"), fuenteCodigoBarras, Brushes.Black, PmargenIzquierdo + 50, PmargenSuperior + 196) ' Bultos
        e.Graphics.DrawString(isnull(listInfo.Item(3), "fecha"), fuenteCodigoBarras, Brushes.Black, PmargenIzquierdo + 10, PmargenSuperior + 300) ' Bultos

        contlstpalets += 1
        If contlstpalets < CInt(Principal.txtCantidadImprimir.Text) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub

    Private Sub CrearEtiqueta4x2(ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim fuenteCodigoBarrasChico As New Font("microsoft sans serif", 7, FontStyle.Bold)
        Dim fuenteDescripcionChico As New Font("microsoft sans serif", 6, FontStyle.Bold)
        Dim fuenteHandHeld As New Font("microsoft sans serif", 5, FontStyle.Bold)
        Dim fuentedescripcion As New Font("microsoft sans serif", 8, FontStyle.Bold)
        Dim fuenteCodigoBarras As New Font("microsoft sans serif", 23, FontStyle.Bold)
        Dim fuenteDescripcionExtraChico As New Font("microsoft sans serif", 4, FontStyle.Bold)
        Dim img As System.Drawing.Image = Nothing
        Dim strFormat As New StringFormat()
        strFormat.Alignment = StringAlignment.Center

        'INICIAN IMPRESIONES 
        img = ObtenerLogo()

        If Not img Is Nothing Then
            e.Graphics.DrawImage(img, PmargenIzquierdo + 285, PmargenSuperior + 5, 80, 80) 'LOGO
        End If

        e.Graphics.DrawImage(Barras(isnull(listInfo.Item(0), "00000")), PmargenIzquierdo + 45, PmargenSuperior + 5, 173, 33) ' Codigo de barras Folio
        e.Graphics.DrawString("Folio: " & isnull(listInfo.Item(0), "folio"), fuenteCodigoBarras, Brushes.Black, PmargenIzquierdo + 30, PmargenSuperior + 45) ' Folio 
        e.Graphics.DrawString("Lote: " & isnull(listInfo.Item(1), "lote"), fuenteCodigoBarras, Brushes.Black, PmargenIzquierdo + 30, PmargenSuperior + 85) ' Lote
        e.Graphics.DrawString("Bultos: " & isnull(listInfo.Item(2), "bultos"), fuenteCodigoBarras, Brushes.Black, PmargenIzquierdo + 30, PmargenSuperior + 125) ' Bultos
        e.Graphics.DrawString(isnull(listInfo.Item(3), "fecha"), fuenteCodigoBarras, Brushes.Black, PmargenIzquierdo + 30, PmargenSuperior + 165) ' Bultos

        contlstpalets += 1
        If contlstpalets < CInt(Principal.txtCantidadImprimir.Text) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If


    End Sub


    Sub ConsultaInfo(ByVal folio As String, ByVal lote As String, ByVal bultos As String, ByVal fecha As String)

        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        listInfo = New List(Of String)
        listInfo.Clear()
        listInfo.Add(folio)
        listInfo.Add(lote)
        listInfo.Add(bultos)
        listInfo.Add(fecha)

    End Sub

    Function Barras(ByVal texto As String) As Image
        Dim imagenbarra As Image = Nothing
        imagenbarra = BarCode.Code128(texto, BarCode.Code128SubTypes.CODE128_UCC, False, 80)
        Return imagenbarra
    End Function

    Function ObtenerFechaCodificada(ByVal fecha As Date) As String
        Dim fechacodificada As String = ""
        Dim cmd As New OleDbCommand
        Dim adap As New OleDbDataAdapter
        Dim rst As New DataSet
        'OBTENER CODIFICACIONES
        'PRIMER DIGITO DEL MES
        rst = New DataSet
        cmd = New OleDbCommand("select letra from equivalenciaFechas where numero = " & Mid(CStr(Month(fecha)).PadLeft(2, "0"), 1, 1), conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener fecha codificada")
            Return "-1"
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            fechacodificada &= rst.Tables(0).Rows(0)(0)
        End If
        rst.Reset()
        rst.Clear()
        'SEGUNDO DIGITO DEL MES
        rst = New DataSet
        cmd = New OleDbCommand("select letra from equivalenciaFechas where numero = " & Mid(CStr(Month(fecha)).PadLeft(2, "0"), 2, 1), conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener fecha codificada")
            Return "-1"
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            fechacodificada &= rst.Tables(0).Rows(0)(0)
        End If
        rst.Reset()
        rst.Clear()
        'PRIMER DIGITO DEL DIA
        rst = New DataSet
        cmd = New OleDbCommand("select letra from equivalenciaFechas where numero = " & Mid(CStr(fecha.Day).PadLeft(2, "0"), 1, 1), conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener fecha codificada")
            Return "-1"
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            fechacodificada &= rst.Tables(0).Rows(0)(0)
        End If
        rst.Reset()
        rst.Clear()
        'SEGUNDO DIGITO DEL DIA
        rst = New DataSet
        cmd = New OleDbCommand("select letra from equivalenciaFechas where numero = " & Mid(CStr(fecha.Day).PadLeft(2, "0"), 2, 1), conexionAccess)
        adap.SelectCommand = cmd
        Try
            adap.Fill(rst)
        Catch ex As Exception
            MsgBox("Error al obtener fecha codificada")
            Return "-1"
        End Try
        If rst.Tables(0).Rows.Count > 0 Then
            fechacodificada &= rst.Tables(0).Rows(0)(0)
        End If
        rst.Reset()
        rst.Clear()
        rst.Dispose()
        adap.Dispose()
        cmd.Dispose()
        Return fechacodificada

    End Function

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

#End Region

End Class