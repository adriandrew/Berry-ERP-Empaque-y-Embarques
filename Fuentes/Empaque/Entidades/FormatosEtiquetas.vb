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
            comando.CommandText = "UPDATE FormatosEtiquetas SET Predeterminado='FALSE' WHERE 0=0 " & condicionTipo
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
            comando.CommandText = "UPDATE FormatosEtiquetas SET Predeterminado='TRUE' WHERE 0=0 " & condicion
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
            comando.CommandText = "SELECT Id, Nombre FROM FormatosEtiquetas WHERE 0=0 " & condicion & " ORDER BY Id ASC"
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

    Public Function ObtenerListado() As List(Of FormatosEtiquetas)

        Try
            Dim lista As New List(Of FormatosEtiquetas)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EIdTipo > 0) Then
                condicion &= " AND IdTipo=@idTipo"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "SELECT IdTipo, Id, Nombre, Predeterminado FROM FormatosEtiquetas WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@idTipo", Me.EIdTipo)
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim tabla As FormatosEtiquetas
            While lectorDatos.Read()
                tabla = New FormatosEtiquetas()
                tabla.idTipo = Convert.ToInt32(lectorDatos("IdTipo").ToString())
                tabla.id = Convert.ToInt32(lectorDatos("Id").ToString())
                tabla.nombre = lectorDatos("Nombre").ToString()
                tabla.predeterminado = Convert.ToBoolean(lectorDatos("Predeterminado").ToString())
                lista.Add(tabla)
            End While
            BaseDatos.conexionEmpaque.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

End Class
