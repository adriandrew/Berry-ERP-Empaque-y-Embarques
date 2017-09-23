Imports System.Data.SqlClient

Public Class FormatosEtiquetas

    Private idTipo As Integer
    Private id As Integer
    Private nombre As String
    Private predeterminado As Boolean

    Public Property EIdTipo() As Integer
        Get
            Return idTipo
        End Get
        Set(value As Integer)
            idTipo = value
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
    Public Property EPredeterminado() As Boolean
        Get
            Return predeterminado
        End Get
        Set(value As Boolean)
            predeterminado = value
        End Set
    End Property

    Public Sub EditarPredeterminado()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty : Dim condicionTipo As String = String.Empty
            If (Me.EIdTipo > 0) Then
                condicion &= " AND IdTipo=@idTipo "
                condicionTipo &= " AND IdTipo=@idTipo "
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id "
            End If
            comando.CommandText = String.Format("UPDATE FormatosEtiquetas SET Predeterminado='FALSE' WHERE 0=0 {0}", condicionTipo)
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
            comando.CommandText = String.Format("UPDATE FormatosEtiquetas SET Predeterminado='TRUE' WHERE 0=0 {0}", condicion)
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
            Dim condicion As String = String.Empty
            If (Me.EIdTipo > 0) Then
                condicion &= " AND IdTipo=@idTipo"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = String.Format("SELECT Id, Nombre FROM FormatosEtiquetas WHERE 0=0 {0} ORDER BY Id ASC", condicion)
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerListado() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EIdTipo > 0) Then
                condicion &= " AND IdTipo=@idTipo"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = String.Format("SELECT IdTipo, Id, Nombre, Predeterminado FROM FormatosEtiquetas WHERE 0=0 {0}", condicion)
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

End Class
