Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports FarPoint.Win.Spread
Public Class Form2

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cna.Close()
        Form1.Show()
    End Sub

    Private Sub sp1_DialogKey(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles sp1.DialogKey
        If e.KeyData = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 1 Then
            If sp1.Sheets(0).ActiveColumnIndex = 6 Then
                InsertaProductores()
            End If
        ElseIf e.KeyData = Keys.F1 And sender.Equals(sp1) And (opc = 2 Or opc = 6) Then
            If sp1.Sheets(0).ActiveColumnIndex = 0 Then
                Form3.Show()
                Form3.BringToFront()
                Form3.Focus()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 2 Then
            If sp1.Sheets(0).ActiveColumnIndex = 3 Then
                InsertaProducto()
            ElseIf sp1.Sheets(0).ActiveColumnIndex = 0 And IsNumeric(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text) Then
                Try
                    reg1.Open("select codigo from grupro where codigo = '" & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text & "'", cna, ADODB.CursorTypeEnum.adOpenStatic)
                Catch ex As Exception
                    Exit Sub
                End Try
                If reg1.EOF Then
                    Form3.Show()
                    Me.SendToBack()
                    Form3.BringToFront()
                    Form3.Focus()
                End If
                reg1.Close()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 3 Then
            If sp1.Sheets(0).ActiveColumnIndex = 3 Then
                InsertaEnvase()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 4 Then
            If sp1.Sheets(0).ActiveColumnIndex = 1 Then
                InsertaEtapa()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 5 Then
            If sp1.Sheets(0).ActiveColumnIndex = 3 Then
                InsertaLotes()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 6 Then
            If sp1.Sheets(0).ActiveColumnIndex = 3 Then
                InsertaTamaño()
            ElseIf e.KeyData = Keys.Enter And sp1.Sheets(0).ActiveColumnIndex = 0 And IsNumeric(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text) Then
                Try
                    reg1.Open("select codigo from pproducto where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
                Catch ex As Exception
                    Exit Sub
                End Try
                If reg1.EOF Then
                    MsgBox("El producto indicado no existe")
                End If
                reg1.Close()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 7 Then
            If sp1.Sheets(0).ActiveColumnIndex = 2 Then
                InsertaEtiqueta()
            End If
        ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And (opc = 1 Or opc = 5) Then
            If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
                If MsgBox("Desea eliminar el productor/embarcador seleccionado?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Try
                        reg.Open("delete from embarcador where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
                    Catch ex As Exception
                        Exit Sub
                    End Try
                    sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
                    sp1.Sheets(0).Rows.Count = sp1.Sheets(0).Rows.Count + 1
                End If
            End If
        ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 2 Then
            If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
                If MsgBox("Desea eliminar el producto seleccionado?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Try
                        reg.Open("delete from producto where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
                    Catch ex As Exception
                        Exit Sub
                    End Try
                    sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
                    sp1.Sheets(0).Rows.Count = sp1.Sheets(0).Rows.Count + 1
                End If
            End If
        ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 3 Then
            If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
                If MsgBox("Desea eliminar el Envase seleccionado?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Try
                        reg.Open("delete from Envase where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
                    Catch ex As Exception
                        Exit Sub
                    End Try
                    sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
                    sp1.Sheets(0).Rows.Count = sp1.Sheets(0).Rows.Count + 1
                End If
            End If
        ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 4 Then
            If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
                If MsgBox("Desea eliminar la variedad seleccionada?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Try
                        reg.Open("delete from variedad where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
                    Catch ex As Exception
                        Exit Sub
                    End Try
                    sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
                    sp1.Sheets(0).Rows.Count = sp1.Sheets(0).Rows.Count + 1
                End If
            End If
        ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 6 Then
            If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
                If MsgBox("Desea eliminar el tamaño?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Try
                        reg.Open("delete from tamano where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
                    Catch ex As Exception
                        Exit Sub
                    End Try
                    sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
                    sp1.Sheets(0).Rows.Count = sp1.Sheets(0).Rows.Count + 1
                End If
            End If
        ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 7 Then
            If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
                If MsgBox("Desea eliminar la etiqueta seleccionada?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Try
                        reg.Open("delete from etiqueta where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
                    Catch ex As Exception
                        Exit Sub
                    End Try
                    sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
                    sp1.Sheets(0).Rows.Count = sp1.Sheets(0).Rows.Count + 1
                End If
            End If
        End If
    End Sub

    Private Sub Form2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, sp1.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And (opc = 1) Then
            If sp1.Sheets(0).ActiveColumnIndex = 6 Then
                InsertaProductores()
            End If
        ElseIf e.KeyData = Keys.F1 And sender.Equals(sp1) And opc = 2 Then
            If sp1.Sheets(0).ActiveColumnIndex = 0 Then
                Form3.Show()
                Form3.BringToFront()
                Form3.Focus()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 2 Then
            If sp1.Sheets(0).ActiveColumnIndex = 3 Then
                InsertaProducto()
            ElseIf sp1.Sheets(0).ActiveColumnIndex = 0 And IsNumeric(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text) Then
                Try
                    reg1.Open("select codigo from grupro where codigo = '" & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text & "'", cna, ADODB.CursorTypeEnum.adOpenStatic)
                Catch ex As Exception
                    Exit Sub
                End Try
                If reg1.EOF Then
                    Form3.Show()
                    Me.SendToBack()
                    Form3.BringToFront()
                    Form3.Focus()
                End If
                reg1.Close()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 3 Then
            If sp1.Sheets(0).ActiveColumnIndex = 3 Then
                InsertaEnvase()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 4 Then
            If sp1.Sheets(0).ActiveColumnIndex = 1 Then
                InsertaEtapa()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 5 Then
            If sp1.Sheets(0).ActiveColumnIndex = 3 Then
                InsertaLotes()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 6 Then
            If sp1.Sheets(0).ActiveColumnIndex = 3 Then
                InsertaTamaño()
            ElseIf sp1.Sheets(0).ActiveColumnIndex = 0 And IsNumeric(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text) Then
                Try
                    reg1.Open("select codigo from producto where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
                Catch ex As Exception
                    Exit Sub
                End Try
                If reg1.EOF Then
                    MsgBox("El producto indicado no existe")
                End If
                reg1.Close()
            End If
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And opc = 7 Then
            If sp1.Sheets(0).ActiveColumnIndex = 2 Then
                InsertaEtiqueta()
            End If
            'ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And (opc = 1 Or opc = 5) Then
            '    If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            '        If MsgBox("Desea eliminar el productor/embarcador seleccionado?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            '            Try
            '                reg.Open("delete from embarcador where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
            '            Catch ex As Exception
            '                Exit Sub
            '            End Try
            '            sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
            '            sp1.Sheets(0).Rows.Count = 50
            '        End If
            '    End If
            'ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 2 Then
            '    If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
            '        If MsgBox("Desea eliminar el producto seleccionado?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            '            Try
            '                reg.Open("delete from producto where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
            '            Catch ex As Exception
            '                Exit Sub
            '            End Try
            '            sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
            '            sp1.Sheets(0).Rows.Count = 50
            '        End If
            '    End If
            'ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 3 Then
            '    If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            '        If MsgBox("Desea eliminar el Envase seleccionado?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            '            Try
            '                reg.Open("delete from Envase where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
            '            Catch ex As Exception
            '                Exit Sub
            '            End Try
            '            sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
            '            sp1.Sheets(0).Rows.Count = 50
            '        End If
            '    End If
            'ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 4 Then
            '    If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            '        If MsgBox("Desea eliminar la variedad seleccionada?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            '            Try
            '                reg.Open("delete from variedad where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
            '            Catch ex As Exception
            '                Exit Sub
            '            End Try
            '            sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
            '            sp1.Sheets(0).Rows.Count = 50
            '        End If
            '    End If
            'ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 6 Then
            '    If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            '        If MsgBox("Desea eliminar el calibre seleccionada?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            '            Try
            '                reg.Open("delete from tamano where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
            '            Catch ex As Exception
            '                Exit Sub
            '            End Try
            '            sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
            '            sp1.Sheets(0).Rows.Count = 50
            '        End If
            '    End If
            'ElseIf e.KeyData = Keys.F9 And sender.Equals(sp1) And opc = 7 Then
            '    If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            '        If MsgBox("Desea eliminar la etiqueta seleccionada?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
            '            Try
            '                reg.Open("delete from etiqueta where codigo = " & sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text, cna, ADODB.CursorTypeEnum.adOpenStatic)
            '            Catch ex As Exception
            '                Exit Sub
            '            End Try
            '            sp1.Sheets(0).RemoveRows(sp1.Sheets(0).ActiveRowIndex, 1)
            '            sp1.Sheets(0).Rows.Count = 50
            '        End If
            '    End If
        End If
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim im As FarPoint.Win.Spread.InputMap
        Dim im2 As FarPoint.Win.Spread.InputMap
        im = sp1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        im = sp1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        im2 = sp1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        im2 = sp1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        For R As Integer = 1 To 100000
            Dim a As Integer = 1
        Next
        conexion2(Conecta & "\empaque.mdb")
        sp1.Sheets(0).ClearRange(0, 0, 100, 100, True)
        Select Case OPC
            Case 1
                Me.Text = "Productores"
                Productores()
            Case 2
                Me.Text = "Productos"
                Label1.Visible = True
                Productos()
            Case 5
                Me.Text = "Lotes"
                Lotes()
        End Select
        CenterToParent()
    End Sub

    Sub Lotes()
        Dim cont As Integer = 0
        Dim tcell As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tcell2 As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tcell3 As New FarPoint.Win.Spread.CellType.NumberCellType
        tcell2.DecimalPlaces = 0
        tcell3.DecimalPlaces = 2
        sp1.Sheets(0).Columns.Count = 4
        sp1.Sheets(0).ClearRange(0, 0, sp1.Sheets(0).RowCount, sp1.Sheets(0).ColumnCount, True)
        sp1.Sheets(0).Columns(1).CellType = tcell
        sp1.Sheets(0).Columns(0).CellType = tcell2
        sp1.Sheets(0).Columns(2, 3).CellType = tcell3
        Try
            reg.Open("select codigo, Descri, Hectareas, pesocampo from lote order by codigo", cna, ADODB.CursorTypeEnum.adOpenStatic)
        Catch ex As Exception
            Exit Sub
        End Try
        While Not reg.EOF
            sp1.Sheets(0).Cells(cont, 0).Text = reg.Fields(0).Value
            sp1.Sheets(0).Cells(cont, 1).Text = reg.Fields(1).Value
            sp1.Sheets(0).Cells(cont, 2).Text = reg.Fields(2).Value
            sp1.Sheets(0).Cells(cont, 3).Text = reg.Fields(3).Value
            reg.MoveNext()
            cont = cont + 1
        End While
        reg.Close()
        sp1.Size = New Size(536, 379)
        sp1.Location = New Point(50, 20)
        sp1.Sheets(0).ColumnHeader.Cells(0, 0).Text = "No."
        sp1.Sheets(0).ColumnHeader.Cells(0, 1).Text = "NOMBRE"
        sp1.Sheets(0).ColumnHeader.Cells(0, 2).Text = "HECTAREAS"
        sp1.Sheets(0).ColumnHeader.Cells(0, 3).Text = "PESO DE CAMPO"
        sp1.Font = New System.Drawing.Font("microsoft sans serif", 8, FontStyle.Bold)
        sp1.Sheets(0).Columns(0).Width = 50
        sp1.Sheets(0).Columns(1).Width = 250
        sp1.Sheets(0).Columns(2).Width = 80
        sp1.Sheets(0).Columns(3).Width = 100
    End Sub

    Sub Productores()
        Dim cont As Integer = 0
        Dim tcell As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tcell2 As New FarPoint.Win.Spread.CellType.NumberCellType
        tcell2.DecimalPlaces = 0
        sp1.Sheets(0).Rows.Count = 10000
        sp1.Sheets(0).Columns.Count = 7
        sp1.Sheets(0).ClearRange(0, 0, sp1.Sheets(0).RowCount, sp1.Sheets(0).ColumnCount, True)
        sp1.Sheets(0).Cells(0, 1, 49, 6).CellType = tcell
        sp1.Sheets(0).Cells(0, 0, 49, 0).CellType = tcell2
        Try
            reg.Open("select codigo,nombre, ciudad, fda, repres, " & _
                " GS1, id from embarcador order by codigo", cna, ADODB.CursorTypeEnum.adOpenStatic)
        Catch ex As Exception
            Exit Sub
        End Try
        While Not reg.EOF
            For R As Integer = 0 To 6
                If IsDBNull(reg.Fields(R).Value) Then
                    sp1.Sheets(0).Cells(cont, R).Text = ""
                Else
                    sp1.Sheets(0).Cells(cont, R).Text = reg.Fields(R).Value
                End If
            Next R
            reg.MoveNext()
            cont = cont + 1
        End While
        reg.Close()
        sp1.Size = New Size(572, 379)
        sp1.Location = New Point(43, 20)
        sp1.Sheets(0).ColumnHeader.Cells(0, 0).Text = "No.*"
        sp1.Sheets(0).ColumnHeader.Cells(0, 1).Text = "NOMBRE*"
        sp1.Sheets(0).ColumnHeader.Cells(0, 2).Text = "CIUDAD Y ESTADO"
        sp1.Sheets(0).ColumnHeader.Cells(0, 3).Text = "FDA"
        sp1.Sheets(0).ColumnHeader.Cells(0, 4).Text = "REPRESENTANTE"
        sp1.Sheets(0).ColumnHeader.Cells(0, 5).Text = "GS1"
        sp1.Sheets(0).ColumnHeader.Cells(0, 6).Text = "ID"
        sp1.Font = New System.Drawing.Font("microsoft sans serif", 8, FontStyle.Bold)
        sp1.Sheets(0).Columns(0).Width = 40
        sp1.Sheets(0).Columns(1).Width = 200
        sp1.Sheets(0).Columns(2).Width = 150
        sp1.Sheets(0).Columns(3).Width = 150
        sp1.Sheets(0).Columns(4).Width = 300
        sp1.Sheets(0).Columns(5).Width = 70
        sp1.Sheets(0).Columns(6).Width = 40
    End Sub

    Sub Productos()
        Dim cont As Integer = 0
        Dim tcell As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tcell2 As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tcell3 As New FarPoint.Win.Spread.CellType.NumberCellType
        tcell2.DecimalPlaces = 0
        tcell3.DecimalPlaces = 2
        sp1.Sheets(0).Rows.Count = 50
        sp1.Sheets(0).Columns.Count = 4
        sp1.Sheets(0).Columns(2, 3).CellType = tcell
        sp1.Sheets(0).Columns(0, 1).CellType = tcell2
        Try
            reg.Open("select grupo, codigo, descex, descna from producto order by codigo", cna, ADODB.CursorTypeEnum.adOpenStatic)
        Catch ex As Exception
            Exit Sub
        End Try
        While Not reg.EOF
            For R As Integer = 0 To 3
                If IsDBNull(reg.Fields(R).Value) Then
                    sp1.Sheets(0).Cells(cont, R).Text = ""
                Else
                    sp1.Sheets(0).Cells(cont, R).Text = reg.Fields(R).Value
                End If
            Next
            reg.MoveNext()
            cont = cont + 1
        End While
        reg.Close()
        sp1.Size = New Size(486, 379)
        sp1.Location = New Point(90, 20)
        sp1.Sheets(0).ColumnHeader.Cells(0, 0).Text = "Gpo.*"
        sp1.Sheets(0).ColumnHeader.Cells(0, 1).Text = "No.*"
        sp1.Sheets(0).ColumnHeader.Cells(0, 2).Text = "DESC. EXTRANJERA*"
        sp1.Sheets(0).ColumnHeader.Cells(0, 3).Text = "DESC. NACIONAL*"
        sp1.Sheets(0).Columns(0).Width = 40
        sp1.Sheets(0).Columns(1).Width = 40
        sp1.Sheets(0).Columns(2).Width = 180
        sp1.Sheets(0).Columns(3).Width = 180
        sp1.Font = New System.Drawing.Font("microsoft sans serif", 8, FontStyle.Bold)
        sp1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
    End Sub

    Sub Envases()
        Dim cont As Integer = 0
        Dim tcell As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tcell2 As New FarPoint.Win.Spread.CellType.NumberCellType
        Dim tcell3 As New FarPoint.Win.Spread.CellType.NumberCellType
        tcell3.DecimalPlaces = 2
        tcell3.DecimalSeparator = "."
        tcell2.DecimalPlaces = 0
        sp1.Sheets(0).Rows.Count = 50
        sp1.Sheets(0).Columns.Count = 4
        sp1.Sheets(0).Columns(1, 2).CellType = tcell
        sp1.Sheets(0).Columns(0).CellType = tcell2
        sp1.Sheets(0).Columns(3).CellType = tcell3

        Try
            reg.Open("select codigo, descri, codiex, libras from envase order by codigo", cna, ADODB.CursorTypeEnum.adOpenStatic)
        Catch ex As Exception
            Exit Sub
        End Try
        While Not reg.EOF
            For R As Integer = 0 To 3
                If IsDBNull(reg.Fields(R).Value) Then
                    sp1.Sheets(0).Cells(cont, R).Text = ""
                Else
                    sp1.Sheets(0).Cells(cont, R).Text = reg.Fields(R).Value
                End If
            Next
            reg.MoveNext()
            cont = cont + 1
        End While
        reg.Close()
        sp1.Size = New Size(497, 380)
        sp1.Location = New Point(120, 20)
        sp1.Sheets(0).ColumnHeader.Cells(0, 0).Text = "No.*"
        sp1.Sheets(0).ColumnHeader.Cells(0, 1).Text = "DESCRIPCION*"
        sp1.Sheets(0).ColumnHeader.Cells(0, 2).Text = "COD. EXT.*"
        sp1.Sheets(0).ColumnHeader.Cells(0, 3).Text = "LB*"
        'sp1.Sheets(0).ColumnHeader.Cells(0, 5).Text = "CAJAS*"
        sp1.Sheets(0).Columns(0).Width = 50
        sp1.Sheets(0).Columns(1).Width = 150
        sp1.Sheets(0).Columns(2).Width = 150
        sp1.Sheets(0).Columns(3).Width = 90
        'sp1.Sheets(0).Columns(5).Width = 60
        sp1.Font = New System.Drawing.Font("microsoft sans serif", 8, FontStyle.Bold)
        sp1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
    End Sub

    Sub Etapas()
        Dim cont As Integer = 0
        Dim tcell As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tcell2 As New FarPoint.Win.Spread.CellType.NumberCellType
        tcell2.DecimalPlaces = 0
        sp1.Sheets(0).Rows.Count = 50
        sp1.Sheets(0).Columns.Count = 2
        sp1.Sheets(0).Cells(0, 0, 49, 0).CellType = tcell2
        sp1.Sheets(0).Cells(0, 1, 49, 1).CellType = tcell
        Try
            reg.Open("select codigo, nombre from etapa order by codigo", cna, ADODB.CursorTypeEnum.adOpenStatic)
        Catch ex As Exception
            Exit Sub
        End Try
        While Not reg.EOF
            For R As Integer = 0 To 1
                If IsDBNull(reg.Fields(R).Value) Then
                    sp1.Sheets(0).Cells(cont, R).Text = ""
                Else
                    sp1.Sheets(0).Cells(cont, R).Text = reg.Fields(R).Value
                End If
            Next
            reg.MoveNext()
            cont = cont + 1
        End While
        reg.Close()
        sp1.Size = New Size(396, 380)
        sp1.Location = New Point(131, 20)
        sp1.Sheets(0).ColumnHeader.Cells(0, 0).Text = "No.*"
        sp1.Sheets(0).ColumnHeader.Cells(0, 1).Text = "DESCRIPCION*"
        sp1.Sheets(0).Columns(0).Width = 40
        sp1.Sheets(0).Columns(1).Width = 300
        sp1.Font = New System.Drawing.Font("microsoft sans serif", 8, FontStyle.Bold)
        sp1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
    End Sub

    Sub Etiquetas()
        Dim cont As Integer = 0
        Dim tcell As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tcell2 As New FarPoint.Win.Spread.CellType.NumberCellType
        tcell2.DecimalPlaces = 0
        sp1.Sheets(0).Rows.Count = 100
        sp1.Sheets(0).Columns.Count = 3
        sp1.Sheets(0).Cells(0, 1, 99, 1).CellType = tcell
        sp1.Sheets(0).Cells(0, 0, 99, 0).CellType = tcell2
        sp1.Sheets(0).Cells(0, 2, 99, 2).CellType = tcell2
        Try
            reg.Open("select codigo, descri, tipo from etiqueta order by codigo", cna, ADODB.CursorTypeEnum.adOpenStatic)
        Catch ex As Exception
            Exit Sub
        End Try
        While Not reg.EOF
            For R As Integer = 0 To 2
                If IsDBNull(reg.Fields(R).Value) Then
                    sp1.Sheets(0).Cells(cont, R).Text = ""
                Else
                    sp1.Sheets(0).Cells(cont, R).Text = reg.Fields(R).Value
                End If
            Next
            reg.MoveNext()
            cont = cont + 1
        End While
        reg.Close()
        sp1.Size = New Size(296, 380)
        sp1.Location = New Point(183, 20)
        sp1.Sheets(0).ColumnHeader.Cells(0, 0).Text = "No."
        sp1.Sheets(0).ColumnHeader.Cells(0, 1).Text = "DESCRIPCION"
        sp1.Sheets(0).ColumnHeader.Cells(0, 2).Text = "TIPO"
        sp1.Sheets(0).Columns(0).Width = 40
        sp1.Sheets(0).Columns(1).Width = 150
        sp1.Sheets(0).Columns(2).Width = 50
        sp1.Font = New System.Drawing.Font("microsoft sans serif", 8, FontStyle.Bold)
        sp1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
    End Sub

    Sub OrdenesCorte()
        Dim cont As Integer = 0
        Dim tcell As New FarPoint.Win.Spread.CellType.TextCellType
        Dim tcell2 As New FarPoint.Win.Spread.CellType.DateTimeCellType
        tcell2.DateTimeFormat = CellType.DateTimeFormat.ShortDate
        sp1.Sheets(0).Columns.Count = 2
        sp1.Sheets(0).OperationMode = OperationMode.ReadOnly
        sp1.Sheets(0).Cells(0, 0, 49, 0).CellType = tcell
        sp1.Sheets(0).Cells(0, 1, 49, 1).CellType = tcell2
        Try
            reg.Open("select distinct lote, fechacorte from entradaproducto  where lote <> '' order by fechacorte", cna, ADODB.CursorTypeEnum.adOpenStatic)
        Catch ex As Exception
            Exit Sub
        End Try
        If reg.RecordCount > 18 Then
            sp1.Sheets(0).RowCount = reg.RecordCount
        Else
            sp1.Sheets(0).RowCount = 18
        End If
        While Not reg.EOF
            For R As Integer = 0 To 1
                If IsDBNull(reg.Fields(R).Value) Then
                    sp1.Sheets(0).Cells(cont, R).Text = ""
                Else
                    sp1.Sheets(0).Cells(cont, R).Text = reg.Fields(R).Value
                End If
            Next
            reg.MoveNext()
            cont = cont + 1
        End While
        reg.Close()
        sp1.Size = New Size(396, 380)
        sp1.Location = New Point(131, 20)
        sp1.Sheets(0).ColumnHeader.Cells(0, 0).Text = "ORDEN"
        sp1.Sheets(0).ColumnHeader.Cells(0, 1).Text = "FECHA"
        sp1.Sheets(0).Columns(0).Width = 170
        sp1.Sheets(0).Columns(1).Width = 170
        sp1.Font = New System.Drawing.Font("microsoft sans serif", 8, FontStyle.Bold)
        sp1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
    End Sub

    Sub InsertaProductores()
        Dim Codigo As Integer
        Dim Nombre As String
        Dim Ciudad As String
        Dim FDA As String
        Dim Rep As String
        Dim GS1 As String
        Dim id As String
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            Codigo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text
        Else
            MsgBox("Es necesario que indique un código de agricultor")
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
            Nombre = UCase(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text)
        Else
            MsgBox("Es necesario que indique un nombre de agricultor")
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text <> "" Then
            Ciudad = UCase(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text)
        Else
            Ciudad = ""
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 3).Text <> "" Then
            FDA = UCase(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 3).Text)
        Else
            FDA = ""
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 4).Text <> "" Then
            Rep = UCase(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 4).Text)
        Else
            Rep = ""
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 5).Text <> "" Then
            GS1 = Mid(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 5).Text, 1, 10)
            If Not IsNumeric(GS1) Then
                MsgBox("El código GS1 debe ser numérico")
                GS1 = ""
            End If
            GS1 = Mid(GS1, 1, 9)
        Else
            GS1 = ""
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 6).Text <> "" Then
            id = UCase(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 6).Text)
        Else
            id = "00"
        End If

        Try
            reg.Open("select codigo,nombre, ciudad, fda, repres, " & _
            " gs1, id from embarcador where codigo = " & Codigo, cna, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Catch ex As Exception
            Exit Sub
        End Try
        If reg.EOF Then
            reg.AddNew()
        End If
        reg.Fields("codigo").Value = Codigo
        reg.Fields("nombre").Value = Mid(Nombre, 1, 40)
        reg.Fields("ciudad").Value = Mid(Ciudad, 1, 40)
        reg.Fields("fda").Value = Mid(FDA, 1, 30)
        reg.Fields("repres").Value = Mid(Rep, 1, 50)
        reg.Fields("gs1").Value = GS1
        reg.Fields("id").Value = id
        reg.Update()
        reg.Close()
    End Sub

    Sub InsertaProducto()
        Dim Grupo As Integer
        Dim Codigo As Integer
        Dim DescExt As String
        Dim DescNal As String
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            Grupo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text
        Else
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
            Codigo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text
        Else
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text <> "" Then
            DescExt = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text
        Else
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 3).Text <> "" Then
            DescNal = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 3).Text
        Else
            Exit Sub
        End If
        Try
            reg.Open("select grupo, codigo, descex, descna from producto where codigo = " & Codigo, cna, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Catch ex As Exception
            Exit Sub
        End Try
        If reg.EOF Then
            reg.AddNew()
        End If
        reg.Fields(0).Value = Grupo
        reg.Fields(1).Value = Codigo
        reg.Fields(2).Value = Mid(DescExt, 1, 255)
        reg.Fields(3).Value = Mid(DescNal, 1, 255)
        reg.Update()
        reg.Close()
    End Sub

    Sub InsertaEnvase()
        Dim Codigo As Integer
        Dim Desc As String
        Dim CodExt As String
        Dim Libras As Double
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            Codigo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text
        Else
            MsgBox("Debes proporcionar un código de envase")
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
            Desc = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text
        Else
            MsgBox("Debes proporcionar un nombre de envase")
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text <> "" Then
            CodExt = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text
        Else
            MsgBox("Debes proporcionar un código extranjero de envase")
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 3).Text <> "" Then
            Libras = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 3).Text
        Else
            MsgBox("Debes proporcionar un peso de envase")
            Exit Sub
        End If

        Try
            reg.Open("select codigo, descri, codiex, libras from envase where codigo = " & Codigo, cna, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Catch ex As Exception
            Exit Sub
        End Try
        If reg.EOF Then
            reg.AddNew()
        End If
        reg.Fields(0).Value = Codigo
        reg.Fields(1).Value = Mid(Desc, 1, 20)
        reg.Fields(2).Value = Mid(CodExt, 1, 20)
        reg.Fields(3).Value = Libras
        reg.Update()
        reg.Close()
    End Sub

    Sub InsertaEtapa()
        Dim Codigo As Integer
        Dim Nombre As String
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            Codigo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text
        Else
            MsgBox("Debes proporcionar un código de Etapa")
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
            Nombre = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text
        Else
            MsgBox("Debes proporcionar un nombre de etapa")
            Exit Sub
        End If
        Try
            reg.Open("select codigo, nombre from etapa where codigo = " & Codigo, cna, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Catch ex As Exception
            Exit Sub
        End Try
        If reg.EOF Then
            reg.AddNew()
        End If
        reg.Fields(0).Value = Codigo
        reg.Fields(1).Value = Mid(Nombre, 1, 20)
        reg.Update()
        reg.Close()
    End Sub

    Sub InsertaTamaño()
        Dim producto As Integer
        Dim Codigo As Integer
        Dim DescExt As String
        Dim DescNal As String
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            producto = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text
        Else
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
            Codigo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text
        Else
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text <> "" Then
            DescExt = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text
        Else
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 3).Text <> "" Then
            DescNal = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 3).Text
        Else
            Exit Sub
        End If
        Try
            reg.Open("select producto, codigo, descex, descna from tamano where codigo = " & Codigo, cna, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Catch ex As Exception
            MsgBox("Error al guardar tamaño " & ex.Message)
            Exit Sub
        End Try
        If reg.EOF Then
            reg.AddNew()
            sp1.ActiveSheet.Rows.Add(sp1.Sheets(0).RowCount - 1, 1)
        End If
        reg.Fields(0).Value = producto
        reg.Fields(1).Value = Codigo
        reg.Fields(2).Value = Mid(DescExt, 1, 20)
        reg.Fields(3).Value = Mid(DescNal, 1, 20)
        Try
            reg.Update()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        reg.Close()
    End Sub

    Sub InsertaLotes()
        Dim Codigo As Integer
        Dim Nombre As String
        Dim Hectareas As Double = 0
        Dim pesocampo As Double = 0
        If IsNumeric(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text) Then
            Codigo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text
        Else
            MsgBox("Es necesario que indique un código de Lote")
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
            Nombre = UCase(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text)
        Else
            MsgBox("Es necesario que indique un nombre de Lote")
            Exit Sub
        End If
        If IsNumeric(sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text) Then
            Hectareas = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text
        Else
            Hectareas = 0
        End If
        pesocampo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 3).Text
        Try
            reg.Open("select codigo, descri, Hectareas, pesocampo " & _
            "  from lote where codigo = " & Codigo, cna, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Catch ex As Exception
            Exit Sub
        End Try
        If reg.EOF Then
            reg.AddNew()
        End If
        reg.Fields("codigo").Value = Codigo
        reg.Fields("descri").Value = Nombre
        reg.Fields("hectareas").Value = Hectareas
        reg.Fields("pesocampo").Value = pesocampo
        reg.Update()
        reg.Close()
    End Sub

    Sub InsertaEtiqueta()
        Dim Codigo As Integer
        Dim Desc As String
        Dim Tipo As String
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            Codigo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text
        Else
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
            Desc = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text
        Else
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text <> "" Then
            Tipo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 2).Text
        Else
            Exit Sub
        End If
        Try
            reg.Open("select codigo, descri, tipo from etiqueta where codigo = " & Codigo, cna, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Catch ex As Exception
            Exit Sub
        End Try
        If reg.EOF Then
            reg.AddNew()
        End If
        reg.Fields(0).Value = Codigo
        reg.Fields(1).Value = Mid(Desc, 1, 25)
        reg.Fields(2).Value = Tipo
        reg.Update()
        reg.Close()
    End Sub

    Private Sub sp1_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles sp1.CellDoubleClick
        If opc = 1 Then
            If IsNumeric(sp1.ActiveSheet.Cells(sp1.ActiveSheet.ActiveRowIndex, 0).Text) Then
                Form1.txtIdProductor.Text = sp1.ActiveSheet.Cells(sp1.ActiveSheet.ActiveRowIndex, 0).Text
                Form1.txtProductor.Text = sp1.ActiveSheet.Cells(sp1.ActiveSheet.ActiveRowIndex, 1).Text
                Me.Close()
            End If
        ElseIf opc = 2 Then
            If IsNumeric(sp1.ActiveSheet.Cells(sp1.ActiveSheet.ActiveRowIndex, 1).Text) Then
                Form1.txtIdProducto.Text = sp1.ActiveSheet.Cells(sp1.ActiveSheet.ActiveRowIndex, 1).Text
                Form1.txtProducto.Text = sp1.ActiveSheet.Cells(sp1.ActiveSheet.ActiveRowIndex, 2).Text
                Me.Close()
            End If
        ElseIf opc = 5 Then
            If IsNumeric(sp1.ActiveSheet.Cells(sp1.ActiveSheet.ActiveRowIndex, 0).Text) Then
                Form1.txtIdLote.Text = sp1.ActiveSheet.Cells(sp1.ActiveSheet.ActiveRowIndex, 0).Text
                Form1.txtLote.Text = sp1.ActiveSheet.Cells(sp1.ActiveSheet.ActiveRowIndex, 1).Text
                Me.Close()
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            For R As Integer = 0 To sp1.Sheets(0).RowCount - 1
                If sp1.Sheets(0).Cells(R, 3).Text.Contains(UCase(TextBox1.Text)) Then
                    sp1.Sheets(0).Rows(R).Visible = True
                Else
                    sp1.Sheets(0).Rows(R).Visible = False
                End If
            Next
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        'Tamaños()
    End Sub
End Class