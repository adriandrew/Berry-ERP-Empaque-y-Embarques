﻿Imports System.Data.SqlClient

Public Class Vaciado

    Private idRecepcion As Integer
    Private fecha As Date
    Private hora As String
    Private idBanda As Integer 
    Private cantidadCajas As Integer
    Private pesoCajas As Double
    Private orden As Integer

    Public Property EIdRecepcion() As Integer
        Get
            Return idRecepcion
        End Get
        Set(value As Integer)
            idRecepcion = value
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
    Public Property EIdBanda() As Integer
        Get
            Return idBanda
        End Get
        Set(value As Integer)
            idBanda = value
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
    Public Property EPesoCajas() As Double
        Get
            Return pesoCajas
        End Get
        Set(value As Double)
            pesoCajas = value
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

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("INSERT INTO Vaciado (IdRecepcion, Fecha, Hora, IdBanda, CantidadCajas, PesoCajas, Orden) VALUES (@idRecepcion, @fecha, @hora, @idBanda, @cantidadCajas, @pesoCajas, @orden)")
            comando.Parameters.AddWithValue("@idRecepcion", Me.EIdRecepcion)
            comando.Parameters.AddWithValue("@fecha", Me.EFecha)
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            comando.Parameters.AddWithValue("@idBanda", Me.EIdBanda)
            comando.Parameters.AddWithValue("@cantidadCajas", Me.ECantidadCajas)
            comando.Parameters.AddWithValue("@pesoCajas", Me.EPesoCajas)
            comando.Parameters.AddWithValue("@orden", Me.EOrden)
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
            comando.CommandText = String.Format("DELETE FROM Vaciado WHERE Fecha=@fecha AND Hora=@hora")
            comando.Parameters.AddWithValue("@fecha", EYELogicaVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

    Public Function ObtenerListadoDetallado() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("SELECT SUM(V.PesoCajas)/SUM(V.CantidadCajas) AS PesoCajaUnitaria, R.Id, R.IdProductor, PR.Nombre AS NombreProductor, R.IdLote, L.Nombre AS NombreLote, R.IdProducto, P.Nombre AS NombreProducto, R.IdVariedad, V2.Nombre AS NombreVariedad, V.IdBanda, V.CantidadCajas, V.PesoCajas, 0 AS Saldo " & _
            " FROM Vaciado AS V " & _
            " LEFT JOIN Recepcion AS R ON V.IdRecepcion = R.Id" & _
            " LEFT JOIN {0}Productores AS PR ON R.IdProductor = PR.Id " & _
            " LEFT JOIN {0}Lotes AS L ON R.IdLote = L.Id " & _
            " LEFT JOIN {0}Productos AS P ON R.IdProducto = P.Id " & _
            " LEFT JOIN {0}Variedades AS V2 ON R.IdVariedad = V2.Id AND R.IdProducto = V2.IdProducto" & _
            " WHERE V.Fecha=@fecha AND V.Hora=@hora " & _
            " GROUP BY R.Id, R.IdProductor, PR.Nombre, R.IdLote, L.Nombre, R.IdProducto, P.Nombre, R.IdVariedad, V2.Nombre, V.IdBanda, V.CantidadCajas, V.PesoCajas, V.Orden " & _
            " ORDER BY V.Orden ASC", EYELogicaVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque)
            comando.Parameters.AddWithValue("@fecha", EYELogicaVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@hora", Me.EHora)
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
            comando.CommandText = String.Format("SELECT Fecha, Hora, ISNULL(SUM(CantidadCajas), 0) " & _
            " FROM Vaciado " & _
            " GROUP BY Fecha, Hora " & _
            " ORDER BY Fecha, Hora ASC", EYELogicaVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque) 
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

    Public Function ObtenerSaldos(ByVal soloId As Boolean) As Integer

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Not soloId) Then
                condicion &= " AND (Fecha<>@fecha OR Hora<>@hora) "
            End If
            comando.CommandText = String.Format("SELECT ISNULL(SUM(CajasRecepcion),0) - ISNULL(SUM(CajasVaciado), 0) AS DiferenciaCajas " & _
            " FROM " & _
            " ( " & _
            " SELECT ISNULL(SUM(CantidadCajas),0) AS CajasRecepcion, 0 AS CajasVaciado FROM Recepcion WHERE Id=@id {0}" & _
            " UNION " & _
            " SELECT 0 AS CajasRecepcion, ISNULL(SUM(CantidadCajas), 0) AS CajasVaciado FROM Vaciado WHERE IdRecepcion=@id {0}" & _
            " ) AS T", condicion)
            comando.Parameters.AddWithValue("@id", Me.EIdRecepcion)
            comando.Parameters.AddWithValue("@fecha", EYELogicaVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            Dim saldo As Integer = 0
            If (datos.Rows.Count > 0) Then
                saldo = datos.Rows(0).Item("DiferenciaCajas")
            End If
            BaseDatos.conexionEmpaque.Close()
            Return saldo
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

End Class
