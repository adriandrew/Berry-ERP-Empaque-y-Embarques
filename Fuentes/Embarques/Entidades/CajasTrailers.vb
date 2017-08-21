Imports System.Data.SqlClient

Public Class CajasTrailers

    Private id As Integer
    Private marca As String
    Private serie As String
    Private numeroEconomico As String
    Private placasMex As String
    Private placasUsa As String
    Private longitud As Double

    Public Property EId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property EMarca() As String
        Get
            Return marca
        End Get
        Set(value As String)
            marca = value
        End Set
    End Property
    Public Property ESerie() As String
        Get
            Return serie
        End Get
        Set(value As String)
            serie = value
        End Set
    End Property
    Public Property ENumeroEconomico() As String
        Get
            Return numeroEconomico
        End Get
        Set(value As String)
            numeroEconomico = value
        End Set
    End Property
    Public Property EPlacasMex() As String
        Get
            Return placasMex
        End Get
        Set(value As String)
            placasMex = value
        End Set
    End Property
    Public Property EPlacasUsa() As String
        Get
            Return placasUsa
        End Get
        Set(value As String)
            placasUsa = value
        End Set
    End Property
    Public Property ELongitud() As Double
        Get
            Return longitud
        End Get
        Set(value As Double)
            longitud = value
        End Set
    End Property
     
    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo 
            comando.CommandText = "SELECT Id, Marca+' - '+Serie AS Nombre FROM " & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "CajasTrailers " & _
            " UNION SELECT -1 AS Id, NULL AS Nombre FROM " & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "CajasTrailers " & _
            " ORDER BY Id ASC"
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
