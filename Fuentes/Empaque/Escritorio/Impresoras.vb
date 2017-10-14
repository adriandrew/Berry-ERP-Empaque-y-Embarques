Imports System.Drawing.Printing.PrinterSettings

Public Class Impresoras

    ' Variables de objetos de entidades.
    Public configuracionImpresoras As New EYEEntidadesEmpaque.ConfiguracionImpresoras()
    ' Variables generales.
    Public nombreEstePrograma As String = String.Empty
    Public tipoImpresora As Integer = 3 ' Siempre es 3 en el catálogo, corresponde al area del empaque.
    Public Shared nombreImpresoraTarima As String = String.Empty
    Public Shared habilitarImpresoraTarima As Boolean = False
    Public Shared margenIzquierdoTarima As Integer = 0
    Public Shared margenSuperiorTarima As Integer = 0
    Public Shared nombreImpresoraCaja As String = String.Empty
    Public Shared habilitarImpresoraCaja As Boolean = False
    Public Shared margenIzquierdoCaja As Integer = 0
    Public Shared margenSuperiorCaja As Integer = 0

#Region "Eventos"

    Private Sub Impresion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Centrar()
        CargarNombrePrograma()
        AsignarTooltips()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Impresion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Me.Cursor = Cursors.WaitCursor
        CargarTitulosDirectorio()
        CargarImpresoras(False)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Impresion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Principal.Enabled = True

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Salir()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Me.Cursor = Cursors.WaitCursor
        GuardarEditarImpresoras()
        Me.Cursor = Cursors.Default

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
        tp.SetToolTip(Me.btnGuardar, "Guardar.")
        tp.SetToolTip(Me.btnSalir, "Salir.")

    End Sub

    Private Sub CargarTitulosDirectorio()

        Me.Text = "Programa:  " & Me.nombreEstePrograma & "  -  Directorio:  " & EYELogicaEmpaque.Directorios.nombre & "  -  Usuario:  " & EYELogicaEmpaque.Usuarios.nombre

    End Sub

    Private Sub Salir()

        Me.Close()

    End Sub

    Private Sub GuardarEditarImpresoras()

        configuracionImpresoras.EIdTipo = Me.tipoImpresora
        configuracionImpresoras.EId = 0
        configuracionImpresoras.Eliminar()
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
        configuracionImpresoras.EId = id
        configuracionImpresoras.ENombre = nombre
        configuracionImpresoras.EHabilitar = habilitar
        configuracionImpresoras.EMargenIzquierdo = margenIzquierdo
        configuracionImpresoras.EMargenSuperior = margenDerecho
        If (Not String.IsNullOrEmpty(nombre)) Then
            configuracionImpresoras.Guardar()
        End If
        ' Impresora de caja.
        id = OpcionTipoEtiqueta.caja
        nombre = cbImpresorasCajas.Text
        habilitar = chkImprimirCajas.Checked
        margenIzquierdo = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtMargenIzquierdoCajas.Text)
        margenDerecho = EYELogicaEmpaque.Funciones.ValidarNumeroACero(txtMargenDerechoCajas.Text)
        configuracionImpresoras.EId = id
        configuracionImpresoras.ENombre = nombre
        configuracionImpresoras.EHabilitar = habilitar
        configuracionImpresoras.EMargenIzquierdo = margenIzquierdo
        configuracionImpresoras.EMargenSuperior = margenDerecho
        If (Not String.IsNullOrEmpty(nombre)) Then
            configuracionImpresoras.Guardar()
        End If
        MessageBox.Show("Guardado finalizado.", "Finalizado.", MessageBoxButtons.OK)
        CargarImpresoras(False)

    End Sub

    Public Sub CargarImpresoras(ByVal soloVariables As Boolean)

        configuracionImpresoras.EIdTipo = Me.tipoImpresora
        ' Se carga la impresora de tarima.
        configuracionImpresoras.EId = OpcionTipoEtiqueta.tarima
        Dim datosImpresoraTarima As New DataTable
        datosImpresoraTarima = configuracionImpresoras.ObtenerListado()
        If (datosImpresoraTarima.Rows.Count > 0) Then
            Impresoras.nombreImpresoraTarima = datosImpresoraTarima.Rows(0).Item("Nombre")
            Impresoras.habilitarImpresoraTarima = datosImpresoraTarima.Rows(0).Item("Habilitar")
            Impresoras.margenIzquierdoTarima = datosImpresoraTarima.Rows(0).Item("MargenIzquierdo")
            Impresoras.margenSuperiorTarima = datosImpresoraTarima.Rows(0).Item("MargenSuperior")
        End If
        If (Not soloVariables) Then
            If (datosImpresoraTarima.Rows.Count > 0) Then
                chkImprimirTarimas.Checked = datosImpresoraTarima.Rows(0).Item("Habilitar")
                txtMargenIzquierdoTarimas.Text = datosImpresoraTarima.Rows(0).Item("MargenIzquierdo")
                txtMargenDerechoTarimas.Text = datosImpresoraTarima.Rows(0).Item("MargenSuperior")
            End If
            cbImpresorasTarimas.Items.Clear()
            For indice As Integer = 0 To InstalledPrinters.Count - 1
                Dim nombre As String = InstalledPrinters.Item(indice)
                cbImpresorasTarimas.Items.Add(nombre)
                If (datosImpresoraTarima.Rows.Count > 0) Then
                    If (datosImpresoraTarima.Rows(0).Item("Nombre").ToString.ToUpper.Equals(nombre.ToUpper)) Then
                        cbImpresorasTarimas.SelectedIndex = indice
                    End If
                End If
            Next
        End If
        ' Se carga la impresora de caja.
        configuracionImpresoras.EId = OpcionTipoEtiqueta.caja
        Dim datosImpresoraCaja As New DataTable
        datosImpresoraCaja = configuracionImpresoras.ObtenerListado()
        If (datosImpresoraCaja.Rows.Count > 0) Then
            Impresoras.nombreImpresoraCaja = datosImpresoraCaja.Rows(0).Item("Nombre")
            Impresoras.habilitarImpresoraCaja = datosImpresoraCaja.Rows(0).Item("Habilitar")
            Impresoras.margenIzquierdoCaja = datosImpresoraCaja.Rows(0).Item("MargenIzquierdo")
            Impresoras.margenSuperiorCaja = datosImpresoraCaja.Rows(0).Item("MargenSuperior")
        End If
        If (Not soloVariables) Then
            If (datosImpresoraCaja.Rows.Count > 0) Then
                chkImprimirCajas.Checked = datosImpresoraCaja.Rows(0).Item("Habilitar")
                txtMargenIzquierdoCajas.Text = datosImpresoraCaja.Rows(0).Item("MargenIzquierdo")
                txtMargenDerechoCajas.Text = datosImpresoraCaja.Rows(0).Item("MargenSuperior")
            End If
            cbImpresorasCajas.Items.Clear()
            For indice As Integer = 0 To InstalledPrinters.Count - 1
                Dim nombre As String = InstalledPrinters.Item(indice)
                cbImpresorasCajas.Items.Add(nombre)
                If (datosImpresoraCaja.Rows.Count > 0) Then
                    If (datosImpresoraCaja.Rows(0).Item("Nombre").ToString.ToUpper.Equals(nombre.ToUpper)) Then
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