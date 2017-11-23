Imports System.IO
Imports FarPoint.Win.Spread
Imports System.Reflection
Imports System.Threading

Public Class Principal

    ' Variables de objetos de entidades.
    Public vaciado As New EYEEntidadesReporteVaciado.Vaciado()
    Public usuarios As New EYEEntidadesReporteVaciado.Usuarios()
    Public productores As New EYEEntidadesReporteVaciado.Productores()
    Public lotes As New EYEEntidadesReporteVaciado.Lotes()
    Public choferesCampos As New EYEEntidadesReporteVaciado.ChoferesCampos()
    Public productos As New EYEEntidadesReporteVaciado.Productos()
    Public variedades As New EYEEntidadesReporteVaciado.Variedades()
    Public empresas As New EYEEntidadesReporteVaciado.Empresas()
    ' Variables de tipos de datos de spread.
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoBooleano As New FarPoint.Win.Spread.CellType.CheckBoxCellType()
    ' Variables de tamaños y posiciones de spreads.
    Public anchoTotal As Integer = 0 : Public altoTotal As Integer = 0
    Public anchoMitad As Integer = 0 : Public altoMitad As Integer = 0
    Public anchoTercio As Integer = 0 : Public altoTercio As Integer = 0 : Public altoCuarto As Integer = 0
    Public izquierda As Integer = 0 : Public arriba As Integer = 0
    ' Variables de formatos de spread.
    Public Shared tipoLetraSpread As String = "Microsoft Sans Serif" : Public Shared tamañoLetraSpread As Integer = 9
    Public Shared alturaFilasEncabezadosGrandesSpread As Integer = 35 : Public Shared alturaFilasEncabezadosMedianosSpread As Integer = 28
    Public Shared alturaFilasEncabezadosChicosSpread As Integer = 22 : Public Shared alturaFilasSpread As Integer = 20 
    ' Variables de estilos.
    Public Shared colorSpreadAreaGris As Color = Color.FromArgb(245, 245, 245) : Public Shared colorSpreadTotal As Color = Color.White
    Public Shared colorCaptura As Color = Color.White : Public Shared colorCapturaBloqueada As Color = Color.FromArgb(235, 255, 255)
    Public Shared colorAdvertencia As Color = Color.Orange
    Public Shared colorTemaAzul As Color = Color.FromArgb(99, 160, 162)
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public opcionSeleccionadaTipoReporte As Integer = -1 : Public opcionSeleccionadaTipoMovimiento As Integer = -1
    Public estaMostrado As Boolean = False
    Public ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public rutaTemporal As String = Application.StartupPath & "\ArchivosTemporales"
    Public estaCerrando As Boolean = False
    Public prefijoBaseDatosEmpaque As String = "EYE" & "_"
    Public colorFiltros As Color
    Public esIzquierda As Boolean = False
    ' Hilos para carga rapida.
    Public hiloCentrar As New Thread(AddressOf Centrar)
    Public hiloNombrePrograma As New Thread(AddressOf CargarNombrePrograma)
    Public hiloEncabezadosTitulos As New Thread(AddressOf CargarEncabezadosTitulos)
    Public hiloTiposDatos As New Thread(AddressOf CargarTiposDeDatos)
    Public hiloColor As New Thread(AddressOf CargarValorColor)
    ' Variable de desarrollo.
    Public esDesarrollo As Boolean = False

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        MostrarCargando(True)
        ConfigurarConexiones()
        IniciarHilosCarga()
        AsignarTooltips()
        CargarMedidas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Me.Cursor = Cursors.WaitCursor 
        CargarComboProductores()
        CargarComboLotes()
        CargarComboChoferes()
        CargarComboProductos()
        CargarComboVariedades()
        Me.estaMostrado = True
        AsignarFoco(dtpFecha)
        CargarEstilos()
        MostrarCargando(False)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Cursor = Cursors.WaitCursor
        EliminarArchivosTemporales()
        Dim nombrePrograma As String = "PrincipalBerry"
        AbrirPrograma(nombrePrograma, True)
        System.Threading.Thread.Sleep(5000)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Me.Cursor = Cursors.WaitCursor
        Me.estaCerrando = True
        MostrarCargando(True)
        Desvanecer()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Application.Exit()

    End Sub 

    Private Sub btnSalir_MouseEnter(sender As Object, e As EventArgs) Handles btnSalir.MouseEnter

        AsignarTooltips("Salir.")

    End Sub

    Private Sub pnlCuerpo_MouseEnter(sender As Object, e As EventArgs) Handles pnlEncabezado.MouseEnter, pnlCuerpo.MouseEnter

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        Me.Cursor = Cursors.WaitCursor
        If (Me.opcionSeleccionadaTipoReporte = OpcionTipoReporte.vaciado Or Me.opcionSeleccionadaTipoReporte = OpcionTipoReporte.saldos) Then
            GenerarReporte()
        Else
            pnlMenu.BackColor = Principal.colorTemaAzul
            pnlMenu.Refresh()
            Thread.Sleep(250)
            pnlMenu.BackColor = pnlFiltros.BackColor
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnGenerar_MouseEnter(sender As Object, e As EventArgs) Handles btnGenerar.MouseEnter

        AsignarTooltips("Generar Reporte.")

    End Sub

    Private Sub pnlFiltros_MouseEnter(sender As Object, e As EventArgs) Handles pnlFiltros.MouseEnter, gbFechas.MouseEnter, gbOpciones.MouseEnter, chkFecha.MouseEnter, cbLotes.MouseEnter, cbChoferes.MouseEnter, cbProductos.MouseEnter, cbVariedades.MouseEnter, cbProductores.MouseEnter

        AsignarTooltips("Filtros para Generar el Reporte.")

    End Sub

    Private Sub spReporte_MouseEnter(sender As Object, e As EventArgs) Handles spReporte.MouseEnter

        AsignarTooltips("Reporte Generado.")

    End Sub

    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick

        If (Me.estaCerrando) Then
            Desvanecer()
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Me.Cursor = Cursors.WaitCursor
        Imprimir(False)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnExportarPdf_Click(sender As Object, e As EventArgs) Handles btnExportarPdf.Click

        Me.Cursor = Cursors.WaitCursor
        Imprimir(True)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        Me.Cursor = Cursors.WaitCursor
        ExportarExcel()
        Me.Cursor = Cursors.Default

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
            AsignarFoco(cbProductores)
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(dtpFecha)
        End If

    End Sub

    Private Sub cbProductores_KeyDown(sender As Object, e As KeyEventArgs) Handles cbProductores.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbProductores.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            Else
                AsignarFoco(cbLotes)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(dtpFechaFinal)
        End If

    End Sub

    Private Sub cbLotes_KeyDown(sender As Object, e As KeyEventArgs) Handles cbLotes.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbLotes.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            Else
                AsignarFoco(cbChoferes)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(cbProductores)
        End If

    End Sub

    Private Sub cbChoferes_KeyDown(sender As Object, e As KeyEventArgs) Handles cbChoferes.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbChoferes.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            Else
                AsignarFoco(cbProductos)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(cbLotes)
        End If

    End Sub

    Private Sub cbProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles cbProductos.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbProductos.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            Else
                AsignarFoco(cbVariedades)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(cbChoferes)
        End If

    End Sub

    Private Sub cbVariedades_KeyDown(sender As Object, e As KeyEventArgs) Handles cbVariedades.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbVariedades.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            Else
                AsignarFoco(btnGenerar)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(cbProductos)
        End If

    End Sub

    Private Sub cbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged

        If (cbProductos.SelectedValue > 0) Then
            cbVariedades.Enabled = True
            CargarComboVariedades()
        Else
            cbVariedades.Enabled = False
        End If

    End Sub

    Private Sub btnGenerar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnGenerar.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            If (cbVariedades.Enabled) Then
                AsignarFoco(cbVariedades)
            ElseIf (cbProductos.Enabled) Then
                AsignarFoco(cbProductos)
            ElseIf (cbChoferes.Enabled) Then
                AsignarFoco(cbChoferes)
            ElseIf (cbLotes.Enabled) Then
                AsignarFoco(cbLotes)
            End If
        End If

    End Sub

    Private Sub rbtnVaciado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnVaciado.CheckedChanged

        If (rbtnVaciado.Checked) Then
            Me.opcionSeleccionadaTipoReporte = OpcionTipoReporte.vaciado
            gbOpciones.Enabled = False
            gbMasOpciones.Enabled = False
        End If

    End Sub

    Private Sub rbtnSaldos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSaldos.CheckedChanged

        If (rbtnSaldos.Checked) Then
            Me.opcionSeleccionadaTipoReporte = OpcionTipoReporte.saldos
            gbOpciones.Enabled = True
            gbMasOpciones.Enabled = True
        End If

    End Sub

    Private Sub rbtnTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTodos.CheckedChanged

        If (rbtnTodos.Checked) Then
            Me.opcionSeleccionadaTipoMovimiento = OpcionTipoMovimientoVaciado.todo
        End If

    End Sub

    Private Sub rbtnConMovimientos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnConMovimientos.CheckedChanged

        If (rbtnConMovimientos.Checked) Then
            Me.opcionSeleccionadaTipoMovimiento = OpcionTipoMovimientoVaciado.conMovimiento
        End If

    End Sub

    Private Sub rbtnSinMovimientos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSinMovimientos.CheckedChanged

        If (rbtnSinMovimientos.Checked) Then
            Me.opcionSeleccionadaTipoMovimiento = OpcionTipoMovimientoVaciado.sinMovimiento
        End If

    End Sub

    Private Sub btnMostrarOcultar_Click(sender As Object, e As EventArgs) Handles btnMostrarOcultar.Click

        MostrarOcultar()

    End Sub

    Private Sub btnMostrarOcultar_MouseEnter(sender As Object, e As EventArgs) Handles btnMostrarOcultar.MouseEnter

        If (Me.esIzquierda) Then
            AsignarTooltips("Mostrar.")
        Else
            AsignarTooltips("Ocultar.")
        End If

    End Sub

    Private Sub pnlPie_MouseEnter(sender As Object, e As EventArgs) Handles pnlPie.MouseEnter

        AsignarTooltips("Opciones.")

    End Sub

    Private Sub pbMarca_MouseEnter(sender As Object, e As EventArgs) Handles pbMarca.MouseEnter

        AsignarTooltips("Producido por Berry.")

    End Sub

#End Region

#Region "Métodos"

#Region "Básicos"

    Private Sub CargarEstilos()

        pnlMenu.BackColor = Principal.colorSpreadAreaGris
        pnlFiltros.BackColor = Principal.colorSpreadAreaGris
        spReporte.ActiveSheet.GrayAreaBackColor = Principal.colorSpreadAreaGris
        pnlPie.BackColor = Principal.colorSpreadAreaGris

    End Sub

    Private Sub CargarMedidas()

        Me.izquierda = 0
        Me.arriba = spReporte.Top
        Me.anchoTotal = pnlCuerpo.Width
        Me.altoTotal = pnlCuerpo.Height
        Me.anchoMitad = Me.anchoTotal / 2
        Me.altoMitad = Me.altoTotal / 2
        Me.anchoTercio = Me.anchoTotal / 3
        Me.altoTercio = Me.altoTotal / 3
        Me.altoCuarto = Me.altoTotal / 4

    End Sub

    Private Sub MostrarOcultar()

        Dim anchoMenor As Integer = btnMostrarOcultar.Width
        Dim espacio As Integer = 1
        If (Not Me.esIzquierda) Then
            pnlFiltros.Left = -pnlFiltros.Width + anchoMenor
            spReporte.Left = anchoMenor + espacio
            spReporte.Width = Me.anchoTotal - anchoMenor - espacio
            Me.esIzquierda = True
        Else
            pnlFiltros.Left = 0
            spReporte.Left = pnlFiltros.Width + espacio
            spReporte.Width = Me.anchoTotal - pnlFiltros.Width - espacio
            Me.esIzquierda = False
        End If

    End Sub

    Private Sub MostrarCargando(ByVal mostrar As Boolean)

        Dim pnlCargando As New Panel
        Dim lblCargando As New Label
        Dim crear As Boolean = False
        If (Me.Controls.Find("pnlCargando", True).Count = 0) Then ' Si no existe, se crea. 
            crear = True
        Else ' Si existe, se obtiene.
            pnlCargando = Me.Controls.Find("pnlCargando", False)(0)
            crear = False
        End If
        If (crear And mostrar) Then ' Si se tiene que crear y mostrar.
            ' Imagen de fondo.
            Try
                pnlCargando.BackgroundImage = Image.FromFile(String.Format("{0}\{1}\{2}", IIf(Me.esDesarrollo, "W:", Application.StartupPath), "Imagenes", "cargando.png"))
            Catch
                pnlCargando.BackgroundImage = Image.FromFile(String.Format("{0}\{1}\{2}", IIf(Me.esDesarrollo, "W:", Application.StartupPath), "Imagenes", "logoBerry.png"))
            End Try
            pnlCargando.BackgroundImageLayout = ImageLayout.Center
            pnlCargando.BackColor = Color.DarkSlateGray
            pnlCargando.Width = Me.Width
            pnlCargando.Height = Me.Height
            pnlCargando.Location = New Point(Me.Location)
            pnlCargando.Name = "pnlCargando"
            pnlCargando.Visible = True
            Me.Controls.Add(pnlCargando)
            ' Etiqueta de cargando.
            lblCargando.Text = "¡cargando!"
            lblCargando.BackColor = pnlCargando.BackColor
            lblCargando.ForeColor = Color.White
            lblCargando.AutoSize = False
            lblCargando.Width = Me.Width
            lblCargando.Height = 75
            lblCargando.TextAlign = ContentAlignment.TopCenter
            lblCargando.Font = New Font(Principal.tipoLetraSpread, 40, FontStyle.Regular)
            lblCargando.Location = New Point(lblCargando.Location.X, (Me.Height / 2) + 140)
            pnlCargando.Controls.Add(lblCargando)
            pnlCargando.BringToFront()
            pnlCargando.Focus()
        ElseIf (Not crear) Then ' Si ya existe, se checa si se muestra o no.
            If (mostrar) Then ' Se muestra.
                pnlCargando.Visible = True
                pnlCargando.BringToFront()
            Else ' No se muestra.
                pnlCargando.Visible = False
                pnlCargando.SendToBack()
            End If
        End If
        Application.DoEvents()

    End Sub

    Public Sub IniciarHilosCarga()

        CheckForIllegalCrossThreadCalls = False
        hiloNombrePrograma.Start()
        hiloCentrar.Start()
        hiloEncabezadosTitulos.Start()
        hiloTiposDatos.Start()
        hiloColor.Start()

    End Sub

    Private Sub AsignarFoco(ByVal c As Control)

        c.Focus()

    End Sub

    Private Sub MostrarAyuda()

        Dim pnlAyuda As New Panel()
        Dim txtAyuda As New TextBox()
        If (pnlContenido.Controls.Find("pnlAyuda", True).Count = 0) Then
            pnlAyuda.Name = "pnlAyuda"
            pnlAyuda.Visible = False
            pnlContenido.Controls.Add(pnlAyuda)
            txtAyuda.Name = "txtAyuda"
            pnlAyuda.Controls.Add(txtAyuda)
        Else
            pnlAyuda = pnlContenido.Controls.Find("pnlAyuda", False)(0)
            txtAyuda = pnlAyuda.Controls.Find("txtAyuda", False)(0)
        End If
        If (Not pnlAyuda.Visible) Then
            pnlCuerpo.Visible = False
            pnlAyuda.Visible = True
            pnlAyuda.Size = pnlCuerpo.Size
            pnlAyuda.Location = pnlCuerpo.Location
            pnlContenido.Controls.Add(pnlAyuda)
            txtAyuda.ScrollBars = ScrollBars.Both
            txtAyuda.Multiline = True
            txtAyuda.Width = pnlAyuda.Width - 10
            txtAyuda.Height = pnlAyuda.Height - 10
            txtAyuda.Location = New Point(5, 5)
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Reporte: " & vbNewLine & "En esta pantalla se desplegará el reporte de acuerdo a los filtros que se hayan seleccionado. " & vbNewLine & "En la parte izquierda se puede agregar cualquiera de los filtros. Existen unos botones que se encuentran en las fechas que contienen la palabra si o no, si la palabra mostrada es si, el rango de fecha correspondiente se incluirá como filtro para el reporte, esto aplica para todas las opciones de fechas. Posteriormente se procede a generar el reporte con los criterios seleccionados. Cuando se termine de generar dicho reporte, se habilitarán las opciones de imprimir, exportar a excel o exportar a pdf, en estas dos últimas el usuario puede guardarlos directamente desde el archivo que se muestra en pantalla si así lo desea, mas no desde el sistema directamente."
            pnlAyuda.Controls.Add(txtAyuda)
        Else
            pnlCuerpo.Visible = True
            pnlAyuda.Visible = False
        End If
        Application.DoEvents()

    End Sub

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Opacity = 0.98
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        hiloCentrar.Abort()

    End Sub

    Private Sub CargarNombrePrograma()

        Me.nombreEstePrograma = Me.Text
        hiloNombrePrograma.Abort()

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
        tp.SetToolTip(Me.spReporte, "Reporte Generado.")
        tp.SetToolTip(Me.btnMostrarOcultar, "Mostrar u Ocultar.")
        tp.SetToolTip(Me.pbMarca, "Producido por Berry.")

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
        hiloTiposDatos.Abort()

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            EYELogicaReporteVaciado.Directorios.id = 1
            EYELogicaReporteVaciado.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaReporteVaciado.Directorios.usuarioSql = "AdminBerry"
            EYELogicaReporteVaciado.Directorios.contrasenaSql = "@berry2017"
            pnlEncabezado.BackColor = Color.DarkRed
        Else
            EYELogicaReporteVaciado.Directorios.ObtenerParametros()
            EYELogicaReporteVaciado.Usuarios.ObtenerParametros()
        End If
        EYELogicaReporteVaciado.Programas.bdCatalogo = "Catalogo" & EYELogicaReporteVaciado.Directorios.id
        EYELogicaReporteVaciado.Programas.bdConfiguracion = "Configuracion" & EYELogicaReporteVaciado.Directorios.id
        EYELogicaReporteVaciado.Programas.bdEmpaque = "Empaque" & EYELogicaReporteVaciado.Directorios.id
        EYEEntidadesReporteVaciado.BaseDatos.ECadenaConexionCatalogo = EYELogicaReporteVaciado.Programas.bdCatalogo
        EYEEntidadesReporteVaciado.BaseDatos.ECadenaConexionConfiguracion = EYELogicaReporteVaciado.Programas.bdConfiguracion
        EYEEntidadesReporteVaciado.BaseDatos.ECadenaConexionEmpaque = EYELogicaReporteVaciado.Programas.bdEmpaque
        EYEEntidadesReporteVaciado.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesReporteVaciado.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesReporteVaciado.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesReporteVaciado.Usuarios)
        usuarios.EId = EYELogicaReporteVaciado.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count > 0) Then
            EYELogicaReporteVaciado.Usuarios.id = lista(0).EId
            EYELogicaReporteVaciado.Usuarios.nombre = lista(0).ENombre
            EYELogicaReporteVaciado.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaReporteVaciado.Usuarios.nivel = lista(0).ENivel
            EYELogicaReporteVaciado.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaReporteVaciado.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub CargarEncabezadosTitulos()

        lblEncabezadoPrograma.Text = "Programa: " & Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " & EYELogicaReporteVaciado.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " & EYELogicaReporteVaciado.Usuarios.nombre
        Me.Text = "Programa:  " & Me.nombreEstePrograma & "              Directorio:  " & EYELogicaReporteVaciado.Directorios.nombre & "              Usuario:  " & EYELogicaReporteVaciado.Usuarios.nombre
        hiloEncabezadosTitulos.Abort()

    End Sub

    Private Sub CargarValorColor()

        Me.colorFiltros = pnlFiltros.BackColor
        hiloColor.Abort()

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = EYELogicaReporteVaciado.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteVaciado.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteVaciado.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteVaciado.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteVaciado.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteVaciado.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteVaciado.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteVaciado.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaReporteVaciado.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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

        ' Se carga la información de la empresa.
        Dim datos As New DataTable
        empresas.EId = 0 ' Se busca la primer empresa.
        datos = empresas.ObtenerListado(True)
        If (datos.Rows.Count = 0) Then
            MsgBox("No existen datos de la empresa para encabezados de impresión. Se cancelará la impresión.", MsgBoxStyle.Information, "Faltan datos.")
            Exit Sub
        End If
        Dim nombrePdf As String = "\Temporal.pdf"
        Dim fuente7 As Integer = 7
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
        informacionImpresion.ZoomFactor = IIf(Me.opcionSeleccionadaTipoReporte = OpcionTipoReporte.saldos, 0.6, 1)
        informacionImpresion.Printer = impresor.PrinterSettings.PrinterName
        informacionImpresion.Centering = FarPoint.Win.Spread.Centering.Horizontal
        informacionImpresion.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        informacionImpresion.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Dim encabezado1 As String = String.Empty
        Dim encabezado2 As String = String.Empty
        Dim encabezado3 As String = String.Empty
        encabezado1 = String.Format("/l/fz""{0}""{1}/c/fz""{0}""{2}/r/fz""{0}""Página /p de /pc", fuente7, datos.Rows(0).Item("Rfc"), datos.Rows(0).Item("Nombre"))
        encabezado1 = encabezado1.ToUpper
        encabezado2 = String.Format("/l/fz""{0}""{1}/c/fb1/fz""{0}""{2}/r/fz""{0}""{3}", fuente7, datos.Rows(0).Item("Domicilio"), datos.Rows(0).Item("Descripcion"), Today.ToShortDateString)
        encabezado2 = encabezado2.ToUpper
        encabezado3 = String.Format("/l/fz""{0}""{1}/c/fb1/fz""{0}""{2}/r/fz""{0}""{3}", fuente7, datos.Rows(0).Item("Municipio") & ", " & datos.Rows(0).Item("Estado") & ", " & datos.Rows(0).Item("Pais"), spReporte.ActiveSheet.SheetName & " (" & IIf(chkFecha.Checked, "Del " & dtpFecha.Value.ToShortDateString & " al " & dtpFechaFinal.Value.ToShortDateString, "Hasta el " & Today) & ")", Now.ToShortTimeString)
        encabezado3 = encabezado3.ToUpper
        If (esPdf) Then
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
        informacionImpresion.Footer = "Producido por: Berry".ToUpper
        For indice = 0 To spReporte.Sheets.Count - 1
            spReporte.Sheets(indice).PrintInfo = informacionImpresion
        Next
        If (Not esPdf) Then
            If (impresor.ShowDialog = Windows.Forms.DialogResult.OK) Then
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

    End Sub

    Private Sub ExportarExcel()

        spParaClonar.Sheets.Clear()
        spParaClonar = ClonarSpread(spParaClonar)
        Dim bandera As Boolean = True
        Dim nombreExcel As String = "\Temporal.xls"
        Dim obtenerRandom As System.Random = New System.Random()
        FormatearSpreadExcel()
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

    Private Sub FormatearSpreadExcel()

        ' Se carga la información de la empresa.
        Dim datos As New DataTable
        empresas.EId = 0 ' Se busca la primer empresa.
        datos = empresas.ObtenerListado(True)
        If (datos.Rows.Count = 0) Then
            MsgBox("No existen datos de la empresa para encabezados de excel. Se cancelará la exportación.", MsgBoxStyle.Information, "Faltan datos.")
            Exit Sub
        End If 
        Dim fuente7 As Integer = 7 
        Dim encabezado1I As String = String.Empty
        Dim encabezado1C As String = String.Empty
        Dim encabezado2I As String = String.Empty
        Dim encabezado2C As String = String.Empty
        Dim encabezado2D As String = String.Empty
        Dim encabezado3I As String = String.Empty
        Dim encabezado3C As String = String.Empty
        Dim encabezado3D As String = String.Empty
        encabezado1I = datos.Rows(0).Item("Rfc") : encabezado1I = encabezado1I.ToUpper
        encabezado1C = datos.Rows(0).Item("Nombre") : encabezado1C = encabezado1C.ToUpper
        encabezado2I = datos.Rows(0).Item("Domicilio") : encabezado2I = encabezado2I.ToUpper
        encabezado2C = datos.Rows(0).Item("Descripcion") : encabezado2C = encabezado2C.ToUpper
        encabezado2D = Today.ToShortDateString : encabezado2D = encabezado2D.ToUpper
        encabezado3I = datos.Rows(0).Item("Municipio") & ", " & datos.Rows(0).Item("Estado") & ", " & datos.Rows(0).Item("Pais") : encabezado3I = encabezado3I.ToUpper
        encabezado3C = spReporte.ActiveSheet.SheetName & " (" & IIf(chkFecha.Checked, "Del " & dtpFecha.Value.ToShortDateString & " al " & dtpFechaFinal.Value.ToShortDateString, "Hasta el " & Today) & ")" : encabezado3C = encabezado3C.ToUpper
        encabezado3D = Now.ToShortTimeString : encabezado3D = encabezado3D.ToUpper
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
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 3).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 3).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
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

    Private Sub GenerarReporte()

        FormatearSpread()
        Dim datos As New DataTable
        vaciado.EIdProductor = cbProductores.SelectedValue
        vaciado.EIdLote = cbLotes.SelectedValue
        vaciado.EIdChofer = cbChoferes.SelectedValue
        vaciado.EIdProducto = cbProductos.SelectedValue
        vaciado.EIdVariedad = cbVariedades.SelectedValue
        Dim fecha As Date = dtpFecha.Value.ToShortDateString : Dim fecha2 As Date = dtpFechaFinal.Value.ToShortDateString
        Dim aplicaFecha As Boolean = False
        If (chkFecha.Checked) Then
            aplicaFecha = True
            vaciado.EFecha = fecha : vaciado.EFecha2 = fecha2
        Else
            aplicaFecha = False
        End If
        If (Me.opcionSeleccionadaTipoReporte = OpcionTipoReporte.vaciado) Then
            datos = vaciado.ObtenerListadoReporteVaciado(aplicaFecha)
        ElseIf (Me.opcionSeleccionadaTipoReporte = OpcionTipoReporte.saldos) Then
            datos = vaciado.ObtenerListadoReporteSaldos(aplicaFecha, Me.opcionSeleccionadaTipoMovimiento)
        End If
        spReporte.ActiveSheet.DataSource = datos
        If (Me.opcionSeleccionadaTipoReporte = OpcionTipoReporte.vaciado) Then
            For columna = 0 To datos.Columns.Count - 1
                datos.Columns(columna).ColumnName = datos.Columns(columna).ToString.Replace("_", " ").ToUpper
            Next
            FormatearSpreadReporteVaciado(spReporte.ActiveSheet.Columns.Count)
            CalcularTotalesHorizontales(0, "Total", spReporte.ActiveSheet.Columns("hora").Index, spReporte.ActiveSheet.Columns("hora").Index + 1, spReporte.ActiveSheet.Columns.Count, 0, spReporte.ActiveSheet.Rows.Count)
            CalcularTotalesVerticales(spReporte.ActiveSheet.Columns.Count, "Total", spReporte.ActiveSheet.Columns("hora").Index + 1, spReporte.ActiveSheet.Columns.Count, 0, spReporte.ActiveSheet.Rows.Count - 1)
        ElseIf (Me.opcionSeleccionadaTipoReporte = OpcionTipoReporte.saldos) Then
            FormatearSpreadReporteSaldos(spReporte.ActiveSheet.Columns.Count)
            CalcularTotalesHorizontales(0, "Total", spReporte.ActiveSheet.Columns("cantidadCajasRecepcion").Index, spReporte.ActiveSheet.Columns("cantidadCajasRecepcion").Index, spReporte.ActiveSheet.Columns.Count, 0, spReporte.ActiveSheet.Rows.Count)
        End If
        btnImprimir.Enabled = True
        btnExportarExcel.Enabled = True
        btnExportarPdf.Enabled = True
        AsignarFoco(dtpFecha)
        MostrarOcultar()

    End Sub

    Private Sub CalcularTotalesHorizontales(ByVal columnaConceptoTotal As Integer, ByVal valorColumnaConceptoTotal As String, ByVal cantidadColumnasSpan As Integer, ByVal columnaInicial As Integer, ByVal columnaFinal As Integer, ByVal filaInicial As Integer, ByVal filaFinal As Integer)

        If (filaFinal > 0) Then
            Dim numeroColumnas As Integer = spReporte.ActiveSheet.Columns.Count
            spReporte.ActiveSheet.AddUnboundRows(filaFinal, 1)
            If (cantidadColumnasSpan > 1) Then
                spReporte.ActiveSheet.AddSpanCell(filaFinal, columnaConceptoTotal, 1, cantidadColumnasSpan)
            End If
            spReporte.ActiveSheet.Cells(filaFinal, columnaConceptoTotal).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spReporte.ActiveSheet.Cells(filaFinal, columnaConceptoTotal).CellType = tipoTexto
            spReporte.ActiveSheet.Cells(filaFinal, columnaConceptoTotal).Text = valorColumnaConceptoTotal.ToUpper
            spReporte.ActiveSheet.Cells(filaFinal, 0, filaFinal, numeroColumnas - 1).BackColor = Color.FromArgb(230, 230, 230)
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

    Private Sub CalcularTotalesVerticales(ByVal columnaConceptoTotal As Integer, ByVal valorColumnaConceptoTotal As String, ByVal columnaInicial As Integer, ByVal columnaFinal As Integer, ByVal filaInicial As Integer, ByVal filaFinal As Integer)

        If (filaFinal > 0) Then
            Dim numeroColumnas As Integer = spReporte.ActiveSheet.Columns.Count
            spReporte.ActiveSheet.AddColumns(columnaFinal, 1)
            spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, columnaConceptoTotal, 2, 1)
            spReporte.ActiveSheet.ColumnHeader.Cells(0, columnaConceptoTotal).CellType = tipoTexto
            spReporte.ActiveSheet.Columns(columnaConceptoTotal).Width = 100
            spReporte.ActiveSheet.ColumnHeader.Cells(0, columnaConceptoTotal).Text = valorColumnaConceptoTotal.ToUpper
            spReporte.ActiveSheet.Cells(0, columnaConceptoTotal, filaFinal, columnaConceptoTotal).BackColor = Color.FromArgb(230, 230, 230)
            For fila = filaInicial To filaFinal
                Dim contador As Double = 0
                For columna = columnaInicial To columnaFinal - 1
                    If Not String.IsNullOrEmpty(spReporte.ActiveSheet.Cells(fila, 0).Text) Then
                        Dim valor As String = spReporte.ActiveSheet.Cells(fila, columna).Text
                        If IsNumeric(valor) Then
                            contador += spReporte.ActiveSheet.Cells(fila, columna).Text
                        End If
                    End If
                Next
                spReporte.ActiveSheet.Cells(fila, columnaFinal).Text = contador
                spReporte.ActiveSheet.Cells(fila, columnaFinal).CellType = tipoDoble
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
        spReporte.Refresh()

    End Sub

    Private Sub FormatearSpreadReporteVaciado(ByVal cantidadColumnas As Integer)

        spReporte.Visible = True
        spReporte.ActiveSheet.Columns.Count = cantidadColumnas
        spReporte.ActiveSheet.SheetName = "Reporte de Vaciado"
        spReporte.ActiveSheet.GrayAreaBackColor = Principal.colorSpreadAreaGris
        spReporte.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Dim numeracion As Integer = 0
        spReporte.ActiveSheet.Columns(numeracion).Tag = "hora" : numeracion += 1
        spReporte.ActiveSheet.ColumnHeader.RowCount = 2
        spReporte.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spReporte.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spReporte.ActiveSheet.ColumnHeader.Rows(0, spReporte.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("hora").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("hora").Index).Value = "Hora".ToUpper
        If (cantidadColumnas > 1) Then
            spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("hora").Index + 1, 1, spReporte.ActiveSheet.Columns.Count - 1)
            spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("hora").Index + 1).Value = "B a n d a s".ToUpper
        End If
        spReporte.ActiveSheet.Columns("hora").Width = 70
        If (cantidadColumnas > 1) Then
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("hora").Index + 1, spReporte.ActiveSheet.Columns.Count - 1).Width = 100
        End If
        Dim anchoFiltros As Integer = 0 ' 15
        For columna = 0 To spReporte.ActiveSheet.Columns.Count - 1
            spReporte.ActiveSheet.Columns(columna).Width += anchoFiltros
        Next
        If (cantidadColumnas > 1) Then
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("hora").Index + 1, spReporte.ActiveSheet.Columns.Count - 1).CellType = tipoEntero
        End If
        'spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoFilter = True
        'spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoSort = True
        spReporte.Refresh()

    End Sub

    Private Sub FormatearSpreadReporteSaldos(ByVal cantidadColumnas As Integer)

        spReporte.Visible = True
        spReporte.ActiveSheet.SheetName = "Reporte de Vaciado con Saldos"
        spReporte.ActiveSheet.GrayAreaBackColor = Principal.colorSpreadAreaGris
        spReporte.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Dim numeracion As Integer = 0
        spReporte.ActiveSheet.Columns.Count = cantidadColumnas
        spReporte.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "fecha" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "hora" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idProductor" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreProductor" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idLote" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreLote" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idChofer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreChofer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idVariedad" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreVariedad" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "fechaVaciado" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasRecepcion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasVaciado" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasSaldo" : numeracion += 1
        spReporte.ActiveSheet.ColumnHeader.RowCount = 2
        spReporte.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spReporte.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spReporte.ActiveSheet.ColumnHeader.Rows(0, spReporte.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("id").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("id").Index).Value = "No. Recepción".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("fecha").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("fecha").Index).Value = "Fecha Recepción".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("hora").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("hora").Index).Value = "Hora Recepción".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idProductor").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idProductor").Index).Value = "P r o d u c t o r   R e c e p c i ó n".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idProductor").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreProductor").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idLote").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idLote").Index).Value = "L o t e   R e c e p c i ó n".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idLote").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreLote").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idChofer").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idChofer").Index).Value = "C h o f e r   R e c e p c i ó n".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idChofer").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreChofer").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idProducto").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idProducto").Index).Value = "P r o d u c t o   R e c e p c i ó n".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idProducto").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idVariedad").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idVariedad").Index).Value = "V a r i e d a d   R e c e p c i ó n".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idVariedad").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreVariedad").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("fechaVaciado").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("fechaVaciado").Index).Value = "Fecha Último Vaciado".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("cantidadCajasRecepcion").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("cantidadCajasRecepcion").Index).Value = "Cantidad Cajas Recepcion".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("cantidadCajasVaciado").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("cantidadCajasVaciado").Index).Value = "Cantidad Cajas Vaciado".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("cantidadCajasSaldo").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("cantidadCajasSaldo").Index).Value = "Saldo Cajas".ToUpper
        spReporte.ActiveSheet.Columns("id").Width = 100
        spReporte.ActiveSheet.Columns("fecha").Width = 100
        spReporte.ActiveSheet.Columns("hora").Width = 100
        spReporte.ActiveSheet.Columns("idProductor").Width = 50
        spReporte.ActiveSheet.Columns("nombreProductor").Width = 190
        spReporte.ActiveSheet.Columns("idLote").Width = 50
        spReporte.ActiveSheet.Columns("nombreLote").Width = 155
        spReporte.ActiveSheet.Columns("idChofer").Width = 50
        spReporte.ActiveSheet.Columns("nombreChofer").Width = 155
        spReporte.ActiveSheet.Columns("idProducto").Width = 50
        spReporte.ActiveSheet.Columns("nombreProducto").Width = 180
        spReporte.ActiveSheet.Columns("idVariedad").Width = 50
        spReporte.ActiveSheet.Columns("nombreVariedad").Width = 170
        spReporte.ActiveSheet.Columns("fechaVaciado").Width = 80
        spReporte.ActiveSheet.Columns("cantidadCajasRecepcion").Width = 90
        spReporte.ActiveSheet.Columns("cantidadCajasVaciado").Width = 90
        spReporte.ActiveSheet.Columns("cantidadCajasSaldo").Width = 80
        Dim anchoFiltros As Integer = 0 '15
        For columna = 0 To spReporte.ActiveSheet.Columns.Count - 1
            spReporte.ActiveSheet.Columns(columna).Width += anchoFiltros
        Next
        spReporte.ActiveSheet.Columns("cantidadCajasRecepcion").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasVaciado").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasSaldo").CellType = tipoEntero
        'spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoFilter = True
        'spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoSort = True
        spReporte.Refresh()

    End Sub

    Private Sub CargarComboProductores()

        productores.EId = 0
        cbProductores.ValueMember = "Id"
        cbProductores.DisplayMember = "Nombre"
        cbProductores.DataSource = productores.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboLotes()

        lotes.EId = 0
        cbLotes.ValueMember = "Id"
        cbLotes.DisplayMember = "Nombre"
        cbLotes.DataSource = lotes.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboChoferes()

        choferesCampos.EId = 0
        cbChoferes.ValueMember = "Id"
        cbChoferes.DisplayMember = "Nombre"
        cbChoferes.DataSource = choferesCampos.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboProductos()

        productos.EId = 0
        cbProductos.ValueMember = "Id"
        cbProductos.DisplayMember = "Nombre"
        cbProductos.DataSource = productos.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboVariedades()

        Dim idProducto As Integer = cbProductos.SelectedValue()
        'If (idProducto > 0) Then
        variedades.EIdProducto = idProducto
        variedades.EId = 0
        cbVariedades.ValueMember = "Id"
        cbVariedades.DisplayMember = "Nombre"
        cbVariedades.DataSource = variedades.ObtenerListadoReporte()
        'End If

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Enum OpcionTipoReporte

        vaciado = 1
        saldos = 2

    End Enum

    Enum OpcionTipoMovimientoVaciado

        todo = 1
        conMovimiento = 2
        sinMovimiento = 3

    End Enum

#End Region

End Class