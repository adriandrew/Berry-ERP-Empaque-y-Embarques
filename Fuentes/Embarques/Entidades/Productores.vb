Imports System.Data.SqlClient

Public Class Productores

    Private id As Integer
    Private nombre As String
    Private domicilio As String
    Private municipio As String
    Private estado As String
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

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = String.Format("SELECT Id, Nombre, (CAST(Id AS Varchar)+' - '+Nombre) AS IdNombre FROM {0}Productores " & _
            " UNION SELECT -1 AS Id, NULL AS Nombre, NULL AS IdNombre FROM {0}Productores " & _
            " ORDER BY Id ASC", EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque)
            BaseDatos.conexionCatalogo.Open() 
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            lectorDatos.Close()
            BaseDatos.conexionCatalogo.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

    Public Function ObtenerListadoReporteCatalogo() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = String.Format("SELECT Id, Nombre FROM {0}Productores ORDER BY Id ASC", EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque)
            BaseDatos.conexionCatalogo.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            lectorDatos.Close()
            BaseDatos.conexionCatalogo.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

End Class
