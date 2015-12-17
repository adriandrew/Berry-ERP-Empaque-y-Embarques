<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Impresion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Impresion))
        Me.cmbEtiquetas = New System.Windows.Forms.ComboBox()
        Me.EtiquetaPaletDocument = New System.Drawing.Printing.PrintDocument()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.sp6 = New FarPoint.Win.Spread.FpSpread()
        Me.sp6_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.spImpresoras = New FarPoint.Win.Spread.FpSpread()
        Me.spImpresoras_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.txtImpresoraCajas = New FarPoint.Win.Spread.FpSpread()
        Me.txtImpresoraCajas_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtImpresoraPalet = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.cbTipoImpresion = New System.Windows.Forms.ComboBox()
        Me.lblTipoEtiqueta = New System.Windows.Forms.Label()
        CType(Me.sp6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sp6_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spImpresoras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spImpresoras_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImpresoraCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImpresoraCajas_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbEtiquetas
        '
        Me.cmbEtiquetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEtiquetas.FormattingEnabled = True
        Me.cmbEtiquetas.Items.AddRange(New Object() {"Etiqueta 2x2 Doble", "Etiqueta 2x2 Sencilla"})
        Me.cmbEtiquetas.Location = New System.Drawing.Point(305, 221)
        Me.cmbEtiquetas.Name = "cmbEtiquetas"
        Me.cmbEtiquetas.Size = New System.Drawing.Size(156, 21)
        Me.cmbEtiquetas.TabIndex = 115
        Me.cmbEtiquetas.Visible = False
        '
        'EtiquetaPaletDocument
        '
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(382, 7)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(100, 20)
        Me.txtFecha.TabIndex = 118
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(325, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "FECHA"
        '
        'sp6
        '
        Me.sp6.AccessibleDescription = ""
        Me.sp6.Location = New System.Drawing.Point(50, 207)
        Me.sp6.Name = "sp6"
        Me.sp6.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sp6_Sheet1})
        Me.sp6.Size = New System.Drawing.Size(74, 20)
        Me.sp6.TabIndex = 121
        Me.sp6.Visible = False
        '
        'sp6_Sheet1
        '
        Me.sp6_Sheet1.Reset()
        sp6_Sheet1.SheetName = "Sheet1"
        '
        'spImpresoras
        '
        Me.spImpresoras.AccessibleDescription = ""
        Me.spImpresoras.Location = New System.Drawing.Point(15, 169)
        Me.spImpresoras.Name = "spImpresoras"
        Me.spImpresoras.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spImpresoras_Sheet1})
        Me.spImpresoras.Size = New System.Drawing.Size(74, 25)
        Me.spImpresoras.TabIndex = 122
        Me.spImpresoras.Visible = False
        '
        'spImpresoras_Sheet1
        '
        Me.spImpresoras_Sheet1.Reset()
        spImpresoras_Sheet1.SheetName = "Sheet1"
        '
        'txtImpresoraCajas
        '
        Me.txtImpresoraCajas.AccessibleDescription = ""
        Me.txtImpresoraCajas.Location = New System.Drawing.Point(107, 169)
        Me.txtImpresoraCajas.Name = "txtImpresoraCajas"
        Me.txtImpresoraCajas.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.txtImpresoraCajas_Sheet1})
        Me.txtImpresoraCajas.Size = New System.Drawing.Size(74, 25)
        Me.txtImpresoraCajas.TabIndex = 123
        Me.txtImpresoraCajas.Visible = False
        '
        'txtImpresoraCajas_Sheet1
        '
        Me.txtImpresoraCajas_Sheet1.Reset()
        txtImpresoraCajas_Sheet1.SheetName = "Sheet1"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(391, 172)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(15, 13)
        Me.Label19.TabIndex = 90
        Me.Label19.Text = "S"
        Me.Label19.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(330, 172)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 89
        Me.Label20.Text = "I"
        Me.Label20.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(391, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 88
        Me.Label15.Text = "S"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(330, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "I"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(357, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "MARGENES"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(12, 223)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(171, 17)
        Me.CheckBox3.TabIndex = 85
        Me.CheckBox3.Text = "Imprimir Etiqueta de Palet"
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(34, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(231, 13)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "IMPRESORA ETIQUETAS RASTREABILIDAD"
        Me.Label18.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(89, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(135, 13)
        Me.Label17.TabIndex = 82
        Me.Label17.Text = "IMPRESORA ETIQUETAS"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(12, 200)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(282, 17)
        Me.CheckBox1.TabIndex = 84
        Me.CheckBox1.Text = "Imprimir Etiquetas para cajas (Rastreabilidad)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'txtImpresoraPalet
        '
        Me.txtImpresoraPalet.Location = New System.Drawing.Point(12, 65)
        Me.txtImpresoraPalet.Name = "txtImpresoraPalet"
        Me.txtImpresoraPalet.Size = New System.Drawing.Size(253, 20)
        Me.txtImpresoraPalet.TabIndex = 91
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 165)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(253, 20)
        Me.TextBox2.TabIndex = 92
        Me.TextBox2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(280, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 23)
        Me.Button1.TabIndex = 93
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(280, 163)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 23)
        Me.Button2.TabIndex = 94
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(347, 65)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(36, 20)
        Me.TextBox14.TabIndex = 95
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(408, 65)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(36, 20)
        Me.TextBox1.TabIndex = 96
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(349, 166)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(36, 20)
        Me.TextBox3.TabIndex = 97
        Me.TextBox3.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(408, 165)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(36, 20)
        Me.TextBox4.TabIndex = 98
        Me.TextBox4.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTipoEtiqueta)
        Me.GroupBox1.Controls.Add(Me.cbTipoImpresion)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.TextBox14)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.cmbEtiquetas)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtImpresoraPalet)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 134)
        Me.GroupBox1.TabIndex = 125
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones de Impresión"
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(364, 345)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(47, 47)
        Me.btnGuardar.TabIndex = 126
        Me.btnGuardar.UseVisualStyleBackColor = True
        Me.btnGuardar.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(435, 345)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(47, 47)
        Me.btnSalir.TabIndex = 127
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'cbTipoImpresion
        '
        Me.cbTipoImpresion.FormattingEnabled = True
        Me.cbTipoImpresion.Items.AddRange(New Object() {"Etiqueta 4 x 2 Pulgadas", "Etiqueta 3.5 x 3 Pulgadas"})
        Me.cbTipoImpresion.Location = New System.Drawing.Point(12, 101)
        Me.cbTipoImpresion.Name = "cbTipoImpresion"
        Me.cbTipoImpresion.Size = New System.Drawing.Size(253, 21)
        Me.cbTipoImpresion.TabIndex = 116
        '
        'lblTipoEtiqueta
        '
        Me.lblTipoEtiqueta.AutoSize = True
        Me.lblTipoEtiqueta.Location = New System.Drawing.Point(278, 104)
        Me.lblTipoEtiqueta.Name = "lblTipoEtiqueta"
        Me.lblTipoEtiqueta.Size = New System.Drawing.Size(107, 13)
        Me.lblTipoEtiqueta.TabIndex = 117
        Me.lblTipoEtiqueta.Text = "TIPO DE ETIQUETA"
        '
        'Impresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(496, 404)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtImpresoraCajas)
        Me.Controls.Add(Me.spImpresoras)
        Me.Controls.Add(Me.sp6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFecha)
        Me.Name = "Impresion"
        Me.Text = "Impresion"
        CType(Me.sp6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sp6_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spImpresoras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spImpresoras_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImpresoraCajas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImpresoraCajas_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbEtiquetas As System.Windows.Forms.ComboBox
    Public WithEvents EtiquetaPaletDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents sp6 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sp6_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents spImpresoras As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spImpresoras_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents txtImpresoraCajas As FarPoint.Win.Spread.FpSpread
    Friend WithEvents txtImpresoraCajas_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents txtImpresoraPalet As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents cbTipoImpresion As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoEtiqueta As System.Windows.Forms.Label
End Class
