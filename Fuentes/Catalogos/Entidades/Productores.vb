Imports System.Data.SqlClient

Public Class Productores
     
    Private id As Integer
    Private nombre As String
    Private domicilio As String
    Private municipio As String
    Private estado As String
    Private rfc As String
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
    Public Property ERfc() As String
        Get
            Return rfc
        End Get
        Set(value As String)
            rfc = value
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
            comando.CommandText = String.Format("INSERT INTO {0}Productores (Id, Nombre, Domicilio, Municipio, Estado, Rfc, Fda, Gs1, Ggn, ClaveAgricola) VALUES (@id, @nombre, @domicilio, @municipio, @estado, @rfc, @fda, @gs1, @ggn, @claveAgricola)", EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque)
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@domicilio", Me.EDomicilio)
            comando.Parameters.AddWithValue("@municipio", Me.EMunicipio)
            comando.Parameters.AddWithValue("@estado", Me.EEstado)
            comando.Parameters.AddWithValue("@rfc", Me.ERfc)
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
            comando.CommandText = String.Format("DELETE FROM {0}Productores WHERE 0=0 {1}", EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque, condicion)
            comando.Parameters.AddWithValue("@id", Me.EId)
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
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = String.Format("SELECT Id, Nombre, Domicilio, Municipio, Estado, Rfc, Fda, Gs1, Ggn, ClaveAgricola FROM {0}Productores WHERE 0=0 {1} ORDER BY Id ASC", EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque, condicion)
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
