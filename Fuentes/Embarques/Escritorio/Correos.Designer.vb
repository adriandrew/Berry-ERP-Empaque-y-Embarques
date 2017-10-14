<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Correos
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
        Me.components = New System.ComponentModel.Container()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Correos))
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        Me.spCorreos = New FarPoint.Win.Spread.FpSpread()
        Me.spCorreos_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlCapturaSuperior = New System.Windows.Forms.Panel()
        Me.chkPrecos = New System.Windows.Forms.CheckBox()
        Me.chkSellos = New System.Windows.Forms.CheckBox()
        Me.chkResponsiva = New System.Windows.Forms.CheckBox()
        Me.chkDistribucion = New System.Windows.Forms.CheckBox()
        Me.chkRemision = New System.Windows.Forms.CheckBox()
        Me.chkManifiesto = New System.Windows.Forms.CheckBox()
        Me.cbProveedores = New System.Windows.Forms.ComboBox()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkRecordar = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblLeyendaParcial = New System.Windows.Forms.Label()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnAdjuntar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.lblDescripcionTooltip = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.impresor = New System.Windows.Forms.PrintDialog()
        Me.notificador = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.pnlContenido.SuspendLayout()
        Me.pnlCuerpo.SuspendLayout()
        CType(Me.spCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spCorreos_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCapturaSuperior.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenido
        '
        Me.pnlContenido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContenido.BackColor = System.Drawing.Color.DarkSlateGray
        Me.pnlContenido.BackgroundImage = Global.EYEEmbarques.My.Resources.Resources.Logo3
        Me.pnlContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlContenido.Controls.Add(Me.pnlCuerpo)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlContenido.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(1034, 630)
        Me.pnlContenido.TabIndex = 3
        '
        'pnlCuerpo
        '
        Me.pnlCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCuerpo.AutoScroll = True
        Me.pnlCuerpo.BackColor = System.Drawing.Color.Transparent
        Me.pnlCuerpo.Controls.Add(Me.spCorreos)
        Me.pnlCuerpo.Controls.Add(Me.pnlCapturaSuperior)
        Me.pnlCuerpo.Location = New System.Drawing.Point(0, 0)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(1034, 567)
        Me.pnlCuerpo.TabIndex = 9
        '
        'spCorreos
        '
        Me.spCorreos.AccessibleDescription = ""
        Me.spCorreos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spCorreos.BackColor = System.Drawing.Color.White
        Me.spCorreos.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spCorreos.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spCorreos.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.spCorreos.HorizontalScrollBar.TabIndex = 0
        Me.spCorreos.Location = New System.Drawing.Point(472, 0)
        Me.spCorreos.Name = "spCorreos"
        Me.spCorreos.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spCorreos_Sheet1})
        Me.spCorreos.Size = New System.Drawing.Size(562, 567)
        Me.spCorreos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spCorreos.TabIndex = 0
        Me.spCorreos.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spCorreos.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spCorreos.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
        Me.spCorreos.VerticalScrollBar.TabIndex = 11
        '
        'spCorreos_Sheet1
        '
        Me.spCorreos_Sheet1.Reset()
        spCorreos_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spCorreos_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spCorreos_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCorreos_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spCorreos_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCorreos_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spCorreos_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCorreos_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spCorreos_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCorreos_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spCorreos_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCorreos_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spCorreos_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'pnlCapturaSuperior
        '
        Me.pnlCapturaSuperior.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlCapturaSuperior.AutoScroll = True
        Me.pnlCapturaSuperior.BackColor = System.Drawing.Color.White
        Me.pnlCapturaSuperior.Controls.Add(Me.chkPrecos)
        Me.pnlCapturaSuperior.Controls.Add(Me.chkSellos)
        Me.pnlCapturaSuperior.Controls.Add(Me.chkResponsiva)
        Me.pnlCapturaSuperior.Controls.Add(Me.chkDistribucion)
        Me.pnlCapturaSuperior.Controls.Add(Me.chkRemision)
        Me.pnlCapturaSuperior.Controls.Add(Me.chkManifiesto)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbProveedores)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtAsunto)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtContrasena)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtDireccion)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtMensaje)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label4)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label2)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label8)
        Me.pnlCapturaSuperior.Controls.Add(Me.chkRecordar)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label3)
        Me.pnlCapturaSuperior.Location = New System.Drawing.Point(0, 0)
        Me.pnlCapturaSuperior.Name = "pnlCapturaSuperior"
        Me.pnlCapturaSuperior.Size = New System.Drawing.Size(470, 567)
        Me.pnlCapturaSuperior.TabIndex = 24
        '
        'chkPrecos
        '
        Me.chkPrecos.AutoSize = True
        Me.chkPrecos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkPrecos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrecos.ForeColor = System.Drawing.Color.Black
        Me.chkPrecos.Location = New System.Drawing.Point(115, 460)
        Me.chkPrecos.Name = "chkPrecos"
        Me.chkPrecos.Size = New System.Drawing.Size(146, 20)
        Me.chkPrecos.TabIndex = 107
        Me.chkPrecos.Text = "FORMA PRECOS"
        Me.chkPrecos.UseVisualStyleBackColor = True
        '
        'chkSellos
        '
        Me.chkSellos.AutoSize = True
        Me.chkSellos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkSellos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSellos.ForeColor = System.Drawing.Color.Black
        Me.chkSellos.Location = New System.Drawing.Point(115, 426)
        Me.chkSellos.Name = "chkSellos"
        Me.chkSellos.Size = New System.Drawing.Size(189, 20)
        Me.chkSellos.TabIndex = 106
        Me.chkSellos.Text = "BITÁCORA DE SELLOS"
        Me.chkSellos.UseVisualStyleBackColor = True
        '
        'chkResponsiva
        '
        Me.chkResponsiva.AutoSize = True
        Me.chkResponsiva.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkResponsiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkResponsiva.ForeColor = System.Drawing.Color.Black
        Me.chkResponsiva.Location = New System.Drawing.Point(115, 392)
        Me.chkResponsiva.Name = "chkResponsiva"
        Me.chkResponsiva.Size = New System.Drawing.Size(179, 20)
        Me.chkResponsiva.TabIndex = 105
        Me.chkResponsiva.Text = "CARTA RESPONSIVA"
        Me.chkResponsiva.UseVisualStyleBackColor = True
        '
        'chkDistribucion
        '
        Me.chkDistribucion.AutoSize = True
        Me.chkDistribucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDistribucion.ForeColor = System.Drawing.Color.Black
        Me.chkDistribucion.Location = New System.Drawing.Point(115, 358)
        Me.chkDistribucion.Name = "chkDistribucion"
        Me.chkDistribucion.Size = New System.Drawing.Size(215, 20)
        Me.chkDistribucion.TabIndex = 104
        Me.chkDistribucion.Text = "DISTRIBUCIÓN DE CARGA"
        Me.chkDistribucion.UseVisualStyleBackColor = True
        '
        'chkRemision
        '
        Me.chkRemision.AutoSize = True
        Me.chkRemision.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemision.ForeColor = System.Drawing.Color.Black
        Me.chkRemision.Location = New System.Drawing.Point(115, 324)
        Me.chkRemision.Name = "chkRemision"
        Me.chkRemision.Size = New System.Drawing.Size(100, 20)
        Me.chkRemision.TabIndex = 103
        Me.chkRemision.Text = "REMISIÓN"
        Me.chkRemision.UseVisualStyleBackColor = True
        '
        'chkManifiesto
        '
        Me.chkManifiesto.AutoSize = True
        Me.chkManifiesto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkManifiesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkManifiesto.ForeColor = System.Drawing.Color.Black
        Me.chkManifiesto.Location = New System.Drawing.Point(115, 290)
        Me.chkManifiesto.Name = "chkManifiesto"
        Me.chkManifiesto.Size = New System.Drawing.Size(118, 20)
        Me.chkManifiesto.TabIndex = 102
        Me.chkManifiesto.Text = "MANIFIESTO"
        Me.chkManifiesto.UseVisualStyleBackColor = True
        '
        'cbProveedores
        '
        Me.cbProveedores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProveedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProveedores.FormattingEnabled = True
        Me.cbProveedores.Location = New System.Drawing.Point(291, 10)
        Me.cbProveedores.Name = "cbProveedores"
        Me.cbProveedores.Size = New System.Drawing.Size(175, 24)
        Me.cbProveedores.TabIndex = 101
        '
        'txtAsunto
        '
        Me.txtAsunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAsunto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAsunto.Location = New System.Drawing.Point(115, 67)
        Me.txtAsunto.Multiline = True
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAsunto.Size = New System.Drawing.Size(350, 50)
        Me.txtAsunto.TabIndex = 100
        '
        'txtContrasena
        '
        Me.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContrasena.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContrasena.Location = New System.Drawing.Point(115, 39)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasena.Size = New System.Drawing.Size(196, 22)
        Me.txtContrasena.TabIndex = 98
        '
        'txtDireccion
        '
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(115, 11)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(175, 22)
        Me.txtDireccion.TabIndex = 97
        '
        'txtMensaje
        '
        Me.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.Location = New System.Drawing.Point(115, 123)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMensaje.Size = New System.Drawing.Size(350, 152)
        Me.txtMensaje.TabIndex = 99
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "MENSAJE:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "ASUNTO:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 15)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "CONTRASEÑA: *"
        '
        'chkRecordar
        '
        Me.chkRecordar.AutoSize = True
        Me.chkRecordar.Checked = True
        Me.chkRecordar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRecordar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkRecordar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecordar.ForeColor = System.Drawing.Color.Black
        Me.chkRecordar.Location = New System.Drawing.Point(317, 40)
        Me.chkRecordar.Name = "chkRecordar"
        Me.chkRecordar.Size = New System.Drawing.Size(92, 20)
        Me.chkRecordar.TabIndex = 18
        Me.chkRecordar.Text = "Recordar"
        Me.chkRecordar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "CORREO: *"
        '
        'pnlPie
        '
        Me.pnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPie.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.lblLeyendaParcial)
        Me.pnlPie.Controls.Add(Me.btnEnviar)
        Me.pnlPie.Controls.Add(Me.btnAdjuntar)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.btnAyuda)
        Me.pnlPie.Controls.Add(Me.lblDescripcionTooltip)
        Me.pnlPie.Controls.Add(Me.btnSalir)
        Me.pnlPie.ForeColor = System.Drawing.Color.White
        Me.pnlPie.Location = New System.Drawing.Point(0, 570)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1034, 60)
        Me.pnlPie.TabIndex = 8
        '
        'lblLeyendaParcial
        '
        Me.lblLeyendaParcial.AutoSize = True
        Me.lblLeyendaParcial.BackColor = System.Drawing.Color.White
        Me.lblLeyendaParcial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLeyendaParcial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblLeyendaParcial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeyendaParcial.ForeColor = System.Drawing.Color.White
        Me.lblLeyendaParcial.Location = New System.Drawing.Point(217, 15)
        Me.lblLeyendaParcial.Name = "lblLeyendaParcial"
        Me.lblLeyendaParcial.Size = New System.Drawing.Size(0, 20)
        Me.lblLeyendaParcial.TabIndex = 57
        '
        'btnEnviar
        '
        Me.btnEnviar.BackColor = System.Drawing.Color.White
        Me.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEnviar.FlatAppearance.BorderSize = 3
        Me.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviar.Image = CType(resources.GetObject("btnEnviar.Image"), System.Drawing.Image)
        Me.btnEnviar.Location = New System.Drawing.Point(128, 0)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(60, 60)
        Me.btnEnviar.TabIndex = 55
        Me.btnEnviar.UseVisualStyleBackColor = False
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.BackColor = System.Drawing.Color.White
        Me.btnAdjuntar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdjuntar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAdjuntar.FlatAppearance.BorderSize = 3
        Me.btnAdjuntar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnAdjuntar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdjuntar.Image = CType(resources.GetObject("btnAdjuntar.Image"), System.Drawing.Image)
        Me.btnAdjuntar.Location = New System.Drawing.Point(64, 0)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(60, 60)
        Me.btnAdjuntar.TabIndex = 56
        Me.btnAdjuntar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(254, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 31)
        Me.Label1.TabIndex = 54
        '
        'btnAyuda
        '
        Me.btnAyuda.BackColor = System.Drawing.Color.White
        Me.btnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAyuda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAyuda.Enabled = False
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
        '
        'lblDescripcionTooltip
        '
        Me.lblDescripcionTooltip.AutoSize = True
        Me.lblDescripcionTooltip.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionTooltip.ForeColor = System.Drawing.Color.White
        Me.lblDescripcionTooltip.Location = New System.Drawing.Point(158, 17)
        Me.lblDescripcionTooltip.Name = "lblDescripcionTooltip"
        Me.lblDescripcionTooltip.Size = New System.Drawing.Size(0, 31)
        Me.lblDescripcionTooltip.TabIndex = 4
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSalir.FlatAppearance.BorderSize = 3
        Me.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(972, 0)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(60, 60)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'impresor
        '
        Me.impresor.UseEXDialog = True
        '
        'notificador
        '
        Me.notificador.Icon = CType(resources.GetObject("notificador.Icon"), System.Drawing.Icon)
        Me.notificador.Text = "Notificaciones"
        Me.notificador.Visible = True
        '
        'Correos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1034, 631)
        Me.Controls.Add(Me.pnlContenido)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Correos"
        Me.Text = "Correos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        CType(Me.spCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spCorreos_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCapturaSuperior.ResumeLayout(False)
        Me.pnlCapturaSuperior.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pnlContenido As System.Windows.Forms.Panel
    Private WithEvents pnlCuerpo As System.Windows.Forms.Panel
    Friend WithEvents spCorreos As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spCorreos_Sheet1 As FarPoint.Win.Spread.SheetView
    Private WithEvents pnlPie As System.Windows.Forms.Panel
    Private WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents lblDescripcionTooltip As System.Windows.Forms.Label
    Private WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblLeyendaParcial As System.Windows.Forms.Label
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents btnAdjuntar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents impresor As System.Windows.Forms.PrintDialog
    Friend WithEvents pnlCapturaSuperior As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkRecordar As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbProveedores As System.Windows.Forms.ComboBox
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents txtContrasena As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents notificador As System.Windows.Forms.NotifyIcon
    Friend WithEvents chkSellos As System.Windows.Forms.CheckBox
    Friend WithEvents chkResponsiva As System.Windows.Forms.CheckBox
    Friend WithEvents chkDistribucion As System.Windows.Forms.CheckBox
    Friend WithEvents chkRemision As System.Windows.Forms.CheckBox
    Friend WithEvents chkManifiesto As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrecos As System.Windows.Forms.CheckBox
End Class
