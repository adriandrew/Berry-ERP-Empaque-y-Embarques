Imports System.IO
Imports FarPoint.Win.Spread
Imports System.Reflection
Imports System.Threading.Thread

Public Class Documentos

    Public nombreEstePrograma As String = String.Empty
    Public opcionSeleccionada As Integer = 0
    Public rutaDocumentos As String = String.Empty
    Public rutaTemporal As String = Application.StartupPath & "\ArchivosTemporales"
    Public rutaAdjuntar As String = String.Empty
    Public empresas As New EYEEntidadesEmbarques.Empresas()

#Region "Eventos"

    Private Sub Documentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Centrar()
        CargarNombrePrograma()
        CargarRutaDocumentos()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Documentos_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        CargarTitulosDirectorio()
        SeleccionarDocumento()
        Me.Enabled = True
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Documentos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Salir()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.Close()

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Imprimir(False, True)

    End Sub

    Private Sub btnExportarPdf_Click(sender As Object, e As EventArgs) Handles btnExportarPdf.Click

        Imprimir(True, True)

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        ExportarExcel()

    End Sub

#End Region

#Region "Métodos"

    Private Sub Salir()

        EliminarArchivosTemporales()
        Principal.MostrarOcultarPanelDocumentos()
        Principal.pnlContenido.Enabled = True

    End Sub

    Private Sub Centrar()

        Me.CenterToScreen()
        Me.Opacity = 0.98
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Private Sub CargarNombrePrograma()

        Me.nombreEstePrograma = Me.Text

    End Sub

    Private Sub CargarTitulosDirectorio()

        Me.Text = "Programa:  " & Me.nombreEstePrograma & "              Directorio:  " & EYELogicaEmbarques.Directorios.nombre & "              Usuario:  " & EYELogicaEmbarques.Usuarios.nombre

    End Sub

    Public Sub CargarRutaDocumentos()

        Me.rutaDocumentos = String.Format("{0}/{1}", Application.StartupPath, "DocumentosEmbarques")

    End Sub

    Private Sub HabilitarBotonesImpresion()

        btnImprimir.Enabled = True
        btnExportarPdf.Enabled = True
        btnExportarExcel.Enabled = True

    End Sub

    Private Sub SeleccionarDocumento()

        If (Me.opcionSeleccionada = OpcionDocumento.manifiesto) Then
            GenerarManifiesto()
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.remision) Then
            GenerarRemision()
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.distribucion) Then
            GenerarDistribucion()
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.responsiva) Then
            GenerarResponsiva()
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.sellos) Then
            GenerarSellos()
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.precos) Then
            GenerarPrecos()
        End If
        HabilitarBotonesImpresion()

    End Sub

    Private Sub FormatearSpread()

        spDocumentos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.ArcticSea
        spDocumentos.Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpreadDocumentos, FontStyle.Regular)
        spDocumentos.ActiveSheet.GrayAreaBackColor = Color.White
        ' Ancho de documento.
        Dim ancho As Double = 0
        For columna = 0 To spDocumentos.ActiveSheet.Columns.Count - 1
            ancho += spDocumentos.ActiveSheet.Columns(columna).Width
        Next
        If (Me.opcionSeleccionada = OpcionDocumento.manifiesto Or Me.opcionSeleccionada = OpcionDocumento.distribucion) Then
            spDocumentos.Width = ancho + 120
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.remision) Then
            spDocumentos.Width = ancho + 5
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.responsiva) Then
            spDocumentos.Width = ancho + 25
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.sellos) Then
            spDocumentos.Width = ancho + 270
            For indice = 0 To spDocumentos.Sheets.Count - 1
                spDocumentos.ActiveSheetIndex = indice
                spDocumentos.ActiveSheet.GrayAreaBackColor = Color.White
            Next
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.precos) Then
            spDocumentos.Width = ancho + 5
        End If
        ' Se saca diferencia para centrarlo a la pantalla.
        Dim diferenciaAncho As Double = Me.Width - spDocumentos.Width
        If (diferenciaAncho > 0) Then
            spDocumentos.Left = diferenciaAncho / 2
        End If
        spDocumentos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spDocumentos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always
        spDocumentos.ActiveSheet.ColumnHeader.Visible = False

    End Sub

    Private Sub GenerarDesgloseTarimasTrailer(ByVal esManifiesto As Boolean, ByVal filaInicio As Integer, ByVal filaMaxima As Integer, ByVal cantidadColumnasSpanIzquierda As Integer, ByVal cantidadColumnasSpanDerecha As Integer)

        ' Inicia desglose de tarimas en trailer en la parte abajo e izquierda.
        Dim datos As New DataTable
        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
        Principal.tarimas.EIdEmbarque = idEmbarque
        Principal.tarimas.EIdTipoEmbarque = Principal.opcionTipoSeleccionada
        datos = Principal.embarques.ObtenerListadoReporte()
        ' Se carga el total de tarimas.
        If (Not esManifiesto) Then
            spDocumentos.ActiveSheet.Cells("totalTarimas").Text = datos.Rows.Count
        End If
        ' Se rellenan los ordenes vacios.
        Dim ordenMaximo As Integer = datos.Rows(datos.Rows.Count - 1).Item("OrdenEmbarque").ToString
        Dim indice As Integer = 0
        Dim ordenNormal As Integer = 0
        While (ordenNormal < ordenMaximo)
            ' Se busca el para saber si existe.
            Dim filaDeDatos As DataRow()
            Dim expresion As String = String.Format("OrdenEmbarque = {0}", ordenNormal)
            filaDeDatos = datos.Select(expresion)
            If (filaDeDatos.Length = 0) Then
                Dim anadir As DataRow = datos.NewRow()
                anadir("Id") = -1
                anadir("CantidadCajas") = -1
                anadir("EsExistente") = False
                anadir("OrdenEmbarque") = ordenNormal
                datos.Rows.Add(anadir)
            End If
            ordenNormal += 1
        End While
        datos.AcceptChanges()
        ' Se rellena ahora si todo el trailer.
        Dim filaSpread As Integer = 0 : Dim filaSpreadTarima As Integer = 0 ' Es para las filas en cada una de las tarimas, ya que llevan mixto algunas.
        Dim filaTarima As Integer = 0
        Dim esIzquierda As Boolean = False
        Dim cantidadEspacios As Integer = 5 ' Salta cada 5 filas en el formato
        Dim columnaSpreadIzquierda As Integer = 1 : Dim columnaSpreadDerecha As Integer = 3
        While (filaTarima < datos.Rows.Count)
            Dim columnaSpread As Integer = 0
            Dim orden As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(filaTarima).Item("OrdenEmbarque").ToString)
            filaSpread = Math.Floor(orden / 2) ' Se divide el orden para saber en que fila va. 
            filaSpread *= cantidadEspacios ' Se multiplica por las filas de salto en el formato.
            filaSpread += filaInicio ' Se suma esa cantidad ya que comienza en esa fila.
            If (orden Mod 2 = 0) Then ' Izquierda 
                columnaSpread = columnaSpreadIzquierda
                esIzquierda = True
                spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaSpread, 1, cantidadColumnasSpanIzquierda)
                ' Se agregan bordes (izquierda y arriba de la tarima).
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread, filaSpread + (cantidadEspacios - 1), columnaSpread).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, False, False) ' Solo izquierda.
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, True, False, False) ' Izquierda y arriba.
            Else ' Derecha.
                columnaSpread = columnaSpreadDerecha
                esIzquierda = False
                spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaSpread, 1, cantidadColumnasSpanDerecha)
                ' Se agregan bordes (izquierda, arriba y derecha de la tarima).
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread, filaSpread + (cantidadEspacios - 1), columnaSpread).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, True, False)
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, True, True, False)
            End If
            ' Número y cantidad de cajas de la tarima.
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = String.Format("| {0} |", orden + 1)
            filaSpreadTarima = filaSpread + 1
            ' Se valida mediante el id de la tarima.
            Dim idTarima As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(filaTarima).Item("Id").ToString)
            If (idTarima > 0) Then
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text &= String.Format("  No. {0} ({1})", idTarima, EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(filaTarima).Item("CantidadCajas").ToString))
            End If
            filaSpreadTarima = filaSpread + 1
            ' Esto es para desglosar las presentaciones por tarimas.
            Dim arregloProducto() As String = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaTarima).Item("AbreviaturaProducto").ToString).Split("-")
            Dim arregloEnvase() As String = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaTarima).Item("AbreviaturaEnvase").ToString).Split("-")
            Dim arregloEtiqueta() As String = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaTarima).Item("AbreviaturaEtiqueta").ToString).Split("-")
            Dim arregloTamano() As String = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaTarima).Item("AbreviaturaTamano").ToString).Split("-")
            For filaArregloMixteo = 0 To arregloProducto.Length - 1
                ' Esto es para quitar espacios al inicio.
                If (filaArregloMixteo > 0) Then
                    arregloProducto(filaArregloMixteo) = arregloProducto(filaArregloMixteo).TrimStart(" ")
                    arregloEnvase(filaArregloMixteo) = arregloEnvase(filaArregloMixteo).TrimStart(" ")
                    arregloEtiqueta(filaArregloMixteo) = arregloEtiqueta(filaArregloMixteo).TrimStart(" ")
                    arregloTamano(filaArregloMixteo) = arregloTamano(filaArregloMixteo).TrimStart(" ")
                End If
                ' Esto es para separar las cantidades de cajas y que no aparezcan siempre en el desglose.
                Dim arregloTemporal() As String
                arregloTemporal = arregloEnvase(filaArregloMixteo).Split("(")
                arregloEnvase(filaArregloMixteo) = arregloTemporal(0)
                arregloTemporal = arregloEtiqueta(filaArregloMixteo).Split("(")
                arregloEtiqueta(filaArregloMixteo) = arregloTemporal(0)
                arregloTemporal = arregloTamano(filaArregloMixteo).Split("(")
                arregloTamano(filaArregloMixteo) = arregloTemporal(0)
                ' Esto agrega los datos correspondientes por cada fila.
                ' Se unen celdas dependiendo la posicion.
                If (esIzquierda) Then
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpreadTarima, columnaSpread, 1, cantidadColumnasSpanIzquierda)
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpreadTarima + 1, columnaSpread, 1, cantidadColumnasSpanIzquierda)
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpreadTarima + 2, columnaSpread, 1, cantidadColumnasSpanIzquierda)
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpreadTarima + 3, columnaSpread, 1, cantidadColumnasSpanIzquierda)
                Else
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpreadTarima, columnaSpread, 1, cantidadColumnasSpanDerecha)
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpreadTarima + 1, columnaSpread, 1, cantidadColumnasSpanDerecha)
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpreadTarima + 2, columnaSpread, 1, cantidadColumnasSpanDerecha)
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpreadTarima + 3, columnaSpread, 1, cantidadColumnasSpanDerecha)
                End If
                spDocumentos.ActiveSheet.Cells(filaSpreadTarima, columnaSpread).Text = String.Format("{0} {1} {2} {3}", arregloProducto(filaArregloMixteo), arregloEnvase(filaArregloMixteo), arregloEtiqueta(filaArregloMixteo), arregloTamano(filaArregloMixteo))
                spDocumentos.ActiveSheet.Cells(filaSpreadTarima, columnaSpread).Font = New Font(Principal.tipoLetraSpread, 7, FontStyle.Regular)
                filaSpreadTarima += 1
            Next
            filaTarima += 1
            If (orden = ordenMaximo) Then
                ' Se le agrega un espacio debajo de la ultima tarima, ya que el spread tiene un bug al imprimir que sino no lo muestra.
                spDocumentos.ActiveSheet.Cells(filaSpread + (cantidadEspacios), columnaSpreadIzquierda).Text = " "
                ' Borde de abajo de todas las tarimas.
                spDocumentos.ActiveSheet.Cells(filaSpread + (cantidadEspacios), columnaSpreadIzquierda, filaSpread + (cantidadEspacios), columnaSpreadDerecha).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, True, False, False)
                ' Tamaño de documento.
                Dim filaMaximaTotal As Integer = 0
                Dim filaMaximaIzquierda As Integer = filaSpread + cantidadEspacios + 1
                If (filaMaximaIzquierda > filaMaxima) Then
                    filaMaximaTotal = filaMaximaIzquierda
                Else
                    filaMaximaTotal = filaMaxima
                End If
                spDocumentos.ActiveSheet.Rows.Count = filaMaximaTotal
            End If
        End While

    End Sub

    Public Sub GenerarManifiesto()

        Dim ruta As String = String.Format("{0}/{1}", Me.rutaDocumentos, "Manifiesto.xml")
        If (Principal.esDesarrollo) Then
            ruta = "W:\DocumentosEmbarques\Manifiesto.xml"
        End If
        Try
            spDocumentos.Open(ruta)
        Catch ex As Exception
            MsgBox(String.Format("No se pudo generar este documento. {0}{0}{1}", vbNewLine, ex.Message), MsgBoxStyle.Critical, "Error.")
            Exit Sub
        End Try
        FormatearSpread()
        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
        Dim datos As New DataTable
        Principal.embarques.EId = idEmbarque
        Principal.embarques.EIdTipo = Principal.opcionTipoSeleccionada
        datos = Principal.embarques.ObtenerListadoReporteManifiestoRemisionDistribucionResponsivaSellos()
        If (datos.Rows.Count > 0) Then
            ' Inicia el relleno de datos del embarque en la parte arriba y derecha.
            spDocumentos.ActiveSheet.Cells("productor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("domicilio").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("DomicilioEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstado").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioEmbarcador").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoEmbarcador").ToString))
            spDocumentos.ActiveSheet.Cells("rfc").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("RfcEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("ggn").Text = String.Format("GGN: {0}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("GgnEmbarcador").ToString))
            spDocumentos.ActiveSheet.Cells("fecha").Text = Mid(datos.Rows(0).Item("Fecha").ToString, 1, 10)
            spDocumentos.ActiveSheet.Cells("hora").Text = datos.Rows(0).Item("Hora").ToString
            spDocumentos.ActiveSheet.Cells("idEmbarque").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Id").ToString)
            spDocumentos.ActiveSheet.Cells("idFactura").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Factura").ToString)
            spDocumentos.ActiveSheet.Cells("fda").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("FdaEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("placasTrailerUsa").Text = String.Format("{0} - {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasUsaTrailer").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NumeroEconomicoTrailer").ToString))
            spDocumentos.ActiveSheet.Cells("placasTrailerMex").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasMexTrailer").ToString)
            spDocumentos.ActiveSheet.Cells("placasCajaUsa").Text = String.Format("{0} - {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasUsaCaja").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NumeroEconomicoCaja").ToString))
            spDocumentos.ActiveSheet.Cells("serie").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("SerieTrailer").ToString)
            spDocumentos.ActiveSheet.Cells("temperatura").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Temperatura").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstadoCliente").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioCliente").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoCliente").ToString))
            spDocumentos.ActiveSheet.Cells("lineaTransporte").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreLineaTransporte").ToString)
            spDocumentos.ActiveSheet.Cells("chofer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreChofer").ToString)
            spDocumentos.ActiveSheet.Cells("cliente").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreCliente").ToString)
            spDocumentos.ActiveSheet.Cells("termografo").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Termografo").ToString)
            spDocumentos.ActiveSheet.Cells("sello1").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello1").ToString)
            spDocumentos.ActiveSheet.Cells("sello2").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello2").ToString)
            spDocumentos.ActiveSheet.Cells("sello3").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello3").ToString)
            spDocumentos.ActiveSheet.Cells("sello4").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello4").ToString)
            spDocumentos.ActiveSheet.Cells("sello5").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello5").ToString)
            spDocumentos.ActiveSheet.Cells("sello6").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello6").ToString)
            spDocumentos.ActiveSheet.Cells("sello7").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello7").ToString)
            spDocumentos.ActiveSheet.Cells("sello8").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello8").ToString)
            datos.Clear()
            ' Inicia desglose de presentaciones en la parte abajo y derecha.
            Dim totalCajas As Integer = 0
            Dim filaSpread As Integer = 27 ' Fila de inicio de desglose.
            Dim columnaSpread As Integer = 0
            ' Inicia productos.
            Dim datosProductos As DataTable
            Dim filaProducto As Integer = 0
            datosProductos = Principal.embarques.ObtenerListadoReporteManifiestoDesgloseEscalonado(True, False, False, False, 0, 0, 0, 0)
            While (filaProducto < datosProductos.Rows.Count)
                Dim idProducto As Integer = datosProductos.Rows(filaProducto).Item("IdProducto").ToString
                columnaSpread = 6
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarLetra(datosProductos.Rows(filaProducto).Item("AbreviaturaProducto").ToString)
                columnaSpread = 13
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosProductos.Rows(filaProducto).Item("CantidadCajas").ToString)
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).CellType = Principal.tipoEntero
                filaSpread += 1
                ' Inicia envases.
                Dim datosEnvases As DataTable
                Dim filaEnvase As Integer = 0
                datosEnvases = Principal.embarques.ObtenerListadoReporteManifiestoDesgloseEscalonado(False, True, False, False, idProducto, 0, 0, 0)
                While (filaEnvase < datosEnvases.Rows.Count)
                    Dim idEnvase As Integer = datosEnvases.Rows(filaEnvase).Item("IdEnvase").ToString
                    columnaSpread = 7
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaSpread, 1, 2)
                    spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarLetra(datosEnvases.Rows(filaEnvase).Item("AbreviaturaEnvase").ToString)
                    columnaSpread = 13
                    spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosEnvases.Rows(filaEnvase).Item("CantidadCajas").ToString)
                    spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).CellType = Principal.tipoEntero
                    filaSpread += 1
                    ' Inicia etiquetas.
                    Dim datosEtiquetas As DataTable
                    Dim filaEtiqueta As Integer = 0
                    datosEtiquetas = Principal.embarques.ObtenerListadoReporteManifiestoDesgloseEscalonado(False, False, True, False, idProducto, idEnvase, 0, 0)
                    While (filaEtiqueta < datosEtiquetas.Rows.Count)
                        Dim idEtiqueta As Integer = datosEtiquetas.Rows(filaEtiqueta).Item("IdEtiqueta").ToString
                        columnaSpread = 9
                        spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaSpread, 1, 2)
                        spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarLetra(datosEtiquetas.Rows(filaEtiqueta).Item("AbreviaturaEtiqueta").ToString)
                        columnaSpread = 13
                        spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosEtiquetas.Rows(filaEtiqueta).Item("CantidadCajas").ToString)
                        spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).CellType = Principal.tipoEntero
                        filaSpread += 1
                        ' Inicia tamanos.
                        Dim datosTamanos As DataTable
                        Dim filaTamano As Integer = 0
                        datosTamanos = Principal.embarques.ObtenerListadoReporteManifiestoDesgloseEscalonado(False, False, False, True, idProducto, idEnvase, idEtiqueta, 0)
                        While (filaTamano < datosTamanos.Rows.Count)
                            columnaSpread = 11
                            spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaSpread, 1, 2)
                            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarLetra(datosTamanos.Rows(filaTamano).Item("AbreviaturaTamano").ToString)
                            columnaSpread = 13
                            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosTamanos.Rows(filaTamano).Item("CantidadCajas").ToString)
                            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).CellType = Principal.tipoEntero
                            filaSpread += 1
                            filaTamano += 1
                        End While
                        ' Termina tamanos.
                        filaEtiqueta += 1
                    End While
                    ' Termina etiquetas.
                    filaEnvase += 1
                End While
                ' Termina envases.
                totalCajas += EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosProductos.Rows(filaProducto).Item("CantidadCajas").ToString)
                spDocumentos.ActiveSheet.Cells(filaSpread - 1, 6, filaSpread - 1, 13).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, False, True)
                filaProducto += 1
            End While
            ' Totales de cajas.
            columnaSpread = 12
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = "Total".ToUpper
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            columnaSpread = 13
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = totalCajas
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).CellType = Principal.tipoEntero
            spDocumentos.ActiveSheet.Cells(filaSpread, 6, filaSpread, 13).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, False, True)
            spDocumentos.ActiveSheet.Cells(filaSpread, 6).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, False, True)
            spDocumentos.ActiveSheet.Cells(filaSpread, 13).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, True, True)
            filaSpread += 1
            datos.Clear()
            ' Inicia desglose de tarimas en trailer en la parte arriba y izquierda.
            GenerarDesgloseTarimasTrailer(True, 4, filaSpread, 2, 2)
        End If

    End Sub

    Public Sub GenerarRemision()

        Dim ruta As String = String.Format("{0}/{1}", Me.rutaDocumentos, "Remision.xml")
        If (Principal.esDesarrollo) Then
            ruta = "W:\DocumentosEmbarques\Remision.xml"
        End If
        Try
            spDocumentos.Open(ruta)
        Catch ex As Exception
            MsgBox(String.Format("No se pudo generar este documento. {0}{0}{1}", vbNewLine, ex.Message), MsgBoxStyle.Critical, "Error.")
            Exit Sub
        End Try
        FormatearSpread()
        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
        Dim datos As New DataTable
        Principal.embarques.EId = idEmbarque
        Principal.embarques.EIdTipo = Principal.opcionTipoSeleccionada
        datos = Principal.embarques.ObtenerListadoReporteManifiestoRemisionDistribucionResponsivaSellos()
        If (datos.Rows.Count > 0) Then
            ' Inicia el relleno de datos del embarque en la parte arriba y derecha.
            spDocumentos.ActiveSheet.Cells("productor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("domicilioProductor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("DomicilioEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstadoProductor").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioEmbarcador").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoEmbarcador").ToString))
            spDocumentos.ActiveSheet.Cells("rfcProductor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("RfcEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("idFactura").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Factura").ToString)
            spDocumentos.ActiveSheet.Cells("fecha").Text = Mid(datos.Rows(0).Item("Fecha").ToString, 1, 10)
            spDocumentos.ActiveSheet.Cells("hora").Text = datos.Rows(0).Item("Hora").ToString()
            spDocumentos.ActiveSheet.Cells("idEmbarque").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Id").ToString)
            spDocumentos.ActiveSheet.Cells("cliente").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreCliente").ToString)
            spDocumentos.ActiveSheet.Cells("domicilioCliente").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("DomicilioCliente").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstadoCliente").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioCliente").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoCliente").ToString))
            spDocumentos.ActiveSheet.Cells("rfcCliente").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("RfcCliente").ToString)
            datos.Clear()
            ' Inicia desglose de presentaciones en la parte abajo y en medio. 
            Dim filaSpread As Integer = 17 ' Fila de inicio de desglose. 
            Dim filaDatos As Integer = 0
            datos = Principal.embarques.ObtenerListadoReporteRemisionDistribucionResponsiva()
            Dim columnaDescripcion As Integer = 1
            Dim columnaCajas As Integer = 8
            Dim columnaPesoUnitario As Integer = 9
            Dim columnaPesoLibras As Integer = 11
            Dim columnaPesoKilos As Integer = 10
            Dim columnaPrecioUnitario As Integer = 12
            Dim columnaImporte As Integer = 13
            Dim totalCajas As Double = 0 : Dim totalPesoKilos As Double = 0 : Dim totalPesoLibras As Double = 0 : Dim totalImporte As Double = 0
            While (filaDatos < datos.Rows.Count)
                Dim descripcion As String = String.Format("  {0} {1} {2} {3} {4}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaProducto").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaVariedad").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaEnvase").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaEtiqueta").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaTamano").ToString))
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Text = descripcion
                Dim cantidadCajas As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(filaDatos).Item("CantidadCajas").ToString)
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas).Text = cantidadCajas
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas).CellType = Principal.tipoEntero
                spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaDescripcion, 1, 7)
                Dim pesoKilos As Double = Math.Round(EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(filaDatos).Item("PesoTotalCajas").ToString) / 2.2046, 2)
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaPesoKilos).Text = pesoKilos.ToString
                Dim pesoLibras As Double = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(filaDatos).Item("PesoTotalCajas").ToString)
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaPesoLibras).Text = pesoLibras.ToString
                Dim pesoUnitarioLibras As Double = Math.Round(pesoLibras / cantidadCajas, 2)
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaPesoUnitario).Text = pesoUnitarioLibras
                Dim precioUnitario As Double = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(filaDatos).Item("PrecioUnitarioCajas").ToString) ' TODO. Hay que tomarlo de la configuracion de precios.
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).Text = precioUnitario
                totalImporte += precioUnitario * cantidadCajas
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).Text = Math.Round(precioUnitario * cantidadCajas)
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).CellType = Principal.tipoDoble
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion, filaSpread + 1, columnaDescripcion).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, False, False)
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte, filaSpread + 1, columnaImporte).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, True, False)
                totalCajas += cantidadCajas
                totalPesoKilos += pesoKilos
                totalPesoLibras += pesoLibras
                filaDatos += 1
                filaSpread += 1
            End While
            filaSpread += 1
            ' Totales.
            spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaDescripcion, 1, columnaCajas - 1)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Text = "Total".ToUpper
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas).Text = totalCajas
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas).CellType = Principal.tipoDoble
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPesoKilos).Text = totalPesoKilos
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPesoKilos).CellType = Principal.tipoDoble
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPesoLibras).Text = totalPesoLibras
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPesoLibras).CellType = Principal.tipoDoble
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion, filaSpread, columnaImporte).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, False, True)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, False, True)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, True, True)
            filaSpread += 1
            ' Subtotal.
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario, filaSpread + 2, columnaPrecioUnitario).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpreadDocumentos, FontStyle.Bold)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).Text = "SubTotal $".ToUpper
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).Text = Math.Round(totalImporte, 2)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).CellType = Principal.tipoDoble
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, False, False)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, True, False)
            filaSpread += 1
            ' Iva. 
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).Text = "Iva $".ToUpper
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).Text = 0
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).CellType = Principal.tipoDoble
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, False, False)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, True, False)
            filaSpread += 1
            ' Total.
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).Text = "Total $".ToUpper
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).Text = Math.Round(totalImporte, 2)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).CellType = Principal.tipoDoble
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaPrecioUnitario).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, False, True)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaImporte).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, True, True)
            filaSpread -= 1
            ' Numero a letra.
            spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaDescripcion, 1, columnaPesoLibras)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpreadDocumentos, FontStyle.Bold)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Text = "Importe total con letra:".ToUpper
            filaSpread += 1
            spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaDescripcion, 1, columnaPesoLibras)
            Dim letra As New NumerosLetras
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Text = StrConv(letra.letras(totalImporte), VbStrConv.ProperCase)
            filaSpread += 2
            ' Observaciones.
            spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaDescripcion, 1, columnaImporte)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Font = New Font(Principal.tipoLetraSpread, Principal.tamañoLetraSpreadDocumentos, FontStyle.Bold)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Text = "Observaciones:".ToUpper
            filaSpread += 1
            spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaDescripcion, 5, columnaImporte)
            filaSpread += 5
            datos.Clear()
            ' Tamaño de documento.
            spDocumentos.ActiveSheet.Rows.Count = filaSpread + 1
        End If

    End Sub

    Public Sub GenerarDistribucion()

        Dim ruta As String = String.Format("{0}/{1}", Me.rutaDocumentos, "Distribucion.xml")
        If (Principal.esDesarrollo) Then
            ruta = "W:\DocumentosEmbarques\Distribucion.xml"
        End If
        Try
            spDocumentos.Open(ruta)
        Catch ex As Exception
            MsgBox(String.Format("No se pudo generar este documento. {0}{0}{1}", vbNewLine, ex.Message), MsgBoxStyle.Critical, "Error.")
            Exit Sub
        End Try
        FormatearSpread()
        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
        Dim datos As New DataTable
        Principal.embarques.EId = idEmbarque
        Principal.embarques.EIdTipo = Principal.opcionTipoSeleccionada
        datos = Principal.embarques.ObtenerListadoReporteManifiestoRemisionDistribucionResponsivaSellos()
        If (datos.Rows.Count > 0) Then
            ' Inicia el relleno de datos del embarque en la parte arriba y centro.
            spDocumentos.ActiveSheet.Cells("productor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("domicilioProductor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("DomicilioEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstadoProductor").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioEmbarcador").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoEmbarcador").ToString))
            spDocumentos.ActiveSheet.Cells("rfcProductor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("RfcEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("idEmbarque").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Id").ToString)
            spDocumentos.ActiveSheet.Cells("idFactura").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Factura").ToString)
            spDocumentos.ActiveSheet.Cells("fecha").Text = Mid(datos.Rows(0).Item("Fecha").ToString, 1, 10)
            spDocumentos.ActiveSheet.Cells("hora").Text = datos.Rows(0).Item("Hora").ToString
            spDocumentos.ActiveSheet.Cells("embarcador").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("fda").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("FdaEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("ggn").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("GgnEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("lineaTransporte").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreLineaTransporte").ToString)
            spDocumentos.ActiveSheet.Cells("placasTrailerUsa").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasUsaTrailer"))
            spDocumentos.ActiveSheet.Cells("placasTrailerMex").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasMexTrailer").ToString)
            spDocumentos.ActiveSheet.Cells("numeroEconomicoTrailer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NumeroEconomicoTrailer").ToString)
            spDocumentos.ActiveSheet.Cells("marcaModeloTrailer").Text = String.Format("{0} {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MarcaTrailer").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("ModeloTrailer").ToString))
            spDocumentos.ActiveSheet.Cells("scacTrailer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("ScacTrailer").ToString)
            spDocumentos.ActiveSheet.Cells("placasCajaUsa").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasUsaCaja").ToString)
            spDocumentos.ActiveSheet.Cells("placasCajaMex").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasMexCaja").ToString)
            spDocumentos.ActiveSheet.Cells("numeroEconomicoCaja").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NumeroEconomicoCaja").ToString)
            spDocumentos.ActiveSheet.Cells("sellos").Text = String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello1").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello2").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello3").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello4").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello5").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello6").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello7").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello8").ToString))
            spDocumentos.ActiveSheet.Cells("chofer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreChofer").ToString)
            spDocumentos.ActiveSheet.Cells("licenciaChofer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("LicenciaChofer").ToString)
            spDocumentos.ActiveSheet.Cells("visaChofer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("VisaChofer").ToString)
            spDocumentos.ActiveSheet.Cells("agenciaAduanalUsa").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("AduanaUsa").ToString)
            spDocumentos.ActiveSheet.Cells("agenciaAduanalMex").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("AduanaMex").ToString)
            spDocumentos.ActiveSheet.Cells("cliente").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreCliente").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstadoCliente").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioCliente").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoCliente").ToString))
            spDocumentos.ActiveSheet.Cells("termografo").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Termografo").ToString)
            datos.Clear()
            ' Inicia desglose de presentaciones en la parte abajo y derecha. 
            Dim filaSpread As Integer = 26 ' Fila de inicio de desglose. 
            Dim filaDatos As Integer = 0
            datos = Principal.embarques.ObtenerListadoReporteRemisionDistribucionResponsiva()
            Dim columnaDescripcion As Integer = 7
            Dim columnaCajas As Integer = 13
            Dim totalCajas As Double = 0
            While (filaDatos < datos.Rows.Count)
                spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaDescripcion, 1, 6)
                Dim descripcion As String = String.Format("{0} {1} {2} {3} {4}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaProducto").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaVariedad").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaEnvase").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaEtiqueta").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaTamano").ToString))
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Text = descripcion
                Dim cantidadCajas As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(filaDatos).Item("CantidadCajas").ToString)
                totalCajas += cantidadCajas
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas).Text = cantidadCajas
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas).CellType = Principal.tipoEntero
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion, filaSpread + 1, columnaDescripcion).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, False, False)
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas, filaSpread + 1, columnaCajas).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, True, False)
                filaDatos += 1
                filaSpread += 1
            End While
            filaSpread += 1
            ' Totales.
            spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaDescripcion, 1, 6)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Text = "Total".ToUpper
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas).Text = totalCajas
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas).CellType = Principal.tipoDoble
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion, filaSpread, columnaCajas).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, False, True)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, True, False, False, True)
            spDocumentos.ActiveSheet.Cells(filaSpread, columnaCajas).Border = New FarPoint.Win.LineBorder(Color.FromArgb(64, 64, 64), 2, False, False, True, True)
            filaSpread += 1
            datos.Clear()
            ' Inicia desglose de tarimas en trailer en la parte abajo e izquierda.
            GenerarDesgloseTarimasTrailer(False, 25, filaSpread, 2, 3)
        End If

    End Sub

    Public Sub GenerarResponsiva()

        Dim ruta As String = String.Format("{0}/{1}", Me.rutaDocumentos, "Responsiva.xml")
        If (Principal.esDesarrollo) Then
            ruta = "W:\DocumentosEmbarques\Responsiva.xml"
        End If
        Try
            spDocumentos.Open(ruta)
        Catch ex As Exception
            MsgBox(String.Format("No se pudo generar este documento. {0}{0}{1}", vbNewLine, ex.Message), MsgBoxStyle.Critical, "Error.")
            Exit Sub
        End Try
        FormatearSpread()
        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
        Dim datos As New DataTable
        Principal.embarques.EId = idEmbarque
        Principal.embarques.EIdTipo = Principal.opcionTipoSeleccionada
        datos = Principal.embarques.ObtenerListadoReporteManifiestoRemisionDistribucionResponsivaSellos()
        If (datos.Rows.Count > 0) Then
            ' Inicia el relleno de datos del embarque en la parte arriba y centro.
            spDocumentos.ActiveSheet.Cells("productor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("domicilioProductor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("DomicilioEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstadoProductor").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioEmbarcador").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoEmbarcador").ToString))
            spDocumentos.ActiveSheet.Cells("rfcProductor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("RfcEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("fechaHora").Text = String.Format("{0} {1}", Mid(datos.Rows(0).Item("Fecha").ToString, 1, 10), datos.Rows(0).Item("Hora").ToString)

            spDocumentos.ActiveSheet.Cells("uno").Text = spDocumentos.ActiveSheet.Cells("uno").Text.Replace("<chofer>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreChofer").ToString))
            spDocumentos.ActiveSheet.Cells("uno").Text = spDocumentos.ActiveSheet.Cells("uno").Text.Replace("<marcaTrailer>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MarcaTrailer").ToString))
            spDocumentos.ActiveSheet.Cells("uno").Text = spDocumentos.ActiveSheet.Cells("uno").Text.Replace("<modeloTrailer>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("ModeloTrailer").ToString))
            spDocumentos.ActiveSheet.Cells("dos").Text = spDocumentos.ActiveSheet.Cells("dos").Text.Replace("<numeroEconomicoTrailer>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NumeroEconomicoTrailer").ToString))
            spDocumentos.ActiveSheet.Cells("dos").Text = spDocumentos.ActiveSheet.Cells("dos").Text.Replace("<placasTrailerMex>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasMexTrailer").ToString))
            spDocumentos.ActiveSheet.Cells("tres").Text = spDocumentos.ActiveSheet.Cells("tres").Text.Replace("<serieCaja>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("SerieCaja").ToString))
            spDocumentos.ActiveSheet.Cells("tres").Text = spDocumentos.ActiveSheet.Cells("tres").Text.Replace("<placasCajaMex>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasMexCaja").ToString))
            spDocumentos.ActiveSheet.Cells("tres").Text = spDocumentos.ActiveSheet.Cells("tres").Text.Replace("<lineaTransporte>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreLineaTransporte").ToString))
            spDocumentos.ActiveSheet.Cells("cinco").Text = spDocumentos.ActiveSheet.Cells("cinco").Text.Replace("<idEmbarque>", EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(0).Item("Id").ToString))
            spDocumentos.ActiveSheet.Cells("cliente").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreCliente").ToString)
            spDocumentos.ActiveSheet.Cells("domicilioCliente").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("DomicilioCliente").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstadoCliente").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioCliente").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoCliente").ToString))
            spDocumentos.ActiveSheet.Cells("once").Text = spDocumentos.ActiveSheet.Cells("once").Text.Replace("<productor>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador").ToString))
            spDocumentos.ActiveSheet.Cells("quince").Text = spDocumentos.ActiveSheet.Cells("quince").Text.Replace("<termografo>", EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(0).Item("Termografo").ToString))
            spDocumentos.ActiveSheet.Cells("dieciseis").Text = spDocumentos.ActiveSheet.Cells("dieciseis").Text.Replace("<temperatura>", EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(0).Item("Temperatura").ToString))
            datos.Clear()
            ' Inicia desglose de presentaciones en la parte abajo y centro. 
            Dim celda As FarPoint.Win.Spread.Cell
            celda = spDocumentos.ActiveSheet.GetCellFromTag(Nothing, "descripcion")
            Dim filaSpread As Integer = celda.Row.Index ' Fila de inicio de desglose. 
            Dim filaDatos As Integer = 0
            datos = Principal.embarques.ObtenerListadoReporteRemisionDistribucionResponsiva()
            Dim columnaDescripcion As Integer = celda.Column.Index
            spDocumentos.ActiveSheet.RemoveRows(filaSpread, 1)
            While (filaDatos < datos.Rows.Count)
                spDocumentos.ActiveSheet.AddRows(filaSpread, 1)
                spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaDescripcion, 1, 5)
                Dim descripcion As String = String.Format("{0} {1} {2} {3} {4} con {5} bultos", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaProducto").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaVariedad").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaEnvase").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaEtiqueta").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("AbreviaturaTamano").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaDatos).Item("CantidadCajas").ToString))
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaDescripcion).Text = descripcion
                filaDatos += 1
            End While
            datos.Clear()
            ' Tamaño de documento.
            celda = spDocumentos.ActiveSheet.GetCellFromTag(Nothing, "nombreFirma")
            spDocumentos.ActiveSheet.Rows.Count = celda.Row.Index + 1
        End If

    End Sub

    Public Sub GenerarSellos()

        Dim ruta As String = String.Format("{0}/{1}", Me.rutaDocumentos, "Sellos.xml")
        If (Principal.esDesarrollo) Then
            ruta = "W:\DocumentosEmbarques\Sellos.xml"
        End If
        Try
            spDocumentos.Open(ruta)
        Catch ex As Exception
            MsgBox(String.Format("No se pudo generar este documento. {0}{0}{1}", vbNewLine, ex.Message), MsgBoxStyle.Critical, "Error.")
            Exit Sub
        End Try
        FormatearSpread()
        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
        Dim datos As New DataTable
        Principal.embarques.EId = idEmbarque
        Principal.embarques.EIdTipo = Principal.opcionTipoSeleccionada
        datos = Principal.embarques.ObtenerListadoReporteManifiestoRemisionDistribucionResponsivaSellos()
        If (datos.Rows.Count > 0) Then
            spDocumentos.ActiveSheetIndex = 0
            ' Inicia el relleno de datos del embarque en la parte arriba y centro. 
            spDocumentos.ActiveSheet.Cells("idEmbarque").Text = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(0).Item("Id").ToString)
            spDocumentos.ActiveSheet.Cells("uno").Text = spDocumentos.ActiveSheet.Cells("uno").Text.Replace("<productor>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador").ToString))
            spDocumentos.ActiveSheet.Cells("dos").Text = spDocumentos.ActiveSheet.Cells("dos").Text.Replace("<productor>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador").ToString))
            spDocumentos.ActiveSheet.Cells("lineaTransporte").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreLineaTransporte").ToString)
            spDocumentos.ActiveSheet.Cells("chofer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreChofer").ToString)
            spDocumentos.ActiveSheet.Cells("placasMexTrailer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasMexTrailer").ToString)
            spDocumentos.ActiveSheet.Cells("serieCaja").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("SerieCaja").ToString)
            spDocumentos.ActiveSheet.Cells("choferLicencia").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("LicenciaChofer").ToString)
            spDocumentos.ActiveSheet.Cells("sello1").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello1").ToString)
            spDocumentos.ActiveSheet.Cells("sello2").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello2").ToString)
            spDocumentos.ActiveSheet.Cells("sello3").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello3").ToString)
            spDocumentos.ActiveSheetIndex = 1 ' Se pasa a la segunda hoja.
            spDocumentos.ActiveSheet.Cells("sello4").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello4").ToString)
            spDocumentos.ActiveSheet.Cells("sello5").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello5").ToString)
            spDocumentos.ActiveSheet.Cells("sello6").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello6").ToString)
            spDocumentos.ActiveSheetIndex = 2 ' Se pasa a la tercera hoja.
            spDocumentos.ActiveSheet.Cells("sello7").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello7").ToString)
            spDocumentos.ActiveSheet.Cells("sello8").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello8").ToString)
            spDocumentos.ActiveSheetIndex = 0
            datos.Clear()
        End If

    End Sub

    Public Sub GenerarPrecos()

        Dim ruta As String = String.Format("{0}/{1}", Me.rutaDocumentos, "Precos.xml")
        If (Principal.esDesarrollo) Then
            ruta = "W:\DocumentosEmbarques\Precos.xml"
        End If
        Try
            spDocumentos.Open(ruta)
        Catch ex As Exception
            MsgBox(String.Format("No se pudo generar este documento. {0}{0}{1}", vbNewLine, ex.Message), MsgBoxStyle.Critical, "Error.")
            Exit Sub
        End Try
        FormatearSpread()
        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
        Dim datos As New DataTable
        Principal.embarques.EId = idEmbarque
        Principal.embarques.EIdTipo = Principal.opcionTipoSeleccionada
        datos = Principal.embarques.ObtenerListadoReporteManifiestoRemisionDistribucionResponsivaSellos()
        If (datos.Rows.Count > 0) Then
            ' Inicia el relleno de datos del embarque en la parte arriba y centro. 
            spDocumentos.ActiveSheet.Cells("uno").Text = spDocumentos.ActiveSheet.Cells("uno").Text.Replace("<municipioProductor>", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioEmbarcador").ToString))
            spDocumentos.ActiveSheet.Cells("productor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador").ToString)
            spDocumentos.ActiveSheet.Cells("placasMexTrailer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasMexTrailer").ToString)
            spDocumentos.ActiveSheet.Cells("colorTrailer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("ColorTrailer").ToString)
            spDocumentos.ActiveSheet.Cells("placasMexCaja").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasMexCaja").ToString)
            spDocumentos.ActiveSheet.Cells("marcaCaja").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MarcaCaja").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstadoCliente").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioCliente").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoCliente").ToString))
            spDocumentos.ActiveSheet.Cells("chofer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreChofer").ToString)
            spDocumentos.ActiveSheet.Cells("lineaTransporte").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreLineaTransporte").ToString)
            spDocumentos.ActiveSheet.Cells("municipioEstadoProductor").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioEmbarcador").ToString), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoEmbarcador").ToString))
            Dim datosProductos As DataTable ' Se consultan los distintos productos.
            Dim filaProducto As Integer = 0
            Dim productos As String = String.Empty
            datosProductos = Principal.embarques.ObtenerListadoReporteManifiestoDesgloseEscalonado(True, False, False, False, 0, 0, 0, 0)
            While (filaProducto < datosProductos.Rows.Count)
                Dim nombreProducto As String = EYELogicaEmbarques.Funciones.ValidarLetra(datosProductos.Rows(filaProducto).Item("NombreProducto").ToString)
                productos &= IIf(filaProducto < datosProductos.Rows.Count - 1, nombreProducto & ", ", nombreProducto)
                filaProducto += 1
            End While
            spDocumentos.ActiveSheet.Cells("producto").Text = productos
            spDocumentos.ActiveSheet.Cells("hora").Text = datos.Rows(0).Item("Hora").ToString
            spDocumentos.ActiveSheet.Cells("horaPrecos").Text = datos.Rows(0).Item("HoraPrecos").ToString
            datos.Clear()
        End If

    End Sub

    Public Sub Imprimir(ByVal esPdf As Boolean, ByVal mostrar As Boolean)

        Me.Cursor = Cursors.WaitCursor
        ' Se carga la información de la empresa.
        Dim lista As New List(Of EYEEntidadesEmbarques.Empresas)
        empresas.EId = 0 ' Se busca la primer empresa.
        lista = empresas.Obtener(True)
        If (lista.Count = 0) Then
            MsgBox("No existen datos de la empresa para encabezados de impresión. Se cancelará la impresión.", MsgBoxStyle.Information, "Faltan datos.")
            Exit Sub
        End If
        Dim nombrePdf As String = "\Temporal.pdf"
        Dim fuente7 As Integer = 7 : Dim fuente8 As Integer = 8
        Dim encabezadoPuntoPago As String = String.Empty
        Dim informacionImpresion As New FarPoint.Win.Spread.PrintInfo
        impresor.AllowSelection = True
        impresor.AllowSomePages = True
        impresor.AllowCurrentPage = True
        informacionImpresion.Orientation = PrintOrientation.Portrait
        informacionImpresion.Margin.Top = 15
        informacionImpresion.Margin.Left = 15
        informacionImpresion.Margin.Right = 15
        informacionImpresion.Margin.Bottom = 15
        informacionImpresion.ShowBorder = False
        informacionImpresion.ShowGrid = False
        informacionImpresion.Printer = impresor.PrinterSettings.PrinterName
        informacionImpresion.Centering = FarPoint.Win.Spread.Centering.Horizontal
        informacionImpresion.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        informacionImpresion.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Hide
        If (Me.opcionSeleccionada = OpcionDocumento.manifiesto Or Me.opcionSeleccionada = OpcionDocumento.distribucion) Then
            informacionImpresion.ZoomFactor = 0.75
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.remision) Then
            informacionImpresion.ZoomFactor = 0.7
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.responsiva) Then
            informacionImpresion.ZoomFactor = 0.9
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.sellos) Then
            informacionImpresion.ZoomFactor = 0.95
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.precos) Then
            informacionImpresion.ZoomFactor = 1
        End If
        Dim encabezado1 As String = String.Empty
        Dim encabezado2 As String = String.Empty
        Dim encabezado3 As String = String.Empty
        encabezado1 = "/l/fz""" & fuente7 & """" & "Rfc " & lista(0).ERfc & "/c/fz""" & fuente7 & """" & lista(0).ENombre
        encabezado1 &= "/r/fz""" & fuente7 & """" & "Página /p de /pc"
        encabezado1 = encabezado1.ToUpper
        encabezado2 = "/l/fz""" & fuente7 & """" & lista(0).EDomicilio & "/c/fb1/fz""" & fuente8 & """" & lista(0).EDescripcion & "/r/fz""" & fuente7 & """" & "Fecha: " & Today.ToShortDateString
        encabezado2 = encabezado2.ToUpper
        encabezado3 = "/l/fz""" & fuente7 & """" & lista(0).ELocalidad & "/c/fb1/fz""" & fuente8 & """" & spDocumentos.ActiveSheet.SheetName & "/r/fz""" & fuente7 & """" & "Hora: " & Now.ToShortTimeString
        encabezado3 = encabezado3.ToUpper
        If (esPdf) Then
            Dim bandera As Boolean = True
            Dim obtenerRandom As System.Random = New System.Random()
            Try
                If (Not Directory.Exists(Me.rutaTemporal)) Then
                    Directory.CreateDirectory(Me.rutaTemporal)
                End If
            Catch ex As Exception
            End Try
            Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
            While bandera
                Dim nombre As String = String.Empty
                If (mostrar) Then ' Es para impresiones directas o en mostrando el pdf.
                    nombrePdf = "\" & obtenerRandom.Next(0, 99999).ToString.PadLeft(5, "0") & ".pdf"
                    If (Not File.Exists(Me.rutaTemporal & nombrePdf)) Then
                        bandera = False
                    End If
                Else ' Es solo para generar los documentos, guardarlos en pdf y enviarlos por correo.
                    If (Me.opcionSeleccionada = OpcionDocumento.manifiesto) Then
                        nombre = "Manifiesto"
                    ElseIf (Me.opcionSeleccionada = OpcionDocumento.remision) Then
                        nombre = "Remision"
                    ElseIf (Me.opcionSeleccionada = OpcionDocumento.distribucion) Then
                        nombre = "Distribucion"
                    ElseIf (Me.opcionSeleccionada = OpcionDocumento.responsiva) Then
                        nombre = "Responsiva"
                    ElseIf (Me.opcionSeleccionada = OpcionDocumento.precos) Then
                        nombre = "Precos"
                    ElseIf (Me.opcionSeleccionada = OpcionDocumento.sellos) Then
                        nombre = "Sellos"
                    End If
                    nombrePdf = String.Format("\{0}-{1}.pdf", nombre, idEmbarque)
                    bandera = False
                End If
            End While
            informacionImpresion.PdfWriteTo = PdfWriteTo.File
            informacionImpresion.PdfFileName = Me.rutaTemporal & nombrePdf
            informacionImpresion.PrintToPdf = True
        End If
        'informacionImpresion.Header = encabezado1 & "/n" & encabezado2 & "/n" & encabezado3
        'informacionImpresion.Footer = "Creado por: Software Berry"
        For indice = 0 To spDocumentos.Sheets.Count - 1
            spDocumentos.Sheets(indice).PrintInfo = informacionImpresion
        Next
        If (Not esPdf) Then
            If (impresor.ShowDialog = Windows.Forms.DialogResult.OK) Then
                spDocumentos.PrintSheet(-1)
            End If
        Else
            If (mostrar) Then
                spDocumentos.PrintSheet(-1)
                Try
                    System.Diagnostics.Process.Start(nombrePdf)
                    System.Diagnostics.Process.Start(Me.rutaTemporal & nombrePdf)
                Catch
                    System.Diagnostics.Process.Start(Me.rutaTemporal & nombrePdf)
                End Try
            Else
                If (Not File.Exists(Me.rutaTemporal & nombrePdf)) Then
                    spDocumentos.PrintSheet(-1)
                End If
                Sleep(2000) ' Un poco de tiempo de espera para generar el documento correctamente.
            End If
        End If
        Me.rutaAdjuntar = Me.rutaTemporal & nombrePdf
        Me.Cursor = Cursors.Default
        Application.DoEvents()

    End Sub

    Private Sub ExportarExcel()

        Me.Cursor = Cursors.WaitCursor
        spParaClonar.Sheets.Clear()
        spParaClonar = ClonarSpread(spParaClonar)
        Dim bandera As Boolean = True
        Dim nombreExcel As String = "\Temporal.xls"
        Dim obtenerRandom As System.Random = New System.Random()
        FormatearExcel()
        Application.DoEvents()
        Try
            If (Not Directory.Exists(Me.rutaTemporal)) Then
                Directory.CreateDirectory(Me.rutaTemporal)
            End If
        Catch ex As Exception
        End Try
        While bandera
            nombreExcel = "\" & obtenerRandom.Next(0, 99999).ToString.PadLeft(5, "0") & ".xls"
            If Not File.Exists(Me.rutaTemporal & nombreExcel) Then
                bandera = False
            End If
        End While
        spParaClonar.SaveExcel(Me.rutaTemporal & nombreExcel, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly)
        System.Diagnostics.Process.Start(Me.rutaTemporal & nombreExcel)
        Me.Cursor = Cursors.Default

    End Sub

    Private Function ClonarSpread(baseObject As FpSpread) As FpSpread

        'Copying to a memory stream
        Dim ms As New System.IO.MemoryStream()
        FarPoint.Win.Spread.Model.SpreadSerializer.SaveXml(spDocumentos, ms, False)
        ms = New System.IO.MemoryStream(ms.ToArray())
        'Copying from memory stream to clone spread object
        Dim newSpread As New FarPoint.Win.Spread.FpSpread()
        FarPoint.Win.Spread.Model.SpreadSerializer.OpenXml(newSpread, ms)
        Dim fInfo As FieldInfo() = GetType(FarPoint.Win.Spread.FpSpread).GetFields(BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic Or BindingFlags.[Static])
        For Each field As FieldInfo In fInfo
            If field IsNot Nothing Then
                Dim del As [Delegate] = Nothing
                If field.FieldType.Name.Contains("EventHandler") Then
                    del = DirectCast(field.GetValue(baseObject), [Delegate])
                End If

                If del IsNot Nothing Then
                    Dim eInfo As EventInfo = GetType(FarPoint.Win.Spread.FpSpread).GetEvent(del.Method.Name.Substring(del.Method.Name.IndexOf("_"c) + 1))
                    If eInfo IsNot Nothing Then
                        eInfo.AddEventHandler(newSpread, del)
                    End If
                End If
            End If
        Next
        Return newSpread

    End Function

    Private Sub FormatearExcel()

        ' Se carga la información de la empresa.
        Dim lista As New List(Of EYEEntidadesEmbarques.Empresas)
        empresas.EId = 0 ' Se busca la primer empresa.
        lista = empresas.Obtener(True)
        If (lista.Count = 0) Then
            MsgBox("No existen datos de la empresa para encabezados de impresión. Se cancelará la impresión.", MsgBoxStyle.Information, "Faltan datos.")
            Exit Sub
        End If
        Dim fuente6 As Integer = 6
        Dim fuente7 As Integer = 7
        Dim fuente8 As Integer = 8
        Dim encabezado1I As String = String.Empty
        Dim encabezado1C As String = String.Empty
        Dim encabezado2I As String = String.Empty
        Dim encabezado2C As String = String.Empty
        Dim encabezado2D As String = String.Empty
        Dim encabezado3I As String = String.Empty
        Dim encabezado3C As String = String.Empty
        Dim encabezado3D As String = String.Empty
        encabezado1I = "RFC " & lista(0).ERfc : encabezado1I = encabezado1I.ToUpper
        encabezado1C = lista(0).ENombre : encabezado1C = encabezado1C.ToUpper
        encabezado2I = lista(0).EDomicilio : encabezado2I = encabezado2I.ToUpper
        encabezado2C = lista(0).EDescripcion : encabezado2C = encabezado2C.ToUpper
        encabezado2D = "Fecha: " & Today.ToShortDateString : encabezado2D = encabezado2D.ToUpper
        encabezado3I = lista(0).ELocalidad : encabezado3I = encabezado3I.ToUpper
        encabezado3C = spDocumentos.ActiveSheet.SheetName : encabezado3C = encabezado3C.ToUpper
        encabezado3D = "Hora: " & Now.ToShortTimeString : encabezado3D = encabezado3D.ToUpper
        For indice = 0 To spParaClonar.Sheets.Count - 1
            spParaClonar.Sheets(indice).Columns.Count = spDocumentos.Sheets(indice).Columns.Count + 10
            spParaClonar.Sheets(indice).Protect = False
            spParaClonar.Sheets(indice).ColumnHeader.Rows.Add(0, 6)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(0, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(0, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(0, 8, 1, 2)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(1, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(1, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(1, 8, 1, 2)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(2, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(2, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(2, 8, 1, 2)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(3, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(3, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(4, 0, 1, spParaClonar.Sheets(indice).ColumnCount)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 0).Text = encabezado1I
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 3).Text = encabezado1C
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).Text = encabezado2I
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).Text = encabezado2C
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).Text = encabezado2D
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).Text = encabezado3I
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).Text = encabezado3C
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).Text = encabezado3D
            spParaClonar.Sheets(indice).ColumnHeader.Cells(4, 0).Border = New FarPoint.Win.LineBorder(Color.Black, 1, False, True, False, False)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Next
        spParaClonar.ActiveSheet.Protect = False
        spParaClonar.ActiveSheet.Rows.Count += 20 ' Se aumenta la cantidad de filas debido a un bug del spread al exportar a excel.

    End Sub

    Public Sub EliminarArchivosTemporales()

        Try
            If (Directory.Exists(Me.rutaTemporal)) Then
                Directory.Delete(Me.rutaTemporal, True)
                Directory.CreateDirectory(Me.rutaTemporal)
            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Enumeraciones"

    Public Enum OpcionDocumento

        manifiesto = 1
        remision = 2
        distribucion = 3
        responsiva = 4
        sellos = 5
        precos = 6

    End Enum

#End Region

End Class