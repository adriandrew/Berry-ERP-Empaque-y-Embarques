Imports System.Data.SqlClient

Public Class Empaque

    Private idProductor As Integer
    Private idProducto As Integer
    Private idVariedad As Integer
    Private idEnvase As Integer
    Private idTamano As Integer
    Private idEtiqueta As Integer
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
    Public Property EIdEnvase() As Integer
        Get
            Return Me.idEnvase
        End Get
        Set(value As Integer)
            Me.idEnvase = value
        End Set
    End Property
    Public Property EIdTamano() As Integer
        Get
            Return Me.idTamano
        End Get
        Set(value As Integer)
            Me.idTamano = value
        End Set
    End Property
    Public Property EIdEtiqueta() As Integer
        Get
            Return Me.idEtiqueta
        End Get
        Set(value As Integer)
            Me.idEtiqueta = value
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

    Public Function ObtenerListadoReporteCajasSimple(ByVal aplicaFecha As Boolean) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            Dim condicionFechaRango As String = String.Empty
            Dim condicionFechaAnterior As String = String.Empty
            Dim condicionFechaFinal As String = String.Empty
            Dim seleccionFinal As String = String.Empty
            Dim seleccionPreFinal As String = String.Empty
            Dim seleccion As String = String.Empty
            Dim agrupacionPreFinal As String = String.Empty
            Dim agrupacion As String = String.Empty
            Dim union As String = String.Empty
            Dim condicionEstatusPiso As String = String.Empty
            Dim condicionEstatusEmbarcado As String = String.Empty
            Dim condicionTipoExportacion As String = String.Empty
            Dim condicionTipoNacional As String = String.Empty
            If (Me.EIdProductor > 0) Then
                condicion &= " AND IdProductor=@idProductor "
            End If
            If (Me.EIdProducto > 0) Then
                condicion &= " AND IdProducto=@idProducto "
                seleccionFinal &= " CajasFinales.IdProducto, P2.Nombre, "
                seleccionPreFinal &= " CajasPreFinales.IdProducto, CajasPreFinales.NombreProducto, "
                seleccion &= " IdProducto, NULL AS NombreProducto, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdProducto, "
                union &= String.Format(" LEFT JOIN {0}Productos AS P2 ON CajasFinales.IdProducto = P2.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdProducto, NULL AS NombreProducto, "
                seleccionFinal &= " CajasFinales.IdProducto, CajasFinales.NombreProducto, "
            End If
            If (Me.EIdVariedad > 0) Then
                condicion &= " AND IdVariedad=@idVariedad "
                seleccionFinal &= " CajasFinales.IdVariedad, V.Nombre, "
                seleccionPreFinal &= " CajasPreFinales.IdVariedad, CajasPreFinales.NombreVariedad, "
                seleccion &= " IdVariedad, NULL AS NombreVariedad, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdVariedad, "
                union &= String.Format(" LEFT JOIN {0}Variedades AS V ON CajasFinales.IdProducto = V.IdProducto AND CajasFinales.IdVariedad = V.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdVariedad, NULL AS NombreVariedad, "
                seleccionFinal &= " CajasFinales.IdVariedad, CajasFinales.NombreVariedad, "
            End If
            If (Me.EIdEnvase > 0) Then
                condicion &= " AND IdEnvase=@idEnvase "
                seleccionFinal &= " CajasFinales.IdEnvase, E.Nombre, "
                seleccionPreFinal &= " CajasPreFinales.IdEnvase, CajasPreFinales.NombreEnvase, "
                seleccion &= " IdEnvase, NULL AS NombreEnvase, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdEnvase, "
                union &= String.Format(" LEFT JOIN {0}Envases AS E ON CajasFinales.IdEnvase = E.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdEnvase, NULL AS NombreEnvase, "
                seleccionFinal &= " CajasFinales.IdEnvase, CajasFinales.NombreEnvase, "
            End If
            If (Me.EIdTamano > 0) Then
                condicion &= " AND IdTamano=@idTamano "
                seleccionFinal &= " CajasFinales.IdTamano, T2.Nombre, "
                seleccionPreFinal &= " CajasPreFinales.IdTamano, CajasPreFinales.NombreTamano, "
                seleccion &= " IdTamano, NULL AS NombreTamano, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdTamano, "
                union &= String.Format(" LEFT JOIN {0}Tamanos AS T2 ON CajasFinales.IdProducto = T2.IdProducto AND CajasFinales.IdTamano = T2.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdTamano, NULL AS NombreTamano, "
                seleccionFinal &= " CajasFinales.IdTamano, CajasFinales.NombreTamano, "
            End If
            If (Me.EIdEtiqueta > 0) Then
                condicion &= " AND IdEtiqueta=@idEtiqueta "
                seleccionFinal &= " CajasFinales.IdEtiqueta, E2.Nombre, "
                seleccionPreFinal &= " CajasPreFinales.IdEtiqueta, CajasPreFinales.NombreEtiqueta, "
                seleccion &= " IdEtiqueta, NULL AS NombreEtiqueta, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdEtiqueta, "
                union &= String.Format(" LEFT JOIN {0}Etiquetas AS E2 ON CajasFinales.IdEtiqueta = E2.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdEtiqueta, NULL AS NombreEtiqueta, "
                seleccionFinal &= " CajasFinales.IdEtiqueta, CajasFinales.NombreEtiqueta, "
            End If
            If (aplicaFecha) Then
                condicionFechaRango &= " AND Fecha BETWEEN @fecha AND @fecha2 "
                condicionFechaAnterior &= " AND Fecha < @fecha "
                condicionFechaFinal &= " AND Fecha <= @fecha2 "
            End If
            condicionEstatusPiso &= " AND EstaEmbarcado = 'FALSE' "
            condicionEstatusEmbarcado &= " AND EstaEmbarcado = 'TRUE' "
            condicionTipoExportacion &= " AND IdTipoEmbarque = 1 "
            condicionTipoNacional &= " AND IdTipoEmbarque = 2 "
            comando.CommandText = String.Format("SELECT CajasFinales.IdProductor, P.Nombre, {9} CajasFinales.CajasAnteriores, CajasFinales.CajasRangos, CajasFinales.CajasActuales, CajasFinales.CajasPiso, CajasFinales.CajasEmbarcadas, CajasFinales.CajasExportadasAnteriores, CajasFinales.CajasExportadasRangos, CajasFinales.CajasExportadasActuales, CajasFinales.CajasNacionalesAnteriores, CajasFinales.CajasNacionalesRangos, CajasFinales.CajasNacionalesActuales FROM " & _
            " ( " & _
                " SELECT CajasPreFinales.IdProductor, CajasPreFinales.NombreProductor, {4} ISNULL(SUM(CajasPreFinales.CajasAnteriores), 0) AS CajasAnteriores, ISNULL(SUM(CajasPreFinales.CajasRangos), 0) AS CajasRangos, ISNULL(SUM(CajasPreFinales.CajasActuales), 0) AS CajasActuales, ISNULL(SUM(CajasPreFinales.CajasPiso), 0) AS CajasPiso, ISNULL(SUM(CajasPreFinales.CajasEmbarcadas), 0) AS CajasEmbarcadas, ISNULL(SUM(CajasPreFinales.CajasExportadasAnteriores), 0) AS CajasExportadasAnteriores, ISNULL(SUM(CajasPreFinales.CajasExportadasRangos), 0) AS CajasExportadasRangos, ISNULL(SUM(CajasPreFinales.CajasExportadasActuales), 0) AS CajasExportadasActuales, ISNULL(SUM(CajasPreFinales.CajasNacionalesAnteriores), 0) AS CajasNacionalesAnteriores, ISNULL(SUM(CajasPreFinales.CajasNacionalesRangos), 0) AS CajasNacionalesRangos, ISNULL(SUM(CajasPreFinales.CajasNacionalesActuales), 0) AS CajasNacionalesActuales FROM " & _
                " ( " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} ISNULL(SUM(CantidadCajas), 0) AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales FROM Tarimas WHERE 0=0 {1} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, ISNULL(SUM(CantidadCajas), 0) AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales " & _
                    " FROM Tarimas WHERE 0=0 {2} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, 0 AS CajasRangos, ISNULL(SUM(CantidadCajas), 0) AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales " & _
                    " FROM Tarimas WHERE 0=0 {3} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, ISNULL(SUM(CantidadCajas), 0) AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales " & _
                    " FROM Tarimas WHERE 0=0 {3} {10} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, ISNULL(SUM(CantidadCajas), 0) AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales " & _
                    " FROM Tarimas WHERE 0=0 {3} {11} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, ISNULL(SUM(CantidadCajas), 0) AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales FROM Tarimas WHERE 0=0 {1} {12} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, ISNULL(SUM(CantidadCajas), 0) AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales " & _
                    " FROM Tarimas WHERE 0=0 {2} {12} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, ISNULL(SUM(CantidadCajas), 0) AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales " & _
                    " FROM Tarimas WHERE 0=0 {3} {12} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, ISNULL(SUM(CantidadCajas), 0) AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales FROM Tarimas WHERE 0=0 {1} {13} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, ISNULL(SUM(CantidadCajas), 0) AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales " & _
                    " FROM Tarimas WHERE 0=0 {2} {13} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, ISNULL(SUM(CantidadCajas), 0) AS CajasNacionalesActuales " & _
                    " FROM Tarimas WHERE 0=0 {3} {13} GROUP BY {7} IdProductor " & _
                    " ) " & _
                " ) AS CajasPreFinales " & _
                " GROUP BY {5} CajasPreFinales.IdProductor, CajasPreFinales.NombreProductor " & _
            " ) AS CajasFinales" & _
            " LEFT JOIN {0}Productores AS P ON CajasFinales.IdProductor = P.Id {8} ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque, condicion & condicionFechaAnterior, condicion & condicionFechaRango, condicion & condicionFechaFinal, seleccionPreFinal, agrupacionPreFinal, seleccion, agrupacion, union, seleccionFinal, condicionEstatusPiso, condicionEstatusEmbarcado, condicionTipoExportacion, condicionTipoNacional)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idVariedad", Me.EIdVariedad)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@idTamano", Me.EIdTamano)
            comando.Parameters.AddWithValue("@idEtiqueta", Me.EIdEtiqueta)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteEmpaque.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteEmpaque.Funciones.ValidarFechaAEstandar(Me.EFecha2))
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

    Public Function ObtenerListadoReporteCajasDetallado(ByVal aplicaFecha As Boolean) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            Dim condicionFechaRango As String = String.Empty
            Dim condicionFechaAnterior As String = String.Empty
            Dim condicionFechaFinal As String = String.Empty
            Dim condicionEstatusPiso As String = String.Empty
            Dim condicionEstatusEmbarcado As String = String.Empty
            Dim condicionTipoExportacion As String = String.Empty
            Dim condicionTipoNacional As String = String.Empty
            If (Me.EIdProductor > 0) Then
                condicion &= " AND IdProductor=@idProductor "
            End If
            If (Me.EIdProducto > 0) Then
                condicion &= " AND IdProducto=@idProducto "
            End If
            If (Me.EIdVariedad > 0) Then
                condicion &= " AND IdVariedad=@idVariedad "
            End If
            If (Me.EIdEnvase > 0) Then
                condicion &= " AND IdEnvase=@idEnvase "
            End If
            If (Me.EIdTamano > 0) Then
                condicion &= " AND IdTamano=@idTamano "
            End If
            If (Me.EIdEtiqueta > 0) Then
                condicion &= " AND IdEtiqueta=@idEtiqueta "
            End If
            If (aplicaFecha) Then
                condicionFechaRango &= " AND Fecha BETWEEN @fecha AND @fecha2 "
                condicionFechaAnterior &= " AND Fecha < @fecha "
                condicionFechaFinal &= " AND Fecha <= @fecha2 "
            End If
            condicionEstatusPiso &= " AND EstaEmbarcado = 'FALSE' "
            condicionEstatusEmbarcado &= " AND EstaEmbarcado = 'TRUE' "
            condicionTipoExportacion &= " AND IdTipoEmbarque = 1 "
            condicionTipoNacional &= " AND IdTipoEmbarque = 2 "
            comando.CommandText = String.Format("SELECT CajasFinales.IdProductor, P.Nombre, CajasFinales.IdProducto, P2.Nombre, CajasFinales.IdVariedad, V.Nombre, CajasFinales.IdEnvase, E.Nombre, CajasFinales.IdTamano, T2.Nombre, CajasFinales.IdEtiqueta, E2.Nombre, CajasFinales.CajasAnteriores, CajasFinales.CajasRangos, CajasFinales.CajasActuales, CajasFinales.CajasPiso, CajasFinales.CajasEmbarcadas, CajasFinales.CajasExportadasAnteriores, CajasFinales.CajasExportadasRangos, CajasFinales.CajasExportadasActuales, CajasFinales.CajasNacionalesAnteriores, CajasFinales.CajasNacionalesRangos, CajasFinales.CajasNacionalesActuales FROM " & _
            " ( " & _
                " SELECT CajasPreFinales.IdProductor, CajasPreFinales.NombreProductor, CajasPreFinales.IdProducto, CajasPreFinales.NombreProducto, CajasPreFinales.IdVariedad, CajasPreFinales.NombreVariedad, CajasPreFinales.IdEnvase, CajasPreFinales.NombreEnvase, CajasPreFinales.IdTamano, CajasPreFinales.NombreTamano, CajasPreFinales.IdEtiqueta, CajasPreFinales.NombreEtiqueta, ISNULL(SUM(CajasPreFinales.CajasAnteriores), 0) AS CajasAnteriores, ISNULL(SUM(CajasPreFinales.CajasRangos), 0) AS CajasRangos, ISNULL(SUM(CajasPreFinales.CajasActuales), 0) AS CajasActuales, ISNULL(SUM(CajasPreFinales.CajasPiso), 0) AS CajasPiso, ISNULL(SUM(CajasPreFinales.CajasEmbarcadas), 0) AS CajasEmbarcadas, ISNULL(SUM(CajasPreFinales.CajasExportadasAnteriores), 0) AS CajasExportadasAnteriores, ISNULL(SUM(CajasPreFinales.CajasExportadasRangos), 0) AS CajasExportadasRangos, ISNULL(SUM(CajasPreFinales.CajasExportadasActuales), 0) AS CajasExportadasActuales, ISNULL(SUM(CajasPreFinales.CajasNacionalesAnteriores), 0) AS CajasNacionalesAnteriores, ISNULL(SUM(CajasPreFinales.CajasNacionalesRangos), 0) AS CajasNacionalesRangos, ISNULL(SUM(CajasPreFinales.CajasNacionalesActuales), 0) AS CajasNacionalesActuales FROM " & _
                " ( " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, ISNULL(SUM(CantidadCajas), 0) AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales FROM Tarimas WHERE 0=0 {1} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, ISNULL(SUM(CantidadCajas), 0) AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {2} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, 0 AS CajasRangos, ISNULL(SUM(CantidadCajas), 0) AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, ISNULL(SUM(CantidadCajas), 0) AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} {4} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, ISNULL(SUM(CantidadCajas), 0) AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} {5} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, ISNULL(SUM(CantidadCajas), 0) AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales  FROM Tarimas WHERE 0=0 {1} {6} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, ISNULL(SUM(CantidadCajas), 0) AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {2} {6} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, ISNULL(SUM(CantidadCajas), 0) AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} {6} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, ISNULL(SUM(CantidadCajas), 0) AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales  FROM Tarimas WHERE 0=0 {1} {7} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, ISNULL(SUM(CantidadCajas), 0) AS CajasNacionalesRangos, 0 AS CajasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {2} {7} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS CajasAnteriores, 0 AS CajasRangos, 0 AS CajasActuales, 0 AS CajasPiso, 0 AS CajasEmbarcadas, 0 AS CajasExportadasAnteriores, 0 AS CajasExportadasRangos, 0 AS CajasExportadasActuales, 0 AS CajasNacionalesAnteriores, 0 AS CajasNacionalesRangos, ISNULL(SUM(CantidadCajas), 0) AS CajasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} {7} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                " ) AS CajasPreFinales " & _
                " GROUP BY CajasPreFinales.IdProductor, CajasPreFinales.NombreProductor, CajasPrefinales.IdProducto, CajasPrefinales.NombreProducto, CajasPrefinales.IdVariedad, CajasPrefinales.NombreVariedad, CajasPrefinales.IdEnvase, CajasPrefinales.NombreEnvase, CajasPrefinales.IdTamano, CajasPrefinales.NombreTamano, CajasPrefinales.IdEtiqueta, CajasPrefinales.NombreEtiqueta" & _
            " ) AS CajasFinales" & _
            " LEFT JOIN {0}Productores AS P ON CajasFinales.IdProductor = P.Id " & _
            " LEFT JOIN {0}Productos AS P2 ON CajasFinales.IdProducto = P2.Id " & _
            " LEFT JOIN {0}Variedades AS V ON CajasFinales.IdProducto = V.IdProducto AND CajasFinales.IdVariedad = V.Id " & _
            " LEFT JOIN {0}Envases AS E ON CajasFinales.IdEnvase = E.Id " & _
            " LEFT JOIN {0}Tamanos AS T2 ON CajasFinales.IdProducto = T2.IdProducto AND CajasFinales.IdTamano = T2.Id " & _
            " LEFT JOIN {0}Etiquetas AS E2 ON CajasFinales.IdEtiqueta = E2.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque, condicion & condicionFechaAnterior, condicion & condicionFechaRango, condicion & condicionFechaFinal, condicionEstatusPiso, condicionEstatusEmbarcado, condicionTipoExportacion, condicionTipoNacional)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idVariedad", Me.EIdVariedad)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@idTamano", Me.EIdTamano)
            comando.Parameters.AddWithValue("@idEtiqueta", Me.EIdEtiqueta)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteEmpaque.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteEmpaque.Funciones.ValidarFechaAEstandar(Me.EFecha2))
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

    Public Function ObtenerListadoReporteTarimasSimple(ByVal aplicaFecha As Boolean) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            Dim condicionFechaRango As String = String.Empty
            Dim condicionFechaAnterior As String = String.Empty
            Dim condicionFechaFinal As String = String.Empty
            Dim seleccionFinal As String = String.Empty
            Dim seleccionPreFinal As String = String.Empty
            Dim seleccion As String = String.Empty
            Dim agrupacionPreFinal As String = String.Empty
            Dim agrupacion As String = String.Empty
            Dim union As String = String.Empty
            Dim condicionEstatusPiso As String = String.Empty
            Dim condicionEstatusEmbarcado As String = String.Empty
            Dim condicionTipoExportacion As String = String.Empty
            Dim condicionTipoNacional As String = String.Empty
            If (Me.EIdProductor > 0) Then
                condicion &= " AND IdProductor=@idProductor "
            End If
            If (Me.EIdProducto > 0) Then
                condicion &= " AND IdProducto=@idProducto "
                seleccionFinal &= " TarimasFinales.IdProducto, P2.Nombre, "
                seleccionPreFinal &= " TarimasPreFinales.IdProducto, TarimasPreFinales.NombreProducto, "
                seleccion &= " IdProducto, NULL AS NombreProducto, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdProducto, "
                union &= String.Format(" LEFT JOIN {0}Productos AS P2 ON TarimasFinales.IdProducto = P2.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdProducto, NULL AS NombreProducto, "
                seleccionFinal &= " TarimasFinales.IdProducto, TarimasFinales.NombreProducto, "
            End If
            If (Me.EIdVariedad > 0) Then
                condicion &= " AND IdVariedad=@idVariedad "
                seleccionFinal &= " TarimasFinales.IdVariedad, V.Nombre, "
                seleccionPreFinal &= " TarimasPreFinales.IdVariedad, TarimasPreFinales.NombreVariedad, "
                seleccion &= " IdVariedad, NULL AS NombreVariedad, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdVariedad, "
                union &= String.Format(" LEFT JOIN {0}Variedades AS V ON TarimasFinales.IdProducto = V.IdProducto AND TarimasFinales.IdVariedad = V.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdVariedad, NULL AS NombreVariedad, "
                seleccionFinal &= " TarimasFinales.IdVariedad, TarimasFinales.NombreVariedad, "
            End If
            If (Me.EIdEnvase > 0) Then
                condicion &= " AND IdEnvase=@idEnvase "
                seleccionFinal &= " TarimasFinales.IdEnvase, E.Nombre, "
                seleccionPreFinal &= " TarimasPreFinales.IdEnvase, TarimasPreFinales.NombreEnvase, "
                seleccion &= " IdEnvase, NULL AS NombreEnvase, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdEnvase, "
                union &= String.Format(" LEFT JOIN {0}Envases AS E ON TarimasFinales.IdEnvase = E.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdEnvase, NULL AS NombreEnvase, "
                seleccionFinal &= " TarimasFinales.IdEnvase, TarimasFinales.NombreEnvase, "
            End If
            If (Me.EIdTamano > 0) Then
                condicion &= " AND IdTamano=@idTamano "
                seleccionFinal &= " TarimasFinales.IdTamano, T2.Nombre, "
                seleccionPreFinal &= " TarimasPreFinales.IdTamano, TarimasPreFinales.NombreTamano, "
                seleccion &= " IdTamano, NULL AS NombreTamano, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdTamano, "
                union &= String.Format(" LEFT JOIN {0}Tamanos AS T2 ON TarimasFinales.IdProducto = T2.IdProducto AND TarimasFinales.IdTamano = T2.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdTamano, NULL AS NombreTamano, "
                seleccionFinal &= " TarimasFinales.IdTamano, TarimasFinales.NombreTamano, "
            End If
            If (Me.EIdEtiqueta > 0) Then
                condicion &= " AND IdEtiqueta=@idEtiqueta "
                seleccionFinal &= " TarimasFinales.IdEtiqueta, E2.Nombre, "
                seleccionPreFinal &= " TarimasPreFinales.IdEtiqueta, TarimasPreFinales.NombreEtiqueta, "
                seleccion &= " IdEtiqueta, NULL AS NombreEtiqueta, "
                agrupacionPreFinal &= seleccionPreFinal
                agrupacion &= " IdEtiqueta, "
                union &= String.Format(" LEFT JOIN {0}Etiquetas AS E2 ON TarimasFinales.IdEtiqueta = E2.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque)
            Else
                seleccionPreFinal &= " NULL AS IdEtiqueta, NULL AS NombreEtiqueta, "
                seleccionFinal &= " TarimasFinales.IdEtiqueta, TarimasFinales.NombreEtiqueta, "
            End If
            If (aplicaFecha) Then
                condicionFechaRango &= " AND Fecha BETWEEN @fecha AND @fecha2 "
                condicionFechaAnterior &= " AND Fecha < @fecha "
                condicionFechaFinal &= " AND Fecha <= @fecha2 "
            End If
            condicionEstatusPiso &= " AND EstaEmbarcado = 'FALSE' "
            condicionEstatusEmbarcado &= " AND EstaEmbarcado = 'TRUE' "
            condicionTipoExportacion &= " AND IdTipoEmbarque = 1 "
            condicionTipoNacional &= " AND IdTipoEmbarque = 2 "
            comando.CommandText = String.Format("SELECT TarimasFinales.IdProductor, P.Nombre, {9} TarimasFinales.TarimasAnteriores, TarimasFinales.TarimasRangos, TarimasFinales.TarimasActuales, TarimasFinales.TarimasPiso, TarimasFinales.TarimasEmbarcadas, TarimasFinales.TarimasExportadasAnteriores, TarimasFinales.TarimasExportadasRangos, TarimasFinales.TarimasExportadasActuales, TarimasFinales.TarimasNacionalesAnteriores, TarimasFinales.TarimasNacionalesRangos, TarimasFinales.TarimasNacionalesActuales FROM " & _
            " ( " & _
                " SELECT TarimasPreFinales.IdProductor, TarimasPreFinales.NombreProductor, {4} ISNULL(SUM(TarimasPreFinales.TarimasAnteriores), 0) AS TarimasAnteriores, ISNULL(SUM(TarimasPreFinales.TarimasRangos), 0) AS TarimasRangos, ISNULL(SUM(TarimasPreFinales.TarimasActuales), 0) AS TarimasActuales, ISNULL(SUM(TarimasPreFinales.TarimasPiso), 0) AS TarimasPiso, ISNULL(SUM(TarimasPreFinales.TarimasEmbarcadas), 0) AS TarimasEmbarcadas, ISNULL(SUM(TarimasPreFinales.TarimasExportadasAnteriores), 0) AS TarimasExportadasAnteriores, ISNULL(SUM(TarimasPreFinales.TarimasExportadasRangos), 0) AS TarimasExportadasRangos, ISNULL(SUM(TarimasPreFinales.TarimasExportadasActuales), 0) AS TarimasExportadasActuales, ISNULL(SUM(TarimasPreFinales.TarimasNacionalesAnteriores), 0) AS TarimasNacionalesAnteriores, ISNULL(SUM(TarimasPreFinales.TarimasNacionalesRangos), 0) AS TarimasNacionalesRangos, ISNULL(SUM(TarimasPreFinales.TarimasNacionalesActuales), 0) AS TarimasNacionalesActuales FROM " & _
                " ( " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} COUNT(Id) AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {1} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, COUNT(Id) AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales " & _
                    " FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {2} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, 0 AS TarimasRangos, COUNT(Id) AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales " & _
                    " FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {3} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, COUNT(Id) AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales " & _
                    " FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {3} {10} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, COUNT(Id) AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales " & _
                    " FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {3} {11} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, COUNT(Id) AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {1} {12} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, COUNT(Id) AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales " & _
                    " FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {2} {12} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, COUNT(Id) AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales " & _
                    " FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {3} {12} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, COUNT(Id) AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {1} {13} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, COUNT(Id) AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales " & _
                    " FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {2} {13} GROUP BY {7} IdProductor " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, {6} 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, COUNT(Id) AS TarimasNacionalesActuales " & _
                    " FROM (SELECT {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY {7} IdProductor, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {3} {13} GROUP BY {7} IdProductor " & _
                    " ) " & _
                " ) AS TarimasPreFinales " & _
                " GROUP BY {5} TarimasPreFinales.IdProductor, TarimasPreFinales.NombreProductor " & _
            " ) AS TarimasFinales" & _
            " LEFT JOIN {0}Productores AS P ON TarimasFinales.IdProductor = P.Id {8} ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque, condicion & condicionFechaAnterior, condicion & condicionFechaRango, condicion & condicionFechaFinal, seleccionPreFinal, agrupacionPreFinal, seleccion, agrupacion, union, seleccionFinal, condicionEstatusPiso, condicionEstatusEmbarcado, condicionTipoExportacion, condicionTipoNacional)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idVariedad", Me.EIdVariedad)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@idTamano", Me.EIdTamano)
            comando.Parameters.AddWithValue("@idEtiqueta", Me.EIdEtiqueta)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteEmpaque.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteEmpaque.Funciones.ValidarFechaAEstandar(Me.EFecha2))
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

    Public Function ObtenerListadoReporteTarimasDetallado(ByVal aplicaFecha As Boolean) As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            Dim condicion As String = String.Empty
            Dim condicionFechaRango As String = String.Empty
            Dim condicionFechaAnterior As String = String.Empty
            Dim condicionFechaFinal As String = String.Empty
            Dim condicionEstatusPiso As String = String.Empty
            Dim condicionEstatusEmbarcado As String = String.Empty
            Dim condicionTipoExportacion As String = String.Empty
            Dim condicionTipoNacional As String = String.Empty
            If (Me.EIdProductor > 0) Then
                condicion &= " AND IdProductor=@idProductor "
            End If
            If (Me.EIdProducto > 0) Then
                condicion &= " AND IdProducto=@idProducto "
            End If
            If (Me.EIdVariedad > 0) Then
                condicion &= " AND IdVariedad=@idVariedad "
            End If
            If (Me.EIdEnvase > 0) Then
                condicion &= " AND IdEnvase=@idEnvase "
            End If
            If (Me.EIdTamano > 0) Then
                condicion &= " AND IdTamano=@idTamano "
            End If
            If (Me.EIdEtiqueta > 0) Then
                condicion &= " AND IdEtiqueta=@idEtiqueta "
            End If
            If (aplicaFecha) Then
                condicionFechaRango &= " AND Fecha BETWEEN @fecha AND @fecha2 "
                condicionFechaAnterior &= " AND Fecha < @fecha "
                condicionFechaFinal &= " AND Fecha <= @fecha2 "
            End If
            condicionEstatusPiso &= " AND EstaEmbarcado = 'FALSE' "
            condicionEstatusEmbarcado &= " AND EstaEmbarcado = 'TRUE' "
            condicionTipoExportacion &= " AND IdTipoEmbarque = 1 "
            condicionTipoNacional &= " AND IdTipoEmbarque = 2 "
            comando.CommandText = String.Format("SELECT TarimasFinales.IdProductor, P.Nombre, TarimasFinales.IdProducto, P2.Nombre, TarimasFinales.IdVariedad, V.Nombre, TarimasFinales.IdEnvase, E.Nombre, TarimasFinales.IdTamano, T2.Nombre, TarimasFinales.IdEtiqueta, E2.Nombre, TarimasFinales.TarimasAnteriores, TarimasFinales.TarimasRangos, TarimasFinales.TarimasActuales, TarimasFinales.TarimasPiso, TarimasFinales.TarimasEmbarcadas, TarimasFinales.TarimasExportadasAnteriores, TarimasFinales.TarimasExportadasRangos, TarimasFinales.TarimasExportadasActuales, TarimasFinales.TarimasNacionalesAnteriores, TarimasFinales.TarimasNacionalesRangos, TarimasFinales.TarimasNacionalesActuales FROM " & _
            " ( " & _
                " SELECT TarimasPreFinales.IdProductor, TarimasPreFinales.NombreProductor, TarimasPreFinales.IdProducto, TarimasPreFinales.NombreProducto, TarimasPreFinales.IdVariedad, TarimasPreFinales.NombreVariedad, TarimasPreFinales.IdEnvase, TarimasPreFinales.NombreEnvase, TarimasPreFinales.IdTamano, TarimasPreFinales.NombreTamano, TarimasPreFinales.IdEtiqueta, TarimasPreFinales.NombreEtiqueta, ISNULL(SUM(TarimasPreFinales.TarimasAnteriores), 0) AS TarimasAnteriores, ISNULL(SUM(TarimasPreFinales.TarimasRangos), 0) AS TarimasRangos, ISNULL(SUM(TarimasPreFinales.TarimasActuales), 0) AS TarimasActuales, ISNULL(SUM(TarimasPreFinales.TarimasPiso), 0) AS TarimasPiso, ISNULL(SUM(TarimasPreFinales.TarimasEmbarcadas), 0) AS TarimasEmbarcadas, ISNULL(SUM(TarimasPreFinales.TarimasExportadasAnteriores), 0) AS TarimasExportadasAnteriores, ISNULL(SUM(TarimasPreFinales.TarimasExportadasRangos), 0) AS TarimasExportadasRangos, ISNULL(SUM(TarimasPreFinales.TarimasExportadasActuales), 0) AS TarimasExportadasActuales, ISNULL(SUM(TarimasPreFinales.TarimasNacionalesAnteriores), 0) AS TarimasNacionalesAnteriores, ISNULL(SUM(TarimasPreFinales.TarimasNacionalesRangos), 0) AS TarimasNacionalesRangos, ISNULL(SUM(TarimasPreFinales.TarimasNacionalesActuales), 0) AS TarimasNacionalesActuales FROM " & _
                " ( " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, COUNT(Id) AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales FROM (SELECT IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta, Id, EstaEmbarcado, IdTipoEmbarque, Fecha FROM Tarimas GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta, Id, EstaEmbarcado, IdTipoEmbarque, Fecha) AS Tarimas WHERE 0=0 {1} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, COUNT(Id) AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {2} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, 0 AS TarimasRangos, COUNT(Id) AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, COUNT(Id) AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} {4} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, COUNT(Id) AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} {5} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, COUNT(Id) AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales  FROM Tarimas WHERE 0=0 {1} {6} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, COUNT(Id) AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {2} {6} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, COUNT(Id) AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} {6} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, COUNT(Id) AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales  FROM Tarimas WHERE 0=0 {1} {7} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, COUNT(Id) AS TarimasNacionalesRangos, 0 AS TarimasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {2} {7} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                    " UNION ALL " & _
                    " ( " & _
                    " SELECT IdProductor, NULL AS NombreProductor, IdProducto, NULL AS NombreProducto, IdVariedad, NULL AS NombreVariedad, IdEnvase, NULL AS NombreEnvase, IdTamano, NULL AS NombreTamano, IdEtiqueta, NULL AS NombreEtiqueta, 0 AS TarimasAnteriores, 0 AS TarimasRangos, 0 AS TarimasActuales, 0 AS TarimasPiso, 0 AS TarimasEmbarcadas, 0 AS TarimasExportadasAnteriores, 0 AS TarimasExportadasRangos, 0 AS TarimasExportadasActuales, 0 AS TarimasNacionalesAnteriores, 0 AS TarimasNacionalesRangos, COUNT(Id) AS TarimasNacionalesActuales  " & _
                    " FROM Tarimas WHERE 0=0 {3} {7} GROUP BY IdProductor, IdProducto, IdVariedad, IdEnvase, IdTamano, IdEtiqueta " & _
                    " ) " & _
                " ) AS TarimasPreFinales " & _
                " GROUP BY TarimasPreFinales.IdProductor, TarimasPreFinales.NombreProductor, TarimasPrefinales.IdProducto, TarimasPrefinales.NombreProducto, TarimasPrefinales.IdVariedad, TarimasPrefinales.NombreVariedad, TarimasPrefinales.IdEnvase, TarimasPrefinales.NombreEnvase, TarimasPrefinales.IdTamano, TarimasPrefinales.NombreTamano, TarimasPrefinales.IdEtiqueta, TarimasPrefinales.NombreEtiqueta" & _
            " ) AS TarimasFinales" & _
            " LEFT JOIN {0}Productores AS P ON TarimasFinales.IdProductor = P.Id " & _
            " LEFT JOIN {0}Productos AS P2 ON TarimasFinales.IdProducto = P2.Id " & _
            " LEFT JOIN {0}Variedades AS V ON TarimasFinales.IdProducto = V.IdProducto AND TarimasFinales.IdVariedad = V.Id " & _
            " LEFT JOIN {0}Envases AS E ON TarimasFinales.IdEnvase = E.Id " & _
            " LEFT JOIN {0}Tamanos AS T2 ON TarimasFinales.IdProducto = T2.IdProducto AND TarimasFinales.IdTamano = T2.Id " & _
            " LEFT JOIN {0}Etiquetas AS E2 ON TarimasFinales.IdEtiqueta = E2.Id ", EYELogicaReporteEmpaque.Programas.bdCatalogo & ".dbo." & EYELogicaReporteEmpaque.Programas.prefijoBaseDatosEmpaque, condicion & condicionFechaAnterior, condicion & condicionFechaRango, condicion & condicionFechaFinal, condicionEstatusPiso, condicionEstatusEmbarcado, condicionTipoExportacion, condicionTipoNacional)
            comando.Parameters.AddWithValue("@idProductor", Me.EIdProductor)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idVariedad", Me.EIdVariedad)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@idTamano", Me.EIdTamano)
            comando.Parameters.AddWithValue("@idEtiqueta", Me.EIdEtiqueta)
            comando.Parameters.AddWithValue("@fecha", EYELogicaReporteEmpaque.Funciones.ValidarFechaAEstandar(Me.EFecha))
            comando.Parameters.AddWithValue("@fecha2", EYELogicaReporteEmpaque.Funciones.ValidarFechaAEstandar(Me.EFecha2))
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
