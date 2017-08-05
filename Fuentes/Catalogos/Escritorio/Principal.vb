Imports System.IO
Imports System.ComponentModel

Public Class Principal

    ' Variables de objetos de entidades.
    Public usuarios As New EYEEntidadesCatalogos.Usuarios()
    Public lotes As New EYEEntidadesCatalogos.Lotes()
    Public productos As New EYEEntidadesCatalogos.Productos()
    Public variedades As New EYEEntidadesCatalogos.Variedades()
    Public choferesCampo As New EYEEntidadesCatalogos.ChoferesCampos()
    Public productores As New EYEEntidadesCatalogos.Productores()
    Public etiquetas As New EYEEntidadesCatalogos.Etiquetas()
    Public clientes As New EYEEntidadesCatalogos.Clientes()
    Public envases As New EYEEntidadesCatalogos.Envases()
    Public tamaños As New EYEEntidadesCatalogos.Tamaños()
    Public tiposEntradas As New EYEEntidadesCatalogos.TiposEntradas()
    Public tiposSalidas As New EYEEntidadesCatalogos.TiposSalidas()
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
    ' Variables de eventos de spread.
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public medidasUnaVez As Boolean = False
    Public opcionSeleccionada As Integer = 0
    Public estaCerrando As Boolean = False
    Public ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public prefijoBaseDatosEmpaque As String = "EYE" & "_"
    ' Variable de desarrollo.
    Public esDesarrollo As Boolean = False

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Centrar()
        CargarNombrePrograma()
        AsignarTooltips()
        ConfigurarConexiones()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Cursor = Cursors.WaitCursor
        'If (Not ValidarAccesoTotal()) Then
        '    Salir()
        'End If
        CargarEncabezados()
        CargarTitulosDirectorio()
        CargarMedidas()
        FormatearSpread()
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If (Me.opcionSeleccionada = OpcionMenu.lotes) Then
            GuardarEditarLotes()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.productos) Then
            GuardarEditarProductos()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.variedades) Then
            GuardarEditarVariedades()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.choferesCampos) Then
            GuardarEditarChoferesCampos()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.productores) Then
            GuardarEditarProductores()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.clientes) Then
            GuardarEditarClientes()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.envases) Then
            GuardarEditarEnvases()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.tamaños) Then
            GuardarEditarTamaños()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.tiposEntradas) Then
            GuardarEditarTiposEntradas()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.tiposSalidas) Then
            GuardarEditarTiposSalidas()
        ElseIf (Me.opcionSeleccionada = OpcionMenu.etiquetas) Then
            GuardarEditarEtiquetas()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If (Me.opcionSeleccionada = OpcionMenu.lotes) Then
            EliminarLotes(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.productos) Then
            EliminarProductos(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.variedades) Then
            EliminarVariedades(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.productores) Then
            EliminarProductores(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.choferesCampos) Then
            EliminarChoferesCampos(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.clientes) Then
            EliminarClientes(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.envases) Then
            EliminarEnvases(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.tamaños) Then
            EliminarTamaños(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.tiposEntradas) Then
            EliminarTiposEntradas(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.tiposSalidas) Then
            EliminarTiposSalidas(True)
        ElseIf (Me.opcionSeleccionada = OpcionMenu.etiquetas) Then
            EliminarEtiquetas(True)
        End If

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
        If (Me.opcionSeleccionada = OpcionMenu.variedades Or Me.opcionSeleccionada = OpcionMenu.tamaños) Then
            spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idProducto").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("nombreProducto").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
            'ElseIf (Me.opcionSeleccionada = OpcionMenu.productores) Then
            'spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idUnidadMedida").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text
            'spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("nombreUnidadMedida").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
            'ElseIf (Me.opcionSeleccionada = OpcionMenu.tamaños) Then
            '    spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idMoneda").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text
            '    spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("nombreMoneda").Index).Text = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
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

    Private Sub rbtnLotes_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnLotes.CheckedChanged

        If (rbtnLotes.Checked) Then
            SeleccionoLotes()
        End If

    End Sub

    Private Sub rbtnProductos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnProductos.CheckedChanged

        If (rbtnProductos.Checked) Then
            SeleccionoProductos()
        End If

    End Sub

    Private Sub rbtnVariedades_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnVariedades.CheckedChanged

        If (rbtnVariedades.Checked) Then
            SeleccionoSubFamilias()
        End If

    End Sub

    Private Sub rbtnProductores_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnProductores.CheckedChanged

        If (rbtnProductores.Checked) Then
            SeleccionoProductores()
        End If

    End Sub

    Private Sub pnlMenu_MouseEnter(sender As Object, e As EventArgs) Handles pnlMenu.MouseEnter

        AsignarTooltips("Menú.")

    End Sub

    Private Sub rbtnChoferesCampos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnChoferesCampos.CheckedChanged

        If (rbtnChoferesCampos.Checked) Then
            SeleccionoChoferesCampos()
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
            If (Me.opcionSeleccionada = OpcionMenu.variedades Or Me.opcionSeleccionada = OpcionMenu.tamaños) Then
                If (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("idProducto").Index) Or (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("nombreProducto").Index) Then
                    spVarios.Enabled = False
                    pnlMenu.Enabled = False
                    CargarCatalogoProductos()
                End If
                'ElseIf (Me.opcionSeleccionada = OpcionMenu.TiposCambios) Then
                '    If (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("idMoneda").Index) Or (spVarios.ActiveSheet.ActiveColumnIndex = spVarios.ActiveSheet.Columns("nombreMoneda").Index) Then
                '        spVarios.Enabled = False
                '        CargarCatalogoMonedas()
                '        FormatearSpreadCatalogo(False)
                '        spCatalogos.Focus()
                '    End If
            End If
        End If

    End Sub

    Private Sub rbtnEnvases_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnEnvases.CheckedChanged

        If (rbtnEnvases.Checked) Then
            SeleccionoEnvases()
        End If

    End Sub

    Private Sub rbtnTiposEntradas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTiposEntradas.CheckedChanged

        If (rbtnTiposEntradas.Checked) Then
            SeleccionoTiposEntradas()
        End If

    End Sub

    Private Sub rbtnTiposSalidas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTiposSalidas.CheckedChanged

        If (rbtnTiposSalidas.Checked) Then
            SeleccionoTiposSalidas()
        End If

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

    Private Sub rbtnEtiquetas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnEtiquetas.CheckedChanged

        If (rbtnEtiquetas.Checked) Then
            SeleccionoEtiquetas()
        End If

    End Sub

    Private Sub rbtnTamaños_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTamaños.CheckedChanged

        If (rbtnTamaños.Checked) Then
            SeleccionoTamaños()
        End If

    End Sub

    Private Sub rbtnClientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnClientes.CheckedChanged

        If (rbtnClientes.Checked) Then
            SeleccionoClientes()
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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Teclas básicas: " & vbNewLine & "F5 sirve para mostrar catálogos. " & vbNewLine & "F6 sirve para eliminar un registro únicamente. " & vbNewLine & "Escape sirve para ocultar catálogos que se encuentren desplegados. " & vbNewLine & vbNewLine & "* Catálogos desplegados: " & vbNewLine & "Cuando se muestra algún catálogo, al seleccionar alguna opción de este, se va mostrando en tiempo real en la captura de donde se originó. Cuando se le da doble clic en alguna opción o a la tecla escape se oculta dicho catálogo. " & vbNewLine & vbNewLine & "* Datos obligatorios:" & vbNewLine & "Todos los que tengan el simbolo * son estrictamente obligatorios." & vbNewLine & vbNewLine & "* Captura:" & vbNewLine & "* Almacenes: " & vbNewLine & "En esta pestaña se capturarán los distintos almacenes que se manejan. " & vbNewLine & "* Familias: " & vbNewLine & "En esta parte se agrupan por un primer nivel dependiendo el almacén, ejemplo: insecticidas, agroquimicos, etc. " & vbNewLine & "* SubFamilias: " & vbNewLine & "En este apartado se capturarán todos los segundos niveles de acuerdo al almacén y familia correspondiente seleccionadas. " & vbNewLine & "* Artículos: " & vbNewLine & "En este lugar se agrupan los terceros niveles de acuerdo al almacén, familia y subfamilia correspondiente seleccionadas. " & vbNewLine & "* Existen distintas opciones que se tienen que configurar como proveedores, monedas, tipos de cambio, etc. en las cuales especifíca claramente todo lo que se necesita." & vbNewLine & vbNewLine & "* Para todas las opciones existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. " : Application.DoEvents()
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

        If ((Not EYELogicaCatalogos.Usuarios.accesoTotal) Or (EYELogicaCatalogos.Usuarios.accesoTotal = 0) Or (EYELogicaCatalogos.Usuarios.accesoTotal = False)) Then
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
        tp.SetToolTip(Me.pnlMenu, "Menú.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            EYELogicaCatalogos.Directorios.id = 1
            EYELogicaCatalogos.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaCatalogos.Directorios.usuarioSql = "AdminBerry"
            EYELogicaCatalogos.Directorios.contrasenaSql = "@berry2017" 
            pnlEncabezado.BackColor = Color.DarkRed
            pnlPie.BackColor = Color.DarkRed
        Else
            EYELogicaCatalogos.Directorios.ObtenerParametros()
            EYELogicaCatalogos.Usuarios.ObtenerParametros()
        End If
        EYEEntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = "Catalogo" & EYELogicaCatalogos.Directorios.id
        EYEEntidadesCatalogos.BaseDatos.ECadenaConexionConfiguracion = "Configuracion" & EYELogicaCatalogos.Directorios.id
        EYEEntidadesCatalogos.BaseDatos.ECadenaConexionAlmacen = "Almacen" & EYELogicaCatalogos.Directorios.id
        EYEEntidadesCatalogos.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesCatalogos.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesCatalogos.BaseDatos.AbrirConexionAlmacen()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesCatalogos.Usuarios)
        usuarios.EId = EYELogicaCatalogos.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count = 1) Then
            EYELogicaCatalogos.Usuarios.id = lista(0).EId
            EYELogicaCatalogos.Usuarios.nombre = lista(0).ENombre
            EYELogicaCatalogos.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaCatalogos.Usuarios.nivel = lista(0).ENivel
            EYELogicaCatalogos.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarTitulosDirectorio()

        Me.Text = "Programa:  " + Me.nombreEstePrograma + "              Directorio:  " + EYELogicaCatalogos.Directorios.nombre + "              Usuario:  " + EYELogicaCatalogos.Usuarios.nombre

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " + EYELogicaCatalogos.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " + EYELogicaCatalogos.Usuarios.nombre

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = EYELogicaCatalogos.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaCatalogos.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaCatalogos.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaCatalogos.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaCatalogos.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaCatalogos.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaCatalogos.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaCatalogos.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaCatalogos.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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
        Application.DoEvents()

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
        If (Me.opcionSeleccionada = OpcionMenu.variedades Or Me.opcionSeleccionada = OpcionMenu.tamaños) Then
            If (columnaActiva = spVarios.ActiveSheet.Columns("idProducto").Index) Then
                fila = spVarios.ActiveSheet.ActiveRowIndex
                Dim idProducto As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index).Value)
                productos.EId = idProducto
                If (idProducto > 0) Then
                    Dim lista As New List(Of EYEEntidadesCatalogos.Productos)
                    lista = productos.ObtenerListado()
                    If (lista.Count > 0) Then
                        spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombreProducto").Index).Value = lista(0).ENombre
                    End If
                End If
            End If
            'ElseIf (Me.opcionSeleccionada = OpcionMenu.productores) Then
            'If (columnaActiva = spVarios.ActiveSheet.Columns("idUnidadMedida").Index) Then
            '    fila = spVarios.ActiveSheet.ActiveRowIndex
            '    Dim idUnidadMedida As Integer = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idUnidadMedida").Index).Value
            '    unidadesMedidas.EId = idUnidadMedida
            '    If (idUnidadMedida > 0) Then
            '        Dim lista As New List(Of EntidadesCatalogos.UnidadesMedidas)
            '        lista = unidadesMedidas.ObtenerListado()
            '        If (lista.Count > 0) Then
            '            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombreUnidadMedida").Index).Value = lista(0).ENombre
            '        End If
            '    End If
            'End If
            'ElseIf (Me.opcionSeleccionada = OpcionMenu.tamaños) Then
            '    fila = spVarios.ActiveSheet.ActiveRowIndex
            '    If (columnaActiva = spVarios.ActiveSheet.Columns("idMoneda").Index) Then
            '        Dim idMonedaa As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idMoneda").Index).Text)
            '        If (idMonedaa > 0) Then
            '            Dim lista As New List(Of EYEEntidadesCatalogos.Envases)
            '            envases.EId = idMonedaa
            '            lista = envases.ObtenerListado
            '            If (lista.Count > 0) Then
            '                spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombreMoneda").Index).Text = lista(0).ENombre
            '            End If
            '        Else
            '            spVarios.ActiveSheet.SetActiveCell(fila - 1, spVarios.ActiveSheet.Columns.Count - 1)
            '        End If
            '    ElseIf (columnaActiva = spVarios.ActiveSheet.Columns("fecha").Index) Then
            '        Dim fecha As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("fecha").Index).Text
            '        If (String.IsNullOrEmpty(fecha)) Then
            '            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("fecha").Index).Value = Today
            '        End If
            '    ElseIf (columnaActiva = spVarios.ActiveSheet.Columns("valor").Index) Then
            '        Dim idMoneda As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idMoneda").Index).Text)
            '        Dim fecha As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("fecha").Index).Text
            '        If (String.IsNullOrEmpty(fecha)) Then
            '            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("fecha").Index).Value = Today
            '        End If
            '        For indice = 0 To spVarios.ActiveSheet.Rows.Count - 1
            '            Dim fechaa As String = spVarios.ActiveSheet.Cells(indice, spVarios.ActiveSheet.Columns("fecha").Index).Text
            '            Dim idMonedaa As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(indice, spVarios.ActiveSheet.Columns("idMoneda").Index).Text)
            '            If (Not String.IsNullOrEmpty(fecha)) Then
            '                If (fechaa = fecha And idMonedaa = idMoneda And indice <> fila) Then
            '                    LimpiarFilaSpread(spVarios, fila)
            '                    spVarios.ActiveSheet.SetActiveCell(fila - 1, spVarios.ActiveSheet.Columns.Count - 1)
            '                End If
            '            End If
            '        Next
            '        Dim valor As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("valor").Index).Text
            '        If (String.IsNullOrEmpty(valor)) Then
            '            spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("valor").Index).Text = String.Empty
            '            spVarios.ActiveSheet.SetActiveCell(fila, spVarios.ActiveSheet.Columns("valor").Index - 1)
            '        End If
            '    End If
        End If

    End Sub

    Private Sub LimpiarFilaSpread(ByVal spread As FarPoint.Win.Spread.FpSpread, ByVal fila As Integer)

        spread.ActiveSheet.ClearRange(fila, 0, 1, spread.ActiveSheet.Columns.Count, True)
        spread.ActiveSheet.SetActiveCell(fila, -1)
        Application.DoEvents()

    End Sub

    Private Sub LimpiarSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        spread.ActiveSheet.ClearRange(0, 0, spread.ActiveSheet.Rows.Count, spread.ActiveSheet.Columns.Count, True) : Application.DoEvents()

    End Sub

    Private Sub CargarCatalogoUnidadesMedidas()

        etiquetas.EId = 0
        spCatalogos.ActiveSheet.DataSource = etiquetas.ObtenerListado() ': Application.DoEvents()
        spCatalogos.Focus()

    End Sub

    Private Sub CargarCatalogoMonedas()

        envases.EId = 0
        spCatalogos.ActiveSheet.DataSource = envases.ObtenerListado()
        spCatalogos.Focus()

    End Sub

    Private Sub CargarCatalogoProductos()

        productos.EId = 0
        spCatalogos.ActiveSheet.DataSource = productos.ObtenerListado()
        FormatearSpreadCatalogo(False)
        AsignarFoco(spCatalogos)

    End Sub

    Private Sub FormatearSpreadCatalogo(ByVal izquierda As Boolean)

        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spCatalogos.Width = 300
        If (izquierda) Then
            spCatalogos.Location = New Point(Me.izquierda, Me.arriba)
        Else
            spCatalogos.Location = New Point(Me.anchoTotal - spCatalogos.Width, Me.arriba)
        End If
        spCatalogos.Visible = True
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCatalogos.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        spCatalogos.Height = Me.altoTotal
        Dim numeracion As Integer = 0
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos.ActiveSheet.Columns("id").Width = 50
        spCatalogos.ActiveSheet.Columns("nombre").Width = 210
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosMedianosSpread
        Application.DoEvents()

    End Sub

    Private Sub VolverFocoCatalogos()

        If (Me.opcionSeleccionada = OpcionMenu.variedades Or Me.opcionSeleccionada = OpcionMenu.tamaños) Then
            spVarios.Enabled = True
            pnlMenu.Enabled = True
            spVarios.Focus()
            spVarios.ActiveSheet.SetActiveCell(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idProducto").Index + 2)
            'ElseIf (Me.opcionSeleccionada = OpcionMenu.productores) Then
            'spVarios.Enabled = True
            'spVarios.Focus()
            'spVarios.ActiveSheet.SetActiveCell(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idUnidadMedida").Index + 2)
            'ElseIf (Me.opcionSeleccionada = OpcionMenu.tamaños) Then
            '    spVarios.Enabled = True
            '    spVarios.Focus()
            '    spVarios.ActiveSheet.SetActiveCell(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("idMoneda").Index + 2)
        End If
        spCatalogos.Visible = False

    End Sub

    Private Sub SeleccionoLotes()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.lotes
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarLotes()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarLotes()

        AcomodarSpread()
        spVarios.ActiveSheet.DataSource = lotes.ObtenerListadoReporte()
        FormatearSpreadLotes()
        AsignarFoco(spVarios)

    End Sub

    Private Sub FormatearSpreadLotes()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "hectareas" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "pesoCaja" : numeracion += 1
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 400
        spVarios.ActiveSheet.Columns("hectareas").Width = 160
        spVarios.ActiveSheet.Columns("pesoCaja").Width = 160
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("hectareas").CellType = tipoDoble
        spVarios.ActiveSheet.Columns("pesoCaja").CellType = tipoDoble
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        Dim obligatorio As String = String.Empty
        obligatorio = " *"
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "L  o  t  e  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("hectareas").Index).Value = "Hectareas".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("pesoCaja").Index).Value = "Peso por Caja".ToUpper()
        spVarios.ActiveSheet.Rows.Count += 1
        spVarios.Focus()
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarLotes()

        EliminarLotes(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            Dim hectareas As Double = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("hectareas").Index).Value)
            Dim pesoCaja As Double = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("pesoCaja").Index).Value)
            If (id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                lotes.EId = id
                lotes.ENombre = nombre
                lotes.EHectareas = hectareas
                lotes.EPesoCaja = pesoCaja
                lotes.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarLotes()

    End Sub

    Private Sub EliminarLotes(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            lotes.EId = 0
            lotes.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            CargarLotes()
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub SeleccionoProductos()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.productos
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarProductos()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarProductos()

        AcomodarSpread()
        productos.EId = 0
        spVarios.ActiveSheet.DataSource = productos.ObtenerListadoReporte()
        FormatearSpreadProductos()
        AsignarFoco(spVarios)

    End Sub

    Private Sub FormatearSpreadProductos()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread
        If (Me.opcionSeleccionada = OpcionMenu.productos) Then
            spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        Else
            spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        End If
        If (Me.opcionSeleccionada = OpcionMenu.productos) Then
            ControlarSpreadEnterASiguienteColumna(spVarios)
        End If
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "abreviatura" : numeracion += 1
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 400
        spVarios.ActiveSheet.Columns("abreviatura").Width = 160
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("abreviatura").CellType = tipoTexto
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        Dim obligatorio As String = String.Empty
        If (Me.opcionSeleccionada = OpcionMenu.productos) Then
            obligatorio = " *"
        End If
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "P  r  o  d  u  c  t  o  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("abreviatura").Index).Value = "Abreviatura".ToUpper()
        If (Me.opcionSeleccionada = OpcionMenu.productos) Then
            spVarios.ActiveSheet.Rows.Count += 1
        End If
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarProductos()

        Dim idAlmacen As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(spVarios.ActiveSheet.ActiveRowIndex, spVarios.ActiveSheet.Columns("id").Index).Value)
        EliminarProductos(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            Dim abreviatura As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("abreviatura").Index).Text
            If (id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                productos.EId = id
                productos.ENombre = nombre
                productos.EAbreviatura = abreviatura
                productos.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarProductos()

    End Sub

    Private Sub EliminarProductos(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            productos.EId = 0
            productos.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarProductos()
        End If

    End Sub

    Private Sub SeleccionoSubFamilias()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.variedades
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarVariedades()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarVariedades()

        AcomodarSpread()
        variedades.EIdProducto = 0
        variedades.EId = 0
        spVarios.ActiveSheet.DataSource = variedades.ObtenerListadoReporte()
        FormatearSpreadVariedades()

    End Sub

    Private Sub FormatearSpreadVariedades()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "abreviatura" : numeracion += 1
        spVarios.ActiveSheet.Columns("idProducto").Width = 50
        spVarios.ActiveSheet.Columns("nombreProducto").Width = 250
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 300
        spVarios.ActiveSheet.Columns("abreviatura").Width = 150
        spVarios.ActiveSheet.Columns("idProducto").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombreProducto").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("abreviatura").CellType = tipoTexto
        Dim obligatorio As String = String.Empty
        obligatorio = " *"
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "V  a  r  i  e  d  a  d  e  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("idProducto").Index).Value = "No.".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre Producto".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper() & obligatorio
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("abreviatura").Index).Value = "Abreviatura".ToUpper()
        spVarios.ActiveSheet.Columns(spVarios.ActiveSheet.Columns("nombreProducto").Index).Locked = True
        spVarios.ActiveSheet.Rows.Count += 1
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarVariedades()

        EliminarVariedades(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim idProducto As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index).Text)
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            Dim abreviatura As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("abreviatura").Index).Text
            If (idProducto > 0 AndAlso id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                variedades.EIdProducto = idProducto
                variedades.EId = id
                variedades.ENombre = nombre
                variedades.EAbreviatura = abreviatura
                variedades.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarVariedades()

    End Sub

    Private Sub EliminarVariedades(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            variedades.EId = 0
            variedades.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarVariedades()
        End If

    End Sub

    Private Sub SeleccionoProductores()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.productores
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarProductores()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarProductores()

        AcomodarSpread()
        productores.EId = 0
        spVarios.ActiveSheet.DataSource = productores.ObtenerListadoReporte()
        FormatearSpreadProductores()

    End Sub

    Private Sub FormatearSpreadProductores()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "domicilio" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "fda" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "gs1" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "ggn" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "claveAgricola" : numeracion += 1
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 400
        spVarios.ActiveSheet.Columns("domicilio").Width = 300
        spVarios.ActiveSheet.Columns("fda").Width = 150
        spVarios.ActiveSheet.Columns("gs1").Width = 150
        spVarios.ActiveSheet.Columns("ggn").Width = 150
        spVarios.ActiveSheet.Columns("claveAgricola").Width = 150
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("domicilio").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("fda").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("gs1").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("ggn").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("claveAgricola").CellType = tipoTexto
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "P  r  o  d  u  c  t  o  r  e  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("domicilio").Index).Value = "Domicilio".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("fda").Index).Value = "Fda".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("gs1").Index).Value = "Gs1".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("ggn").Index).Value = "Ggn".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("claveAgricola").Index).Value = "Clave Agrícola".ToUpper()
        spVarios.ActiveSheet.Rows.Count += 1
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarProductores()

        productores.EId = 0
        EliminarProductores(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            Dim domicilio As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("domicilio").Index).Text
            Dim fda As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("fda").Index).Text
            Dim gs1 As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("gs1").Index).Text
            Dim ggn As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("ggn").Index).Text
            Dim claveAgricola As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("claveAgricola").Index).Text
            If (id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                productores.EId = id
                productores.ENombre = nombre
                productores.EDomicilio = domicilio
                productores.EFda = fda
                productores.EGs1 = gs1
                productores.EGgn = ggn
                productores.EClaveAgricola = claveAgricola
                productores.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarProductores()

    End Sub

    Private Sub EliminarProductores(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            productores.EId = 0
            productores.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarProductores()
        End If

    End Sub

    Private Sub SeleccionoChoferesCampos()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.choferesCampos
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarChoferesCampos()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarChoferesCampos()

        AcomodarSpread()
        choferesCampo.EId = 0
        spVarios.ActiveSheet.DataSource = choferesCampo.ObtenerListadoReporte()
        FormatearSpreadChoferesCampos()
        AsignarFoco(spVarios)

    End Sub

    Private Sub FormatearSpreadChoferesCampos()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 400
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "C  h  o  f  e  r  e  s      d  e      C  a  m  p  o".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre *".ToUpper()
        spVarios.ActiveSheet.Rows.Count += 1
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarChoferesCampos()

        EliminarChoferesCampos(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            If (id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                choferesCampo.EId = id
                choferesCampo.ENombre = nombre
                choferesCampo.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarChoferesCampos()

    End Sub

    Private Sub EliminarChoferesCampos(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            choferesCampo.EId = 0
            choferesCampo.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarChoferesCampos()
        End If

    End Sub

    Private Sub SeleccionoEnvases()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.envases
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarEnvases()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarEnvases()

        AcomodarSpread()
        envases.EId = 0
        spVarios.ActiveSheet.DataSource = envases.ObtenerListadoReporte()
        FormatearSpreadEnvases()

    End Sub

    Private Sub FormatearSpreadEnvases()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "abreviatura" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "peso" : numeracion += 1
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 400
        spVarios.ActiveSheet.Columns("abreviatura").Width = 150
        spVarios.ActiveSheet.Columns("peso").Width = 150
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("abreviatura").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("peso").CellType = tipoTexto
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "E  n  v  a  s  e  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("abreviatura").Index).Value = "Abreviatura".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("peso").Index).Value = "Peso".ToUpper()
        spVarios.ActiveSheet.Rows.Count += 1
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarEnvases()

        EliminarEnvases(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            Dim abreviatura As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("abreviatura").Index).Text
            Dim peso As Double = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("peso").Index).Text)
            If (id > 0 AndAlso Not String.IsNullOrEmpty(nombre) AndAlso peso > 0) Then
                envases.EId = id
                envases.ENombre = nombre
                envases.EAbreviatura = abreviatura
                envases.EPeso = peso
                envases.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarEnvases()

    End Sub

    Private Sub EliminarEnvases(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            envases.EId = 0
            envases.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarEnvases()
        End If

    End Sub

    Private Sub SeleccionoTiposEntradas()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.tiposEntradas
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarTiposEntradas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarTiposEntradas()

        spVarios.Height = Me.altoTotal
        spVarios.Width = Me.anchoTotal
        spVarios.Top = Me.arriba
        spVarios.Left = Me.izquierda
        spVarios.Show()
        tiposEntradas.EId = 0
        spVarios.ActiveSheet.DataSource = tiposEntradas.ObtenerListadoReporte()
        FormatearSpreadTiposEntradas()

    End Sub

    Private Sub FormatearSpreadTiposEntradas()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 400
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "T  i  p  o  s      d  e      E  n  t  r  a  d  a  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre *".ToUpper()
        spVarios.ActiveSheet.Rows.Count += 1
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarTiposEntradas()

        EliminarTiposEntradas(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            If (id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                tiposEntradas.EId = id
                tiposEntradas.ENombre = nombre
                tiposEntradas.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarTiposEntradas()

    End Sub

    Private Sub EliminarTiposEntradas(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            tiposEntradas.EId = 0
            tiposEntradas.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarTiposEntradas()
        End If

    End Sub

    Private Sub SeleccionoTiposSalidas()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.tiposSalidas
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarTiposSalidas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarTiposSalidas()

        spVarios.Height = Me.altoTotal
        spVarios.Width = Me.anchoTotal
        spVarios.Top = Me.arriba
        spVarios.Left = Me.izquierda
        spVarios.Show()
        tiposSalidas.EId = 0
        spVarios.ActiveSheet.DataSource = tiposSalidas.ObtenerListadoReporte()
        FormatearSpreadTiposSalidas()

    End Sub

    Private Sub FormatearSpreadTiposSalidas()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 400
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "T  i  p  o  s      d  e      S  a  l  i  d  a  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre *".ToUpper()
        spVarios.ActiveSheet.Rows.Count += 1
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarTiposSalidas()

        EliminarTiposSalidas(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            If (id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                tiposSalidas.EId = id
                tiposSalidas.ENombre = nombre
                tiposSalidas.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarTiposSalidas()

    End Sub

    Private Sub EliminarTiposSalidas(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            tiposSalidas.EId = 0
            tiposSalidas.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarTiposSalidas()
        End If

    End Sub

    Private Sub SeleccionoEtiquetas()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.etiquetas
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarEtiquetas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarEtiquetas()

        AcomodarSpread()
        etiquetas.EId = 0
        spVarios.ActiveSheet.DataSource = etiquetas.ObtenerListado()
        FormatearSpreadEtiquetas()

    End Sub

    Private Sub FormatearSpreadEtiquetas()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "abreviatura" : numeracion += 1
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 400
        spVarios.ActiveSheet.Columns("abreviatura").Width = 160
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("abreviatura").CellType = tipoTexto
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "E  t  i  q  u  e  t  a  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("abreviatura").Index).Value = "Abreviatura".ToUpper()
        spVarios.ActiveSheet.Rows.Count += 1
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarEtiquetas()

        EliminarEtiquetas(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            Dim abreviatura As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("abreviatura").Index).Text
            If (id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                etiquetas.EId = id
                etiquetas.ENombre = nombre
                etiquetas.EAbreviatura = abreviatura
                etiquetas.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarEtiquetas()

    End Sub

    Private Sub EliminarEtiquetas(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            etiquetas.EId = 0
            etiquetas.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarEtiquetas()
        End If

    End Sub

    Private Sub SeleccionoTamaños()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.tamaños
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarTamaños()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarTamaños()

        AcomodarSpread()
        tamaños.EIdProducto = 0
        tamaños.EId = 0
        spVarios.ActiveSheet.DataSource = tamaños.ObtenerListadoReporte()
        FormatearSpreadTamaños()

    End Sub

    Private Sub FormatearSpreadTamaños()

        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "abreviatura" : numeracion += 1
        spVarios.ActiveSheet.Columns("idProducto").Width = 50
        spVarios.ActiveSheet.Columns("nombreProducto").Width = 250
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 300
        spVarios.ActiveSheet.Columns("abreviatura").Width = 150
        spVarios.ActiveSheet.Columns("idProducto").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombreProducto").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("abreviatura").CellType = tipoTexto
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "T  a  m  a  ñ  o  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("idProducto").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre Producto *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("abreviatura").Index).Value = "Abreviatura".ToUpper()
        spVarios.ActiveSheet.Columns(spVarios.ActiveSheet.Columns("nombreProducto").Index).Locked = True
        spVarios.ActiveSheet.Rows.Count += 1
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarTamaños()

        EliminarTamaños(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim idProducto As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("idProducto").Index).Text)
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Value
            Dim abreviatura As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("abreviatura").Index).Text
            If (idProducto > 0 AndAlso id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                tamaños.EIdProducto = idProducto
                tamaños.EId = id
                tamaños.ENombre = nombre
                tamaños.EAbreviatura = abreviatura
                tamaños.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarTamaños()

    End Sub

    Private Sub EliminarTamaños(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            tamaños.EIdProducto = 0
            tamaños.EId = 0
            tamaños.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarTamaños()
        End If

    End Sub

    Private Sub SeleccionoClientes()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = OpcionMenu.clientes
        OcultarSpreads()
        LimpiarSpread(spVarios)
        CargarClientes()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarClientes()

        AcomodarSpread()
        clientes.EId = 0
        spVarios.ActiveSheet.DataSource = clientes.ObtenerListadoReporte()
        FormatearSpreadClientes()

    End Sub

    Private Sub FormatearSpreadClientes()

        spVarios.ActiveSheet.Columns(0, spVarios.ActiveSheet.Columns.Count - 1).Locked = False
        spVarios.ActiveSheet.ColumnHeader.RowCount = 2
        spVarios.ActiveSheet.ColumnHeader.Rows(0, spVarios.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spVarios.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spVarios.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spVarios.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        ControlarSpreadEnterASiguienteColumna(spVarios)
        Dim numeracion As Integer = 0
        spVarios.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "rfc" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "domicilio" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "municipio" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "estado" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "telefono" : numeracion += 1
        spVarios.ActiveSheet.Columns(numeracion).Tag = "correo" : numeracion += 1
        spVarios.ActiveSheet.Columns("id").Width = 50
        spVarios.ActiveSheet.Columns("nombre").Width = 400
        spVarios.ActiveSheet.Columns("rfc").Width = 120
        spVarios.ActiveSheet.Columns("domicilio").Width = 300
        spVarios.ActiveSheet.Columns("municipio").Width = 200
        spVarios.ActiveSheet.Columns("estado").Width = 180
        spVarios.ActiveSheet.Columns("telefono").Width = 120
        spVarios.ActiveSheet.Columns("correo").Width = 150
        spVarios.ActiveSheet.Columns("id").CellType = tipoEntero
        spVarios.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("rfc").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("domicilio").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("municipio").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("estado").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("telefono").CellType = tipoTexto
        spVarios.ActiveSheet.Columns("correo").CellType = tipoTexto
        spVarios.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, spVarios.ActiveSheet.Columns.Count)
        spVarios.ActiveSheet.ColumnHeader.Cells(0, 0).Value = "C  l  i  e  n  t  e  s".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("id").Index).Value = "No. *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("nombre").Index).Value = "Nombre *".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("rfc").Index).Value = "Rfc".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("domicilio").Index).Value = "Domicilio".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("municipio").Index).Value = "Municipio".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("estado").Index).Value = "Estado".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("telefono").Index).Value = "Teléfono".ToUpper()
        spVarios.ActiveSheet.ColumnHeader.Cells(1, spVarios.ActiveSheet.Columns("correo").Index).Value = "Correo".ToUpper()
        spVarios.ActiveSheet.Rows.Count += 1
        Application.DoEvents()

    End Sub

    Private Sub GuardarEditarClientes()

        EliminarClientes(False)
        For fila As Integer = 0 To spVarios.ActiveSheet.Rows.Count - 1
            Dim id As Integer = EYELogicaCatalogos.Funciones.ValidarNumeroACero(spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("nombre").Index).Text
            Dim rfc As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("rfc").Index).Text
            Dim domicilio As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("domicilio").Index).Text
            Dim municipio As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("municipio").Index).Text
            Dim estado As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("estado").Index).Text
            Dim telefono As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("telefono").Index).Text
            Dim correo As String = spVarios.ActiveSheet.Cells(fila, spVarios.ActiveSheet.Columns("correo").Index).Text
            If (id > 0 AndAlso Not String.IsNullOrEmpty(nombre)) Then
                clientes.EId = id
                clientes.ENombre = nombre
                clientes.Erfc = rfc
                clientes.EDomicilio = domicilio
                clientes.EMunicipio = municipio
                clientes.EEstado = estado
                clientes.ETelefono = telefono
                clientes.ECorreo = correo
                clientes.Guardar()
            End If
        Next
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarClientes()

    End Sub

    Private Sub EliminarClientes(ByVal conMensaje As Boolean)

        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            clientes.EId = 0
            clientes.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            CargarClientes()
        End If

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Public Enum OpcionMenu

        lotes = 1
        productos = 2
        variedades = 3
        choferesCampos = 4
        productores = 5
        clientes = 6
        envases = 7
        tamaños = 8
        tiposEntradas = 9
        tiposSalidas = 10
        etiquetas = 11

    End Enum

#End Region

End Class