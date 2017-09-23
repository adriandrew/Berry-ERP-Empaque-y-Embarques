Imports System.Data.SqlClient

Public Class ProveedoresCorreo

    Private id As Integer
    Private nombre As String
    Private servidor As String
    Private dominio As String
    Private puerto As String

    Public Property EId() As Integer
        Get
            Return Me.id
        End Get
        Set(value As Integer)
            Me.id = value
        End Set
    End Property
    Public Property ENombre() As String
        Get
            Return Me.nombre
        End Get
        Set(value As String)
            Me.nombre = value
        End Set
    End Property
    Public Property EServidor() As String
        Get
            Return Me.servidor
        End Get
        Set(value As String)
            Me.servidor = value
        End Set
    End Property
    Public Property EDominio() As String
        Get
            Return Me.dominio
        End Get
        Set(value As String)
            Me.dominio = value
        End Set
    End Property
    Public Property EPuerto() As String
        Get
            Return Me.puerto
        End Get
        Set(value As String)
            Me.puerto = value
        End Set
    End Property

    Public Function ObtenerListado() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = String.Format("SELECT * FROM ProveedoresCorreo WHERE 0=0 {0}", condicion)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            lectorDatos.Close()
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

End Class
