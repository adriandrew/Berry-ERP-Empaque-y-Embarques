Imports System.Data.SqlClient

Public Class Vaciado

    Private idRecepcion As Integer
    Private fecha As Date
    Private hora As String
    Private idBanda As Integer 
    Private cantidadCajas As Integer
    Private pesoCajas As Double
    Private orden As Integer

    Public Property EIdRecepcion() As Integer
        Get
            Return idRecepcion
        End Get
        Set(value As Integer)
            idRecepcion = value
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
    Public Property EIdBanda() As Integer
        Get
            Return idBanda
        End Get
        Set(value As Integer)
            idBanda = value
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
            comando.CommandText = "INSERT INTO Vaciado (IdRecepcion, Fecha, Hora, IdBanda, CantidadCajas, PesoCajas, Orden) VALUES (@idRecepcion, @fecha, @hora, @idBanda, @cantidadCajas, @pesoCajas, @orden)"
            comando.Parameters.AddWithValue("@idRecepcion", Me.EIdRecepcion)
            comando.Parameters.AddWithValue("@fecha", Me.EFecha)
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            comando.Parameters.AddWithValue("@idBanda", Me.EIdBanda) 
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
            comando.CommandText = "DELETE FROM Vaciado WHERE Fecha=@fecha AND Hora=@hora"
            comando.Parameters.AddWithValue("@fecha", EYELogicaVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = "SELECT SUM(VAC.PesoCajas)/SUM(VAC.CantidadCajas) AS PesoCajaUnitaria, R.Id, R.IdLote, L.Nombre AS NombreLote, R.IdProducto, P.Nombre AS NombreProducto, R.IdVariedad, V.Nombre AS NombreVariedad, VAC.IdBanda, VAC.CantidadCajas, VAC.PesoCajas, 0 AS Saldo " & _
            " FROM Vaciado AS VAC " & _
            " LEFT JOIN Recepcion AS R ON VAC.IdRecepcion = R.Id" & _
            " LEFT JOIN " & EYELogicaVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque & "Lotes AS L ON R.IdLote = L.Id " & _
            " LEFT JOIN " & EYELogicaVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque & "Productos AS P ON R.IdProducto = P.Id " & _
            " LEFT JOIN " & EYELogicaVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaVaciado.Programas.prefijoBaseDatosEmpaque & "Variedades AS V ON R.IdVariedad = V.Id AND R.IdProducto = V.IdProducto" & _
            " WHERE VAC.Fecha=@fecha AND VAC.Hora=@hora " & _
            " GROUP BY R.Id, R.IdLote, L.Nombre, R.IdProducto, P.Nombre, R.IdVariedad, V.Nombre, VAC.IdBanda, VAC.CantidadCajas, VAC.PesoCajas, VAC.Orden " & _
            " ORDER BY VAC.Orden ASC"
            comando.Parameters.AddWithValue("@fecha", EYELogicaVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@hora", Me.EHora)
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

    Public Function ObtenerSaldosReporte(ByVal soloId As Boolean) As Integer

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            If (Not soloId) Then
                condicion &= " AND (Fecha<>@fecha OR Hora<>@hora) "
            End If
            comando.CommandText = "SELECT ISNULL(SUM(CajasR),0) - ISNULL(SUM(CajasV), 0) AS DiferenciaCajas " & _
            " FROM " & _
            " ( " & _
            " SELECT ISNULL(SUM(CantidadCajas),0) AS CajasR, 0 AS CajasV FROM Recepcion WHERE Id=@id " & condicion & _
            " UNION " & _
            " SELECT 0 AS CajasR, ISNULL(SUM(CantidadCajas), 0) AS CajasV FROM Vaciado WHERE IdRecepcion=@id " & condicion & _
            " ) AS T"
            '"SELECT ISNULL(SUM(R.CantidadCajas),0) - ISNULL(SUM(V.CantidadCajas), 0) AS DiferenciaCajas FROM Recepcion AS R LEFT JOIN Vaciado AS V ON R.Id = V.IdRecepcion WHERE R.Id=@id"
            comando.Parameters.AddWithValue("@id", Me.EIdRecepcion)
            comando.Parameters.AddWithValue("@fecha", EYELogicaVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader
            lectorDatos = comando.ExecuteReader()
            datos.Load(lectorDatos)
            Dim saldo As Integer = 0
            If (datos.Rows.Count > 0) Then
                saldo = datos.Rows(0).Item("DiferenciaCajas")
            End If
            BaseDatos.conexionEmpaque.Close()
            Return saldo
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerListado() As List(Of Vaciado)

        Try
            Dim lista As New List(Of Vaciado)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque 
            comando.CommandText = "SELECT IdRecepcion, Fecha, Hora, IdBanda, CantidadCajas, PesoCajas, Orden FROM Vaciado WHERE Fecha=@fecha AND Hora=@hora ORDER BY Orden ASC"
            comando.Parameters.AddWithValue("@fecha", Me.EFecha)
            comando.Parameters.AddWithValue("@hora", Me.EHora)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim vaciado As Vaciado
            While lectorDatos.Read()
                vaciado = New Vaciado()
                vaciado.idRecepcion = Convert.ToInt32(lectorDatos("IdRecepcion").ToString())
                vaciado.fecha = Convert.ToDateTime(lectorDatos("Fecha").ToString())
                vaciado.hora = lectorDatos("Hora").ToString()
                vaciado.idBanda = Convert.ToInt32(lectorDatos("IdBanda").ToString())
                vaciado.cantidadCajas = Convert.ToInt32(lectorDatos("CantidadCajas").ToString())
                vaciado.pesoCajas = Convert.ToDouble(lectorDatos("PesoCajas").ToString())
                vaciado.orden = Convert.ToInt32(lectorDatos("Orden").ToString())
                lista.Add(vaciado)
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
