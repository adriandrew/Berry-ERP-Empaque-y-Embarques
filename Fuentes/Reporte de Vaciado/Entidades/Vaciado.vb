Imports System.Data.SqlClient

Public Class Vaciado

    Private idProductor As Integer
    Private idLote As Integer
    Private idChofer As Integer
    Private idProducto As Integer
    Private idVariedad As Integer
    Private fecha As Date
    Private fecha2 As Date

    Public Property EIdProductor() As Integer
        Get
            Return Me.idProductor
        End Get
        Set(value As Integer)
            Me.idProductor = value
        End Set
    End Property
    Public Property EIdLote() As Integer
        Get
            Return Me.idLote
        End Get
        Set(value As Integer)
            Me.idLote = value
        End Set
    End Property
    Public Property EIdChofer() As Integer
        Get
            Return Me.idChofer
        End Get
        Set(value As Integer)
            Me.idChofer = value
        End Set
    End Property
    Public Property EIdProducto() As Integer
        Get
            Return Me.idProducto
        End Get
        Set(value As Integer)
            Me.idProducto = value
        End Set
    End Property
    Public Property EIdVariedad() As Integer
        Get
            Return Me.idVariedad
        End Get
        Set(value As Integer)
            Me.idVariedad = value
        End Set
    End Property
    Public Property EFecha() As String
        Get
            Return Me.fecha
        End Get
        Set(value As String)
            Me.fecha = value
        End Set
    End Property
    Public Property EFecha2() As String
        Get
            Return Me.fecha2
        End Get
        Set(value As String)
            Me.fecha2 = value
        End Set
    End Property

    Public Function ArmarBandas(ByVal aplicaFecha As Boolean) As String

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicionSumaSegunda As String = String.Empty
            Dim condicionSumaPrimera As String = String.Empty
            Dim condicionFechaRango As String = String.Empty
            If (aplicaFecha) Then
                condicionFechaRango &= " AND Fecha BETWEEN @fecha AND @fecha2 "
            End If
            comando.CommandText = String.Format("SELECT IdBanda FROM Vaciado " & _
            " WHERE 0=0 {0} GROUP BY IdBanda ORDER BY IdBanda ASC ", condicionFechaRango)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha2))
            BaseDatos.conexionEmpaque.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionEmpaque.Close()
            For fila As Integer = 0 To datos.Rows.Count - 1
                condicionSumaSegunda &= String.Format(", CASE WHEN (V.IdBanda = {0}) THEN SUM(V.Cajas) END AS Banda_{0}", datos.Rows(fila).Item("IdBanda"))
                condicionSumaPrimera &= String.Format(", SUM(VT.Banda_{0}) AS Banda_{0}", datos.Rows(fila).Item("IdBanda"))
            Next
            Return condicionSumaSegunda & "|" & condicionSumaPrimera
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function
     
    Public Function ObtenerListadoReporteVaciado(ByVal aplicaFecha As Boolean) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque 
            Dim seleccionarBandas() As String = ArmarBandas(aplicaFecha).Split("|")
            Dim primeraSumaBandas As String = seleccionarBandas(1)
            Dim segundaSumaBandas As String = seleccionarBandas(0)
            Dim condicionFechaRango As String = String.Empty 
            If (aplicaFecha) Then
                condicionFechaRango &= " AND Fecha BETWEEN @fecha AND @fecha2 "
            End If
            comando.CommandText = String.Format("SELECT VT.Hora {0} FROM (SELECT V.Hora {1} FROM (SELECT IdBanda, ISNULL(SUM(CantidadCajas), 0) AS Cajas, CONVERT(VARCHAR(5), Hora, 108) AS Hora FROM Vaciado WHERE 0=0 {2} GROUP BY IdBanda, CONVERT(VARCHAR(5), Hora, 108) ) AS V GROUP BY V.Hora, V.IdBanda) AS VT GROUP BY VT.Hora", primeraSumaBandas, segundaSumaBandas, condicionFechaRango)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha2))
            BaseDatos.conexionEmpaque.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Function ObtenerListadoReporteSaldos(ByVal aplicaFecha As Boolean, ByVal opcionMovimiento As Integer) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            Dim condicionFechaRango As String = String.Empty
            If (Me.EIdProductor > 0) Then
                condicion &= " AND R.IdProductor=@idProductor "
            End If
            If (Me.EIdLote > 0) Then
                condicion &= " AND R.IdLote=@idLote "
            End If
            If (Me.EIdChofer > 0) Then
                condicion &= " AND R.IdChofer=@idChofer "
            End If
            If (Me.EIdProducto > 0) Then
                condicion &= " AND R.IdProducto=@idProducto "
            End If
            If (Me.EIdVariedad > 0) Then
                condicion &= " AND R.IdVariedad=@idVariedad "
            End If
            If (aplicaFecha) Then
                condicionFechaRango &= " AND VAC.Fecha BETWEEN @fecha AND @fecha2 "
            End If
            If (opcionMovimiento = 2) Then ' Con movimientos.
                condicion &= " AND ISNULL(VAC.CantidadCajas, 0) > 0 "
            ElseIf (opcionMovimiento = 3) Then ' Sin movimientos.
                condicion &= " AND ISNULL(VAC.CantidadCajas, 0) = 0 "
            End If
            comando.CommandText = String.Format("SELECT R.Id, R.Fecha, CONVERT(VARCHAR(5), R.Hora, 108), R.IdProductor, PR.Nombre, R.IdLote, L.Nombre, R.IdChofer, CC.Nombre, R.IdProducto, P.Nombre, R.IdVariedad, V.Nombre, MAX(VAC.Fecha), ISNULL(SUM(R.CantidadCajas), 0) AS CajasRecepcion, VAC.CantidadCajas AS CajasVaciado, ISNULL(SUM(R.CantidadCajas), 0)-ISNULL(VAC.CantidadCajas, 0) AS Saldo" & _
            " FROM Recepcion AS R " & _
            " LEFT JOIN (SELECT IdRecepcion, MAX(Fecha) AS Fecha, ISNULL(SUM(CantidadCajas), 0) AS CantidadCajas FROM Vaciado GROUP BY IdRecepcion) AS VAC ON R.Id = VAC.IdRecepcion " & _
            " LEFT JOIN {0}Productores AS PR ON R.IdProductor = PR.Id " & _
            " LEFT JOIN {0}Lotes AS L ON R.IdLote = L.Id " & _
            " LEFT JOIN {0}ChoferesCampos AS CC ON R.IdChofer = CC.Id " & _
            " LEFT JOIN {0}Productos AS P ON R.IdProducto = P.Id " & _
            " LEFT JOIN {0}Variedades AS V ON R.IdVariedad = V.Id AND R.IdProducto = V.IdProducto " & _
            " WHERE 0=0 {1} " & _
            " GROUP BY R.Id, R.Fecha, R.Hora, R.IdProductor, PR.Nombre, R.IdLote, L.Nombre, R.IdChofer, CC.Nombre, R.IdProducto, P.Nombre, R.IdVariedad, V.Nombre, VAC.CantidadCajas", EYELogicaReporteVaciado.Programas.bdCatalogo & ".dbo." & EYELogicaReporteVaciado.Programas.prefijoBaseDatosEmpaque, condicion & condicionFechaRango)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@idLote", Me.EIdLote)
            comando.Parameters.AddWithValue("@idChofer", Me.EIdChofer)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idVariedad", Me.EIdVariedad)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteVaciado.Funciones.ValidarFechaAEstandar(Me.EFecha2))
            BaseDatos.conexionEmpaque.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionEmpaque.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

End Class
