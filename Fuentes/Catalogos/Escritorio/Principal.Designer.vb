<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaGrayscale")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderMidnight")
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderMidnight")
        Dim NamedStyle5 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerMidnight")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle6 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaMidnght")
        Dim GeneralCellType2 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedFocusIndicatorRenderer1 As FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer()
        Dim EnhancedInterfaceRenderer1 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer3 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer4 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer5 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.rbtnContactosCorreo = New System.Windows.Forms.RadioButton()
        Me.rbtnAduanasUsa = New System.Windows.Forms.RadioButton()
        Me.rbtnAduanasMex = New System.Windows.Forms.RadioButton()
        Me.rbtnCajasTrailers = New System.Windows.Forms.RadioButton()
        Me.rbtnDocumentadores = New System.Windows.Forms.RadioButton()
        Me.rbtnChoferes = New System.Windows.Forms.RadioButton()
        Me.rbtnTrailers = New System.Windows.Forms.RadioButton()
        Me.rbtnLineasTransportes = New System.Windows.Forms.RadioButton()
        Me.rbtnClientes = New System.Windows.Forms.RadioButton()
        Me.rbtnTamaños = New System.Windows.Forms.RadioButton()
        Me.rbtnEtiquetas = New System.Windows.Forms.RadioButton()
        Me.rbtnEnvases = New System.Windows.Forms.RadioButton()
        Me.rbtnChoferesCampos = New System.Windows.Forms.RadioButton()
        Me.rbtnVariedades = New System.Windows.Forms.RadioButton()
        Me.rbtnLotes = New System.Windows.Forms.RadioButton()
        Me.rbtnProductos = New System.Windows.Forms.RadioButton()
        Me.rbtnProductores = New System.Windows.Forms.RadioButton()
        Me.spCatalogos = New FarPoint.Win.Spread.FpSpread()
        Me.spCatalogos_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.spVarios = New FarPoint.Win.Spread.FpSpread()
        Me.spVarios_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.lblDescripcionTooltip = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezadoArea = New System.Windows.Forms.Label()
        Me.lblEncabezadoUsuario = New System.Windows.Forms.Label()
        Me.lblEncabezadoEmpresa = New System.Windows.Forms.Label()
        Me.lblEncabezadoPrograma = New System.Windows.Forms.Label()
        Me.temporizador = New System.Windows.Forms.Timer(Me.components)
        Me.pnlContenido.SuspendLayout()
        Me.pnlCuerpo.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        CType(Me.spCatalogos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spCatalogos_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spVarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spVarios_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenido
        '
        Me.pnlContenido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContenido.BackColor = System.Drawing.Color.DarkSlateGray
        Me.pnlContenido.BackgroundImage = Global.EYECatalogosSinAlmacen.My.Resources.Resources.Logo3
        Me.pnlContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlContenido.Controls.Add(Me.pnlCuerpo)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Controls.Add(Me.pnlEncabezado)
        Me.pnlContenido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlContenido.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(1034, 630)
        Me.pnlContenido.TabIndex = 2
        '
        'pnlCuerpo
        '
        Me.pnlCuerpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCuerpo.AutoScroll = True
        Me.pnlCuerpo.BackColor = System.Drawing.Color.Transparent
        Me.pnlCuerpo.Controls.Add(Me.pnlMenu)
        Me.pnlCuerpo.Controls.Add(Me.spCatalogos)
        Me.pnlCuerpo.Controls.Add(Me.spVarios)
        Me.pnlCuerpo.Location = New System.Drawing.Point(3, 77)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(1028, 490)
        Me.pnlCuerpo.TabIndex = 9
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackColor = System.Drawing.Color.White
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEliminar.FlatAppearance.BorderSize = 3
        Me.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(847, 0)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 60)
        Me.btnEliminar.TabIndex = 18
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.Color.White
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGuardar.FlatAppearance.BorderSize = 3
        Me.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(908, 0)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 60)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'pnlMenu
        '
        Me.pnlMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMenu.AutoScroll = True
        Me.pnlMenu.BackColor = System.Drawing.Color.MintCream
        Me.pnlMenu.Controls.Add(Me.rbtnContactosCorreo)
        Me.pnlMenu.Controls.Add(Me.rbtnAduanasUsa)
        Me.pnlMenu.Controls.Add(Me.rbtnAduanasMex)
        Me.pnlMenu.Controls.Add(Me.rbtnCajasTrailers)
        Me.pnlMenu.Controls.Add(Me.rbtnDocumentadores)
        Me.pnlMenu.Controls.Add(Me.rbtnChoferes)
        Me.pnlMenu.Controls.Add(Me.rbtnTrailers)
        Me.pnlMenu.Controls.Add(Me.rbtnLineasTransportes)
        Me.pnlMenu.Controls.Add(Me.rbtnClientes)
        Me.pnlMenu.Controls.Add(Me.rbtnTamaños)
        Me.pnlMenu.Controls.Add(Me.rbtnEtiquetas)
        Me.pnlMenu.Controls.Add(Me.rbtnEnvases)
        Me.pnlMenu.Controls.Add(Me.rbtnChoferesCampos)
        Me.pnlMenu.Controls.Add(Me.rbtnVariedades)
        Me.pnlMenu.Controls.Add(Me.rbtnLotes)
        Me.pnlMenu.Controls.Add(Me.rbtnProductos)
        Me.pnlMenu.Controls.Add(Me.rbtnProductores)
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(1028, 40)
        Me.pnlMenu.TabIndex = 24
        '
        'rbtnContactosCorreo
        '
        Me.rbtnContactosCorreo.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnContactosCorreo.AutoSize = True
        Me.rbtnContactosCorreo.BackColor = System.Drawing.Color.Transparent
        Me.rbtnContactosCorreo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnContactosCorreo.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnContactosCorreo.FlatAppearance.BorderSize = 2
        Me.rbtnContactosCorreo.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnContactosCorreo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnContactosCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnContactosCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnContactosCorreo.ForeColor = System.Drawing.Color.Black
        Me.rbtnContactosCorreo.Location = New System.Drawing.Point(2148, 4)
        Me.rbtnContactosCorreo.Name = "rbtnContactosCorreo"
        Me.rbtnContactosCorreo.Size = New System.Drawing.Size(203, 32)
        Me.rbtnContactosCorreo.TabIndex = 19
        Me.rbtnContactosCorreo.TabStop = True
        Me.rbtnContactosCorreo.Text = "CONTACTOS CORREO"
        Me.rbtnContactosCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnContactosCorreo.UseVisualStyleBackColor = False
        '
        'rbtnAduanasUsa
        '
        Me.rbtnAduanasUsa.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnAduanasUsa.AutoSize = True
        Me.rbtnAduanasUsa.BackColor = System.Drawing.Color.Transparent
        Me.rbtnAduanasUsa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnAduanasUsa.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnAduanasUsa.FlatAppearance.BorderSize = 2
        Me.rbtnAduanasUsa.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnAduanasUsa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnAduanasUsa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnAduanasUsa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAduanasUsa.ForeColor = System.Drawing.Color.Black
        Me.rbtnAduanasUsa.Location = New System.Drawing.Point(1820, 4)
        Me.rbtnAduanasUsa.Name = "rbtnAduanasUsa"
        Me.rbtnAduanasUsa.Size = New System.Drawing.Size(137, 32)
        Me.rbtnAduanasUsa.TabIndex = 18
        Me.rbtnAduanasUsa.TabStop = True
        Me.rbtnAduanasUsa.Text = "ADUANAS USA"
        Me.rbtnAduanasUsa.UseVisualStyleBackColor = False
        '
        'rbtnAduanasMex
        '
        Me.rbtnAduanasMex.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnAduanasMex.AutoSize = True
        Me.rbtnAduanasMex.BackColor = System.Drawing.Color.Transparent
        Me.rbtnAduanasMex.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnAduanasMex.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnAduanasMex.FlatAppearance.BorderSize = 2
        Me.rbtnAduanasMex.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnAduanasMex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnAduanasMex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnAduanasMex.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAduanasMex.ForeColor = System.Drawing.Color.Black
        Me.rbtnAduanasMex.Location = New System.Drawing.Point(1678, 4)
        Me.rbtnAduanasMex.Name = "rbtnAduanasMex"
        Me.rbtnAduanasMex.Size = New System.Drawing.Size(140, 32)
        Me.rbtnAduanasMex.TabIndex = 17
        Me.rbtnAduanasMex.TabStop = True
        Me.rbtnAduanasMex.Text = "ADUANAS MEX"
        Me.rbtnAduanasMex.UseVisualStyleBackColor = False
        '
        'rbtnCajasTrailers
        '
        Me.rbtnCajasTrailers.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnCajasTrailers.AutoSize = True
        Me.rbtnCajasTrailers.BackColor = System.Drawing.Color.Transparent
        Me.rbtnCajasTrailers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnCajasTrailers.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnCajasTrailers.FlatAppearance.BorderSize = 2
        Me.rbtnCajasTrailers.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnCajasTrailers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnCajasTrailers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnCajasTrailers.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCajasTrailers.ForeColor = System.Drawing.Color.Black
        Me.rbtnCajasTrailers.Location = New System.Drawing.Point(1402, 4)
        Me.rbtnCajasTrailers.Name = "rbtnCajasTrailers"
        Me.rbtnCajasTrailers.Size = New System.Drawing.Size(158, 32)
        Me.rbtnCajasTrailers.TabIndex = 16
        Me.rbtnCajasTrailers.TabStop = True
        Me.rbtnCajasTrailers.Text = "CAJAS TRAILERS"
        Me.rbtnCajasTrailers.UseVisualStyleBackColor = False
        '
        'rbtnDocumentadores
        '
        Me.rbtnDocumentadores.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnDocumentadores.AutoSize = True
        Me.rbtnDocumentadores.BackColor = System.Drawing.Color.Transparent
        Me.rbtnDocumentadores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnDocumentadores.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnDocumentadores.FlatAppearance.BorderSize = 2
        Me.rbtnDocumentadores.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnDocumentadores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnDocumentadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnDocumentadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnDocumentadores.ForeColor = System.Drawing.Color.Black
        Me.rbtnDocumentadores.Location = New System.Drawing.Point(1959, 4)
        Me.rbtnDocumentadores.Name = "rbtnDocumentadores"
        Me.rbtnDocumentadores.Size = New System.Drawing.Size(187, 32)
        Me.rbtnDocumentadores.TabIndex = 15
        Me.rbtnDocumentadores.TabStop = True
        Me.rbtnDocumentadores.Text = "DOCUMENTADORES"
        Me.rbtnDocumentadores.UseVisualStyleBackColor = False
        '
        'rbtnChoferes
        '
        Me.rbtnChoferes.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnChoferes.AutoSize = True
        Me.rbtnChoferes.BackColor = System.Drawing.Color.Transparent
        Me.rbtnChoferes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnChoferes.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnChoferes.FlatAppearance.BorderSize = 2
        Me.rbtnChoferes.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnChoferes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnChoferes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnChoferes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnChoferes.ForeColor = System.Drawing.Color.Black
        Me.rbtnChoferes.Location = New System.Drawing.Point(1562, 4)
        Me.rbtnChoferes.Name = "rbtnChoferes"
        Me.rbtnChoferes.Size = New System.Drawing.Size(114, 32)
        Me.rbtnChoferes.TabIndex = 14
        Me.rbtnChoferes.TabStop = True
        Me.rbtnChoferes.Text = "CHOFERES"
        Me.rbtnChoferes.UseVisualStyleBackColor = False
        '
        'rbtnTrailers
        '
        Me.rbtnTrailers.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnTrailers.AutoSize = True
        Me.rbtnTrailers.BackColor = System.Drawing.Color.Transparent
        Me.rbtnTrailers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnTrailers.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnTrailers.FlatAppearance.BorderSize = 2
        Me.rbtnTrailers.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnTrailers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnTrailers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnTrailers.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnTrailers.ForeColor = System.Drawing.Color.Black
        Me.rbtnTrailers.Location = New System.Drawing.Point(1299, 4)
        Me.rbtnTrailers.Name = "rbtnTrailers"
        Me.rbtnTrailers.Size = New System.Drawing.Size(101, 32)
        Me.rbtnTrailers.TabIndex = 13
        Me.rbtnTrailers.TabStop = True
        Me.rbtnTrailers.Text = "TRAILERS"
        Me.rbtnTrailers.UseVisualStyleBackColor = False
        '
        'rbtnLineasTransportes
        '
        Me.rbtnLineasTransportes.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnLineasTransportes.AutoSize = True
        Me.rbtnLineasTransportes.BackColor = System.Drawing.Color.Transparent
        Me.rbtnLineasTransportes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnLineasTransportes.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnLineasTransportes.FlatAppearance.BorderSize = 2
        Me.rbtnLineasTransportes.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnLineasTransportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnLineasTransportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnLineasTransportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnLineasTransportes.ForeColor = System.Drawing.Color.Black
        Me.rbtnLineasTransportes.Location = New System.Drawing.Point(1100, 4)
        Me.rbtnLineasTransportes.Name = "rbtnLineasTransportes"
        Me.rbtnLineasTransportes.Size = New System.Drawing.Size(196, 32)
        Me.rbtnLineasTransportes.TabIndex = 12
        Me.rbtnLineasTransportes.TabStop = True
        Me.rbtnLineasTransportes.Text = "LINEAS TRANSPORTE"
        Me.rbtnLineasTransportes.UseVisualStyleBackColor = False
        '
        'rbtnClientes
        '
        Me.rbtnClientes.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnClientes.AutoSize = True
        Me.rbtnClientes.BackColor = System.Drawing.Color.Transparent
        Me.rbtnClientes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnClientes.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnClientes.FlatAppearance.BorderSize = 2
        Me.rbtnClientes.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnClientes.ForeColor = System.Drawing.Color.Black
        Me.rbtnClientes.Location = New System.Drawing.Point(676, 3)
        Me.rbtnClientes.Name = "rbtnClientes"
        Me.rbtnClientes.Size = New System.Drawing.Size(102, 32)
        Me.rbtnClientes.TabIndex = 11
        Me.rbtnClientes.TabStop = True
        Me.rbtnClientes.Text = "CLIENTES"
        Me.rbtnClientes.UseVisualStyleBackColor = False
        '
        'rbtnTamaños
        '
        Me.rbtnTamaños.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnTamaños.AutoSize = True
        Me.rbtnTamaños.BackColor = System.Drawing.Color.Transparent
        Me.rbtnTamaños.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnTamaños.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnTamaños.FlatAppearance.BorderSize = 2
        Me.rbtnTamaños.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnTamaños.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnTamaños.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnTamaños.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnTamaños.ForeColor = System.Drawing.Color.Black
        Me.rbtnTamaños.Location = New System.Drawing.Point(880, 3)
        Me.rbtnTamaños.Name = "rbtnTamaños"
        Me.rbtnTamaños.Size = New System.Drawing.Size(102, 32)
        Me.rbtnTamaños.TabIndex = 10
        Me.rbtnTamaños.TabStop = True
        Me.rbtnTamaños.Text = "TAMAÑOS"
        Me.rbtnTamaños.UseVisualStyleBackColor = False
        '
        'rbtnEtiquetas
        '
        Me.rbtnEtiquetas.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnEtiquetas.AutoSize = True
        Me.rbtnEtiquetas.BackColor = System.Drawing.Color.Transparent
        Me.rbtnEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnEtiquetas.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnEtiquetas.FlatAppearance.BorderSize = 2
        Me.rbtnEtiquetas.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnEtiquetas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnEtiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnEtiquetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnEtiquetas.ForeColor = System.Drawing.Color.Black
        Me.rbtnEtiquetas.Location = New System.Drawing.Point(984, 4)
        Me.rbtnEtiquetas.Name = "rbtnEtiquetas"
        Me.rbtnEtiquetas.Size = New System.Drawing.Size(114, 32)
        Me.rbtnEtiquetas.TabIndex = 9
        Me.rbtnEtiquetas.TabStop = True
        Me.rbtnEtiquetas.Text = "ETIQUETAS"
        Me.rbtnEtiquetas.UseVisualStyleBackColor = False
        '
        'rbtnEnvases
        '
        Me.rbtnEnvases.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnEnvases.AutoSize = True
        Me.rbtnEnvases.BackColor = System.Drawing.Color.Transparent
        Me.rbtnEnvases.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnEnvases.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnEnvases.FlatAppearance.BorderSize = 2
        Me.rbtnEnvases.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnEnvases.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnEnvases.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnEnvases.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnEnvases.ForeColor = System.Drawing.Color.Black
        Me.rbtnEnvases.Location = New System.Drawing.Point(780, 3)
        Me.rbtnEnvases.Name = "rbtnEnvases"
        Me.rbtnEnvases.Size = New System.Drawing.Size(98, 32)
        Me.rbtnEnvases.TabIndex = 6
        Me.rbtnEnvases.TabStop = True
        Me.rbtnEnvases.Text = "ENVASES"
        Me.rbtnEnvases.UseVisualStyleBackColor = False
        '
        'rbtnChoferesCampos
        '
        Me.rbtnChoferesCampos.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnChoferesCampos.AutoSize = True
        Me.rbtnChoferesCampos.BackColor = System.Drawing.Color.Transparent
        Me.rbtnChoferesCampos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnChoferesCampos.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnChoferesCampos.FlatAppearance.BorderSize = 2
        Me.rbtnChoferesCampos.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnChoferesCampos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnChoferesCampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnChoferesCampos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnChoferesCampos.ForeColor = System.Drawing.Color.Black
        Me.rbtnChoferesCampos.Location = New System.Drawing.Point(85, 4)
        Me.rbtnChoferesCampos.Name = "rbtnChoferesCampos"
        Me.rbtnChoferesCampos.Size = New System.Drawing.Size(179, 32)
        Me.rbtnChoferesCampos.TabIndex = 5
        Me.rbtnChoferesCampos.TabStop = True
        Me.rbtnChoferesCampos.Text = "CHOFERES CAMPO"
        Me.rbtnChoferesCampos.UseVisualStyleBackColor = False
        '
        'rbtnVariedades
        '
        Me.rbtnVariedades.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnVariedades.AutoSize = True
        Me.rbtnVariedades.BackColor = System.Drawing.Color.Transparent
        Me.rbtnVariedades.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnVariedades.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnVariedades.FlatAppearance.BorderSize = 2
        Me.rbtnVariedades.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnVariedades.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnVariedades.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnVariedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnVariedades.ForeColor = System.Drawing.Color.Black
        Me.rbtnVariedades.Location = New System.Drawing.Point(396, 4)
        Me.rbtnVariedades.Name = "rbtnVariedades"
        Me.rbtnVariedades.Size = New System.Drawing.Size(125, 32)
        Me.rbtnVariedades.TabIndex = 4
        Me.rbtnVariedades.TabStop = True
        Me.rbtnVariedades.Text = "VARIEDADES"
        Me.rbtnVariedades.UseVisualStyleBackColor = False
        '
        'rbtnLotes
        '
        Me.rbtnLotes.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnLotes.AutoSize = True
        Me.rbtnLotes.BackColor = System.Drawing.Color.Transparent
        Me.rbtnLotes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnLotes.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnLotes.FlatAppearance.BorderSize = 2
        Me.rbtnLotes.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnLotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnLotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnLotes.ForeColor = System.Drawing.Color.Black
        Me.rbtnLotes.Location = New System.Drawing.Point(7, 4)
        Me.rbtnLotes.Name = "rbtnLotes"
        Me.rbtnLotes.Size = New System.Drawing.Size(76, 32)
        Me.rbtnLotes.TabIndex = 3
        Me.rbtnLotes.TabStop = True
        Me.rbtnLotes.Text = "LOTES"
        Me.rbtnLotes.UseVisualStyleBackColor = False
        '
        'rbtnProductos
        '
        Me.rbtnProductos.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnProductos.AutoSize = True
        Me.rbtnProductos.BackColor = System.Drawing.Color.Transparent
        Me.rbtnProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnProductos.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnProductos.FlatAppearance.BorderSize = 2
        Me.rbtnProductos.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnProductos.ForeColor = System.Drawing.Color.Black
        Me.rbtnProductos.Location = New System.Drawing.Point(266, 4)
        Me.rbtnProductos.Name = "rbtnProductos"
        Me.rbtnProductos.Size = New System.Drawing.Size(128, 32)
        Me.rbtnProductos.TabIndex = 2
        Me.rbtnProductos.TabStop = True
        Me.rbtnProductos.Text = "PRODUCTOS"
        Me.rbtnProductos.UseVisualStyleBackColor = False
        '
        'rbtnProductores
        '
        Me.rbtnProductores.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnProductores.AutoSize = True
        Me.rbtnProductores.BackColor = System.Drawing.Color.Transparent
        Me.rbtnProductores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtnProductores.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnProductores.FlatAppearance.BorderSize = 2
        Me.rbtnProductores.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnProductores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnProductores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnProductores.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnProductores.ForeColor = System.Drawing.Color.Black
        Me.rbtnProductores.Location = New System.Drawing.Point(523, 3)
        Me.rbtnProductores.Name = "rbtnProductores"
        Me.rbtnProductores.Size = New System.Drawing.Size(151, 32)
        Me.rbtnProductores.TabIndex = 0
        Me.rbtnProductores.TabStop = True
        Me.rbtnProductores.Text = "PRODUCTORES"
        Me.rbtnProductores.UseVisualStyleBackColor = False
        '
        'spCatalogos
        '
        Me.spCatalogos.AccessibleDescription = ""
        Me.spCatalogos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.spCatalogos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spCatalogos.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spCatalogos.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.Black
        EnhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.DarkSlateBlue
        Me.spCatalogos.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.spCatalogos.HorizontalScrollBar.TabIndex = 10
        Me.spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.spCatalogos.Location = New System.Drawing.Point(3, 41)
        Me.spCatalogos.Name = "spCatalogos"
        NamedStyle1.ForeColor = System.Drawing.Color.White
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.Locked = False
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.Color.Gainsboro
        NamedStyle2.CellType = GeneralCellType1
        NamedStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle2.Locked = False
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle2.Renderer = GeneralCellType1
        NamedStyle3.BackColor = System.Drawing.Color.DarkSlateBlue
        NamedStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle3.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle4.BackColor = System.Drawing.Color.DarkSlateBlue
        NamedStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle4.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle4.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle4.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle5.BackColor = System.Drawing.Color.MidnightBlue
        NamedStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle5.NoteIndicatorColor = System.Drawing.Color.Red
        EnhancedCornerRenderer1.ActiveBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedCornerRenderer1.GridLineColor = System.Drawing.Color.Empty
        EnhancedCornerRenderer1.NormalBackgroundColor = System.Drawing.Color.MidnightBlue
        NamedStyle5.Renderer = EnhancedCornerRenderer1
        NamedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        NamedStyle6.CellType = GeneralCellType2
        NamedStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle6.Locked = False
        NamedStyle6.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle6.Renderer = GeneralCellType2
        Me.spCatalogos.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4, NamedStyle5, NamedStyle6})
        Me.spCatalogos.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spCatalogos_Sheet1})
        Me.spCatalogos.Size = New System.Drawing.Size(221, 183)
        SpreadSkin1.ColumnFooterDefaultStyle = NamedStyle3
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle3
        SpreadSkin1.CornerDefaultStyle = NamedStyle5
        SpreadSkin1.DefaultStyle = NamedStyle6
        SpreadSkin1.FocusRenderer = EnhancedFocusIndicatorRenderer1
        EnhancedInterfaceRenderer1.ArrowColorEnabled = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer1.GrayAreaColor = System.Drawing.Color.LightSlateGray
        EnhancedInterfaceRenderer1.RangeGroupBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer1.RangeGroupButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer1.RangeGroupLineColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer1.ScrollBoxBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedInterfaceRenderer1.SheetTabBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer1.SheetTabLowerActiveColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer1.SheetTabLowerNormalColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer1.SheetTabUpperActiveColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer1.SheetTabUpperNormalColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer1.SplitBarBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer1.SplitBarDarkColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer1.SplitBarLightColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer1.SplitBoxBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer1.SplitBoxBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer1.TabStripBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedInterfaceRenderer1.TabStripButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer1.TabStripButtonFlatStyle = System.Windows.Forms.FlatStyle.Flat
        EnhancedInterfaceRenderer1.TabStripButtonLowerActiveColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer1.TabStripButtonLowerNormalColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer1.TabStripButtonLowerPressedColor = System.Drawing.Color.DimGray
        EnhancedInterfaceRenderer1.TabStripButtonUpperActiveColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer1.TabStripButtonUpperNormalColor = System.Drawing.Color.SlateBlue
        EnhancedInterfaceRenderer1.TabStripButtonUpperPressedColor = System.Drawing.Color.DarkSlateBlue
        SpreadSkin1.InterfaceRenderer = EnhancedInterfaceRenderer1
        SpreadSkin1.Name = "MidnightPersonalizado"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle4
        EnhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.Black
        EnhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.DarkSlateBlue
        SpreadSkin1.ScrollBarRenderer = EnhancedScrollBarRenderer2
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.GradientSelectionRenderer(System.Drawing.Color.MidnightBlue, System.Drawing.Color.MidnightBlue, System.Drawing.Drawing2D.LinearGradientMode.Horizontal, 80)
        Me.spCatalogos.Skin = SpreadSkin1
        Me.spCatalogos.TabIndex = 22
        Me.spCatalogos.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spCatalogos.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer3.ArrowColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer3.ArrowHoveredColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer3.ArrowSelectedColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer3.ButtonBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer3.ButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer3.ButtonHoveredBackgroundColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer3.ButtonHoveredBorderColor = System.Drawing.Color.Black
        EnhancedScrollBarRenderer3.ButtonSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer3.ButtonSelectedBorderColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer3.TrackBarBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer3.TrackBarSelectedBackgroundColor = System.Drawing.Color.DarkSlateBlue
        Me.spCatalogos.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer3
        Me.spCatalogos.VerticalScrollBar.TabIndex = 11
        Me.spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.spCatalogos.Visible = False
        '
        'spCatalogos_Sheet1
        '
        Me.spCatalogos_Sheet1.Reset()
        spCatalogos_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spCatalogos_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spCatalogos_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCatalogos_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderMidnight"
        Me.spCatalogos_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCatalogos_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerMidnight"
        Me.spCatalogos_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCatalogos_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderMidnight"
        Me.spCatalogos_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCatalogos_Sheet1.DefaultStyle.Parent = "DataAreaMidnght"
        Me.spCatalogos_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCatalogos_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderMidnight"
        Me.spCatalogos_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spCatalogos_Sheet1.SheetCornerStyle.Parent = "CornerMidnight"
        Me.spCatalogos_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'spVarios
        '
        Me.spVarios.AccessibleDescription = ""
        Me.spVarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.spVarios.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spVarios.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer4.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer4.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer4.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer4.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer4.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer4.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer4.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer4.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer4.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer4.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer4.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spVarios.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer4
        Me.spVarios.HorizontalScrollBar.TabIndex = 2
        Me.spVarios.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.spVarios.Location = New System.Drawing.Point(3, 42)
        Me.spVarios.Name = "spVarios"
        Me.spVarios.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spVarios_Sheet1})
        Me.spVarios.Size = New System.Drawing.Size(1022, 445)
        Me.spVarios.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spVarios.TabIndex = 27
        Me.spVarios.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spVarios.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer5.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer5.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer5.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer5.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer5.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer5.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer5.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer5.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer5.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer5.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer5.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spVarios.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer5
        Me.spVarios.VerticalScrollBar.TabIndex = 3
        Me.spVarios.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.spVarios.Visible = False
        '
        'spVarios_Sheet1
        '
        Me.spVarios_Sheet1.Reset()
        spVarios_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spVarios_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spVarios_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spVarios_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spVarios_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spVarios_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spVarios_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spVarios_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spVarios_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spVarios_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spVarios_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spVarios_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spVarios_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'pnlPie
        '
        Me.pnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPie.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.btnEliminar)
        Me.pnlPie.Controls.Add(Me.btnAyuda)
        Me.pnlPie.Controls.Add(Me.btnGuardar)
        Me.pnlPie.Controls.Add(Me.lblDescripcionTooltip)
        Me.pnlPie.Controls.Add(Me.btnSalir)
        Me.pnlPie.ForeColor = System.Drawing.Color.White
        Me.pnlPie.Location = New System.Drawing.Point(0, 570)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1034, 60)
        Me.pnlPie.TabIndex = 8
        '
        'btnAyuda
        '
        Me.btnAyuda.BackColor = System.Drawing.Color.White
        Me.btnAyuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
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
        '
        'lblDescripcionTooltip
        '
        Me.lblDescripcionTooltip.AutoSize = True
        Me.lblDescripcionTooltip.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionTooltip.ForeColor = System.Drawing.Color.White
        Me.lblDescripcionTooltip.Location = New System.Drawing.Point(101, 17)
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
        'pnlEncabezado
        '
        Me.pnlEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoArea)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoUsuario)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoEmpresa)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoPrograma)
        Me.pnlEncabezado.ForeColor = System.Drawing.Color.White
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1034, 75)
        Me.pnlEncabezado.TabIndex = 7
        '
        'lblEncabezadoArea
        '
        Me.lblEncabezadoArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEncabezadoArea.AutoSize = True
        Me.lblEncabezadoArea.BackColor = System.Drawing.Color.Transparent
        Me.lblEncabezadoArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoArea.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoArea.Location = New System.Drawing.Point(599, 0)
        Me.lblEncabezadoArea.Name = "lblEncabezadoArea"
        Me.lblEncabezadoArea.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoArea.TabIndex = 5
        '
        'lblEncabezadoUsuario
        '
        Me.lblEncabezadoUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEncabezadoUsuario.AutoSize = True
        Me.lblEncabezadoUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lblEncabezadoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoUsuario.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoUsuario.Location = New System.Drawing.Point(599, 35)
        Me.lblEncabezadoUsuario.Name = "lblEncabezadoUsuario"
        Me.lblEncabezadoUsuario.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoUsuario.TabIndex = 4
        '
        'lblEncabezadoEmpresa
        '
        Me.lblEncabezadoEmpresa.AutoSize = True
        Me.lblEncabezadoEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.lblEncabezadoEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoEmpresa.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoEmpresa.Location = New System.Drawing.Point(12, 35)
        Me.lblEncabezadoEmpresa.Name = "lblEncabezadoEmpresa"
        Me.lblEncabezadoEmpresa.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoEmpresa.TabIndex = 1
        '
        'lblEncabezadoPrograma
        '
        Me.lblEncabezadoPrograma.AutoSize = True
        Me.lblEncabezadoPrograma.BackColor = System.Drawing.Color.Transparent
        Me.lblEncabezadoPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoPrograma.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoPrograma.Location = New System.Drawing.Point(12, 0)
        Me.lblEncabezadoPrograma.Name = "lblEncabezadoPrograma"
        Me.lblEncabezadoPrograma.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoPrograma.TabIndex = 0
        '
        'temporizador
        '
        Me.temporizador.Interval = 1
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1034, 631)
        Me.Controls.Add(Me.pnlContenido)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Principal"
        Me.Text = "Empaque y Embarques - Catálogos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        CType(Me.spCatalogos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spCatalogos_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spVarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spVarios_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pnlContenido As System.Windows.Forms.Panel
    Private WithEvents pnlCuerpo As System.Windows.Forms.Panel
    Private WithEvents pnlPie As System.Windows.Forms.Panel
    Private WithEvents btnSalir As System.Windows.Forms.Button
    Private WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Private WithEvents lblEncabezadoEmpresa As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoPrograma As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoArea As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoUsuario As System.Windows.Forms.Label
    Private WithEvents btnEliminar As System.Windows.Forms.Button
    Private WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblDescripcionTooltip As System.Windows.Forms.Label
    Private WithEvents spCatalogos As FarPoint.Win.Spread.FpSpread
    Private WithEvents spCatalogos_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents temporizador As System.Windows.Forms.Timer
    Private WithEvents btnAyuda As System.Windows.Forms.Button
    Private WithEvents pnlMenu As System.Windows.Forms.Panel
    Private WithEvents rbtnVariedades As System.Windows.Forms.RadioButton
    Private WithEvents rbtnLotes As System.Windows.Forms.RadioButton
    Private WithEvents rbtnProductos As System.Windows.Forms.RadioButton
    Private WithEvents rbtnProductores As System.Windows.Forms.RadioButton
    Private WithEvents spVarios As FarPoint.Win.Spread.FpSpread
    Private WithEvents spVarios_Sheet1 As FarPoint.Win.Spread.SheetView
    Private WithEvents rbtnChoferesCampos As System.Windows.Forms.RadioButton
    Private WithEvents rbtnEnvases As System.Windows.Forms.RadioButton
    Private WithEvents rbtnEtiquetas As System.Windows.Forms.RadioButton
    Private WithEvents rbtnTamaños As System.Windows.Forms.RadioButton
    Private WithEvents rbtnClientes As System.Windows.Forms.RadioButton
    Private WithEvents rbtnLineasTransportes As System.Windows.Forms.RadioButton
    Private WithEvents rbtnTrailers As System.Windows.Forms.RadioButton
    Private WithEvents rbtnChoferes As System.Windows.Forms.RadioButton
    Private WithEvents rbtnDocumentadores As System.Windows.Forms.RadioButton
    Private WithEvents rbtnCajasTrailers As System.Windows.Forms.RadioButton
    Private WithEvents rbtnAduanasMex As System.Windows.Forms.RadioButton
    Private WithEvents rbtnAduanasUsa As System.Windows.Forms.RadioButton
    Private WithEvents rbtnContactosCorreo As System.Windows.Forms.RadioButton
End Class
