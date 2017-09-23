Imports System.Data.SqlClient

Public Class Precios

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

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("INSERT INTO ConfiguracionPrecios (IdProducto, IdEnvase, IdTamano, IdEtiqueta, Precio) VALUES (@idProducto, @idEnvase, @idTamano, @idEtiqueta, @precio)")
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@idTamano", Me.EIdTamano)
            comando.Parameters.AddWithValue("@idEtiqueta", Me.EIdEtiqueta)
            comando.Parameters.AddWithValue("@precio", Me.EPrecio)
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
            Dim condicion As String = String.Empty
            If (Me.EIdProducto > 0) Then
                condicion &= " AND IdProducto=@idProducto"
            End If
            If (Me.EIdEnvase > 0) Then
                condicion &= " AND IdEnvase=@idEnvase"
            End If
            If (Me.EIdTamano > 0) Then
                condicion &= " AND IdTamano=@idTamano"
            End If
            If (Me.EIdEtiqueta > 0) Then
                condicion &= " AND IdEtiqueta=@idEtiqueta"
            End If
            comando.CommandText = String.Format("DELETE FROM ConfiguracionPrecios WHERE 0=0 {0}", condicion)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@idTamano", Me.EIdTamano)
            comando.Parameters.AddWithValue("@idEtiqueta", Me.EIdEtiqueta)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("SELECT CP.IdProducto, P.Nombre AS NombreProducto, CP.IdEnvase, E.Nombre AS NombreEnvase, CP.IdTamano, T.Nombre AS NombreTamano, CP.IdEtiqueta, E2.Nombre AS NombreEtiqueta, CP.Precio FROM ConfiguracionPrecios AS CP " & _
            " LEFT JOIN {0}Productos AS P ON CP.IdProducto=P.Id " & _
            " LEFT JOIN {0}Envases AS E ON CP.IdEnvase=E.Id " & _
            " LEFT JOIN {0}Tamanos AS T ON CP.IdProducto=T.IdProducto AND CP.IdTamano=T.Id " & _
            " LEFT JOIN {0}Etiquetas AS E2 ON CP.IdEtiqueta=E2.Id " & _
            " ORDER BY CP.IdProducto, CP.IdEnvase, CP.IdTamano, CP.IdEtiqueta ASC", EYELogicaConfiguraciones.Programas.bdCatalogo & ".dbo." & EYELogicaConfiguraciones.Programas.prefijoBaseDatosEmpaque)
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
