﻿Imports System.Data.SqlClient

Public Class Lotes

    Private id As Integer
    Private nombre As String
    Private hectareas As Double
    Private pesoCaja As Double

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
    Public Property EHectareas() As Double
        Get
            Return hectareas
        End Get
        Set(value As Double)
            hectareas = value
        End Set
    End Property
    Public Property EPesoCaja() As Double
        Get
            Return pesoCaja
        End Get
        Set(value As Double)
            pesoCaja = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = String.Format("INSERT INTO {0}Lotes (Id, Nombre, Hectareas, PesoCaja) VALUES (@id, @nombre, @hectareas, @pesoCaja)", EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque)
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@hectareas", Me.EHectareas)
            comando.Parameters.AddWithValue("@pesoCaja", Me.EPesoCaja)
            BaseDatos.conexionCatalogo.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionCatalogo.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Sub

    Public Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " WHERE Id=@id"
            End If
            comando.CommandText = String.Format("DELETE FROM {0}Lotes {1}", EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque, condicion)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionCatalogo.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionCatalogo.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Sub

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = String.Format("SELECT Id, Nombre, Hectareas, PesoCaja FROM {0}Lotes ORDER BY Id ASC", EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionCatalogo.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

End Class
