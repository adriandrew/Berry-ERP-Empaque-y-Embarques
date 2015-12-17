Imports System.IO
Module ModConexion
    Public EsPrueba As Boolean
    Public Opx As Integer

    Public MenuNoEmpresa As Integer
    Public MenuNombreEmpresa As String
    Public MenuDomicilioEmpresa As String
    Public MenuLocalidadEmpresa As String
    Public MenuRfcEmpresa As String
    Public MenuLogotipoEmpresa As String
    Public MenuIdioma As String
    Public MenuModulo As String
    Public MenuGrupo As String
    Public MenuPrograma As String
    Public MenuUsuarioEmpresa As String
    Public MenuEquipoOrigen As String
    Public MenuConexion As String
    Public MenuConexionUsuario As String
    Public MenuConexionClave As String
    Public MenuConexionBD As String
    Public MenuTipoBD As String
    Public MenuRutaArchivoBD As String
    Public MenuBdAccess As String

    Sub LeeArchivo2()
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

    Sub conexionnueva()
        Dim band As Boolean

        Dim Fecha As Date
        Dim Hora As Date
        Dim dd As String
        Dim mm As String
        Dim aa As String
        Dim hh As String
        Dim mi As String
        Dim ss As String

        Fecha = Now.ToShortDateString
        Hora = Now
        mm = Fecha.Month
        dd = Fecha.Day
        aa = Fecha.Year
        hh = Hora.Hour
        mi = Hora.Minute
        ss = Hora.Second
        Dim CADENA As String
        CADENA = ""
        Dim s1 As Integer
        If EsPrueba Then
            CADENA = "\sys21.mx\prueba.txt"
            band = True
        Else
            For s1 = 1 To 6000
                CADENA = "\sys21.mx\" & aa & mm & dd & hh & mi & ss & ".txt"


                If Dir(CADENA) <> "" Then
                    band = True
                    Exit For
                Else
                    ss = cint(ss) - 1
                    If ss = 0 Then
                        mi = CInt(mi) - 1
                        ss = 59
                    End If
                    If mi = 0 Then
                        hh = CInt(hh) - 1
                        ss = 59
                        mi = 59
                    End If
                End If
            Next s1
        End If

        If band = False Then
            MsgBox("No Hay Cadena")
        End If

        Dim oSR As New StreamReader(CADENA)
        Dim s As String = oSR.ReadLine()
        Dim I As Integer = 0
        Do While Not (s Is Nothing Or s = "")
            If I = 0 Then
                MenuNoEmpresa = s
            End If
            If I = 1 Then
                MenuNombreEmpresa = s
            End If
            If I = 2 Then
                MenuDomicilioEmpresa = s
            End If
            If I = 3 Then
                MenuLocalidadEmpresa = s
            End If
            If I = 4 Then
                MenuRfcEmpresa = s
            End If
            If I = 5 Then
                MenuLogotipoEmpresa = s
            End If
            If I = 6 Then
                MenuIdioma = s
            End If
            If I = 7 Then
                MenuModulo = s
            End If
            If I = 8 Then
                MenuGrupo = s
            End If
            If I = 9 Then
                MenuPrograma = s
            End If
            If I = 10 Then
                MenuUsuarioEmpresa = s
            End If
            If I = 11 Then
                MenuEquipoOrigen = s
            End If
            If I = 12 Then
                MenuConexion = s
            End If
            If I = 13 Then
                MenuConexionUsuario = s
            End If
            If I = 14 Then
                MenuConexionClave = s
            End If
            If I = 15 Then
                MenuConexionBD = s
            End If
            If I = 16 Then
                MenuTipoBD = s
            End If
            If I = 17 Then
                MenuBdAccess = s
            End If
            I = I + 1
            s = oSR.ReadLine
        Loop
        oSR.Close()

        If Not EsPrueba Then
            '           Kill (Cadena)
        End If


    End Sub

End Module
