Imports System.IO
Imports System.ComponentModel

Public Class Principal

    ' Variables de objetos de entidades.
    Public usuarios As New EntidadesRecepcion.Usuarios()
    Public recepcion As New EntidadesRecepcion.Recepcion()
    Public almacenes As New EntidadesRecepcion.Almacenes()
    Public familias As New EntidadesRecepcion.Familias()
    Public variedades As New EntidadesRecepcion.Variedades()
    Public articulos As New EntidadesRecepcion.Articulos()
    Public unidadesMedidas As New EntidadesRecepcion.UnidadesMedidas()
    Public choferesCampos As New EntidadesRecepcion.ChoferesCampos()
    Public lotes As New EntidadesRecepcion.Lotes()
    Public productos As New EntidadesRecepcion.Productos()
    Public tiposSalidas As New EntidadesRecepcion.TiposSalidas()
    ' Variables de tipos de datos de spread.
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoTextoContrasena As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoBooleano As New FarPoint.Win.Spread.CellType.CheckBoxCellType()
    Public tipoMoneda As New FarPoint.Win.Spread.CellType.CurrencyCellType()
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
    ' Variables de eventos de spread.
    Public filaAlmacen As Integer = -1 : Public filaFamilia As Integer = -1 : Public filaSubFamilia As Integer = -1
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public estaMostrado As Boolean = False : Public estaCerrando As Boolean = False
    Public ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public prefijoBaseDatosEmpaque As String = "EYE" & "_"
    Public cantidadFilas As Integer = 1
    Public opcionCatalogoSeleccionada As Integer = 0
    Public esGuardadoValido As Boolean = True
    ' Variable de desarrollo.
    Public esDesarrollo As Boolean = False

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Centrar()
        CargarNombrePrograma()
        AsignarTooltips()
        ConfigurarConexiones()
        CargarMedidas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        'If (Not ValidarAccesoTotal()) Then
        '    Salir()
        'End If
        CargarEncabezados()
        CargarTitulosDirectorio()
        FormatearSpread()
        FormatearSpreadRecepcion()
        FormatearSpreadTotales()
        CargarLotes()
        CargarChoferesCampo()
        CargarProductos() 
        Me.Enabled = True
        CargarIdConsecutivo()
        Me.estaMostrado = True
        AsignarFoco(txtId)
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
        Desvanecer()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Salir()

    End Sub

    Private Sub spEntradas_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spRecepcion.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter(spRecepcion)
        End If

    End Sub

    Private Sub spEntradas_KeyDown(sender As Object, e As KeyEventArgs) Handles spRecepcion.KeyDown

        If (e.KeyData = Keys.F6) Then ' Eliminar un registro.
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                EliminarRegistroDeSpread(spRecepcion)
            End If
        ElseIf (e.KeyData = Keys.Enter) Then ' Validar registros.
            ControlarSpreadEnter(spRecepcion)
        ElseIf (e.KeyData = Keys.F5) Then ' Abrir catalogos. 
            CargarCatalogoEnSpread()
        ElseIf (e.KeyData = Keys.Escape) Then
            spRecepcion.ActiveSheet.SetActiveCell(0, 0)
            AsignarFoco(cbVariedades)
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        ValidarGuardado()
        If (Me.esGuardadoValido) Then
            GuardarEditarRecepcion()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        EliminarRecepcion(True)

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
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.choferesCampos) Then
            CargarDatosEnOtrosDeCatalogos(fila)
        Else
            CargarDatosEnSpreadDeCatalogos(fila)
        End If

    End Sub

    Private Sub spCatalogos_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos.CellDoubleClick

        VolverFocoCatalogos()

    End Sub

    Private Sub spCatalogos_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            VolverFocoCatalogos()
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

    Private Sub txtId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtId.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (IsNumeric(txtId.Text)) Then
                e.SuppressKeyPress = True
                CargarRecepcion()
            Else
                txtId.Clear()
                LimpiarPantalla()
            End If
        End If

    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFecha.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtHora)
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtId)
        End If

    End Sub

    Private Sub cbLotes_KeyDown(sender As Object, e As KeyEventArgs) Handles cbLotes.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbLotes.SelectedValue > 0) Then
                AsignarFoco(cbChoferesCampos)
            Else
                cbLotes.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtHora)
        End If

    End Sub

    Private Sub cbProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles cbProductos.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbProductos.SelectedValue > 0) Then
                AsignarFoco(cbVariedades)
            Else
                cbProductos.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbChoferesCampos)
        End If

    End Sub

    Private Sub btnIdAnterior_Click(sender As Object, e As EventArgs) Handles btnIdAnterior.Click

        If (LogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text) > 1) Then
            txtId.Text -= 1
            CargarRecepcion()
        End If

    End Sub

    Private Sub btnIdSiguiente_Click(sender As Object, e As EventArgs) Handles btnIdSiguiente.Click

        If (LogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text) >= 1) Then
            txtId.Text += 1
            CargarRecepcion()
        End If

    End Sub

#End Region

#Region "Métodos"

#Region "Básicos"

    Private Sub Salir()

        Application.Exit()

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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Teclas básicas: " & vbNewLine & "F5 sirve para mostrar catálogos. " & vbNewLine & "F6 sirve para eliminar un registro únicamente. " & vbNewLine & "Escape sirve para ocultar catálogos que se encuentren desplegados. " & vbNewLine & vbNewLine & "* Catálogos desplegados: " & vbNewLine & "Cuando se muestra algún catálogo, al seleccionar alguna opción de este, se va mostrando en tiempo real en la captura de donde se originó. Cuando se le da doble clic en alguna opción o a la tecla escape se oculta dicho catálogo. " & vbNewLine & vbNewLine & "* Datos obligatorios: " & vbNewLine & "Todos los que tengan el simbolo * son estrictamente obligatorios." & vbNewLine & vbNewLine & "* Captura:" & vbNewLine & "* Parte superior: " & vbNewLine & "En esta parte se capturarán todos los datos que son generales, tal cual como el número de la entrada, el almacén al que corresponde, etc." & vbNewLine & "* Parte inferior: " & vbNewLine & "En esta parte se capturarán todos los datos que pueden combinarse, por ejemplo los distintos artículos de ese número de entrada." & vbNewLine & vbNewLine & "* Existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. " : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlCuerpo.Visible = True : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
        End If

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

        If ((Not LogicaRecepcion.Usuarios.accesoTotal) Or (LogicaRecepcion.Usuarios.accesoTotal = 0) Or (LogicaRecepcion.Usuarios.accesoTotal = False)) Then
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
        tp.SetToolTip(Me.pnlEncabezado, "Datos Principales.")
        tp.SetToolTip(Me.btnAyuda, "Ayuda.")
        tp.SetToolTip(Me.btnSalir, "Salir.")
        tp.SetToolTip(Me.btnGuardar, "Guardar.")
        tp.SetToolTip(Me.btnEliminar, "Eliminar.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            LogicaRecepcion.Directorios.id = 1
            LogicaRecepcion.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            LogicaRecepcion.Directorios.usuarioSql = "AdminBerry"
            LogicaRecepcion.Directorios.contrasenaSql = "@berry2017" 
        Else
            LogicaRecepcion.Directorios.ObtenerParametros()
            LogicaRecepcion.Usuarios.ObtenerParametros()
        End If
        LogicaRecepcion.Programas.bdCatalogo = "Catalogo" & LogicaRecepcion.Directorios.id
        LogicaRecepcion.Programas.bdConfiguracion = "Configuracion" & LogicaRecepcion.Directorios.id
        LogicaRecepcion.Programas.bdEmpaque = "Empaque" & LogicaRecepcion.Directorios.id
        EntidadesRecepcion.BaseDatos.ECadenaConexionCatalogo = LogicaRecepcion.Programas.bdCatalogo
        EntidadesRecepcion.BaseDatos.ECadenaConexionConfiguracion = LogicaRecepcion.Programas.bdConfiguracion
        EntidadesRecepcion.BaseDatos.ECadenaConexionEmpaque = LogicaRecepcion.Programas.bdEmpaque
        EntidadesRecepcion.BaseDatos.AbrirConexionCatalogo()
        EntidadesRecepcion.BaseDatos.AbrirConexionConfiguracion()
        EntidadesRecepcion.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        LogicaRecepcion.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EntidadesRecepcion.Usuarios)
        usuarios.EId = LogicaRecepcion.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count = 1) Then
            LogicaRecepcion.Usuarios.id = lista(0).EId
            LogicaRecepcion.Usuarios.nombre = lista(0).ENombre
            LogicaRecepcion.Usuarios.contrasena = lista(0).EContrasena
            LogicaRecepcion.Usuarios.nivel = lista(0).ENivel
            LogicaRecepcion.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarTitulosDirectorio()

        Me.Text = "Programa:  " + Me.nombreEstePrograma + "              Directorio:  " + LogicaRecepcion.Directorios.nombre + "              Usuario:  " + LogicaRecepcion.Usuarios.nombre

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " + LogicaRecepcion.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " + LogicaRecepcion.Usuarios.nombre

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Directory.GetCurrentDirectory()
        ejecutarProgramaPrincipal.Arguments = LogicaRecepcion.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & LogicaRecepcion.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & LogicaRecepcion.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & LogicaRecepcion.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & LogicaRecepcion.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & LogicaRecepcion.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & LogicaRecepcion.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & LogicaRecepcion.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & LogicaRecepcion.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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

    Private Sub AsignarFoco(ByVal c As Control)

        c.Focus()

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
        tipoMoneda.MinimumValue = 0
        tipoMoneda.DecimalPlaces = 8
        tipoMoneda.Separator = ","
        tipoMoneda.DecimalSeparator = "."
        tipoMoneda.ShowCurrencySymbol = True
        tipoMoneda.ShowSeparator = True

    End Sub

    Private Sub CargarMedidas()

        Me.izquierda = 0
        Me.arriba = spRecepcion.Top
        Me.anchoTotal = pnlCuerpo.Width
        Me.altoTotal = pnlCuerpo.Height
        Me.anchoMitad = Me.anchoTotal / 2
        Me.altoMitad = Me.altoTotal / 2
        Me.anchoTercio = Me.anchoTotal / 3
        Me.altoTercio = Me.altoTotal / 3
        Me.altoCuarto = Me.altoTotal / 4

    End Sub

#End Region

#Region "Todos los demás"

    Private Sub LimpiarPantalla()

        For Each c As Control In pnlCapturaSuperior.Controls
            c.BackColor = Color.White
        Next
        For fila = 0 To spRecepcion.ActiveSheet.Rows.Count - 1
            For columna = 0 To spRecepcion.ActiveSheet.Columns.Count - 1
                spRecepcion.ActiveSheet.Cells(fila, columna).BackColor = Color.White
            Next
        Next
        If (Not chkConservarDatos.Checked) Then
            cbLotes.SelectedIndex = 0
            cbChoferesCampos.SelectedIndex = 0
            cbProductos.SelectedIndex = 0
            cbVariedades.SelectedIndex = 0
            dtpFecha.Value = Today
        End If
        spRecepcion.ActiveSheet.DataSource = Nothing
        spRecepcion.ActiveSheet.Rows.Count = 1
        spRecepcion.ActiveSheet.SetActiveCell(0, 0)
        LimpiarSpread(spRecepcion)
        LimpiarSpread(spTotales)

    End Sub

    Private Sub LimpiarSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        spread.ActiveSheet.ClearRange(0, 0, spread.ActiveSheet.Rows.Count, spread.ActiveSheet.Columns.Count, True)

    End Sub

    Private Sub CargarLotes()

        cbLotes.DataSource = lotes.ObtenerListadoReporte()
        cbLotes.DisplayMember = "Nombre"
        cbLotes.ValueMember = "Id"

    End Sub

    Private Sub CargarChoferesCampo()

        cbChoferesCampos.DataSource = choferesCampos.ObtenerListadoReporte()
        cbChoferesCampos.DisplayMember = "Nombre"
        cbChoferesCampos.ValueMember = "Id"

    End Sub

    Private Sub CargarProductos()

        cbProductos.DataSource = productos.ObtenerListadoReporte()
        cbProductos.DisplayMember = "Nombre"
        cbProductos.ValueMember = "Id"

    End Sub

    Private Sub CargarVariedades()

        If (Me.estaMostrado) Then
            If (cbProductos.Items.Count > 0) Then
                If (cbProductos.SelectedValue > 0) Then
                    variedades.EIdProducto = cbProductos.SelectedValue
                    cbVariedades.DataSource = variedades.ObtenerListadoReporte()
                    cbVariedades.DisplayMember = "Nombre"
                    cbVariedades.ValueMember = "Id"
                End If
            End If
        End If

    End Sub

    Private Sub FormatearSpread()

        ' Se cargan tipos de datos de spread.
        CargarTiposDeDatos()
        ' Se cargan las opciones generales. 
        pnlCatalogos.Visible = False
        spRecepcion.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spTotales.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight
        spRecepcion.ActiveSheet.GrayAreaBackColor = Principal.colorAreaGris
        spTotales.ActiveSheet.GrayAreaBackColor = Principal.colorAreaGris
        spRecepcion.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spTotales.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spCatalogos.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spRecepcion.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spTotales.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spRecepcion.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spTotales.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spCatalogos.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spRecepcion.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spRecepcion.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spTotales.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spTotales.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        'spEntradas.EditModePermanent = True
        spRecepcion.EditModeReplace = True
        spTotales.Enabled = False
        Application.DoEvents()

    End Sub

    Private Sub EliminarRegistroDeSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        If (spread.ActiveSheet.ActiveRowIndex > 0) Then
            spread.ActiveSheet.Rows.Remove(spread.ActiveSheet.ActiveRowIndex, 1)
        Else
            spread.ActiveSheet.ClearRange(spread.ActiveSheet.ActiveRowIndex, 0, 1, spread.ActiveSheet.Columns.Count, False)
            spread.ActiveSheet.SetActiveCell(spread.ActiveSheet.ActiveRowIndex, 0)
        End If

    End Sub

    Private Sub ControlarSpreadEnter(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim columnaActiva As Integer = spread.ActiveSheet.ActiveColumnIndex
        If (columnaActiva = spread.ActiveSheet.Columns.Count - 1) Then
            spread.ActiveSheet.Rows.Count += 1
        End If
        If (spread.Name = spRecepcion.Name) Then
            Dim fila As Integer = 0
            If (columnaActiva = spRecepcion.ActiveSheet.Columns("cantidadCajas").Index) Then
                fila = spRecepcion.ActiveSheet.ActiveRowIndex
                Dim cantidadCajas As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Value)
                If (cantidadCajas > 0) Then
                    Dim lista As New List(Of EntidadesRecepcion.Lotes)
                    Dim idLote As Integer = cbLotes.SelectedValue
                    lotes.EId = idLote
                    lista = lotes.ObtenerListado()
                    If (lista.Count = 1) Then
                        Dim pesoCaja As Double = lista(0).EPesoCaja
                        spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Value = cantidadCajas * pesoCaja
                    End If
                Else
                    spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Value = String.Empty
                    spRecepcion.ActiveSheet.SetActiveCell(fila, spRecepcion.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spRecepcion.ActiveSheet.Columns("pesoCajas").Index) Then
                fila = spRecepcion.ActiveSheet.ActiveRowIndex
                Dim pesoCajas As Double = LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Value)
                If (pesoCajas <= 0) Then
                    spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Value = String.Empty
                    spRecepcion.ActiveSheet.SetActiveCell(fila, spRecepcion.ActiveSheet.ActiveColumnIndex - 1)
                End If
            End If
            CalcularTotales()
        End If

    End Sub

    Private Sub CalcularTotales()

        Dim total As Double = 0
        For columna = 0 To spRecepcion.ActiveSheet.Columns.Count - 1
            For fila = 0 To spRecepcion.ActiveSheet.Rows.Count - 1
                total += LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, columna).Text)
            Next
            spTotales.ActiveSheet.Cells(0, columna).Text = total
            total = 0
        Next
        'spTotales.ActiveSheet.Cells(0, spTotales.ActiveSheet.Columns("total").Index).Text = "Total".ToUpper
        spTotales.ActiveSheet.Cells(0, 0, 0, spTotales.ActiveSheet.Columns.Count - 1).BackColor = Color.Gainsboro

    End Sub

    Private Sub CargarIdConsecutivo()

        Dim idMaximo As Integer = recepcion.ObtenerMaximoId()
        txtId.Text = idMaximo

    End Sub

    Private Sub CargarDatosEnSpreadDeCatalogos(ByVal filaCatalogos As Integer)

        If (spRecepcion.ActiveSheet.ActiveColumnIndex = spRecepcion.ActiveSheet.Columns("idFamilia").Index Or spRecepcion.ActiveSheet.ActiveColumnIndex = spRecepcion.ActiveSheet.Columns("nombreFamilia").Index) Then
            spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("idFamilia").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("nombreFamilia").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
        ElseIf (spRecepcion.ActiveSheet.ActiveColumnIndex = spRecepcion.ActiveSheet.Columns("idSubFamilia").Index Or spRecepcion.ActiveSheet.ActiveColumnIndex = spRecepcion.ActiveSheet.Columns("nombreSubFamilia").Index) Then
            spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("idSubFamilia").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("nombreSubFamilia").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
        ElseIf (spRecepcion.ActiveSheet.ActiveColumnIndex = spRecepcion.ActiveSheet.Columns("idArticulo").Index Or spRecepcion.ActiveSheet.ActiveColumnIndex = spRecepcion.ActiveSheet.Columns("nombreArticulo").Index) Then
            spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("idArticulo").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("nombreArticulo").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
            spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("nombreUnidadMedida").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("unidadMedida").Index).Text
        End If

    End Sub

    Private Sub CargarDatosEnOtrosDeCatalogos(ByVal filaCatalogos As Integer)

        'If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.proveedor) Then
        '    txtIdProveedor.Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
        '    txtNombreProveedor.Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
        'End If

    End Sub

    Private Sub CargarCatalogoEnSpread()

        spRecepcion.Enabled = False
        Dim columna As Integer = spRecepcion.ActiveSheet.ActiveColumnIndex
        If (columna = spRecepcion.ActiveSheet.Columns("idFamilia").Index) Or (columna = spRecepcion.ActiveSheet.Columns("nombreFamilia").Index) Then
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.familia
            familias.EId = 0
            Dim datos As New DataTable
            datos = familias.ObtenerListadoReporte()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                spRecepcion.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.centro)
        ElseIf (columna = spRecepcion.ActiveSheet.Columns("idSubFamilia").Index) Or (columna = spRecepcion.ActiveSheet.Columns("nombreSubFamilia").Index) Then
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.subfamilia
            Dim idFamilia As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("idFamilia").Index).Text)
            If (idFamilia > 0) Then
                variedades.EIdProducto = idFamilia
                variedades.EId = 0
                Dim datos As New DataTable
                datos = variedades.ObtenerListadoReporte()
                If (datos.Rows.Count > 0) Then
                    spCatalogos.ActiveSheet.DataSource = datos
                Else
                    spCatalogos.ActiveSheet.DataSource = Nothing
                    spCatalogos.ActiveSheet.Rows.Count = 0
                    spRecepcion.Enabled = True
                End If
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                spRecepcion.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.centro)
        ElseIf (columna = spRecepcion.ActiveSheet.Columns("idArticulo").Index) Or (columna = spRecepcion.ActiveSheet.Columns("nombreArticulo").Index) Then
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.articulo
            Dim idFamilia As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("idFamilia").Index).Text)
            Dim idSubFamilia As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(spRecepcion.ActiveSheet.ActiveRowIndex, spRecepcion.ActiveSheet.Columns("idSubFamilia").Index).Text)
            If (idFamilia > 0 And idSubFamilia > 0) Then
                articulos.EIdFamilia = idFamilia
                articulos.EIdSubFamilia = idSubFamilia
                articulos.EId = 0
                Dim datos As New DataTable
                datos = articulos.ObtenerListadoReporte()
                If (datos.Rows.Count > 0) Then
                    spCatalogos.ActiveSheet.DataSource = datos
                Else
                    spCatalogos.ActiveSheet.DataSource = Nothing
                    spCatalogos.ActiveSheet.Rows.Count = 0
                    spRecepcion.Enabled = True
                End If
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                spRecepcion.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.centro)
        End If

    End Sub

    Private Sub CargarCatalogoEnOtros()

        pnlCapturaSuperior.Enabled = False
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.choferesCampos) Then
            choferesCampos.EId = 0
            Dim datos As New DataTable
            datos = choferesCampos.ObtenerListadoReporte()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                pnlCapturaSuperior.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.centro)
        End If

    End Sub

    Private Sub FormatearSpreadCatalogo(ByVal posicion As Integer)

        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.articulo) Then
            spCatalogos.Width = 450
            spCatalogos.ActiveSheet.Columns.Count = 3
        Else
            spCatalogos.Width = 320
            spCatalogos.ActiveSheet.Columns.Count = 2
        End If
        If (posicion = OpcionPosicion.izquierda) Then ' Izquierda.
            pnlCatalogos.Location = New Point(Me.izquierda, Me.arriba)
        ElseIf (posicion = OpcionPosicion.centro) Then ' Centrar.
            pnlCatalogos.Location = New Point(Me.anchoMitad - (spCatalogos.Width / 2), Me.arriba)
        ElseIf (posicion = OpcionPosicion.derecha) Then ' Derecha.
            pnlCatalogos.Location = New Point(Me.anchoTotal - spCatalogos.Width, Me.arriba)
        End If
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCatalogos.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Dim numeracion As Integer = 0
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.articulo) Then
            spCatalogos.ActiveSheet.Columns(numeracion).Tag = "unidadMedida" : numeracion += 1
        End If
        spCatalogos.ActiveSheet.Columns("id").Width = 50
        spCatalogos.ActiveSheet.Columns("nombre").Width = 235
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.articulo) Then
            spCatalogos.ActiveSheet.Columns("unidadMedida").Width = 130
        End If
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.articulo) Then
            spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("unidadMedida").Index).Value = "Unidad".ToUpper
        End If
        pnlCatalogos.Height = spRecepcion.Height
        pnlCatalogos.Size = spCatalogos.Size
        pnlCatalogos.BringToFront()
        pnlCatalogos.Visible = True
        AsignarFoco(pnlCatalogos)
        AsignarFoco(spCatalogos)
        Application.DoEvents()

    End Sub

    Private Sub VolverFocoCatalogos()

        'If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.proveedor) Then
        '    pnlCapturaSuperior.Enabled = True
        '    AsignarFoco(txtIdProveedor)
        'Else
        spRecepcion.Enabled = True
        AsignarFoco(spRecepcion)
        'End If
        pnlCatalogos.Visible = False

    End Sub

    Private Sub CargarRecepcion()

        Me.Cursor = Cursors.WaitCursor
        recepcion.EId = LogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text)
        If (recepcion.EId > 0) Then
            Dim lista As New List(Of EntidadesRecepcion.Recepcion)
            lista = recepcion.ObtenerListado()
            If (lista.Count > 0) Then
                dtpFecha.Value = lista(0).EFecha
                txtHora.Text = lista(0).EHora
                cbLotes.SelectedValue = lista(0).EIdLote
                cbChoferesCampos.SelectedValue = lista(0).EIdChofer
                cbProductos.SelectedValue = lista(0).EIdProducto
                cbVariedades.SelectedValue = lista(0).EIdVariedad
                spRecepcion.ActiveSheet.DataSource = recepcion.ObtenerListadoReporte()
                cantidadFilas = spRecepcion.ActiveSheet.Rows.Count + 1
                FormatearSpreadRecepcion()
            Else
                LimpiarPantalla()
            End If
        End If
        CalcularTotales()
        AsignarFoco(dtpFecha)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FormatearSpreadRecepcion()

        spRecepcion.ActiveSheet.ColumnHeader.Rows(0, spRecepcion.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spRecepcion.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spRecepcion.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        spRecepcion.ActiveSheet.Rows.Count = cantidadFilas
        ControlarSpreadEnterASiguienteColumna(spRecepcion)
        Dim numeracion As Integer = 0
        spRecepcion.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spRecepcion.ActiveSheet.Columns(numeracion).Tag = "pesoCajas" : numeracion += 1
        spRecepcion.ActiveSheet.Columns.Count = numeracion
        spRecepcion.ActiveSheet.Columns("cantidadCajas").Width = 220
        spRecepcion.ActiveSheet.Columns("pesoCajas").Width = 220
        spRecepcion.ActiveSheet.Columns("cantidadCajas").CellType = tipoEntero
        spRecepcion.ActiveSheet.Columns("pesoCajas").CellType = tipoDoble
        spRecepcion.ActiveSheet.ColumnHeader.Cells(0, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Value = "Cantidad de Cajas *".ToUpper()
        spRecepcion.ActiveSheet.ColumnHeader.Cells(0, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Value = "Peso de Cajas *".ToUpper()
        Application.DoEvents()

    End Sub

    Private Sub FormatearSpreadTotales()

        spTotales.ActiveSheet.Columns.Count = 2
        Dim numeracion As Integer = 0
        spTotales.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "pesoCajas" : numeracion += 1
        'spTotales.ActiveSheet.Columns(numeracion).Tag = "total" : numeracion += 1
        spTotales.ActiveSheet.Columns.Count = numeracion
        spTotales.ActiveSheet.Columns("cantidadCajas").Width = 220
        spTotales.ActiveSheet.Columns("pesoCajas").Width = 220
        'spTotales.ActiveSheet.Columns("total").Width = 220
        spTotales.ActiveSheet.Columns("cantidadCajas").CellType = tipoEntero
        spTotales.ActiveSheet.Columns("pesoCajas").CellType = tipoDoble
        'spTotales.ActiveSheet.Columns("total").CellType = tipoTexto
        spTotales.ActiveSheet.ColumnHeader.Visible = False
        Application.DoEvents()

    End Sub

    Private Sub ValidarGuardado()

        Me.Cursor = Cursors.WaitCursor
        Me.esGuardadoValido = True
        ' Parte superior. 
        Dim id As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text)
        If (id <= 0) Then
            txtId.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim hora As String = txtHora.Text
        If (String.IsNullOrEmpty(hora) Or hora.Length <> 5) Then
            txtHora.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idLote As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(cbLotes.SelectedValue)
        If (idLote <= 0) Then
            cbLotes.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idChofer As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(cbChoferesCampos.SelectedValue)
        If (idChofer <= 0) Then
            cbChoferesCampos.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idProducto As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(cbProductos.SelectedValue)
        If (idProducto <= 0) Then
            cbProductos.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idVariedad As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(cbVariedades.SelectedValue)
        If (idVariedad <= 0) Then
            cbVariedades.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        ' Parte inferior.
        For fila As Integer = 0 To spRecepcion.ActiveSheet.Rows.Count - 1
            Dim cantidadCajas As String = spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Text
            Dim cantidadCajas2 As Double = LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Text)
            If (Not String.IsNullOrEmpty(cantidadCajas) Or cantidadCajas2 > 0) Then
                Dim pesoCajas As String = spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Text
                Dim pesoCajas2 As Double = LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Text)
                If (String.IsNullOrEmpty(pesoCajas) Or pesoCajas2 < 0) Then
                    spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
            End If
        Next
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GuardarEditarRecepcion()

        Me.Cursor = Cursors.WaitCursor
        EliminarRecepcion(False)
        ' Parte superior. 
        Dim id As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text)
        Dim fecha As Date = dtpFecha.Value
        Dim hora As String = txtHora.Text
        Dim idLote As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(cbLotes.SelectedValue)
        Dim idChofer As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(cbChoferesCampos.SelectedValue)
        Dim idProducto As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(cbProductos.SelectedValue)
        Dim idVariedad As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(cbVariedades.SelectedValue)
        ' Parte inferior.
        For fila As Integer = 0 To spRecepcion.ActiveSheet.Rows.Count - 1
            Dim cantidadCajas As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Text)
            Dim pesoCajas As Integer = LogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Text)
            If (id > 0 AndAlso IsDate(fecha) AndAlso idLote > 0 AndAlso idChofer > 0 AndAlso idProducto > 0 And idVariedad > 0 AndAlso cantidadCajas > 0 AndAlso pesoCajas > 0) Then
                recepcion.EId = id
                recepcion.EFecha = fecha
                recepcion.EHora = hora
                recepcion.EIdLote = idLote
                recepcion.EIdChofer = idChofer
                recepcion.EIdProducto = idProducto
                recepcion.EIdVariedad = idVariedad
                recepcion.ECantidadCajas = cantidadCajas
                recepcion.EPesoCajas = pesoCajas
                recepcion.EOrden = fila
                recepcion.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        LimpiarPantalla()
        CargarIdConsecutivo()
        AsignarFoco(txtId)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EliminarRecepcion(ByVal conMensaje As Boolean)

        Me.Cursor = Cursors.WaitCursor
        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar esta entrada de recepción?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            recepcion.EId = LogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text)
            recepcion.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            LimpiarPantalla()
            CargarIdConsecutivo()
            AsignarFoco(txtId)
        End If
        Me.Cursor = Cursors.Default

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Enum OpcionPosicion

        izquierda = 1
        centro = 2
        derecha = 3

    End Enum

    Enum OpcionCatalogo

        familia = 1
        subfamilia = 2
        articulo = 3
        choferesCampos = 4

    End Enum

#End Region
     
    Private Sub txtHora_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHora.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (Not String.IsNullOrEmpty(txtHora.Text.Trim.Replace(":", "").Replace("_", ""))) Then
                AsignarFoco(cbLotes)
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(dtpFecha)
        End If

    End Sub

    Private Sub cbChoferesCampos_KeyDown(sender As Object, e As KeyEventArgs) Handles cbChoferesCampos.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbChoferesCampos.SelectedValue > 0) Then
                AsignarFoco(cbProductos)
            Else
                cbChoferesCampos.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbLotes)
        End If

    End Sub

    Private Sub cbVariedades_KeyDown(sender As Object, e As KeyEventArgs) Handles cbVariedades.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbChoferesCampos.SelectedValue > 0) Then
                AsignarFoco(spRecepcion)
            Else
                cbChoferesCampos.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbProductos)
        End If

    End Sub

    Private Sub cbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged

        CargarVariedades()

    End Sub

End Class