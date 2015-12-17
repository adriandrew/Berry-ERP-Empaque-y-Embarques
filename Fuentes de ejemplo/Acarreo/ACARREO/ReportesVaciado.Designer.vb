<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportesVaciado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportesVaciado))
        Me.spReporte = New FarPoint.Win.Spread.FpSpread()
        Me.spReporte_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAtrasPalletsHasta = New System.Windows.Forms.Button()
        Me.btnAdelantePalletsHasta = New System.Windows.Forms.Button()
        Me.txtFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.btnAtrasPalletsDesde = New System.Windows.Forms.Button()
        Me.btnAdelantePalletsDesde = New System.Windows.Forms.Button()
        Me.txtFechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboLotes = New System.Windows.Forms.ComboBox()
        Me.SheetView1 = New FarPoint.Win.Spread.SheetView()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.rbtnCompleto = New System.Windows.Forms.RadioButton()
        Me.rbtnParciales = New System.Windows.Forms.RadioButton()
        CType(Me.spReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spReporte_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spReporte
        '
        Me.spReporte.AccessibleDescription = ""
        Me.spReporte.Location = New System.Drawing.Point(23, 91)
        Me.spReporte.Name = "spReporte"
        Me.spReporte.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spReporte_Sheet1})
        Me.spReporte.Size = New System.Drawing.Size(955, 527)
        Me.spReporte.TabIndex = 45
        '
        'spReporte_Sheet1
        '
        Me.spReporte_Sheet1.Reset()
        spReporte_Sheet1.SheetName = "Sheet1"
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel2.Controls.Add(Me.btnImprimir)
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.btnExcel)
        Me.Panel2.Location = New System.Drawing.Point(0, 624)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(991, 51)
        Me.Panel2.TabIndex = 44
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Hasta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(25, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Desde:"
        '
        'btnAtrasPalletsHasta
        '
        Me.btnAtrasPalletsHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtrasPalletsHasta.ForeColor = System.Drawing.Color.Black
        Me.btnAtrasPalletsHasta.Location = New System.Drawing.Point(170, 63)
        Me.btnAtrasPalletsHasta.Name = "btnAtrasPalletsHasta"
        Me.btnAtrasPalletsHasta.Size = New System.Drawing.Size(28, 24)
        Me.btnAtrasPalletsHasta.TabIndex = 53
        Me.btnAtrasPalletsHasta.Text = "<"
        Me.btnAtrasPalletsHasta.UseVisualStyleBackColor = True
        '
        'btnAdelantePalletsHasta
        '
        Me.btnAdelantePalletsHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdelantePalletsHasta.ForeColor = System.Drawing.Color.Black
        Me.btnAdelantePalletsHasta.Location = New System.Drawing.Point(197, 63)
        Me.btnAdelantePalletsHasta.Name = "btnAdelantePalletsHasta"
        Me.btnAdelantePalletsHasta.Size = New System.Drawing.Size(28, 24)
        Me.btnAdelantePalletsHasta.TabIndex = 52
        Me.btnAdelantePalletsHasta.Text = ">"
        Me.btnAdelantePalletsHasta.UseVisualStyleBackColor = True
        '
        'txtFechaHasta
        '
        Me.txtFechaHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHasta.ForeColor = System.Drawing.Color.Black
        Me.txtFechaHasta.Location = New System.Drawing.Point(89, 65)
        Me.txtFechaHasta.Mask = "00/00/0000"
        Me.txtFechaHasta.Name = "txtFechaHasta"
        Me.txtFechaHasta.Size = New System.Drawing.Size(82, 20)
        Me.txtFechaHasta.TabIndex = 51
        Me.txtFechaHasta.ValidatingType = GetType(Date)
        '
        'btnAtrasPalletsDesde
        '
        Me.btnAtrasPalletsDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtrasPalletsDesde.ForeColor = System.Drawing.Color.Black
        Me.btnAtrasPalletsDesde.Location = New System.Drawing.Point(170, 37)
        Me.btnAtrasPalletsDesde.Name = "btnAtrasPalletsDesde"
        Me.btnAtrasPalletsDesde.Size = New System.Drawing.Size(28, 24)
        Me.btnAtrasPalletsDesde.TabIndex = 50
        Me.btnAtrasPalletsDesde.Text = "<"
        Me.btnAtrasPalletsDesde.UseVisualStyleBackColor = True
        '
        'btnAdelantePalletsDesde
        '
        Me.btnAdelantePalletsDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdelantePalletsDesde.ForeColor = System.Drawing.Color.Black
        Me.btnAdelantePalletsDesde.Location = New System.Drawing.Point(197, 37)
        Me.btnAdelantePalletsDesde.Name = "btnAdelantePalletsDesde"
        Me.btnAdelantePalletsDesde.Size = New System.Drawing.Size(28, 24)
        Me.btnAdelantePalletsDesde.TabIndex = 49
        Me.btnAdelantePalletsDesde.Text = ">"
        Me.btnAdelantePalletsDesde.UseVisualStyleBackColor = True
        '
        'txtFechaDesde
        '
        Me.txtFechaDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaDesde.ForeColor = System.Drawing.Color.Black
        Me.txtFechaDesde.Location = New System.Drawing.Point(89, 39)
        Me.txtFechaDesde.Mask = "00/00/0000"
        Me.txtFechaDesde.Name = "txtFechaDesde"
        Me.txtFechaDesde.Size = New System.Drawing.Size(82, 20)
        Me.txtFechaDesde.TabIndex = 48
        Me.txtFechaDesde.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Lote:"
        '
        'cboLotes
        '
        Me.cboLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLotes.FormattingEnabled = True
        Me.cboLotes.Location = New System.Drawing.Point(89, 12)
        Me.cboLotes.Name = "cboLotes"
        Me.cboLotes.Size = New System.Drawing.Size(214, 21)
        Me.cboLotes.TabIndex = 46
        '
        'SheetView1
        '
        Me.SheetView1.Reset()
        SheetView1.SheetName = "Sheet1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'rbtnCompleto
        '
        Me.rbtnCompleto.AutoSize = True
        Me.rbtnCompleto.Location = New System.Drawing.Point(386, 15)
        Me.rbtnCompleto.Name = "rbtnCompleto"
        Me.rbtnCompleto.Size = New System.Drawing.Size(110, 17)
        Me.rbtnCompleto.TabIndex = 56
        Me.rbtnCompleto.Text = "Reporte Completo"
        Me.rbtnCompleto.UseVisualStyleBackColor = True
        Me.rbtnCompleto.Visible = False
        '
        'rbtnParciales
        '
        Me.rbtnParciales.AutoSize = True
        Me.rbtnParciales.Checked = True
        Me.rbtnParciales.Location = New System.Drawing.Point(386, 43)
        Me.rbtnParciales.Name = "rbtnParciales"
        Me.rbtnParciales.Size = New System.Drawing.Size(124, 17)
        Me.rbtnParciales.TabIndex = 57
        Me.rbtnParciales.TabStop = True
        Me.rbtnParciales.Text = "Reporte de Parciales"
        Me.rbtnParciales.UseVisualStyleBackColor = True
        Me.rbtnParciales.Visible = False
        '
        'ReportesVaciado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(990, 675)
        Me.Controls.Add(Me.rbtnParciales)
        Me.Controls.Add(Me.rbtnCompleto)
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
        Me.Controls.Add(Me.spReporte)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportesVaciado"
        Me.Text = "Reportes de Vaciado"
        CType(Me.spReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spReporte_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.SheetView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents spReporte As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spReporte_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAtrasPalletsHasta As System.Windows.Forms.Button
    Friend WithEvents btnAdelantePalletsHasta As System.Windows.Forms.Button
    Friend WithEvents txtFechaHasta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnAtrasPalletsDesde As System.Windows.Forms.Button
    Friend WithEvents btnAdelantePalletsDesde As System.Windows.Forms.Button
    Friend WithEvents txtFechaDesde As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLotes As System.Windows.Forms.ComboBox
    Friend WithEvents SheetView1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents rbtnCompleto As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnParciales As System.Windows.Forms.RadioButton
End Class
