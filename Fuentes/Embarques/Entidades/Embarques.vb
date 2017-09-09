Imports System.Data.SqlClient

Public Class Embarques

    Private id As Integer
    Private idTipo As Integer
    Private idProductor As Integer
    Private idEmbarcador As Integer
    Private idCliente As Integer
    Private idLineaTransporte As Integer
    Private idTrailer As Integer
    Private idCajaTrailer As Integer
    Private idChofer As Integer
    Private idAduanaMex As Integer
    Private idAduanaUsa As Integer
    Private idDocumentador As Integer
    Private fecha As Date
    Private hora As String
    Private temperatura As Double
    Private termografo As String
    Private precioFlete As Double
    Private horaPrecos As String
    Private sello1 As String
    Private sello2 As String
    Private sello3 As String
    Private sello4 As String
    Private sello5 As String
    Private sello6 As String
    Private sello7 As String
    Private sello8 As String
    Private factura As String
    Private guiaCaades As String
    Private banderin As String
    Private observaciones As String

    Public Property EId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property EIdTipo() As Integer
        Get
            Return idTipo
        End Get
        Set(value As Integer)
            idTipo = value
        End Set
    End Property
    Public Property EIdProductor() As Integer
        Get
            Return idProductor
        End Get
        Set(value As Integer)
            idProductor = value
        End Set
    End Property
    Public Property EIdEmbarcador() As Integer
        Get
            Return idEmbarcador
        End Get
        Set(value As Integer)
            idEmbarcador = value
        End Set
    End Property
    Public Property EIdCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(value As Integer)
            idCliente = value
        End Set
    End Property
    Public Property EIdLineaTransporte() As Integer
        Get
            Return idLineaTransporte
        End Get
        Set(value As Integer)
            idLineaTransporte = value
        End Set
    End Property
    Public Property EIdTrailer() As Integer
        Get
            Return idTrailer
        End Get
        Set(value As Integer)
            idTrailer = value
        End Set
    End Property
    Public Property EIdCajaTrailer() As Integer
        Get
            Return idCajaTrailer
        End Get
        Set(value As Integer)
            idCajaTrailer = value
        End Set
    End Property
    Public Property EIdChofer() As Integer
        Get
            Return idChofer
        End Get
        Set(value As Integer)
            idChofer = value
        End Set
    End Property
    Public Property EIdAduanaMex() As Integer
        Get
            Return idAduanaMex
        End Get
        Set(value As Integer)
            idAduanaMex = value
        End Set
    End Property
    Public Property EIdAduanaUsa() As Integer
        Get
            Return idAduanaUsa
        End Get
        Set(value As Integer)
            idAduanaUsa = value
        End Set
    End Property
    Public Property EIdDocumentador() As Integer
        Get
            Return idDocumentador
        End Get
        Set(value As Integer)
            idDocumentador = value
        End Set
    End Property
    Public Property EFecha() As Date
        Get
            Return fecha
        End Get
        Set(value As Date)
            fecha = value
        End Set
    End Property
    Public Property EHora() As String
        Get
            Return hora
        End Get
        Set(value As String)
            hora = value
        End Set
    End Property
    Public Property ETemperatura() As Double
        Get
            Return temperatura
        End Get
        Set(value As Double)
            temperatura = value
        End Set
    End Property
    Public Property ETermografo() As String
        Get
            Return termografo
        End Get
        Set(value As String)
            termografo = value
        End Set
    End Property
    Public Property EPrecioFlete() As Double
        Get
            Return precioFlete
        End Get
        Set(value As Double)
            precioFlete = value
        End Set
    End Property
    Public Property EHoraPrecos() As String
        Get
            Return horaPrecos
        End Get
        Set(value As String)
            horaPrecos = value
        End Set
    End Property
    Public Property ESello1() As String
        Get
            Return sello1
        End Get
        Set(value As String)
            sello1 = value
        End Set
    End Property
    Public Property ESello2() As String
        Get
            Return sello2
        End Get
        Set(value As String)
            sello2 = value
        End Set
    End Property
    Public Property ESello3() As String
        Get
            Return sello3
        End Get
        Set(value As String)
            sello3 = value
        End Set
    End Property
    Public Property ESello4() As String
        Get
            Return sello4
        End Get
        Set(value As String)
            sello4 = value
        End Set
    End Property
    Public Property ESello5() As String
        Get
            Return sello5
        End Get
        Set(value As String)
            sello5 = value
        End Set
    End Property
    Public Property ESello6() As String
        Get
            Return sello6
        End Get
        Set(value As String)
            sello6 = value
        End Set
    End Property
    Public Property ESello7() As String
        Get
            Return sello7
        End Get
        Set(value As String)
            sello7 = value
        End Set
    End Property
    Public Property ESello8() As String
        Get
            Return sello8
        End Get
        Set(value As String)
            sello8 = value
        End Set
    End Property
    Public Property EFactura() As String
        Get
            Return factura
        End Get
        Set(value As String)
            factura = value
        End Set
    End Property
    Public Property EGuiaCaades() As String
        Get
            Return guiaCaades
        End Get
        Set(value As String)
            guiaCaades = value
        End Set
    End Property
    Public Property EBanderin() As String
        Get
            Return banderin
        End Get
        Set(value As String)
            banderin = value
        End Set
    End Property
    Public Property EObservaciones() As String
        Get
            Return observaciones
        End Get
        Set(value As String)
            observaciones = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = "INSERT INTO Embarques (Id, IdTipo, IdProductor, IdEmbarcador, IdCliente, IdLineaTransporte, IdTrailer, IdCajaTrailer, IdChofer, idAduanaMex, idAduanaUsa, IdDocumentador, Fecha, Hora, Temperatura, Termografo, PrecioFlete, HoraPrecos, Observaciones, Sello1, Sello2, Sello3, Sello4, Sello5, Sello6, Sello7, Sello8, Factura, GuiaCaades, Banderin) VALUES (@id, @idTipo, @idProductor, @idEmbarcador, @idCliente, @idLineaTransporte, @idTrailer, @idCajaTrailer, @idChofer, @idAduanaMex, @idAduanaUsa, @idDocumentador, @fecha, @hora, @temperatura, @termografo, @precioFlete, @horaPrecos, @observaciones, @sello1, @sello2, @sello3, @sello4, @sello5, @sello6, @sello7, @sello8, @factura, @guiaCaades, @banderin)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@idEmbarcador", Me.EIdEmbarcador)
            comando.Parameters.AddWithValue("@idCliente", Me.EIdCliente)
            comando.Parameters.AddWithValue("@idLineaTransporte", Me.EIdLineaTransporte)
            comando.Parameters.AddWithValue("@idTrailer", Me.EIdTrailer)
            comando.Parameters.AddWithValue("@idCajaTrailer", Me.EIdCajaTrailer)
            comando.Parameters.AddWithValue("@idChofer", Me.EIdChofer)
            comando.Parameters.AddWithValue("@idAduanaMex", Me.EIdAduanaMex)
            comando.Parameters.AddWithValue("@idAduanaUsa", Me.EIdAduanaUsa)
            comando.Parameters.AddWithValue("@idDocumentador", Me.EIdDocumentador)
            comando.Parameters.AddWithValue("@fecha", Me.EFecha)
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            comando.Parameters.AddWithValue("@temperatura", Me.ETemperatura)
            comando.Parameters.AddWithValue("@termografo", Me.ETermografo)
            comando.Parameters.AddWithValue("@precioFlete", Me.EPrecioFlete)
            comando.Parameters.AddWithValue("@horaPrecos", Me.EHoraPrecos) 
            comando.Parameters.AddWithValue("@sello1", Me.ESello1)
            comando.Parameters.AddWithValue("@sello2", Me.ESello2)
            comando.Parameters.AddWithValue("@sello3", Me.ESello3)
            comando.Parameters.AddWithValue("@sello4", Me.ESello4)
            comando.Parameters.AddWithValue("@sello5", Me.ESello5)
            comando.Parameters.AddWithValue("@sello6", Me.ESello6)
            comando.Parameters.AddWithValue("@sello7", Me.ESello7)
            comando.Parameters.AddWithValue("@sello8", Me.ESello8)
            comando.Parameters.AddWithValue("@factura", Me.EFactura)
            comando.Parameters.AddWithValue("@guiaCaades", Me.EGuiaCaades)
            comando.Parameters.AddWithValue("@banderin", Me.EBanderin)
            comando.Parameters.AddWithValue("@observaciones", Me.EObservaciones)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

    Public Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EIdTipo > 0) Then
                condicion &= " AND IdTipo=@idTipo"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "DELETE FROM Embarques WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

    Public Function ObtenerMaximoId() As Integer

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EIdTipo > 0) Then
                condicion &= " AND IdTipo=@idTipo"
            End If
            comando.CommandText = "SELECT MAX(CAST (Id AS Int)) AS IdMaximo FROM Embarques WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim valor As Integer = 0
            While lectorDatos.Read()
                valor = EYELogicaEmbarques.Funciones.ValidarNumeroACero(lectorDatos("IdMaximo").ToString()) + 1
            End While
            BaseDatos.conexionEmpaque.Close()
            Return valor
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EIdTipo > 0) Then
                condicion &= " AND T.IdTipoEmbarque=@idTipo"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND T.IdEmbarque=@id"
            End If
            comando.CommandText = "SELECT T.Id, P.Abreviatura AS AbreviaturaProducto, V.Abreviatura AS AbreviaturaVariedad, E.Abreviatura AS AbreviaturaEnvase, T2.Abreviatura AS AbreviaturaTamano, E2.Abreviatura AS AbreviaturaEtiqueta, T.CantidadCajas, 'TRUE' AS EsExistente, T.OrdenEmbarque, P.Nombre AS NombreProducto, V.Nombre AS NombreVariedad, E.Nombre AS NombreEnvase, T2.Nombre AS NombreTamano, E2.Nombre AS NombreEtiqueta" & _
            " FROM Tarimas AS T " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Productos AS P ON T.IdProducto = P.Id " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Variedades AS V ON T.IdProducto = V.IdProducto AND T.IdVariedad = V.Id " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Envases AS E ON T.IdEnvase = E.Id " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Tamanos AS T2 ON T.IdProducto = T2.IdProducto AND T.IdTamano = T2.Id " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Etiquetas AS E2 ON T.IdEtiqueta = E2.Id " & _
            " WHERE 0=0 " & condicion & " ORDER BY T.OrdenEmbarque ASC"
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            BaseDatos.conexionEmpaque.Close()
            For columna = 0 To datos.Columns.Count - 1
                If (datos.Columns(columna).DataType Is GetType(String)) Then
                    datos.Columns(columna).MaxLength = 400
                End If
            Next
            Dim indice As Integer = 0
            Dim indiceAnterior As Integer = 0
            Dim id As Integer = 0
            Dim contador As Integer = 0
            Dim idAnterior As Integer = 0
            While indice < datos.Rows.Count
                id = datos.Rows(indice).Item("Id").ToString()
                If (indice > 0) Then
                    idAnterior = datos.Rows(indiceAnterior).Item("Id").ToString
                End If
                If (idAnterior = id And indice > 0) Then
                    datos.Rows(indiceAnterior).Item("NombreProducto") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("NombreProducto").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("NombreVariedad") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("NombreVariedad").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("NombreEnvase") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("NombreEnvase").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("NombreTamano") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("NombreTamano").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("NombreEtiqueta") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("NombreEtiqueta").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") " 
                    datos.Rows(indiceAnterior).Item("AbreviaturaProducto") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("AbreviaturaProducto").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("AbreviaturaVariedad") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("AbreviaturaVariedad").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("AbreviaturaEnvase") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("AbreviaturaEnvase").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("AbreviaturaTamano") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("AbreviaturaTamano").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("AbreviaturaEtiqueta") &= IIf(contador > 0, "- ", String.Empty) & datos.Rows(indice).Item("AbreviaturaEtiqueta").ToString() & " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") " 
                    datos.Rows(indiceAnterior).Item("CantidadCajas") += datos.Rows(indice).Item("CantidadCajas").ToString()
                    If (indice > 0) Then
                        datos.Rows(indice).Delete()
                    End If
                Else
                    indiceAnterior = indice
                    contador = 0
                    datos.Rows(indiceAnterior).Item("NombreProducto") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("NombreVariedad") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("NombreEnvase") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("NombreTamano") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("NombreEtiqueta") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") " 
                    datos.Rows(indiceAnterior).Item("AbreviaturaProducto") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("AbreviaturaVariedad") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("AbreviaturaEnvase") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("AbreviaturaTamano") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                    datos.Rows(indiceAnterior).Item("AbreviaturaEtiqueta") &= " (" & datos.Rows(indice).Item("CantidadCajas").ToString() & ") "
                End If
                contador += 1
                indice += 1
            End While
            datos.AcceptChanges()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerListado() As List(Of Embarques)

        Try
            Dim lista As New List(Of Embarques)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EIdTipo > 0) Then
                condicion &= " AND IdTipo=@idTipo"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "SELECT Id, Fecha, Hora, IdProductor, IdEmbarcador, IdCliente, IdLineaTransporte, IdTrailer, IdCajaTrailer, IdChofer, IdAduanaMex, IdAduanaUsa, IdDocumentador, Temperatura, Termografo, PrecioFlete, HoraPrecos, Sello1, Sello2, Sello3, Sello4, Sello5, Sello6, Sello7, Sello8, Factura, GuiaCaades FROM Embarques WHERE 0=0 " & condicion & " ORDER BY sello4 ASC"
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim tabla As Embarques
            While lectorDatos.Read()
                tabla = New Embarques()
                tabla.id = Convert.ToInt32(lectorDatos("Id").ToString())
                tabla.fecha = Convert.ToDateTime(lectorDatos("Fecha").ToString())
                tabla.hora = lectorDatos("Hora").ToString()
                tabla.idProductor = Convert.ToInt32(lectorDatos("IdProductor").ToString())
                tabla.idEmbarcador = Convert.ToInt32(lectorDatos("IdEmbarcador").ToString())
                tabla.idCliente = Convert.ToInt32(lectorDatos("IdCliente").ToString())
                tabla.idLineaTransporte = Convert.ToInt32(lectorDatos("IdLineaTransporte").ToString())
                tabla.idTrailer = Convert.ToInt32(lectorDatos("IdTrailer").ToString())
                tabla.idCajaTrailer = Convert.ToInt32(lectorDatos("IdCajaTrailer").ToString())
                tabla.idChofer = Convert.ToInt32(lectorDatos("IdChofer").ToString())
                tabla.idAduanaMex = Convert.ToInt32(lectorDatos("IdAduanaMex").ToString())
                tabla.idAduanaUsa = Convert.ToInt32(lectorDatos("IdAduanaUsa").ToString())
                tabla.idDocumentador = Convert.ToInt32(lectorDatos("IdDocumentador").ToString())
                tabla.temperatura = Convert.ToDouble(lectorDatos("Temperatura").ToString())
                tabla.termografo = lectorDatos("Termografo").ToString()
                tabla.precioFlete = Convert.ToDouble(lectorDatos("PrecioFlete").ToString())
                tabla.horaPrecos = lectorDatos("HoraPrecos").ToString()
                tabla.sello1 = lectorDatos("Sello1").ToString()
                tabla.sello2 = lectorDatos("Sello2").ToString()
                tabla.sello3 = lectorDatos("Sello3").ToString()
                tabla.sello4 = lectorDatos("Sello4").ToString()
                tabla.sello5 = lectorDatos("Sello5").ToString()
                tabla.sello6 = lectorDatos("Sello6").ToString()
                tabla.sello7 = lectorDatos("Sello7").ToString()
                tabla.sello8 = lectorDatos("Sello8").ToString()
                tabla.factura = lectorDatos("Factura").ToString()
                tabla.guiaCaades = lectorDatos("GuiaCaades").ToString()
                lista.Add(tabla)
            End While
            BaseDatos.conexionEmpaque.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerMinimaFecha() As Date

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = "SELECT MIN(fecha) AS FechaMinima FROM Embarques"
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim valor As Date
            While lectorDatos.Read()
                valor = lectorDatos("FechaMinima").ToString()
            End While
            If (Not lectorDatos.HasRows) Then
                valor = Today
            End If
            BaseDatos.conexionEmpaque.Close()
            Return valor
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function
     
    Public Function ObtenerListadoReporteManifiestoRemisionDistribucionResponsivaSellos() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim bdCatalogos As String = EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque
            comando.CommandText = String.Format("SELECT E.Id, E.Factura, E.Fecha, E.Hora, E.Temperatura, E.IdEmbarcador, E2.Nombre AS NombreEmbarcador, E2.Domicilio AS DomicilioEmbarcador, E2.Municipio AS MunicipioEmbarcador, E2.Estado AS EstadoEmbarcador, E2.Rfc AS RfcEmbarcador, E2.Ggn AS GgnEmbarcador, E2.Fda AS FdaEmbarcador, E.IdCliente, C.Nombre AS NombreCliente, C.Domicilio AS DomicilioCliente, C.Municipio AS MunicipioCliente, C.Estado AS EstadoCliente, C.Rfc AS RfcCliente, E.IdLineaTransporte, LT.Nombre AS NombreLineaTransporte, E.IdTrailer, T.PlacasMex AS PlacasMexTrailer, T.PlacasUsa AS PlacasUsaTrailer, T.Serie AS SerieTrailer, T.NumeroEconomico AS NumeroEconomicoTrailer, T.Marca AS MarcaTrailer, T.Modelo AS ModeloTrailer, T.Scac AS ScacTrailer, T.Color AS ColorTrailer, E.IdCajaTrailer, CT.Serie AS SerieCaja, CT.PlacasMex AS PlacasMexCaja, CT.PlacasUsa AS PlacasUsaCaja, CT.NumeroEconomico AS NumeroEconomicoCaja, CT.Marca AS MarcaCaja, E.IdChofer, C2.Nombre AS NombreChofer, C2.Licencia AS LicenciaChofer, C2.Visa AS VisaChofer, E.IdAduanaMex, AM.Nombre AS AduanaMex, E.IdAduanaUsa, AU.Nombre AS AduanaUsa, E.IdDocumentador, E.Temperatura, E.Termografo, E.PrecioFlete, E.HoraPrecos, E.Sello1, E.Sello2, E.Sello3, E.Sello4, E.Sello5, E.Sello6, E.Sello7, E.Sello8, E.Factura, E.GuiaCaades " & _
            " FROM Embarques AS E " & _
            " LEFT JOIN {0}Productores AS E2 ON E.IdEmbarcador = E2.Id " & _
            " LEFT JOIN {0}Clientes AS C ON E.IdCliente = C.Id " & _
            " LEFT JOIN {0}LineasTransportes AS LT ON E.IdLineaTransporte = LT.Id " & _
            " LEFT JOIN {0}Trailers AS T ON E.IdLineaTransporte = T.IdLineaTransporte AND E.IdTrailer = T.Id " & _
            " LEFT JOIN {0}CajasTrailers AS CT ON E.IdCajaTrailer = CT.Id " & _
            " LEFT JOIN {0}Choferes AS C2 ON E.IdChofer= C2.Id " & _
            " LEFT JOIN {0}AduanasMex AS AM ON E.IdAduanaMex= AM.Id " & _
            " LEFT JOIN {0}AduanasUsa AS AU ON E.IdAduanaUsa= AU.Id " & _
            " WHERE E.IdTipo=@idTipo AND E.Id=@id", bdCatalogos)
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerListadoReporteManifiestoDesgloseEscalonado(ByVal esProducto As Boolean, ByVal esEnvase As Boolean, ByVal esEtiqueta As Boolean, ByVal esTamano As Boolean, ByVal idProducto As Integer, ByVal idEnvase As Integer, ByVal idEtiqueta As Integer, ByVal idTamano As Integer) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicionWhere As String = String.Empty : Dim condicionGroup As String = String.Empty : Dim condicionSelect As String = String.Empty
            If (esProducto) Then
                condicionSelect &= " T.IdProducto, P.Nombre AS NombreProducto, P.Abreviatura AS AbreviaturaProducto "
                condicionGroup &= "T.IdProducto, P.Nombre, P.Abreviatura "
            End If
            If (esEnvase) Then
                condicionSelect &= " T.IdEnvase, E.Nombre AS NombreEnvase, E.Abreviatura AS AbreviaturaEnvase "
                condicionGroup &= " T.IdEnvase, E.Nombre, E.Abreviatura "
            End If
            If (esEtiqueta) Then
                condicionSelect &= "T.IdEtiqueta, ET.Nombre AS NombreEtiqueta, ET.Abreviatura AS AbreviaturaEtiqueta"
                condicionGroup &= " T.IdEtiqueta, ET.Nombre, ET.Abreviatura "
            End If
            If (esTamano) Then
                condicionSelect &= " T.IdTamano, TA.Nombre AS NombreTamano, TA.Abreviatura AS AbreviaturaTamano "
                condicionGroup &= " T.IdTamano, TA.Nombre, TA.Abreviatura "
            End If
            If (idProducto > 0) Then
                condicionWhere &= " AND T.IdProducto = @idProducto "
            ElseIf (idEnvase > 0) Then
                condicionWhere &= " AND T.IdEnvase = @idEnvase "
            ElseIf (idEtiqueta > 0) Then
                condicionWhere &= " AND T.IdEtiqueta = @idEtiqueta "
            ElseIf (idTamano > 0) Then
                condicionWhere &= " AND T.IdTamano = @idTamano "
            End If
            Dim bdCatalogos As String = EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque
            comando.CommandText = String.Format("SELECT SUM(ISNULL(T.CantidadCajas, 0)) AS CantidadCajas, {1} " & _
                    " FROM Tarimas AS T " & _
                    " LEFT JOIN {0}Productos AS P ON T.IdProducto = P.Id " & _
                    " LEFT JOIN {0}Envases AS E ON T.IdEnvase = E.Id " & _
                    " LEFT JOIN {0}Tamanos AS TA ON T.IdProducto = TA.IdProducto AND T.IdTamano = TA.Id " & _
                    " LEFT JOIN {0}Etiquetas AS ET ON T.IdEtiqueta = ET.Id " & _
                    " WHERE T.IdTipoEmbarque=@idTipoEmbarque AND T.IdEmbarque=@idEmbarque {2}" & _
                    " GROUP BY {3}", bdCatalogos, condicionSelect, condicionWhere, condicionGroup)
            comando.Parameters.AddWithValue("@idTipoEmbarque", Me.EIdTipo)
            comando.Parameters.AddWithValue("@idEmbarque", Me.EId)
            comando.Parameters.AddWithValue("@idProducto", idProducto)
            comando.Parameters.AddWithValue("@idEnvase", idEnvase)
            comando.Parameters.AddWithValue("@idEtiqueta", idEtiqueta)
            comando.Parameters.AddWithValue("@idTamano", idTamano)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerListadoReporteRemisionDistribucionResponsiva() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim bdCatalogos As String = EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque
            comando.CommandText = String.Format("SELECT P.Nombre AS NombreProducto, P.Abreviatura AS AbreviaturaProducto, V.Nombre AS NombreVariedad, V.Abreviatura AS AbreviaturaVariedad, E.Nombre AS NombreEnvase, E.Abreviatura AS AbreviaturaEnvase, T2.Nombre AS NombreTamano, T2.Abreviatura AS AbreviaturaTamano, E2.Nombre AS NombreEtiqueta, E2.Abreviatura AS AbreviaturaEtiqueta, 1 AS PrecioUnitarioCajas, SUM(ISNULL(T.CantidadCajas, 0)) AS CantidadCajas, SUM(ISNULL(T.PesoTotalCajas, 0)) AS PesoTotalCajas " & _
                    " FROM Tarimas AS T " & _
                    " LEFT JOIN {0}Productos AS P ON T.IdProducto = P.Id " & _
                    " LEFT JOIN {0}Variedades AS V ON T.IdProducto = V.IdProducto AND T.IdVariedad = V.Id " & _
                    " LEFT JOIN {0}Envases AS E ON T.IdEnvase = E.Id " & _
                    " LEFT JOIN {0}Tamanos AS T2 ON T.IdProducto = T2.IdProducto AND T.IdTamano = T2.Id " & _
                    " LEFT JOIN {0}Etiquetas AS E2 ON T.IdEtiqueta = E2.Id " & _
                    " WHERE T.IdTipoEmbarque=@idTipoEmbarque AND T.IdEmbarque=@idEmbarque " & _
                    " GROUP BY P.Nombre, P.Abreviatura, V.Nombre, V.Abreviatura, E.Nombre, E.Abreviatura, T2.Nombre, T2.Abreviatura, E2.Nombre, E2.Abreviatura", bdCatalogos)
            comando.Parameters.AddWithValue("@idTipoEmbarque", Me.EIdTipo)
            comando.Parameters.AddWithValue("@idEmbarque", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

End Class
