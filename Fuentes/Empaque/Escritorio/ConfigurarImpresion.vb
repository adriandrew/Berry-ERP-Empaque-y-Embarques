Imports System.Drawing.Printing.PrinterSettings

Public Class ConfigurarImpresion

    ' Variables de objetos de entidades.
    Public impresoras As New EYEEntidadesEmpaque.Impresoras()
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public tipoImpresora As Integer = 3 ' Siempre es 3 en el catalogo.
    Public Shared nombreImpresoraTarima As String = String.Empty
    Public Shared habilitarImpresoraTarima As Boolean = False
    Public Shared margenIzquierdoTarima As Integer = 0
    Public Shared margenSuperiorTarima As Integer = 0
    Public Shared nombreImpresoraCaja As String = String.Empty
    Public Shared habilitarImpresoraCaja As Boolean = False
    Public Shared margenIzquierdoCaja As Integer = 0
    Public Shared margenSuperiorCaja As Integer = 0

#Region "Eventos"

    Private Sub ConfigurarImpresion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Centrar()
        CargarNombrePrograma()
        AsignarTooltips()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ConfigurarImpresion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Me.Cursor = Cursors.WaitCursor
        CargarTitulosDirectorio()
        CargarImpresoras(False)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ConfigurarImpresion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Principal.Enabled = True

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Salir()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        GuardarEditar()

    End Sub

#End Region

#Region "Métodos"

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Opacity = 0.98

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
        tp.SetToolTip(Me.btnAyuda, "Ayuda.")
        tp.SetToolTip(Me.btnSalir, "Salir.")

    End Sub

    Private Sub CargarTitulosDirectorio()

        Me.Text = "Programa:  " + Me.nombreEstePrograma + "              Directorio:  " + EYELogicaEmpaque.Directorios.nombre + "              Usuario:  " + EYELogicaEmpaque.Usuarios.nombre

    End Sub

    Private Sub Salir()

        Me.Close()

    End Sub

    Private Sub GuardarEditar()

        Me.Cursor = Cursors.WaitCursor
        impresoras.EIdTipo = Me.tipoImpresora
        impresoras.EId = 0
        impresoras.Eliminar()
        Dim id As Integer = 0
        Dim nombre As String = String.Empty
        Dim habilitar As Boolean = False
        Dim margenIzquierdo As Double = 0
        Dim margenDerecho As Double = 0
        ' Impresora de tarima.
        id = OpcionTipoEtiqueta.tarima
        nombre = cbImpresorasTarimas.Text
        habilitar = chkImprimirTarimas.Checked
        margenIzquierdo = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtMargenIzquierdoTarimas.Text)
        margenDerecho = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtMargenDerechoTarimas.Text)
        impresoras.EId = id
        impresoras.ENombre = nombre
        impresoras.EHabilitar = habilitar
        impresoras.EMargenIzquierdo = margenIzquierdo
        impresoras.EMargenSuperior = margenDerecho
        If (Not String.IsNullOrEmpty(nombre)) Then
            impresoras.Guardar()
        End If
        ' Impresora de caja.
        id = OpcionTipoEtiqueta.caja
        nombre = cbImpresorasCajas.Text
        habilitar = chkImprimirCajas.Checked
        margenIzquierdo = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtMargenIzquierdoCajas.Text)
        margenDerecho = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtMargenDerechoCajas.Text)
        impresoras.EId = id
        impresoras.ENombre = nombre
        impresoras.EHabilitar = habilitar
        impresoras.EMargenIzquierdo = margenIzquierdo
        impresoras.EMargenSuperior = margenDerecho
        If (Not String.IsNullOrEmpty(nombre)) Then
            impresoras.Guardar()
        End If
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarImpresoras(False)
        Me.Cursor = Cursors.Default

    End Sub

    Public Sub CargarImpresoras(ByVal soloVariables As Boolean)

        impresoras.EIdTipo = Me.tipoImpresora
        ' Se carga la impresora de tarima.
        impresoras.EId = OpcionTipoEtiqueta.tarima
        Dim listaImpresoraTarima As New List(Of EYEEntidadesEmpaque.Impresoras)
        listaImpresoraTarima = impresoras.ObtenerListado() 
        If (listaImpresoraTarima.Count > 0) Then
            ConfigurarImpresion.nombreImpresoraTarima = listaImpresoraTarima(0).ENombre
            ConfigurarImpresion.habilitarImpresoraTarima = listaImpresoraTarima(0).EHabilitar
            ConfigurarImpresion.margenIzquierdoTarima = listaImpresoraTarima(0).EMargenIzquierdo
            ConfigurarImpresion.margenSuperiorTarima = listaImpresoraTarima(0).EMargenSuperior
        End If
        If (Not soloVariables) Then
            If (listaImpresoraTarima.Count > 0) Then
                chkImprimirTarimas.Checked = listaImpresoraTarima(0).EHabilitar
                txtMargenIzquierdoTarimas.Text = listaImpresoraTarima(0).EMargenIzquierdo
                txtMargenDerechoTarimas.Text = listaImpresoraTarima(0).EMargenSuperior
            End If
            cbImpresorasTarimas.Items.Clear()
            For indice As Integer = 0 To InstalledPrinters.Count - 1
                Dim nombre As String = InstalledPrinters.Item(indice)
                cbImpresorasTarimas.Items.Add(nombre)
                If (listaImpresoraTarima.Count > 0) Then
                    If (listaImpresoraTarima(0).ENombre.ToUpper.Equals(nombre.ToUpper)) Then
                        cbImpresorasTarimas.SelectedIndex = indice
                    End If
                End If
            Next
        End If
        ' Se carga la impresora de caja.
        impresoras.EId = OpcionTipoEtiqueta.caja
        Dim listaImpresoraCaja As New List(Of EYEEntidadesEmpaque.Impresoras)
        listaImpresoraCaja = impresoras.ObtenerListado()
        If (listaImpresoraCaja.Count > 0) Then
            ConfigurarImpresion.nombreImpresoraCaja = listaImpresoraCaja(0).ENombre
            ConfigurarImpresion.habilitarImpresoraCaja = listaImpresoraCaja(0).EHabilitar
            ConfigurarImpresion.margenIzquierdoCaja = listaImpresoraCaja(0).EMargenIzquierdo
            ConfigurarImpresion.margenSuperiorCaja = listaImpresoraCaja(0).EMargenSuperior
        End If
        If (Not soloVariables) Then
            If (listaImpresoraCaja.Count > 0) Then
                chkImprimirCajas.Checked = listaImpresoraCaja(0).EHabilitar
                txtMargenIzquierdoCajas.Text = listaImpresoraCaja(0).EMargenIzquierdo
                txtMargenDerechoCajas.Text = listaImpresoraCaja(0).EMargenSuperior
            End If
            cbImpresorasCajas.Items.Clear()
            For indice As Integer = 0 To InstalledPrinters.Count - 1
                Dim nombre As String = InstalledPrinters.Item(indice)
                cbImpresorasCajas.Items.Add(nombre)
                If (listaImpresoraCaja.Count > 0) Then
                    If (listaImpresoraCaja(0).ENombre.ToUpper.Equals(nombre.ToUpper)) Then
                        cbImpresorasCajas.SelectedIndex = indice
                    End If
                End If
            Next
        End If

    End Sub

#End Region

#Region "Enumeraciones"

    Enum OpcionTipoEtiqueta

        tarima = 1
        caja = 2

    End Enum

#End Region

End Class