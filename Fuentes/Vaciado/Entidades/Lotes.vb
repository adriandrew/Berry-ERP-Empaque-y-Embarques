Imports System.Data.SqlClient

Public Class Lotes

    Private id As Integer
    Private nombre As String
    Private hectareas As Double
    Private pesoCaja As Double

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
    Public Property EHectareas() As Double
        Get
            Return hectareas
        End Get
        Set(value As Double)
            hectareas = value
        End Set
    End Property
    Public Property EPesoCaja() As Double
        Get
            Return pesoCaja
        End Get
        Set(value As Double)
            pesoCaja = value
        End Set
    End Property

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT Id, Nombre FROM " & LogicaVaciado.Programas.prefijoBaseDatosEmpaque & "Lotes " & _
            " UNION SELECT -1 AS Id, NULL AS Nombre FROM " & LogicaVaciado.Programas.prefijoBaseDatosEmpaque & "Lotes " & _
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

    Public Function ObtenerListado() As List(Of Lotes)

        Try
            Dim lista As New List(Of Lotes)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            Dim condicion As String = String.Empty
            If (Me.EId > 0) Then
                condicion &= " AND Id=@id"
            End If
            comando.CommandText = "SELECT Id, Nombre, Hectareas, PesoCaja FROM " & LogicaVaciado.Programas.prefijoBaseDatosEmpaque & "Lotes WHERE 0=0 " & condicion
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionCatalogo.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim lotes As Lotes
            While lectorDatos.Read()
                lotes = New Lotes()
                lotes.id = Convert.ToInt32(lectorDatos("Id").ToString())
                lotes.nombre = lectorDatos("Nombre").ToString()
                lotes.hectareas = Convert.ToDouble(lectorDatos("Hectareas").ToString())
                lotes.pesoCaja = Convert.ToDouble(lectorDatos("PesoCaja").ToString())
                lista.Add(lotes)
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
