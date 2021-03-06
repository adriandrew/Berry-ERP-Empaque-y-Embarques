﻿Imports System.Data.SqlClient

Public Class CajasTrailers
     
    Private id As Integer
    Private marca As String
    Private serie As String
    Private numeroEconomico As String
    Private placasMex As String
    Private placasUsa As String
    Private longitud As Double

    Public Property EId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property EMarca() As String
        Get
            Return marca
        End Get
        Set(value As String)
            marca = value
        End Set
    End Property
    Public Property ESerie() As String
        Get
            Return serie
        End Get
        Set(value As String)
            serie = value
        End Set
    End Property
    Public Property ENumeroEconomico() As String
        Get
            Return numeroEconomico
        End Get
        Set(value As String)
            numeroEconomico = value
        End Set
    End Property
    Public Property EPlacasMex() As String
        Get
            Return placasMex
        End Get
        Set(value As String)
            placasMex = value
        End Set
    End Property
    Public Property EPlacasUsa() As String
        Get
            Return placasUsa
        End Get
        Set(value As String)
            placasUsa = value
        End Set
    End Property
    Public Property ELongitud() As Double
        Get
            Return longitud
        End Get
        Set(value As Double)
            longitud = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = String.Format("INSERT INTO {0}CajasTrailers (Id, Marca, Serie, NumeroEconomico, PlacasMex, PlacasUsa, Longitud) VALUES (@id, @marca, @serie, @numeroEconomico, @placasMex, @placasUsa, @longitud)", EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque)
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@marca", Me.EMarca)
            comando.Parameters.AddWithValue("@serie", Me.ESerie)
            comando.Parameters.AddWithValue("@numeroEconomico", Me.ENumeroEconomico)
            comando.Parameters.AddWithValue("@placasMex", Me.EPlacasMex)
            comando.Parameters.AddWithValue("@placasUsa", Me.EPlacasUsa)
            comando.Parameters.AddWithValue("@longitud", Me.ELongitud)
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
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = String.Format("DELETE FROM {0}CajasTrailers WHERE 0=0 {1}", EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque, condicion)
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
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = String.Format("SELECT Id, Marca, Serie, NumeroEconomico, PlacasMex, PlacasUsa, Longitud FROM {0}CajasTrailers WHERE 0=0 {1} ORDER BY Id ASC", EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque, condicion)
            comando.Parameters.AddWithValue("@id", Me.EId)
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
