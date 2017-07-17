﻿Imports System.Data.SqlClient

Public Class Lotes

    Private id As Integer
    Private nombre As String 

    Public Property EId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property ENombre() As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property 

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT Id, Nombre FROM " & EYELogicaReporteVaciado.Programas.prefijoBaseDatosEmpaque & "Lotes " & _
            " UNION SELECT -1 AS Id, 'Todos' AS Nombre FROM " & EYELogicaReporteVaciado.Programas.prefijoBaseDatosEmpaque & "Lotes " & _
            " ORDER BY Id ASC"
            BaseDatos.conexionCatalogo.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            BaseDatos.conexionCatalogo.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

    Public Function ObtenerListado() As List(Of Lotes)

        Try
            Dim lista As New List(Of Lotes)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " WHERE Id=@id"
            End If
            comando.CommandText = "SELECT * FROM " & EYELogicaReporteVaciado.Programas.prefijoBaseDatosEmpaque & "Lotes " & condicion
            comando.Parameters.AddWithValue("@id", Me.id)
            BaseDatos.conexionCatalogo.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim almacenes As Lotes
            While lectorDatos.Read()
                almacenes = New Lotes()
                almacenes.id = Convert.ToInt32(lectorDatos("Id").ToString())
                almacenes.nombre = lectorDatos("Nombre").ToString()
                lista.Add(almacenes)
            End While
            BaseDatos.conexionCatalogo.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

End Class