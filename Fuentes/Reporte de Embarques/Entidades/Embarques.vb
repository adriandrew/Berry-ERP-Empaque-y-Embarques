Imports System.Data.SqlClient

Public Class Embarques

    Private idEmbarcador As Integer
    Private idProducto As Integer
    Private idVariedad As Integer
    Private idEnvase As Integer
    Private idTamano As Integer
    Private idEtiqueta As Integer
    Private fecha As Date
    Private fecha2 As Date

    Public Property EIdEmbarcador() As Integer
        Get
            Return Me.idEmbarcador
        End Get
        Set(value As Integer)
            Me.idEmbarcador = value
        End Set
    End Property
    Public Property EIdProducto() As Integer
        Get
            Return Me.idProducto
        End Get
        Set(value As Integer)
            Me.idProducto = value
        End Set
    End Property
    Public Property EIdVariedad() As Integer
        Get
            Return Me.idVariedad
        End Get
        Set(value As Integer)
            Me.idVariedad = value
        End Set
    End Property
    Public Property EIdEnvase() As Integer
        Get
            Return Me.idEnvase
        End Get
        Set(value As Integer)
            Me.idEnvase = value
        End Set
    End Property
    Public Property EIdTamano() As Integer
        Get
            Return Me.idTamano
        End Get
        Set(value As Integer)
            Me.idTamano = value
        End Set
    End Property
    Public Property EIdEtiqueta() As Integer
        Get
            Return Me.idEtiqueta
        End Get
        Set(value As Integer)
            Me.idEtiqueta = value
        End Set
    End Property
    Public Property EFecha() As String
        Get
            Return Me.fecha
        End Get
        Set(value As String)
            Me.fecha = value
        End Set
    End Property
    Public Property EFecha2() As String
        Get
            Return Me.fecha2
        End Get
        Set(value As String)
            Me.fecha2 = value
        End Set
    End Property

    Public Function ObtenerListadoReporteEmbarques(ByVal aplicaFecha As Boolean) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            Dim condicionFechaRango As String = String.Empty
            Dim condicionTipoExportacion As String = String.Empty
            Dim condicionTipoNacional As String = String.Empty
            If (Me.EIdEmbarcador > 0) Then
                condicion &= " AND E.IdEmbarcador=@idEmbarcador "
            End If
            If (aplicaFecha) Then
                condicionFechaRango &= " AND Fecha BETWEEN @fecha AND @fecha2 "
            End If
            comando.CommandText = String.Format("SELECT E.Id, E.Fecha, CONVERT(VARCHAR(5), E.Hora, 108), CASE WHEN E.IdTipo=1 THEN 'Exportación' WHEN E.IdTipo=2 THEN 'Nacional' ELSE '' END, E.IdEmbarcador, E2.Nombre, E.IdCliente, C.Nombre, E.IdLineaTransporte, LT.Nombre, E.IdTrailer, T.Serie, E.IdCajaTrailer, CT.Serie, E.IdChofer, C2.Nombre, E.IdAduanaMex, AM.Nombre, E.IdAduanaUsa, AU.Nombre, E.IdDocumentador, D.Nombre, E.Temperatura, E.Termografo, E.PrecioFlete, E.Sello1, E.Sello2, E.Sello3, E.Sello4, E.Sello5, E.Sello6, E.Sello7, E.Sello8, E.Factura, E.GuiaCaades, E.Observaciones " & _
            " FROM Embarques AS E " & _
            " LEFT JOIN {0}Productores AS P ON E.IdProductor = P.Id " & _
            " LEFT JOIN {0}Productores AS E2 ON E.IdEmbarcador = E2.Id " & _
            " LEFT JOIN {0}Clientes AS C ON E.IdCliente = C.Id " & _
            " LEFT JOIN {0}LineasTransportes AS LT ON E.IdLineaTransporte = LT.Id " & _
            " LEFT JOIN {0}Trailers AS T ON E.IdLineaTransporte = T.IdLineaTransporte AND E.IdTrailer = T.Id " & _
            " LEFT JOIN {0}CajasTrailers AS CT ON E.IdCajaTrailer = CT.Id " & _
            " LEFT JOIN {0}Choferes AS C2 ON E.IdChofer = C2.Id " & _
            " LEFT JOIN {0}AduanasMex AS AM ON E.IdAduanaMex = AM.Id " & _
            " LEFT JOIN {0}AduanasUsa AS AU ON E.IdAduanaUsa = AU.Id " & _
            " LEFT JOIN {0}Documentadores AS D ON E.IdDocumentador = D.Id " & _
            " WHERE 0=0 {1}" & _
            " ", EYELogicaReporteEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmbarques.Programas.prefijoBaseDatosEmpaque, condicion & condicionFechaRango)
            comando.Parameters.AddWithValue("@idEmbarcador", Me.EIdEmbarcador)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteEmbarques.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteEmbarques.Funciones.ValidarFechaAEstandar(Me.EFecha2))
            BaseDatos.conexionEmpaque.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerListadoReporteEmbarquesDetallado(ByVal aplicaFecha As Boolean) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            Dim condicionFechaRango As String = String.Empty
            Dim condicionTipoExportacion As String = String.Empty
            Dim condicionTipoNacional As String = String.Empty
            If (Me.EIdEmbarcador > 0) Then
                condicion &= " AND E.IdEmbarcador=@idEmbarcador "
            End If
            If (Me.EIdProducto > 0) Then
                condicion &= " AND T.IdProducto=@idProducto "
            End If
            If (Me.EIdVariedad > 0) Then
                condicion &= " AND T.IdVariedad=@idVariedad "
            End If
            If (Me.EIdEnvase > 0) Then
                condicion &= " AND T.IdEnvase=@idEnvase "
            End If
            If (Me.EIdTamano > 0) Then
                condicion &= " AND T.IdTamano=@idTamano "
            End If
            If (Me.EIdEtiqueta > 0) Then
                condicion &= " AND T.IdEtiqueta=@idEtiqueta "
            End If
            If (aplicaFecha) Then
                condicionFechaRango &= " AND Fecha BETWEEN @fecha AND @fecha2 "
            End If
            comando.CommandText = String.Format("SELECT E.Id, E.Fecha, CONVERT(VARCHAR(5), E.Hora, 108), CASE WHEN E.IdTipo=1 THEN 'Exportación' WHEN E.IdTipo=2 THEN 'Nacional' ELSE '' END, E.IdEmbarcador, E2.Nombre, T.IdProducto, P2.Nombre, T.IdVariedad, V.Nombre, T.IdEnvase, E3.Nombre, T.IdTamano, T2.Nombre, T.IdEtiqueta, E4.Nombre, T.CantidadCajas, T.PesoCajas " & _
            " FROM Embarques AS E " & _
            " LEFT JOIN (SELECT IdEmbarque, IdTipoEmbarque, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta, ISNULL(SUM(CantidadCajas), 0) AS CantidadCajas, ISNULL(SUM(PesoTotalCajas), 0) AS PesoCajas FROM Tarimas GROUP BY IdEmbarque, IdTipoEmbarque, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta) AS T ON E.Id = T.IdEmbarque AND E.IdTipo = T.IdTipoEmbarque " & _
            " LEFT JOIN {0}Productores AS E2 ON E.IdEmbarcador = E2.Id " & _
            " LEFT JOIN {0}Productos AS P2 ON T.IdProducto = P2.Id " & _
            " LEFT JOIN {0}Variedades AS V ON T.IdProducto = V.IdProducto AND T.IdVariedad = V.Id " & _
            " LEFT JOIN {0}Envases AS E3 ON T.IdEnvase = E3.Id " & _
            " LEFT JOIN {0}Tamanos AS T2 ON T.IdProducto = T2.IdProducto AND T.IdTamano = T2.Id " & _
            " LEFT JOIN {0}Etiquetas AS E4 ON T.IdEtiqueta = E4.Id " & _
            " WHERE 0=0 {1}" & _
            " ", EYELogicaReporteEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmbarques.Programas.prefijoBaseDatosEmpaque, condicion & condicionFechaRango)
            comando.Parameters.AddWithValue("@idEmbarcador", Me.EIdEmbarcador)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idVariedad", Me.EIdVariedad)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@idTamano", Me.EIdTamano)
            comando.Parameters.AddWithValue("@idEtiqueta", Me.EIdEtiqueta)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteEmbarques.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteEmbarques.Funciones.ValidarFechaAEstandar(Me.EFecha2))
            BaseDatos.conexionEmpaque.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

End Class
