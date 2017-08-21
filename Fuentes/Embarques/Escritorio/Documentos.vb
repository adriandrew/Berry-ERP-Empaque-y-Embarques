Public Class Documentos

    Public nombreEstePrograma As String = String.Empty
    Public opcionSeleccionada As Integer = 0

#Region "Eventos"

    Private Sub Documentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         
        Me.Cursor = Cursors.WaitCursor
        Centrar()
        CargarNombrePrograma()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Documentos_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Cursor = Cursors.WaitCursor
        CargarTitulosDirectorio()
        GenerarDocumento()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Documentos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Salir()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.Close()

    End Sub

#End Region

#Region "Métodos"

    Private Sub Salir()

        Principal.MostrarOcultarPanelDocumentos()
        Principal.Enabled = True

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

    Private Sub GenerarDocumento()

        If (Me.opcionSeleccionada = OpcionDocumento.manifiesto) Then
            GenerarManifiesto()
        ElseIf (Me.opcionSeleccionada = OpcionDocumento.remision) Then

        End If

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
        spDocumentos.Width = ancho + 120
        ' Se saca diferencia para centrarlo a la pantalla.
        Dim diferenciaAncho As Double = Me.Width - spDocumentos.Width
        If (diferenciaAncho > 0) Then
            spDocumentos.Left = diferenciaAncho / 2
        End If
        spDocumentos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spDocumentos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always

    End Sub

    Private Sub GenerarManifiesto()

        Dim ruta As String = String.Format("{0}/{1}", Application.StartupPath, "Manifiesto.xml")
        If (Principal.esDesarrollo) Then
            ruta = "W:\Manifiesto.xml"
        End If
        spDocumentos.Open(ruta)
        FormatearSpread()
        Dim idEmbarque As Integer = EYELogicaEmbarques.Funciones.ValidarNumeroACero(Principal.txtId.Text)
        Dim datos As New DataTable
        Principal.embarques.EId = idEmbarque
        Principal.embarques.EIdTipo = Principal.opcionTipoSeleccionada
        datos = Principal.embarques.ObtenerListadoReporteManifiesto()
        If (datos.Rows.Count > 0) Then
            ' Inicia el relleno de datos del embarque en la parte arriba y derecha.
            spDocumentos.ActiveSheet.Cells("productor").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreEmbarcador"))
            spDocumentos.ActiveSheet.Cells("domicilio").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("DomicilioEmbarcador"))
            spDocumentos.ActiveSheet.Cells("municipioEstado").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioEmbarcador")), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoEmbarcador")))
            spDocumentos.ActiveSheet.Cells("ggn").Text = String.Format("GGN: {0}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("GgnEmbarcador")))
            spDocumentos.ActiveSheet.Cells("fecha").Text = datos.Rows(0).Item("Fecha")
            spDocumentos.ActiveSheet.Cells("hora").Text = datos.Rows(0).Item("Hora").ToString
            spDocumentos.ActiveSheet.Cells("idEmbarque").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Id"))
            spDocumentos.ActiveSheet.Cells("remision").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Factura"))
            spDocumentos.ActiveSheet.Cells("fda").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("FdaEmbarcador"))
            spDocumentos.ActiveSheet.Cells("cliente").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreCliente"))
            spDocumentos.ActiveSheet.Cells("placasUsa").Text = String.Format("{0} - {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasUsaTrailer")), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NumeroEconomicoTrailer")))
            spDocumentos.ActiveSheet.Cells("placasMex").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasMexTrailer"))
            spDocumentos.ActiveSheet.Cells("placasUsaCaja").Text = String.Format("{0} - {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("PlacasUsaCaja")), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NumeroEconomicoCaja")))
            spDocumentos.ActiveSheet.Cells("serie").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("SerieTrailer"))
            spDocumentos.ActiveSheet.Cells("temperatura").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Temperatura"))
            spDocumentos.ActiveSheet.Cells("destino").Text = String.Format("{0}, {1}", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("MunicipioCliente")), EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("EstadoCliente")))
            spDocumentos.ActiveSheet.Cells("linea").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreLineaTransporte"))
            spDocumentos.ActiveSheet.Cells("chofer").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreChofer"))
            spDocumentos.ActiveSheet.Cells("cliente").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("NombreCliente"))
            spDocumentos.ActiveSheet.Cells("termografo").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Termografo"))
            spDocumentos.ActiveSheet.Cells("sello1").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello1"))
            spDocumentos.ActiveSheet.Cells("sello2").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello2"))
            spDocumentos.ActiveSheet.Cells("sello3").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello3"))
            spDocumentos.ActiveSheet.Cells("sello4").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello4"))
            spDocumentos.ActiveSheet.Cells("sello5").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello5"))
            spDocumentos.ActiveSheet.Cells("sello6").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello6"))
            spDocumentos.ActiveSheet.Cells("sello7").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello7"))
            spDocumentos.ActiveSheet.Cells("sello8").Text = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(0).Item("Sello8"))
            datos.Clear()
            ' Inicia desglose de presentaciones en la parte abajo y derecha.
            Dim totalCajas As Integer = 0
            Dim filaSpread As Integer = 27 ' Fila de inicio de desglose.
            Dim columnaSpread As Integer = 0
            ' Inicia productos.
            Dim datosProductos As DataTable
            Dim filaProducto As Integer = 0
            datosProductos = Principal.embarques.ObtenerListadoReporteManifiesto2(True, False, False, False, 0, 0, 0, 0)
            While filaProducto < datosProductos.Rows.Count
                Dim idProducto As Integer = datosProductos.Rows(filaProducto).Item("IdProducto")
                columnaSpread = 6
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarLetra(datosProductos.Rows(filaProducto).Item("AbreviaturaProducto"))
                columnaSpread = 13
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosProductos.Rows(filaProducto).Item("CantidadCajas"))
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).CellType = Principal.tipoEntero
                filaSpread += 1
                ' Inicia envases.
                Dim datosEnvases As DataTable
                Dim filaEnvase As Integer = 0
                datosEnvases = Principal.embarques.ObtenerListadoReporteManifiesto2(False, True, False, False, idProducto, 0, 0, 0)
                While filaEnvase < datosEnvases.Rows.Count
                    Dim idEnvase As Integer = datosEnvases.Rows(filaEnvase).Item("IdEnvase")
                    columnaSpread = 7
                    spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaSpread, 1, 2)
                    spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarLetra(datosEnvases.Rows(filaEnvase).Item("AbreviaturaEnvase"))
                    columnaSpread = 13
                    spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosEnvases.Rows(filaEnvase).Item("CantidadCajas"))
                    spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).CellType = Principal.tipoEntero
                    filaSpread += 1
                    ' Inicia etiquetas.
                    Dim datosEtiquetas As DataTable
                    Dim filaEtiqueta As Integer = 0
                    datosEtiquetas = Principal.embarques.ObtenerListadoReporteManifiesto2(False, False, True, False, idProducto, idEnvase, 0, 0)
                    While filaEtiqueta < datosEtiquetas.Rows.Count
                        Dim idEtiqueta As Integer = datosEtiquetas.Rows(filaEtiqueta).Item("IdEtiqueta")
                        columnaSpread = 9
                        spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaSpread, 1, 2)
                        spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarLetra(datosEtiquetas.Rows(filaEtiqueta).Item("AbreviaturaEtiqueta"))
                        columnaSpread = 13
                        spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosEtiquetas.Rows(filaEtiqueta).Item("CantidadCajas"))
                        spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).CellType = Principal.tipoEntero
                        filaSpread += 1
                        ' Inicia tamanos.
                        Dim datosTamanos As DataTable
                        Dim filaTamano As Integer = 0
                        datosTamanos = Principal.embarques.ObtenerListadoReporteManifiesto2(False, False, False, True, idProducto, idEnvase, idEtiqueta, 0)
                        While filaTamano < datosTamanos.Rows.Count
                            columnaSpread = 11
                            spDocumentos.ActiveSheet.AddSpanCell(filaSpread, columnaSpread, 1, 2)
                            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarLetra(datosTamanos.Rows(filaTamano).Item("AbreviaturaTamano"))
                            columnaSpread = 13
                            spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosTamanos.Rows(filaTamano).Item("CantidadCajas"))
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
                totalCajas += EYELogicaEmbarques.Funciones.ValidarNumeroACero(datosProductos.Rows(filaProducto).Item("CantidadCajas"))
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
            datos.Clear()
            ' Inicia desglose de tarimas en trailer en la parte arriba y izquierda.
            Principal.tarimas.EIdEmbarque = idEmbarque
            Principal.tarimas.EIdTipoEmbarque = Principal.opcionTipoSeleccionada
            datos = Principal.embarques.ObtenerListadoReporte()
            filaSpread = 0 : Dim filaSpreadTarima As Integer = 0 ' Es para las filas en cada una de las tarimas, ya que llevan mixto algunas.
            Dim filaTarima As Integer = 0
            While filaTarima < datos.Rows.Count
                Dim orden As Integer = datos.Rows(filaTarima).Item("OrdenEmbarque")
                Dim columnaSpreadIzquierda As Integer = 1 : Dim columnaSpreadDerecha As Integer = 3 : columnaSpread = 0
                filaSpread = Math.Floor(orden / 2) ' Se divide el orden para saber en que fila va. 
                filaSpread *= 5 ' Se multiplica por 5, ya que salta cada 5 filas en el formato.
                filaSpread += 4 ' Se suma 4 ya que comienza en esa fila.
                If (orden Mod 2 = 0) Then ' Izquierda 
                    columnaSpread = columnaSpreadIzquierda
                Else ' Derecha.
                    columnaSpread = columnaSpreadDerecha
                End If
                ' Número y cantidad de cajas de la tarima.
                spDocumentos.ActiveSheet.Cells(filaSpread, columnaSpread).Text = String.Format("No. {0} ({1})", EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaTarima).Item("Id")), EYELogicaEmbarques.Funciones.ValidarNumeroACero(datos.Rows(filaTarima).Item("CantidadCajas")))
                filaSpreadTarima = filaSpread + 1
                ' Esto es para desglosar las presentaciones por tarimas.
                Dim arregloProducto() As String = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaTarima).Item("NombreProducto")).Split("-")
                Dim arregloEnvase() As String = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaTarima).Item("NombreEnvase")).Split("-")
                Dim arregloEtiqueta() As String = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaTarima).Item("NombreEtiqueta")).Split("-")
                Dim arregloTamano() As String = EYELogicaEmbarques.Funciones.ValidarLetra(datos.Rows(filaTarima).Item("NombreTamano")).Split("-")
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
                    spDocumentos.ActiveSheet.Cells(filaSpreadTarima, columnaSpread).Text = String.Format("{0} {1} {2} {3}", arregloProducto(filaArregloMixteo), arregloEnvase(filaArregloMixteo), arregloEtiqueta(filaArregloMixteo), arregloTamano(filaArregloMixteo))
                    spDocumentos.ActiveSheet.Cells(filaSpreadTarima, columnaSpread).Font = New Font(Principal.tipoLetraSpread, 6, FontStyle.Regular)
                    filaSpreadTarima += 1
                Next
                filaTarima += 1
            End While
        End If

    End Sub

#End Region

#Region "Enumeraciones"

    Public Enum OpcionDocumento

        manifiesto = 1
        remision = 2

    End Enum

#End Region

End Class