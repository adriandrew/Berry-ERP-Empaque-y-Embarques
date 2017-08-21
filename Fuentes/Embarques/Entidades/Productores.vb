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
            comando.CommandText = "SELECT Id, Nombre FROM " & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Productores " & _
            " UNION SELECT -1 AS Id, NULL AS Nombre FROM " & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Productores " & _
            " ORDER BY Id ASC"
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

    Public Function ObtenerListado() As List(Of Productores)

        Try
            Dim lista As New List(Of Productores)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "SELECT Id, Nombre, Domicilio, Municipio, Estado, Fda, Gs1, Ggn, ClaveAgricola FROM " & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Productores WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionCatalogo.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim tabla As Productores
            While lectorDatos.Read()
                tabla = New Productores()
                tabla.id = Convert.ToInt32(lectorDatos("Id").ToString())
                tabla.nombre = lectorDatos("Nombre").ToString()
                tabla.domicilio = lectorDatos("Domicilio").ToString()
                tabla.municipio = lectorDatos("Municipio").ToString()
                tabla.estado = lectorDatos("Estado").ToString()
                tabla.fda = lectorDatos("Fda").ToString()
                tabla.gs1 = lectorDatos("Gs1").ToString()
                tabla.ggn = lectorDatos("Ggn").ToString()
                tabla.claveAgricola = lectorDatos("ClaveAgricola").ToString()
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
