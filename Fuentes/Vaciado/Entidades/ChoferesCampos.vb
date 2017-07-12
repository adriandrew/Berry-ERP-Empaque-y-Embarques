﻿Imports System.Data.SqlClient

Public Class ChoferesCampos

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
            comando.CommandText = "SELECT Id, Nombre FROM " & LogicaVaciado.Programas.prefijoBaseDatosEmpaque & "ChoferesCampos " & _
            " UNION SELECT -1 AS Id, NULL AS Nombre FROM " & LogicaVaciado.Programas.prefijoBaseDatosEmpaque & "ChoferesCampos " & _
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

    Public Function ObtenerListado() As List(Of ChoferesCampos)

        Try
            Dim lista As New List(Of ChoferesCampos)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "SELECT Id, Nombre FROM " & LogicaVaciado.Programas.prefijoBaseDatosEmpaque & "ChoferesCampos WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionCatalogo.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim choferesCampos As ChoferesCampos
            While lectorDatos.Read()
                choferesCampos = New ChoferesCampos()
                choferesCampos.id = Convert.ToInt32(lectorDatos("Id").ToString())
                choferesCampos.nombre = lectorDatos("Nombre").ToString()
                lista.Add(choferesCampos)
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