Imports System.Data.SqlClient

Public Class Recepcion
     
    Private id As Integer
    Private fecha As Date
    Private hora As String
    Private idProductor As Integer
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
    Public Property EIdProductor() As Integer
        Get
            Return idProductor
        End Get
        Set(value As Integer)
            idProductor = value
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

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = "INSERT INTO Recepcion (Id, Fecha, Hora, IdProductor, IdLote, IdChofer, IdProducto, IdVariedad, CantidadCajas, PesoCajas, Orden) VALUES (@id, @fecha, @hora, @idProductor, @idLote, @idChofer, @idProducto, @idVariedad, @cantidadCajas, @pesoCajas, @orden)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@fecha", Me.EFecha)
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@idLote", Me.EIdLote)
            comando.Parameters.AddWithValue("@idChofer", Me.EIdChofer)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idVariedad", Me.EIdVariedad)
            comando.Parameters.AddWithValue("@cantidadCajas", Me.ECantidadCajas)
            comando.Parameters.AddWithValue("@pesoCajas", Me.EPesoCajas)
            comando.Parameters.AddWithValue("@orden", Me.EOrden)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

    Public Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "DELETE FROM Recepcion WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@id", Me.id)
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
            comando.CommandText = "SELECT MAX(CAST (Id AS Int)) AS IdMaximo FROM Recepcion"
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim valor As Integer = 0
            While lectorDatos.Read()
                valor = EYELogicaRecepcion.Funciones.ValidarNumeroACero(lectorDatos("IdMaximo").ToString()) + 1
            End While
            BaseDatos.conexionEmpaque.Close()
            Return valor
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "SELECT CantidadCajas, PesoCajas FROM Recepcion WHERE 0=0 " & condicion & " ORDER BY Orden ASC"
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
            comando.CommandText = "SELECT Id, Fecha, Hora, IdProductor, IdLote, IdChofer, IdProducto, IdVariedad, CantidadCajas, PesoCajas, Orden FROM Recepcion WHERE 0=0 " & condicion & " ORDER BY Orden ASC"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim tabla As Recepcion
            While lectorDatos.Read()
                tabla = New Recepcion()
                tabla.id = Convert.ToInt32(lectorDatos("Id").ToString())
                tabla.fecha = Convert.ToDateTime(lectorDatos("Fecha").ToString())
                tabla.hora = lectorDatos("Hora").ToString()
                tabla.idProductor = Convert.ToInt32(lectorDatos("IdProductor").ToString())
                tabla.idLote = Convert.ToInt32(lectorDatos("IdLote").ToString())
                tabla.idChofer = Convert.ToInt32(lectorDatos("IdChofer").ToString())
                tabla.idProducto = Convert.ToInt32(lectorDatos("IdProducto").ToString())
                tabla.idVariedad = Convert.ToInt32(lectorDatos("IdVariedad").ToString())
                tabla.cantidadCajas = Convert.ToInt32(lectorDatos("CantidadCajas").ToString())
                tabla.pesoCajas = Convert.ToDouble(lectorDatos("PesoCajas").ToString())
                tabla.orden = Convert.ToInt32(lectorDatos("Orden").ToString())
                lista.Add(tabla)
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
