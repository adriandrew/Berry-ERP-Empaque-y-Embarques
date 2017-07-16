Imports System.Data.SqlClient

Public Class Variedades

    Private idProducto As Integer
    Private id As Integer
    Private nombre As String
    Private abreviatura As String

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
    Public Property EAbreviatura() As String
        Get
            Return abreviatura
        End Get
        Set(value As String)
            abreviatura = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "INSERT INTO " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Variedades (IdProducto, Id, Nombre, Abreviatura) VALUES (@idProducto, @id, @nombre, @abreviatura)"
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@abreviatura", Me.EAbreviatura)
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
            If (Me.EIdProducto > 0) Then
                condicion &= " AND IdProducto=@idProducto"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "DELETE FROM " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Variedades WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
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
            Dim condicion As String = String.Empty
            If (Me.EIdProducto > 0) Then
                condicion &= " AND V.IdProducto=@idProducto"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND V.Id=@id"
            End If
            comando.CommandText = "SELECT V.IdProducto, P.Nombre, V.Id, V.Nombre, V.Abreviatura FROM " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Variedades AS V LEFT JOIN " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Productos AS P ON V.IdProducto = P.Id WHERE 0=0 " & condicion & " ORDER BY V.IdProducto, V.Id ASC"
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
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
