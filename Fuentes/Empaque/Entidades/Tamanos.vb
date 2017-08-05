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
                condicion &= " AND T.IdProducto=@idProducto"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND T.Id=@id"
            End If
            comando.CommandText = "SELECT T.IdProducto, P.Nombre, T.Id, T.Nombre FROM " & EYELogicaEmpaque.Programas.prefijoBaseDatosEmpaque & "Tamanos AS T " & _
            " LEFT JOIN " & EYELogicaEmpaque.Programas.prefijoBaseDatosEmpaque & "Productos AS P ON T.IdProducto = P.Id " & _
            " WHERE 0=0 " & condicion
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

    Public Function ObtenerListado() As List(Of Tamanos)

        Try
            Dim lista As New List(Of Tamanos)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            Dim condicion As String = String.Empty
            If Me.EIdProducto > 0 Then
                condicion &= " AND IdProducto=@idProducto"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "SELECT IdProducto, Id, Nombre FROM " & EYELogicaEmpaque.Programas.prefijoBaseDatosEmpaque & "Tamanos WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionCatalogo.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim tabla As Tamanos
            While lectorDatos.Read()
                tabla = New Tamanos()
                tabla.idProducto = Convert.ToInt32(lectorDatos("IdProducto").ToString())
                tabla.id = Convert.ToInt32(lectorDatos("Id").ToString())
                tabla.nombre = lectorDatos("Nombre").ToString()
                lista.Add(tabla)
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
