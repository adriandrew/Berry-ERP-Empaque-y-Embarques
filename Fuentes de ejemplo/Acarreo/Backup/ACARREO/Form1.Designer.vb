<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Encabezado3 = New System.Windows.Forms.Label
        Me.Encabezado2 = New System.Windows.Forms.Label
        Me.Encabezado1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Button33 = New System.Windows.Forms.Button
        Me.Button23 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button27 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.PictureBox50 = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtFolio = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtHora = New System.Windows.Forms.MaskedTextBox
        Me.spAcarreo = New FarPoint.Win.Spread.FpSpread
        Me.spAcarreo_Sheet1 = New FarPoint.Win.Spread.SheetView
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtIdLote = New System.Windows.Forms.TextBox
        Me.txtLote = New System.Windows.Forms.TextBox
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtIdProducto = New System.Windows.Forms.TextBox
        Me.txtProductor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtIdProductor = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.spHistorial = New FarPoint.Win.Spread.FpSpread
        Me.spHistorial_Sheet1 = New FarPoint.Win.Spread.SheetView
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spAcarreo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spAcarreo_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spHistorial_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.Encabezado3)
        Me.Panel1.Controls.Add(Me.Encabezado2)
        Me.Panel1.Controls.Add(Me.Encabezado1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 147)
        Me.Panel1.TabIndex = 0
        '
        'Encabezado3
        '
        Me.Encabezado3.AutoSize = True
        Me.Encabezado3.BackColor = System.Drawing.Color.Transparent
        Me.Encabezado3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Encabezado3.ForeColor = System.Drawing.Color.White
        Me.Encabezado3.Location = New System.Drawing.Point(105, 63)
        Me.Encabezado3.Name = "Encabezado3"
        Me.Encabezado3.Size = New System.Drawing.Size(84, 13)
        Me.Encabezado3.TabIndex = 3
        Me.Encabezado3.Text = "Encabezado3"
        '
        'Encabezado2
        '
        Me.Encabezado2.AutoSize = True
        Me.Encabezado2.BackColor = System.Drawing.Color.Transparent
        Me.Encabezado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Encabezado2.ForeColor = System.Drawing.Color.White
        Me.Encabezado2.Location = New System.Drawing.Point(105, 38)
        Me.Encabezado2.Name = "Encabezado2"
        Me.Encabezado2.Size = New System.Drawing.Size(84, 13)
        Me.Encabezado2.TabIndex = 2
        Me.Encabezado2.Text = "Encabezado2"
        '
        'Encabezado1
        '
        Me.Encabezado1.AutoSize = True
        Me.Encabezado1.BackColor = System.Drawing.Color.Transparent
        Me.Encabezado1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Encabezado1.ForeColor = System.Drawing.Color.White
        Me.Encabezado1.Location = New System.Drawing.Point(106, 13)
        Me.Encabezado1.Name = "Encabezado1"
        Me.Encabezado1.Size = New System.Drawing.Size(84, 13)
        Me.Encabezado1.TabIndex = 1
        Me.Encabezado1.Text = "Encabezado1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(99, 105)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel2.Controls.Add(Me.Button33)
        Me.Panel2.Controls.Add(Me.Button23)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button27)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.Button12)
        Me.Panel2.Location = New System.Drawing.Point(0, 628)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1000, 55)
        Me.Panel2.TabIndex = 1
        '
        'Button33
        '
        Me.Button33.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button33.Image = CType(resources.GetObject("Button33.Image"), System.Drawing.Image)
        Me.Button33.Location = New System.Drawing.Point(215, 0)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(47, 47)
        Me.Button33.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.Button33, "Reporte de Acarreo")
        Me.Button33.UseVisualStyleBackColor = True
        '
        'Button23
        '
        Me.Button23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button23.Image = CType(resources.GetObject("Button23.Image"), System.Drawing.Image)
        Me.Button23.Location = New System.Drawing.Point(109, 0)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(47, 47)
        Me.Button23.TabIndex = 51
        Me.Button23.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button23, "Guardar")
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(3, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(47, 47)
        Me.Button2.TabIndex = 6
        Me.Button2.TabStop = False
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button27
        '
        Me.Button27.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button27.Image = CType(resources.GetObject("Button27.Image"), System.Drawing.Image)
        Me.Button27.Location = New System.Drawing.Point(931, 0)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(47, 47)
        Me.Button27.TabIndex = 31
        Me.Button27.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button27, "Salir")
        Me.Button27.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(56, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(47, 47)
        Me.Button5.TabIndex = 9
        Me.Button5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button5, "Eliminar Folio de Acarreo")
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button12.Location = New System.Drawing.Point(162, 0)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(47, 47)
        Me.Button12.TabIndex = 16
        Me.Button12.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Button12, "Historial de Acarreo")
        Me.Button12.UseVisualStyleBackColor = True
        '
        'PictureBox50
        '
        Me.PictureBox50.Image = CType(resources.GetObject("PictureBox50.Image"), System.Drawing.Image)
        Me.PictureBox50.Location = New System.Drawing.Point(624, 224)
        Me.PictureBox50.Name = "PictureBox50"
        Me.PictureBox50.Size = New System.Drawing.Size(320, 390)
        Me.PictureBox50.TabIndex = 4
        Me.PictureBox50.TabStop = False
        '
        'txtFolio
        '
        Me.txtFolio.BackColor = System.Drawing.Color.White
        Me.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.Location = New System.Drawing.Point(119, 153)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(100, 20)
        Me.txtFolio.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(67, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "FOLIO:"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(119, 179)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(100, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "FECHA:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(228, 183)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "HORA:"
        Me.Label9.Visible = False
        '
        'txtHora
        '
        Me.txtHora.BackColor = System.Drawing.Color.White
        Me.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Location = New System.Drawing.Point(282, 179)
        Me.txtHora.Mask = "00:00"
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(42, 20)
        Me.txtHora.TabIndex = 3
        Me.txtHora.ValidatingType = GetType(Date)
        Me.txtHora.Visible = False
        '
        'spAcarreo
        '
        Me.spAcarreo.AccessibleDescription = ""
        Me.spAcarreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spAcarreo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.spAcarreo.Location = New System.Drawing.Point(14, 283)
        Me.spAcarreo.Name = "spAcarreo"
        Me.spAcarreo.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spAcarreo_Sheet1})
        Me.spAcarreo.Size = New System.Drawing.Size(473, 304)
        Me.spAcarreo.TabIndex = 7
        '
        'spAcarreo_Sheet1
        '
        Me.spAcarreo_Sheet1.Reset()
        spAcarreo_Sheet1.SheetName = "Sheet1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(71, 235)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "LOTE:"
        '
        'txtIdLote
        '
        Me.txtIdLote.BackColor = System.Drawing.Color.White
        Me.txtIdLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdLote.Location = New System.Drawing.Point(119, 231)
        Me.txtIdLote.Name = "txtIdLote"
        Me.txtIdLote.Size = New System.Drawing.Size(52, 20)
        Me.txtIdLote.TabIndex = 5
        '
        'txtLote
        '
        Me.txtLote.BackColor = System.Drawing.Color.White
        Me.txtLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLote.Location = New System.Drawing.Point(177, 231)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.ReadOnly = True
        Me.txtLote.Size = New System.Drawing.Size(225, 20)
        Me.txtLote.TabIndex = 28
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.White
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(177, 257)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(225, 20)
        Me.txtProducto.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 261)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "PRODUCTO:"
        '
        'txtIdProducto
        '
        Me.txtIdProducto.BackColor = System.Drawing.Color.White
        Me.txtIdProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProducto.Location = New System.Drawing.Point(119, 257)
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.Size = New System.Drawing.Size(52, 20)
        Me.txtIdProducto.TabIndex = 6
        '
        'txtProductor
        '
        Me.txtProductor.BackColor = System.Drawing.Color.White
        Me.txtProductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductor.Location = New System.Drawing.Point(177, 205)
        Me.txtProductor.Name = "txtProductor"
        Me.txtProductor.ReadOnly = True
        Me.txtProductor.Size = New System.Drawing.Size(225, 20)
        Me.txtProductor.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "PRODUCTOR:"
        '
        'txtIdProductor
        '
        Me.txtIdProductor.BackColor = System.Drawing.Color.White
        Me.txtIdProductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdProductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProductor.Location = New System.Drawing.Point(119, 205)
        Me.txtIdProductor.Name = "txtIdProductor"
        Me.txtIdProductor.Size = New System.Drawing.Size(52, 20)
        Me.txtIdProductor.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(282, 597)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "TOTAL:"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(347, 593)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(116, 20)
        Me.txtTotal.TabIndex = 35
        '
        'spHistorial
        '
        Me.spHistorial.AccessibleDescription = ""
        Me.spHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spHistorial.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.spHistorial.Location = New System.Drawing.Point(573, 167)
        Me.spHistorial.Name = "spHistorial"
        Me.spHistorial.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spHistorial_Sheet1})
        Me.spHistorial.Size = New System.Drawing.Size(405, 420)
        Me.spHistorial.TabIndex = 37
        Me.spHistorial.Visible = False
        '
        'spHistorial_Sheet1
        '
        Me.spHistorial_Sheet1.Reset()
        spHistorial_Sheet1.SheetName = "Sheet1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(990, 675)
        Me.Controls.Add(Me.spHistorial)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtProductor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtIdProductor)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtIdProducto)
        Me.Controls.Add(Me.txtLote)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIdLote)
        Me.Controls.Add(Me.spAcarreo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox50)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1006, 713)
        Me.MinimumSize = New System.Drawing.Size(1006, 713)
        Me.Name = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spAcarreo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spAcarreo_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spHistorial_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox50 As System.Windows.Forms.PictureBox
    Friend WithEvents Encabezado3 As System.Windows.Forms.Label
    Friend WithEvents Encabezado2 As System.Windows.Forms.Label
    Friend WithEvents Encabezado1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents spAcarreo As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spAcarreo_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIdLote As System.Windows.Forms.TextBox
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents spHistorial As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spHistorial_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Button33 As System.Windows.Forms.Button

End Class
