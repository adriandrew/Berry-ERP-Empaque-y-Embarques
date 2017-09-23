Imports System.IO
Imports System.ComponentModel
Imports System.Threading

Public Class Principal

    ' Variables de objetos de entidades.
    Public usuarios As New EYEEntidadesConfiguraciones.Usuarios()
    Public cajasPesoTarimas As New EYEEntidadesConfiguraciones.CajasPesoTarimas()
    Public productos As New EYEEntidadesConfiguraciones.Productos()
    Public envases As New EYEEntidadesConfiguraciones.Envases()
    Public tamanos As New EYEEntidadesConfiguraciones.Tamaños()
    Public etiquetas As New EYEEntidadesConfiguraciones.Etiquetas()
    Public precios As New EYEEntidadesConfiguraciones.Precios()
    ' Variables de tipos de datos de spread.
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoTextoContrasena As New FarPoint.Win.Spread.CellType.TextCellType()
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
    Public Shared tipoLetraSpread As String = "Microsoft Sans Serif" : Public Shared tamañoLetraSpread As Integer = 11
    Public Shared alturaFilasEncabezadosGrandesSpread As Integer = 35 : Public Shared alturaFilasEncabezadosMedianosSpread As Integer = 28
    Public Shared alturaFilasEncabezadosChicosSpread As Integer = 22 : Public Shared alturaFilasSpread As Integer = 20
    Public Shared colorAreaGris = Color.White
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public medidasUnaVez As Boolean = False
    Public opcionSeleccionada As Integer = 0
    Public opcionSeleccionadaSubMenu As Integer = 0
    Public estaCerrando As Boolean = False
    Public ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public prefijoBaseDatosEmpaque As String = "EYE" & "_"
    ' Hilos para carga rapida. 
    Public hiloCentrar As New Thread(AddressOf Centrar)
    Public hiloNombrePrograma As New Thread(AddressOf CargarNombrePrograma)
    Public hiloEncabezadosTitulos As New Thread(AddressOf CargarEncabezadosTitulos)
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

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Cursor = Cursors.WaitCursor
        'If (Not ValidarAccesoTotal()) Then
        '    Salir()
        'End If 
        FormatearSpread()
        MostrarCargando(False)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Cursor = Cursors.WaitCursor
        Dim nombrePrograma As String = "PrincipalBerry"
        AbrirPrograma(nombrePrograma, True)
        System.Threading.Thread.Sleep(3000)
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

        Salir()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Me.Cursor = Cursors.WaitCursor
        If (Me.opcionSeleccionada = OpcionMenu.cajasPesoTarimas) Then
            GuardarEditarCajasPesoTarimas() 
        ElseIf (Me.opcionSeleccionada = OpcionMenu.precios) Then
            GuardarEditarPrecios()
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Me.Cursor = Cursors.WaitCursor
        If (Me.opcionSeleccionada = OpcionMenu.cajasPesoTarimas) Then
            EliminarCajasPesoTarimas(True) 
        ElseIf (Me.opcionSeleccionada = OpcionMenu.precios) Then
            EliminarPrecios(True)
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnGuardar_MouseEnter(sender As Object, e As EventArgs) Handles btnGuardar.MouseEnter

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub btnEliminar_MouseEnter(sender As Object, e As EventArgs) Handles btnEliminar.MouseEnter

        AsignarTooltips("Eliminar.")

    End Sub

    Private Sub btnSalir_MouseEnter(sender As Object, e As EventArgs) Handles btnSalir.MouseEnter

        AsignarTooltips("Salir.")

    End Sub

    Private Sub pnlEncabezado_MouseEnter(sender As Object, e As EventArgs) Handles pnlPie.MouseEnter, pnlEncabezado.MouseEnter, pnlCuerpo.MouseEnter

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub spCatalogos_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos.CellClick

        Dim fila As Integer = e.Row
        CargarDatosEnSpreadDeCatalogos(fila)

    End Sub

    Private Sub spCatalogos_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos.CellDoubleClick

        VolverFocoDeCatalogos()

    End Sub

    Private Sub spCatalogos_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            Dim fila As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
            CargarDatosEnSpreadDeCatalogos(fila)
        ElseIf (e.KeyCode = Keys.Escape) Then
            VolverFocoDeCatalogos()
        End If

    End Sub

    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick

        If (Me.estaCerrando) Then
            Desvanecer()
        End If

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click

        MostrarAyuda()

    End Sub

    Private Sub btnAyuda_MouseEnter(sender As Object, e As EventArgs) Handles btnAyuda.MouseEnter

        AsignarTooltips("Ayuda.")

    End Sub

    Private Sub rbtnCajasPesoTarimas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCajasPesoTarimas.CheckedChanged

        If (rbtnCajasPesoTarimas.Checked) Then
            SeleccionoCajasPesoTarimas()
        End If

    End Sub

    Private Sub rbtnProductos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnMatrices.CheckedChanged

        If (rbtnMatrices.Checked) Then
            'SeleccionoProductos()
        End If

    End Sub

    Private Sub pnlMenu_MouseEnter(sender As Object, e As EventArgs) Handles pnlMenu.MouseEnter

        AsignarTooltips("Menú.")

    End Sub

    Private Sub rbtnPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPrecios.CheckedChanged

        If (rbtnPrecios.Checked) Then
            SeleccionoPrecios()
        End If

    End Sub

    Private Sub spVarios_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spVarios.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter(spVarios)
        End If

    End Sub

    Private Sub spVarios_KeyDown(sender As Object, e As KeyEventArgs) Handles spVarios.KeyDown

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter(spVarios)
        ElseIf (e.KeyData = Keys.F6) Then ' Eliminar un registro. 
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                EliminarRegistroDeSpread(spVarios)
            End If
        ElseIf (e.KeyData = Keys.F5) Then ' Abrir catalogos.
            CargarCatalogoEnSpread()
        End If

    End Sub

    Private Sub CargarCatalogoEnSpread()

        pnlMenu.Enabled = False
        spVarios.Enabled = False
        If (Me.opcionSeleccionada = OpcionMenu.cajasPesoTarimas Or Me.opcionSeleccionada = OpcionMenu.precios) Then
            If (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("idProducto").Index) Or (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("nombreProducto").Index) Then
                Me.opcionSeleccionadaSubMenu = OpcionSubMenu.producto
                CargarCatalogoProductos()
            ElseIf (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("idEnvase").Index) Or (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("nombreEnvase").Index) Then
                Me.opcionSeleccionadaSubMenu = OpcionSubMenu.envase
                CargarCatalogoEnvases()
            Else
                pnlMenu.Enabled = True
                spVarios.Enabled = True
            End If
            If (Me.opcionSeleccionada = OpcionMenu.precios) Then
                If (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("idTamano").Index) Or (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("nombreTamano").Index) Then
                    Me.opcionSeleccionadaSubMenu = OpcionSubMenu.tamano
                    CargarCatalogoTamanos()
                ElseIf (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("idEtiqueta").Index) Or (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("nombreEtiqueta").Index) Then
                    Me.opcionSeleccionadaSubMenu = OpcionSubMenu.etiqueta
                    CargarCatalogoEtiquetas()
                Else
                    pnlMenu.Enabled = True
                    spVarios.Enabled = True
                End If
            End If
        Else
            pnlMenu.Enabled = True
            spVarios.Enabled = True
        End If
        AsignarFoco(txtBuscarCatalogo)

    End Sub

    Private Sub Principal_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        If (Not Me.medidasUnaVez) Then
            If (pnlMenu.HorizontalScroll.Visible) Then
                pnlMenu.Height += 15
                CargarMedidas()
                Me.medidasUnaVez = True
            End If
        Else
            If (Not pnlMenu.HorizontalScroll.Visible) Then
                pnlMenu.Height -= 15
                CargarMedidas()
                Me.medidasUnaVez = False
            End If
        End If

    End Sub

    Private Sub txtBuscarCatalogo_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarCatalogo.TextChanged

        BuscarCatalogos()

    End Sub

    Private Sub txtBuscarCatalogo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarCatalogo.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            AsignarFoco(spCatalogos)
        ElseIf (e.KeyCode = Keys.Escape) Then
            VolverFocoDeCatalogos()
        End If

    End Sub

#End Region

#Region "Métodos"

#Region "Básicos"

    Private Sub BuscarCatalogos()

        Dim valorBuscado As String = txtBuscarCatalogo.Text.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u")
        For fila = 0 To spCatalogos.ActiveSheet.Rows.Count - 1
            Dim valorSpread As String = EYELogicaConfiguraciones.Funciones.ValidarLetra(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text & spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text).Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u")
            If (valorSpread.ToUpper.Contains(valorBuscado.ToUpper)) Then
                spCatalogos.ActiveSheet.Rows(fila).Visible = True
            Else
                spCatalogos.ActiveSheet.Rows(fila).Visible = False
            End If
        Next

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

    End Sub

    Private Sub Salir()

        Application.Exit()

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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Teclas básicas: " & vbNewLine & "F5 sirve para mostrar catálogos. " & vbNewLine & "F6 sirve para eliminar un registro únicamente. " & vbNewLine & "Escape sirve para ocultar catálogos que se encuentren desplegados. " & vbNewLine & vbNewLine & "* Catálogos desplegados: " & vbNewLine & "Cuando se muestra algún catálogo, al seleccionar alguna opción de este, se va mostrando en tiempo real en la captura de donde se originó. Cuando se le da doble clic en alguna opción o a la tecla escape se oculta dicho catálogo. " & vbNewLine & vbNewLine & "* Datos obligatorios:" & vbNewLine & "Todos los que tengan el simbolo * son estrictamente obligatorios." & vbNewLine & vbNewLine & "* Captura:" & vbNewLine & "* Almacenes: " & vbNewLine & "En esta pestaña se capturarán los distintos almacenes que se manejan. " & vbNewLine & "* Familias: " & vbNewLine & "En esta parte se agrupan por un primer nivel dependiendo el almacén, ejemplo: insecticidas, agroquimicos, etc. " & vbNewLine & "* SubFamilias: " & vbNewLine & "En este apartado se capturarán todos los segundos niveles de acuerdo al almacén y familia correspondiente seleccionadas. " & vbNewLine & "* Artículos: " & vbNewLine & "En este lugar se agrupan los terceros niveles de acuerdo al almacén, familia y subfamilia correspondiente seleccionadas. " & vbNewLine & "* Existen distintas opciones que se tienen que configurar como proveedores, monedas, tipos de cambio, etc. en las cuales especifíca claramente todo lo que se necesita." & vbNewLine & vbNewLine & "* Para todas las opciones existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. "
            pnlAyuda.Controls.Add(txtAyuda)
        Else
            pnlCuerpo.Visible = True
            pnlAyuda.Visible = False
        End If
        Application.DoEvents()

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

    Private Function ValidarAccesoTotal() As Boolean

        If ((Not EYELogicaConfiguraciones.Usuarios.accesoTotal) Or (EYELogicaConfiguraciones.Usuarios.accesoTotal = 0) Or (EYELogicaConfiguraciones.Usuarios.accesoTotal = False)) Then
            MsgBox("No tienes permisos suficientes para acceder a este programa.", MsgBoxStyle.Information, "Permisos insuficientes.")
            Return False
        Else
            Return True
        End If

    End Function

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
        tp.SetToolTip(Me.pnlEncabezado, "Datos Principales.")
        tp.SetToolTip(Me.btnAyuda, "Ayuda.")
        tp.SetToolTip(Me.btnSalir, "Salir.")
        tp.SetToolTip(Me.btnGuardar, "Guardar.")
        tp.SetToolTip(Me.btnEliminar, "Eliminar.")
        tp.SetToolTip(Me.pnlMenu, "Menú.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            EYELogicaConfiguraciones.Directorios.id = 1
            EYELogicaConfiguraciones.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaConfiguraciones.Directorios.usuarioSql = "AdminBerry"
            EYELogicaConfiguraciones.Directorios.contrasenaSql = "@berry2017"
            pnlEncabezado.BackColor = Color.DarkRed
            pnlPie.BackColor = Color.DarkRed
        Else
            EYELogicaConfiguraciones.Directorios.ObtenerParametros()
            EYELogicaConfiguraciones.Usuarios.ObtenerParametros()
        End If
        EYELogicaConfiguraciones.Programas.bdCatalogo = "Catalogo" & EYELogicaConfiguraciones.Directorios.id
        EYELogicaConfiguraciones.Programas.bdConfiguracion = "Configuracion" & EYELogicaConfiguraciones.Directorios.id
        EYELogicaConfiguraciones.Programas.bdEmpaque = "Empaque" & EYELogicaConfiguraciones.Directorios.id
        EYEEntidadesConfiguraciones.BaseDatos.ECadenaConexionCatalogo = EYELogicaConfiguraciones.Programas.bdCatalogo
        EYEEntidadesConfiguraciones.BaseDatos.ECadenaConexionConfiguracion = EYELogicaConfiguraciones.Programas.bdConfiguracion
        EYEEntidadesConfiguraciones.BaseDatos.ECadenaConexionEmpaque = EYELogicaConfiguraciones.Programas.bdEmpaque
        EYEEntidadesConfiguraciones.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesConfiguraciones.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesConfiguraciones.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaConfiguraciones.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesConfiguraciones.Usuarios)
        usuarios.EId = EYELogicaConfiguraciones.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count > 0) Then
            EYELogicaConfiguraciones.Usuarios.id = lista(0).EId
            EYELogicaConfiguraciones.Usuarios.nombre = lista(0).ENombre
            EYELogicaConfiguraciones.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaConfiguraciones.Usuarios.nivel = lista(0).ENivel
            EYELogicaConfiguraciones.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarEncabezadosTitulos()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " + EYELogicaConfiguraciones.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " + EYELogicaConfiguraciones.Usuarios.nombre
        Me.Text = "Programa:  " + Me.nombreEstePrograma + "              Directorio:  " + EYELogicaConfiguraciones.Directorios.nombre + "              Usuario:  " + EYELogicaConfiguraciones.Usuarios.nombre
        hiloEncabezadosTitulos.Abort()

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = EYELogicaConfiguraciones.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaConfiguraciones.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaConfiguraciones.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaConfiguraciones.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaConfiguraciones.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaConfiguraciones.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaConfiguraciones.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaConfiguraciones.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaConfiguraciones.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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

#End Region

#Region "Todos"

    Private Sub AsignarFoco(ByVal c As Control)

        c.Focus()

    End Sub

    Private Sub AcomodarSpread()

        spVarios.Height = Me.altoTotal
        spVarios.Width = Me.anchoTotal
        spVarios.Top = Me.arriba
        spVarios.Left = Me.izquierda
        spVarios.Show()

    End Sub

    Public Sub ControlarSpreadEnterASiguienteColumna(ByVal spread As FarPoint.Win.Spread.FpSpread)

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
        tipoTextoContrasena.PasswordChar = "*"

    End Sub

    Private Sub CargarMedidas()

        Me.izquierda = 0
        Me.arriba = pnlMenu.Height
        Me.anchoTotal = pnlCuerpo.Width
        Me.altoTotal = pnlCuerpo.Height - pnlMenu.Height
        Me.anchoMitad = Me.anchoTotal / 2
        Me.altoMitad = Me.altoTotal / 2
        Me.anchoTercio = Me.anchoTotal / 3
        Me.altoTercio = Me.altoTotal / 3
        Me.altoCuarto = Me.altoTotal / 4

    End Sub

    Private Sub OcultarSpreads()

        spCatalogos.Hide()
        spVarios.Hide()
        Application.DoEvents()

    End Sub

    Private Sub FormatearSpread()

        ' Se cargan tipos de datos de spread.
        CargarTiposDeDatos()
        ' Se cargan las opciones generales de cada spread.
        OcultarSpreads()
        pnlCatalogos.Visible = False
        spVarios.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight
        spVarios.ActiveSheet.GrayAreaBackColor = Principal.colorAreaGris
        spVarios.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spCatalogos.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spCatalogos.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spVarios.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spVarios.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always
        spVarios.EditModeReplace = True
        spVarios.Refresh()

    End Sub

    Private Sub EliminarRegistroDeSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        spread.ActiveSheet.Rows.Remove(spread.ActiveSheet.ActiveRowIndex, 1)

    End Sub

    Private Sub ControlarSpreadEnter(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim columnaActiva As Integer = spread.ActiveSheet.ActiveColumnIndex
        If (columnaActiva = spread.ActiveSheet.Columns.Count - 1) Then
            spread.ActiveSheet.Rows.Count += 1
        End If
        Dim fila As Integer = 0
        If (Me.opcionSeleccionada = OpcionMenu.cajasPesoTarimas Or Me.opcionSeleccionada = OpcionMenu.precios) Then
            If (columnaActiva = spVarios.ActiveSheet.Columns("idProducto").Index) Then
                fila = spVarios.ActiveSheet.ActiveRowIndex
                Dim idProducto As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index).Value)
                productos.EId = idProducto
                If (idProducto > 0) Then 
                    Dim datos As New DataTable
                    datos = productos.ObtenerListadoReporte()
                    If (datos.Rows.Count > 0) Then
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombreProducto").Index).Value = datos.Rows(0).Item("Nombre")
                    Else
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index).Value = Nothing
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index + 1).Value = Nothing
                        spVarios.ActiveSheet.SetActiveCell(fila, spVarios.ActiveSheet.Columns("idProducto").Index - 1)
                    End If
                Else
                    spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index).Value = Nothing
                    spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index + 1).Value = Nothing
                    spVarios.ActiveSheet.SetActiveCell(fila, spVarios.ActiveSheet.Columns("idProducto").Index - 1)
                End If
            ElseIf (columnaActiva = spVarios.ActiveSheet.Columns("idEnvase").Index) Then
                fila = spVarios.ActiveSheet.ActiveRowIndex
                Dim idEnvase As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEnvase").Index).Value)
                envases.EId = idEnvase
                If (idEnvase > 0) Then
                    Dim datos As New DataTable
                    datos = envases.ObtenerListado()
                    If (datos.Rows.Count > 0) Then
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombreEnvase").Index).Value = datos.Rows(0).Item("Nombre")
                    Else
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEnvase").Index).Value = Nothing
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEnvase").Index + 1).Value = Nothing
                        spVarios.ActiveSheet.SetActiveCell(fila, spVarios.ActiveSheet.Columns("idEnvase").Index - 1)
                    End If
                Else
                    spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEnvase").Index).Value = Nothing
                    spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEnvase").Index + 1).Value = Nothing
                    spVarios.ActiveSheet.SetActiveCell(fila, spVarios.ActiveSheet.Columns("idEnvase").Index - 1)
                End If
            End If
            If (Me.opcionSeleccionada = OpcionMenu.precios) Then
                If (columnaActiva = spVarios.ActiveSheet.Columns("idTamano").Index) Then
                    fila = spVarios.ActiveSheet.ActiveRowIndex
                    Dim idTamano As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idTamano").Index).Value)
                    tamanos.EId = idTamano
                    If (idTamano > 0) Then
                        Dim datos As New DataTable
                        datos = tamanos.ObtenerListado()
                        If (datos.Rows.Count > 0) Then
                            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombreTamano").Index).Value = datos.Rows(0).Item("Nombre")
                        Else
                            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idTamano").Index).Value = Nothing
                            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idTamano").Index + 1).Value = Nothing
                            spVarios.ActiveSheet.SetActiveCell(fila, spVarios.ActiveSheet.Columns("idTamano").Index - 1)
                        End If
                    Else
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idTamano").Index).Value = Nothing
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idTamano").Index + 1).Value = Nothing
                        spVarios.ActiveSheet.SetActiveCell(fila, spVarios.ActiveSheet.Columns("idTamano").Index - 1)
                    End If
                ElseIf (columnaActiva = spVarios.ActiveSheet.Columns("idEtiqueta").Index) Then
                    fila = spVarios.ActiveSheet.ActiveRowIndex
                    Dim idEtiqueta As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEtiqueta").Index).Value)
                    etiquetas.EId = idEtiqueta
                    If (idEtiqueta > 0) Then
                        Dim datos As New DataTable
                        datos = etiquetas.ObtenerListado()
                        If (datos.Rows.Count > 0) Then
                            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombreEtiqueta").Index).Value = datos.Rows(0).Item("Nombre")
                        Else
                            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEtiqueta").Index).Value = Nothing
                            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEtiqueta").Index + 1).Value = Nothing
                            spVarios.ActiveSheet.SetActiveCell(fila, spVarios.ActiveSheet.Columns("idEtiqueta").Index - 1)
                        End If
                    Else
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEtiqueta").Index).Value = Nothing
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEtiqueta").Index + 1).Value = Nothing
                        spVarios.ActiveSheet.SetActiveCell(fila, spVarios.ActiveSheet.Columns("idEtiqueta").Index - 1)
                    End If 
                End If
            End If
        End If

    End Sub

    Private Sub LimpiarFilaSpread(ByVal spread As FarPoint.Win.Spread.FpSpread, ByVal fila As Integer)

        spread.ActiveSheet.ClearRange(fila, 0, 1, spread.ActiveSheet.Columns.Count, True)
        spread.ActiveSheet.SetActiveCell(fila, -1)
        spread.Refresh()

    End Sub

    Private Sub LimpiarSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        spread.ActiveSheet.ClearRange(0, 0, spread.ActiveSheet.Rows.Count, spread.ActiveSheet.Columns.Count, True)
        spread.Refresh()

    End Sub

    Private Sub CargarCatalogoProductos()

        productos.EId = 0
        spCatalogos.ActiveSheet.DataSource = productos.ObtenerListadoReporteCatalogo()
        FormatearSpreadCatalogo(OpcionPosicion.derecha) 

    End Sub

    Private Sub CargarCatalogoEnvases()

        envases.EId = 0
        spCatalogos.ActiveSheet.DataSource = envases.ObtenerListadoReporteCatalogo()
        FormatearSpreadCatalogo(OpcionPosicion.derecha) 

    End Sub

    Private Sub CargarCatalogoTamanos()

        Dim idProducto As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idProducto").Index).Text)
        If (idProducto > 0) Then
            tamanos.EIdProducto = idProducto
            tamanos.EId = 0
            Dim datos As New DataTable
            datos = tamanos.ObtenerListadoReporteCatalogo()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                spVarios.Enabled = True
            End If
        Else
            spCatalogos.ActiveSheet.DataSource = Nothing
            spCatalogos.ActiveSheet.Rows.Count = 0
            spVarios.Enabled = True
        End If
        FormatearSpreadCatalogo(OpcionPosicion.izquierda)

    End Sub

    Private Sub CargarCatalogoEtiquetas()

        etiquetas.EId = 0
        spCatalogos.ActiveSheet.DataSource = etiquetas.ObtenerListadoReporteCatalogo()
        FormatearSpreadCatalogo(OpcionPosicion.izquierda) 

    End Sub

    Private Sub FormatearSpreadCatalogo(ByVal posicion As Integer)

        spCatalogos.Width = 500
        spCatalogos.Height = Me.altoTotal
        If (posicion = OpcionPosicion.izquierda) Then ' Izquierda.
            pnlCatalogos.Location = New Point(Me.izquierda, Me.arriba)
        ElseIf (posicion = OpcionPosicion.centro) Then ' Centrar.
            pnlCatalogos.Location = New Point(Me.anchoMitad - (spCatalogos.Width / 2), Me.arriba)
        ElseIf (posicion = OpcionPosicion.derecha) Then ' Derecha.
            pnlCatalogos.Location = New Point(Me.anchoTotal - spCatalogos.Width, Me.arriba)
        End If
        spCatalogos.Visible = True
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spCatalogos.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Dim numeracion As Integer = 0
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos.ActiveSheet.Columns("id").Width = 70
        spCatalogos.ActiveSheet.Columns("nombre").Width = 370
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        pnlCatalogos.Height = spCatalogos.Height
        pnlCatalogos.Width = spCatalogos.Width
        spCatalogos.Height = pnlCatalogos.Height - txtBuscarCatalogo.Height - 5
        spCatalogos.Width = pnlCatalogos.Width
        spCatalogos.ActiveSheet.Columns(0, spCatalogos.ActiveSheet.Columns.Count - 1).AllowAutoFilter = True
        spCatalogos.ActiveSheet.Columns(0, spCatalogos.ActiveSheet.Columns.Count - 1).AllowAutoSort = True
        pnlCatalogos.BringToFront()
        pnlCatalogos.Visible = True
        spCatalogos.Refresh()

    End Sub

    Private Sub VolverFocoDeCatalogos()

        pnlMenu.Enabled = True
        spVarios.Enabled = True
        If (Me.opcionSeleccionada = OpcionMenu.cajasPesoTarimas Or Me.opcionSeleccionada = OpcionMenu.precios) Then
            spVarios.Enabled = True
            pnlMenu.Enabled = True
            AsignarFoco(spVarios)
            If (Me.opcionSeleccionadaSubMenu = OpcionSubMenu.producto) Then
                spVarios.ActiveSheet.SetActiveCell(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idProducto").Index + 2)
            ElseIf (Me.opcionSeleccionadaSubMenu = OpcionSubMenu.envase) Then
                spVarios.ActiveSheet.SetActiveCell(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idEnvase").Index + 2)
            ElseIf (Me.opcionSeleccionadaSubMenu = OpcionSubMenu.tamano) Then
                spVarios.ActiveSheet.SetActiveCell(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idTamano").Index + 2)
            ElseIf (Me.opcionSeleccionadaSubMenu = OpcionSubMenu.etiqueta) Then
                spVarios.ActiveSheet.SetActiveCell(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idEtiqueta").Index + 2)
            End If
        End If
        txtBuscarCatalogo.Clear()
        pnlCatalogos.Visible = False

    End Sub

    Private Sub CargarDatosEnSpreadDeCatalogos(ByVal fila As Integer)

        If (Me.opcionSeleccionada = OpcionMenu.cajasPesoTarimas Or Me.opcionSeleccionada = OpcionMenu.precios) Then
            If (Me.opcionSeleccionadaSubMenu = OpcionSubMenu.producto) Then
                spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idProducto").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text
                spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("nombreProducto").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
            ElseIf (Me.opcionSeleccionadaSubMenu = OpcionSubMenu.envase) Then
                spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idEnvase").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text
                spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("nombreEnvase").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
            End If
            If (Me.opcionSeleccionada = OpcionMenu.precios) Then
                If (Me.opcionSeleccionadaSubMenu = OpcionSubMenu.tamano) Then
                    spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idTamano").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text
                    spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("nombreTamano").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
                ElseIf (Me.opcionSeleccionadaSubMenu = OpcionSubMenu.etiqueta) Then
                    spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idEtiqueta").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text
                    spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("nombreEtiqueta").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
                End If
            End If
        End If

    End Sub

    Private Sub SeleccionoCajasPesoTarimas()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.cajasPesoTarimas
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarCajasPesoTarimas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarCajasPesoTarimas()

        AcomodarSpread()
        spVarios.ActiveSheet.DataSource = cajasPesoTarimas.ObtenerListadoReporte()
        FormatearSpreadCajasPesoTarimas()
        AsignarFoco(spVarios)

    End Sub

    Private Sub FormatearSpreadCajasPesoTarimas()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "idEnvase" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombreEnvase" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "pesoUnitarioCajas" : numeracion += 1
        spVarios.ActiveSheet.Columns("idProducto").Width = 50
        spVarios.ActiveSheet.Columns("nombreProducto").Width = 250
        spVarios.ActiveSheet.Columns("idEnvase").Width = 50
        spVarios.ActiveSheet.Columns("nombreEnvase").Width = 250
        spVarios.ActiveSheet.Columns("cantidadCajas").Width = 120
        spVarios.ActiveSheet.Columns("pesoUnitarioCajas").Width = 120
        spVarios.ActiveSheet.Columns("idProducto").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombreProducto").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("idEnvase").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombreEnvase").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("cantidadCajas").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("pesoUnitarioCajas").CellType = tipoDoble
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        Dim obligatorio As String = String.Empty
        obligatorio = " *"
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "Cajas y Peso Por Tarimas".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("idProducto").Index).Value = "No.".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre Producto".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("idEnvase").Index).Value = "No.".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombreEnvase").Index).Value = "Nombre Envase".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("cantidadCajas").Index).Value = "Cantidad de Cajas".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("pesoUnitarioCajas").Index).Value = "Peso por Caja Libras".ToUpper() & obligatorio
        spVarios.ActiveSheet.Rows.Count += 1
        spVarios.Focus()
        spVarios.Refresh()

    End Sub

    Private Sub GuardarEditarCajasPesoTarimas()

        EliminarCajasPesoTarimas(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim idProducto As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index).Text)
            Dim idEnvase As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEnvase").Index).Text)
            Dim cantidadCajas As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("cantidadCajas").Index).Value)
            Dim pesoUnitarioCajas As Double = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("pesoUnitarioCajas").Index).Value)
            If (idProducto > 0 AndAlso idEnvase > 0 AndAlso cantidadCajas > 0 AndAlso pesoUnitarioCajas > 0) Then
                cajasPesoTarimas.EIdProducto = idProducto
                cajasPesoTarimas.EIdEnvase = idEnvase
                cajasPesoTarimas.ECantidadCajas = cantidadCajas
                cajasPesoTarimas.EPesoUnitarioCajas = pesoUnitarioCajas
                cajasPesoTarimas.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarCajasPesoTarimas()

    End Sub

    Private Sub EliminarCajasPesoTarimas(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            cajasPesoTarimas.EIdProducto = 0
            cajasPesoTarimas.EIdEnvase = 0
            cajasPesoTarimas.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            CargarCajasPesoTarimas()
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        End If

    End Sub
         
    Private Sub SeleccionoPrecios()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.precios
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarPrecios()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarPrecios()

        AcomodarSpread()
        precios.EIdProducto = 0
        spVarios.ActiveSheet.DataSource = precios.ObtenerListadoReporte()
        FormatearSpreadPrecios()
        AsignarFoco(spVarios)

    End Sub

    Private Sub FormatearSpreadPrecios()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "idEnvase" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombreEnvase" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "idTamano" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombreTamano" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "idEtiqueta" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombreEtiqueta" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "precio" : numeracion += 1
        spVarios.ActiveSheet.Columns("idProducto").Width = 50
        spVarios.ActiveSheet.Columns("nombreProducto").Width = 250
        spVarios.ActiveSheet.Columns("idEnvase").Width = 50
        spVarios.ActiveSheet.Columns("nombreEnvase").Width = 250
        spVarios.ActiveSheet.Columns("idTamano").Width = 50
        spVarios.ActiveSheet.Columns("nombreTamano").Width = 250
        spVarios.ActiveSheet.Columns("idEtiqueta").Width = 50
        spVarios.ActiveSheet.Columns("nombreEtiqueta").Width = 250
        spVarios.ActiveSheet.Columns("precio").Width = 100
        spVarios.ActiveSheet.Columns("idProducto").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombreProducto").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("idEnvase").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombreEnvase").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("idTamano").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombreTamano").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("idEtiqueta").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombreEtiqueta").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("precio").CellType = tipoDoble
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "P  r  e  c  i  o  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("idProducto").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre Producto *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("idEnvase").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombreEnvase").Index).Value = "Nombre Envase *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("idTamano").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombreTamano").Index).Value = "Nombre Tamaño *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("idEtiqueta").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombreEtiqueta").Index).Value = "Nombre Etiqueta *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("precio").Index).Value = "Precio *".ToUpper()
        spVarios.ActiveSheet.Rows.Count += 1
        spVarios.Focus()
        spVarios.Refresh()

    End Sub

    Private Sub GuardarEditarPrecios()

        EliminarPrecios(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim idProducto As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index).Text)
            Dim idEnvase As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEnvase").Index).Text)
            Dim idTamano As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idTamano").Index).Text)
            Dim idEtiqueta As Integer = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idEtiqueta").Index).Text)
            Dim precio As Double = EYELogicaConfiguraciones.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("precio").Index).Text)
            If (idProducto > 0 AndAlso idEnvase > 0 AndAlso idTamano > 0 AndAlso idEtiqueta > 0) Then
                precios.EIdProducto = idProducto
                precios.EIdEnvase = idEnvase
                precios.EIdTamano = idTamano
                precios.EIdEtiqueta = idEtiqueta
                precios.EPrecio = precio
                precios.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarPrecios()

    End Sub

    Private Sub EliminarPrecios(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            precios.EIdProducto = 0
            precios.EIdEnvase = 0
            precios.EIdTamano = 0
            precios.EIdEtiqueta = 0
            precios.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarPrecios()
        End If

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Enum OpcionPosicion

        izquierda = 1
        centro = 2
        derecha = 3

    End Enum

    Public Enum OpcionMenu

        cajasPesoTarimas = 1
        precios = 2

    End Enum

    Public Enum OpcionSubMenu

        producto = 1
        envase = 2
        tamano = 3
        etiqueta = 4

    End Enum

#End Region

End Class