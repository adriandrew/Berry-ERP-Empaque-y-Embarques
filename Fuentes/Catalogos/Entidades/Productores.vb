Imports System.Data.SqlClient

Public Class Productores
     
    Private id As Integer
    Private nombre As String
    Private domicilio As String
    Private fda As String
    Private gs1 As String
    Private ggn As String
    Private claveAgricola As String

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
    Public Property EFda() As String
        Get
            Return fda
        End Get
        Set(value As String)
            fda = value
        End Set
    End Property
    Public Property EGs1() As String
        Get
            Return gs1
        End Get
        Set(value As String)
            gs1 = value
        End Set
    End Property
    Public Property EGgn() As String
        Get
            Return ggn
        End Get
        Set(value As String)
            ggn = value
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

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "INSERT INTO " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Productores (Id, Nombre, Domicilio, Fda, Gs1, Ggn, ClaveAgricola) VALUES (@id, @nombre, @domicilio, @fda, @gs1, @ggn, @claveAgricola)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@domicilio", Me.EDomicilio)
            comando.Parameters.AddWithValue("@fda", Me.EFda)
            comando.Parameters.AddWithValue("@gs1", Me.EGs1)
            comando.Parameters.AddWithValue("@ggn", Me.EGgn)
            comando.Parameters.AddWithValue("@claveAgricola", Me.EClaveAgricola)
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
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "DELETE FROM " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Productores WHERE 0=0 " & condicion
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
            If Me.EId > 0 Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "SELECT Id, Nombre, Domicilio, Fda, Gs1, Ggn, ClaveAgricola FROM " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Productores WHERE 0=0 " & condicion & " ORDER BY Id ASC"
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
