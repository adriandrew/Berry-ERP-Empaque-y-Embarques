Imports System.Data.SqlClient

Public Class Choferes

    Private id As Integer
    Private nombre As String
    Private domicilio As String
    Private municipio As String
    Private estado As String
    Private licencia As String
    Private visa As String

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
    Public Property EDomicilio() As String
        Get
            Return domicilio
        End Get
        Set(value As String)
            domicilio = value
        End Set
    End Property
    Public Property EMunicipio() As String
        Get
            Return municipio
        End Get
        Set(value As String)
            municipio = value
        End Set
    End Property
    Public Property EEstado() As String
        Get
            Return estado
        End Get
        Set(value As String)
            estado = value
        End Set
    End Property
    Public Property ELicencia() As String
        Get
            Return licencia
        End Get
        Set(value As String)
            licencia = value
        End Set
    End Property
    Public Property EVisa() As String
        Get
            Return visa
        End Get
        Set(value As String)
            visa = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "INSERT INTO " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Choferes (Id, Nombre, Domicilio, Municipio, Estado, Licencia, Visa) VALUES (@id, @nombre, @domicilio, @municipio, @estado, @licencia, @visa)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@domicilio", Me.EDomicilio)
            comando.Parameters.AddWithValue("@municipio", Me.EMunicipio)
            comando.Parameters.AddWithValue("@estado", Me.EEstado)
            comando.Parameters.AddWithValue("@licencia", Me.ELicencia)
            comando.Parameters.AddWithValue("@visa", Me.EVisa)
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
            comando.CommandText = "DELETE FROM " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Choferes " & condicion
            comando.Parameters.AddWithValue("@id", Me.id)
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
            comando.CommandText = "SELECT Id, Nombre, Domicilio, Municipio, Estado, Licencia, Visa FROM " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Choferes ORDER BY Id ASC"
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
