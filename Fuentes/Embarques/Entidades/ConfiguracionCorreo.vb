Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text

Public Class ConfiguracionCorreo

    Private direccion As String
    Private contrasena As String
    Private asunto As String
    Private mensaje As String
    Private idProveedor As Integer

    Public Property EDireccion() As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property
    Public Property EContrasena() As String
        Get
            Return contrasena
        End Get
        Set(value As String)
            contrasena = value
        End Set
    End Property
    Public Property EAsunto() As String
        Get
            Return asunto
        End Get
        Set(value As String)
            asunto = value
        End Set
    End Property
    Public Property EMensaje() As String
        Get
            Return mensaje
        End Get
        Set(value As String)
            mensaje = value
        End Set
    End Property
    Public Property EIdProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(value As Integer)
            idProveedor = value
        End Set
    End Property

    Public Function ObtenerListado() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("SELECT * FROM ConfiguracionCorreo")
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

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("INSERT INTO ConfiguracionCorreo (Direccion, Contrasena, Asunto, Mensaje, IdProveedor) VALUES (@direccion, @contrasena, @asunto, @mensaje, @idProveedor)")
            comando.Parameters.AddWithValue("@direccion", Me.EDireccion)
            comando.Parameters.AddWithValue("@contrasena", Me.EContrasena)
            comando.Parameters.AddWithValue("@asunto", Me.EAsunto)
            comando.Parameters.AddWithValue("@mensaje", Me.EMensaje)
            comando.Parameters.AddWithValue("@idProveedor", Me.EIdProveedor)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

    Public Sub Editar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("UPDATE ConfiguracionCorreo SET Direccion=@direccion, Contrasena=@contrasena, Asunto=@asunto, Mensaje=@mensaje, IdProveedor=@idProveedor")
            comando.Parameters.AddWithValue("@direccion", Me.EDireccion)
            comando.Parameters.AddWithValue("@contrasena", Me.EContrasena)
            comando.Parameters.AddWithValue("@asunto", Me.EAsunto)
            comando.Parameters.AddWithValue("@mensaje", Me.EMensaje)
            comando.Parameters.AddWithValue("@idProveedor", Me.EIdProveedor)
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
            comando.CommandText = String.Format("DELETE FROM ConfiguracionCorreo")
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

End Class
