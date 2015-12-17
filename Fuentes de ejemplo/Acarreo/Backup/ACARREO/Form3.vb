Imports FarPoint.Win.Spread
Public Class Form3

    Private Sub sp1_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles sp1.CellDoubleClick
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveColumnIndex, 0).Text <> "" Then
            Form2.sp1.Sheets(0).Cells(Form2.sp1.Sheets(0).ActiveRowIndex, 0).Text = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text
            Me.Close()
        End If
    End Sub

    Private Sub sp1_DialogKey(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles sp1.DialogKey
        If e.KeyData = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And sp1.Sheets(0).ActiveColumnIndex = 1 Then
            InsertaGrupo()
        End If
    End Sub

    Private Sub Form3_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form2.Show()
        Form2.BringToFront()
        Form2.Focus()
    End Sub

    Private Sub Form3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, sp1.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyData = Keys.Enter And sender.Equals(sp1) And sp1.Sheets(0).ActiveColumnIndex = 1 Then
            InsertaGrupo()
        End If
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        sp1.Sheets(0).Columns.Count = 2
        BringToFront()
        CenterToParent()
        Grupos()
    End Sub

    Sub Grupos()
        Dim Cont As Integer = 0
        Try
            reg.Open("select codigo, descri from grupro order by codigo ", cna, ADODB.CursorTypeEnum.adOpenStatic)
        Catch ex As Exception
            Exit Sub
        End Try
        While Not reg.EOF
            For R As Integer = 0 To 1
                If IsDBNull(reg.Fields(R).Value) Then
                    sp1.Sheets(0).Cells(Cont, R).Text = ""
                Else
                    sp1.Sheets(0).Cells(Cont, R).Text = reg.Fields(R).Value
                End If
            Next
            reg.MoveNext()
            Cont = Cont + 1
        End While
        If reg.RecordCount > 14 Then
            sp1.Sheets(0).Rows.Count = reg.RecordCount
        Else
            sp1.Sheets(0).Rows.Count = 14
        End If
        reg.Close()
    End Sub

    Sub InsertaGrupo()
        Dim Codigo As Integer
        Dim Nombre As String
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text <> "" Then
            Codigo = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 0).Text
        Else
            Exit Sub
        End If
        If sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text <> "" Then
            Nombre = sp1.Sheets(0).Cells(sp1.Sheets(0).ActiveRowIndex, 1).Text
        Else
            Exit Sub
        End If
        Try
            reg.Open("select codigo, descri from grupro where codigo = '" & Codigo & "'", cna, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Catch ex As Exception
            Exit Sub
        End Try
        If reg.EOF Then
            reg.AddNew()
        End If
        reg.Fields(0).Value = Codigo
        reg.Fields(1).Value = Nombre
        reg.Update()
        reg.Close()
        If sp1.Sheets(0).ActiveRowIndex = sp1.Sheets(0).Rows.Count - 1 Then
            sp1.Sheets(0).Rows.Count = sp1.Sheets(0).Rows.Count + 1
        End If
    End Sub
End Class