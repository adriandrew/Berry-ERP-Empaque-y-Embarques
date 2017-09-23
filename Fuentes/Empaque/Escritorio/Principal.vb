Imports System.IO
Imports System.ComponentModel
Imports System.Threading

Public Class Principal

    ' Variables de objetos de entidades.
    Public usuarios As New EYEEntidadesEmpaque.Usuarios()
    Public empaque As New EYEEntidadesEmpaque.Empaque()
    Public cajas As New EYEEntidadesEmpaque.Cajas()
    Public productores As New EYEEntidadesEmpaque.Productores()
    Public lotes As New EYEEntidadesEmpaque.Lotes()
    Public productos As New EYEEntidadesEmpaque.Productos()
    Public variedades As New EYEEntidadesEmpaque.Variedades()
    Public envases As New EYEEntidadesEmpaque.Envases()
    Public tamanos As New EYEEntidadesEmpaque.Tamanos()
    Public etiquetas As New EYEEntidadesEmpaque.Etiquetas()
    Public formatosEtiquetas As New EYEEntidadesEmpaque.FormatosEtiquetas()
    Public configuracionCajasPesoTarimas As New EYEEntidadesEmpaque.ConfiguracionCajasPesoTarimas()
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
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public estaMostrado As Boolean = False : Public estaCerrando As Boolean = False
    Public ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public prefijoBaseDatosEmpaque As String = "EYE" & "_"
    Public cantidadFilas As Integer = 1
    Public opcionCatalogoSeleccionada As Integer = -1
    Public opcionTipoSeleccionada As Integer = -1
    Public opcionEtiquetaTarimaSeleccionada As Integer = -1 : Public opcionEtiquetaCajaSeleccionada As Integer = 0
    Public esGuardadoValido As Boolean = True
    Public datosTarimasParaImprimir As New DataTable
    Public contadorTarimasParaImprimir As Integer = 0 : Public listaTarimasParaImprimir As New List(Of System.Data.DataRow)
    Public datosCajasParaImprimir As New DataTable
    Public contadorCajasParaImprimir As Integer = 0 : Public listaCajasParaImprimir As New List(Of System.Data.DataRow)
    Public estaImprimiendo As Boolean = False
    Public esIzquierda As Boolean = False
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
        FormatearSpreadTarimas()
        FormatearSpreadTotales()
        CargarFechaHora()
        CargarProductores()
        CargarFormatosEtiquetas()
        CargarOpcionesImpresion() 
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

    Private Sub spEmpaque_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spEmpaque.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter(spEmpaque)
        End If

    End Sub

    Private Sub spEmpaque_KeyDown(sender As Object, e As KeyEventArgs) Handles spEmpaque.KeyDown

        If (e.KeyData = Keys.F6) Then ' Eliminar un registro.
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                EliminarRegistroDeSpread(spEmpaque)
            End If
        ElseIf (e.KeyData = Keys.Enter) Then ' Validar registros.
            ControlarSpreadEnter(spEmpaque)
        ElseIf (e.KeyData = Keys.F5) Then ' Abrir catalogos. 
            CargarCatalogoEnSpread()
        ElseIf (e.KeyData = Keys.Escape) Then
            spEmpaque.ActiveSheet.SetActiveCell(0, 0)
            If (txtCantidad.Enabled) Then
                AsignarFoco(txtCantidad)
            Else
                AsignarFoco(cbProductores)
            End If
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        ValidarGuardado()
        If (Me.esGuardadoValido) Then
            GuardarEditarTarimas()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        EliminarTarimas(True)

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
                CargarTarimas()
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
                If (txtCantidad.Enabled) Then
                    AsignarFoco(txtCantidad)
                Else
                    AsignarFoco(spEmpaque)
                End If
            Else
                cbProductores.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtHora)
        ElseIf (e.KeyData = Keys.F5) Then ' Abrir catalogos.
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.productor
            CargarCatalogoEnOtros()
        End If

    End Sub

    Private Sub btnIdAnterior_Click(sender As Object, e As EventArgs) Handles btnIdAnterior.Click

        If (EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtId.Text) > 1) Then
            txtId.Text -= 1
            CargarTarimas()
        End If

    End Sub

    Private Sub btnIdSiguiente_Click(sender As Object, e As EventArgs) Handles btnIdSiguiente.Click

        If (EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtId.Text) >= 1) Then
            txtId.Text += 1
            CargarTarimas()
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

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (IsNumeric(txtCantidad.Text)) Then
                e.SuppressKeyPress = True
                AsignarFoco(spEmpaque)
            Else
                txtId.Text = 1
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            cbProductores.Focus()
        End If

    End Sub

    Private Sub spCatalogos_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos.CellClick

        Dim fila As Integer = e.Row
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.productor) Then
            CargarDatosEnOtrosDeCatalogos(fila)
        Else
            CargarDatosEnSpreadDeCatalogos(fila)
        End If

    End Sub

    Private Sub spCatalogos_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos.CellDoubleClick

        VolverFocoDeCatalogos()

    End Sub

    Private Sub spCatalogos_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            Dim fila As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
            If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.productor) Then
                CargarDatosEnOtrosDeCatalogos(fila)
            Else
                CargarDatosEnSpreadDeCatalogos(fila)
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then
            VolverFocoDeCatalogos()
        End If

    End Sub

    Private Sub btnConfigurarImpresion_Click(sender As Object, e As EventArgs) Handles btnConfigurarImpresion.Click

        Impresion.Show()
        Impresion.BringToFront()
        Me.Enabled = False

    End Sub

    Private Sub btnConfigurarImpresion_MouseEnter(sender As Object, e As EventArgs) Handles btnConfigurarImpresion.MouseEnter

        AsignarTooltips("Configurar Impresión.")

    End Sub

    Private Sub pdTarima_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pdTarima.PrintPage

        DefinirEtiquetaTarima(e)

    End Sub

    Private Sub pdCaja_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pdCaja.PrintPage

        DefinirEtiquetaCaja(e)

    End Sub

    Private Sub cbFormatoEtiquetaTarima_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFormatoEtiquetaTarima.SelectedIndexChanged

        If (Me.estaMostrado) Then
            Dim id As Integer = cbFormatoEtiquetaTarima.SelectedValue
            formatosEtiquetas.EIdTipo = OpcionTipoEtiqueta.tarima
            formatosEtiquetas.EId = id
            formatosEtiquetas.EditarPredeterminado()
            Me.opcionEtiquetaTarimaSeleccionada = id
        End If

    End Sub

    Private Sub cbFormatoEtiquetaCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFormatoEtiquetaCaja.SelectedIndexChanged

        If (Me.estaMostrado) Then
            Dim id As Integer = cbFormatoEtiquetaCaja.SelectedValue
            formatosEtiquetas.EIdTipo = OpcionTipoEtiqueta.caja
            formatosEtiquetas.EId = id
            formatosEtiquetas.EditarPredeterminado()
            Me.opcionEtiquetaCajaSeleccionada = id
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

    Private Sub txtBuscarCatalogo_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarCatalogo.TextChanged

        BuscarCatalogos()

    End Sub

    Private Sub txtBuscarCatalogo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarCatalogo.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            spCatalogos.Focus()
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
            Dim valorSpread As String = EYELogicaEmpaque.Funciones.ValidarLetra(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text & spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text).Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u")
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

    Private Sub MostrarOcultar()

        Dim anchoMenor As Integer = pnlCapturaSuperior.Width / 5
        Dim espacio As Integer = 1
        If (Not Me.esIzquierda) Then
            pnlCapturaSuperior.Left = -pnlCapturaSuperior.Width + anchoMenor
            spEmpaque.Left = anchoMenor + espacio
            spEmpaque.Width += anchoMenor * 4 - espacio
            spTotales.Left = spEmpaque.Left
            spTotales.Width = spEmpaque.Width
            Me.esIzquierda = True
        Else
            pnlCapturaSuperior.Left = 0
            spEmpaque.Left = pnlCapturaSuperior.Width + espacio
            spEmpaque.Width -= anchoMenor * 4 - espacio
            spTotales.Left = spEmpaque.Left
            spTotales.Width = spEmpaque.Width
            Me.esIzquierda = False
        End If

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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Teclas básicas: " & vbNewLine & "F5 sirve para mostrar catálogos. " & vbNewLine & "F6 sirve para eliminar un registro únicamente. " & vbNewLine & "Escape sirve para ocultar catálogos que se encuentren desplegados. " & vbNewLine & vbNewLine & "* Catálogos desplegados: " & vbNewLine & "Cuando se muestra algún catálogo, al seleccionar alguna opción de este, se va mostrando en tiempo real en la captura de donde se originó. Cuando se le da doble clic en alguna opción o a la tecla escape se oculta dicho catálogo. " & vbNewLine & vbNewLine & "* Datos obligatorios: " & vbNewLine & "Todos los que tengan el simbolo * son estrictamente obligatorios." & vbNewLine & vbNewLine & "* Captura:" & vbNewLine & "* Parte superior: " & vbNewLine & "En esta parte se capturarán todos los datos que son generales, tal cual como el número de la entrada, el almacén al que corresponde, etc." & vbNewLine & "* Parte inferior: " & vbNewLine & "En esta parte se capturarán todos los datos que pueden combinarse, por ejemplo los distintos artículos de ese número de entrada." & vbNewLine & vbNewLine & "* Existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. "
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

        If ((Not EYELogicaEmpaque.Usuarios.accesoTotal) Or (EYELogicaEmpaque.Usuarios.accesoTotal = 0) Or (EYELogicaEmpaque.Usuarios.accesoTotal = False)) Then
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
        tp.SetToolTip(Me.btnConfigurarImpresion, "Configurar Impresión.")
        tp.SetToolTip(Me.btnMostrarOcultar, "Mostrar u Ocultar.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            EYELogicaEmpaque.Directorios.id = 1
            EYELogicaEmpaque.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaEmpaque.Directorios.usuarioSql = "AdminBerry"
            EYELogicaEmpaque.Directorios.contrasenaSql = "@berry2017"
            pnlEncabezado.BackColor = Color.DarkRed
            pnlPie.BackColor = Color.DarkRed
        Else
            EYELogicaEmpaque.Directorios.ObtenerParametros()
            EYELogicaEmpaque.Usuarios.ObtenerParametros()
        End If
        EYELogicaEmpaque.Programas.bdCatalogo = "Catalogo" & EYELogicaEmpaque.Directorios.id
        EYELogicaEmpaque.Programas.bdConfiguracion = "Configuracion" & EYELogicaEmpaque.Directorios.id
        EYELogicaEmpaque.Programas.bdEmpaque = "Empaque" & EYELogicaEmpaque.Directorios.id
        EYEEntidadesEmpaque.BaseDatos.ECadenaConexionCatalogo = EYELogicaEmpaque.Programas.bdCatalogo
        EYEEntidadesEmpaque.BaseDatos.ECadenaConexionConfiguracion = EYELogicaEmpaque.Programas.bdConfiguracion
        EYEEntidadesEmpaque.BaseDatos.ECadenaConexionEmpaque = EYELogicaEmpaque.Programas.bdEmpaque
        EYEEntidadesEmpaque.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesEmpaque.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesEmpaque.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaEmpaque.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesEmpaque.Usuarios)
        usuarios.EId = EYELogicaEmpaque.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count = 1) Then
            EYELogicaEmpaque.Usuarios.id = lista(0).EId
            EYELogicaEmpaque.Usuarios.nombre = lista(0).ENombre
            EYELogicaEmpaque.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaEmpaque.Usuarios.nivel = lista(0).ENivel
            EYELogicaEmpaque.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarEncabezadosTitulos()

        lblEncabezadoPrograma.Text = "Programa: " & Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " & EYELogicaEmpaque.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " & EYELogicaEmpaque.Usuarios.nombre
        Me.Text = "Programa:  " & Me.nombreEstePrograma & "              Directorio:  " & EYELogicaEmpaque.Directorios.nombre & "              Usuario:  " & EYELogicaEmpaque.Usuarios.nombre
        hiloEncabezadosTitulos.Abort()

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & ".exe"
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = EYELogicaEmpaque.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmpaque.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmpaque.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmpaque.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmpaque.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmpaque.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmpaque.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmpaque.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaEmpaque.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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
        Me.arriba = spEmpaque.Top
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
        For fila = 0 To spEmpaque.ActiveSheet.Rows.Count - 1
            For columna = 0 To spEmpaque.ActiveSheet.Columns.Count - 1
                spEmpaque.ActiveSheet.Cells(fila, columna).BackColor = Color.White
            Next
        Next
        If (Not chkConservarDatos.Checked) Then
            cbProductores.SelectedIndex = 0
            dtpFecha.Value = Today
            txtHora.Text = Now.Hour.ToString().PadLeft(2, "0") & ":" & Now.Minute.ToString().PadLeft(2, "0")
            txtCantidad.Text = 1
            chkPropio.Checked = True
            chkSobrante.Checked = False
        End If
        spEmpaque.ActiveSheet.DataSource = Nothing
        spEmpaque.ActiveSheet.Rows.Count = 1
        spEmpaque.ActiveSheet.SetActiveCell(0, 0)
        LimpiarSpread(spEmpaque)
        LimpiarSpread(spTotales)
        HabilitarControles()

    End Sub

    Private Sub HabilitarControles()

        txtCantidad.Enabled = True
        btnGuardar.Enabled = True
        btnEliminar.Enabled = True

    End Sub

    Private Sub LimpiarSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        spread.ActiveSheet.ClearRange(0, 0, spread.ActiveSheet.Rows.Count, spread.ActiveSheet.Columns.Count, True)

    End Sub

    Private Sub CargarFechaHora()

        txtHora.Text = Now.Hour.ToString().PadLeft(2, "0") & ":" & Now.Minute.ToString().PadLeft(2, "0")

    End Sub

    Private Sub CargarProductores()

        cbProductores.DataSource = productores.ObtenerListadoReporte()
        cbProductores.DisplayMember = "IdNombre"
        cbProductores.ValueMember = "Id"

    End Sub

    Private Sub FormatearSpread()

        ' Se cargan tipos de datos de spread.
        CargarTiposDeDatos()
        ' Se cargan las opciones generales. 
        pnlCatalogos.Visible = False
        spEmpaque.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spTotales.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight
        spEmpaque.ActiveSheet.GrayAreaBackColor = Principal.colorAreaGris
        spTotales.ActiveSheet.GrayAreaBackColor = Principal.colorAreaGris
        spEmpaque.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spTotales.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spCatalogos.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spEmpaque.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spTotales.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spEmpaque.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spTotales.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spCatalogos.ActiveSheet.Rows(-1).Height = Principal.alturaFilasSpread
        spEmpaque.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spEmpaque.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spTotales.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spTotales.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always
        'spEntradas.EditModePermanent = True
        spEmpaque.EditModeReplace = True
        spTotales.Enabled = False
        Application.DoEvents()

    End Sub

    Private Sub CargarDatosEnSpreadDeCatalogos(ByVal filaCatalogos As Integer)

        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.lote) Then
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("idLote").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("nombreLote").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
        ElseIf (Me.opcionCatalogoSeleccionada = OpcionCatalogo.producto) Then
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("idProducto").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("nombreProducto").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
        ElseIf (Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad) Then
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("idProducto").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("idProducto").Index).Text
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("nombreProducto").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombreProducto").Index).Text
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("idVariedad").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("nombreVariedad").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
        ElseIf (Me.opcionCatalogoSeleccionada = OpcionCatalogo.envase) Then
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("idEnvase").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("nombreEnvase").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
        ElseIf (Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano) Then
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("idTamano").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("nombreTamano").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
        ElseIf (Me.opcionCatalogoSeleccionada = OpcionCatalogo.etiqueta) Then
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("idEtiqueta").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
            spEmpaque.ActiveSheet.Cells(spEmpaque.ActiveSheet.ActiveRowIndex, spEmpaque.ActiveSheet.Columns("nombreEtiqueta").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
        End If

    End Sub

    Private Sub CargarDatosEnOtrosDeCatalogos(ByVal filaCatalogos As Integer)

        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.productor) Then
            cbProductores.SelectedValue = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
        End If

    End Sub

    Private Sub CargarCatalogoEnSpread()

        pnlCapturaSuperior.Enabled = False
        spEmpaque.Enabled = False
        Dim columna As Integer = spEmpaque.ActiveSheet.ActiveColumnIndex
        Dim fila As Integer = spEmpaque.ActiveSheet.ActiveRowIndex
        If (columna = spEmpaque.ActiveSheet.Columns("idLote").Index) Or (columna = spEmpaque.ActiveSheet.Columns("nombreLote").Index) Then
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.lote
            lotes.EId = 0
            Dim datos As New DataTable
            datos = lotes.ObtenerListadoReporteCatalogo()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                pnlCapturaSuperior.Enabled = True
                spEmpaque.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.derecha)
        ElseIf (columna = spEmpaque.ActiveSheet.Columns("idProducto").Index) Or (columna = spEmpaque.ActiveSheet.Columns("nombreProducto").Index) Then
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.producto
            productos.EId = 0
            Dim datos As New DataTable
            datos = productos.ObtenerListadoReporteCatalogo()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                pnlCapturaSuperior.Enabled = True
                spEmpaque.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.derecha)
        ElseIf (columna = spEmpaque.ActiveSheet.Columns("idVariedad").Index) Or (columna = spEmpaque.ActiveSheet.Columns("nombreVariedad").Index) Then
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad
            Dim idProducto As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index).Text)
            variedades.EIdProducto = idProducto
            variedades.EId = 0
            Dim datos As New DataTable
            datos = variedades.ObtenerListadoReporteCatalogo()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                pnlCapturaSuperior.Enabled = True
                spEmpaque.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.derecha)
        ElseIf (columna = spEmpaque.ActiveSheet.Columns("idEnvase").Index) Or (columna = spEmpaque.ActiveSheet.Columns("nombreEnvase").Index) Then
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.envase
            envases.EId = 0
            Dim datos As New DataTable
            datos = envases.ObtenerListadoReporteCatalogo()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                pnlCapturaSuperior.Enabled = True
                spEmpaque.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.derecha)
        ElseIf (columna = spEmpaque.ActiveSheet.Columns("idTamano").Index) Or (columna = spEmpaque.ActiveSheet.Columns("nombreTamano").Index) Then
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano
            Dim idProducto As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index).Text)
            tamanos.EIdProducto = idProducto
            tamanos.EId = 0
            Dim datos As New DataTable
            datos = tamanos.ObtenerListadoReporteCatalogo()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                pnlCapturaSuperior.Enabled = True
                spEmpaque.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.derecha)
        ElseIf (columna = spEmpaque.ActiveSheet.Columns("idEtiqueta").Index) Or (columna = spEmpaque.ActiveSheet.Columns("nombreEtiqueta").Index) Then
            Me.opcionCatalogoSeleccionada = OpcionCatalogo.etiqueta
            etiquetas.EId = 0
            Dim datos As New DataTable
            datos = etiquetas.ObtenerListadoReporteCatalogo()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                pnlCapturaSuperior.Enabled = True
                spEmpaque.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.derecha)
        Else
            pnlCapturaSuperior.Enabled = True
            spEmpaque.Enabled = True
        End If
        txtBuscarCatalogo.Focus()

    End Sub

    Private Sub CargarCatalogoEnOtros()

        pnlCapturaSuperior.Enabled = False
        spEmpaque.Enabled = False
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.productor) Then
            productores.EId = 0
            Dim datos As New DataTable
            datos = productores.ObtenerListadoReporteCatalogo()
            If (datos.Rows.Count > 0) Then
                spCatalogos.ActiveSheet.DataSource = datos
            Else
                spCatalogos.ActiveSheet.DataSource = Nothing
                spCatalogos.ActiveSheet.Rows.Count = 0
                pnlCapturaSuperior.Enabled = True
                spEmpaque.Enabled = True
            End If
            FormatearSpreadCatalogo(OpcionPosicion.centro)
        End If
        txtBuscarCatalogo.Focus()

    End Sub

    Private Sub FormatearSpreadCatalogo(ByVal posicion As Integer)

        spCatalogos.Height = Me.altoTotal
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad Or Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano) Then
            spCatalogos.Width = 850
            spCatalogos.ActiveSheet.Columns.Count = 4
        Else
            spCatalogos.Width = 500
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
        spCatalogos.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Dim numeracion As Integer = 0
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad Or Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano) Then
            spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
            spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        End If
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad Or Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano) Then
            spCatalogos.ActiveSheet.Columns("idProducto").Width = 50
            spCatalogos.ActiveSheet.Columns("nombreProducto").Width = 300
        End If
        spCatalogos.ActiveSheet.Columns("id").Width = 70
        spCatalogos.ActiveSheet.Columns("nombre").Width = 370
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad Or Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano) Then
            spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("idProducto").Index).Value = "No.".ToUpper
            spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre Producto".ToUpper
        End If
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        pnlCatalogos.Height = Me.altoTotal
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

        pnlCapturaSuperior.Enabled = True
        spEmpaque.Enabled = True
        If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.productor) Then
            AsignarFoco(cbProductores)
        Else
            AsignarFoco(spEmpaque)
        End If
        txtBuscarCatalogo.Clear()
        pnlCatalogos.Visible = False

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
        If (spread.Name = spEmpaque.Name) Then
            Dim fila As Integer = 0
            If (columnaActiva = spEmpaque.ActiveSheet.Columns("idLote").Index) Then
                fila = spEmpaque.ActiveSheet.ActiveRowIndex
                Dim idLote As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idLote").Index).Value)
                If (idLote > 0) Then
                    Dim datosLotes As New DataTable
                    lotes.EId = idLote
                    datosLotes = lotes.ObtenerListado()
                    If (datosLotes.Rows.Count > 0) Then
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("nombreLote").Index).Value = datosLotes.Rows(0).Item("Nombre")
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1)
                    Else
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                    End If
                Else
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                    spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spEmpaque.ActiveSheet.Columns("idProducto").Index) Then
                fila = spEmpaque.ActiveSheet.ActiveRowIndex
                Dim idProducto As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index).Value)
                If (idProducto > 0) Then
                    Dim datosProductos As New DataTable
                    productos.EId = idProducto
                    datosProductos = productos.ObtenerListado()
                    If (datosProductos.Rows.Count > 0) Then
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("nombreProducto").Index).Value = datosProductos.Rows(0).Item("Nombre")
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1)
                    Else
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                    End If
                Else
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                    spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spEmpaque.ActiveSheet.Columns("idVariedad").Index) Then
                fila = spEmpaque.ActiveSheet.ActiveRowIndex
                Dim idProducto As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index).Value)
                Dim idVariedad As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idVariedad").Index).Value)
                If (idProducto > 0 AndAlso idVariedad > 0) Then
                    Dim datosVariedades As New DataTable
                    variedades.EIdProducto = idProducto
                    variedades.EId = idVariedad
                    datosVariedades = variedades.ObtenerListado()
                    If (datosVariedades.Rows.Count > 0) Then
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("nombreVariedad").Index).Value = datosVariedades.Rows(0).Item("Nombre")
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1)
                    Else
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                    End If
                Else
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                    spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spEmpaque.ActiveSheet.Columns("idEnvase").Index) Then
                fila = spEmpaque.ActiveSheet.ActiveRowIndex
                Dim idProducto As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index).Value)
                Dim idEnvase As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEnvase").Index).Value)
                If (idEnvase > 0) Then
                    Dim datosEnvases As New DataTable
                    envases.EId = idEnvase
                    datosEnvases = envases.ObtenerListado()
                    If (datosEnvases.Rows.Count = 1) Then
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("nombreEnvase").Index).Value = datosEnvases.Rows(0).Item("Nombre")
                        'Dim cantidadCajas As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Value)
                        Dim pesoUnitarioCajas As Double = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Value)
                        If (pesoUnitarioCajas <= 0) Then
                            ' Se carga la cantidad de cajas y peso desde la configuracion por tarima.
                            Dim datosCajasPesoTarimas As New DataTable
                            configuracionCajasPesoTarimas.EIdProducto = idProducto
                            configuracionCajasPesoTarimas.EIdEnvase = idEnvase
                            datosCajasPesoTarimas = configuracionCajasPesoTarimas.ObtenerListadoReporte()
                            If (datosCajasPesoTarimas.Rows.Count > 0) Then
                                Dim cajasConfiguradas As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(datosCajasPesoTarimas.Rows(0).Item("CantidadCajas").ToString)
                                Dim pesoConfigurado As Double = EYELogicaEmpaque.Funciones.ValidarNumeroACero(datosCajasPesoTarimas.Rows(0).Item("PesoUnitarioCajas").ToString)
                                ' Se carga el peso unitario del envase configurado anteriormente desde catálogos. NO APLICADO.
                                'Dim pesoEnvase As Double = listaEnvases(0).EPeso ' NO APLICADO.
                                spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Value = cajasConfiguradas
                                spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Value = pesoConfigurado
                                spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).Value = cajasConfiguradas * pesoConfigurado
                            End If
                        End If
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1)
                    Else
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                    End If
                Else
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                    spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spEmpaque.ActiveSheet.Columns("idTamano").Index) Then
                fila = spEmpaque.ActiveSheet.ActiveRowIndex
                Dim idProducto As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index).Value)
                Dim idTamano As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idTamano").Index).Value)
                If (idProducto > 0) Then
                    Dim datosTamanos As New DataTable
                    tamanos.EIdProducto = idProducto
                    tamanos.EId = idTamano
                    datosTamanos = tamanos.ObtenerListado()
                    If (datosTamanos.Rows.Count > 0) Then
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("nombreTamano").Index).Value = datosTamanos.Rows(0).Item("Nombre")
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1)
                    Else
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                    End If
                Else
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                    spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spEmpaque.ActiveSheet.Columns("idEtiqueta").Index) Then
                fila = spEmpaque.ActiveSheet.ActiveRowIndex
                Dim idEtiqueta As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEtiqueta").Index).Value)
                If (idEtiqueta > 0) Then
                    Dim datosEtiquetas As New DataTable
                    etiquetas.EId = idEtiqueta
                    datosEtiquetas = etiquetas.ObtenerListado()
                    If (datosEtiquetas.Rows.Count > 0) Then
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("nombreEtiqueta").Index).Value = datosEtiquetas.Rows(0).Item("Nombre")
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1)
                    Else
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                        spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                    End If
                Else
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex + 1).Text = String.Empty
                    spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spEmpaque.ActiveSheet.Columns("cantidadCajas").Index) Then
                fila = spEmpaque.ActiveSheet.ActiveRowIndex
                Dim cantidadCajas As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Value)
                If (cantidadCajas > 0) Then
                    Dim pesoUnitarioCajas As Double = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Value)
                    If (pesoUnitarioCajas > 0) Then
                        spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).Value = cantidadCajas * pesoUnitarioCajas
                    End If
                Else
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                    spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                End If
            ElseIf (columnaActiva = spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index) Then
                fila = spEmpaque.ActiveSheet.ActiveRowIndex
                Dim cantidadCajas As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Value)
                Dim pesoUnitarioCajas As Double = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Value)
                If (pesoUnitarioCajas <= 0) Then
                    spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                Else
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).Value = cantidadCajas * pesoUnitarioCajas
                End If
            ElseIf (columnaActiva = spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index) Then
                fila = spEmpaque.ActiveSheet.ActiveRowIndex
                Dim cantidadCajas As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Value)
                Dim pesoCajas As Double = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).Value)
                If (pesoCajas > 0) Then
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Value = pesoCajas / cantidadCajas
                Else
                    spEmpaque.ActiveSheet.SetActiveCell(fila, spEmpaque.ActiveSheet.ActiveColumnIndex - 1)
                End If
            End If
            CalcularTotales()
        End If

    End Sub

    Private Sub CalcularTotales()

        Dim total As Double = 0
        For columna = 0 To spEmpaque.ActiveSheet.Columns.Count - 1
            If (columna = spEmpaque.ActiveSheet.Columns("cantidadCajas").Index Or columna = spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index) Then
                For fila = 0 To spEmpaque.ActiveSheet.Rows.Count - 1
                    total += EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, columna).Text)
                Next
                spTotales.ActiveSheet.Cells(0, columna).Text = total
                total = 0
            End If
        Next
        spTotales.Refresh()
        spTotales.ActiveSheet.Cells(0, spTotales.ActiveSheet.Columns("total").Index).Text = "Total".ToUpper
        spTotales.ActiveSheet.Cells(0, spTotales.ActiveSheet.Columns("total").Index).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        spTotales.ActiveSheet.Cells(0, 0, 0, spTotales.ActiveSheet.Columns.Count - 1).BackColor = Color.Gainsboro

    End Sub

    Private Sub CargarIdConsecutivo()

        Dim idMaximo As Integer = empaque.ObtenerMaximoId()
        txtId.Text = idMaximo

    End Sub

    Private Sub CargarTarimas()

        Me.Cursor = Cursors.WaitCursor
        empaque.EId = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtId.Text)
        If (empaque.EId > 0) Then
            Dim datosTarimas As New DataTable
            datosTarimas = empaque.ObtenerListado()
            If (datosTarimas.Rows.Count > 0) Then
                txtCantidad.Text = "1"
                txtCantidad.Enabled = False
                dtpFecha.Value = datosTarimas.Rows(0).Item("Fecha")
                txtHora.Text = Mid(datosTarimas.Rows(0).Item("Hora").ToString, 1, 5)
                cbProductores.SelectedValue = datosTarimas.Rows(0).Item("IdProductor")
                chkPropio.Checked = datosTarimas.Rows(0).Item("EsPropio")
                chkSobrante.Checked = datosTarimas.Rows(0).Item("EsSobrante")
                If (datosTarimas.Rows(0).Item("EstaEmbarcado")) Then
                    btnGuardar.Enabled = False
                    btnEliminar.Enabled = False
                Else
                    btnGuardar.Enabled = True
                    btnEliminar.Enabled = True
                End If
                spEmpaque.ActiveSheet.DataSource = empaque.ObtenerListadoReporte()
                cantidadFilas = spEmpaque.ActiveSheet.Rows.Count + 1
                FormatearSpreadTarimas()
            Else
                LimpiarPantalla()
            End If
        End If
        CalcularTotales()
        AsignarFoco(dtpFecha)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FormatearSpreadTarimas()

        spEmpaque.ActiveSheet.ColumnHeader.RowCount = 2
        spEmpaque.ActiveSheet.ColumnHeader.Rows(0, spEmpaque.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spEmpaque.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spEmpaque.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spEmpaque.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        spEmpaque.ActiveSheet.Rows.Count = cantidadFilas
        ControlarSpreadEnterASiguienteColumna(spEmpaque)
        Dim numeracion As Integer = 0
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "idLote" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "nombreLote" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "idVariedad" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "nombreVariedad" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "idEnvase" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "nombreEnvase" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "idTamano" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "nombreTamano" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "idEtiqueta" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "nombreEtiqueta" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "pesoUnitarioCajas" : numeracion += 1
        spEmpaque.ActiveSheet.Columns(numeracion).Tag = "pesoTotalCajas" : numeracion += 1
        spEmpaque.ActiveSheet.Columns.Count = numeracion
        spEmpaque.ActiveSheet.Columns("idLote").Width = 50
        spEmpaque.ActiveSheet.Columns("nombreLote").Width = 150
        spEmpaque.ActiveSheet.Columns("idProducto").Width = 50
        spEmpaque.ActiveSheet.Columns("nombreProducto").Width = 150
        spEmpaque.ActiveSheet.Columns("idVariedad").Width = 50
        spEmpaque.ActiveSheet.Columns("nombreVariedad").Width = 150
        spEmpaque.ActiveSheet.Columns("idEnvase").Width = 50
        spEmpaque.ActiveSheet.Columns("nombreEnvase").Width = 150
        spEmpaque.ActiveSheet.Columns("idTamano").Width = 50
        spEmpaque.ActiveSheet.Columns("nombreTamano").Width = 150
        spEmpaque.ActiveSheet.Columns("idEtiqueta").Width = 50
        spEmpaque.ActiveSheet.Columns("nombreEtiqueta").Width = 150
        spEmpaque.ActiveSheet.Columns("cantidadCajas").Width = 110
        spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Width = 100
        spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Width = 100
        spEmpaque.ActiveSheet.Columns("idLote").CellType = tipoEntero
        spEmpaque.ActiveSheet.Columns("nombreLote").CellType = tipoTexto
        spEmpaque.ActiveSheet.Columns("idProducto").CellType = tipoEntero
        spEmpaque.ActiveSheet.Columns("nombreProducto").CellType = tipoTexto
        spEmpaque.ActiveSheet.Columns("idVariedad").CellType = tipoEntero
        spEmpaque.ActiveSheet.Columns("nombreVariedad").CellType = tipoTexto
        spEmpaque.ActiveSheet.Columns("idTamano").CellType = tipoEntero
        spEmpaque.ActiveSheet.Columns("nombreTamano").CellType = tipoTexto
        spEmpaque.ActiveSheet.Columns("idEnvase").CellType = tipoEntero
        spEmpaque.ActiveSheet.Columns("nombreEnvase").CellType = tipoTexto
        spEmpaque.ActiveSheet.Columns("idEtiqueta").CellType = tipoEntero
        spEmpaque.ActiveSheet.Columns("nombreEtiqueta").CellType = tipoTexto
        spEmpaque.ActiveSheet.Columns("cantidadCajas").CellType = tipoEntero
        spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").CellType = tipoDoble
        spEmpaque.ActiveSheet.Columns("pesoTotalCajas").CellType = tipoDoble
        spEmpaque.ActiveSheet.AddColumnHeaderSpanCell(0, spEmpaque.ActiveSheet.Columns("idLote").Index, 1, 2)
        spEmpaque.ActiveSheet.ColumnHeader.Cells(0, spEmpaque.ActiveSheet.Columns("idLote").Index).Value = "L o t e".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("idLote").Index).Value = "No *".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("nombreLote").Index).Value = "Nombre *".ToUpper()
        spEmpaque.ActiveSheet.AddColumnHeaderSpanCell(0, spEmpaque.ActiveSheet.Columns("idProducto").Index, 1, 2)
        spEmpaque.ActiveSheet.ColumnHeader.Cells(0, spEmpaque.ActiveSheet.Columns("idProducto").Index).Value = "P r o d u c t o".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("idProducto").Index).Value = "No *".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre *".ToUpper()
        spEmpaque.ActiveSheet.AddColumnHeaderSpanCell(0, spEmpaque.ActiveSheet.Columns("idVariedad").Index, 1, 2)
        spEmpaque.ActiveSheet.ColumnHeader.Cells(0, spEmpaque.ActiveSheet.Columns("idVariedad").Index).Value = "V a r i e d a d".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("idVariedad").Index).Value = "No *".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("nombreVariedad").Index).Value = "Nombre *".ToUpper()
        spEmpaque.ActiveSheet.AddColumnHeaderSpanCell(0, spEmpaque.ActiveSheet.Columns("idEnvase").Index, 1, 2)
        spEmpaque.ActiveSheet.ColumnHeader.Cells(0, spEmpaque.ActiveSheet.Columns("idEnvase").Index).Value = "E n v a s e".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("idEnvase").Index).Value = "No *".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("nombreEnvase").Index).Value = "Nombre *".ToUpper()
        spEmpaque.ActiveSheet.AddColumnHeaderSpanCell(0, spEmpaque.ActiveSheet.Columns("idTamano").Index, 1, 2)
        spEmpaque.ActiveSheet.ColumnHeader.Cells(0, spEmpaque.ActiveSheet.Columns("idTamano").Index).Value = "T a m a ñ o".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("idTamano").Index).Value = "No *".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("nombreTamano").Index).Value = "Nombre *".ToUpper()
        spEmpaque.ActiveSheet.AddColumnHeaderSpanCell(0, spEmpaque.ActiveSheet.Columns("idEtiqueta").Index, 1, 2)
        spEmpaque.ActiveSheet.ColumnHeader.Cells(0, spEmpaque.ActiveSheet.Columns("idEtiqueta").Index).Value = "E t i q u e t a".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("idEtiqueta").Index).Value = "No *".ToUpper()
        spEmpaque.ActiveSheet.ColumnHeader.Cells(1, spEmpaque.ActiveSheet.Columns("nombreEtiqueta").Index).Value = "Nombre *".ToUpper()
        spEmpaque.ActiveSheet.AddColumnHeaderSpanCell(0, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index, 2, 1)
        spEmpaque.ActiveSheet.ColumnHeader.Cells(0, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Value = "Cantidad Cajas *".ToUpper()
        spEmpaque.ActiveSheet.AddColumnHeaderSpanCell(0, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index, 2, 1)
        spEmpaque.ActiveSheet.ColumnHeader.Cells(0, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Value = "Peso Unitario Libras *".ToUpper()
        spEmpaque.ActiveSheet.AddColumnHeaderSpanCell(0, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index, 2, 1)
        spEmpaque.ActiveSheet.ColumnHeader.Cells(0, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).Value = "Peso Total *".ToUpper()
        spEmpaque.ActiveSheet.Columns("nombreLote").Locked = True
        spEmpaque.ActiveSheet.Columns("nombreProducto").Locked = True
        spEmpaque.ActiveSheet.Columns("nombreVariedad").Locked = True
        spEmpaque.ActiveSheet.Columns("nombreEnvase").Locked = True
        spEmpaque.ActiveSheet.Columns("nombreTamano").Locked = True
        spEmpaque.ActiveSheet.Columns("nombreEtiqueta").Locked = True
        spEmpaque.Refresh()

    End Sub

    Private Sub FormatearSpreadTotales()

        spTotales.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spTotales.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Dim numeracion As Integer = 0
        spTotales.ActiveSheet.Columns(numeracion).Tag = "total" : numeracion += 1
        spTotales.ActiveSheet.Columns(spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Tag = "cantidadCajas" : numeracion += 1
        spTotales.ActiveSheet.Columns(spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Tag = "pesoUnitarioCajas" : numeracion += 1
        spTotales.ActiveSheet.Columns(spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).Tag = "pesoTotalCajas" : numeracion += 1
        spTotales.ActiveSheet.Columns.Count = spEmpaque.ActiveSheet.Columns.Count
        spTotales.ActiveSheet.AddSpanCell(0, spTotales.ActiveSheet.Columns("total").Index, 1, spTotales.ActiveSheet.Columns("cantidadCajas").Index)
        spTotales.ActiveSheet.Columns(spTotales.ActiveSheet.Columns("total").Index, spTotales.ActiveSheet.Columns("cantidadCajas").Index - 1).Width = 0
20:     spTotales.ActiveSheet.Columns("total").Width = 1200
        spTotales.ActiveSheet.Columns("cantidadCajas").Width = spEmpaque.ActiveSheet.Columns("cantidadCajas").Width
        spTotales.ActiveSheet.Columns("pesoUnitarioCajas").Width = spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Width
        spTotales.ActiveSheet.Columns("pesoTotalCajas").Width = spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Width
        spTotales.ActiveSheet.Columns("total").CellType = tipoTexto
        spTotales.ActiveSheet.Columns("cantidadCajas").CellType = spEmpaque.ActiveSheet.Columns("cantidadCajas").CellType
        spTotales.ActiveSheet.Columns("pesoUnitarioCajas").CellType = spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").CellType
        spTotales.ActiveSheet.Columns("pesoTotalCajas").CellType = spEmpaque.ActiveSheet.Columns("pesoTotalCajas").CellType
        spTotales.ActiveSheet.ColumnHeader.Visible = False
        spTotales.Refresh()

    End Sub

    Private Sub ValidarGuardado()

        Me.Cursor = Cursors.WaitCursor
        Me.esGuardadoValido = True
        ' Parte superior. 
        Dim id As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtId.Text)
        If (id <= 0) Then
            txtId.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim datosTarimasParaValidar As New DataTable
        empaque.EId = id
        datosTarimasParaValidar = empaque.ObtenerParaValidar()
        If (datosTarimasParaValidar.Rows.Count > 0) Then
            If (datosTarimasParaValidar.Rows(0).Item("EstaEmbarcado")) Then
                MsgBox(String.Format("Esta tarima ya fue embarcada en el embarque número {0}, en la posición {1}, con destino de {2}.", datosTarimasParaValidar.Rows(0).Item("IdEmbarque"), datosTarimasParaValidar.Rows(0).Item("OrdenEmbarque") + 1, IIf(datosTarimasParaValidar.Rows(0).Item("IdTipoEmbarque") = 1, "exportación", "nacional")), MsgBoxStyle.Exclamation, "No permitido.")
                Me.esGuardadoValido = False
            End If
        End If
        Dim hora As String = txtHora.Text
        If (String.IsNullOrEmpty(hora) Or hora.Length <> 5) Then
            txtHora.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idProductor As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(cbProductores.SelectedValue)
        If (idProductor <= 0) Then
            cbProductores.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim cantidad As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtCantidad.Text)
        If (cantidad <= 0) Then
            txtCantidad.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        ' Parte inferior.
        For fila As Integer = 0 To spEmpaque.ActiveSheet.Rows.Count - 1
            Dim cantidadCajas As String = spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Text
            Dim cantidadCajas2 As Double = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Text)
            If (Not String.IsNullOrEmpty(cantidadCajas) Or cantidadCajas2 > 0) Then
                Dim idLote As String = spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idLote").Index).Text
                Dim idLote2 As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idLote").Index).Text)
                If (String.IsNullOrEmpty(idLote) Or idLote2 < 0) Then
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idLote").Index, fila, spEmpaque.ActiveSheet.Columns("nombreLote").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
                Dim idProducto As String = spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index).Text
                Dim idProducto2 As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index).Text)
                If (String.IsNullOrEmpty(idProducto) Or idProducto2 < 0) Then
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index, fila, spEmpaque.ActiveSheet.Columns("nombreProducto").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
                Dim idVariedad As String = spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idVariedad").Index).Text
                Dim idVariedad2 As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idVariedad").Index).Text)
                If (String.IsNullOrEmpty(idVariedad) Or idVariedad2 < 0) Then
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idVariedad").Index, fila, spEmpaque.ActiveSheet.Columns("nombreVariedad").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
                Dim idEnvase As String = spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEnvase").Index).Text
                Dim idEnvase2 As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEnvase").Index).Text)
                If (String.IsNullOrEmpty(idEnvase) Or idEnvase2 < 0) Then
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEnvase").Index, fila, spEmpaque.ActiveSheet.Columns("nombreEnvase").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
                Dim idTamano As String = spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idTamano").Index).Text
                Dim idTamano2 As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idTamano").Index).Text)
                If (String.IsNullOrEmpty(idTamano) Or idTamano2 < 0) Then
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idTamano").Index, fila, spEmpaque.ActiveSheet.Columns("nombreTamano").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
                Dim idEtiqueta As String = spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEtiqueta").Index).Text
                Dim idEtiqueta2 As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEtiqueta").Index).Text)
                If (String.IsNullOrEmpty(idEtiqueta) Or idEtiqueta2 < 0) Then
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEtiqueta").Index, fila, spEmpaque.ActiveSheet.Columns("nombreEtiqueta").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
                Dim pesoUnitarioCajas As String = spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Text
                Dim pesoUnitarioCajas2 As Double = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Text)
                If (String.IsNullOrEmpty(pesoUnitarioCajas) Or pesoUnitarioCajas2 < 0) Then
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
                Dim pesoCajas As String = spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).Text
                Dim pesoCajas2 As Double = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).Text)
                If (String.IsNullOrEmpty(pesoCajas) Or pesoCajas2 < 0) Then
                    spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
            End If
        Next
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GuardarEditarTarimas()

        Me.Cursor = Cursors.WaitCursor
        Dim hilo As New Thread(AddressOf MandarImprimir)
        For cantidad As Integer = 1 To txtCantidad.Text ' Cantidad de tarimas a generar.
            EliminarTarimas(False)
            ' Parte superior. 
            Dim id As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtId.Text)
            EliminarCajas(id)
            Dim fecha As Date = dtpFecha.Value
            Dim hora As String = txtHora.Text
            Dim idProductor As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(cbProductores.SelectedValue)
            Dim esPropio As Boolean = chkPropio.Checked
            Dim esSobrante As Boolean = chkSobrante.Checked
            Dim observaciones As String = String.Empty ' Pendiente
            ' Datos no capturables por el usuario.
            Dim idEmbarcador As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(cbProductores.SelectedValue) ' El mismo que el productor por defecto.
            Dim claveAgricola As String = String.Empty
            Dim datosProductores As New DataTable
            productores.EId = idEmbarcador
            datosProductores = productores.ObtenerListado()
            If (datosProductores.Rows.Count > 0) Then
                claveAgricola = datosProductores.Rows(0).Item("ClaveAgricola")
            End If
            Dim diaJuliano As String = (DatePart(DateInterval.DayOfYear, CDate(fecha))).ToString.PadLeft(3, "0")
            diaJuliano = Mid(diaJuliano, 3, 1) & Mid(diaJuliano, 2, 1) & Mid(diaJuliano, 1, 1) & Mid((Year(fecha).ToString), 4, 1)
            Dim idCliente As Integer = 0
            Dim temperatura As Integer = 0
            Dim esTrazable As Boolean = False
            Dim estaEmbarcado As Boolean = False
            Dim idEmbarque As Integer = 0
            Dim idTipoEmbarque As Integer = 0 ' Siempre es cero, significa que no está en piso.
            Dim ordenEmbarque As Integer = 0
            For fila As Integer = 0 To spEmpaque.ActiveSheet.Rows.Count - 1
                Dim idLote As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idLote").Index).Text)
                Dim idProducto As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idProducto").Index).Text)
                Dim idVariedad As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idVariedad").Index).Text)
                Dim idEnvase As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEnvase").Index).Text)
                Dim idTamano As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idTamano").Index).Text)
                Dim idEtiqueta As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("idEtiqueta").Index).Text)
                Dim cantidadCajas As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("cantidadCajas").Index).Text)
                Dim pesoUnitarioCajas As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoUnitarioCajas").Index).Text)
                Dim pesoCajas As Integer = EYELogicaEmpaque.Funciones.ValidarNumeroACero(spEmpaque.ActiveSheet.Cells(fila, spEmpaque.ActiveSheet.Columns("pesoTotalCajas").Index).Text)
                If (id > 0 AndAlso IsDate(fecha) And Not String.IsNullOrEmpty(txtHora.Text) AndAlso idProductor > 0 AndAlso idLote > 0 AndAlso idProducto > 0 AndAlso idVariedad > 0 AndAlso idEnvase > 0 AndAlso idTamano > 0 AndAlso idEtiqueta > 0 AndAlso cantidadCajas > 0 AndAlso pesoUnitarioCajas > 0 AndAlso pesoCajas > 0) Then
                    empaque.EId = id
                    empaque.EIdProductor = idProductor
                    empaque.EIdEmbarcador = idEmbarcador
                    empaque.EIdCliente = idCliente
                    empaque.EIdLote = idLote
                    empaque.EIdProducto = idProducto
                    empaque.EIdVariedad = idVariedad
                    empaque.EIdEnvase = idEnvase
                    empaque.EIdTamano = idTamano
                    empaque.EIdEtiqueta = idEtiqueta
                    empaque.EFecha = fecha
                    empaque.EHora = hora
                    empaque.ECantidadCajas = cantidadCajas
                    empaque.EPesoUnitarioCajas = pesoUnitarioCajas
                    empaque.EPesoTotalCajas = pesoCajas
                    empaque.ETemperatura = temperatura
                    empaque.EObservaciones = observaciones
                    empaque.EEsPropio = esPropio
                    empaque.EEsSobrante = esSobrante
                    empaque.EEsTrazable = esTrazable
                    empaque.EOrden = fila
                    empaque.EEstaEmbarcado = estaEmbarcado
                    empaque.EIdEmbarque = idEmbarque
                    empaque.EIdTipoEmbarque = idTipoEmbarque
                    empaque.EOrdenEmbarque = ordenEmbarque
                    empaque.Guardar()
                    For indice = 0 To cantidadCajas - 1
                        GuardarTrazabilidad(id, diaJuliano, claveAgricola, indice, fila)
                    Next
                    ' TODO. Se tiene que dar salida en almacén.
                    ' GuardarSalidaAlmacen() 
                End If
            Next
            If (Not chkSobrante.Checked) Then
                Me.opcionTipoSeleccionada = OpcionTipoEtiqueta.tarima
                PrepararImpresion(id)
                Me.opcionTipoSeleccionada = OpcionTipoEtiqueta.caja
                PrepararImpresion(id)
            End If
            txtId.Text += 1 ' Se suma uno, para generar la siguiente tarima.
        Next
        If (Not chkSobrante.Checked) Then
            hilo.Start()
        End If
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        LimpiarPantalla()
        CargarIdConsecutivo()
        AsignarFoco(txtId)
        If (Not Me.estaImprimiendo) Then
            hilo.Abort()
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EliminarTarimas(ByVal conMensaje As Boolean)

        Me.Cursor = Cursors.WaitCursor
        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar esta tarima?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            empaque.EId = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtId.Text)
            empaque.Eliminar()
        End If
        If (conMensaje And respuestaSi) Then
            MessageBox.Show("Eliminado finalizado.", "Finalizado.", MessageBoxButtons.OK)
            LimpiarPantalla()
            CargarIdConsecutivo()
            AsignarFoco(txtId)
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GuardarTrazabilidad(ByVal idTarima As Integer, ByVal diaJuliano As String, ByVal claveAgricola As String, ByVal orden As Integer, ByVal ordenTarima As Integer)

        cajas.EIdTarima = idTarima
        cajas.EDiaJuliano = diaJuliano
        cajas.EClaveAgricola = claveAgricola
        Dim idConsecutivo As Integer = cajas.ObtenerMaximoId()
        cajas.EId = idConsecutivo
        cajas.EOrden = orden
        cajas.EOrdenTarima = ordenTarima
        cajas.Guardar()

    End Sub

    Private Sub EliminarCajas(ByVal idTarima As Integer)

        cajas.EIdTarima = idTarima
        cajas.Eliminar()

    End Sub

    Private Sub CargarFormatosEtiquetas()

        Dim listaFormatosEtiquetas As New DataTable
        ' Etiquetas de tarimas. 
        formatosEtiquetas.EIdTipo = OpcionTipoEtiqueta.tarima
        cbFormatoEtiquetaTarima.DataSource = formatosEtiquetas.ObtenerListadoReporte()
        cbFormatoEtiquetaTarima.DisplayMember = "Nombre"
        cbFormatoEtiquetaTarima.ValueMember = "Id"
        listaFormatosEtiquetas = formatosEtiquetas.ObtenerListado()
        For indice = 0 To listaFormatosEtiquetas.Rows.Count - 1
            If (listaFormatosEtiquetas.Rows(indice).Item("Predeterminado")) Then 
                cbFormatoEtiquetaTarima.SelectedValue = listaFormatosEtiquetas.Rows(indice).Item("Id")
            End If
        Next
        ' Etiquetas de cajas.
        listaFormatosEtiquetas.Clear()
        formatosEtiquetas.EIdTipo = OpcionTipoEtiqueta.caja
        cbFormatoEtiquetaCaja.DataSource = formatosEtiquetas.ObtenerListadoReporte()
        cbFormatoEtiquetaCaja.DisplayMember = "Nombre"
        cbFormatoEtiquetaCaja.ValueMember = "Id"
        listaFormatosEtiquetas = formatosEtiquetas.ObtenerListado()
        For indice = 0 To listaFormatosEtiquetas.Rows.Count - 1
            If (listaFormatosEtiquetas.Rows(indice).Item("Predeterminado")) Then
                cbFormatoEtiquetaCaja.SelectedValue = listaFormatosEtiquetas.Rows(indice).Item("Id")
            End If
        Next


    End Sub

    Private Sub CargarOpcionesImpresion()

        Me.opcionEtiquetaTarimaSeleccionada = cbFormatoEtiquetaTarima.SelectedValue
        Me.opcionEtiquetaCajaSeleccionada = cbFormatoEtiquetaCaja.SelectedValue
        Impresion.CargarImpresoras(True)

    End Sub

    Private Sub PrepararImpresion(ByVal id As Integer)

        ' Aquí se obtienen datos de la tarima. 
        empaque.EId = id
        If (Me.opcionTipoSeleccionada = OpcionTipoEtiqueta.Tarima) Then
            Me.datosTarimasParaImprimir = empaque.ObtenerListadoReporteImpresionTarimas()
            ' Si es una tarima normal o mixta, se hace el proceso para unir cantidades y dejar un solo registro.
            If (Me.datosTarimasParaImprimir.Rows.Count > 1) Then
                Dim cantidadCajas As Integer = Me.datosTarimasParaImprimir.Rows(0)("CantidadCajas")
                Me.datosTarimasParaImprimir.Rows(0)("NombreProducto") &= "(" & cantidadCajas & ")"
                Me.datosTarimasParaImprimir.Rows(0)("NombreVariedad") &= "(" & cantidadCajas & ")"
                Me.datosTarimasParaImprimir.Rows(0)("NombreEnvase") &= "(" & cantidadCajas & ")"
                Me.datosTarimasParaImprimir.Rows(0)("NombreTamano") &= "(" & cantidadCajas & ")"
                Me.datosTarimasParaImprimir.Rows(0)("NombreEtiqueta") &= "(" & cantidadCajas & ")"
            End If
            For fila As Integer = 1 To Me.datosTarimasParaImprimir.Rows.Count - 1
                Me.datosTarimasParaImprimir.Rows(0)("NombreProducto") &= " " & Me.datosTarimasParaImprimir.Rows(fila)("NombreProducto") & "(" & Me.datosTarimasParaImprimir.Rows(fila)("CantidadCajas") & ")"
                Me.datosTarimasParaImprimir.Rows(0)("NombreVariedad") &= " " & Me.datosTarimasParaImprimir.Rows(fila)("NombreVariedad") & "(" & Me.datosTarimasParaImprimir.Rows(fila)("CantidadCajas") & ")"
                Me.datosTarimasParaImprimir.Rows(0)("NombreEnvase") &= " " & Me.datosTarimasParaImprimir.Rows(fila)("NombreEnvase") & "(" & Me.datosTarimasParaImprimir.Rows(fila)("CantidadCajas") & ")"
                Me.datosTarimasParaImprimir.Rows(0)("NombreTamano") &= " " & Me.datosTarimasParaImprimir.Rows(fila)("NombreTamano") & "(" & Me.datosTarimasParaImprimir.Rows(fila)("CantidadCajas") & ")"
                Me.datosTarimasParaImprimir.Rows(0)("NombreEtiqueta") &= " " & Me.datosTarimasParaImprimir.Rows(fila)("NombreEtiqueta") & "(" & Me.datosTarimasParaImprimir.Rows(fila)("CantidadCajas") & ")"
                Me.datosTarimasParaImprimir.Rows(0)("CantidadCajas") += Me.datosTarimasParaImprimir.Rows(fila)("CantidadCajas")
            Next
            ' Se agrega al listado.
            Me.listaTarimasParaImprimir.Add(Me.datosTarimasParaImprimir.Rows(0))
        ElseIf (Me.opcionTipoSeleccionada = OpcionTipoEtiqueta.Caja) Then
            Me.datosCajasParaImprimir = empaque.ObtenerListadoReporteImpresionCajas()
            For fila As Integer = 0 To Me.datosCajasParaImprimir.Rows.Count - 1
                ' Se agrega al listado.
                Me.listaCajasParaImprimir.Add(Me.datosCajasParaImprimir.Rows(fila))
            Next
        End If

    End Sub

    Private Sub MandarImprimir()

        Me.estaImprimiendo = True
        ' Impresión de etiquetas de tarima. 
        ' Si hay datos para imprimir.
        If (Me.listaTarimasParaImprimir.Count > 0) Then
            pdTarima.PrinterSettings.PrinterName = Impresion.nombreImpresoraTarima
            If (Impresion.habilitarImpresoraTarima) Then
                Try
                    pdTarima.Print()
                Catch ex As Exception
                    MsgBox("Hay un error al imprimir. " & ex.Message, MsgBoxStyle.Critical, "Error.")
                End Try
            End If
        End If
        ' Se reinician los valores para la próxima impresión.
        Me.contadorTarimasParaImprimir = 0
        Me.listaTarimasParaImprimir.Clear()
        Me.datosTarimasParaImprimir.Clear()

        ' Impresion de etiquetas de caja. 
        ' Si hay datos para imprimir.
        If (Me.listaCajasParaImprimir.Count > 0) Then
            pdCaja.PrinterSettings.PrinterName = Impresion.nombreImpresoraCaja
            If (Impresion.habilitarImpresoraCaja) Then
                Try
                    pdCaja.Print()
                Catch ex As Exception
                    MsgBox("Hay un error al imprimir. " & ex.Message, MsgBoxStyle.Critical, "Error.")
                End Try
            End If
        End If
        ' Se reinician los valores para la próxima impresión.
        Me.contadorCajasParaImprimir = 0
        Me.listaCajasParaImprimir.Clear()
        Me.datosCajasParaImprimir.Clear()

        Me.estaImprimiendo = False

    End Sub

    Private Sub DefinirEtiquetaTarima(ByRef e As System.Drawing.Printing.PrintPageEventArgs)

        If (Me.opcionEtiquetaTarimaSeleccionada = OpcionFormatoEtiquetaTarima.normal35por3) Then
            CrearEtiquetaTarimaNormal35x3(e)
        End If

    End Sub

    Private Sub CrearEtiquetaTarimaNormal35x3(ByRef e As System.Drawing.Printing.PrintPageEventArgs)

        Dim fuenteCodigoBarras7 As New Font(Principal.tipoLetraSpread, 7, FontStyle.Bold)
        Dim fuenteCodigoBarras23 As New Font(Principal.tipoLetraSpread, 23, FontStyle.Bold)
        Dim fuenteDescripcion4 As New Font(Principal.tipoLetraSpread, 4, FontStyle.Bold)
        Dim fuenteDescripcion6 As New Font(Principal.tipoLetraSpread, 6, FontStyle.Bold)
        Dim fuenteDescripcion8 As New Font(Principal.tipoLetraSpread, 8, FontStyle.Bold)
        Dim imagen As System.Drawing.Image = Nothing
        Dim margenIzquierdoTarima As Integer = Impresion.margenIzquierdoTarima : Dim margenSuperiorTarima As Integer = Impresion.margenSuperiorTarima
        Dim formato As New StringFormat()
        formato.Alignment = StringAlignment.Center
        ' Se obtienen los datos generales.
        Dim numeracion As Integer = 0
        Dim altura As Integer = 0
        Dim id As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaTarimasParaImprimir.Item(contadorTarimasParaImprimir).Item("Id").ToString)
        Dim nombreProducto As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaTarimasParaImprimir.Item(contadorTarimasParaImprimir).Item("NombreProducto").ToString())
        Dim nombreVariedad As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaTarimasParaImprimir.Item(contadorTarimasParaImprimir).Item("NombreVariedad").ToString())
        Dim nombreEnvase As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaTarimasParaImprimir.Item(contadorTarimasParaImprimir).Item("NombreEnvase").ToString())
        Dim nombreTamano As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaTarimasParaImprimir.Item(contadorTarimasParaImprimir).Item("NombreTamano").ToString())
        Dim nombreEtiqueta As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaTarimasParaImprimir.Item(contadorTarimasParaImprimir).Item("NombreEtiqueta").ToString())
        Dim cantidadCajas As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaTarimasParaImprimir.Item(contadorTarimasParaImprimir).Item("CantidadCajas").ToString)
        Dim nombreEmbarcador As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("NombreEmbarcador").ToString)
        ' Formato de etiqueta chica despegable.
        e.Graphics.DrawImage(GenerarBarras(id), margenIzquierdoTarima + 10, margenSuperiorTarima + altura, 140, 28) ' Codigo de barras con id de tarima.
        e.Graphics.DrawString(id, fuenteCodigoBarras7, Brushes.Black, margenIzquierdoTarima + 80, margenSuperiorTarima + 29, formato) ' Id de tarima.
        e.Graphics.DrawString(nombreProducto & "  " & nombreTamano, IIf(nombreProducto.Length + nombreTamano.Length > 25, fuenteDescripcion4, fuenteDescripcion6), Brushes.Black, New Rectangle(margenIzquierdoTarima + 160, margenSuperiorTarima + altura, 130, 20)) ' Producto y tamaño.
        altura += 16
        e.Graphics.DrawString(nombreEtiqueta & " " & nombreEnvase, IIf(nombreEtiqueta.Length + nombreEnvase.Length > 25, fuenteDescripcion4, fuenteDescripcion6), Brushes.Black, New Rectangle(margenIzquierdoTarima + 160, margenSuperiorTarima + altura, 130, 20)) ' Etiqueta y envase.
        altura += 16
        e.Graphics.DrawString("Total Cajas: " & cantidadCajas, fuenteDescripcion4, Brushes.Black, margenIzquierdoTarima + 160, margenSuperiorTarima + altura) ' Relleno.
        ' Formato de etiqueta grande pegable.
        altura = 96
        e.Graphics.DrawImage(GenerarBarras(id), margenIzquierdoTarima + 51, margenSuperiorTarima + 63, 173, 33) ' Codigo de barras con id de tarima.
        e.Graphics.DrawString(id, fuenteCodigoBarras23, Brushes.Black, margenIzquierdoTarima + 140, margenSuperiorTarima + altura, formato) ' Id de tarima.
        altura = 132
        e.Graphics.DrawString(nombreEmbarcador, fuenteDescripcion8, Brushes.Black, margenIzquierdoTarima + 0, margenSuperiorTarima + altura) ' Embarcador.
        altura += 30
        e.Graphics.DrawString("PRODUCT: " & nombreProducto, fuenteDescripcion8, Brushes.Black, margenIzquierdoTarima + 0, margenSuperiorTarima + altura) ' Producto.
        altura += 30
        e.Graphics.DrawString("LABEL: " & nombreEtiqueta, fuenteDescripcion8, Brushes.Black, margenIzquierdoTarima + 0, margenSuperiorTarima + altura) ' Etiqueta. 
        altura += 30
        If (nombreEnvase.Length > 30) Then
            e.Graphics.DrawString("CONTAINER: " & nombreEnvase, fuenteDescripcion8, Brushes.Black, New Rectangle(margenIzquierdoTarima + 0, margenSuperiorTarima + altura, 300, 25)) ' Envase.
            altura += 40
        Else
            e.Graphics.DrawString("CONTAINER: " & nombreEnvase, fuenteDescripcion8, Brushes.Black, margenIzquierdoTarima + 0, margenSuperiorTarima + altura) ' Envase.
            altura += 30
        End If
        e.Graphics.DrawString("SIZE: " & nombreTamano, fuenteDescripcion8, Brushes.Black, margenIzquierdoTarima + 0, margenSuperiorTarima + altura) ' Tamaño.
        altura += 30
        e.Graphics.DrawString("TOTAL PACKS: " & cantidadCajas, fuenteDescripcion8, Brushes.Black, margenIzquierdoTarima + 0, margenSuperiorTarima + altura) ' Cantidad de cajas.
        ' Se agrega el logo.
        If (Not String.IsNullOrEmpty(nombreEmbarcador)) Then
            Dim ruta As String = Application.StartupPath & "\logoCliente.jpg"
            If (System.IO.File.Exists(ruta)) Then
                imagen = System.Drawing.Image.FromFile(ruta)
            Else
                imagen = Nothing
            End If
        Else
            Dim ruta As String = Application.StartupPath & "\logoBerry.png"
            If (Me.esDesarrollo) Then
                ruta = "W:\logoBerry.png"
            End If
            If (System.IO.File.Exists(ruta)) Then
                imagen = System.Drawing.Image.FromFile(ruta)
            Else
                imagen = Nothing
            End If
        End If
        If (Not imagen Is Nothing) Then
            e.Graphics.DrawImage(imagen, margenIzquierdoTarima + 220, margenSuperiorTarima + 270, 80, 80)
        End If
        ' Se aumenta el contador de tarimas.
        contadorTarimasParaImprimir += 1
        ' Se verifica si tiene mas impresiones pendientes de acuerdo a las tarimas.
        If (contadorTarimasParaImprimir < Me.listaTarimasParaImprimir.Count) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub

    Private Sub DefinirEtiquetaCaja(ByRef e As System.Drawing.Printing.PrintPageEventArgs)

        If (Me.opcionEtiquetaCajaSeleccionada = OpcionFormatoEtiquetaCaja.normal2por2) Then
            CrearEtiquetaCajaNormal2x2(e)
        End If

    End Sub

    Sub CrearEtiquetaCajaNormal2x2(ByRef e As System.Drawing.Printing.PrintPageEventArgs)

        Dim fuente6 As New Font(Principal.tipoLetraSpread, 6, FontStyle.Regular)
        Dim fuente65 As New Font(Principal.tipoLetraSpread, 6.5, FontStyle.Regular)
        Dim fuente7 As New Font(Principal.tipoLetraSpread, 7, FontStyle.Bold)
        Dim fuente85 As New Font(Principal.tipoLetraSpread, 8.25, FontStyle.Regular)
        Dim fuente9 As New Font(Principal.tipoLetraSpread, 9, FontStyle.Regular)
        Dim fuente14 As New Font(Principal.tipoLetraSpread, 14, FontStyle.Regular)
        Dim imagen As System.Drawing.Image = Nothing
        Dim formatoHorizontalCentrado As New StringFormat()
        formatoHorizontalCentrado.Alignment = StringAlignment.Center
        Dim formatoDerecho As New StringFormat()
        formatoDerecho.Alignment = StringAlignment.Far
        Dim formatoVerticalCentro As New StringFormat()
        formatoVerticalCentro.LineAlignment = StringAlignment.Center
        Dim formatoCentrado As New StringFormat
        formatoCentrado.Alignment = StringAlignment.Center
        formatoCentrado.LineAlignment = StringAlignment.Center
        Dim gtin As String = String.Empty
        Dim lotBatch As String = String.Empty
        Dim margenIzquierdoCaja As Integer = Impresion.margenIzquierdoCaja : Dim margenSuperiorCaja As Integer = Impresion.margenSuperiorCaja
        ' Se obtienen los datos generales.
        Dim nombreEmbarcador As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("NombreEmbarcador").ToString)
        Dim domicilioEmbarcador As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("DomicilioEmbarcador").ToString)
        Dim municipioEmbarcador As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("MunicipioEmbarcador").ToString)
        Dim estadoEmbarcador As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("EstadoEmbarcador").ToString)
        Dim claveAgricola As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("ClaveAgricola").ToString)
        Dim diaJuliano As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("DiaJuliano").ToString)
        Dim idTarima As String = EYELogicaEmpaque.Funciones.ValidarNumeroACero(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("IdTarima").ToString).ToString.PadLeft(6, "0")
        Dim id As String = EYELogicaEmpaque.Funciones.ValidarNumeroACero(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("Id").ToString).ToString.PadLeft(3, "0")
        Dim nombreProducto As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("NombreProducto").ToString())
        Dim nombreVariedad As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("NombreVariedad").ToString())
        Dim nombreEnvase As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("NombreEnvase").ToString())
        Dim nombreTamano As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("NombreTamano").ToString())
        Dim nombreEtiqueta As String = EYELogicaEmpaque.Funciones.ValidarLetra(Me.listaCajasParaImprimir.Item(contadorCajasParaImprimir).Item("NombreEtiqueta").ToString())
        gtin = "00000000000000" ' TODO. Pendiente de generar configuracion.
        lotBatch = ObtenerLotBatch()
        ' Formato de la etiqueta.
        e.Graphics.DrawString(nombreEmbarcador, fuente7, Brushes.Black, New Rectangle(margenIzquierdoCaja + 0, margenSuperiorCaja + 0, 200, 20)) ' Embarcador.
        e.Graphics.DrawString(domicilioEmbarcador & " " & municipioEmbarcador & " " & estadoEmbarcador, fuente65, Brushes.Black, New Rectangle(margenIzquierdoCaja + 0, margenSuperiorCaja + 21, 200, 25)) ' Domicilio, municipio y estado. 
        e.Graphics.DrawString(claveAgricola & "-" & diaJuliano & "-" & idTarima & "-" & id, fuente85, Brushes.Black, margenIzquierdoCaja + 95, margenSuperiorCaja + 46, formatoHorizontalCentrado) ' Id trazable.
        'e.Graphics.DrawString("Trace this at www.swberry.net", fuente6, Brushes.Black, margenIzquierdoCaja + 95, margenSuperiorCaja + 59, formatoHorizontalCentrado) ' Sitio web. ' TODO. Pendiente agregar sitio web.
        e.Graphics.DrawLine(Pens.Black, margenIzquierdoCaja + 0, margenSuperiorCaja + 69, margenIzquierdoCaja + 192, margenSuperiorCaja + 69) ' Linea.
        e.Graphics.DrawString(nombreProducto & " " & nombreVariedad, fuente65, Brushes.Black, New Rectangle(margenIzquierdoCaja + 0, margenSuperiorCaja + 70, 150, 13), formatoVerticalCentro) ' Producto y variedad.
        e.Graphics.DrawString(nombreEnvase, fuente65, Brushes.Black, New Rectangle(margenIzquierdoCaja + 96, margenSuperiorCaja + 70, 92, 13), formatoDerecho) ' Envase.
        e.Graphics.DrawString(nombreEtiqueta, fuente65, Brushes.Black, New Rectangle(margenIzquierdoCaja + 0, margenSuperiorCaja + 83, 92, 13), formatoVerticalCentro) ' Etiqueta.
        e.Graphics.DrawString(nombreTamano, fuente65, Brushes.Black, New Rectangle(margenIzquierdoCaja + 96, margenSuperiorCaja + 83, 92, 13), formatoDerecho) ' Tamaño.
        e.Graphics.DrawImage(GenerarBarras("01" & gtin & "10" & lotBatch), margenIzquierdoCaja + 10, margenSuperiorCaja + 96, 170, 48) ' Codigo de barras.
        e.Graphics.DrawString("(01)" & gtin & "(10)" & lotBatch, fuente6, Brushes.Black, margenIzquierdoCaja + 95, margenSuperiorCaja + 144, formatoHorizontalCentrado) 'Id de codigo de barras.
        e.Graphics.DrawString(idTarima, fuente7, Brushes.Black, margenIzquierdoCaja + 0, margenSuperiorCaja + 156) ' Id de tarima.
        e.Graphics.DrawString("Produce of MX", fuente85, Brushes.Black, margenIzquierdoCaja + 0, margenSuperiorCaja + 172) ' Mexico. 
        '' Se agrega el logo.
        'Dim ruta As String = Application.StartupPath & "\logoBerry.png"
        'If (Not String.IsNullOrEmpty(nombreEmbarcador)) Then
        '    ruta = Application.StartupPath & "\logoCliente.jpg"
        'Else
        '    ruta = Application.StartupPath & "\logoBerry.png"
        'End If
        'If (Me.esDesarrollo) Then
        '    ruta = "W:\logoBerry.png"
        'End If
        'If (System.IO.File.Exists(ruta)) Then
        '    imagen = System.Drawing.Image.FromFile(ruta)
        '    e.Graphics.DrawImage(imagen, margenIzquierdoCaja + 160, margenSuperiorCaja + 170, 30, 30)
        'End If
        ' Se aumenta el contador de cajas.
        contadorCajasParaImprimir += 1
        ' Se verifica si tiene mas impresiones pendientes de acuerdo a las cajas.
        If (contadorCajasParaImprimir < Me.listaCajasParaImprimir.Count) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub

    Private Function GenerarBarras(ByVal texto As String) As Image

        Dim imagenBarras As Image = Nothing
        imagenBarras = BarCode.Code128(texto, BarCode.Code128SubTypes.CODE128_UCC, False, 80)
        Return imagenBarras

    End Function

    Private Function ObtenerLotBatch() As String

        Dim fechaMinima2 As Date = empaque.ObtenerMinimaFecha() ' Fecha minima de empacado (de la primer tarima).
        Dim fechaMinima As String = fechaMinima2.ToString
        fechaMinima = Mid(fechaMinima, 1, 2) & Mid(fechaMinima, 4, 2) & Mid(fechaMinima, 7, 4)
        Dim aleatorio As Integer = 1 ' Numero aleatorio, 1 por defecto.
        For indice As Integer = 1 To 8 ' Se genera el aleatorio del 1 al 8.
            aleatorio = aleatorio + Convert.ToInt32(Mid(fechaMinima, indice, 1))
        Next
        aleatorio = aleatorio * 3 ' Se multiplica por 3.
        Dim aleatorio2 As String = Mid(aleatorio.ToString, Len(aleatorio.ToString), 1) ' Se extrae el ultimo numero del resultado aleatorio (1 digito).
        Dim diferenciaDias As String = (DateDiff(DateInterval.DayOfYear, fechaMinima2, Today) + 1).ToString.PadLeft(3, "0") ' Se calcula la diferencia de dias de la primer tarima hasta ahora.
        Dim añoActual As String = (Mid((Year(Today)).ToString, 3, 2)).ToString.PadLeft(2, "0") ' Es el año actual (2 digitos). 
        Dim lotBatch As String = aleatorio2 & diferenciaDias & añoActual
        Return lotBatch

    End Function

#End Region

#End Region

#Region "Enumeraciones"

    Enum OpcionPosicion

        izquierda = 1
        centro = 2
        derecha = 3

    End Enum

    Enum OpcionCatalogo

        productor = 1
        lote = 2
        producto = 3
        variedad = 4
        envase = 5
        tamano = 6
        etiqueta = 7

    End Enum

    Enum OpcionFormatoEtiquetaTarima

        ' Este listado debe corresponder a la tabla FormatosEtiquetas (no es configurable por el usuario).
        normal35por3 = 1

    End Enum

    Enum OpcionFormatoEtiquetaCaja

        ' Este listado debe corresponder a la tabla FormatosEtiquetas (no es configurable por el usuario).
        normal2por2 = 1

    End Enum

    Enum OpcionTipoEtiqueta

        ' Este listado debe corresponder a la tabla TiposEtiquetas (no es configurable por el usuario).
        tarima = 1
        caja = 2

    End Enum

#End Region

End Class