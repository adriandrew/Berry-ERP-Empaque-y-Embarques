Imports System.Data.SqlClient

Public Class Recepcion
     
    Private id As Integer
    Private fecha As Date
    Private hora As String
    Private idLote As Integer
    Private idChofer As Integer
    Private idProducto As Integer
    Private idVariedad As Integer
    Private cantidadCajas As Integer
    Private pesoCajas As Double
    Private orden As Integer

    Public Property EId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property EFecha() As Date
        Get
            Return fecha
        End Get
        Set(value As Date)
            fecha = value
        End Set
    End Property
    Public Property EHora() As String
        Get
            Return hora
        End Get
        Set(value As String)
            hora = value
        End Set
    End Property
    Public Property EIdLote() As Integer
        Get
            Return idLote
        End Get
        Set(value As Integer)
            idLote = value
        End Set
    End Property
    Public Property EIdChofer() As Integer
        Get
            Return idChofer
        End Get
        Set(value As Integer)
            idChofer = value
        End Set
    End Property
    Public Property EIdProducto() As Integer
        Get
            Return idProducto
        End Get
        Set(value As Integer)
            idProducto = value
        End Set
    End Property
    Public Property EIdVariedad() As Integer
        Get
            Return idVariedad
        End Get
        Set(value As Integer)
            idVariedad = value
        End Set
    End Property
    Public Property ECantidadCajas() As Integer
        Get
            Return cantidadCajas
        End Get
        Set(value As Integer)
            cantidadCajas = value
        End Set
    End Property
    Public Property EPesoCajas() As Double
        Get
            Return pesoCajas
        End Get
        Set(value As Double)
            pesoCajas = value
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
     
    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND R.Id=@id"
            End If
            comando.CommandText = String.Format("SELECT SUM(R.PesoCajas)/SUM(R.CantidadCajas) AS PesoCajaUnitaria, R.IdProductor, PR.Nombre AS NombreProductor, R.IdLote, L.Nombre AS NombreLote, R.IdProducto, P.Nombre AS NombreProducto, R.IdVariedad, V.Nombre AS NombreVariedad " & _
            " FROM Recepcion AS R " & _
            " LEFT JOIN {0}Productores AS PR ON R.IdProductor = PR.Id " & _
            " LEFT JOIN {0}Lotes AS L ON R.IdLote = L.Id " & _
            " LEFT JOIN {0}Productos AS P ON R.IdProducto = P.Id " & _
            " LEFT JOIN {0}Variedades AS V ON R.IdVariedad = V.Id AND R.IdProducto = V.IdProducto" & _
            " WHERE 0=0 {1}" & _
            " GROUP BY R.IdProductor, PR.Nombre, R.IdLote, L.Nombre, R.IdProducto, P.Nombre, R.IdVariedad, V.Nombre", EYELogicaVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque, condicion)
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
