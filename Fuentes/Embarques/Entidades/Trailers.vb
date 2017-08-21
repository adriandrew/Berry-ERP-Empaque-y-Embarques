Imports System.Data.SqlClient

Public Class Trailers

    Private idLineaTransporte As Integer
    Private id As Integer
    Private marca As String
    Private modelo As Integer
    Private serie As String
    Private numeroEconomico As String
    Private placasMex As String
    Private placasUsa As String
    Private scac As String
    Private fda As String
    Private color As String

    Public Property EIdLineaTransporte() As Integer
        Get
            Return idLineaTransporte
        End Get
        Set(value As Integer)
            idLineaTransporte = value
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
    Public Property EMarca() As String
        Get
            Return marca
        End Get
        Set(value As String)
            marca = value
        End Set
    End Property
    Public Property EModelo() As Integer
        Get
            Return modelo
        End Get
        Set(value As Integer)
            modelo = value
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
    Public Property EScac() As String
        Get
            Return scac
        End Get
        Set(value As String)
            scac = value
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
    Public Property EColor() As String
        Get
            Return color
        End Get
        Set(value As String)
            color = value
        End Set
    End Property
     
    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            Dim condicion As String = String.Empty
            If (Me.EIdLineaTransporte > 0) Then
                condicion &= " AND IdLineaTransporte=@idLineaTransporte"
            End If
            comando.CommandText = "SELECT -1 AS Id, NULL AS Nombre FROM " & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Trailers " & _
            " UNION SELECT Id, Marca+' - '+Serie AS Nombre FROM " & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Trailers " & _
            " WHERE 0=0 " & condicion & " ORDER BY Id ASC"
            comando.Parameters.AddWithValue("@idLineaTransporte", Me.EIdLineaTransporte) 
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
