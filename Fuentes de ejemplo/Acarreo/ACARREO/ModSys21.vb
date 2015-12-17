Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.IO
Module ModSys21
    Public conexionAccess As New OleDbConnection
    Public cna As New ADODB.Connection
    Public cnndatos As New OleDbConnection
    'Public con As New MySql.Data.MySqlClient.MySqlConnection
    Public reg As New ADODB.Recordset
    Public reg1 As New ADODB.Recordset
    Public Enc1 As String
    Public Enc2 As String
    Public Enc3 As String
    Public RFC As String
    Public Logodir As String
    Public Equipo As String = My.Computer.Name
    Public EmpresaActiva As Integer
    Public Server As String
    Public Usuar As String
    Public Pwd As String
    Public NombreSistema As String
    Public ProgramaLink As String
    Public Conecta As String
    Public ban As Boolean
    Public prefijo As String
    Public ini As Integer
    Public con As Integer
    Public Num As Integer
    Public opc As Integer
    Public OPK As Integer
    Public preciouni As Double
    Public costoprom As Double

    Public nombreImpresora As String = String.Empty
    Public tipoEtiquetaPalet As Integer = 0



    Sub LeeArchivo()
        Dim X As Integer = 0 'para la conexión
        Try
            Dim oSR As New StreamReader("\ProgSYS21\connect.cnf")
            Dim s As String = oSR.ReadLine()
            Do While Not (s Is Nothing Or s = "")
                X = X + 1
                If X = 1 Then
                    Server = s
                ElseIf X = 2 Then
                    Usuar = s
                ElseIf X = 3 Then
                    Pwd = s
                End If
                s = oSR.ReadLine
            Loop
            oSR.Close()
        Catch ex As Exception

        End Try
    End Sub

    Sub conexion(ByVal dir As String)
        Try
            conexionAccess.ConnectionString = "Provider=Microsoft.jet.OLEDB.4.0;Data Source=" & dir & ";Persist Security Info=False;"
        Catch ex As Exception
            MsgBox("El programa no encontró el servidor, favor de configurarlo en el programa principal")
            Principal.Close()
            End
        End Try
    End Sub

    Sub conexion2(ByVal dir As String)
        cna = New ADODB.Connection
        Try
            cna.Open("Provider=Microsoft.Jet.OLEDB.4.0; " & "Data Source=" & dir & ";")
        Catch ex As Exception
            MsgBox("El programa no encontró el servidor, favor de configurarlo en el programa principal")
            Principal.Close()
            End
        End Try
    End Sub

    Sub ConsultaPuntoRetorno()
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim adap As New OleDb.OleDbDataAdapter
        Dim adap1 As New OleDb.OleDbDataAdapter
        Dim rst As New DataSet
        Dim rst1 As New DataSet
        cnndatos.ConnectionString = "Provider=Microsoft.jet.OLEDB.4.0;Data Source=\ASYS21\Sys21Datos.mdb;" & _
        "Persist Security Info=False;Jet OLEDB:Database Password=MMLI;"
        cnndatos.Open()
        cmd = New OleDbCommand("select path from puntoretorno where equipo = '" & Equipo & "'", cnndatos)
        cmd1 = New OleDbCommand("select a.nombre, a.domicilio, a.localidad, a.logo, a.rfc from empresas a, puntoretorno b " & _
        " where a.Numero = b.NoEmpresa and b.Equipo = '" & Equipo & "'", cnndatos)
        adap.SelectCommand = cmd
        adap.Fill(rst)
        adap1.SelectCommand = cmd1
        adap1.Fill(rst1)
        If rst.Tables(0).Rows.Count > 0 Then
            Conecta = rst.Tables(0).Rows(0).Item(0)
            Enc1 = rst1.Tables(0).Rows(0).Item(0)
            Enc2 = rst1.Tables(0).Rows(0).Item(1)
            Enc3 = rst1.Tables(0).Rows(0).Item(2)
            Logodir = rst1.Tables(0).Rows(0).Item(3)
            RFC = rst1.Tables(0).Rows(0).Item(4)
        Else
            Principal.Close()
            End
        End If
        adap.Dispose()
        cmd.Dispose()
        rst.Dispose()
        conexionAccess.Close()
    End Sub

    Function isnull(ByRef var As Object, ByVal def As String) As String
        If IsDBNull(var) Then
            Return def
        Else
            Return var
        End If
    End Function

    Function isnull(ByRef var As Object, ByVal def As Double) As Double
        If IsDBNull(var) Then
            Return def
        Else
            Return var
        End If
    End Function


End Module
