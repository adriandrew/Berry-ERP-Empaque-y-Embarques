Imports System.IO
Imports System.ComponentModel
Imports System.Threading

Public Class Principal

    ' Variables de objetos de entidades.
    Public usuarios As New EYEEntidadesVaciado.Usuarios()
    Public vaciado As New EYEEntidadesVaciado.Vaciado()
    Public recepcion As New EYEEntidadesVaciado.Recepcion()
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
    Public estaMostrado As Boolean = False : Public estaCerrando As Boolean = False
    Public ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public prefijoBaseDatosEmpaque As String = "EYE" & "_"
    Public cantidadFilas As Integer = 1
    Public opcionCatalogoSeleccionada As Integer = 0
    Public esGuardadoValido As Boolean = True
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
        FormatearSpreadVaciado()
        Me.estaMostrado = True
        AsignarFoco(dtpFecha)
        CargarEstilos()
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

    Private Sub spVaciado_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spVaciado.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter(spVaciado)
        End If

    End Sub

    Private Sub spVaciado_KeyDown(sender As Object, e As KeyEventArgs) Handles spVaciado.KeyDown

        If (e.KeyData = Keys.F6) Then ' Eliminar un registro.
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                EliminarRegistroDeSpread(spVaciado)
            End If
        ElseIf (e.KeyData = Keys.Enter) Then ' Validar registros.
            ControlarSpreadEnter(spVaciado)
        ElseIf (e.KeyData = Keys.Escape) Then
            spVaciado.ActiveSheet.SetActiveCell(0, 0)
            AsignarFoco(txtHora)
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Me.Cursor = Cursors.WaitCursor
        ValidarGuardadoVaciado()
        If (Me.esGuardadoValido) Then
            GuardarEditarVaciado()
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Me.Cursor = Cursors.WaitCursor
        EliminarVaciado(True)
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

    Private Sub pnlEncabezado_MouseEnter(sender As Object, e As EventArgs) Handles pnlEncabezado.MouseEnter, pnlCuerpo.MouseEnter

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick

        If (Me.estaCerrando) Then
            Desvanecer()
        End If

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click

        Me.Cursor = Cursors.WaitCursor
        MostrarAyuda()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnAyuda_MouseEnter(sender As Object, e As EventArgs) Handles btnAyuda.MouseEnter

        AsignarTooltips("Ayuda.")

    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFecha.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtHora)
        End If

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHora.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (Not String.IsNullOrEmpty(txtHora.Text.Trim.Replace(":", "").Replace("_", "")) And txtHora.Text.Length = 5) Then
                CargarVaciado()
            Else
                LimpiarPantalla()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(dtpFecha)
        End If

    End Sub

    Private Sub btnListados_Click(sender As Object, e As EventArgs) Handles btnListados.Click

        Me.Cursor = Cursors.WaitCursor
        CargarListados()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnListados_MouseEnter(sender As Object, e As EventArgs) Handles btnListados.MouseEnter

        AsignarTooltips("Mostrar u Ocultar Listado.")

    End Sub

    Private Sub spListados_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spListados.CellClick

        Dim fila As Integer = e.Row
        CargarDatosDeListados(fila)

    End Sub

    Private Sub spListados_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spListados.CellDoubleClick

        VolverFocoDeListados()

    End Sub

    Private Sub spListados_KeyDown(sender As Object, e As KeyEventArgs) Handles spListados.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            VolverFocoDeListados()
        End If

    End Sub

    Private Sub pbMarca_MouseEnter(sender As Object, e As EventArgs) Handles pbMarca.MouseEnter

        AsignarTooltips("Producido por Berry.")

    End Sub

    Private Sub pnlCapturaSuperior_MouseEnter(sender As Object, e As EventArgs) Handles pnlCapturaSuperior.MouseEnter

        AsignarTooltips("Capturar Datos Generales.")

    End Sub

    Private Sub spVaciado_MouseEnter(sender As Object, e As EventArgs) Handles spVaciado.MouseEnter

        AsignarTooltips("Capturar Datos Detallados.")

    End Sub

    Private Sub pnlPie_MouseEnter(sender As Object, e As EventArgs) Handles pnlPie.MouseEnter

        AsignarTooltips("Opciones.")

    End Sub

#End Region

#Region "Métodos"

#Region "Básicos"

    Private Sub CargarEstilos()

        pnlCapturaSuperior.BackColor = Principal.colorSpreadAreaGris
        spVaciado.ActiveSheet.GrayAreaBackColor = Principal.colorSpreadAreaGris
        pnlPie.BackColor = Principal.colorSpreadAreaGris

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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Teclas básicas: " & vbNewLine & "F5 sirve para mostrar catálogos. " & vbNewLine & "F6 sirve para eliminar un registro únicamente. " & vbNewLine & "F7 sirve para mostrar listados." & vbNewLine & "Escape sirve para ocultar catálogos o listados que se encuentren desplegados. " & vbNewLine & vbNewLine & "* Catálogos o listados desplegados: " & vbNewLine & "Cuando se muestra algún catálogo o listado, al seleccionar alguna opción de este, se va mostrando en tiempo real en la captura de donde se originó. Cuando se le da doble clic en alguna opción o a la tecla escape se oculta dicho catálogo o listado. " & vbNewLine & vbNewLine & "* Datos obligatorios:" & vbNewLine & "Todos los que tengan el simbolo * son estrictamente obligatorios." & vbNewLine & vbNewLine & "* Captura:" & vbNewLine & "* Parte superior/izquierda: " & vbNewLine & "En esta parte se capturarán todos los datos que son generales, tal cual como la fecha y hora." & vbNewLine & "* Parte inferior/derecha: " & vbNewLine & "En esta parte se capturarán todas las descargas o vaciados del producto por cada número de recepción, las distintas bandas y su cantidad de cajas." & vbNewLine & vbNewLine & "* Existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. "
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

        If ((Not EYELogicaVaciado.Usuarios.accesoTotal) Or (EYELogicaVaciado.Usuarios.accesoTotal = 0) Or (EYELogicaVaciado.Usuarios.accesoTotal = False)) Then
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
        tp.SetToolTip(Me.btnListados, "Mostrar u Ocultar Listado.")
        tp.SetToolTip(Me.pbMarca, "Producido por Berry.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            EYELogicaVaciado.Directorios.id = 1
            EYELogicaVaciado.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaVaciado.Directorios.usuarioSql = "AdminBerry"
            EYELogicaVaciado.Directorios.contrasenaSql = "@berry2017"
            pnlEncabezado.BackColor = Color.DarkRed
        Else
            EYELogicaVaciado.Directorios.ObtenerParametros()
            EYELogicaVaciado.Usuarios.ObtenerParametros()
        End If
        EYELogicaVaciado.Programas.bdCatalogo = "Catalogo" & EYELogicaVaciado.Directorios.id
        EYELogicaVaciado.Programas.bdConfiguracion = "Configuracion" & EYELogicaVaciado.Directorios.id
        EYELogicaVaciado.Programas.bdEmpaque = "Empaque" & EYELogicaVaciado.Directorios.id
        EYEEntidadesVaciado.BaseDatos.ECadenaConexionCatalogo = EYELogicaVaciado.Programas.bdCatalogo
        EYEEntidadesVaciado.BaseDatos.ECadenaConexionConfiguracion = EYELogicaVaciado.Programas.bdConfiguracion
        EYEEntidadesVaciado.BaseDatos.ECadenaConexionEmpaque = EYELogicaVaciado.Programas.bdEmpaque
        EYEEntidadesVaciado.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesVaciado.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesVaciado.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesVaciado.Usuarios)
        usuarios.EId = EYELogicaVaciado.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count > 0) Then
            EYELogicaVaciado.Usuarios.id = lista(0).EId
            EYELogicaVaciado.Usuarios.nombre = lista(0).ENombre
            EYELogicaVaciado.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaVaciado.Usuarios.nivel = lista(0).ENivel
            EYELogicaVaciado.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarEncabezadosTitulos()

        lblEncabezadoPrograma.Text = "Programa: " & Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " & EYELogicaVaciado.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " & EYELogicaVaciado.Usuarios.nombre
        Me.Text = "Programa:  " & Me.nombreEstePrograma & "              Directorio:  " & EYELogicaVaciado.Directorios.nombre & "              Usuario:  " & EYELogicaVaciado.Usuarios.nombre
        hiloEncabezadosTitulos.Abort()

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = EYELogicaVaciado.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaVaciado.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaVaciado.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaVaciado.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaVaciado.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaVaciado.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaVaciado.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaVaciado.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaVaciado.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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
        Me.arriba = spVaciado.Top
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
            If ((Not TypeOf c Is Button) AndAlso (Not TypeOf c Is Label)) Then
                c.BackColor = Principal.colorCaptura
            End If
        Next
        For fila = 0 To spVaciado.ActiveSheet.Rows.Count - 1
            For columna = 0 To spVaciado.ActiveSheet.Columns.Count - 1
                spVaciado.ActiveSheet.Cells(fila, columna).BackColor = Principal.colorCaptura
            Next
        Next
        If (Not chkMantenerDatos.Checked) Then
            dtpFecha.Value = Today
        End If
        spVaciado.ActiveSheet.DataSource = Nothing
        spVaciado.ActiveSheet.Rows.Count = 1
        spVaciado.ActiveSheet.SetActiveCell(0, 0)
        LimpiarSpread(spVaciado)

    End Sub

    Private Sub LimpiarSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        spread.ActiveSheet.ClearRange(0, 0, spread.ActiveSheet.Rows.Count, spread.ActiveSheet.Columns.Count, True)

    End Sub

    Private Sub FormatearSpread()

        ' Se cargan tipos de datos de spread.
        CargarTiposDeDatos()
        ' Se cargan las opciones generales.
        pnlCatalogos.Visible = False
        spVaciado.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight
        spListados.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Rose
        spVaciado.ActiveSheet.GrayAreaBackColor = Principal.colorSpreadAreaGris
        spListados.ActiveSheet.GrayAreaBackColor = Color.FromArgb(255, 230, 230)
        spVaciado.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spCatalogos.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spListados.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spVaciado.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spListados.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVaciado.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spCatalogos.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spListados.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spVaciado.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spVaciado.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always
        spListados.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spListados.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always
        spVaciado.EditModeReplace = True
        Application.DoEvents()

    End Sub

    Private Sub EliminarRegistroDeSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim idRecepcion As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spread.ActiveSheet.Cells(spread.ActiveSheet.ActiveRowIndex, spread.ActiveSheet.Columns("idRecepcion").Index).Value)
        spread.ActiveSheet.Rows.Remove(spread.ActiveSheet.ActiveRowIndex, 1)
        spread.ActiveSheet.Rows.Count += 1
        CalcularSaldos(idRecepcion)

    End Sub

    Private Sub ControlarSpreadEnter(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim columnaActiva As Integer = spread.ActiveSheet.ActiveColumnIndex
        If (columnaActiva = spread.ActiveSheet.Columns.Count - 1) Then
            spread.ActiveSheet.Rows.Count += 1
        End If
        If (spread.Name = spVaciado.Name) Then
            Dim fila As Integer = 0
            If (columnaActiva = spVaciado.ActiveSheet.Columns("idRecepcion").Index) Then
                fila = spVaciado.ActiveSheet.ActiveRowIndex
                Dim idRecepcion As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Value)
                If (idRecepcion > 0) Then
                    Dim datos As New DataTable
                    recepcion.EId = idRecepcion
                    datos = recepcion.ObtenerListadoReporte()
                    If (datos.Rows.Count = 1) Then
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idProductor").Index).Value = datos.Rows(0).Item("idProductor")
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("nombreProductor").Index).Value = datos.Rows(0).Item("nombreProductor")
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idLote").Index).Value = datos.Rows(0).Item("idLote")
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("nombreLote").Index).Value = datos.Rows(0).Item("nombreLote")
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idProducto").Index).Value = datos.Rows(0).Item("idProducto")
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("nombreProducto").Index).Value = datos.Rows(0).Item("nombreProducto")
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idVariedad").Index).Value = datos.Rows(0).Item("idVariedad")
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("nombreVariedad").Index).Value = datos.Rows(0).Item("nombreVariedad")
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajaUnitaria").Index).Value = datos.Rows(0).Item("pesoCajaUnitaria")
                        spVaciado.ActiveSheet.SetActiveCell(fila, spVaciado.ActiveSheet.Columns("nombreVariedad").Index)
                    Else
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Value = String.Empty
                        spVaciado.ActiveSheet.SetActiveCell(fila, spVaciado.ActiveSheet.ActiveColumnIndex - 1)
                    End If
                Else
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Value = String.Empty
                    spVaciado.ActiveSheet.SetActiveCell(fila, spVaciado.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spVaciado.ActiveSheet.Columns("idBanda").Index) Then
                fila = spVaciado.ActiveSheet.ActiveRowIndex
                Dim idBanda As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idBanda").Index).Value)
                If (idBanda <= 0) Then
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idBanda").Index).Value = String.Empty
                    spVaciado.ActiveSheet.SetActiveCell(fila, spVaciado.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spVaciado.ActiveSheet.Columns("cantidadCajas").Index) Then
                fila = spVaciado.ActiveSheet.ActiveRowIndex
                Dim cantidadCajas As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Value)
                If (cantidadCajas > 0) Then
                    Dim pesoCaja As Double = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajaUnitaria").Index).Value)
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajas").Index).Value = cantidadCajas * pesoCaja
                    Dim idRecepcion As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Value)
                    ' Saldos de cajas.
                    Dim saldoCajas As Integer = CalcularSaldos(idRecepcion)
                    If (saldoCajas < 0) Then
                        MsgBox("Saldos de cajas insuficientes. No puedes sobrepasar la cantidad de cajas de este número de recepción.", MsgBoxStyle.Exclamation, "Saldos insuficientes.")
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Text = 0
                        spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajas").Index).Text = 0
                        spVaciado.ActiveSheet.SetActiveCell(fila, spVaciado.ActiveSheet.ActiveColumnIndex - 1)
                        CalcularSaldos(idRecepcion)
                    End If
                Else
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Value = String.Empty
                    spVaciado.ActiveSheet.SetActiveCell(fila, spVaciado.ActiveSheet.ActiveColumnIndex - 1)
                End If
            End If
            CalcularTotales()
        End If

    End Sub

    Private Function CalcularSaldos(ByVal idRecepcion As Integer) As Integer

        ' Con esta instrucción siguiente se quita el bindeo de la columna saldo que le hace el datatable al spread.
        spVaciado.ActiveSheet.BindDataColumn(spVaciado.ActiveSheet.Columns("saldoCajas").Index, Nothing)
        ' Se obtienen los saldos exceptuando esta hora.
        Dim fecha As Date = dtpFecha.Value
        Dim hora As String = txtHora.Text
        vaciado.EIdRecepcion = idRecepcion
        vaciado.EFecha = fecha
        vaciado.EHora = hora
        Dim cajasRestantesExcepcion As Integer = vaciado.ObtenerSaldos(False)
        'Se obtiene la sumatoria de cajas escritas por el usuario.
        Dim cajasTemporales As Integer = 0
        For fila As Integer = 0 To spVaciado.ActiveSheet.Rows.Count - 1
            If (spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Value = idRecepcion) Then
                cajasTemporales += spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Value
            End If
        Next
        ' Se actualizan los saldos en pantalla.
        Dim saldoTiempoReal As Integer = cajasRestantesExcepcion - cajasTemporales
        For fila As Integer = 0 To spVaciado.ActiveSheet.Rows.Count - 1
            If (spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Value = idRecepcion) Then
                spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("saldoCajas").Index).Value = saldoTiempoReal
            End If
        Next
        Return saldoTiempoReal

    End Function

    Private Sub CalcularSaldosConExcepcion()

        ' Con esta instrucción siguiente se quita el bindeo de la columna saldo que le hace el datatable al spread.
        spVaciado.ActiveSheet.BindDataColumn(spVaciado.ActiveSheet.Columns("saldoCajas").Index, Nothing)
        ' Con esto se calculan todos los saldos de algún id.
        For fila As Integer = 0 To spVaciado.ActiveSheet.Rows.Count - 1
            Dim idRecepcion As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Text)
            vaciado.EIdRecepcion = idRecepcion
            Dim cajasRestantes As Integer = vaciado.ObtenerSaldos(True)
            spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("saldoCajas").Index).Value = cajasRestantes
        Next

    End Sub

    Private Sub CalcularTotales()

        Dim total As Double = 0
        For columna = spVaciado.ActiveSheet.Columns("cantidadCajas").Index To spVaciado.ActiveSheet.Columns("pesoCajas").Index
            For fila = 0 To spVaciado.ActiveSheet.Rows.Count - 1
                total += EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, columna).Text)
            Next
            spVaciado.ActiveSheet.ColumnFooter.Cells(0, columna).Value = total
            total = 0
        Next

    End Sub

    Private Sub CargarVaciado()

        Me.Cursor = Cursors.WaitCursor
        vaciado.EFecha = dtpFecha.Value
        vaciado.EHora = Mid(txtHora.Text, 1, 3) & "00"
        spVaciado.ActiveSheet.DataSource = vaciado.ObtenerListadoDetallado()
        Me.cantidadFilas = spVaciado.ActiveSheet.Rows.Count + 1
        FormatearSpreadVaciado()
        AsignarFoco(spVaciado)
        spVaciado.ActiveSheet.SetActiveCell(0, 1)
        CalcularSaldosConExcepcion()
        CalcularTotales()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FormatearSpreadVaciado()

        ControlarSpreadEnterASiguienteColumna(spVaciado)
        spVaciado.ActiveSheet.Rows.Count = Me.cantidadFilas
        spVaciado.ActiveSheet.LockBackColor = Principal.colorCapturaBloqueada
        spVaciado.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        Dim numeracion As Integer = 0
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "pesoCajaUnitaria" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "idRecepcion" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "idProductor" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "nombreProductor" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "idLote" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "nombreLote" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "idVariedad" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "nombreVariedad" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "idBanda" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "pesoCajas" : numeracion += 1
        spVaciado.ActiveSheet.Columns(numeracion).Tag = "saldoCajas" : numeracion += 1
        spVaciado.ActiveSheet.Columns.Count = numeracion
        spVaciado.ActiveSheet.ColumnHeader.RowCount = 2
        spVaciado.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVaciado.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVaciado.ActiveSheet.ColumnHeader.Rows(0, spVaciado.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVaciado.ActiveSheet.AddColumnHeaderSpanCell(0, spVaciado.ActiveSheet.Columns("idRecepcion").Index, 2, 1)
        spVaciado.ActiveSheet.ColumnHeader.Cells(0, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Value = "No. Recepción *".ToUpper()
        spVaciado.ActiveSheet.AddColumnHeaderSpanCell(0, spVaciado.ActiveSheet.Columns("idProductor").Index, 1, 2)
        spVaciado.ActiveSheet.ColumnHeader.Cells(0, spVaciado.ActiveSheet.Columns("idProductor").Index).Value = "P  r  o  d  u  c  t  o  r".ToUpper()
        spVaciado.ActiveSheet.ColumnHeader.Cells(1, spVaciado.ActiveSheet.Columns("idProductor").Index).Value = "No.".ToUpper()
        spVaciado.ActiveSheet.ColumnHeader.Cells(1, spVaciado.ActiveSheet.Columns("nombreProductor").Index).Value = "Nombre".ToUpper()
        spVaciado.ActiveSheet.AddColumnHeaderSpanCell(0, spVaciado.ActiveSheet.Columns("idLote").Index, 1, 2)
        spVaciado.ActiveSheet.ColumnHeader.Cells(0, spVaciado.ActiveSheet.Columns("idLote").Index).Value = "L  o  t  e".ToUpper()
        spVaciado.ActiveSheet.ColumnHeader.Cells(1, spVaciado.ActiveSheet.Columns("idLote").Index).Value = "No.".ToUpper()
        spVaciado.ActiveSheet.ColumnHeader.Cells(1, spVaciado.ActiveSheet.Columns("nombreLote").Index).Value = "Nombre".ToUpper()
        spVaciado.ActiveSheet.AddColumnHeaderSpanCell(0, spVaciado.ActiveSheet.Columns("idProducto").Index, 1, 2)
        spVaciado.ActiveSheet.ColumnHeader.Cells(0, spVaciado.ActiveSheet.Columns("idProducto").Index).Value = "P  r  o  d  u  c  t  o".ToUpper()
        spVaciado.ActiveSheet.ColumnHeader.Cells(1, spVaciado.ActiveSheet.Columns("idProducto").Index).Value = "No.".ToUpper()
        spVaciado.ActiveSheet.ColumnHeader.Cells(1, spVaciado.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre".ToUpper()
        spVaciado.ActiveSheet.AddColumnHeaderSpanCell(0, spVaciado.ActiveSheet.Columns("idVariedad").Index, 1, 2)
        spVaciado.ActiveSheet.ColumnHeader.Cells(0, spVaciado.ActiveSheet.Columns("idVariedad").Index).Value = "V  a  r  i  e  d  a  d".ToUpper()
        spVaciado.ActiveSheet.ColumnHeader.Cells(1, spVaciado.ActiveSheet.Columns("idVariedad").Index).Value = "No.".ToUpper()
        spVaciado.ActiveSheet.ColumnHeader.Cells(1, spVaciado.ActiveSheet.Columns("nombreVariedad").Index).Value = "Nombre".ToUpper()
        spVaciado.ActiveSheet.AddColumnHeaderSpanCell(0, spVaciado.ActiveSheet.Columns("idBanda").Index, 2, 1)
        spVaciado.ActiveSheet.ColumnHeader.Cells(0, spVaciado.ActiveSheet.Columns("idBanda").Index).Value = "No. Banda *".ToUpper()
        spVaciado.ActiveSheet.AddColumnHeaderSpanCell(0, spVaciado.ActiveSheet.Columns("cantidadCajas").Index, 2, 1)
        spVaciado.ActiveSheet.ColumnHeader.Cells(0, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Value = "Cantidad Cajas *".ToUpper()
        spVaciado.ActiveSheet.AddColumnHeaderSpanCell(0, spVaciado.ActiveSheet.Columns("pesoCajas").Index, 2, 1)
        spVaciado.ActiveSheet.ColumnHeader.Cells(0, spVaciado.ActiveSheet.Columns("pesoCajas").Index).Value = "Peso Cajas".ToUpper()
        spVaciado.ActiveSheet.AddColumnHeaderSpanCell(0, spVaciado.ActiveSheet.Columns("saldoCajas").Index, 2, 1)
        spVaciado.ActiveSheet.ColumnHeader.Cells(0, spVaciado.ActiveSheet.Columns("saldoCajas").Index).Value = "Saldo Cajas".ToUpper()
        spVaciado.ActiveSheet.Columns("idRecepcion").Width = 90
        spVaciado.ActiveSheet.Columns("idProductor").Width = 50
        spVaciado.ActiveSheet.Columns("nombreProductor").Width = 150
        spVaciado.ActiveSheet.Columns("idLote").Width = 50
        spVaciado.ActiveSheet.Columns("nombreLote").Width = 150
        spVaciado.ActiveSheet.Columns("idProducto").Width = 50
        spVaciado.ActiveSheet.Columns("nombreProducto").Width = 150
        spVaciado.ActiveSheet.Columns("idVariedad").Width = 50
        spVaciado.ActiveSheet.Columns("nombreVariedad").Width = 150
        spVaciado.ActiveSheet.Columns("idBanda").Width = 60
        spVaciado.ActiveSheet.Columns("cantidadCajas").Width = 75
        spVaciado.ActiveSheet.Columns("pesoCajas").Width = 70
        spVaciado.ActiveSheet.Columns("saldoCajas").Width = 70
        spVaciado.ActiveSheet.Columns("idRecepcion").CellType = tipoEntero
        spVaciado.ActiveSheet.Columns("idProductor").CellType = tipoEntero
        spVaciado.ActiveSheet.Columns("nombreProductor").CellType = tipoTexto
        spVaciado.ActiveSheet.Columns("idLote").CellType = tipoEntero
        spVaciado.ActiveSheet.Columns("nombreLote").CellType = tipoTexto
        spVaciado.ActiveSheet.Columns("idProducto").CellType = tipoEntero
        spVaciado.ActiveSheet.Columns("nombreProducto").CellType = tipoTexto
        spVaciado.ActiveSheet.Columns("idVariedad").CellType = tipoEntero
        spVaciado.ActiveSheet.Columns("nombreVariedad").CellType = tipoTexto
        spVaciado.ActiveSheet.Columns("idBanda").CellType = tipoEntero
        spVaciado.ActiveSheet.Columns("cantidadCajas").CellType = tipoEntero
        spVaciado.ActiveSheet.Columns("pesoCajas").CellType = tipoDoble
        spVaciado.ActiveSheet.Columns("saldoCajas").CellType = tipoEntero
        spVaciado.ActiveSheet.Columns(spVaciado.ActiveSheet.Columns("idProductor").Index, spVaciado.ActiveSheet.Columns("nombreVariedad").Index).Locked = True
        spVaciado.ActiveSheet.Columns("pesoCajas").Locked = True
        spVaciado.ActiveSheet.Columns("saldoCajas").Locked = True
        spVaciado.ActiveSheet.Columns("pesoCajaUnitaria").Visible = False
        spVaciado.ActiveSheet.ColumnFooter.Visible = True
        spVaciado.ActiveSheet.ColumnFooter.Columns(0).CellType = tipoTexto
        spVaciado.ActiveSheet.ColumnFooter.Columns("cantidadCajas").CellType = tipoDoble
        spVaciado.ActiveSheet.ColumnFooter.Columns("pesoCajas").CellType = tipoDoble
        spVaciado.ActiveSheet.ColumnFooter.Columns("saldoCajas").CellType = tipoTexto
        spVaciado.ActiveSheet.ColumnFooter.Columns(0, spVaciado.ActiveSheet.Columns.Count - 1).BackColor = Principal.colorSpreadTotal
        spVaciado.ActiveSheet.ColumnFooter.Columns(0, spVaciado.ActiveSheet.Columns.Count - 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        spVaciado.ActiveSheet.AddColumnFooterSpanCell(0, 0, 1, spVaciado.ActiveSheet.Columns("cantidadCajas").Index)
        spVaciado.ActiveSheet.ColumnFooter.Cells(0, 0).Value = "Total".ToUpper()
        spVaciado.Refresh()

    End Sub

    Private Sub ValidarGuardadoVaciado()

        Me.esGuardadoValido = True
        ' Parte superior.  
        Dim hora As String = txtHora.Text
        If (String.IsNullOrEmpty(hora) Or hora.Length <> 5) Then
            txtHora.BackColor = Principal.colorAdvertencia
            Me.esGuardadoValido = False
        End If
        ' Parte inferior.
        For fila As Integer = 0 To spVaciado.ActiveSheet.Rows.Count - 1
            Dim idRecepcion As String = spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Text
            Dim idRecepcion2 As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Text)
            If (Not String.IsNullOrEmpty(idRecepcion) Or idRecepcion2 > 0) Then
                Dim idBanda As String = spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idBanda").Index).Text
                Dim idBanda2 As Double = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idBanda").Index).Text)
                If (String.IsNullOrEmpty(idBanda) Or idBanda2 < 0) Then
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idBanda").Index).BackColor = Principal.colorAdvertencia
                    Me.esGuardadoValido = False
                End If
                Dim cantidadCajas As String = spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Text
                Dim cantidadCajas2 As Double = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Text)
                If (String.IsNullOrEmpty(cantidadCajas) Or cantidadCajas2 < 0) Then
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).BackColor = Principal.colorAdvertencia
                    Me.esGuardadoValido = False
                End If
                Dim pesoCajas As String = spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajas").Index).Text
                Dim pesoCajas2 As Double = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajas").Index).Text)
                If (String.IsNullOrEmpty(pesoCajas) Or pesoCajas2 < 0) Then
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajas").Index).BackColor = Principal.colorAdvertencia
                    Me.esGuardadoValido = False
                End If
            End If
        Next

    End Sub

    Private Sub GuardarEditarVaciado()

        EliminarVaciado(False)
        ' Parte superior.  
        Dim fecha As Date = dtpFecha.Value
        Dim hora As String = txtHora.Text
        ' Parte inferior.
        For fila As Integer = 0 To spVaciado.ActiveSheet.Rows.Count - 1
            Dim idRecepcion As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idRecepcion").Index).Text)
            Dim idBanda As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idBanda").Index).Text)
            Dim cantidadCajas As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Text)
            Dim pesoCajas As Double = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajas").Index).Text)
            Dim orden As Integer = fila
            If (IsDate(fecha) AndAlso idBanda > 0 AndAlso cantidadCajas > 0 AndAlso pesoCajas > 0) Then
                vaciado.EIdRecepcion = idRecepcion
                vaciado.EFecha = fecha
                vaciado.EHora = hora
                vaciado.EIdBanda = idBanda
                vaciado.ECantidadCajas = cantidadCajas
                vaciado.EPesoCajas = pesoCajas
                vaciado.EOrden = orden
                vaciado.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        LimpiarPantalla()
        CargarVaciado()
        AsignarFoco(txtHora)

    End Sub

    Private Sub EliminarVaciado(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar esta entrada de vaciado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            vaciado.EFecha = dtpFecha.Value
            vaciado.EHora = txtHora.Text
            vaciado.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            LimpiarPantalla()
            AsignarFoco(txtHora)
        End If

    End Sub

    Private Sub FormatearSpreadListados(ByVal posicion As Integer)

        spListados.Width = 410
        spListados.ActiveSheet.Columns.Count = 3
        spListados.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        If (posicion = OpcionPosicion.izquierda) Then ' Izquierda.
            spListados.Location = New Point(Me.izquierda, Me.arriba)
        ElseIf (posicion = OpcionPosicion.centro) Then ' Centrar.
            spListados.Location = New Point(Me.anchoMitad - (spListados.Width / 2), Me.arriba)
        ElseIf (posicion = OpcionPosicion.derecha) Then ' Derecha.
            spListados.Location = New Point(Me.anchoTotal - spListados.Width, Me.arriba)
        End If
        Dim numeracion As Integer = 0
        spListados.ActiveSheet.Columns(numeracion).Tag = "fecha" : numeracion += 1
        spListados.ActiveSheet.Columns(numeracion).Tag = "hora" : numeracion += 1
        spListados.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spListados.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spListados.ActiveSheet.ColumnHeader.Rows(0).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spListados.ActiveSheet.ColumnHeader.Cells(0, spListados.ActiveSheet.Columns("fecha").Index).Value = "Fecha".ToUpper
        spListados.ActiveSheet.ColumnHeader.Cells(0, spListados.ActiveSheet.Columns("hora").Index).Value = "Hora".ToUpper
        spListados.ActiveSheet.ColumnHeader.Cells(0, spListados.ActiveSheet.Columns("cantidadCajas").Index).Value = "Cantidad Cajas".ToUpper
        spListados.ActiveSheet.Columns("fecha").Width = 120
        spListados.ActiveSheet.Columns("hora").Width = 100
        spListados.ActiveSheet.Columns("cantidadCajas").Width = 120
        spListados.ActiveSheet.Columns(0, spListados.ActiveSheet.Columns.Count - 1).AllowAutoFilter = True
        spListados.ActiveSheet.Columns(0, spListados.ActiveSheet.Columns.Count - 1).AllowAutoSort = True
        spListados.Height = spVaciado.Height
        spListados.BringToFront()
        spListados.Visible = True
        spListados.Refresh()

    End Sub

    Private Sub CargarListados()

        If (spListados.Visible) Then
            spListados.Visible = False
            spVaciado.Enabled = True
        Else
            spVaciado.Enabled = False
            recepcion.EId = 0
            Dim datos As New DataTable
            datos = vaciado.ObtenerListado()
            If (datos.Rows.Count > 0) Then
                spListados.ActiveSheet.DataSource = datos
            Else
                spListados.ActiveSheet.DataSource = Nothing
                spListados.ActiveSheet.Rows.Count = 0
                spVaciado.Enabled = True
            End If
            FormatearSpreadListados(OpcionPosicion.centro)
        End If

    End Sub

    Private Sub CargarDatosDeListados(ByVal filaCatalogos As Integer)

        dtpFecha.Value = spListados.ActiveSheet.Cells(filaCatalogos, spListados.ActiveSheet.Columns("fecha").Index).Text
        txtHora.Text = spListados.ActiveSheet.Cells(filaCatalogos, spListados.ActiveSheet.Columns("hora").Index).Text

    End Sub

    Private Sub VolverFocoDeListados()

        pnlCapturaSuperior.Enabled = True
        spVaciado.Enabled = True
        CargarVaciado()
        AsignarFoco(spVaciado)
        spListados.Visible = False

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Enum OpcionPosicion

        izquierda = 1
        centro = 2
        derecha = 3

    End Enum

#End Region

End Class