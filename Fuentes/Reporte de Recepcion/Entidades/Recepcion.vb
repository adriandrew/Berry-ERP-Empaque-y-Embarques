﻿Imports System.Data.SqlClient

Public Class Recepcion

    Private idProductor As Integer
    Private idLote As Integer
    Private idChofer As Integer
    Private idProducto As Integer
    Private idVariedad As Integer
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
    Public Property EIdLote() As Integer
        Get
            Return Me.idLote
        End Get
        Set(value As Integer)
            Me.idLote = value
        End Set
    End Property
    Public Property EIdChofer() As Integer
        Get
            Return Me.idChofer
        End Get
        Set(value As Integer)
            Me.idChofer = value
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
                condicion &= " AND R.IdProductor=@idProductor "
            End If
            If (Me.EIdLote > 0) Then
                condicion &= " AND R.IdLote=@idLote "
            End If
            If (Me.EIdChofer > 0) Then
                condicion &= " AND R.IdChofer=@idChofer "
            End If
            If (Me.EIdProducto > 0) Then
                condicion &= " AND R.IdProducto=@idProducto "
            End If
            If (Me.EIdVariedad > 0) Then
                condicion &= " AND R.IdVariedad=@idVariedad "
            End If
            If (aplicaFecha) Then
                condicionFechaRango &= " AND Fecha BETWEEN @fecha AND @fecha2 " 
            End If
            comando.CommandText = String.Format("SELECT R.Id, R.Fecha, CONVERT(VARCHAR(5), R.Hora, 108), R.IdProductor, PR.Nombre, R.IdLote, L.Nombre, R.IdChofer, CC.Nombre, R.IdProducto, P.Nombre, R.IdVariedad, V.Nombre, SUM(ISNULL(R.CantidadCajas, 0)), SUM(ISNULL(R.PesoCajas, 0)) " & _
            " FROM Recepcion AS R " & _
            " LEFT JOIN {0}Productores AS PR ON R.IdProductor = PR.Id " & _
            " LEFT JOIN {0}Lotes AS L ON R.IdLote = L.Id " & _
            " LEFT JOIN {0}ChoferesCampos AS CC ON R.IdChofer = CC.Id " & _
            " LEFT JOIN {0}Productos AS P ON R.IdProducto = P.Id " & _
            " LEFT JOIN {0}Variedades AS V ON R.IdVariedad = V.Id AND R.IdProducto = V.IdProducto " & _
            " WHERE 0=0 {1}" & _
            " GROUP BY R.Id, R.Fecha, R.Hora, R.IdProductor, PR.Nombre, R.IdLote, L.Nombre, R.IdChofer, CC.Nombre, R.IdProducto, P.Nombre, R.IdVariedad, V.Nombre", EYELogicaReporteRecepcion.Programas.bdCatalogo & ".dbo." & EYELogicaReporteRecepcion.Programas.prefijoBaseDatosEmpaque, condicion & condicionFechaRango)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@idLote", Me.EIdLote)
            comando.Parameters.AddWithValue("@idChofer", Me.EIdChofer)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idVariedad", Me.EIdVariedad)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteRecepcion.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteRecepcion.Funciones.ValidarFechaAEstandar(Me.EFecha2))
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
