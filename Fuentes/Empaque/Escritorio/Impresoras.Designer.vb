<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Impresoras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Impresoras))
        Me.pnlConfiguracion = New System.Windows.Forms.Panel()
        Me.gbEtiquetasCajas = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMargenDerechoCajas = New System.Windows.Forms.TextBox()
        Me.chkImprimirCajas = New System.Windows.Forms.CheckBox()
        Me.cbImpresorasCajas = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMargenIzquierdoCajas = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbEtiquetasTarimas = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMargenDerechoTarimas = New System.Windows.Forms.TextBox()
        Me.cbImpresorasTarimas = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkImprimirTarimas = New System.Windows.Forms.CheckBox()
        Me.txtMargenIzquierdoTarimas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.lblDescripcionTooltip = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlConfiguracion.SuspendLayout()
        Me.gbEtiquetasCajas.SuspendLayout()
        Me.gbEtiquetasTarimas.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlConfiguracion
        '
        Me.pnlConfiguracion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlConfiguracion.BackColor = System.Drawing.Color.White
        Me.pnlConfiguracion.Controls.Add(Me.gbEtiquetasCajas)
        Me.pnlConfiguracion.Controls.Add(Me.gbEtiquetasTarimas)
        Me.pnlConfiguracion.Location = New System.Drawing.Point(3, 5)
        Me.pnlConfiguracion.Name = "pnlConfiguracion"
        Me.pnlConfiguracion.Size = New System.Drawing.Size(586, 341)
        Me.pnlConfiguracion.TabIndex = 24
        '
        'gbEtiquetasCajas
        '
        Me.gbEtiquetasCajas.BackColor = System.Drawing.Color.Transparent
        Me.gbEtiquetasCajas.Controls.Add(Me.Label2)
        Me.gbEtiquetasCajas.Controls.Add(Me.txtMargenDerechoCajas)
        Me.gbEtiquetasCajas.Controls.Add(Me.chkImprimirCajas)
        Me.gbEtiquetasCajas.Controls.Add(Me.cbImpresorasCajas)
        Me.gbEtiquetasCajas.Controls.Add(Me.Label3)
        Me.gbEtiquetasCajas.Controls.Add(Me.txtMargenIzquierdoCajas)
        Me.gbEtiquetasCajas.Controls.Add(Me.Label5)
        Me.gbEtiquetasCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEtiquetasCajas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.gbEtiquetasCajas.Location = New System.Drawing.Point(3, 180)
        Me.gbEtiquetasCajas.Name = "gbEtiquetasCajas"
        Me.gbEtiquetasCajas.Size = New System.Drawing.Size(579, 150)
        Me.gbEtiquetasCajas.TabIndex = 38
        Me.gbEtiquetasCajas.TabStop = False
        Me.gbEtiquetasCajas.Text = "ETIQUETAS DE CAJAS"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(5, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(381, 20)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "IMPRESORA *"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMargenDerechoCajas
        '
        Me.txtMargenDerechoCajas.BackColor = System.Drawing.Color.White
        Me.txtMargenDerechoCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMargenDerechoCajas.ForeColor = System.Drawing.Color.Black
        Me.txtMargenDerechoCajas.Location = New System.Drawing.Point(514, 69)
        Me.txtMargenDerechoCajas.MaxLength = 2
        Me.txtMargenDerechoCajas.Name = "txtMargenDerechoCajas"
        Me.txtMargenDerechoCajas.Size = New System.Drawing.Size(30, 22)
        Me.txtMargenDerechoCajas.TabIndex = 35
        Me.txtMargenDerechoCajas.Text = "0"
        Me.txtMargenDerechoCajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkImprimirCajas
        '
        Me.chkImprimirCajas.AutoSize = True
        Me.chkImprimirCajas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkImprimirCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImprimirCajas.ForeColor = System.Drawing.Color.Black
        Me.chkImprimirCajas.Location = New System.Drawing.Point(5, 103)
        Me.chkImprimirCajas.Name = "chkImprimirCajas"
        Me.chkImprimirCajas.Size = New System.Drawing.Size(105, 20)
        Me.chkImprimirCajas.TabIndex = 30
        Me.chkImprimirCajas.Text = "IMPRIMIR *"
        Me.chkImprimirCajas.UseVisualStyleBackColor = True
        '
        'cbImpresorasCajas
        '
        Me.cbImpresorasCajas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbImpresorasCajas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbImpresorasCajas.BackColor = System.Drawing.Color.White
        Me.cbImpresorasCajas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbImpresorasCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpresorasCajas.ForeColor = System.Drawing.Color.Black
        Me.cbImpresorasCajas.FormattingEnabled = True
        Me.cbImpresorasCajas.Location = New System.Drawing.Point(5, 69)
        Me.cbImpresorasCajas.Name = "cbImpresorasCajas"
        Me.cbImpresorasCajas.Size = New System.Drawing.Size(381, 24)
        Me.cbImpresorasCajas.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(487, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 15)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "SUPERIOR *"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMargenIzquierdoCajas
        '
        Me.txtMargenIzquierdoCajas.BackColor = System.Drawing.Color.White
        Me.txtMargenIzquierdoCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMargenIzquierdoCajas.ForeColor = System.Drawing.Color.Black
        Me.txtMargenIzquierdoCajas.Location = New System.Drawing.Point(420, 69)
        Me.txtMargenIzquierdoCajas.MaxLength = 2
        Me.txtMargenIzquierdoCajas.Name = "txtMargenIzquierdoCajas"
        Me.txtMargenIzquierdoCajas.Size = New System.Drawing.Size(30, 22)
        Me.txtMargenIzquierdoCajas.TabIndex = 33
        Me.txtMargenIzquierdoCajas.Text = "0"
        Me.txtMargenIzquierdoCajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(391, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 15)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "IZQUIERDO *"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbEtiquetasTarimas
        '
        Me.gbEtiquetasTarimas.BackColor = System.Drawing.Color.Transparent
        Me.gbEtiquetasTarimas.Controls.Add(Me.Label8)
        Me.gbEtiquetasTarimas.Controls.Add(Me.txtMargenDerechoTarimas)
        Me.gbEtiquetasTarimas.Controls.Add(Me.cbImpresorasTarimas)
        Me.gbEtiquetasTarimas.Controls.Add(Me.Label1)
        Me.gbEtiquetasTarimas.Controls.Add(Me.chkImprimirTarimas)
        Me.gbEtiquetasTarimas.Controls.Add(Me.txtMargenIzquierdoTarimas)
        Me.gbEtiquetasTarimas.Controls.Add(Me.Label4)
        Me.gbEtiquetasTarimas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEtiquetasTarimas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.gbEtiquetasTarimas.Location = New System.Drawing.Point(3, 9)
        Me.gbEtiquetasTarimas.Name = "gbEtiquetasTarimas"
        Me.gbEtiquetasTarimas.Size = New System.Drawing.Size(579, 150)
        Me.gbEtiquetasTarimas.TabIndex = 37
        Me.gbEtiquetasTarimas.TabStop = False
        Me.gbEtiquetasTarimas.Text = "ETIQUETAS DE TARIMAS"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(5, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(381, 20)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "IMPRESORA *"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMargenDerechoTarimas
        '
        Me.txtMargenDerechoTarimas.BackColor = System.Drawing.Color.White
        Me.txtMargenDerechoTarimas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMargenDerechoTarimas.ForeColor = System.Drawing.Color.Black
        Me.txtMargenDerechoTarimas.Location = New System.Drawing.Point(514, 65)
        Me.txtMargenDerechoTarimas.MaxLength = 2
        Me.txtMargenDerechoTarimas.Name = "txtMargenDerechoTarimas"
        Me.txtMargenDerechoTarimas.Size = New System.Drawing.Size(30, 22)
        Me.txtMargenDerechoTarimas.TabIndex = 35
        Me.txtMargenDerechoTarimas.Text = "0"
        Me.txtMargenDerechoTarimas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbImpresorasTarimas
        '
        Me.cbImpresorasTarimas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbImpresorasTarimas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbImpresorasTarimas.BackColor = System.Drawing.Color.White
        Me.cbImpresorasTarimas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbImpresorasTarimas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpresorasTarimas.ForeColor = System.Drawing.Color.Black
        Me.cbImpresorasTarimas.FormattingEnabled = True
        Me.cbImpresorasTarimas.Location = New System.Drawing.Point(5, 65)
        Me.cbImpresorasTarimas.Name = "cbImpresorasTarimas"
        Me.cbImpresorasTarimas.Size = New System.Drawing.Size(381, 24)
        Me.cbImpresorasTarimas.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(487, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 15)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "SUPERIOR *"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkImprimirTarimas
        '
        Me.chkImprimirTarimas.AutoSize = True
        Me.chkImprimirTarimas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkImprimirTarimas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImprimirTarimas.ForeColor = System.Drawing.Color.Black
        Me.chkImprimirTarimas.Location = New System.Drawing.Point(8, 95)
        Me.chkImprimirTarimas.Name = "chkImprimirTarimas"
        Me.chkImprimirTarimas.Size = New System.Drawing.Size(105, 20)
        Me.chkImprimirTarimas.TabIndex = 31
        Me.chkImprimirTarimas.Text = "IMPRIMIR *"
        Me.chkImprimirTarimas.UseVisualStyleBackColor = True
        '
        'txtMargenIzquierdoTarimas
        '
        Me.txtMargenIzquierdoTarimas.BackColor = System.Drawing.Color.White
        Me.txtMargenIzquierdoTarimas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMargenIzquierdoTarimas.ForeColor = System.Drawing.Color.Black
        Me.txtMargenIzquierdoTarimas.Location = New System.Drawing.Point(420, 65)
        Me.txtMargenIzquierdoTarimas.MaxLength = 2
        Me.txtMargenIzquierdoTarimas.Name = "txtMargenIzquierdoTarimas"
        Me.txtMargenIzquierdoTarimas.Size = New System.Drawing.Size(30, 22)
        Me.txtMargenIzquierdoTarimas.TabIndex = 33
        Me.txtMargenIzquierdoTarimas.Text = "0"
        Me.txtMargenIzquierdoTarimas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(391, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 15)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "IZQUIERDO *"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.Color.White
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGuardar.FlatAppearance.BorderSize = 3
        Me.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(468, 0)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 60)
        Me.btnGuardar.TabIndex = 18
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'pnlPie
        '
        Me.pnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPie.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.btnGuardar)
        Me.pnlPie.Controls.Add(Me.btnAyuda)
        Me.pnlPie.Controls.Add(Me.lblDescripcionTooltip)
        Me.pnlPie.Controls.Add(Me.btnSalir)
        Me.pnlPie.ForeColor = System.Drawing.Color.White
        Me.pnlPie.Location = New System.Drawing.Point(0, 348)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(593, 60)
        Me.pnlPie.TabIndex = 25
        '
        'btnAyuda
        '
        Me.btnAyuda.BackColor = System.Drawing.Color.White
        Me.btnAyuda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAyuda.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAyuda.FlatAppearance.BorderSize = 3
        Me.btnAyuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAyuda.ForeColor = System.Drawing.Color.Black
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Location = New System.Drawing.Point(0, 0)
        Me.btnAyuda.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(60, 60)
        Me.btnAyuda.TabIndex = 5
        Me.btnAyuda.UseVisualStyleBackColor = False
        Me.btnAyuda.Visible = False
        '
        'lblDescripcionTooltip
        '
        Me.lblDescripcionTooltip.AutoSize = True
        Me.lblDescripcionTooltip.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionTooltip.ForeColor = System.Drawing.Color.White
        Me.lblDescripcionTooltip.Location = New System.Drawing.Point(200, 17)
        Me.lblDescripcionTooltip.Name = "lblDescripcionTooltip"
        Me.lblDescripcionTooltip.Size = New System.Drawing.Size(0, 31)
        Me.lblDescripcionTooltip.TabIndex = 4
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSalir.FlatAppearance.BorderSize = 3
        Me.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(531, 0)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(60, 60)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'Impresoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(592, 408)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlConfiguracion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Impresoras"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configurar Impresoras"
        Me.pnlConfiguracion.ResumeLayout(False)
        Me.gbEtiquetasCajas.ResumeLayout(False)
        Me.gbEtiquetasCajas.PerformLayout()
        Me.gbEtiquetasTarimas.ResumeLayout(False)
        Me.gbEtiquetasTarimas.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlConfiguracion As System.Windows.Forms.Panel
    Friend WithEvents txtMargenIzquierdoTarimas As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkImprimirTarimas As System.Windows.Forms.CheckBox
    Friend WithEvents chkImprimirCajas As System.Windows.Forms.CheckBox
    Friend WithEvents cbImpresorasTarimas As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMargenDerechoTarimas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbEtiquetasTarimas As System.Windows.Forms.GroupBox
    Friend WithEvents gbEtiquetasCajas As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMargenDerechoCajas As System.Windows.Forms.TextBox
    Friend WithEvents cbImpresorasCajas As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMargenIzquierdoCajas As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents pnlPie As System.Windows.Forms.Panel
    Private WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents lblDescripcionTooltip As System.Windows.Forms.Label
    Private WithEvents btnSalir As System.Windows.Forms.Button
    Private WithEvents btnGuardar As System.Windows.Forms.Button
End Class
