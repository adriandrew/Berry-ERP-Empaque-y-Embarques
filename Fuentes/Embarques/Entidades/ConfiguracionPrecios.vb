Imports System.Data.SqlClient

Public Class ConfiguracionPrecios

    Private idProducto As Integer
    Private idEnvase As Integer
    Private idEtiqueta As Integer
    Private idTamano As Integer
    Private precio As Double

    Public Property EIdProducto() As Integer
        Get
            Return idProducto
        End Get
        Set(value As Integer)
            idProducto = value
        End Set
    End Property
    Public Property EIdEnvase() As Integer
        Get
            Return idEnvase
        End Get
        Set(value As Integer)
            idEnvase = value
        End Set
    End Property
    Public Property EIdEtiqueta() As Integer
        Get
            Return idEtiqueta
        End Get
        Set(value As Integer)
            idEtiqueta = value
        End Set
    End Property
    Public Property EIdTamano() As Integer
        Get
            Return idTamano
        End Get
        Set(value As Integer)
            idTamano = value
        End Set
    End Property
    Public Property EPrecio() As Integer
        Get
            Return precio
        End Get
        Set(value As Integer)
            precio = value
        End Set
    End Property
     
    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("SELECT Precio FROM ConfiguracionPrecios WHERE IdProducto=@idProducto AND IdEnvase=@idEnvase AND IdTamano=@idTamano AND IdEtiqueta=@idEtiqueta")
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@idTamano", Me.EIdTamano)
            comando.Parameters.AddWithValue("@idEtiqueta", Me.EIdEtiqueta)
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
