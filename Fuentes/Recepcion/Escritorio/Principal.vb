Imports System.IO
Imports System.ComponentModel
Imports System.Threading

Public Class Principal

    ' Variables de objetos de entidades.
    Public usuarios As New EYEEntidadesRecepcion.Usuarios()
    Public productores As New EYEEntidadesRecepcion.Productores()
    Public recepcion As New EYEEntidadesRecepcion.Recepcion()
    Public variedades As New EYEEntidadesRecepcion.Variedades()
    Public choferesCampos As New EYEEntidadesRecepcion.ChoferesCampos()
    Public lotes As New EYEEntidadesRecepcion.Lotes()
    Public productos As New EYEEntidadesRecepcion.Productos()
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
        FormatearSpreadRecepcion()
        FormatearSpreadTotales()
        CargarProductores()
        CargarLotes()
        CargarChoferesCampo()
        CargarProductos() 
        CargarIdConsecutivo()
        Me.estaMostrado = True
        AsignarFoco(txtId)
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

    Private Sub spEntradas_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spRecepcion.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter(spRecepcion)
        End If

    End Sub

    Private Sub spRecepcion_KeyDown(sender As Object, e As KeyEventArgs) Handles spRecepcion.KeyDown

        If (e.KeyData = Keys.F6) Then ' Eliminar un registro.
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                EliminarRegistroDeSpread(spRecepcion)
            End If
        ElseIf (e.KeyData = Keys.Enter) Then ' Validar registros.
            ControlarSpreadEnter(spRecepcion)
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

    Private Sub cbProductores_KeyDown(sender As Object, e As KeyEventArgs) Handles cbProductores.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbProductores.SelectedValue > 0) Then
                AsignarFoco(cbLotes)
            Else
                cbProductores.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtHora)
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
            AsignarFoco(cbProductores)
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

        If (EYELogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text) > 1) Then
            txtId.Text -= 1
            CargarRecepcion()
        End If

    End Sub

    Private Sub btnIdSiguiente_Click(sender As Object, e As EventArgs) Handles btnIdSiguiente.Click

        If (EYELogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text) >= 1) Then
            txtId.Text += 1
            CargarRecepcion()
        End If

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHora.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (Not String.IsNullOrEmpty(txtHora.Text.Trim.Replace(":", "").Replace("_", "")) And txtHora.Text.Length = 5) Then
                AsignarFoco(cbProductores)
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
            If (cbVariedades.SelectedValue > 0) Then
                AsignarFoco(spRecepcion)
            Else
                cbVariedades.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbProductos)
        End If

    End Sub

    Private Sub cbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged

        CargarVariedades()

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

        If ((Not EYELogicaRecepcion.Usuarios.accesoTotal) Or (EYELogicaRecepcion.Usuarios.accesoTotal = 0) Or (EYELogicaRecepcion.Usuarios.accesoTotal = False)) Then
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
            EYELogicaRecepcion.Directorios.id = 1
            EYELogicaRecepcion.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaRecepcion.Directorios.usuarioSql = "AdminBerry"
            EYELogicaRecepcion.Directorios.contrasenaSql = "@berry2017"
            pnlEncabezado.BackColor = Color.DarkRed
            pnlPie.BackColor = Color.DarkRed
        Else
            EYELogicaRecepcion.Directorios.ObtenerParametros()
            EYELogicaRecepcion.Usuarios.ObtenerParametros()
        End If
        EYELogicaRecepcion.Programas.bdCatalogo = "Catalogo" & EYELogicaRecepcion.Directorios.id
        EYELogicaRecepcion.Programas.bdConfiguracion = "Configuracion" & EYELogicaRecepcion.Directorios.id
        EYELogicaRecepcion.Programas.bdEmpaque = "Empaque" & EYELogicaRecepcion.Directorios.id
        EYEEntidadesRecepcion.BaseDatos.ECadenaConexionCatalogo = EYELogicaRecepcion.Programas.bdCatalogo
        EYEEntidadesRecepcion.BaseDatos.ECadenaConexionConfiguracion = EYELogicaRecepcion.Programas.bdConfiguracion
        EYEEntidadesRecepcion.BaseDatos.ECadenaConexionEmpaque = EYELogicaRecepcion.Programas.bdEmpaque
        EYEEntidadesRecepcion.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesRecepcion.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesRecepcion.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaRecepcion.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesRecepcion.Usuarios)
        usuarios.EId = EYELogicaRecepcion.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count = 1) Then
            EYELogicaRecepcion.Usuarios.id = lista(0).EId
            EYELogicaRecepcion.Usuarios.nombre = lista(0).ENombre
            EYELogicaRecepcion.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaRecepcion.Usuarios.nivel = lista(0).ENivel
            EYELogicaRecepcion.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub
     
    Private Sub CargarEncabezadosTitulos()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " + EYELogicaRecepcion.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " + EYELogicaRecepcion.Usuarios.nombre
        Me.Text = "Programa:  " + Me.nombreEstePrograma + "              Directorio:  " + EYELogicaRecepcion.Directorios.nombre + "              Usuario:  " + EYELogicaRecepcion.Usuarios.nombre
        hiloEncabezadosTitulos.Abort()

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = EYELogicaRecepcion.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaRecepcion.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaRecepcion.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaRecepcion.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaRecepcion.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaRecepcion.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaRecepcion.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaRecepcion.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaRecepcion.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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
            cbProductores.SelectedIndex = 0
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

    Private Sub CargarProductores()

        cbProductores.DataSource = productores.ObtenerListadoReporte()
        cbProductores.DisplayMember = "Nombre"
        cbProductores.ValueMember = "Id"

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
        spCatalogos.Visible = False
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
                Dim cantidadCajas As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Value)
                If (cantidadCajas > 0) Then
                    Dim lista As New List(Of EYEEntidadesRecepcion.Lotes)
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
                Dim pesoCajas As Double = EYELogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Value)
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
                total += EYELogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, columna).Text)
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

    Private Sub CargarRecepcion()

        Me.Cursor = Cursors.WaitCursor
        recepcion.EId = EYELogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text)
        If (recepcion.EId > 0) Then
            Dim lista As New List(Of EYEEntidadesRecepcion.Recepcion)
            lista = recepcion.ObtenerListado()
            If (lista.Count > 0) Then
                dtpFecha.Value = lista(0).EFecha
                txtHora.Text = lista(0).EHora
                cbProductores.SelectedValue = lista(0).EIdProductor
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
        spRecepcion.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
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
        spRecepcion.ActiveSheet.ColumnHeader.Cells(0, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Value = "Cantidad Cajas *".ToUpper()
        spRecepcion.ActiveSheet.ColumnHeader.Cells(0, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Value = "Peso Cajas *".ToUpper()
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
        spTotales.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spTotales.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Application.DoEvents()

    End Sub

    Private Sub ValidarGuardado()

        Me.Cursor = Cursors.WaitCursor
        Me.esGuardadoValido = True
        ' Parte superior. 
        Dim id As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text)
        If (id <= 0) Then
            txtId.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim hora As String = txtHora.Text
        If (String.IsNullOrEmpty(hora) Or hora.Length <> 5) Then
            txtHora.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idProductor As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbProductores.SelectedValue)
        If (idProductor <= 0) Then
            cbProductores.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idLote As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbLotes.SelectedValue)
        If (idLote <= 0) Then
            cbLotes.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idChofer As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbChoferesCampos.SelectedValue)
        If (idChofer <= 0) Then
            cbChoferesCampos.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idProducto As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbProductos.SelectedValue)
        If (idProducto <= 0) Then
            cbProductos.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idVariedad As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbVariedades.SelectedValue)
        If (idVariedad <= 0) Then
            cbVariedades.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        ' Parte inferior.
        For fila As Integer = 0 To spRecepcion.ActiveSheet.Rows.Count - 1
            Dim cantidadCajas As String = spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Text
            Dim cantidadCajas2 As Double = EYELogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Text)
            If (Not String.IsNullOrEmpty(cantidadCajas) Or cantidadCajas2 > 0) Then
                Dim pesoCajas As String = spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Text
                Dim pesoCajas2 As Double = EYELogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Text)
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
        Dim id As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text)
        Dim fecha As Date = dtpFecha.Value
        Dim hora As String = txtHora.Text
        Dim idProductor As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbProductores.SelectedValue)
        Dim idLote As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbLotes.SelectedValue)
        Dim idChofer As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbChoferesCampos.SelectedValue)
        Dim idProducto As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbProductos.SelectedValue)
        Dim idVariedad As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(cbVariedades.SelectedValue)
        ' Parte inferior.
        For fila As Integer = 0 To spRecepcion.ActiveSheet.Rows.Count - 1
            Dim cantidadCajas As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("cantidadCajas").Index).Text)
            Dim pesoCajas As Integer = EYELogicaRecepcion.Funciones.ValidarNumeroACero(spRecepcion.ActiveSheet.Cells(fila, spRecepcion.ActiveSheet.Columns("pesoCajas").Index).Text)
            If (id > 0 AndAlso IsDate(fecha) AndAlso idProductor > 0 AndAlso idLote > 0 AndAlso idChofer > 0 AndAlso idProducto > 0 And idVariedad > 0 AndAlso cantidadCajas > 0 AndAlso pesoCajas > 0) Then
                recepcion.EId = id
                recepcion.EFecha = fecha
                recepcion.EHora = hora
                recepcion.EIdProductor = idProductor
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
            recepcion.EId = EYELogicaRecepcion.Funciones.ValidarNumeroACero(txtId.Text)
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

#End Region

End Class