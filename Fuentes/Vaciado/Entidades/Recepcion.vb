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
            comando.CommandText = "SELECT SUM(R.PesoCajas)/SUM(R.CantidadCajas) AS PesoCajaUnitaria, R.IdLote, L.Nombre AS NombreLote, R.IdProducto, P.Nombre AS NombreProducto, R.IdVariedad, V.Nombre AS NombreVariedad " & _
            " FROM Recepcion AS R " & _
            " LEFT JOIN " & EYELogicaVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque & "Lotes AS L ON R.IdLote = L.Id " & _
            " LEFT JOIN " & EYELogicaVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque & "Productos AS P ON R.IdProducto = P.Id " & _
            " LEFT JOIN " & EYELogicaVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque & "Variedades AS V ON R.IdVariedad = V.Id AND R.IdProducto = V.IdProducto" & _
            " WHERE 0=0 " & condicion & _
            " GROUP BY R.IdLote, L.Nombre, R.IdProducto, P.Nombre, R.IdVariedad, V.Nombre"
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

    Public Function ObtenerListado() As List(Of Recepcion)

        Try
            Dim lista As New List(Of Recepcion)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "SELECT Id, Fecha, Hora, IdLote, IdChofer, IdProducto, IdVariedad, CantidadCajas, PesoCajas, Orden FROM Recepcion WHERE 0=0 " & condicion & " ORDER BY Orden ASC"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim recepcion As Recepcion
            While lectorDatos.Read()
                recepcion = New Recepcion()
                recepcion.id = Convert.ToInt32(lectorDatos("Id").ToString())
                recepcion.fecha = Convert.ToDateTime(lectorDatos("Fecha").ToString())
                recepcion.hora = lectorDatos("Hora").ToString()
                recepcion.idLote = Convert.ToInt32(lectorDatos("IdLote").ToString())
                recepcion.idChofer = Convert.ToInt32(lectorDatos("IdChofer").ToString())
                recepcion.idProducto = Convert.ToInt32(lectorDatos("IdProducto").ToString())
                recepcion.idVariedad = Convert.ToInt32(lectorDatos("IdVariedad").ToString())
                recepcion.cantidadCajas = Convert.ToInt32(lectorDatos("CantidadCajas").ToString())
                recepcion.pesoCajas = Convert.ToDouble(lectorDatos("PesoCajas").ToString())
                recepcion.orden = Convert.ToInt32(lectorDatos("Orden").ToString())
                lista.Add(recepcion)
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
