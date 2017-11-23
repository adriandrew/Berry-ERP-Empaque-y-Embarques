Imports System.IO
Imports FarPoint.Win.Spread
Imports System.Reflection
Imports System.Threading

Public Class Principal

    ' Variables de objetos de entidades.
    Public tarimas As New EYEEntidadesReporteEmpaque.Empaque()
    Public usuarios As New EYEEntidadesReporteEmpaque.Usuarios()
    Public productores As New EYEEntidadesReporteEmpaque.Productores()
    Public productos As New EYEEntidadesReporteEmpaque.Productos()
    Public variedades As New EYEEntidadesReporteEmpaque.Variedades()
    Public envases As New EYEEntidadesReporteEmpaque.Envases()
    Public tamanos As New EYEEntidadesReporteEmpaque.Tamanos()
    Public etiquetas As New EYEEntidadesReporteEmpaque.Etiquetas()
    Public empresas As New EYEEntidadesReporteEmpaque.Empresas()
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
    Public Shared tipoLetraSpread As String = "Microsoft Sans Serif" : Public Shared tamañoLetraSpread As Integer = 8
    Public Shared alturaFilasEncabezadosGrandesSpread As Integer = 35 : Public Shared alturaFilasEncabezadosMedianosSpread As Integer = 28
    Public Shared alturaFilasEncabezadosChicosSpread As Integer = 22 : Public Shared alturaFilasSpread As Integer = 20
    ' Variables de estilos.
    Public Shared colorSpreadAreaGris As Color = Color.FromArgb(245, 245, 245) : Public Shared colorSpreadTotal As Color = Color.White
    Public Shared colorCaptura As Color = Color.White : Public Shared colorCapturaBloqueada As Color = Color.FromArgb(235, 255, 255)
    Public Shared colorAdvertencia As Color = Color.Orange
    Public Shared colorTemaAzul As Color = Color.FromArgb(99, 160, 162)
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public opcionSeleccionada As Integer = 0
    Public opcionTamanoSeleccionada As Integer = 0
    Public opcionTipoSeleccionada As Integer = 0
    Public estaMostrado As Boolean = False
    Public ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public rutaTemporal As String = Application.StartupPath & "\ArchivosTemporales"
    Public estaCerrando As Boolean = False
    Public prefijoBaseDatosEmpaque As String = "EYE" & "_"
    Public colorFiltros As Color
    Public esIzquierda As Boolean = False
    ' Hilos para carga rápida.
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
        CargarComboProductos()
        CargarComboVariedades()
        CargarComboEnvases()
        CargarComboTamanos()
        CargarComboEtiquetas()
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
        GenerarReporte()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnGenerar_MouseEnter(sender As Object, e As EventArgs) Handles btnGenerar.MouseEnter

        AsignarTooltips("Generar Reporte.")

    End Sub

    Private Sub pnlFiltros_MouseEnter(sender As Object, e As EventArgs) Handles pnlFiltros.MouseEnter, gbFechas.MouseEnter, gbOpciones.MouseEnter, chkFecha.MouseEnter, cbProductores.MouseEnter

        AsignarTooltips("Filtros para Generar el Reporte.")

    End Sub

    Private Sub spReporte_MouseHover(sender As Object, e As EventArgs) Handles spReporte.MouseHover

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

    Private Sub cbProductor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbProductores.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbProductores.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(dtpFechaFinal)
        End If

    End Sub

    Private Sub btnGenerar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnGenerar.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            If (cbProductores.Enabled) Then
                AsignarFoco(cbProductores)
            End If
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

    Private Sub cbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged

        If (cbProductos.SelectedValue > 0) Then
            cbVariedades.Enabled = True
            cbTamanos.Enabled = True
            CargarComboVariedades()
            CargarComboTamanos()
        Else
            cbVariedades.Enabled = False
            cbTamanos.Enabled = False
        End If

    End Sub

    Private Sub rbtnSimple_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSimple.CheckedChanged

        If (rbtnSimple.Checked) Then
            Me.opcionTamanoSeleccionada = OpcionTamano.simple
        End If

    End Sub

    Private Sub rbtnDetallado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnDetallado.CheckedChanged

        If (rbtnDetallado.Checked) Then
            Me.opcionTamanoSeleccionada = OpcionTamano.detallado
        End If

    End Sub

    Private Sub rbtnCajas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCajas.CheckedChanged

        If (rbtnCajas.Checked) Then
            Me.opcionTipoSeleccionada = OpcionTipo.cajas
        End If

    End Sub

    Private Sub rbtnTarimas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTarimas.CheckedChanged

        If (rbtnTarimas.Checked) Then
            Me.opcionTipoSeleccionada = OpcionTipo.tarimas
        End If

    End Sub

    Private Sub pbMarca_MouseEnter(sender As Object, e As EventArgs) Handles pbMarca.MouseEnter

        AsignarTooltips("Producido por Berry.")

    End Sub

    Private Sub pnlPie_MouseEnter(sender As Object, e As EventArgs) Handles pnlPie.MouseEnter

        AsignarTooltips("Opciones.")

    End Sub

#End Region

#Region "Métodos"

#Region "Básicos"

    Private Sub CargarEstilos()

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
            EYELogicaReporteEmpaque.Directorios.id = 1
            EYELogicaReporteEmpaque.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaReporteEmpaque.Directorios.usuarioSql = "AdminBerry"
            EYELogicaReporteEmpaque.Directorios.contrasenaSql = "@berry2017"
            pnlEncabezado.BackColor = Color.DarkRed
        Else
            EYELogicaReporteEmpaque.Directorios.ObtenerParametros()
            EYELogicaReporteEmpaque.Usuarios.ObtenerParametros()
        End If
        EYELogicaReporteEmpaque.Programas.bdCatalogo = "Catalogo" & EYELogicaReporteEmpaque.Directorios.id
        EYELogicaReporteEmpaque.Programas.bdConfiguracion = "Configuracion" & EYELogicaReporteEmpaque.Directorios.id
        EYELogicaReporteEmpaque.Programas.bdEmpaque = "Empaque" & EYELogicaReporteEmpaque.Directorios.id
        EYEEntidadesReporteEmpaque.BaseDatos.ECadenaConexionCatalogo = EYELogicaReporteEmpaque.Programas.bdCatalogo
        EYEEntidadesReporteEmpaque.BaseDatos.ECadenaConexionConfiguracion = EYELogicaReporteEmpaque.Programas.bdConfiguracion
        EYEEntidadesReporteEmpaque.BaseDatos.ECadenaConexionEmpaque = EYELogicaReporteEmpaque.Programas.bdEmpaque
        EYEEntidadesReporteEmpaque.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesReporteEmpaque.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesReporteEmpaque.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesReporteEmpaque.Usuarios)
        usuarios.EId = EYELogicaReporteEmpaque.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count > 0) Then
            EYELogicaReporteEmpaque.Usuarios.id = lista(0).EId
            EYELogicaReporteEmpaque.Usuarios.nombre = lista(0).ENombre
            EYELogicaReporteEmpaque.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaReporteEmpaque.Usuarios.nivel = lista(0).ENivel
            EYELogicaReporteEmpaque.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub CargarEncabezadosTitulos()

        lblEncabezadoPrograma.Text = "Programa: " & Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " & EYELogicaReporteEmpaque.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " & EYELogicaReporteEmpaque.Usuarios.nombre
        Me.Text = "Programa:  " & Me.nombreEstePrograma & "              Directorio:  " & EYELogicaReporteEmpaque.Directorios.nombre & "              Usuario:  " & EYELogicaReporteEmpaque.Usuarios.nombre
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
        ejecutarProgramaPrincipal.Arguments = EYELogicaReporteEmpaque.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmpaque.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmpaque.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmpaque.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmpaque.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmpaque.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmpaque.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmpaque.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaReporteEmpaque.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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
        informacionImpresion.ZoomFactor = IIf(Me.opcionTamanoSeleccionada = OpcionTamano.detallado, 0.45, 0.8)
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
            If (Directory.Exists(rutaTemporal)) Then
                Directory.Delete(rutaTemporal, True)
                Directory.CreateDirectory(rutaTemporal)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GenerarReporte()

        FormatearSpread()
        Dim datos As New DataTable
        tarimas.EIdProductor = cbProductores.SelectedValue
        tarimas.EIdProducto = cbProductos.SelectedValue
        tarimas.EIdVariedad = cbVariedades.SelectedValue
        tarimas.EIdEnvase = cbEnvases.SelectedValue
        tarimas.EIdTamano = cbTamanos.SelectedValue
        tarimas.EIdEtiqueta = cbEtiquetas.SelectedValue
        Dim fecha As Date = dtpFecha.Value.ToShortDateString : Dim fecha2 As Date = dtpFechaFinal.Value.ToShortDateString
        Dim aplicaFecha As Boolean = False
        If (chkFecha.Checked) Then
            aplicaFecha = True
            tarimas.EFecha = fecha : tarimas.EFecha2 = fecha2
        Else
            aplicaFecha = False
        End If
        If (Me.opcionTipoSeleccionada = OpcionTipo.cajas) Then
            If (Me.opcionTamanoSeleccionada = OpcionTamano.simple) Then
                datos = tarimas.ObtenerListadoReporteCajasSimple(aplicaFecha)
            ElseIf (Me.opcionTamanoSeleccionada = OpcionTamano.detallado) Then
                datos = tarimas.ObtenerListadoReporteCajasDetallado(aplicaFecha)            
            End If
        ElseIf (Me.opcionTipoSeleccionada = OpcionTipo.tarimas) Then
            If (Me.opcionTamanoSeleccionada = OpcionTamano.simple) Then
                datos = tarimas.ObtenerListadoReporteTarimasSimple(aplicaFecha)
            ElseIf (Me.opcionTamanoSeleccionada = OpcionTamano.detallado) Then
                datos = tarimas.ObtenerListadoReporteTarimasDetallado(aplicaFecha)
            End If
        End If

        '' ' Ejemplo agrupamiento linq 1.
        '' Dim distinctRows() As DataRow = (From row As DataRow In datos.Rows.Cast(Of DataRow)() _
        ''                   Group row By randomField = row.Field(Of Integer)("IdProductor") Into Group _
        ''                   Select Group(0)).ToArray
        '' Dim dt2 As DataTable = distinctRows.CopyToDataTable() 

        '' ' Ejemplo agrupamiento linq 2.  
        '' Dim query = From row In datos
        '' Group row By Month = row.Field(Of Int32)("IdProductor") Into MonthGroup = Group
        '' Select New With {
        ''     Key Month,
        ''     .Sales = MonthGroup.Sum(Function(r) r.Field(Of Int32)("CajasAnteriores")),
        ''     .Leads = MonthGroup.Sum(Function(r) r.Field(Of Int32)("CajasRangos")),
        ''     .Gross = MonthGroup.Sum(Function(r) r.Field(Of Int32)("CajasActuales"))
        ''}
        '' For Each x In query
        ''     Console.WriteLine("Month:{0} {1} {2} {3}", x.Month, x.Sales, x.Leads, x.Gross)
        '' Next

        spReporte.ActiveSheet.DataSource = datos
        FormatearSpreadReporte(spReporte.ActiveSheet.Columns.Count)
        CalcularTotales(0, "Total", spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").Index, spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").Index, spReporte.ActiveSheet.Columns.Count, 0, spReporte.ActiveSheet.Rows.Count)
        btnImprimir.Enabled = True
        btnExportarExcel.Enabled = True
        btnExportarPdf.Enabled = True
        AsignarFoco(dtpFecha)
        MostrarOcultar()

    End Sub

    Private Sub CalcularTotales(ByVal columnaConceptoTotal As Integer, ByVal valorColumnaConceptoTotal As String, ByVal cantidadColumnasSpan As Integer, ByVal columnaInicial As Integer, ByVal columnaFinal As Integer, ByVal filaInicial As Integer, ByVal filaFinal As Integer)

        If (filaFinal > 0) Then
            Dim numeroColumnas As Integer = spReporte.ActiveSheet.Columns.Count
            spReporte.ActiveSheet.AddUnboundRows(filaFinal, 1)
            spReporte.ActiveSheet.AddSpanCell(filaFinal, columnaConceptoTotal, 1, cantidadColumnasSpan)
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

    Private Sub FormatearSpreadReporte(ByVal cantidadColumnas As Integer)

        spReporte.Visible = True
        spReporte.ActiveSheet.SheetName = "Reporte de Empaque"
        spReporte.ActiveSheet.GrayAreaBackColor = Principal.colorSpreadAreaGris
        spReporte.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Dim numeracion As Integer = 0
        spReporte.ActiveSheet.Columns.Count = cantidadColumnas
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idProductor" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreProductor" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idVariedad" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreVariedad" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idEnvase" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreEnvase" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idTamano" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreTamano" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idEtiqueta" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreEtiqueta" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasAnteriores" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasRango" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasActuales" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasPiso" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasEmbarcadas" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasExportadasAnteriores" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasExportadasRango" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasExportadasActuales" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasNacionalesAnteriores" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasNacionalesRango" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajasNacionalesActuales" : numeracion += 1
        spReporte.ActiveSheet.ColumnHeader.RowCount = 2
        spReporte.ActiveSheet.ColumnHeader.Rows(0, spReporte.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spReporte.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread * 1.25
        spReporte.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread * 1.25
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idProductor").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idProductor").Index).Value = "P r o d u c t o r".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idProductor").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreProductor").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idProducto").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idProducto").Index).Value = "P r o d u c t o".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idProducto").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idVariedad").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idVariedad").Index).Value = "V a r i e d a d".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idVariedad").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreVariedad").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idEnvase").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idEnvase").Index).Value = "E n v a s e".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idEnvase").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreEnvase").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idTamano").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idTamano").Index).Value = "T a m a ñ o".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idTamano").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreTamano").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idEtiqueta").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idEtiqueta").Index).Value = "E t i q u e t a".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idEtiqueta").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreEtiqueta").Index).Value = "Nombre".ToUpper
        Dim valor As String = IIf(Me.opcionTipoSeleccionada = OpcionTipo.cajas, "Cajas", "Tarimas").ToString.ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").Index, 1, 3)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").Index).Value = "E m p a c a d o".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").Index).Value = valor & " Anteriores".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasRango").Index).Value = valor & " Rango".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasActuales").Index).Value = valor & " Actuales".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("cantidadCajasPiso").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("cantidadCajasPiso").Index).Value = "E s t a t u s   A c t u a l".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasPiso").Index).Value = valor & " en Piso".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasEmbarcadas").Index).Value = valor & " Embarcadas".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("cantidadCajasExportadasAnteriores").Index, 1, 3)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("cantidadCajasExportadasAnteriores").Index).Value = "E m b a r c a d o   E x p o r t a c i ó n".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasExportadasAnteriores").Index).Value = valor & " Anteriores".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasExportadasRango").Index).Value = valor & " Rango".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasExportadasActuales").Index).Value = valor & " Actuales".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("cantidadCajasNacionalesAnteriores").Index, 1, 3)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("cantidadCajasNacionalesAnteriores").Index).Value = "E m b a r c a d o   N a c i o n a l".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasNacionalesAnteriores").Index).Value = valor & " Anteriores".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasNacionalesRango").Index).Value = valor & " Rango".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("cantidadCajasNacionalesActuales").Index).Value = valor & " Actuales".ToUpper
        spReporte.ActiveSheet.Columns("idProductor").Width = 50
        spReporte.ActiveSheet.Columns("nombreProductor").Width = 170
        spReporte.ActiveSheet.Columns("idProducto").Width = 50
        spReporte.ActiveSheet.Columns("nombreProducto").Width = 150
        spReporte.ActiveSheet.Columns("idVariedad").Width = 50
        spReporte.ActiveSheet.Columns("nombreVariedad").Width = 150
        spReporte.ActiveSheet.Columns("idEnvase").Width = 50
        spReporte.ActiveSheet.Columns("nombreEnvase").Width = 150
        spReporte.ActiveSheet.Columns("idTamano").Width = 50
        spReporte.ActiveSheet.Columns("nombreTamano").Width = 150
        spReporte.ActiveSheet.Columns("idEtiqueta").Width = 50
        spReporte.ActiveSheet.Columns("nombreEtiqueta").Width = 150
        spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").Width = 95
        spReporte.ActiveSheet.Columns("cantidadCajasRango").Width = 90
        spReporte.ActiveSheet.Columns("cantidadCajasActuales").Width = IIf(chkFecha.Checked, 90, 100)
        spReporte.ActiveSheet.Columns("cantidadCajasPiso").Width = 90
        spReporte.ActiveSheet.Columns("cantidadCajasEmbarcadas").Width = 100
        spReporte.ActiveSheet.Columns("cantidadCajasExportadasAnteriores").Width = 95
        spReporte.ActiveSheet.Columns("cantidadCajasExportadasRango").Width = 90
        spReporte.ActiveSheet.Columns("cantidadCajasExportadasActuales").Width = IIf(chkFecha.Checked, 90, 116)
        spReporte.ActiveSheet.Columns("cantidadCajasNacionalesAnteriores").Width = 95
        spReporte.ActiveSheet.Columns("cantidadCajasNacionalesRango").Width = 90
        spReporte.ActiveSheet.Columns("cantidadCajasNacionalesActuales").Width = IIf(chkFecha.Checked, 90, 115)
        Dim anchoFiltros As Integer = 0 '10
        For columna = 0 To spReporte.ActiveSheet.Columns.Count - 1
            spReporte.ActiveSheet.Columns(columna).Width += anchoFiltros
        Next
        spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasRango").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasActuales").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasPiso").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasEmbarcadas").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasExportadasAnteriores").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasExportadasRango").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasExportadasActuales").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasNacionalesAnteriores").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasNacionalesRango").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("cantidadCajasNacionalesActuales").CellType = tipoEntero
        If (Me.opcionTamanoSeleccionada = OpcionTamano.simple) Then
            If (cbProductos.SelectedValue > 0) Then
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idProducto").Index, spReporte.ActiveSheet.Columns("nombreProducto").Index).Visible = True
            Else
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idProducto").Index, spReporte.ActiveSheet.Columns("nombreProducto").Index).Visible = False
            End If
            If (cbVariedades.SelectedValue > 0) Then
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idVariedad").Index, spReporte.ActiveSheet.Columns("nombreVariedad").Index).Visible = True
            Else
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idVariedad").Index, spReporte.ActiveSheet.Columns("nombreVariedad").Index).Visible = False
            End If
            If (cbEnvases.SelectedValue > 0) Then
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idEnvase").Index, spReporte.ActiveSheet.Columns("nombreEnvase").Index).Visible = True
            Else
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idEnvase").Index, spReporte.ActiveSheet.Columns("nombreEnvase").Index).Visible = False
            End If
            If (cbTamanos.SelectedValue > 0) Then
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idTamano").Index, spReporte.ActiveSheet.Columns("nombreTamano").Index).Visible = True
            Else
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idTamano").Index, spReporte.ActiveSheet.Columns("nombreTamano").Index).Visible = False
            End If
            If (cbEtiquetas.SelectedValue > 0) Then
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idEtiqueta").Index, spReporte.ActiveSheet.Columns("nombreEtiqueta").Index).Visible = True
            Else
                spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idEtiqueta").Index, spReporte.ActiveSheet.Columns("nombreEtiqueta").Index).Visible = False
            End If
        End If
        If (chkFecha.Checked) Then
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").Index, spReporte.ActiveSheet.Columns("cantidadCajasRango").Index).Visible = True
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("cantidadCajasExportadasAnteriores").Index, spReporte.ActiveSheet.Columns("cantidadCajasExportadasRango").Index).Visible = True
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("cantidadCajasNacionalesAnteriores").Index, spReporte.ActiveSheet.Columns("cantidadCajasNacionalesRango").Index).Visible = True
        Else
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").Index, spReporte.ActiveSheet.Columns("cantidadCajasRango").Index).Visible = False
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("cantidadCajasExportadasAnteriores").Index, spReporte.ActiveSheet.Columns("cantidadCajasExportadasRango").Index).Visible = False
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("cantidadCajasNacionalesAnteriores").Index, spReporte.ActiveSheet.Columns("cantidadCajasNacionalesRango").Index).Visible = False
        End If
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

    Private Sub CargarComboProductos()

        productores.EId = 0
        cbProductos.ValueMember = "Id"
        cbProductos.DisplayMember = "Nombre"
        cbProductos.DataSource = productos.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboVariedades()

        Dim idProducto As Integer = cbProductos.SelectedValue()
        variedades.EIdProducto = idProducto
        variedades.EId = 0
        cbVariedades.ValueMember = "Id"
        cbVariedades.DisplayMember = "Nombre"
        cbVariedades.DataSource = variedades.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboEnvases()

        envases.EId = 0
        cbEnvases.ValueMember = "Id"
        cbEnvases.DisplayMember = "Nombre"
        cbEnvases.DataSource = envases.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboTamanos()

        Dim idProducto As Integer = cbProductos.SelectedValue()
        tamanos.EIdProducto = idProducto
        tamanos.EId = 0
        cbTamanos.ValueMember = "Id"
        cbTamanos.DisplayMember = "Nombre"
        cbTamanos.DataSource = tamanos.ObtenerListadoReporte()

    End Sub

    Private Sub CargarComboEtiquetas()

        etiquetas.EId = 0
        cbEtiquetas.ValueMember = "Id"
        cbEtiquetas.DisplayMember = "Nombre"
        cbEtiquetas.DataSource = etiquetas.ObtenerListadoReporte()

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Enum OpcionTipo

        cajas = 1
        tarimas = 2

    End Enum

    Enum OpcionTamano

        detallado = 1
        simple = 2

    End Enum

#End Region

End Class