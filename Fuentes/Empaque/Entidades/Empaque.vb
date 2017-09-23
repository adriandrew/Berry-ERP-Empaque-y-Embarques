Imports System.Data.SqlClient

Public Class Empaque

    Private id As Integer
    Private idProductor As Integer
    Private idEmbarcador As Integer
    Private idCliente As Integer
    Private idLote As Integer
    Private idProducto As Integer
    Private idVariedad As Integer
    Private idEnvase As Integer
    Private idTamano As Integer
    Private idEtiqueta As Integer
    Private fecha As Date
    Private hora As String
    Private cantidadCajas As Integer
    Private pesoUnitarioCajas As Double
    Private pesoTotalCajas As Double
    Private temperatura As Double
    Private observaciones As String
    Private esPropio As Boolean
    Private esSobrante As Boolean
    Private esTrazable As Boolean
    Private orden As Integer
    Private estaEmbarcado As Boolean
    Private idEmbarque As Integer
    Private idTipoEmbarque As Integer
    Private ordenEmbarque As Integer

    Public Property EId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
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
    Public Property EIdLote() As Integer
        Get
            Return idLote
        End Get
        Set(value As Integer)
            idLote = value
        End Set
    End Property
    Public Property EIdProducto() As Integer
        Get
            Return idProducto
        End Get
        Set(value As Integer)
            idProducto = value
        End Set
    End Property
    Public Property EIdVariedad() As Integer
        Get
            Return idVariedad
        End Get
        Set(value As Integer)
            idVariedad = value
        End Set
    End Property
    Public Property EIdEnvase() As Integer
        Get
            Return idEnvase
        End Get
        Set(value As Integer)
            idEnvase = value
        End Set
    End Property
    Public Property EIdTamano() As Integer
        Get
            Return idTamano
        End Get
        Set(value As Integer)
            idTamano = value
        End Set
    End Property
    Public Property EIdEtiqueta() As Integer
        Get
            Return idEtiqueta
        End Get
        Set(value As Integer)
            idEtiqueta = value
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
    Public Property ECantidadCajas() As Integer
        Get
            Return cantidadCajas
        End Get
        Set(value As Integer)
            cantidadCajas = value
        End Set
    End Property
    Public Property EPesoUnitarioCajas() As Double
        Get
            Return pesoUnitarioCajas
        End Get
        Set(value As Double)
            pesoUnitarioCajas = value
        End Set
    End Property
    Public Property EPesoTotalCajas() As Double
        Get
            Return pesoTotalCajas
        End Get
        Set(value As Double)
            pesoTotalCajas = value
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
    Public Property EObservaciones() As String
        Get
            Return observaciones
        End Get
        Set(value As String)
            observaciones = value
        End Set
    End Property
    Public Property EEsPropio() As Boolean
        Get
            Return esPropio
        End Get
        Set(value As Boolean)
            esPropio = value
        End Set
    End Property
    Public Property EEsSobrante() As Boolean
        Get
            Return esSobrante
        End Get
        Set(value As Boolean)
            esSobrante = value
        End Set
    End Property
    Public Property EEsTrazable() As Boolean
        Get
            Return esTrazable
        End Get
        Set(value As Boolean)
            esTrazable = value
        End Set
    End Property
    Public Property EOrden() As Integer
        Get
            Return orden
        End Get
        Set(value As Integer)
            orden = value
        End Set
    End Property
    Public Property EEstaEmbarcado() As Boolean
        Get
            Return estaEmbarcado
        End Get
        Set(value As Boolean)
            estaEmbarcado = value
        End Set
    End Property
    Public Property EIdEmbarque() As Integer
        Get
            Return idEmbarque
        End Get
        Set(value As Integer)
            idEmbarque = value
        End Set
    End Property
    Public Property EIdTipoEmbarque() As Integer
        Get
            Return idTipoEmbarque
        End Get
        Set(value As Integer)
            idTipoEmbarque = value
        End Set
    End Property
    Public Property EOrdenEmbarque() As Integer
        Get
            Return ordenEmbarque
        End Get
        Set(value As Integer)
            ordenEmbarque = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("INSERT INTO Tarimas (Id, IdProductor, IdEmbarcador, IdCliente, IdLote, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta, Fecha, Hora, CantidadCajas, PesoUnitarioCajas, PesoTotalCajas, Temperatura, Observaciones, EsPropio, EsSobrante, EsTrazable, Orden, EstaEmbarcado, IdEmbarque, IdTipoEmbarque, OrdenEmbarque) VALUES (@id, @idProductor, @idEmbarcador, @idCliente, @idLote, @idProducto, @idVariedad, @idEnvase, @idTamano, @idEtiqueta, @fecha, @hora, @cantidadCajas, @pesoUnitarioCajas, @pesoTotalCajas, @temperatura, @observaciones, @esPropio, @esSobrante, @esTrazable, @orden, @estaEmbarcado, @idEmbarque, @idTipoEmbarque, @ordenEmbarque)")
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@idEmbarcador", Me.EIdEmbarcador)
            comando.Parameters.AddWithValue("@idCliente", Me.EIdCliente)
            comando.Parameters.AddWithValue("@idLote", Me.EIdLote)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idVariedad", Me.EIdVariedad)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@idTamano", Me.EIdTamano)
            comando.Parameters.AddWithValue("@idEtiqueta", Me.EIdEtiqueta)
            comando.Parameters.AddWithValue("@fecha", Me.EFecha)
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            comando.Parameters.AddWithValue("@cantidadCajas", Me.ECantidadCajas)
            comando.Parameters.AddWithValue("@pesoUnitarioCajas", Me.EPesoUnitarioCajas)
            comando.Parameters.AddWithValue("@pesoTotalCajas", Me.EPesoTotalCajas)
            comando.Parameters.AddWithValue("@temperatura", Me.ETemperatura)
            comando.Parameters.AddWithValue("@observaciones", Me.EObservaciones)
            comando.Parameters.AddWithValue("@esPropio", Me.EEsPropio)
            comando.Parameters.AddWithValue("@esSobrante", Me.EEsSobrante)
            comando.Parameters.AddWithValue("@esTrazable", Me.EEsTrazable)
            comando.Parameters.AddWithValue("@orden", Me.EOrden)
            comando.Parameters.AddWithValue("@estaEmbarcado", Me.EEstaEmbarcado)
            comando.Parameters.AddWithValue("@idEmbarque", Me.EIdEmbarque)
            comando.Parameters.AddWithValue("@idTipoEmbarque", Me.EIdTipoEmbarque)
            comando.Parameters.AddWithValue("@ordenEmbarque", Me.EOrdenEmbarque)
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
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = String.Format("DELETE FROM Tarimas WHERE 0=0 {0}", condicion)
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
            comando.CommandText = String.Format("SELECT MAX(CAST (Id AS Int)) AS IdMaximo FROM Tarimas")
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim valor As Integer = 0
            While lectorDatos.Read()
                valor = EYELogicaEmpaque.Funciones.ValidarNumeroACero(lectorDatos("IdMaximo").ToString()) + 1
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
            If (Me.EId > 0) Then
                condicion &= " AND T.Id=@id"
            End If
            comando.CommandText = String.Format("SELECT T.IdLote, L.Nombre, T.IdProducto, P.Nombre, T.IdVariedad, V.Nombre, T.IdEnvase, E.Nombre, T.IdTamano, TA.Nombre, T.IdEtiqueta, ET.Nombre, T.CantidadCajas, T.PesoUnitarioCajas, T.PesoTotalCajas " & _
            " FROM Tarimas AS T " & _
            " LEFT JOIN {0}Lotes AS L ON T.IdLote = L.Id " & _
            " LEFT JOIN {0}Productos AS P ON T.IdProducto = P.Id " & _
            " LEFT JOIN {0}Variedades AS V ON T.IdProducto = V.IdProducto AND T.IdVariedad = V.Id " & _
            " LEFT JOIN {0}Envases AS E ON T.IdEnvase = E.Id " & _
            " LEFT JOIN {0}Tamanos AS TA ON T.IdProducto = TA.IdProducto AND T.IdTamano = TA.Id " & _
            " LEFT JOIN {0}Etiquetas AS ET ON T.IdEtiqueta = ET.Id " & _
            " WHERE 0=0 {1} ORDER BY T.Orden ASC", EYELogicaEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaEmpaque.Programas.prefijoBaseDatosEmpaque, condicion)
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

    Public Function ObtenerListadoReporteImpresionTarimas() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND T.Id=@id"
            End If
            comando.CommandText = String.Format("SELECT T.Id, T.IdProductor, P.Nombre AS NombreProductor, T.IdEmbarcador, E.Nombre AS NombreEmbarcador, T.IdLote, L.Nombre AS NombreLote, T.IdProducto, PR.Nombre AS NombreProducto, T.IdVariedad, V.Nombre AS NombreVariedad, T.IdEnvase, EN.Nombre AS NombreEnvase, T.IdTamano, TA.Nombre AS NombreTamano, T.IdEtiqueta, ET.Nombre AS NombreEtiqueta, T.CantidadCajas, T.PesoTotalCajas, T.Fecha, T.Hora, T.EsPropio " & _
            " FROM Tarimas AS T " & _
            " LEFT JOIN {0}Productores AS P ON T.IdProductor = P.Id " & _
            " LEFT JOIN {0}Productores AS E ON T.IdEmbarcador = E.Id " & _
            " LEFT JOIN {0}Lotes AS L ON T.IdLote = L.Id " & _
            " LEFT JOIN {0}Productos AS PR ON T.IdProducto = PR.Id " & _
            " LEFT JOIN {0}Variedades AS V ON T.IdProducto = V.IdProducto AND T.IdVariedad = V.Id " & _
            " LEFT JOIN {0}Envases AS EN ON T.IdEnvase = EN.Id " & _
            " LEFT JOIN {0}Tamanos AS TA ON T.IdProducto = TA.IdProducto AND T.IdTamano = TA.Id " & _
            " LEFT JOIN {0}Etiquetas AS ET ON T.IdEtiqueta = ET.Id " & _
            " WHERE 0=0 {1} ORDER BY T.Orden ASC", EYELogicaEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaEmpaque.Programas.prefijoBaseDatosEmpaque, condicion)
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

    Public Function ObtenerListadoReporteImpresionCajas() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND T.Id=@id"
            End If
            comando.CommandText = String.Format("SELECT T.Id AS IdTarima, C.Id, C.DiaJuliano, C.ClaveAgricola, T.IdProductor, P.Nombre AS NombreProductor, T.IdEmbarcador, E.Nombre AS NombreEmbarcador, E.Domicilio AS DomicilioEmbarcador, E.Municipio AS MunicipioEmbarcador, E.Estado AS EstadoEmbarcador, T.IdLote, L.Nombre AS NombreLote, T.IdProducto, PR.Nombre AS NombreProducto, T.IdVariedad, V.Nombre AS NombreVariedad, T.IdEnvase, EN.Nombre AS NombreEnvase, T.IdTamano, TA.Nombre AS NombreTamano, T.IdEtiqueta, ET.Nombre AS NombreEtiqueta, T.CantidadCajas, T.PesoTotalCajas, T.Fecha, T.Hora, T.EsPropio " & _
            " FROM Tarimas AS T " & _
            " LEFT JOIN Cajas AS C ON T.Id = C.IdTarima AND T.Orden = C.OrdenTarima " & _
            " LEFT JOIN {0}Productores AS P ON T.IdProductor = P.Id " & _
            " LEFT JOIN {0}Productores AS E ON T.IdEmbarcador = E.Id " & _
            " LEFT JOIN {0}Lotes AS L ON T.IdLote = L.Id " & _
            " LEFT JOIN {0}Productos AS PR ON T.IdProducto = PR.Id " & _
            " LEFT JOIN {0}Variedades AS V ON T.IdProducto = V.IdProducto AND T.IdVariedad = V.Id " & _
            " LEFT JOIN {0}Envases AS EN ON T.IdEnvase = EN.Id " & _
            " LEFT JOIN {0}Tamanos AS TA ON T.IdProducto = TA.IdProducto AND T.IdTamano = TA.Id " & _
            " LEFT JOIN {0}Etiquetas AS ET ON T.IdEtiqueta = ET.Id " & _
            " WHERE 0=0 {1} ORDER BY T.Orden ASC", EYELogicaEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaEmpaque.Programas.prefijoBaseDatosEmpaque, condicion)
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

    Public Function ObtenerListado() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = String.Format("SELECT Id, Fecha, Hora, IdProductor, EsPropio, EsSobrante, EstaEmbarcado FROM Tarimas WHERE 0=0 {0} ORDER BY Orden ASC", condicion)
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

    Public Function ObtenerMinimaFecha() As Date

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("SELECT MIN(Fecha) AS FechaMinima FROM Tarimas")
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

    Public Function ObtenerParaValidar() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("SELECT Id, EstaEmbarcado, IdEmbarque, IdTipoEmbarque, OrdenEmbarque " & _
            " FROM Tarimas " & _
            " WHERE Id=@id " & _
            " GROUP BY Id, EstaEmbarcado, IdEmbarque, IdTipoEmbarque, OrdenEmbarque")
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

End Class
