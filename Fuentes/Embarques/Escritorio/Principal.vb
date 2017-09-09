Imports System.IO
Imports System.ComponentModel
Imports System.Threading

Public Class Principal

    ' Variables de objetos de entidades.
    Public usuarios As New EYEEntidadesEmbarques.Usuarios()
    Public embarques As New EYEEntidadesEmbarques.Embarques()
    Public productores As New EYEEntidadesEmbarques.Productores()
    Public clientes As New EYEEntidadesEmbarques.Clientes()
    Public lineasTransportes As New EYEEntidadesEmbarques.LineasTransportes()
    Public trailers As New EYEEntidadesEmbarques.Trailers()
    Public cajasTrailers As New EYEEntidadesEmbarques.CajasTrailers()
    Public choferes As New EYEEntidadesEmbarques.Choferes()
    Public aduanasMex As New EYEEntidadesEmbarques.AduanasMex()
    Public aduanasUsa As New EYEEntidadesEmbarques.AduanasUsa()
    Public documentadores As New EYEEntidadesEmbarques.Documentadores()
    Public tarimas As New EYEEntidadesEmbarques.Tarimas()
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
    Public Shared tipoLetraSpread As String = "Microsoft Sans Serif" : Public Shared tamañoLetraSpread As Integer = 11 : Public Shared tamañoLetraSpreadDocumentos As Integer = 10
    Public Shared alturaFilasEncabezadosGrandesSpread As Integer = 35 : Public Shared alturaFilasEncabezadosMedianosSpread As Integer = 28
    Public Shared alturaFilasEncabezadosChicosSpread As Integer = 22 : Public Shared alturaFilasMedianasSpread As Integer = 20
    Public Shared colorAreaGris = Color.White
    ' Variables de eventos de spread.
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public estaMostrado As Boolean = False : Public estaCerrando As Boolean = False
    Public ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public prefijoBaseDatosEmpaque As String = "EYE" & "_"
    Public cantidadFilas As Integer = 1
    Public opcionCatalogoSeleccionada As Integer = -1
    Public opcionTipoSeleccionada As Integer = -1
    Public esIzquierda As Boolean = False
    Public esGuardadoValido As Boolean = True
    Public estaImprimiendo As Boolean = False 
    ' Hilos para carga rapida. 
    Public hiloCentrar As New Thread(AddressOf Centrar)
    Public hiloNombrePrograma As New Thread(AddressOf CargarNombrePrograma) 
    Public hiloEncabezadosTitulos As New Thread(AddressOf CargarEncabezadosTitulos)
    Public hiloFecha As New Thread(AddressOf CargarFechaHora)
    ' Variable de desarrollo.
    Public esDesarrollo As Boolean = False

#Region "Eventos"
     
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor 
        MostrarCargando(True)
        ConfigurarConexiones()
        IniciarHilosCarga()
        AsignarTooltips()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Cursor = Cursors.WaitCursor
        FormatearSpread()
        FormatearSpreadEmbarques()
        CargarProductores()
        CargarClientes()
        CargarLineasTransportes()
        CargarTrailers()
        CargarCajasTrailers()
        CargarChoferes()
        CargarAduanasMex()
        CargarAduanasUsa()
        CargarDocumentadores()
        CargarIdConsecutivo()
        AsignarFoco(txtId) 
        Me.estaMostrado = True
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

    Private Sub spEmpaque_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spEmbarques.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter(spEmbarques)
        End If

    End Sub

    Private Sub spEmbarques_KeyDown(sender As Object, e As KeyEventArgs) Handles spEmbarques.KeyDown

        If (e.KeyData = Keys.F6) Then ' Eliminar un registro.
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                EliminarRegistroDeSpread(spEmbarques)
            End If
        ElseIf (e.KeyData = Keys.Enter) Then ' Validar registros.
            ControlarSpreadEnter(spEmbarques)
        ElseIf (e.KeyData = Keys.F5) Then ' Abrir catalogos. 
            CargarCatalogoEnSpread()
        ElseIf (e.KeyData = Keys.Escape) Then
            spEmbarques.ActiveSheet.SetActiveCell(0, 0)
            If (Me.opcionTipoSeleccionada = OpcionTipo.exportacion) Then
                AsignarFoco(txtGuiaCaades)
            ElseIf (Me.opcionTipoSeleccionada = OpcionTipo.nacional) Then
                AsignarFoco(txtFactura)
            End If
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        ValidarGuardado()
        If (Me.esGuardadoValido) Then
            GuardarEditarEmbarques()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        EliminarEmbarques(True)

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
                CargarEmbarques()
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

    Private Sub cbEmbarcadores_KeyDown(sender As Object, e As KeyEventArgs) Handles cbEmbarcadores.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbEmbarcadores.SelectedValue > 0) Then
                AsignarFoco(cbClientes)
            Else
                cbEmbarcadores.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtHora)
        End If

    End Sub

    Private Sub btnIdAnterior_Click(sender As Object, e As EventArgs) Handles btnIdAnterior.Click

        If (EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtId.Text) > 1) Then
            txtId.Text -= 1
            CargarEmbarques()
        End If

    End Sub

    Private Sub btnIdSiguiente_Click(sender As Object, e As EventArgs) Handles btnIdSiguiente.Click

        If (EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtId.Text) >= 1) Then
            txtId.Text += 1
            CargarEmbarques()
        End If

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHora.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (Not String.IsNullOrEmpty(txtHora.Text.Trim.Replace(":", "").Replace("_", "")) And txtHora.Text.Length = 5 And IsDate(txtHora.Text)) Then
                AsignarFoco(cbEmbarcadores)
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(dtpFecha)
        End If

    End Sub

    Private Sub spCatalogos_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos.CellClick

        Dim fila As Integer = e.Row
        CargarDatosEnSpreadDeCatalogos(fila)

    End Sub

    Private Sub spCatalogos_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos.CellDoubleClick

        VolverFocoCatalogos()

    End Sub

    Private Sub spCatalogos_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos.KeyDown

        If (e.KeyCode = Keys.Escape) Then
            VolverFocoCatalogos()
        End If

    End Sub

    Private Sub btnGenerarDocumentos_Click(sender As Object, e As EventArgs) Handles btnGenerarDocumentos.Click

        MostrarOcultarPanelDocumentos()

    End Sub

    Private Sub btnGenerarDocumentos_MouseEnter(sender As Object, e As EventArgs) Handles btnGenerarDocumentos.MouseEnter

        AsignarTooltips("Generar Documentos.")

    End Sub

    Private Sub cbClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles cbClientes.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbClientes.SelectedValue > 0) Then
                AsignarFoco(cbLineasTransportes)
            Else
                cbClientes.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbEmbarcadores)
        End If

    End Sub

    Private Sub cbLineasTransportes_KeyDown(sender As Object, e As KeyEventArgs) Handles cbLineasTransportes.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbLineasTransportes.SelectedValue > 0) Then
                AsignarFoco(cbTrailers)
            Else
                cbLineasTransportes.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbClientes)
        End If

    End Sub

    Private Sub cbTrailers_KeyDown(sender As Object, e As KeyEventArgs) Handles cbTrailers.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbTrailers.SelectedValue > 0) Then
                AsignarFoco(cbCajasTrailers)
            Else
                cbTrailers.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbLineasTransportes)
        End If

    End Sub

    Private Sub cbCajasTrailers_KeyDown(sender As Object, e As KeyEventArgs) Handles cbCajasTrailers.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbCajasTrailers.SelectedValue > 0) Then
                AsignarFoco(cbChoferes)
            Else
                cbCajasTrailers.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbTrailers)
        End If

    End Sub

    Private Sub cbChoferes_KeyDown(sender As Object, e As KeyEventArgs) Handles cbChoferes.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbChoferes.SelectedValue > 0) Then
                If (Me.opcionTipoSeleccionada = OpcionTipo.exportacion) Then
                    AsignarFoco(cbAduanasMex)
                ElseIf (Me.opcionTipoSeleccionada = OpcionTipo.nacional) Then
                    AsignarFoco(cbDocumentadores)
                End If
            Else
                cbChoferes.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbTrailers)
        End If

    End Sub

    Private Sub cbAduanasMex_KeyDown(sender As Object, e As KeyEventArgs) Handles cbAduanasMex.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbAduanasMex.SelectedValue > 0) Then
                AsignarFoco(cbAduanasUsa)
            Else
                cbAduanasMex.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbChoferes)
        End If

    End Sub

    Private Sub cbAduanasUsa_KeyDown(sender As Object, e As KeyEventArgs) Handles cbAduanasUsa.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbAduanasUsa.SelectedValue > 0) Then
                AsignarFoco(cbDocumentadores)
            Else
                cbAduanasUsa.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbAduanasMex)
        End If

    End Sub

    Private Sub cbDocumentadores_KeyDown(sender As Object, e As KeyEventArgs) Handles cbDocumentadores.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (cbDocumentadores.SelectedValue > 0) Then
                AsignarFoco(txtTemperatura)
            Else
                cbDocumentadores.SelectedIndex = 0
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            If (Me.opcionTipoSeleccionada = OpcionTipo.exportacion) Then
                AsignarFoco(cbAduanasUsa)
            ElseIf (Me.opcionTipoSeleccionada = OpcionTipo.nacional) Then
                AsignarFoco(cbChoferes)
            End If
        End If

    End Sub

    Private Sub txtTemperatura_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTemperatura.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (IsNumeric(txtTemperatura.Text)) Then
                AsignarFoco(txtTermografo)
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(cbDocumentadores)
        End If

    End Sub

    Private Sub txtTermografo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTermografo.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (Not String.IsNullOrEmpty(txtTermografo.Text)) Then
                AsignarFoco(txtPrecioFlete)
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtTemperatura)
        End If

    End Sub

    Private Sub txtPrecioFlete_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioFlete.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (IsNumeric(txtPrecioFlete.Text)) Then
                If (Me.opcionTipoSeleccionada = OpcionTipo.exportacion) Then
                    AsignarFoco(txtHoraPrecos)
                ElseIf (Me.opcionTipoSeleccionada = OpcionTipo.nacional) Then
                    AsignarFoco(txtSello1)
                End If
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtTermografo)
        End If

    End Sub

    Private Sub txtHoraPrecos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHoraPrecos.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (Not String.IsNullOrEmpty(txtHoraPrecos.Text.Trim.Replace(":", "").Replace("_", "")) And txtHoraPrecos.Text.Length = 5 And IsDate(txtHoraPrecos.Text)) Then
                AsignarFoco(txtSello1)
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtPrecioFlete)
        End If

    End Sub

    Private Sub txtSello1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSello1.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (Not String.IsNullOrEmpty(txtSello1.Text)) Then
                AsignarFoco(txtSello2)
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            If (Me.opcionTipoSeleccionada = OpcionTipo.exportacion) Then
                AsignarFoco(txtHoraPrecos)
            ElseIf (Me.opcionTipoSeleccionada = OpcionTipo.nacional) Then
                AsignarFoco(txtPrecioFlete)
            End If
        End If

    End Sub

    Private Sub txtSello2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSello2.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello3)
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello1)
        End If

    End Sub

    Private Sub txtSello3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSello3.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello4)
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello2)
        End If

    End Sub

    Private Sub txtSello4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSello4.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello5)
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello3)
        End If

    End Sub

    Private Sub txtSello5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSello5.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello6)
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello4)
        End If

    End Sub

    Private Sub txtSello6_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSello6.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello7)
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello5)
        End If

    End Sub

    Private Sub txtSello7_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSello7.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello8)
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello6)
        End If

    End Sub

    Private Sub txtSello8_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSello8.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtFactura)
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello7)
        End If

    End Sub

    Private Sub txtFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFactura.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (Not String.IsNullOrEmpty(txtFactura.Text)) Then
                If (Me.opcionTipoSeleccionada = OpcionTipo.exportacion) Then
                    AsignarFoco(txtGuiaCaades)
                ElseIf (Me.opcionTipoSeleccionada = OpcionTipo.nacional) Then
                    AsignarFoco(spEmbarques)
                End If
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtSello8)
        End If

    End Sub

    Private Sub txtGuiaCaades_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGuiaCaades.KeyDown

        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            AsignarFoco(spEmbarques)
        ElseIf (e.KeyData = Keys.Escape) Then
            e.SuppressKeyPress = True
            AsignarFoco(txtFactura)
        End If

    End Sub

    Private Sub cbLineasTransportes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLineasTransportes.SelectedIndexChanged

        CargarTrailers()

    End Sub

    Private Sub rbtnExportacion_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnExportacion.CheckedChanged

        If (rbtnExportacion.Checked) Then
            Me.opcionTipoSeleccionada = OpcionTipo.exportacion
            If (Me.estaMostrado) Then
                CargarIdConsecutivo()
                LimpiarPantalla()
                MostrarDatosExportacionNacional()
            End If
        End If

    End Sub

    Private Sub rbtnNacional_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnNacional.CheckedChanged

        If (rbtnNacional.Checked) Then
            Me.opcionTipoSeleccionada = OpcionTipo.nacional
            If (Me.estaMostrado) Then
                CargarIdConsecutivo()
                LimpiarPantalla()
                MostrarDatosExportacionNacional()
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

    Private Sub btnManifiesto_Click(sender As Object, e As EventArgs) Handles btnManifiesto.Click

        Documentos.opcionSeleccionada = Documentos.OpcionDocumento.manifiesto
        Documentos.Show()
        pnlContenido.Enabled = False

    End Sub

    Private Sub btnRemision_Click(sender As Object, e As EventArgs) Handles btnRemision.Click

        Documentos.opcionSeleccionada = Documentos.OpcionDocumento.remision
        Documentos.Show()
        pnlContenido.Enabled = False

    End Sub

    Private Sub btnDistribucionCarga_Click(sender As Object, e As EventArgs) Handles btnDistribucionCarga.Click

        Documentos.opcionSeleccionada = Documentos.OpcionDocumento.distribucion
        Documentos.Show()
        pnlContenido.Enabled = False

    End Sub

    Private Sub btnCartaResponsiva_Click(sender As Object, e As EventArgs) Handles btnCartaResponsiva.Click

        Documentos.opcionSeleccionada = Documentos.OpcionDocumento.responsiva
        Documentos.Show()
        pnlContenido.Enabled = False

    End Sub

    Private Sub btnBitacoraSellos_Click(sender As Object, e As EventArgs) Handles btnBitacoraSellos.Click

        Documentos.opcionSeleccionada = Documentos.OpcionDocumento.sellos
        Documentos.Show()
        pnlContenido.Enabled = False

    End Sub

    Private Sub btnPrecos_Click(sender As Object, e As EventArgs) Handles btnPrecos.Click

        Documentos.opcionSeleccionada = Documentos.OpcionDocumento.precos
        Documentos.Show()
        pnlContenido.Enabled = False

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

    Private Sub MostrarOcultar()

        Dim anchoMenor As Integer = pnlCapturaSuperior.Width / 5
        Dim espacio As Integer = 10
        If (Not Me.esIzquierda) Then
            pnlCapturaSuperior.Left = -pnlCapturaSuperior.Width + anchoMenor
            spEmbarques.Left = anchoMenor + espacio
            spEmbarques.Width += anchoMenor * 4 - espacio
            btnMostrarOcultar.BackgroundImage = Nothing
            btnMostrarOcultar.BackgroundImage = Global.EYEEmbarques.My.Resources.hand_right_32
            Me.esIzquierda = True
        Else
            pnlCapturaSuperior.Left = 0
            spEmbarques.Left = pnlCapturaSuperior.Width + espacio
            spEmbarques.Width -= anchoMenor * 4 - espacio
            btnMostrarOcultar.BackgroundImage = Nothing
            btnMostrarOcultar.BackgroundImage = Global.EYEEmbarques.My.Resources.hand_left_32
            Me.esIzquierda = False
        End If

    End Sub

    Private Sub Salir()

        Application.Exit()

    End Sub

    Private Sub MostrarAyuda()

        Dim pnlAyuda As New Panel()
        Dim txtAyuda As New TextBox()
        If (pnlContenido.Controls.Find("pnlAyuda", True).Count = 0) Then ' Si no existe, se crea uno oculto.
            pnlAyuda.Name = "pnlAyuda" : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
            pnlContenido.Controls.Add(pnlAyuda) : Application.DoEvents()
            txtAyuda.Name = "txtAyuda" : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else ' Si existe, se asigna a los objetos que se acaban de crear.
            pnlAyuda = pnlContenido.Controls.Find("pnlAyuda", False)(0) : Application.DoEvents()
            txtAyuda = pnlAyuda.Controls.Find("txtAyuda", False)(0) : Application.DoEvents()
        End If
        If (Not pnlAyuda.Visible) Then ' Si está oculto, es que se acaba de crear solo el objeto, entonces se agregan todas las demás propiedades.
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
        Else ' Si está visible y existe, pues se oculta.
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

        If ((Not EYELogicaEmbarques.Usuarios.accesoTotal) Or (EYELogicaEmbarques.Usuarios.accesoTotal = 0) Or (EYELogicaEmbarques.Usuarios.accesoTotal = False)) Then
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
        tp.SetToolTip(Me.btnGenerarDocumentos, "Generar Documentos.")
        tp.SetToolTip(Me.btnEnviarCorreos, "Enviar Correos.")
        tp.SetToolTip(Me.btnMostrarOcultar, "Mostrar / Ocultar.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            EYELogicaEmbarques.Directorios.id = 1
            EYELogicaEmbarques.Directorios.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            EYELogicaEmbarques.Directorios.usuarioSql = "AdminBerry"
            EYELogicaEmbarques.Directorios.contrasenaSql = "@berry2017"
            pnlEncabezado.BackColor = Color.DarkRed
            pnlPie.BackColor = Color.DarkRed
        Else
            EYELogicaEmbarques.Directorios.ObtenerParametros()
            EYELogicaEmbarques.Usuarios.ObtenerParametros()
        End If
        EYELogicaEmbarques.Programas.bdCatalogo = "Catalogo" & EYELogicaEmbarques.Directorios.id
        EYELogicaEmbarques.Programas.bdConfiguracion = "Configuracion" & EYELogicaEmbarques.Directorios.id
        EYELogicaEmbarques.Programas.bdEmpaque = "Empaque" & EYELogicaEmbarques.Directorios.id
        EYEEntidadesEmbarques.BaseDatos.ECadenaConexionCatalogo = EYELogicaEmbarques.Programas.bdCatalogo
        EYEEntidadesEmbarques.BaseDatos.ECadenaConexionConfiguracion = EYELogicaEmbarques.Programas.bdConfiguracion
        EYEEntidadesEmbarques.BaseDatos.ECadenaConexionEmpaque = EYELogicaEmbarques.Programas.bdEmpaque
        EYEEntidadesEmbarques.BaseDatos.AbrirConexionCatalogo()
        EYEEntidadesEmbarques.BaseDatos.AbrirConexionConfiguracion()
        EYEEntidadesEmbarques.BaseDatos.AbrirConexionEmpaque()
        ConsultarInformacionUsuario()
        CargarPrefijoBaseDatosEmpaque()

    End Sub

    Private Sub CargarPrefijoBaseDatosEmpaque()

        EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque = Me.prefijoBaseDatosEmpaque

    End Sub

    Private Sub ConsultarInformacionUsuario()

        Dim lista As New List(Of EYEEntidadesEmbarques.Usuarios)
        usuarios.EId = EYELogicaEmbarques.Usuarios.id
        lista = usuarios.ObtenerListado()
        If (lista.Count = 1) Then
            EYELogicaEmbarques.Usuarios.id = lista(0).EId
            EYELogicaEmbarques.Usuarios.nombre = lista(0).ENombre
            EYELogicaEmbarques.Usuarios.contrasena = lista(0).EContrasena
            EYELogicaEmbarques.Usuarios.nivel = lista(0).ENivel
            EYELogicaEmbarques.Usuarios.accesoTotal = lista(0).EAccesoTotal
        End If

    End Sub

    Private Sub CargarEncabezadosTitulos()

        lblEncabezadoPrograma.Text = "Programa: " & Me.Text
        lblEncabezadoEmpresa.Text = "Directorio: " & EYELogicaEmbarques.Directorios.nombre
        lblEncabezadoUsuario.Text = "Usuario: " & EYELogicaEmbarques.Usuarios.nombre
        btnMostrarOcultar.BackgroundImage = Global.EYEEmbarques.My.Resources.hand_left_32
        'For Each c As Control In pnlPie.Controls ' TODO. Borrar esto, es una prueba.
        '    If (c.GetType Is GetType(Button)) Then
        '        Thread.Sleep(40)
        '        c.BackColor = ObtenerColorAleatorio()
        '    End If
        'Next
        Me.Text = "Programa:  " & Me.nombreEstePrograma & "              Directorio:  " & EYELogicaEmbarques.Directorios.nombre & "              Usuario:  " & EYELogicaEmbarques.Usuarios.nombre
        hiloEncabezadosTitulos.Abort()

    End Sub

    Private Function ObtenerColorAleatorio() As Color

        Dim aleatorio As New Random
        Return Color.FromArgb(aleatorio.Next(0, 256), aleatorio.Next(0, 256), aleatorio.Next(0, 256))

    End Function


    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & ".exe"
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = EYELogicaEmbarques.Directorios.id.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmbarques.Directorios.nombre.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmbarques.Directorios.descripcion.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmbarques.Directorios.rutaLogo.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmbarques.Directorios.esPredeterminado.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmbarques.Directorios.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmbarques.Directorios.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & EYELogicaEmbarques.Directorios.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de directorios, indice 9 ;)".Replace(" ", "|") & " " & EYELogicaEmbarques.Usuarios.id.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 11 ;)".Replace(" ", "|")
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

    Public Sub ControlarSpreadEnterASiguienteFila(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim valor1 As FarPoint.Win.Spread.InputMap
        Dim valor2 As FarPoint.Win.Spread.InputMap
        valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        valor1.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRowFirstColumn)
        valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        valor1.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRowFirstColumn)
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
        Me.arriba = spEmbarques.Top
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

    Public Sub MostrarOcultarPanelDocumentos()

        If (pnlDocumentos.Visible) Then
            pnlCapturaSuperior.Enabled = True
            spEmbarques.Enabled = True
            pnlDocumentos.Visible = False
            pnlDocumentos.SendToBack()
        Else
            pnlCapturaSuperior.Enabled = False
            spEmbarques.Enabled = False
            pnlDocumentos.Visible = True
            pnlDocumentos.BringToFront()
        End If

    End Sub

    Private Sub MostrarDatosExportacionNacional()

        If (Me.opcionTipoSeleccionada = OpcionTipo.exportacion) Then
            For Each c As Control In pnlCapturaSuperior.Controls
                c.Visible = True
            Next
        ElseIf (Me.opcionTipoSeleccionada = OpcionTipo.nacional) Then
            lblAduanaMex.Visible = False
            cbAduanasMex.Visible = False
            lblAduanaUsa.Visible = False
            cbAduanasUsa.Visible = False
            lblHoraPrecos.Visible = False
            txtHoraPrecos.Visible = False
            lblGuiaCaades.Visible = False
            txtGuiaCaades.Visible = False
        End If

    End Sub

    Private Sub LimpiarPantalla()

        For Each c As Control In pnlCapturaSuperior.Controls
            c.BackColor = Color.White
        Next
        For fila = 0 To spEmbarques.ActiveSheet.Rows.Count - 1
            For columna = 0 To spEmbarques.ActiveSheet.Columns.Count - 1
                spEmbarques.ActiveSheet.Cells(fila, columna).BackColor = Color.White
            Next
        Next
        If (Not chkConservarDatos.Checked) Then
            dtpFecha.Value = Today
            txtHora.Text = Now.Hour.ToString().PadLeft(2, "0") & ":" & Now.Minute.ToString().PadLeft(2, "0")
            cbEmbarcadores.SelectedIndex = 0
            cbClientes.SelectedIndex = 0
            cbAduanasMex.SelectedIndex = 0
            cbAduanasUsa.SelectedIndex = 0
            cbDocumentadores.SelectedIndex = 0
        End If
        cbLineasTransportes.SelectedIndex = 0
        If (cbTrailers.Items.Count > 0) Then
            cbTrailers.SelectedIndex = 0
        End If
        cbCajasTrailers.SelectedIndex = 0
        cbChoferes.SelectedIndex = 0
        txtTemperatura.Text = String.Empty
        txtTermografo.Text = String.Empty
        txtPrecioFlete.Text = String.Empty
        txtHoraPrecos.Text = String.Empty
        txtSello1.Text = String.Empty
        txtSello2.Text = String.Empty
        txtSello3.Text = String.Empty
        txtSello4.Text = String.Empty
        txtSello5.Text = String.Empty
        txtSello6.Text = String.Empty
        txtSello7.Text = String.Empty
        txtSello8.Text = String.Empty
        txtFactura.Text = String.Empty
        txtGuiaCaades.Text = String.Empty
        spEmbarques.ActiveSheet.DataSource = Nothing
        spEmbarques.ActiveSheet.Rows.Count = 1
        spEmbarques.ActiveSheet.SetActiveCell(0, 0)
        LimpiarSpread(spEmbarques) 

    End Sub
     
    Private Sub LimpiarSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        spread.ActiveSheet.ClearRange(0, 0, spread.ActiveSheet.Rows.Count, spread.ActiveSheet.Columns.Count, True)

    End Sub

    Public Sub IniciarHilosCarga()

        CheckForIllegalCrossThreadCalls = False
        hiloNombrePrograma.Start()
        hiloCentrar.Start() 
        hiloEncabezadosTitulos.Start()
        hiloFecha.Start()

    End Sub

    Private Sub CargarFechaHora()

        txtHora.Text = Now.Hour.ToString().PadLeft(2, "0") & ":" & Now.Minute.ToString().PadLeft(2, "0")
        hiloFecha.Abort()

    End Sub

    Private Sub CargarProductores()

        cbEmbarcadores.DataSource = productores.ObtenerListadoReporte()
        cbEmbarcadores.DisplayMember = "Nombre"
        cbEmbarcadores.ValueMember = "Id"

    End Sub

    Private Sub CargarClientes()

        cbClientes.DataSource = clientes.ObtenerListadoReporte()
        cbClientes.DisplayMember = "Nombre"
        cbClientes.ValueMember = "Id"

    End Sub

    Private Sub CargarLineasTransportes()

        cbLineasTransportes.DataSource = lineasTransportes.ObtenerListadoReporte()
        cbLineasTransportes.DisplayMember = "Nombre"
        cbLineasTransportes.ValueMember = "Id"

    End Sub

    Private Sub CargarTrailers()

        If (Me.estaMostrado) Then
            Dim idLineaTransporte As Integer = cbLineasTransportes.SelectedValue
            If (idLineaTransporte > 0) Then
                trailers.EIdLineaTransporte = idLineaTransporte
                trailers.EId = 0
                cbTrailers.DataSource = trailers.ObtenerListadoReporte()
                cbTrailers.DisplayMember = "Nombre"
                cbTrailers.ValueMember = "Id"
            End If
        End If

    End Sub

    Private Sub CargarCajasTrailers()

        cbCajasTrailers.DataSource = cajasTrailers.ObtenerListadoReporte()
        cbCajasTrailers.DisplayMember = "Nombre"
        cbCajasTrailers.ValueMember = "Id"

    End Sub

    Private Sub CargarChoferes()

        cbChoferes.DataSource = choferes.ObtenerListadoReporte()
        cbChoferes.DisplayMember = "Nombre"
        cbChoferes.ValueMember = "Id"

    End Sub

    Private Sub CargarAduanasMex()

        cbAduanasMex.DataSource = aduanasMex.ObtenerListadoReporte()
        cbAduanasMex.DisplayMember = "Nombre"
        cbAduanasMex.ValueMember = "Id"

    End Sub

    Private Sub CargarAduanasUsa()

        cbAduanasUsa.DataSource = aduanasUsa.ObtenerListadoReporte()
        cbAduanasUsa.DisplayMember = "Nombre"
        cbAduanasUsa.ValueMember = "Id"

    End Sub

    Private Sub CargarDocumentadores()

        cbDocumentadores.DataSource = documentadores.ObtenerListadoReporte()
        cbDocumentadores.DisplayMember = "Nombre"
        cbDocumentadores.ValueMember = "Id"

    End Sub

    Private Sub FormatearSpread()

        ' Se cargan tipos de datos de spread.
        CargarTiposDeDatos()
        ' Se cargan las opciones generales. 
        pnlCatalogos.Visible = False
        spEmbarques.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight
        spEmbarques.ActiveSheet.GrayAreaBackColor = Principal.colorAreaGris
        spEmbarques.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spCatalogos.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Regular)
        spEmbarques.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosGrandesSpread
        spEmbarques.ActiveSheet.Rows(-1).Height = Principal.alturaFilasMedianasSpread
        spCatalogos.ActiveSheet.Rows(-1).Height = Principal.alturaFilasMedianasSpread
        spEmbarques.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spEmbarques.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spEmbarques.EditModeReplace = True
        'Application.DoEvents() 

    End Sub

    Private Sub CargarDatosEnSpreadDeCatalogos(ByVal filaCatalogos As Integer)

        'If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.cliente) Then
        '    spEmbarques.ActiveSheet.Cells(spEmbarques.ActiveSheet.ActiveRowIndex, spEmbarques.ActiveSheet.Columns("idLote").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("id").Index).Text
        '    spEmbarques.ActiveSheet.Cells(spEmbarques.ActiveSheet.ActiveRowIndex, spEmbarques.ActiveSheet.Columns("nombreLote").Index).Text = spCatalogos.ActiveSheet.Cells(filaCatalogos, spCatalogos.ActiveSheet.Columns("nombre").Index).Text 
        'End If

    End Sub

    Private Sub CargarCatalogoEnSpread()

        'spEmbarques.Enabled = False
        'Dim columna As Integer = spEmbarques.ActiveSheet.ActiveColumnIndex
        'Dim fila As Integer = spEmbarques.ActiveSheet.ActiveRowIndex
        'If (columna = spEmbarques.ActiveSheet.Columns("idLote").Index) Or (columna = spEmbarques.ActiveSheet.Columns("nombreLote").Index) Then
        '    Me.opcionCatalogoSeleccionada = OpcionCatalogo.cliente
        '    clientes.EId = 0
        '    Dim datos As New DataTable
        '    datos = clientes.ObtenerListadoReporte()
        '    If (datos.Rows.Count > 0) Then
        '        spCatalogos.ActiveSheet.DataSource = datos
        '    Else
        '        spCatalogos.ActiveSheet.DataSource = Nothing
        '        spCatalogos.ActiveSheet.Rows.Count = 0
        '        spEmbarques.Enabled = True
        '    End If
        '    FormatearSpreadCatalogo(OpcionPosicion.derecha)
        'End If

    End Sub

    Private Sub FormatearSpreadCatalogo(ByVal posicion As Integer)

        'If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad Or Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano) Then
        '    spCatalogos.Width = 570
        '    spCatalogos.ActiveSheet.Columns.Count = 4
        'Else
        '    spCatalogos.Width = 320
        '    spCatalogos.ActiveSheet.Columns.Count = 2
        'End If
        'If (posicion = OpcionPosicion.izquierda) Then ' Izquierda.
        '    pnlCatalogos.Location = New Point(Me.izquierda, Me.arriba)
        'ElseIf (posicion = OpcionPosicion.centro) Then ' Centrar.
        '    pnlCatalogos.Location = New Point(Me.anchoMitad - (spCatalogos.Width / 2), Me.arriba)
        'ElseIf (posicion = OpcionPosicion.derecha) Then ' Derecha.
        '    pnlCatalogos.Location = New Point(Me.anchoTotal - spCatalogos.Width, Me.arriba)
        'End If
        'spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        'spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosMedianosSpread
        'spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        'spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        'spCatalogos.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        'Dim numeracion As Integer = 0
        'If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad Or Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano) Then
        '    spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idProducto" : numeracion += 1
        '    spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        'End If
        'spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        'spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        'If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad Or Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano) Then
        '    spCatalogos.ActiveSheet.Columns("idProducto").Width = 50
        '    spCatalogos.ActiveSheet.Columns("nombreProducto").Width = 200
        'End If
        'spCatalogos.ActiveSheet.Columns("id").Width = 50
        'spCatalogos.ActiveSheet.Columns("nombre").Width = 235
        'If (Me.opcionCatalogoSeleccionada = OpcionCatalogo.variedad Or Me.opcionCatalogoSeleccionada = OpcionCatalogo.tamano) Then
        '    spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("idProducto").Index).Value = "No.".ToUpper
        '    spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombreProducto").Index).Value = "Nombre Producto".ToUpper
        'End If
        'spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        'spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        'pnlCatalogos.Height = spEmbarques.Height
        'pnlCatalogos.Size = spCatalogos.Size
        'pnlCatalogos.BringToFront()
        'pnlCatalogos.Visible = True
        'AsignarFoco(pnlCatalogos)
        'AsignarFoco(spCatalogos)
        'Application.DoEvents()

    End Sub

    Private Sub VolverFocoCatalogos()

        spEmbarques.Enabled = True
        AsignarFoco(spEmbarques)
        pnlCatalogos.Visible = False

    End Sub

    Private Sub EliminarRegistroDeSpread(ByVal spread As FarPoint.Win.Spread.FpSpread)

        spread.ActiveSheet.ClearRange(spread.ActiveSheet.ActiveRowIndex, 0, 1, spread.ActiveSheet.Columns.Count, False)
        spread.ActiveSheet.SetActiveCell(spread.ActiveSheet.ActiveRowIndex, 0)

    End Sub

    Private Sub ControlarSpreadEnter(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim columnaActiva As Integer = spread.ActiveSheet.ActiveColumnIndex
        Dim filaActiva As Integer = 0
        If (spread.Name = spEmbarques.Name) Then
            If (columnaActiva = spEmbarques.ActiveSheet.Columns("idTarima").Index) Then
                filaActiva = spEmbarques.ActiveSheet.ActiveRowIndex
                Dim idTarima As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.Columns("idTarima").Index).Value)
                Dim idTarima2 As String = EYELogicaEmbarques.Funciones.ValidarLetra(spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.Columns("idTarima").Index).Text)
                If (idTarima > 0) Then
                    tarimas.EId = idTarima
                    ' Se validan los registros que son nuevos unicamente.
                    If (spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.Columns("esExistente").Index).Value) Then
                        Exit Sub
                    Else
                        Dim listaTarimasParaValidar As List(Of EYEEntidadesEmbarques.Tarimas)
                        listaTarimasParaValidar = tarimas.ObtenerParaValidar()
                        If (listaTarimasParaValidar.Count > 0) Then
                            If (listaTarimasParaValidar(0).EEstaEmbarcado) Then
                                MsgBox(String.Format("Esta tarima ya fue embarcada en el embarque número {0}, en la posición {1}, con destino de {2}.", listaTarimasParaValidar(0).EIdEmbarque, listaTarimasParaValidar(0).EOrdenEmbarque + 1, IIf(listaTarimasParaValidar(0).EIdTipoEmbarque = 1, "exportación", "nacional")), MsgBoxStyle.Exclamation, "No permitido.")
                            ElseIf (listaTarimasParaValidar(0).EEsSobrante) Then
                                MsgBox("Esta tarima es sobrante.", MsgBoxStyle.Exclamation, "No permitido.")
                            End If
                        Else
                            MsgBox("Esta tarima no existe.", MsgBoxStyle.Exclamation, "No permitido.")
                        End If
                    End If
                    Dim listaTarimas As List(Of EYEEntidadesEmbarques.Tarimas)
                    listaTarimas = tarimas.ObtenerParaCargar()
                    If (listaTarimas.Count = 1) Then
                        spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.Columns("nombreProducto").Index).Value = listaTarimas(0).EAbreviaturaProducto
                        spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.Columns("nombreVariedad").Index).Value = listaTarimas(0).EAbreviaturaVariedad
                        spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.Columns("nombreEnvase").Index).Value = listaTarimas(0).EAbreviaturaEnvase
                        spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.Columns("nombreTamano").Index).Value = listaTarimas(0).EAbreviaturaTamano
                        spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.Columns("nombreEtiqueta").Index).Value = listaTarimas(0).EAbreviaturaEtiqueta
                        spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.Columns("cantidadCajas").Index).Value = listaTarimas(0).ECantidadCajas
                        If (listaTarimas(0).ERegistros > 2) Then
                            spEmbarques.ActiveSheet.Rows(filaActiva).Height = Principal.alturaFilasMedianasSpread * 2
                        Else
                            spEmbarques.ActiveSheet.Rows(filaActiva).Height = Principal.alturaFilasMedianasSpread
                        End If
                        spEmbarques.ActiveSheet.SetActiveCell(filaActiva, spEmbarques.ActiveSheet.ActiveColumnIndex + 1)
                    Else
                        spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.ActiveColumnIndex, filaActiva, spEmbarques.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                        spEmbarques.ActiveSheet.SetActiveCell(filaActiva, spEmbarques.ActiveSheet.ActiveColumnIndex - 1)
                    End If
                ElseIf (idTarima < 0 Or Not String.IsNullOrEmpty(idTarima2)) Then
                    MsgBox("Este número de tarima no es válido.", MsgBoxStyle.Exclamation, "No permitido.")
                    spEmbarques.ActiveSheet.Cells(filaActiva, spEmbarques.ActiveSheet.ActiveColumnIndex, filaActiva, spEmbarques.ActiveSheet.ActiveColumnIndex).Text = String.Empty
                    spEmbarques.ActiveSheet.SetActiveCell(filaActiva, spEmbarques.ActiveSheet.ActiveColumnIndex - 1)
                End If
                If (filaActiva = spread.ActiveSheet.Rows.Count - 1) Then
                    spread.ActiveSheet.Rows.Count += 1
                End If
            End If
        End If

    End Sub

    Private Sub CargarIdConsecutivo()

        embarques.EIdTipo = Me.opcionTipoSeleccionada
        Dim idMaximo As Integer = embarques.ObtenerMaximoId()
        txtId.Text = idMaximo

    End Sub

    Private Sub CargarEmbarques()

        Me.Cursor = Cursors.WaitCursor
        embarques.EIdTipo = Me.opcionTipoSeleccionada
        embarques.EId = EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtId.Text)
        If (embarques.EIdTipo > 0 AndAlso embarques.EId > 0) Then
            Dim lista As New List(Of EYEEntidadesEmbarques.Embarques)
            lista = embarques.ObtenerListado()
            If (lista.Count > 0) Then
                dtpFecha.Value = lista(0).EFecha
                txtHora.Text = lista(0).EHora
                cbEmbarcadores.SelectedValue = lista(0).EIdEmbarcador
                cbClientes.SelectedValue = lista(0).EIdCliente
                cbLineasTransportes.SelectedValue = lista(0).EIdLineaTransporte
                cbTrailers.SelectedValue = lista(0).EIdTrailer
                cbCajasTrailers.SelectedValue = lista(0).EIdCajaTrailer
                cbChoferes.SelectedValue = lista(0).EIdChofer
                cbAduanasMex.SelectedValue = lista(0).EIdAduanaMex
                cbAduanasUsa.SelectedValue = lista(0).EIdAduanaUsa
                cbDocumentadores.SelectedValue = lista(0).EIdDocumentador
                txtTemperatura.Text = lista(0).ETemperatura
                txtTermografo.Text = lista(0).ETermografo
                txtPrecioFlete.Text = lista(0).EPrecioFlete
                txtHoraPrecos.Text = lista(0).EHoraPrecos
                txtSello1.Text = lista(0).ESello1
                txtSello2.Text = lista(0).ESello2
                txtSello3.Text = lista(0).ESello3
                txtSello4.Text = lista(0).ESello4
                txtSello5.Text = lista(0).ESello5
                txtSello6.Text = lista(0).ESello6
                txtSello7.Text = lista(0).ESello7
                txtSello8.Text = lista(0).ESello8
                txtFactura.Text = lista(0).EFactura
                txtGuiaCaades.Text = lista(0).EGuiaCaades
                ' Se rellena a pata, ya que con el datasource no permitía quitar el id de la tarima ni la cantidad de cajas.
                Dim datos As New DataTable
                datos = embarques.ObtenerListadoReporte()
                spEmbarques.ActiveSheet.Columns.Count = 0
                spEmbarques.ActiveSheet.Rows.Count = 0
                spEmbarques.ActiveSheet.Columns.Count = datos.Columns.Count
                spEmbarques.ActiveSheet.Rows.Count = 500
                Dim fila As Integer = 0 : Dim filaSpread As Integer = 0
                While fila < datos.Rows.Count
                    Dim orden As Integer = datos.Rows(fila).Item("OrdenEmbarque").ToString()
                    If (filaSpread = orden) Then
                        For columna = 0 To spEmbarques.ActiveSheet.Columns.Count - 1
                            spEmbarques.ActiveSheet.Cells(filaSpread, columna).Text = datos.Rows(fila).Item(columna).ToString()
                        Next
                        fila += 1
                    End If
                    filaSpread += 1
                End While
                cantidadFilas = filaSpread + 1
                FormatearSpreadEmbarques()
                btnGenerarDocumentos.Enabled = True
                btnEnviarCorreos.Enabled = True
            Else
                LimpiarPantalla()
                btnGenerarDocumentos.Enabled = False
                btnEnviarCorreos.Enabled = False
            End If
        Else
            btnGenerarDocumentos.Enabled = False
            btnEnviarCorreos.Enabled = False
        End If
        AsignarFoco(dtpFecha)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FormatearSpreadEmbarques()

        spEmbarques.ActiveSheet.ColumnHeader.RowCount = 2
        spEmbarques.ActiveSheet.ColumnHeader.Rows(0, spEmbarques.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpread, FontStyle.Bold)
        spEmbarques.ActiveSheet.ColumnHeader.Rows(0).Height = Principal.alturaFilasEncabezadosChicosSpread
        spEmbarques.ActiveSheet.ColumnHeader.Rows(1).Height = Principal.alturaFilasEncabezadosMedianosSpread
        spEmbarques.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        spEmbarques.ActiveSheet.Rows.Count = cantidadFilas
        ControlarSpreadEnterASiguienteFila(spEmbarques)
        Dim numeracion As Integer = 0
        spEmbarques.ActiveSheet.Columns(numeracion).Tag = "idTarima" : numeracion += 1
        spEmbarques.ActiveSheet.Columns(numeracion).Tag = "nombreProducto" : numeracion += 1
        spEmbarques.ActiveSheet.Columns(numeracion).Tag = "nombreVariedad" : numeracion += 1
        spEmbarques.ActiveSheet.Columns(numeracion).Tag = "nombreEnvase" : numeracion += 1
        spEmbarques.ActiveSheet.Columns(numeracion).Tag = "nombreTamano" : numeracion += 1
        spEmbarques.ActiveSheet.Columns(numeracion).Tag = "nombreEtiqueta" : numeracion += 1
        spEmbarques.ActiveSheet.Columns(numeracion).Tag = "cantidadCajas" : numeracion += 1
        spEmbarques.ActiveSheet.Columns(numeracion).Tag = "esExistente" : numeracion += 1
        spEmbarques.ActiveSheet.Columns.Count = numeracion
        spEmbarques.ActiveSheet.Columns("idTarima").Width = 85
        spEmbarques.ActiveSheet.Columns("nombreProducto").Width = 250
        spEmbarques.ActiveSheet.Columns("nombreVariedad").Width = 250
        spEmbarques.ActiveSheet.Columns("nombreEnvase").Width = 250
        spEmbarques.ActiveSheet.Columns("nombreTamano").Width = 250
        spEmbarques.ActiveSheet.Columns("nombreEtiqueta").Width = 250
        spEmbarques.ActiveSheet.Columns("cantidadCajas").Width = 100
        spEmbarques.ActiveSheet.Columns("idTarima").CellType = tipoEntero
        spEmbarques.ActiveSheet.Columns("nombreProducto").CellType = tipoTexto
        spEmbarques.ActiveSheet.Columns("nombreVariedad").CellType = tipoTexto
        spEmbarques.ActiveSheet.Columns("nombreTamano").CellType = tipoTexto
        spEmbarques.ActiveSheet.Columns("nombreEnvase").CellType = tipoTexto
        spEmbarques.ActiveSheet.Columns("nombreEtiqueta").CellType = tipoTexto
        spEmbarques.ActiveSheet.Columns("cantidadCajas").CellType = tipoEntero
        spEmbarques.ActiveSheet.Columns("esExistente").CellType = tipoBooleano
        spEmbarques.ActiveSheet.Columns(spEmbarques.ActiveSheet.Columns("nombreProducto").Index, spEmbarques.ActiveSheet.Columns("nombreEtiqueta").Index).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spEmbarques.ActiveSheet.AddColumnHeaderSpanCell(0, spEmbarques.ActiveSheet.Columns("idTarima").Index, 2, 1)
        spEmbarques.ActiveSheet.ColumnHeader.Cells(0, spEmbarques.ActiveSheet.Columns("idTarima").Index).Value = "No. Tarima *".ToUpper()
        spEmbarques.ActiveSheet.AddColumnHeaderSpanCell(0, spEmbarques.ActiveSheet.Columns("nombreProducto").Index, 1, spEmbarques.ActiveSheet.Columns("nombreEtiqueta").Index + 1 - spEmbarques.ActiveSheet.Columns("nombreProducto").Index)
        spEmbarques.ActiveSheet.ColumnHeader.Cells(0, spEmbarques.ActiveSheet.Columns("nombreProducto").Index).Value = "P r e s e n t a c i ó n".ToUpper()
        spEmbarques.ActiveSheet.ColumnHeader.Cells(1, spEmbarques.ActiveSheet.Columns("nombreProducto").Index).Value = "Producto".ToUpper()
        spEmbarques.ActiveSheet.ColumnHeader.Cells(1, spEmbarques.ActiveSheet.Columns("nombreVariedad").Index).Value = "Variedad".ToUpper()
        spEmbarques.ActiveSheet.ColumnHeader.Cells(1, spEmbarques.ActiveSheet.Columns("nombreEnvase").Index).Value = "Envase".ToUpper()
        spEmbarques.ActiveSheet.ColumnHeader.Cells(1, spEmbarques.ActiveSheet.Columns("nombreTamano").Index).Value = "Tamaño".ToUpper()
        spEmbarques.ActiveSheet.ColumnHeader.Cells(1, spEmbarques.ActiveSheet.Columns("nombreEtiqueta").Index).Value = "Etiqueta".ToUpper()
        spEmbarques.ActiveSheet.AddColumnHeaderSpanCell(0, spEmbarques.ActiveSheet.Columns("cantidadCajas").Index, 2, 1)
        spEmbarques.ActiveSheet.ColumnHeader.Cells(0, spEmbarques.ActiveSheet.Columns("cantidadCajas").Index).Value = "Cantidad Cajas".ToUpper()
        spEmbarques.ActiveSheet.Columns(spEmbarques.ActiveSheet.Columns("nombreProducto").Index, spEmbarques.ActiveSheet.Columns.Count - 1).Locked = True
        spEmbarques.ActiveSheet.Columns("esExistente").Visible = False
        'Application.DoEvents() 

    End Sub

    Private Sub ValidarGuardado()

        Me.Cursor = Cursors.WaitCursor
        Me.esGuardadoValido = True
        ' Parte superior.
        Dim id As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtId.Text)
        If (id <= 0) Then
            txtId.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim hora As String = txtHora.Text
        If (String.IsNullOrEmpty(hora) Or hora.Length <> 5 Or Not IsDate(hora)) Then
            txtHora.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idEmbarcador As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbEmbarcadores.SelectedValue)
        If (idEmbarcador <= 0) Then
            cbEmbarcadores.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idCliente As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbClientes.SelectedValue)
        If (idCliente <= 0) Then
            cbClientes.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idLinea As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbLineasTransportes.SelectedValue)
        If (idLinea <= 0) Then
            cbLineasTransportes.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idTrailer As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbTrailers.SelectedValue)
        If (idTrailer <= 0) Then
            cbTrailers.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idCaja As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbCajasTrailers.SelectedValue)
        If (idCaja <= 0) Then
            cbCajasTrailers.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim idChofer As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbChoferes.SelectedValue)
        If (idChofer <= 0) Then
            cbChoferes.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        If (Me.opcionTipoSeleccionada = OpcionTipo.exportacion) Then
            Dim idAduanaMex As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbAduanasMex.SelectedValue)
            If (idAduanaMex <= 0) Then
                cbAduanasMex.BackColor = Color.Orange
                Me.esGuardadoValido = False
            End If
            Dim idAduanaUsa As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbAduanasUsa.SelectedValue)
            If (idAduanaUsa <= 0) Then
                cbAduanasUsa.BackColor = Color.Orange
                Me.esGuardadoValido = False
            End If
        End If
        Dim idDocumentador As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbDocumentadores.SelectedValue)
        If (idDocumentador <= 0) Then
            cbDocumentadores.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim temperatura As Double = EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtTemperatura.Text)
        If (temperatura <= 0) Then
            txtTemperatura.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim termografo As String = EYELogicaEmbarques.Funciones.ValidarLetra(txtTermografo.Text)
        If (String.IsNullOrEmpty(termografo)) Then
            txtTermografo.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim precioFlete As Double = EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtPrecioFlete.Text)
        If (precioFlete <= 0) Then
            txtPrecioFlete.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        If (Me.opcionTipoSeleccionada = OpcionTipo.exportacion) Then
            Dim horaPrecos As String = txtHoraPrecos.Text
            If (String.IsNullOrEmpty(horaPrecos) Or horaPrecos.Length <> 5 Or Not IsDate(horaPrecos)) Then
                txtHoraPrecos.BackColor = Color.Orange
                Me.esGuardadoValido = False
            End If
        End If
        Dim sello1 As String = txtSello1.Text
        If (String.IsNullOrEmpty(sello1)) Then
            txtSello1.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        Dim factura As String = txtFactura.Text
        If (String.IsNullOrEmpty(factura)) Then
            txtFactura.BackColor = Color.Orange
            Me.esGuardadoValido = False
        End If
        ' Parte inferior.
        For fila As Integer = 0 To spEmbarques.ActiveSheet.Rows.Count - 1
            Dim cantidadCajas As String = spEmbarques.ActiveSheet.Cells(fila, spEmbarques.ActiveSheet.Columns("cantidadCajas").Index).Text
            Dim cantidadCajas2 As Double = EYELogicaEmbarques.Funciones.ValidarNumeroACero(spEmbarques.ActiveSheet.Cells(fila, spEmbarques.ActiveSheet.Columns("cantidadCajas").Index).Text)
            If (Not String.IsNullOrEmpty(cantidadCajas) Or cantidadCajas2 > 0) Then
                Dim idTarima As String = spEmbarques.ActiveSheet.Cells(fila, spEmbarques.ActiveSheet.Columns("idTarima").Index).Text
                Dim idTarima2 As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(spEmbarques.ActiveSheet.Cells(fila, spEmbarques.ActiveSheet.Columns("idTarima").Index).Text)
                If (String.IsNullOrEmpty(idTarima) Or idTarima2 < 0) Then
                    spEmbarques.ActiveSheet.Cells(fila, spEmbarques.ActiveSheet.Columns("idTarima").Index, fila, spEmbarques.ActiveSheet.Columns.Count - 1).BackColor = Color.Orange
                    Me.esGuardadoValido = False
                End If
            End If
        Next
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GuardarEditarEmbarques()

        Me.Cursor = Cursors.WaitCursor
        EliminarEmbarques(False)
        ' Parte superior. 
        Dim id As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtId.Text)
        Dim idTipo As Integer = Me.opcionTipoSeleccionada
        Dim fecha As Date = dtpFecha.Value
        Dim hora As String = txtHora.Text
        Dim idEmbarcador As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbEmbarcadores.SelectedValue)
        Dim idCliente As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbClientes.SelectedValue)
        Dim idLinea As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbLineasTransportes.SelectedValue)
        Dim idTrailer As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbTrailers.SelectedValue)
        Dim idCajaTrailer As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbCajasTrailers.SelectedValue)
        Dim idChofer As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbChoferes.SelectedValue)
        Dim idAduanaMex As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbAduanasMex.SelectedValue)
        Dim idAduanaUsa As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbAduanasUsa.SelectedValue)
        Dim idDocumentador As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(cbClientes.SelectedValue)
        Dim temperatura As Double = EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtTemperatura.Text)
        Dim termografo As String = txtTermografo.Text
        Dim precioFlete As Double = EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtPrecioFlete.Text)
        Dim horaPrecos As String = txtHoraPrecos.Text
        If (Me.opcionTipoSeleccionada = OpcionTipo.nacional) Then
            horaPrecos = "00:00"
        End If
        Dim sello1 As String = txtSello1.Text
        Dim sello2 As String = txtSello2.Text
        Dim sello3 As String = txtSello3.Text
        Dim sello4 As String = txtSello4.Text
        Dim sello5 As String = txtSello5.Text
        Dim sello6 As String = txtSello6.Text
        Dim sello7 As String = txtSello7.Text
        Dim sello8 As String = txtSello8.Text
        Dim factura As String = txtFactura.Text
        Dim guiaCaades As String = txtGuiaCaades.Text
        ' Datos no capturables por el usuario. 
        Dim idProductor As Integer = 0 ' No se ocupa aun.
        Dim banderin As String = String.Empty ' No se usará aun.
        Dim observaciones As String = String.Empty ' Pendiente
        If (id > 0 AndAlso IsDate(fecha) And Not String.IsNullOrEmpty(hora) AndAlso idEmbarcador > 0 AndAlso idCliente > 0 AndAlso idLinea > 0 AndAlso idTrailer > 0 AndAlso idCajaTrailer AndAlso idChofer > 0 AndAlso IIf(Me.opcionTipoSeleccionada = OpcionTipo.exportacion, idAduanaMex > 0, True) AndAlso IIf(Me.opcionTipoSeleccionada = OpcionTipo.exportacion, idAduanaUsa > 0, True) AndAlso idEmbarcador > 0) Then
            embarques.EId = id
            embarques.EIdTipo = idTipo
            embarques.EIdProductor = idProductor
            embarques.EIdEmbarcador = idEmbarcador
            embarques.EIdCliente = idCliente
            embarques.EIdLineaTransporte = idLinea
            embarques.EIdTrailer = idTrailer
            embarques.EIdCajaTrailer = idCajaTrailer
            embarques.EIdChofer = idChofer
            embarques.EIdAduanaMex = idAduanaMex
            embarques.EIdAduanaUsa = idAduanaUsa
            embarques.EIdDocumentador = idDocumentador
            embarques.EFecha = fecha
            embarques.EHora = hora
            embarques.ETemperatura = temperatura
            embarques.ETermografo = termografo
            embarques.EPrecioFlete = precioFlete
            embarques.EHoraPrecos = horaPrecos
            embarques.ESello1 = sello1
            embarques.ESello2 = sello2
            embarques.ESello3 = sello3
            embarques.ESello4 = sello4
            embarques.ESello5 = sello5
            embarques.ESello6 = sello6
            embarques.ESello7 = sello7
            embarques.ESello8 = sello8
            embarques.EFactura = factura
            embarques.EGuiaCaades = guiaCaades
            embarques.EBanderin = banderin
            embarques.EObservaciones = observaciones
            embarques.Guardar()
            EditarIncluirTarimas(id, idEmbarcador, idCliente)
        End If
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        LimpiarPantalla()
        CargarIdConsecutivo()
        AsignarFoco(txtId)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EditarExcluirTarimas()

        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtId.Text)
        tarimas.EIdEmbarque = idEmbarque
        tarimas.EIdTipoEmbarque = Me.opcionTipoSeleccionada
        tarimas.EditarExcluirEnEmbarque()

    End Sub

    Private Sub EditarIncluirTarimas(ByVal idEmbarque As Integer, ByVal idEmbarcador As Integer, ByVal idCliente As Integer)

        For fila As Integer = 0 To spEmbarques.ActiveSheet.Rows.Count - 1
            Dim idTarima As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(spEmbarques.ActiveSheet.Cells(fila, spEmbarques.ActiveSheet.Columns("idTarima").Index).Text)
            If (idTarima > 0) Then
                tarimas.EIdEmbarcador = idEmbarcador
                tarimas.EIdCliente = idCliente
                tarimas.EIdEmbarque = idEmbarque
                tarimas.EId = idTarima
                tarimas.EIdTipoEmbarque = Me.opcionTipoSeleccionada
                tarimas.EOrdenEmbarque = fila
                tarimas.EditarIncluirEnEmbarque()
            End If
        Next

    End Sub

    Private Sub EliminarEmbarques(ByVal conMensaje As Boolean)

        Me.Cursor = Cursors.WaitCursor
        Dim respuestaSi As Boolean = False
        If (conMensaje) Then
            If (MessageBox.Show("Confirmas que deseas eliminar este embarque?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                respuestaSi = True
            End If
        End If
        If ((respuestaSi) Or (Not conMensaje)) Then
            EditarExcluirTarimas()
            embarques.EId = EYELogicaEmbarques.Funciones.ValidarNumeroACero(txtId.Text)
            embarques.EIdTipo = Me.opcionTipoSeleccionada
            embarques.Eliminar()
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

        cliente = 1

    End Enum

    Enum OpcionTipo

        exportacion = 1
        nacional = 2

    End Enum

#End Region

    Private Sub btnEnviarCorreos_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreos.Click

        Correos.Show()
        pnlContenido.Enabled = False

    End Sub

    Private Sub btnEnviarCorreos_MouseEnter(sender As Object, e As EventArgs) Handles btnEnviarCorreos.MouseEnter

        AsignarTooltips("Enviar Correos.")

    End Sub
     
End Class