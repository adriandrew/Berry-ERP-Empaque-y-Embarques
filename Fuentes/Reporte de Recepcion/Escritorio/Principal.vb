﻿Imports System.IO
Imports FarPoint.Win.Spread
Imports System.Reflection

Public Class Principal

    ' Variables de objetos de entidades.
    Public recepcion As New EYEEntidadesReporteRecepcion.Recepcion()
    Public usuarios As New EYEEntidadesReporteRecepcion.Usuarios()
    Public lotes As New EYEEntidadesReporteRecepcion.Lotes()
    Public choferesCampos As New EYEEntidadesReporteRecepcion.ChoferesCampos()
    Public productos As New EYEEntidadesReporteRecepcion.Productos()
    Public variedades As New EYEEntidadesReporteRecepcion.Variedades()
    Public empresas As New EYEEntidadesReporteRecepcion.Empresas()
    ' Variables de tipos de datos de spread.
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoBooleano As New FarPoint.Win.Spread.CellType.CheckBoxCellType()
    ' Variables de formatos de spread.
    Public Shared tipoLetraSpread As String = "Microsoft Sans Serif" : Public Shared tamañoLetraSpread As Integer = 11
    Public Shared alturaFilasEncabezadosGrandesSpread As Integer = 35 : Public Shared alturaFilasEncabezadosMedianosSpread As Integer = 28
    Public Shared alturaFilasEncabezadosChicosSpread As Integer = 22 : Public Shared alturaFilasSpread As Integer = 20
    Public Shared colorAreaGris = Color.White
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public opcionSeleccionada As Integer = 0
    Public estaMostrado As Boolean = False
    Public ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public rutaTemporal As String = CurDir() & "\ArchivosTemporales"
    Public estaCerrando As Boolean = False
    Public prefijoBaseDatosEmpaque As String = "EYE" & "_"
    Public colorFiltros As Color
    ' Variable de desarrollo.
    Public esDesarrollo As Boolean = False

#Region "Eventos"

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Cursor = Cursors.WaitCursor
        EliminarArchivosTemporales()
        Dim nombrePrograma As String = "PrincipalBerry"
        AbrirPrograma(nombrePrograma, True)
        System.Threading.Thread.Sleep(5000)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Me.estaCerrando = True
        Desvanecer()

    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        CargarNombrePrograma()
        AsignarTooltips()
        ConfigurarConexiones()
        CargarTiposDeDatos()

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Me.Cursor = Cursors.AppStarting
        Me.Enabled = False
        CargarEncabezados()
        CargarTitulosDirectorio()
        CargarValorColor()
        CargarComboLotes()
        CargarComboChoferes()
        CargarComboProductos()
        CargarComboVariedades()
        Me.estaMostrado = True
        Me.Enabled = True
        AsignarFoco(dtpFecha)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Application.Exit()

    End Sub

    Private Sub btnGuardar_MouseEnter(sender As Object, e As EventArgs)

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub btnSalir_MouseEnter(sender As Object, e As EventArgs) Handles btnSalir.MouseEnter

        AsignarTooltips("Salir.")

    End Sub

    Private Sub pnlCuerpo_MouseEnter(sender As Object, e As EventArgs) Handles pnlPie.MouseEnter, pnlEncabezado.MouseEnter, pnlCuerpo.MouseEnter

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        GenerarReporte()

    End Sub

    Private Sub btnGenerar_MouseEnter(sender As Object, e As EventArgs) Handles btnGenerar.MouseEnter

        AsignarTooltips("Generar Reporte.")

    End Sub

    Private Sub pnlFiltros_MouseHover(sender As Object, e As EventArgs) Handles pnlFiltros.MouseHover, gbFechas.MouseHover, gbNiveles.MouseHover, chkFecha.MouseHover, cbLote.MouseHover, cbChofer.MouseHover, cbProducto.MouseHover, cbVariedad.MouseHover

        AlinearFiltrosNormal()
        AsignarTooltips("Filtros para Generar el Reporte.")

    End Sub

    Private Sub spActividades_MouseHover(sender As Object, e As EventArgs) Handles spReporte.MouseHover

        AlinearFiltrosIzquierda()
        AsignarTooltips("Reporte Generado.")

    End Sub

    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick

        If (Me.estaCerrando) Then
            Desvanecer()
        Else
            AlinearFiltrosIzquierda()
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Imprimir(False)

    End Sub

    Private Sub btnExportarPdf_Click(sender As Object, e As EventArgs) Handles btnExportarPdf.Click

        Imprimir(True)

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        ExportarExcel()

    End Sub

    Private Sub btnImprimir_MouseEnter(sender As Object, e As EventArgs) Handles btnImprimir.MouseEnter

        AsignarTooltips("Imprimir.")

    End Sub

    Private Sub btnExportarExcel_MouseEnter(sender As Object, e As EventArgs) Handles btnExportarExcel.MouseEnter

        AsignarTooltips("Exportar a Excel.")

    End Sub

    Private Sub btnExportarPdf_MouseEnter(sender As Object, e As EventArgs) Handles btnExportarPdf.MouseEnter

        AsignarTooltips("Exportar a Pdf.")

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click

        MostrarAyuda()

    End Sub

    Private Sub btnAyuda_MouseEnter(sender As Object, e As EventArgs) Handles btnAyuda.MouseEnter

        AsignarTooltips("Ayuda.")

    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged

        If (chkFecha.Checked) Then
            chkFecha.Text = "SI"
        Else
            chkFecha.Text = "NO"
        End If

    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFecha.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            AsignarFoco(dtpFechaFinal)
        End If

    End Sub

    Private Sub dtpFechaFinal_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaFinal.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            AsignarFoco(cbLote)
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(dtpFecha)
        End If

    End Sub

    Private Sub cbAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles cbLote.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbLote.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            Else
                AsignarFoco(cbChofer)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(dtpFechaFinal)
        End If

    End Sub

    Private Sub cbFamilia_KeyDown(sender As Object, e As KeyEventArgs) Handles cbChofer.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbChofer.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            Else
                AsignarFoco(cbProducto)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(cbLote)
        End If

    End Sub

    Private Sub cbSubFamilia_KeyDown(sender As Object, e As KeyEventArgs) Handles cbProducto.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbProducto.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            Else
                AsignarFoco(cbVariedad)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(cbChofer)
        End If

    End Sub

    Private Sub cbArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles cbVariedad.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbVariedad.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            Else
                AsignarFoco(btnGenerar)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(cbProducto)
        End If

    End Sub

    Private Sub btnGenerar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnGenerar.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            If (cbVariedad.Enabled) Then
                AsignarFoco(cbVariedad)
            ElseIf (cbProducto.Enabled) Then
                AsignarFoco(cbProducto)
            ElseIf (cbChofer.Enabled) Then
                AsignarFoco(cbChofer)
            ElseIf (cbLote.Enabled) Then
                AsignarFoco(cbLote)
            End If
        End If

    End Sub

#End Region

#Region "Métodos"

#Region "Básicos"

    Private Sub AsignarFoco(ByVal c As Control)

        c.Focus()

    End Sub

    Private Sub MostrarAyuda()

        Dim pnlAyuda As New Panel()
        Dim txtAyuda As New TextBox()
        If (pnlContenido.Controls.Find("pnlAyuda", True).Count = 0) Then
            pnlAyuda.Name = "pnlAyuda" : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
            pnlContenido.Controls.Add(pnlAyuda) : Application.DoEvents()
            txtAyuda.Name = "txtAyuda" : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlAyuda = pnlContenido.Controls.Find("pnlAyuda", False)(0) : Application.DoEvents()
            txtAyuda = pnlAyuda.Controls.Find("txtAyuda", False)(0) : Application.DoEvents()
        End If
        If (Not pnlAyuda.Visible) Then
            pnlCuerpo.Visible = False : Application.DoEvents()
            pnlAyuda.Visible = True : Application.DoEvents()
            pnlAyuda.Size = pnlCuerpo.Size : Application.DoEvents()
            pnlAyuda.Location = pnlCuerpo.Location : Application.DoEvents()
            pnlContenido.Controls.Add(pnlAyuda) : Application.DoEvents()
            txtAyuda.ScrollBars = ScrollBars.Both : Application.DoEvents()
            txtAyuda.Multiline = True : Application.DoEvents()
            txtAyuda.Width = pnlAyuda.Width - 10 : Application.DoEvents()
            txtAyuda.Height = pnlAyuda.Height - 10 : Application.DoEvents()
            txtAyuda.Location = New Point(5, 5) : Application.DoEvents()
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Reporte: " & vbNewLine & "En esta pantalla se desplegará el reporte de acuerdo a los filtros que se hayan seleccionado. " & vbNewLine & "En la parte izquierda se puede agregar cualquiera de los filtros. Existen unos botones que se encuentran en las fechas que contienen la palabra si o no, si la palabra mostrada es si, el rango de fecha correspondiente se incluirá como filtro para el reporte, esto aplica para todas las opciones de fechas. Posteriormente se procede a generar el reporte con los criterios seleccionados. Cuando se termine de generar dicho reporte, se habilitarán las opciones de imprimir, exportar a excel o exportar a pdf, en estas dos últimas el usuario puede guardarlos directamente desde el archivo que se muestra en pantalla si así lo desea, mas no desde el sistema directamente." : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlCuerpo.Visible = True : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
        End If

    End Sub

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Opacity = 0.98
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Private Sub CargarNombrePrograma()

        Me.nombreEstePrograma = Me.Text

    End Sub

    Private Sub AsignarTooltips()

        Dim tp As New ToolTip()
        tp.AutoPopDelay = 5000
        tp.InitialDelay = 0
        tp.ReshowDelay = 100
        tp.ShowAlways = True
        tp.SetToolTip(Me.btnSalir, "Salir.")
        tp.SetToolTip(Me.btnImprimir, "Imprimir.")
        tp.SetToolTip(Me.btnExportarExcel, "Exportar a Excel.")
        tp.SetToolTip(Me.btnExportarPdf, "Exportar a Pdf.")
        tp.SetToolTip(Me.btnGenerar, "Generar Reporte.")
        tp.SetToolTip(Me.pnlFiltros, "Filtros para Generar el Reporte.")
        tp.SetToolTip(Me.spReporte, "Datos del Reporte.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Public Sub ControlarSpreadEnter(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim valor1 As FarPoint.Win.Spread.InputMap
        Dim valor2 As FarPoint.Win.Spread.InputMap
        valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        valor1.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        valor1.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        valor2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        valor2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)

    End Sub

    Private Sub CargarTiposDeDatos()

        tipoDoble.DecimalPlaces = 2
        tipoDoble.DecimalSeparator = "."
        tipoDoble.Separator = ","
        tipoDoble.ShowSeparator = True
        tipoEntero.DecimalPlaces = 0
        tipoEntero.Separator = ","
        tipoEntero.ShowSeparator = True 

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            EYELogicaReporteRecepcion.Directorios.id = 1
            EYELogicaReporteRecepcion.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaReporteRecepcion.Directorios.usuarioSql = "AdminBerry"
            EYELogicaReporteRecepcion.Directorios.contrasenaSql = "@berry2017"
        Else
            EYELogicaReporteRecepcion.Directorios.ObtenerParametros()
            EYELogicaReporteRecepcion.Usuarios.ObtenerParametros()
        End If
        EYELogicaReporteRecepcion.Programas.bdCatalogo = "Catalogo" & EYELogicaReporteRecepcion.Directorios.id
        EYELogicaReporteRecepcion.Programas.bdConfiguracion = "Configuracion" & EYELogicaReporteRecepcion.Directorios.id
        EYELogicaReporteRecepcion.Programas.bdEmpaque = "Empaque" & EYELogicaReporteRecepcion.Directorios.id
        EYEEntidadesReporteRecepcion.BaseDatos.ECadenaConexionCatalogo = EYELogicaReporteRecepcion.Programas.bdCatalogo
        EYEEntidadesReporteRecepcion.BaseDatos.ECadenaConexionConfiguracion = EYELogicaReporteRecepcion.Programas.bdConfiguracion
        EYEEntidadesReporteRecepcion.BaseDatos.ECadenaConexionEmpaque = EYELogicaReporteRecepcion.Programas.bdEmpaque
        EYEEntidadesReporteRecepcion.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesReporteRecepcion.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesReporteRecepcion.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesReporteRecepcion.Usuarios)
        usuarios.EId = EYELogicaReporteRecepcion.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count = 1) Then
            EYELogicaReporteRecepcion.Usuarios.id = lista(0).EId
            EYELogicaReporteRecepcion.Usuarios.nombre = lista(0).ENombre
            EYELogicaReporteRecepcion.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaReporteRecepcion.Usuarios.nivel = lista(0).ENivel
            EYELogicaReporteRecepcion.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaReporteRecepcion.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub CargarTitulosDirectorio()

        Me.Text = "Programa:  " + Me.nombreEstePrograma + "              Directorio:  " + EYELogicaReporteRecepcion.Directorios.nombre + "              Usuario:  " + EYELogicaReporteRecepcion.Usuarios.nombre

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " + EYELogicaReporteRecepcion.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " + EYELogicaReporteRecepcion.Usuarios.nombre

    End Sub

    Private Sub CargarValorColor()

        Me.colorFiltros = pnlFiltros.BackColor

    End Sub

    Private Sub PonerFocoEnControl(ByVal c As Control)

        c.Focus()

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = EYELogicaReporteRecepcion.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteRecepcion.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteRecepcion.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteRecepcion.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteRecepcion.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteRecepcion.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteRecepcion.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteRecepcion.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaReporteRecepcion.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
        Try
            Dim proceso = Process.Start(ejecutarProgramaPrincipal)
            proceso.WaitForInputIdle()
            If (salir) Then
                If (Me.ShowIcon) Then
                    Me.ShowIcon = False
                End If
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show((Convert.ToString("No se puede abrir el programa principal en la ruta : " & ejecutarProgramaPrincipal.WorkingDirectory & "\") & nombre) & Environment.NewLine & Environment.NewLine & ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Desvanecer()

        temporizador.Interval = 10
        temporizador.Enabled = True
        temporizador.Start()
        If (Me.Opacity > 0) Then
            Me.Opacity -= 0.25 : Application.DoEvents()
        Else
            temporizador.Enabled = False
            temporizador.Stop()
        End If

    End Sub

#End Region

#Region "Todos"

    Private Sub Imprimir(ByVal esPdf As Boolean)

        Me.Cursor = Cursors.WaitCursor
        ' Se carga la información de la empresa.
        Dim lista As New List(Of EYEEntidadesReporteRecepcion.Empresas)
        empresas.EId = 0 ' Se busca la primer empresa.
        lista = empresas.Obtener(True)
        If (lista.Count = 0) Then
            MsgBox("No existen datos de la empresa para encabezados de impresión. Se cancelará la impresión.", MsgBoxStyle.Information, "Faltan datos.")
            Exit Sub
        End If
        Dim nombrePdf As String = "\Temporal.pdf"
        Dim fuente7 As Integer = 7 : Dim fuente8 As Integer = 8
        Dim encabezadoPuntoPago As String = String.Empty
        Dim informacionImpresion As New FarPoint.Win.Spread.PrintInfo
        impresor.AllowSelection = True
        impresor.AllowSomePages = True
        impresor.AllowCurrentPage = True
        informacionImpresion.Orientation = PrintOrientation.Landscape
        informacionImpresion.Margin.Top = 20
        informacionImpresion.Margin.Left = 20
        informacionImpresion.Margin.Right = 20
        informacionImpresion.Margin.Bottom = 20
        informacionImpresion.ShowBorder = False
        informacionImpresion.ShowGrid = False
        informacionImpresion.ZoomFactor = 0.6
        informacionImpresion.Printer = impresor.PrinterSettings.PrinterName
        informacionImpresion.Centering = FarPoint.Win.Spread.Centering.Horizontal
        informacionImpresion.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        informacionImpresion.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Dim encabezado1 As String = String.Empty
        Dim encabezado2 As String = String.Empty
        Dim encabezado3 As String = String.Empty
        encabezado1 = "/l/fz""" & fuente7 & """" & "Rfc " & lista(0).ERfc & "/c/fz""" & fuente7 & """" & lista(0).ENombre
        encabezado1 &= "/r/fz""" & fuente7 & """" & "Página /p de /pc"
        encabezado1 = encabezado1.ToUpper
        encabezado2 = "/l/fz""" & fuente7 & """" & lista(0).EDomicilio & "/c/fb1/fz""" & fuente8 & """" & lista(0).EDescripcion & "/r/fz""" & fuente7 & """" & "Fecha: " & Today.ToShortDateString
        encabezado2 = encabezado2.ToUpper
        encabezado3 = "/l/fz""" & fuente7 & """" & lista(0).ELocalidad & "/c/fb1/fz""" & fuente8 & """" & spReporte.ActiveSheet.SheetName & "/r/fz""" & fuente7 & """" & "Hora: " & Now.ToShortTimeString
        encabezado3 = encabezado3.ToUpper
        If esPdf Then
            Dim bandera As Boolean = True
            Dim obtenerRandom As System.Random = New System.Random()
            Try
                If (Not Directory.Exists(rutaTemporal)) Then
                    Directory.CreateDirectory(rutaTemporal)
                End If
            Catch ex As Exception
            End Try
            While bandera
                nombrePdf = "\" & obtenerRandom.Next(0, 99999).ToString.PadLeft(5, "0") & ".pdf"
                If Not File.Exists(rutaTemporal & nombrePdf) Then
                    bandera = False
                End If
            End While
            informacionImpresion.PdfWriteTo = PdfWriteTo.File
            informacionImpresion.PdfFileName = rutaTemporal & nombrePdf
            informacionImpresion.PrintToPdf = True
        End If
        informacionImpresion.Header = encabezado1 & "/n" & encabezado2 & "/n" & encabezado3
        informacionImpresion.Footer = "Creado por: Software Berry"
        For indice = 0 To spReporte.Sheets.Count - 1
            spReporte.Sheets(indice).PrintInfo = informacionImpresion
        Next
        If Not esPdf Then
            If impresor.ShowDialog = Windows.Forms.DialogResult.OK Then
                spReporte.PrintSheet(-1)
            End If
        Else
            spReporte.PrintSheet(-1)
            Try
                System.Diagnostics.Process.Start(nombrePdf)
                System.Diagnostics.Process.Start(rutaTemporal & nombrePdf)
            Catch
                System.Diagnostics.Process.Start(rutaTemporal & nombrePdf)
            End Try
        End If
        Me.Cursor = Cursors.Default
        Application.DoEvents()

    End Sub

    Private Sub ExportarExcel()

        Me.Cursor = Cursors.WaitCursor
        spParaClonar.Sheets.Clear()
        spParaClonar = ClonarSpread(spParaClonar)
        Dim bandera As Boolean = True
        Dim nombreExcel As String = "\Temporal.xls"
        Dim obtenerRandom As System.Random = New System.Random()
        FormatearExcel()
        Application.DoEvents()
        Try
            If (Not Directory.Exists(rutaTemporal)) Then
                Directory.CreateDirectory(rutaTemporal)
            End If
        Catch ex As Exception
        End Try
        While bandera
            nombreExcel = "\" & obtenerRandom.Next(0, 99999).ToString.PadLeft(5, "0") & ".xls"
            If Not File.Exists(rutaTemporal & nombreExcel) Then
                bandera = False
            End If
        End While
        spParaClonar.SaveExcel(rutaTemporal & nombreExcel, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly)
        System.Diagnostics.Process.Start(rutaTemporal & nombreExcel)
        Me.Cursor = Cursors.Default

    End Sub

    Private Function ClonarSpread(baseObject As FpSpread) As FpSpread

        'Copying to a memory stream
        Dim ms As New System.IO.MemoryStream()
        FarPoint.Win.Spread.Model.SpreadSerializer.SaveXml(spReporte, ms, False)
        ms = New System.IO.MemoryStream(ms.ToArray())
        'Copying from memory stream to clone spread object
        Dim newSpread As New FarPoint.Win.Spread.FpSpread()
        FarPoint.Win.Spread.Model.SpreadSerializer.OpenXml(newSpread, ms)
        Dim fInfo As FieldInfo() = GetType(FarPoint.Win.Spread.FpSpread).GetFields(BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic Or BindingFlags.[Static])
        For Each field As FieldInfo In fInfo
            If field IsNot Nothing Then
                Dim del As [Delegate] = Nothing
                If field.FieldType.Name.Contains("EventHandler") Then
                    del = DirectCast(field.GetValue(baseObject), [Delegate])
                End If

                If del IsNot Nothing Then
                    Dim eInfo As EventInfo = GetType(FarPoint.Win.Spread.FpSpread).GetEvent(del.Method.Name.Substring(del.Method.Name.IndexOf("_"c) + 1))
                    If eInfo IsNot Nothing Then
                        eInfo.AddEventHandler(newSpread, del)
                    End If
                End If
            End If
        Next
        Return newSpread

    End Function

    Private Sub FormatearExcel()

        ' Se carga la información de la empresa.
        Dim lista As New List(Of EYEEntidadesReporteRecepcion.Empresas)
        empresas.EId = 0 ' Se busca la primer empresa.
        lista = empresas.Obtener(True)
        If (lista.Count = 0) Then
            MsgBox("No existen datos de la empresa para encabezados de impresión. Se cancelará la impresión.", MsgBoxStyle.Information, "Faltan datos.")
            Exit Sub
        End If
        Dim fuente6 As Integer = 6
        Dim fuente7 As Integer = 7
        Dim fuente8 As Integer = 8
        Dim encabezado1I As String = String.Empty
        Dim encabezado1C As String = String.Empty
        Dim encabezado2I As String = String.Empty
        Dim encabezado2C As String = String.Empty
        Dim encabezado2D As String = String.Empty
        Dim encabezado3I As String = String.Empty
        Dim encabezado3C As String = String.Empty
        Dim encabezado3D As String = String.Empty
        encabezado1I = "RFC " & lista(0).ERfc : encabezado1I = encabezado1I.ToUpper
        encabezado1C = lista(0).ENombre : encabezado1C = encabezado1C.ToUpper
        encabezado2I = lista(0).EDomicilio : encabezado2I = encabezado2I.ToUpper
        encabezado2C = lista(0).EDescripcion : encabezado2C = encabezado2C.ToUpper
        encabezado2D = "Fecha: " & Today.ToShortDateString : encabezado2D = encabezado2D.ToUpper
        encabezado3I = lista(0).ELocalidad : encabezado3I = encabezado3I.ToUpper
        encabezado3C = spReporte.ActiveSheet.SheetName : encabezado3C = encabezado3C.ToUpper
        encabezado3D = "Hora: " & Now.ToShortTimeString : encabezado3D = encabezado3D.ToUpper
        For indice = 0 To spParaClonar.Sheets.Count - 1
            spParaClonar.Sheets(indice).Columns.Count = spReporte.Sheets(indice).Columns.Count + 10
            spParaClonar.Sheets(indice).Protect = False
            spParaClonar.Sheets(indice).ColumnHeader.Rows.Add(0, 6)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(0, 0, 1, 3) 'spParaClonar.Sheets(i).ColumnCount 
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(0, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(0, 8, 1, 2)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(1, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(1, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(1, 8, 1, 2)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(2, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(2, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(2, 8, 1, 2)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(3, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(3, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(4, 0, 1, spParaClonar.Sheets(indice).ColumnCount)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 0).Text = encabezado1I
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 3).Text = encabezado1C
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).Text = encabezado2I
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).Text = encabezado2C
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).Text = encabezado2D
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).Text = encabezado3I
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).Text = encabezado3C
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).Text = encabezado3D
            spParaClonar.Sheets(indice).ColumnHeader.Cells(4, 0).Border = New FarPoint.Win.LineBorder(Color.Black, 1, False, True, False, False)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Next
        spParaClonar.ActiveSheet.Protect = False
        spParaClonar.ActiveSheet.Rows.Count += 20 ' Se aumenta la cantidad de filas debido a un bug del spread al exportar a excel.

    End Sub

    Private Sub EliminarArchivosTemporales()

        Try
            If Directory.Exists(rutaTemporal) Then
                Directory.Delete(rutaTemporal, True)
                Directory.CreateDirectory(rutaTemporal)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AlinearFiltrosIzquierda()

        temporizador.Interval = 1
        temporizador.Enabled = True
        temporizador.Start()
        Dim ancho As Integer = -(pnlFiltros.Width - (pnlFiltros.Width / 3))
        If (pnlFiltros.Location.X > ancho) Then
            pnlFiltros.Location = New Point(pnlFiltros.Location.X - 80, pnlFiltros.Location.Y)
            spReporte.Location = New Point(spReporte.Location.X - 80, spReporte.Location.Y)
            Application.DoEvents()
        Else
            temporizador.Enabled = False
            temporizador.Stop()
            AlinearFiltrosIzquierda2()
        End If

    End Sub

    Private Sub AlinearFiltrosIzquierda2()

        pnlFiltros.BackColor = Color.Gray
        btnGenerar.Enabled = False
        spReporte.Width = pnlCuerpo.Width - 80
        Application.DoEvents()

    End Sub

    Private Sub AlinearFiltrosNormal()

        pnlFiltros.Left = 0
        pnlFiltros.BackColor = Me.colorFiltros
        btnGenerar.Enabled = True
        System.Threading.Thread.Sleep(250)
        spReporte.Width = pnlCuerpo.Width - pnlFiltros.Width - 5
        spReporte.Location = New Point(pnlFiltros.Location.X + pnlFiltros.Width + 5, pnlFiltros.Location.Y)
        Application.DoEvents()

    End Sub

    Private Sub GenerarReporte()

        Me.Cursor = Cursors.WaitCursor
        FormatearSpread()
        Dim datos As New DataTable
        If (Me.estaMostrado) Then
            recepcion.EIdLote = cbLote.SelectedValue
            recepcion.EIdChofer = cbChofer.SelectedValue
            recepcion.EIdProducto = cbProducto.SelectedValue
            recepcion.EIdVariedad = cbVariedad.SelectedValue
        End If
        Dim fecha As Date = dtpFecha.Value.ToShortDateString : Dim fecha2 As Date = dtpFechaFinal.Value.ToShortDateString
        Dim aplicaFecha As Boolean = False
        If (chkFecha.Checked) Then
            aplicaFecha = True
            recepcion.EFecha = fecha : recepcion.EFecha2 = fecha2
        Else
            aplicaFecha = False
        End If
        datos = recepcion.ObtenerListadoReporte(aplicaFecha)
        spReporte.ActiveSheet.DataSource = datos
        FormatearSpreadReporte(spReporte.ActiveSheet.Columns.Count)
        CalcularTotales(0, "Total", spReporte.ActiveSheet.Columns("cantidadCajas").Index, spReporte.ActiveSheet.Columns("cantidadCajas").Index, spReporte.ActiveSheet.Columns.Count, 0, spReporte.ActiveSheet.Rows.Count)
        AlinearFiltrosIzquierda()
        btnImprimir.Enabled = True
        btnExportarExcel.Enabled = True
        btnExportarPdf.Enabled = True
        AsignarFoco(dtpFecha)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CalcularTotales(ByVal columnaConceptoTotal As Integer, ByVal valorColumnaConceptoTotal As String, ByVal cantidadColumnasSpan As Integer, ByVal columnaInicial As Integer, ByVal columnaFinal As Integer, ByVal filaInicial As Integer, ByVal filaFinal As Integer)

        If (filaFinal > 0) Then
            Dim numeroColumnas As Integer = spReporte.ActiveSheet.Columns.Count
            spReporte.ActiveSheet.AddUnboundRows(filaFinal, 1)
            spReporte.ActiveSheet.AddSpanCell(filaFinal, columnaConceptoTotal, 1, cantidadColumnasSpan)
            spReporte.ActiveSheet.Cells(filaFinal, columnaConceptoTotal).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spReporte.ActiveSheet.Cells(filaFinal, columnaConceptoTotal).CellType = tipoTexto
            spReporte.ActiveSheet.Cells(filaFinal, columnaConceptoTotal).Text = valorColumnaConceptoTotal.ToUpper
            spReporte.ActiveSheet.Cells(filaFinal, 0, filaFinal, numeroColumnas - 1).BackColor = Color.Gainsboro
            For columna = columnaInicial To columnaFinal - 1
                Dim contador As Double = 0
                For fila = filaInicial To filaFinal - 1
                    If Not String.IsNullOrEmpty(spReporte.ActiveSheet.Cells(fila, 0).Text) Then
                        Dim valor As String = spReporte.ActiveSheet.Cells(fila, columna).Text
                        If IsNumeric(valor) Then
                            contador += spReporte.ActiveSheet.Cells(fila, columna).Text
                        End If
                    End If
                Next
                spReporte.ActiveSheet.Cells(filaFinal, columna).Text = contador
                spReporte.ActiveSheet.Cells(filaFinal, columna).CellType = tipoDoble
            Next
        End If

    End Sub

    Private Sub FormatearSpread()

        spReporte.Reset()
        spReporte.Visible = False
        spReporte.ActiveSheet.SheetName = "Reporte"
        spReporte.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spReporte.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spReporte.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spReporte.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spReporte.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        Application.DoEvents()

    End Sub

    Private Sub FormatearSpreadReporte(ByVal cantidadColumnas As Integer)

        spReporte.Visible = True
        spReporte.ActiveSheet.SheetName = "Reporte de Recepción"
        spReporte.ActiveSheet.GrayAreaBackColor = Principal.colorAreaGris
        spReporte.ActiveSheet.ColumnHeader.RowCount = 2
        spReporte.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spReporte.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spReporte.ActiveSheet.ColumnHeader.Rows(0, spReporte.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        Dim numeracion As Integer = 0
        spReporte.ActiveSheet.Columns.Count = cantidadColumnas
        spReporte.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "fecha" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "hora" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idLote" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreLote" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idChofer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreChofer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idVariedad" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreVariedad" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "pesoCajas" : numeracion += 1
        spReporte.ActiveSheet.Columns("id").Width = 50
        spReporte.ActiveSheet.Columns("fecha").Width = 80
        spReporte.ActiveSheet.Columns("hora").Width = 70
        spReporte.ActiveSheet.Columns("idLote").Width = 50
        spReporte.ActiveSheet.Columns("nombreLote").Width = 170
        spReporte.ActiveSheet.Columns("idChofer").Width = 50
        spReporte.ActiveSheet.Columns("nombreChofer").Width = 170
        spReporte.ActiveSheet.Columns("idProducto").Width = 50
        spReporte.ActiveSheet.Columns("nombreProducto").Width = 170
        spReporte.ActiveSheet.Columns("idVariedad").Width = 50
        spReporte.ActiveSheet.Columns("nombreVariedad").Width = 170
        spReporte.ActiveSheet.Columns("cantidadCajas").Width = 120
        spReporte.ActiveSheet.Columns("pesoCajas").Width = 100
        Dim anchoFiltros As Integer = 25
        For columna = 0 To spReporte.ActiveSheet.Columns.Count - 1
            spReporte.ActiveSheet.Columns(columna).Width += anchoFiltros
        Next 
        spReporte.ActiveSheet.Columns("pesoCajas").CellType = tipoDoble
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("id").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("fecha").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("fecha").Index).Value = "Fecha".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("hora").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("hora").Index).Value = "Hora".ToUpper 
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idLote").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idLote").Index).Value = "Lote".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idLote").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreLote").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idChofer").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idChofer").Index).Value = "Chofer".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idChofer").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreChofer").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idProducto").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idProducto").Index).Value = "Producto".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idProducto").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idVariedad").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idVariedad").Index).Value = "Variedad".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idVariedad").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreVariedad").Index).Value = "Nombre".ToUpper 
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("cantidadCajas").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("cantidadCajas").Index).Value = "Cantidad Cajas".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("pesoCajas").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("pesoCajas").Index).Value = "Peso Cajas".ToUpper
        spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoFilter = True
        spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoSort = True
        spReporte.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Application.DoEvents()

    End Sub

    Private Sub CargarComboLotes()

        lotes.EId = 0
        cbLote.ValueMember = "Id"
        cbLote.DisplayMember = "Nombre"
        cbLote.DataSource = lotes.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboChoferes()

        choferesCampos.EId = 0
        cbChofer.ValueMember = "Id"
        cbChofer.DisplayMember = "Nombre"
        cbChofer.DataSource = choferesCampos.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboProductos()

        productos.EId = 0
        cbProducto.ValueMember = "Id"
        cbProducto.DisplayMember = "Nombre"
        cbProducto.DataSource = productos.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboVariedades()

        Dim idProducto As Integer = cbProducto.SelectedValue()
        'If (idProducto > 0) Then
        variedades.EIdProducto = idProducto
        variedades.EId = 0
        cbVariedad.ValueMember = "Id"
        cbVariedad.DisplayMember = "Nombre"
        cbVariedad.DataSource = variedades.ObtenerListadoReporte()
        'End If

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Enum OpcionNivel

        lote = 0
        familia = 1
        subFamilia = 2
        articulo = 3

    End Enum

#End Region

    Private Sub cbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProducto.SelectedIndexChanged

        If (cbProducto.SelectedValue > 0) Then
            cbVariedad.Enabled = True
            CargarComboVariedades()
        Else
            cbVariedad.Enabled = False
        End If

    End Sub

End Class