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
    Public Shared tipoLetraSpread As String = "Microsoft Sans Serif" : Public Shared tamañoLetraSpread As Integer = 11
    Public Shared alturaFilasEncabezadosGrandesSpread As Integer = 35 : Public Shared alturaFilasEncabezadosMedianosSpread As Integer = 28
    Public Shared alturaFilasEncabezadosChicosSpread As Integer = 22 : Public Shared alturaFilasSpread As Integer = 20
    Public Shared colorAreaGris = Color.White
    ' Variables de eventos de spread.
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
        'Centrar()
        'CargarNombrePrograma()
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
        'CargarEncabezados()
        'CargarTitulosDirectorio()
        FormatearSpread()
        FormatearSpreadVaciado()
        FormatearSpreadTotales()
        Me.estaMostrado = True
        AsignarFoco(dtpFecha)
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

        ValidarGuardado()
        If (Me.esGuardadoValido) Then
            GuardarEditarVaciado()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        EliminarVaciado(True)

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

#End Region

#Region "Métodos"

#Region "Básicos"

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
            pnlPie.BackColor = Color.DarkRed
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
        If (lista.Count = 1) Then
            EYELogicaVaciado.Usuarios.id = lista(0).EId
            EYELogicaVaciado.Usuarios.nombre = lista(0).ENombre
            EYELogicaVaciado.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaVaciado.Usuarios.nivel = lista(0).ENivel
            EYELogicaVaciado.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub
     
    Private Sub CargarEncabezadosTitulos()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " + EYELogicaVaciado.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " + EYELogicaVaciado.Usuarios.nombre
        Me.Text = "Programa:  " + Me.nombreEstePrograma + "              Directorio:  " + EYELogicaVaciado.Directorios.nombre + "              Usuario:  " + EYELogicaVaciado.Usuarios.nombre
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
            c.BackColor = Color.White
        Next
        For fila = 0 To spVaciado.ActiveSheet.Rows.Count - 1
            For columna = 0 To spVaciado.ActiveSheet.Columns.Count - 1
                spVaciado.ActiveSheet.Cells(fila, columna).BackColor = Color.White
            Next
        Next
        If (Not chkConservarDatos.Checked) Then
            dtpFecha.Value = Today
        End If
        spVaciado.ActiveSheet.DataSource = Nothing
        spVaciado.ActiveSheet.Rows.Count = 1
        spVaciado.ActiveSheet.SetActiveCell(0, 0)
        LimpiarSpread(spVaciado)
        LimpiarSpread(spTotales)

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
        spTotales.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight
        spVaciado.ActiveSheet.GrayAreaBackColor = Principal.colorAreaGris
        spTotales.ActiveSheet.GrayAreaBackColor = Principal.colorAreaGris
        spVaciado.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spTotales.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spCatalogos.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spVaciado.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spTotales.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVaciado.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spTotales.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spCatalogos.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spVaciado.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spVaciado.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spTotales.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spTotales.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        'spEntradas.EditModePermanent = True
        spVaciado.EditModeReplace = True
        spTotales.Enabled = False
        Application.DoEvents()

    End Sub

    Private Sub EliminarRegistroDeSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim idRecepcion As Integer = EYELogicaVaciado.Funciones.ValidarNumeroACero(spread.ActiveSheet.Cells(spread.ActiveSheet.ActiveRowIndex, spread.ActiveSheet.Columns("idRecepcion").Index).Value)
        If (spread.ActiveSheet.ActiveRowIndex > 0) Then
            spread.ActiveSheet.Rows.Remove(spread.ActiveSheet.ActiveRowIndex, 1)
        Else
            spread.ActiveSheet.ClearRange(spread.ActiveSheet.ActiveRowIndex, 0, 1, spread.ActiveSheet.Columns.Count, False)
            spread.ActiveSheet.SetActiveCell(spread.ActiveSheet.ActiveRowIndex, 0)
        End If
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
        Dim cajasRestantesExcepcion As Integer = vaciado.ObtenerSaldosReporte(False)
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
            Dim cajasRestantes As Integer = vaciado.ObtenerSaldosReporte(True)
            spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("saldoCajas").Index).Value = cajasRestantes
        Next

    End Sub

    Private Sub CalcularTotales()

        Dim total As Double = 0
        For columna = spVaciado.ActiveSheet.Columns("cantidadCajas").Index To spVaciado.ActiveSheet.Columns("pesoCajas").Index
            For fila = 0 To spVaciado.ActiveSheet.Rows.Count - 1
                total += EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, columna).Text)
            Next
            spTotales.ActiveSheet.Cells(0, columna).Text = total
            total = 0
        Next
        'spTotales.ActiveSheet.Cells(0, spTotales.ActiveSheet.Columns("total").Index).Text = "Total".ToUpper
        spTotales.ActiveSheet.Cells(0, 0, 0, spTotales.ActiveSheet.Columns.Count - 1).BackColor = Color.Gainsboro

    End Sub

    Private Sub CargarVaciado()

        Me.Cursor = Cursors.WaitCursor
        Dim datos As New DataTable
        vaciado.EFecha = dtpFecha.Value
        vaciado.EHora = Mid(txtHora.Text, 1, 3) & "00"
        spVaciado.ActiveSheet.DataSource = vaciado.ObtenerListadoReporte()
        cantidadFilas = spVaciado.ActiveSheet.Rows.Count + 1
        FormatearSpreadVaciado()
        AsignarFoco(spVaciado)
        spVaciado.ActiveSheet.SetActiveCell(0, 1)
        CalcularSaldosConExcepcion()
        CalcularTotales()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FormatearSpreadVaciado()

        spVaciado.ActiveSheet.ColumnHeader.RowCount = 2
        spVaciado.ActiveSheet.ColumnHeader.Rows(0, spVaciado.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVaciado.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVaciado.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVaciado.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVaciado)
        spVaciado.ActiveSheet.Rows.Count = cantidadFilas
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
        spVaciado.ActiveSheet.Columns("idRecepcion").Width = 120
        spVaciado.ActiveSheet.Columns("idProductor").Width = 50
        spVaciado.ActiveSheet.Columns("nombreProductor").Width = 150
        spVaciado.ActiveSheet.Columns("idLote").Width = 50
        spVaciado.ActiveSheet.Columns("nombreLote").Width = 150
        spVaciado.ActiveSheet.Columns("idProducto").Width = 50
        spVaciado.ActiveSheet.Columns("nombreProducto").Width = 150
        spVaciado.ActiveSheet.Columns("idVariedad").Width = 50
        spVaciado.ActiveSheet.Columns("nombreVariedad").Width = 150
        spVaciado.ActiveSheet.Columns("idBanda").Width = 120
        spVaciado.ActiveSheet.Columns("cantidadCajas").Width = 130
        spVaciado.ActiveSheet.Columns("pesoCajas").Width = 100
        spVaciado.ActiveSheet.Columns("saldoCajas").Width = 100
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
        spVaciado.ActiveSheet.Columns("pesoCajaUnitaria").Visible = False
        Application.DoEvents()

    End Sub

    Private Sub FormatearSpreadTotales()

        Dim numeracion As Integer = 0
        spTotales.ActiveSheet.Columns(numeracion).Tag = "pesoCajaUnitaria" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "idRecepcion" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "idProductor" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "nombreProductor" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "idLote" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "nombreLote" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "idVariedad" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "nombreVariedad" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "idBanda" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "pesoCajas" : numeracion += 1
        spTotales.ActiveSheet.Columns(numeracion).Tag = "saldoCajas" : numeracion += 1
        'spTotales.ActiveSheet.Columns(numeracion).Tag = "total" : numeracion += 1
        spTotales.ActiveSheet.Columns.Count = numeracion
        spTotales.ActiveSheet.Columns("idRecepcion").Width = spVaciado.ActiveSheet.Columns("idRecepcion").Width
        spTotales.ActiveSheet.Columns("idProductor").Width = spVaciado.ActiveSheet.Columns("idProductor").Width
        spTotales.ActiveSheet.Columns("nombreProductor").Width = spVaciado.ActiveSheet.Columns("nombreProductor").Width
        spTotales.ActiveSheet.Columns("idLote").Width = spVaciado.ActiveSheet.Columns("idLote").Width
        spTotales.ActiveSheet.Columns("nombreLote").Width = spVaciado.ActiveSheet.Columns("nombreLote").Width
        spTotales.ActiveSheet.Columns("idProducto").Width = spVaciado.ActiveSheet.Columns("idProducto").Width
        spTotales.ActiveSheet.Columns("nombreProducto").Width = spVaciado.ActiveSheet.Columns("nombreProducto").Width
        spTotales.ActiveSheet.Columns("idVariedad").Width = spVaciado.ActiveSheet.Columns("idVariedad").Width
        spTotales.ActiveSheet.Columns("nombreVariedad").Width = spVaciado.ActiveSheet.Columns("nombreVariedad").Width
        spTotales.ActiveSheet.Columns("idBanda").Width = spVaciado.ActiveSheet.Columns("idBanda").Width
        spTotales.ActiveSheet.Columns("cantidadCajas").Width = spVaciado.ActiveSheet.Columns("cantidadCajas").Width
        spTotales.ActiveSheet.Columns("pesoCajas").Width = spVaciado.ActiveSheet.Columns("pesoCajas").Width
        spTotales.ActiveSheet.Columns("saldoCajas").Width = spVaciado.ActiveSheet.Columns("saldoCajas").Width
        'spTotales.ActiveSheet.Columns("total").Width = 220
        'spTotales.ActiveSheet.Columns("total").CellType = tipoTexto
        spTotales.ActiveSheet.ColumnHeader.Visible = False
        spTotales.ActiveSheet.Columns("pesoCajaUnitaria").Visible = False
        spTotales.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spTotales.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Application.DoEvents()

    End Sub

    Private Sub ValidarGuardado()

        Me.Cursor = Cursors.WaitCursor
        Me.esGuardadoValido = True
        ' Parte superior.  
        Dim hora As String = txtHora.Text
        If (String.IsNullOrEmpty(hora) Or hora.Length <> 5) Then
            txtHora.BackColor = Color.Orange
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
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("idBanda").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
                Dim cantidadCajas As String = spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Text
                Dim cantidadCajas2 As Double = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).Text)
                If (String.IsNullOrEmpty(cantidadCajas) Or cantidadCajas2 < 0) Then
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("cantidadCajas").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
                Dim pesoCajas As String = spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajas").Index).Text
                Dim pesoCajas2 As Double = EYELogicaVaciado.Funciones.ValidarNumeroACero(spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajas").Index).Text)
                If (String.IsNullOrEmpty(pesoCajas) Or pesoCajas2 < 0) Then
                    spVaciado.ActiveSheet.Cells(fila, spVaciado.ActiveSheet.Columns("pesoCajas").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
            End If
        Next
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GuardarEditarVaciado()

        Me.Cursor = Cursors.WaitCursor
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
            If (IsDate(fecha) AndAlso idBanda > 0 AndAlso cantidadCajas > 0 AndAlso pesoCajas > 0) Then
                vaciado.EIdRecepcion = idRecepcion
                vaciado.EFecha = fecha
                vaciado.EHora = hora
                vaciado.EIdBanda = idBanda
                vaciado.ECantidadCajas = cantidadCajas
                vaciado.EPesoCajas = pesoCajas
                vaciado.EOrden = fila
                vaciado.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        LimpiarPantalla()
        CargarVaciado()
        AsignarFoco(txtHora)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EliminarVaciado(ByVal conMensaje As Boolean)

        Me.Cursor = Cursors.WaitCursor
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

#End Region

End Class