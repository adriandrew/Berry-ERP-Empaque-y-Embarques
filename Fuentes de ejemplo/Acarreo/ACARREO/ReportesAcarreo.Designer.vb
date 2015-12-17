<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportesAcarreo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportesAcarreo))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.cboLotes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAtrasPalletsHasta = New System.Windows.Forms.Button()
        Me.btnAdelantePalletsHasta = New System.Windows.Forms.Button()
        Me.txtFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.btnAtrasPalletsDesde = New System.Windows.Forms.Button()
        Me.btnAdelantePalletsDesde = New System.Windows.Forms.Button()
        Me.txtFechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.spReporte = New FarPoint.Win.Spread.FpSpread()
        Me.spReporte_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel2.SuspendLayout()
        CType(Me.spReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spReporte_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel2.Controls.Add(Me.btnImprimir)
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.btnExcel)
        Me.Panel2.Location = New System.Drawing.Point(0, 624)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(991, 51)
        Me.Panel2.TabIndex = 2
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(65, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(47, 47)
        Me.btnImprimir.TabIndex = 46
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(931, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(47, 47)
        Me.btnSalir.TabIndex = 31
        Me.btnSalir.TabStop = False
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.Location = New System.Drawing.Point(12, 3)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(47, 47)
        Me.btnExcel.TabIndex = 45
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'cboLotes
        '
        Me.cboLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLotes.FormattingEnabled = True
        Me.cboLotes.Location = New System.Drawing.Point(84, 6)
        Me.cboLotes.Name = "cboLotes"
        Me.cboLotes.Size = New System.Drawing.Size(214, 21)
        Me.cboLotes.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Lote:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Hasta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Desde:"
        '
        'btnAtrasPalletsHasta
        '
        Me.btnAtrasPalletsHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtrasPalletsHasta.ForeColor = System.Drawing.Color.Black
        Me.btnAtrasPalletsHasta.Location = New System.Drawing.Point(165, 57)
        Me.btnAtrasPalletsHasta.Name = "btnAtrasPalletsHasta"
        Me.btnAtrasPalletsHasta.Size = New System.Drawing.Size(28, 24)
        Me.btnAtrasPalletsHasta.TabIndex = 40
        Me.btnAtrasPalletsHasta.Text = "<"
        Me.btnAtrasPalletsHasta.UseVisualStyleBackColor = True
        '
        'btnAdelantePalletsHasta
        '
        Me.btnAdelantePalletsHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdelantePalletsHasta.ForeColor = System.Drawing.Color.Black
        Me.btnAdelantePalletsHasta.Location = New System.Drawing.Point(192, 57)
        Me.btnAdelantePalletsHasta.Name = "btnAdelantePalletsHasta"
        Me.btnAdelantePalletsHasta.Size = New System.Drawing.Size(28, 24)
        Me.btnAdelantePalletsHasta.TabIndex = 39
        Me.btnAdelantePalletsHasta.Text = ">"
        Me.btnAdelantePalletsHasta.UseVisualStyleBackColor = True
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHasta.ForeColor = System.Drawing.Color.Black
        Me.txtFechaHasta.Location = New System.Drawing.Point(84, 59)
        Me.txtFechaHasta.Mask = "00/00/0000"
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(82, 20)
        Me.txtFechaHasta.TabIndex = 38
        Me.txtFechaHasta.ValidatingType = GetType(Date)
        '
        'btnAtrasPalletsDesde
        '
        Me.btnAtrasPalletsDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtrasPalletsDesde.ForeColor = System.Drawing.Color.Black
        Me.btnAtrasPalletsDesde.Location = New System.Drawing.Point(165, 31)
        Me.btnAtrasPalletsDesde.Name = "btnAtrasPalletsDesde"
        Me.btnAtrasPalletsDesde.Size = New System.Drawing.Size(28, 24)
        Me.btnAtrasPalletsDesde.TabIndex = 37
        Me.btnAtrasPalletsDesde.Text = "<"
        Me.btnAtrasPalletsDesde.UseVisualStyleBackColor = True
        '
        'btnAdelantePalletsDesde
        '
        Me.btnAdelantePalletsDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdelantePalletsDesde.ForeColor = System.Drawing.Color.Black
        Me.btnAdelantePalletsDesde.Location = New System.Drawing.Point(192, 31)
        Me.btnAdelantePalletsDesde.Name = "btnAdelantePalletsDesde"
        Me.btnAdelantePalletsDesde.Size = New System.Drawing.Size(28, 24)
        Me.btnAdelantePalletsDesde.TabIndex = 36
        Me.btnAdelantePalletsDesde.Text = ">"
        Me.btnAdelantePalletsDesde.UseVisualStyleBackColor = True
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaDesde.ForeColor = System.Drawing.Color.Black
        Me.txtFechaDesde.Location = New System.Drawing.Point(84, 33)
        Me.txtFechaDesde.Mask = "00/00/0000"
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(82, 20)
        Me.txtFechaDesde.TabIndex = 35
        Me.txtFechaDesde.ValidatingType = GetType(Date)
        '
        'spReporte
        '
        Me.spReporte.AccessibleDescription = ""
        Me.spReporte.Location = New System.Drawing.Point(23, 91)
        Me.spReporte.Name = "spReporte"
        Me.spReporte.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spReporte_Sheet1})
        Me.spReporte.Size = New System.Drawing.Size(955, 527)
        Me.spReporte.TabIndex = 43
        '
        'spReporte_Sheet1
        '
        Me.spReporte_Sheet1.Reset()
        spReporte_Sheet1.SheetName = "Sheet1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 675)
        Me.Controls.Add(Me.spReporte)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnAtrasPalletsHasta)
        Me.Controls.Add(Me.btnAdelantePalletsHasta)
        Me.Controls.Add(Me.txtFechaHasta)
        Me.Controls.Add(Me.btnAtrasPalletsDesde)
        Me.Controls.Add(Me.btnAdelantePalletsDesde)
        Me.Controls.Add(Me.txtFechaDesde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboLotes)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form4"
        Me.Text = "Reportes de Acarreo"
        Me.Panel2.ResumeLayout(False)
        CType(Me.spReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spReporte_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents cboLotes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAtrasPalletsHasta As System.Windows.Forms.Button
    Friend WithEvents btnAdelantePalletsHasta As System.Windows.Forms.Button
    Friend WithEvents txtFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnAtrasPalletsDesde As System.Windows.Forms.Button
    Friend WithEvents btnAdelantePalletsDesde As System.Windows.Forms.Button
    Friend WithEvents txtFechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents spReporte As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spReporte_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
