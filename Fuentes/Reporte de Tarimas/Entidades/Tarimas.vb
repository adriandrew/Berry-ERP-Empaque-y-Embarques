Imports System.Data.SqlClient

Public Class Tarimas

    Private idProductor As Integer
    Private fecha As Date
    Private fecha2 As Date

    Public Property EIdProductor() As Integer
        Get
            Return Me.idProductor
        End Get
        Set(value As Integer)
            Me.idProductor = value
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

    Public Function ObtenerListadoReporte(ByVal aplicaFecha As Boolean) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            Dim condicionFechaRango As String = String.Empty
            If (Me.EIdProductor > 0) Then
                condicion &= " AND T.IdProductor=@idProductor "
            End If
            If (aplicaFecha) Then
                condicionFechaRango &= " AND T.Fecha BETWEEN @fecha AND @fecha2 "
            End If
            comando.CommandText = String.Format("SELECT T.Id, T.Fecha, CONVERT(VARCHAR(5), T.Hora, 108), CASE WHEN T.EstaEmbarcado='TRUE' THEN 'Embarcado' ELSE 'En Piso' END, CASE WHEN T.IdTipoEmbarque=1 THEN 'Exportación' WHEN T.IdTipoEmbarque=2 THEN 'Nacional' ELSE '' END, T.IdProductor, P.Nombre, T.IdLote, L.Nombre, T.IdProducto, P2.Nombre, T.IdVariedad, V.Nombre, T.IdEnvase, E3.Nombre, T.IdTamano, T2.Nombre, T.IdEtiqueta, E4.Nombre, ISNULL(SUM(T.CantidadCajas), 0), ISNULL(SUM(T.PesoTotalCajas), 0), CASE WHEN T.IdEmbarque=0 THEN NULL ELSE T.IdEmbarque END, E.Fecha, CONVERT(VARCHAR(5), E.Hora, 108), CASE WHEN T.IdEmbarcador=0 THEN NULL ELSE T.IdEmbarcador END, E2.Nombre, CASE WHEN T.IdCliente=0 THEN NULL ELSE T.IdCliente END, C.Nombre " & _
            " FROM Tarimas AS T " & _
            " LEFT JOIN Embarques AS E ON E.IdTipo = T.IdTipoEmbarque AND E.Id = T.IdEmbarque " & _
            " LEFT JOIN {0}Productores AS P ON T.IdProductor = P.Id " & _
            " LEFT JOIN {0}Productores AS E2 ON T.IdEmbarcador = E2.Id " & _
            " LEFT JOIN {0}Clientes AS C ON T.IdCliente = C.Id " & _
            " LEFT JOIN {0}Lotes AS L ON T.IdLote = L.Id " & _
            " LEFT JOIN {0}Productos AS P2 ON T.IdProducto = P2.Id " & _
            " LEFT JOIN {0}Variedades AS V ON T.IdProducto = V.IdProducto AND T.IdVariedad = V.Id " & _
            " LEFT JOIN {0}Envases AS E3 ON T.IdEnvase = E3.Id " & _
            " LEFT JOIN {0}Tamanos AS T2 ON T.IdProducto = T2.IdProducto AND T.IdTamano = T2.Id " & _
            " LEFT JOIN {0}Etiquetas AS E4 ON T.IdEtiqueta = E4.Id " & _
            " WHERE 0=0 {1}" & _
            " GROUP BY T.Id, T.Fecha, T.Hora, T.EstaEmbarcado, T.IdTipoEmbarque, T.IdProductor, P.Nombre, T.IdLote, L.Nombre, T.IdProducto, P2.Nombre, T.IdVariedad, V.Nombre, T.IdEnvase, E3.Nombre, T.IdTamano, T2.Nombre, T.IdEtiqueta, E4.Nombre, T.IdEmbarcador, E2.Nombre, T.IdCliente, C.Nombre, T.IdEmbarque, E.Fecha, E.Hora", EYELogicaReporteTarimas.Programas.bdCatalogo & ".dbo." & EYELogicaReporteTarimas.Programas.prefijoBaseDatosEmpaque, condicion & condicionFechaRango)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteTarimas.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteTarimas.Funciones.ValidarFechaAEstandar(Me.EFecha2))
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
