Imports System.Data.SqlClient

Public Class Tarimas

    Private id As Integer
    Private idEmbarcador As Integer
    Private idCliente As Integer
    Private esSobrante As Boolean
    Private estaEmbarcado As Boolean
    Private idEmbarque As Integer
    Private idTipoEmbarque As Integer
    Private ordenEmbarque As Integer
    Private idProducto As Integer
    Private nombreProducto As String
    Private idVariedad As Integer
    Private nombreVariedad As String
    Private idEnvase As Integer
    Private nombreEnvase As String
    Private idTamano As Integer
    Private nombreTamano As String
    Private idEtiqueta As Integer
    Private nombreEtiqueta As String
    Private cantidadCajas As Integer
    Private registros As Integer

    Public Property EId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property
    Public Property EIdEmbarcador() As Integer
        Get
            Return idEmbarcador
        End Get
        Set(value As Integer)
            idEmbarcador = value
        End Set
    End Property
    Public Property EIdCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(value As Integer)
            idCliente = value
        End Set
    End Property
    Public Property EEsSobrante() As Boolean
        Get
            Return esSobrante
        End Get
        Set(value As Boolean)
            esSobrante = value
        End Set
    End Property
    Public Property EEstaEmbarcado() As Boolean
        Get
            Return estaEmbarcado
        End Get
        Set(value As Boolean)
            estaEmbarcado = value
        End Set
    End Property
    Public Property EIdEmbarque() As Integer
        Get
            Return idEmbarque
        End Get
        Set(value As Integer)
            idEmbarque = value
        End Set
    End Property
    Public Property EIdTipoEmbarque() As Integer
        Get
            Return idTipoEmbarque
        End Get
        Set(value As Integer)
            idTipoEmbarque = value
        End Set
    End Property
    Public Property EOrdenEmbarque() As Integer
        Get
            Return ordenEmbarque
        End Get
        Set(value As Integer)
            ordenEmbarque = value
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
    Public Property ENombreProducto() As String
        Get
            Return nombreProducto
        End Get
        Set(value As String)
            nombreProducto = value
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
    Public Property ENombreVariedad() As String
        Get
            Return nombreVariedad
        End Get
        Set(value As String)
            nombreVariedad = value
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
    Public Property ENombreEnvase() As String
        Get
            Return nombreEnvase
        End Get
        Set(value As String)
            nombreEnvase = value
        End Set
    End Property
    Public Property EIdTamano() As Integer
        Get
            Return idTamano
        End Get
        Set(value As Integer)
            idTamano = value
        End Set
    End Property
    Public Property ENombreTamano() As String
        Get
            Return nombreTamano
        End Get
        Set(value As String)
            nombreTamano = value
        End Set
    End Property
    Public Property EIdEtiqueta() As Integer
        Get
            Return idEtiqueta
        End Get
        Set(value As Integer)
            idEtiqueta = value
        End Set
    End Property
    Public Property ENombreEtiqueta() As String
        Get
            Return nombreEtiqueta
        End Get
        Set(value As String)
            nombreEtiqueta = value
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
    Public Property ERegistros() As Integer
        Get
            Return registros
        End Get
        Set(value As Integer)
            registros = value
        End Set
    End Property

    Public Function ObtenerParaCargar() As List(Of Tarimas)

        Try
            Dim lista As New List(Of Tarimas)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque 
            comando.CommandText = "SELECT T.Id, T.IdProducto, P.Nombre AS NombreProducto, T.IdVariedad, V.Nombre AS NombreVariedad, T.IdEnvase, E.Nombre AS NombreEnvase, T.IdTamano, TA.Nombre AS NombreTamano, T.IdEtiqueta, ET.Nombre AS NombreEtiqueta, T.CantidadCajas " & _
            " FROM Tarimas AS T " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Productos AS P ON T.IdProducto = P.Id " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Variedades AS V ON T.IdProducto = V.IdProducto AND T.IdVariedad = V.Id " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Envases AS E ON T.IdEnvase = E.Id " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Tamanos AS TA ON T.IdProducto = TA.IdProducto AND T.IdTamano = TA.Id " & _
            " LEFT JOIN " & EYELogicaEmbarques.Programas.bdCatalogo & ".dbo." & EYELogicaEmbarques.Programas.prefijoBaseDatosEmpaque & "Etiquetas AS ET ON T.IdEtiqueta = ET.Id " & _
            " WHERE T.EstaEmbarcado = 'FALSE' AND T.EsSobrante = 'FALSE' AND T.Id=@id ORDER BY T.Orden ASC"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim tabla As Tarimas
            tabla = New Tarimas()
            Dim contador As Integer = 0
            While lectorDatos.Read()
                tabla.id = Convert.ToInt32(lectorDatos("Id").ToString())
                tabla.nombreProducto &= IIf(contador > 0, "- ", String.Empty) & lectorDatos("NombreProducto").ToString() & " (" & Convert.ToInt32(lectorDatos("CantidadCajas").ToString()) & ") "
                tabla.nombreVariedad &= IIf(contador > 0, "- ", String.Empty) & lectorDatos("NombreVariedad").ToString() & " (" & Convert.ToInt32(lectorDatos("CantidadCajas").ToString()) & ") "
                tabla.nombreEnvase &= IIf(contador > 0, "- ", String.Empty) & lectorDatos("NombreEnvase").ToString() & " (" & Convert.ToInt32(lectorDatos("CantidadCajas").ToString()) & ") "
                tabla.nombreTamano &= IIf(contador > 0, "- ", String.Empty) & lectorDatos("NombreTamano").ToString() & " (" & Convert.ToInt32(lectorDatos("CantidadCajas").ToString()) & ") "
                tabla.nombreEtiqueta &= IIf(contador > 0, "- ", String.Empty) & lectorDatos("NombreEtiqueta").ToString() & " (" & Convert.ToInt32(lectorDatos("CantidadCajas").ToString()) & ") "
                tabla.cantidadCajas += Convert.ToInt32(lectorDatos("CantidadCajas").ToString())
                tabla.registros = contador + 1
                contador += 1
            End While
            If (lectorDatos.HasRows) Then
                lista.Add(tabla)
            End If
            BaseDatos.conexionEmpaque.Close()
            Return lista
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Function

    Public Sub EditarExcluirEnEmbarque()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque 
            comando.CommandText = "UPDATE Tarimas SET EstaEmbarcado='FALSE', IdEmbarcador=0, IdCliente=0, IdEmbarque=0, IdTipoEmbarque=0, OrdenEmbarque=0 WHERE IdEmbarque=@idEmbarque AND IdTipoEmbarque=@idTipoEmbarque"
            comando.Parameters.AddWithValue("@idEmbarque", Me.EIdEmbarque)
            comando.Parameters.AddWithValue("@idTipoEmbarque", Me.EIdTipoEmbarque)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub

    Public Sub EditarIncluirEnEmbarque()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = "UPDATE Tarimas SET EstaEmbarcado='TRUE', IdEmbarcador=@idEmbarcador, IdCliente=@idCliente, IdEmbarque=@idEmbarque, IdTipoEmbarque=@idTipoEmbarque, OrdenEmbarque=@ordenEmbarque WHERE Id=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idEmbarcador", Me.EIdEmbarcador)
            comando.Parameters.AddWithValue("@idCliente", Me.EIdCliente)
            comando.Parameters.AddWithValue("@idEmbarque", Me.EIdEmbarque)
            comando.Parameters.AddWithValue("@idTipoEmbarque", Me.EIdTipoEmbarque)
            comando.Parameters.AddWithValue("@ordenEmbarque", Me.EOrdenEmbarque)
            BaseDatos.conexionEmpaque.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionEmpaque.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionEmpaque.Close()
        End Try

    End Sub
     
    Public Function ObtenerParaValidar() As List(Of Tarimas)

        Try
            Dim lista As New List(Of Tarimas)
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionEmpaque
            comando.CommandText = String.Format("SELECT Id, EsSobrante, EstaEmbarcado, IdEmbarque, IdTipoEmbarque, OrdenEmbarque " & _
            " FROM Tarimas " & _
            " WHERE Id=@id " & _
            " GROUP BY Id, EsSobrante, EstaEmbarcado, IdEmbarque, IdTipoEmbarque, OrdenEmbarque")
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionEmpaque.Open()
            Dim lectorDatos As SqlDataReader = comando.ExecuteReader()
            Dim tabla As Tarimas
            While lectorDatos.Read()
                tabla = New Tarimas()
                tabla.id = Convert.ToInt32(lectorDatos("Id").ToString())
                tabla.esSobrante = Convert.ToBoolean(lectorDatos("EsSobrante").ToString())
                tabla.estaEmbarcado = Convert.ToBoolean(lectorDatos("EstaEmbarcado").ToString())
                tabla.idEmbarque = lectorDatos("IdEmbarque").ToString()
                tabla.idTipoEmbarque = Convert.ToInt32(lectorDatos("IdTipoEmbarque").ToString())
                tabla.ordenEmbarque = Convert.ToInt32(lectorDatos("OrdenEmbarque").ToString())
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
