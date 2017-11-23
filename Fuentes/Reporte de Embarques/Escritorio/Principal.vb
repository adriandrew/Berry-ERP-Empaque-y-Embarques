Imports System.IO
Imports FarPoint.Win.Spread
Imports System.Reflection
Imports System.Threading

Public Class Principal

    ' Variables de objetos de entidades.
    Public empresas As New EYEEntidadesReporteEmbarques.Empresas()
    Public usuarios As New EYEEntidadesReporteEmbarques.Usuarios()
    Public embarques As New EYEEntidadesReporteEmbarques.Embarques()
    Public productores As New EYEEntidadesReporteEmbarques.Productores()
    Public productos As New EYEEntidadesReporteEmbarques.Productos()
    Public variedades As New EYEEntidadesReporteEmbarques.Variedades()
    Public envases As New EYEEntidadesReporteEmbarques.Envases()
    Public tamanos As New EYEEntidadesReporteEmbarques.Tamanos()
    Public etiquetas As New EYEEntidadesReporteEmbarques.Etiquetas()
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

    Private Sub pnlFiltros_MouseEnter(sender As Object, e As EventArgs) Handles pnlFiltros.MouseEnter, gbFechas.MouseEnter, gbOpciones.MouseEnter, chkFecha.MouseEnter, cbEmbarcadores.MouseEnter

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
            AsignarFoco(cbEmbarcadores)
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(dtpFecha)
        End If

    End Sub

    Private Sub cbProductor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbEmbarcadores.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (cbEmbarcadores.SelectedValue <= 0) Then
                AsignarFoco(btnGenerar)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            AsignarFoco(dtpFechaFinal)
        End If

    End Sub

    Private Sub btnGenerar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnGenerar.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            If (cbEmbarcadores.Enabled) Then
                AsignarFoco(cbEmbarcadores)
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
            HabilitarControles()
        End If

    End Sub

    Private Sub rbtnDetallado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnDetallado.CheckedChanged

        If (rbtnDetallado.Checked) Then
            Me.opcionTamanoSeleccionada = OpcionTamano.detallado
            HabilitarControles()
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
            EYELogicaReporteEmbarques.Directorios.id = 1
            EYELogicaReporteEmbarques.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaReporteEmbarques.Directorios.usuarioSql = "AdminBerry"
            EYELogicaReporteEmbarques.Directorios.contrasenaSql = "@berry2017"
            pnlEncabezado.BackColor = Color.DarkRed
        Else
            EYELogicaReporteEmbarques.Directorios.ObtenerParametros()
            EYELogicaReporteEmbarques.Usuarios.ObtenerParametros()
        End If
        EYELogicaReporteEmbarques.Programas.bdCatalogo = "Catalogo" & EYELogicaReporteEmbarques.Directorios.id
        EYELogicaReporteEmbarques.Programas.bdConfiguracion = "Configuracion" & EYELogicaReporteEmbarques.Directorios.id
        EYELogicaReporteEmbarques.Programas.bdEmpaque = "Empaque" & EYELogicaReporteEmbarques.Directorios.id
        EYEEntidadesReporteEmbarques.BaseDatos.ECadenaConexionCatalogo = EYELogicaReporteEmbarques.Programas.bdCatalogo
        EYEEntidadesReporteEmbarques.BaseDatos.ECadenaConexionConfiguracion = EYELogicaReporteEmbarques.Programas.bdConfiguracion
        EYEEntidadesReporteEmbarques.BaseDatos.ECadenaConexionEmpaque = EYELogicaReporteEmbarques.Programas.bdEmpaque
        EYEEntidadesReporteEmbarques.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesReporteEmbarques.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesReporteEmbarques.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesReporteEmbarques.Usuarios)
        usuarios.EId = EYELogicaReporteEmbarques.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count > 0) Then
            EYELogicaReporteEmbarques.Usuarios.id = lista(0).EId
            EYELogicaReporteEmbarques.Usuarios.nombre = lista(0).ENombre
            EYELogicaReporteEmbarques.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaReporteEmbarques.Usuarios.nivel = lista(0).ENivel
            EYELogicaReporteEmbarques.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaReporteEmbarques.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub CargarEncabezadosTitulos()

        lblEncabezadoPrograma.Text = "Programa: " & Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " & EYELogicaReporteEmbarques.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " & EYELogicaReporteEmbarques.Usuarios.nombre
        Me.Text = "Programa:  " & Me.nombreEstePrograma & "              Directorio:  " & EYELogicaReporteEmbarques.Directorios.nombre & "              Usuario:  " & EYELogicaReporteEmbarques.Usuarios.nombre
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
        ejecutarProgramaPrincipal.Arguments = EYELogicaReporteEmbarques.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmbarques.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmbarques.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmbarques.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmbarques.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmbarques.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmbarques.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaReporteEmbarques.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaReporteEmbarques.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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

    Private Sub HabilitarControles()

        If (Me.opcionTamanoSeleccionada = OpcionTamano.simple) Then
            cbProductos.Enabled = False
            cbVariedades.Enabled = False
            cbEnvases.Enabled = False
            cbTamanos.Enabled = False
            cbEtiquetas.Enabled = False
        Else
            cbProductos.Enabled = True
            cbVariedades.Enabled = True
            cbEnvases.Enabled = True
            cbTamanos.Enabled = True
            cbEtiquetas.Enabled = True
        End If

    End Sub

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
        informacionImpresion.ZoomFactor = IIf(Me.opcionTamanoSeleccionada = OpcionTamano.simple, 0.5, 0.55)
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
        embarques.EIdEmbarcador = cbEmbarcadores.SelectedValue
        embarques.EIdProducto = cbProductos.SelectedValue
        embarques.EIdVariedad = cbVariedades.SelectedValue
        embarques.EIdEnvase = cbEnvases.SelectedValue
        embarques.EIdTamano = cbTamanos.SelectedValue
        embarques.EIdEtiqueta = cbEtiquetas.SelectedValue
        Dim fecha As Date = dtpFecha.Value.ToShortDateString : Dim fecha2 As Date = dtpFechaFinal.Value.ToShortDateString
        Dim aplicaFecha As Boolean = False
        If (chkFecha.Checked) Then
            aplicaFecha = True
            embarques.EFecha = fecha : embarques.EFecha2 = fecha2
        Else
            aplicaFecha = False
        End If
        If (Me.opcionTamanoSeleccionada = OpcionTamano.simple) Then
            datos = embarques.ObtenerListadoReporteEmbarques(aplicaFecha)
        ElseIf (Me.opcionTamanoSeleccionada = OpcionTamano.detallado) Then
            datos = embarques.ObtenerListadoReporteEmbarquesDetallado(aplicaFecha)
        End If
        spReporte.ActiveSheet.DataSource = datos
        spReporte.Visible = True
        If (Me.opcionTamanoSeleccionada = OpcionTamano.simple) Then
            FormatearSpreadReporteEmbarques(spReporte.ActiveSheet.Columns.Count)
        ElseIf (Me.opcionTamanoSeleccionada = OpcionTamano.detallado) Then
            FormatearSpreadReporteEmbarquesDetallado(spReporte.ActiveSheet.Columns.Count)
            Dim idAnterior As Integer = 0
            Dim tipoAnterior As String = String.Empty 
            Dim fila As Integer = 0 : Dim filaAnterior As Integer = 0
            While (fila <= spReporte.ActiveSheet.Rows.Count - 1)
                Dim id As Integer = EYELogicaReporteEmbarques.Funciones.ValidarNumeroACero(spReporte.ActiveSheet.Cells(fila, spReporte.ActiveSheet.Columns("id").Index).Text)
                Dim tipo As String = EYELogicaReporteEmbarques.Funciones.ValidarLetra(spReporte.ActiveSheet.Cells(fila, spReporte.ActiveSheet.Columns("tipo").Index).Text) 
                ' Los dos if de abajo hacen lo mismo, con la diferencia que el ultimo aumenta una fila, se supone que es el registro final del reporte, por eso lo hace.
                ' No se pueden poner juntos porque en algunos casos no imprimen correctamente los subtotales.
                If (id <> idAnterior Or Not tipo.ToUpper.Equals(tipoAnterior.ToUpper)) Then
                    ' Se hacen los span de las columnas con datos que se repiten.
                    If (fila > 0) Then
                        For columna = 0 To spReporte.ActiveSheet.Columns("nombreEmbarcador").Index
                            spReporte.ActiveSheet.AddSpanCell(filaAnterior, columna, (fila + 1) - (filaAnterior + 1), 1)
                        Next
                    End If
                    CalcularTotales(True, 0, "SubTotal", spReporte.ActiveSheet.Columns("cantidadCajas").Index, spReporte.ActiveSheet.Columns("cantidadCajas").Index, spReporte.ActiveSheet.Columns.Count, filaAnterior, fila)
                    filaAnterior = IIf(fila > 0, fila + 1, 0)
                    idAnterior = id
                    tipoAnterior = tipo
                ElseIf (fila = spReporte.ActiveSheet.Rows.Count - 1) Then
                    fila += 1
                    ' Se hacen los span de las columnas con datos que se repiten.
                    If (fila > 0) Then
                        For columna = 0 To spReporte.ActiveSheet.Columns("nombreEmbarcador").Index
                            spReporte.ActiveSheet.AddSpanCell(filaAnterior, columna, (fila + 1) - (filaAnterior + 1), 1)
                        Next
                    End If
                    CalcularTotales(True, 0, "SubTotal", spReporte.ActiveSheet.Columns("cantidadCajas").Index, spReporte.ActiveSheet.Columns("cantidadCajas").Index, spReporte.ActiveSheet.Columns.Count, filaAnterior, fila)
                    filaAnterior = IIf(fila > 0, fila + 1, 0)
                    idAnterior = id
                    tipoAnterior = tipo
                End If
                fila += 1
            End While
            CalcularTotales(False, 0, "Total", spReporte.ActiveSheet.Columns("cantidadCajas").Index, spReporte.ActiveSheet.Columns("cantidadCajas").Index, spReporte.ActiveSheet.Columns.Count, 0, spReporte.ActiveSheet.Rows.Count)
        End If
        btnImprimir.Enabled = True
        btnExportarExcel.Enabled = True
        btnExportarPdf.Enabled = True
        AsignarFoco(dtpFecha)
        MostrarOcultar()

    End Sub

    Private Sub CalcularTotales(ByVal esSubTotal As Boolean, ByVal columnaConceptoTotal As Integer, ByVal valorColumnaConceptoTotal As String, ByVal cantidadColumnasSpan As Integer, ByVal columnaInicial As Integer, ByVal columnaFinal As Integer, ByVal filaInicial As Integer, ByVal filaFinal As Integer)

        If (filaFinal > 0) Then
            Dim colorSubTotal As Color = Color.FromArgb(245, 245, 245)
            Dim colorTotal As Color = Color.FromArgb(230, 230, 230)
            Dim colorActual As Color
            If (esSubTotal) Then
                colorActual = colorSubTotal
            Else
                colorActual = colorTotal
            End If
            Dim numeroColumnas As Integer = spReporte.ActiveSheet.Columns.Count
            spReporte.ActiveSheet.AddUnboundRows(filaFinal, 1)
            spReporte.ActiveSheet.AddSpanCell(filaFinal, columnaConceptoTotal, 1, cantidadColumnasSpan)
            spReporte.ActiveSheet.Cells(filaFinal, columnaConceptoTotal).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spReporte.ActiveSheet.Cells(filaFinal, columnaConceptoTotal).CellType = tipoTexto
            spReporte.ActiveSheet.Cells(filaFinal, columnaConceptoTotal).Text = valorColumnaConceptoTotal.ToUpper
            spReporte.ActiveSheet.Cells(filaFinal, 0, filaFinal, numeroColumnas - 1).BackColor = colorActual
            For columna = columnaInicial To columnaFinal - 1
                Dim contador As Double = 0
                For fila = filaInicial To filaFinal - 1
                    If (Not String.IsNullOrEmpty(spReporte.ActiveSheet.Cells(fila, 0).Text)) Then
                        Dim valor As String = spReporte.ActiveSheet.Cells(fila, columna).Text
                        If IsNumeric(valor) Then
                            If (Not esSubTotal) Then ' Si es total.
                                If (spReporte.ActiveSheet.Cells(fila, columna).BackColor = colorSubTotal) Then ' Se suman subtotales únicamente.
                                    contador += spReporte.ActiveSheet.Cells(fila, columna).Value
                                End If
                            Else
                                contador += spReporte.ActiveSheet.Cells(fila, columna).Value
                            End If
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

    Private Sub FormatearSpreadReporteEmbarques(ByVal cantidadColumnas As Integer)

        spReporte.Visible = True
        spReporte.ActiveSheet.SheetName = "Reporte de Embarques"
        spReporte.ActiveSheet.GrayAreaBackColor = Principal.colorSpreadAreaGris
        spReporte.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Dim numeracion As Integer = 0
        spReporte.ActiveSheet.Columns.Count = cantidadColumnas
        spReporte.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "fecha" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "hora" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "tipo" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idEmbarcador" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreEmbarcador" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idCliente" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreCliente" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idLineaTransporte" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreLineaTransporte" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idTrailer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "serieTrailer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idCajaTrailer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "serieCajaTrailer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idChofer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreChofer" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idAduanaMex" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreAduanaMex" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idAduanaUsa" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreAduanaUsa" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idDocumentador" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreDocumentador" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "temperatura" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "termografo" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "precioFlete" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "sello1" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "sello2" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "sello3" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "sello4" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "sello5" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "sello6" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "sello7" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "sello8" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "factura" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "guiaCaades" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "observaciones" : numeracion += 1
        spReporte.ActiveSheet.Columns("id").Width = 50
        spReporte.ActiveSheet.Columns("fecha").Width = 65
        spReporte.ActiveSheet.Columns("hora").Width = 50
        spReporte.ActiveSheet.Columns("tipo").Width = 70
        spReporte.ActiveSheet.Columns("idEmbarcador").Width = 50
        spReporte.ActiveSheet.Columns("nombreEmbarcador").Width = 170
        spReporte.ActiveSheet.Columns("idCliente").Width = 50
        spReporte.ActiveSheet.Columns("nombreCliente").Width = 170
        spReporte.ActiveSheet.Columns("idLineaTransporte").Width = 50
        spReporte.ActiveSheet.Columns("nombreLineaTransporte").Width = 170
        spReporte.ActiveSheet.Columns("idTrailer").Width = 50
        spReporte.ActiveSheet.Columns("serieTrailer").Width = 170
        spReporte.ActiveSheet.Columns("idCajaTrailer").Width = 50
        spReporte.ActiveSheet.Columns("serieCajaTrailer").Width = 170
        spReporte.ActiveSheet.Columns("idChofer").Width = 50
        spReporte.ActiveSheet.Columns("nombreChofer").Width = 170
        spReporte.ActiveSheet.Columns("idAduanaMex").Width = 50
        spReporte.ActiveSheet.Columns("nombreAduanaMex").Width = 170
        spReporte.ActiveSheet.Columns("idAduanaUsa").Width = 50
        spReporte.ActiveSheet.Columns("nombreAduanaUsa").Width = 170
        spReporte.ActiveSheet.Columns("idDocumentador").Width = 50
        spReporte.ActiveSheet.Columns("nombreDocumentador").Width = 170
        spReporte.ActiveSheet.Columns("temperatura").Width = 110
        spReporte.ActiveSheet.Columns("termografo").Width = 110
        spReporte.ActiveSheet.Columns("precioFlete").Width = 80
        spReporte.ActiveSheet.Columns("sello1").Width = 80
        spReporte.ActiveSheet.Columns("sello2").Width = 80
        spReporte.ActiveSheet.Columns("sello3").Width = 80
        spReporte.ActiveSheet.Columns("sello4").Width = 80
        spReporte.ActiveSheet.Columns("sello5").Width = 80
        spReporte.ActiveSheet.Columns("sello6").Width = 80
        spReporte.ActiveSheet.Columns("sello7").Width = 80
        spReporte.ActiveSheet.Columns("sello8").Width = 80
        spReporte.ActiveSheet.Columns("factura").Width = 80
        spReporte.ActiveSheet.Columns("guiaCaades").Width = 80
        spReporte.ActiveSheet.Columns("observaciones").Width = 150
        Dim anchoFiltros As Integer = 10
        For columna = 0 To spReporte.ActiveSheet.Columns.Count - 1
            spReporte.ActiveSheet.Columns(columna).Width += anchoFiltros
        Next
        'spReporte.ActiveSheet.Columns("cantidadCajasAnteriores").CellType = tipoEntero
        spReporte.ActiveSheet.ColumnHeader.RowCount = 2
        spReporte.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread * 1.25
        spReporte.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread * 1.25
        spReporte.ActiveSheet.ColumnHeader.Rows(0, spReporte.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("id").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("fecha").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("fecha").Index).Value = "Fecha".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("hora").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("hora").Index).Value = "Hora".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("tipo").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("tipo").Index).Value = "Tipo".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idEmbarcador").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idEmbarcador").Index).Value = "E m b a r c a d o r".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idEmbarcador").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreEmbarcador").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idCliente").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idCliente").Index).Value = "C l i e n t e".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idCliente").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreCliente").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idLineaTransporte").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idLineaTransporte").Index).Value = "L i n e a   T r a n s p o r t e".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idLineaTransporte").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreLineaTransporte").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idTrailer").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idTrailer").Index).Value = "T r a i l e r".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idTrailer").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("serieTrailer").Index).Value = "Serie".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idCajaTrailer").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idCajaTrailer").Index).Value = "C a j a   T r a i l e r".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idCajaTrailer").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("serieCajaTrailer").Index).Value = "Serie".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idChofer").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idChofer").Index).Value = "C h o f e r".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idChofer").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreChofer").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idAduanaMex").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idAduanaMex").Index).Value = "A d u a n a   M e x".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idAduanaMex").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreAduanaMex").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idAduanaUsa").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idAduanaUsa").Index).Value = "A d u a n a   U s a".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idAduanaUsa").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreAduanaUsa").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idDocumentador").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idDocumentador").Index).Value = "D o c u m e n t a d o r".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idDocumentador").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreDocumentador").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("temperatura").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("temperatura").Index).Value = "Temperatura".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("termografo").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("termografo").Index).Value = "Termografo".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("precioFlete").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("precioFlete").Index).Value = "Precio Flete".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("sello1").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("sello1").Index).Value = "Sello 1".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("sello2").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("sello2").Index).Value = "Sello 2".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("sello3").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("sello3").Index).Value = "Sello 3".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("sello4").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("sello4").Index).Value = "Sello 4".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("sello5").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("sello5").Index).Value = "Sello 5".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("sello6").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("sello6").Index).Value = "Sello 6".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("sello7").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("sello7").Index).Value = "Sello 7".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("sello8").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("sello8").Index).Value = "Sello 8".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("factura").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("factura").Index).Value = "Factura".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("guiaCaades").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("guiaCaades").Index).Value = "Guia Caades".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("observaciones").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("observaciones").Index).Value = "Observaciones".ToUpper 
        spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoFilter = True
        'spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoSort = True
        spReporte.Refresh()

    End Sub

    Private Sub FormatearSpreadReporteEmbarquesDetallado(ByVal cantidadColumnas As Integer)

        spReporte.Visible = True
        spReporte.ActiveSheet.SheetName = "Reporte de Embarques"
        spReporte.ActiveSheet.GrayAreaBackColor = Principal.colorSpreadAreaGris
        spReporte.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Dim numeracion As Integer = 0
        spReporte.ActiveSheet.Columns.Count = cantidadColumnas
        spReporte.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "fecha" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "hora" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "tipo" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idEmbarcador" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreEmbarcador" : numeracion += 1
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
        spReporte.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "pesoCajas" : numeracion += 1
        spReporte.ActiveSheet.Columns("id").Width = 50
        spReporte.ActiveSheet.Columns("fecha").Width = 70
        spReporte.ActiveSheet.Columns("hora").Width = 50
        spReporte.ActiveSheet.Columns("tipo").Width = 70
        spReporte.ActiveSheet.Columns("idEmbarcador").Width = 50
        spReporte.ActiveSheet.Columns("nombreEmbarcador").Width = 170
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
        spReporte.ActiveSheet.Columns("cantidadCajas").Width = 90
        spReporte.ActiveSheet.Columns("pesoCajas").Width = 70
        Dim anchoFiltros As Integer = 10
        For columna = 0 To spReporte.ActiveSheet.Columns.Count - 1
            spReporte.ActiveSheet.Columns(columna).Width += anchoFiltros
        Next
        spReporte.ActiveSheet.Columns("cantidadCajas").CellType = tipoEntero
        spReporte.ActiveSheet.Columns("pesoCajas").CellType = tipoDoble
        spReporte.ActiveSheet.ColumnHeader.RowCount = 2
        spReporte.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread * 1.25
        spReporte.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread * 1.25
        spReporte.ActiveSheet.ColumnHeader.Rows(0, spReporte.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("id").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("fecha").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("fecha").Index).Value = "Fecha".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("hora").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("hora").Index).Value = "Hora".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("tipo").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("tipo").Index).Value = "Tipo".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idEmbarcador").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idEmbarcador").Index).Value = "E m b a r c a d o r".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idEmbarcador").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreEmbarcador").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idProducto").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idProducto").Index).Value = "Producto".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idProducto").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idVariedad").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idVariedad").Index).Value = "Variedad".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idVariedad").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreVariedad").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idEnvase").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idEnvase").Index).Value = "Envase".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idEnvase").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreEnvase").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idTamano").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idTamano").Index).Value = "Tamaño".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idTamano").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreTamano").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idEtiqueta").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idEtiqueta").Index).Value = "Etiqueta".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idEtiqueta").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreEtiqueta").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("cantidadCajas").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("cantidadCajas").Index).Value = "Cantidad Cajas".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("pesoCajas").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("pesoCajas").Index).Value = "Peso Cajas".ToUpper
        spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoFilter = True
        'spReporte.ActiveSheet.Columns(0, spReporte.ActiveSheet.Columns.Count - 1).AllowAutoSort = True
        spReporte.Refresh()

    End Sub

    Private Sub CargarComboProductores()

        productores.EId = 0
        cbEmbarcadores.ValueMember = "Id"
        cbEmbarcadores.DisplayMember = "Nombre"
        cbEmbarcadores.DataSource = productores.ObtenerListadoReporte()

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

    Enum OpcionTamano

        detallado = 1
        simple = 2

    End Enum

#End Region

End Class