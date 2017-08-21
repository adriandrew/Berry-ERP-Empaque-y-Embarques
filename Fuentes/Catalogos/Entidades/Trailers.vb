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

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "INSERT INTO " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Trailers (IdLineaTransporte, Id, Marca, Modelo, Serie, NumeroEconomico, PlacasMex, PlacasUsa, Scac, Fda, Color) VALUES (@idLineaTransporte, @id, @marca, @modelo, @serie, @numeroEconomico, @placasMex, @placasUsa, @scac, @fda, @color)"
            comando.Parameters.AddWithValue("@idLineaTransporte", Me.EIdLineaTransporte)
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@marca", Me.EMarca)
            comando.Parameters.AddWithValue("@modelo", Me.EModelo)
            comando.Parameters.AddWithValue("@serie", Me.ESerie)
            comando.Parameters.AddWithValue("@numeroEconomico", Me.ENumeroEconomico)
            comando.Parameters.AddWithValue("@placasMex", Me.EPlacasMex)
            comando.Parameters.AddWithValue("@placasUsa", Me.EPlacasUsa)
            comando.Parameters.AddWithValue("@scac", Me.EScac)
            comando.Parameters.AddWithValue("@fda", Me.EFda)
            comando.Parameters.AddWithValue("@color", Me.EColor)
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
            If (Me.EIdLineaTransporte > 0) Then
                condicion &= " AND IdLineaTransporte=@idLineaTransporte"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "DELETE FROM " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Trailers WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@idLineaTransporte", Me.EIdLineaTransporte)
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
            If (Me.EIdLineaTransporte > 0) Then
                condicion &= " AND T.IdLineaTransporte=@idLineaTransporte"
            End If
            If (Me.EId > 0) Then
                condicion &= " AND T.Id=@id"
            End If
            comando.CommandText = "SELECT T.IdLineaTransporte, LT.Nombre, T.Id, T.Marca, T.Modelo, T.Serie, T.NumeroEconomico, T.PlacasMex, T.PlacasUsa, T.Scac, T.Fda, T.Color FROM " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "Trailers AS T LEFT JOIN " & EYELogicaCatalogos.Programas.prefijoBaseDatosEmpaque & "LineasTransportes AS LT ON T.IdLineaTransporte = LT.Id WHERE 0=0 " & condicion & " ORDER BY T.IdLineaTransporte, T.Id ASC"
            comando.Parameters.AddWithValue("@idLineaTransporte", Me.EIdLineaTransporte)
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
