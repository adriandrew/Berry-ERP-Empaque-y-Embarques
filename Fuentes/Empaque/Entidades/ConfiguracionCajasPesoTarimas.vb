Imports System.Data.SqlClient

Public Class ConfiguracionCajasPesoTarimas

    Private idProducto As Integer
    Private idEnvase As Integer
    Private cantidadCajas As Integer
    Private pesoUnitarioCajas As Double

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
    Public Property ECantidadCajas() As Integer
        Get
            Return cantidadCajas
        End Get
        Set(value As Integer)
            cantidadCajas = value
        End Set
    End Property
    Public Property EPesoUnitarioCajas() As Double
        Get
            Return pesoUnitarioCajas
        End Get
        Set(value As Double)
            pesoUnitarioCajas = value
        End Set
    End Property
     
    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque 
            comando.CommandText = String.Format("SELECT CantidadCajas, PesoUnitarioCajas FROM ConfiguracionCajasPesoTarimas WHERE IdProducto=@idProducto AND IdEnvase=@idEnvase")
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
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
