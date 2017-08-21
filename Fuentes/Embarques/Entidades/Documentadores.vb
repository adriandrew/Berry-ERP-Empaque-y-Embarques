Imports System.Data.SqlClient

Public Class Documentadores

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
            comando.CommandText = "SELECT Id, Nombre FROM " & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Documentadores " & _
            " UNION SELECT -1 AS Id, NULL AS Nombre FROM " & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Documentadores " & _
            " ORDER BY Id ASC"
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
