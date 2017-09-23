Imports System.Data.SqlClient

Public Class CajasPesoTarimas

    Private idProducto As Integer
    Private idEnvase As Integer 
    Private cantidadCajas As Integer
    Private pesoUnitarioCajas As Double

    Public Property EIdProducto() As Integer
        Get
            Return idProducto
        End Get
        Set(value As Integer)
            idProducto = value
        End Set
    End Property
    Public Property EIdEnvase() As Integer
        Get
            Return idEnvase
        End Get
        Set(value As Integer)
            idEnvase = value
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
    Public Property EPesoUnitarioCajas() As Double
        Get
            Return pesoUnitarioCajas
        End Get
        Set(value As Double)
            pesoUnitarioCajas = value
        End Set
    End Property

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("INSERT INTO ConfiguracionCajasPesoTarimas (IdProducto, IdEnvase, CantidadCajas, PesoUnitarioCajas) VALUES (@idProducto, @idEnvase, @cantidadCajas, @pesoUnitarioCajas)")
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
            comando.Parameters.AddWithValue("@cantidadCajas", Me.ECantidadCajas)
            comando.Parameters.AddWithValue("@pesoUnitarioCajas", Me.EPesoUnitarioCajas)
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
            If (Me.EIdProducto > 0) Then
                condicion &= " AND IdProducto=@idProducto"
            End If
            If (Me.EIdEnvase > 0) Then
                condicion &= " AND IdEnvase=@idEnvase"
            End If
            comando.CommandText = String.Format("DELETE FROM ConfiguracionCajasPesoTarimas WHERE 0=0 {0}", condicion)
            comando.Parameters.AddWithValue("@idProducto", Me.EIdProducto)
            comando.Parameters.AddWithValue("@idEnvase", Me.EIdEnvase)
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
            comando.CommandText = String.Format("SELECT CCPT.IdProducto, P.Nombre AS NombreProducto, CCPT.IdEnvase, E.Nombre AS NombreEnvase, CCPT.CantidadCajas, CCPT.PesoUnitarioCajas FROM ConfiguracionCajasPesoTarimas AS CCPT LEFT JOIN {0}Productos AS P ON CCPT.IdProducto=P.Id LEFT JOIN {0}Envases AS E ON CCPT.IdEnvase=E.Id ORDER BY IdProducto, IdEnvase ASC", EYELogicaConfiguraciones.Programas.bdCatalogo & ".dbo." & EYELogicaConfiguraciones.Programas.prefijoBaseDatosEmpaque)
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
