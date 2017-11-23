Imports System.Data.SqlClient

Public Class Tamanos

    Private idProducto As Integer
    Private id As Integer
    Private nombre As String

    Public Property EIdProducto() As Integer
        Get
            Return idProducto
        End Get
        Set(value As Integer)
            idProducto = value
        End Set
    End Property
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
            Dim condicion As String = String.Empty
            If (Me.EIdProducto > 0) Then
                condicion &= " AND IdProducto=@idProducto"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = String.Format("SELECT -1 AS Id, 'Todos' AS Nombre FROM {0}Tamanos " & _
            " UNION " & _
            " SELECT Id, Nombre FROM {0}Tamanos " & _
            " WHERE 0=0 {1}", EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque, condicion)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@id", Me.EId)
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
     
End Class
