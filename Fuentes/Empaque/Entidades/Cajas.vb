Imports System.Data.SqlClient

Public Class Cajas

    Private idTarima As Integer
    Private id As Integer
    Private diaJuliano As String
    Private claveAgricola As String
    Private orden As Integer
    Private ordenTarima As Integer

    Public Property EIdTarima() As Integer
        Get
            Return idTarima
        End Get
        Set(value As Integer)
            idTarima = value
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
    Public Property EDiaJuliano() As String
        Get
            Return diaJuliano
        End Get
        Set(value As String)
            diaJuliano = value
        End Set
    End Property
    Public Property EClaveAgricola() As String
        Get
            Return claveAgricola
        End Get
        Set(value As String)
            claveAgricola = value
        End Set
    End Property
    Public Property EOrden() As Integer
        Get
            Return orden
        End Get
        Set(value As Integer)
            orden = value
        End Set
    End Property
    Public Property EOrdenTarima() As Integer
        Get
            Return ordenTarima
        End Get
        Set(value As Integer)
            ordenTarima = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("INSERT INTO Cajas (IdTarima, Id, DiaJuliano, ClaveAgricola, Orden, OrdenTarima) VALUES (@idTarima, @id, @diaJuliano, @claveAgricola, @orden, @ordenTarima)")
            comando.Parameters.AddWithValue("@idTarima", Me.EIdTarima)
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@diaJuliano", Me.EDiaJuliano)
            comando.Parameters.AddWithValue("@claveAgricola", Me.EClaveAgricola)
            comando.Parameters.AddWithValue("@orden", Me.EOrden)
            comando.Parameters.AddWithValue("@ordenTarima", Me.EOrdenTarima)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

    Public Function ObtenerMaximoId() As Integer

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EIdTarima > 0) Then
                condicion &= "AND IdTarima=@idTarima "
            End If
            If (Not String.IsNullOrEmpty(Me.EClaveAgricola)) Then
                condicion &= " AND ClaveAgricola LIKE @claveAgricola "
            End If
            If (Not String.IsNullOrEmpty(Me.EDiaJuliano)) Then
                condicion &= " AND DiaJuliano LIKE @diaJuliano "
            End If
            comando.CommandText = String.Format("SELECT MAX(CAST (Id AS Int)) AS IdMaximo FROM Cajas WHERE 0=0 {0}", condicion)
            comando.Parameters.AddWithValue("@idTarima", Me.EIdTarima)
            comando.Parameters.AddWithValue("@claveAgricola", Me.EClaveAgricola)
            comando.Parameters.AddWithValue("@diaJuliano", Me.EDiaJuliano)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim valor As Integer = 0
            While lectorDatos.Read()
                valor = EYELogicaEmpaque.Funciones.ValidarNumeroACero(lectorDatos("IdMaximo").ToString()) + 1
            End While
            BaseDatos.conexionEmpaque.Close()
            Return valor
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EIdTarima > 0) Then
                comando.CommandText = String.Format("DELETE FROM Cajas WHERE IdTarima=@idTarima")
                comando.Parameters.AddWithValue("@idTarima", Me.EIdTarima)
                BaseDatos.conexionEmpaque.Open()
                comando.ExecuteNonQuery()
                BaseDatos.conexionEmpaque.Close()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

End Class
