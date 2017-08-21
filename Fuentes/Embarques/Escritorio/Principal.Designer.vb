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
        Dim EnhancedScrollBarRenderer6 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim NamedStyle7 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim NamedStyle8 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaGrayscale")
        Dim GeneralCellType3 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim NamedStyle9 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderMidnight")
        Dim NamedStyle10 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderMidnight")
        Dim NamedStyle11 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerMidnight")
        Dim EnhancedCornerRenderer2 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle12 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaMidnght")
        Dim GeneralCellType4 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin2 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedFocusIndicatorRenderer2 As FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer()
        Dim EnhancedInterfaceRenderer2 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim EnhancedScrollBarRenderer7 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer8 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        Me.pnlDocumentos = New System.Windows.Forms.Panel()
        Me.btnPrecos = New System.Windows.Forms.Button()
        Me.btnBitacoraSellos = New System.Windows.Forms.Button()
        Me.btnCartaResponsiva = New System.Windows.Forms.Button()
        Me.btnDistribucionCarga = New System.Windows.Forms.Button()
        Me.btnRemision = New System.Windows.Forms.Button()
        Me.btnManifiesto = New System.Windows.Forms.Button()
        Me.pnlCatalogos = New System.Windows.Forms.Panel()
        Me.spCatalogos = New FarPoint.Win.Spread.FpSpread()
        Me.spCatalogos_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlCapturaSuperior = New System.Windows.Forms.Panel()
        Me.btnMostrarOcultar = New System.Windows.Forms.Button()
        Me.rbtnExportacion = New System.Windows.Forms.RadioButton()
        Me.rbtnNacional = New System.Windows.Forms.RadioButton()
        Me.txtGuiaCaades = New System.Windows.Forms.TextBox()
        Me.lblGuiaCaades = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSello8 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtSello7 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtSello6 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtSello5 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtSello4 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSello3 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtSello2 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSello1 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtHoraPrecos = New System.Windows.Forms.MaskedTextBox()
        Me.lblHoraPrecos = New System.Windows.Forms.Label()
        Me.txtPrecioFlete = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTermografo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTemperatura = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbDocumentadores = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbAduanasUsa = New System.Windows.Forms.ComboBox()
        Me.lblAduanaUsa = New System.Windows.Forms.Label()
        Me.cbAduanasMex = New System.Windows.Forms.ComboBox()
        Me.lblAduanaMex = New System.Windows.Forms.Label()
        Me.cbCajasTrailers = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbChoferes = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbTrailers = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbLineasTransportes = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbClientes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbEmbarcadores = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnIdSiguiente = New System.Windows.Forms.Button()
        Me.btnIdAnterior = New System.Windows.Forms.Button()
        Me.chkConservarDatos = New System.Windows.Forms.CheckBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.spEmbarques = New FarPoint.Win.Spread.FpSpread()
        Me.spEmbarques_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.btnGenerarDocumentos = New System.Windows.Forms.Button()
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
        Me.pnlDocumentos.SuspendLayout()
        Me.pnlCatalogos.SuspendLayout()
        CType(Me.spCatalogos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spCatalogos_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCapturaSuperior.SuspendLayout()
        CType(Me.spEmbarques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spEmbarques_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlContenido.BackgroundImage = Global.Embarques.My.Resources.Resources.Logo3
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
        Me.pnlCuerpo.Controls.Add(Me.pnlDocumentos)
        Me.pnlCuerpo.Controls.Add(Me.pnlCatalogos)
        Me.pnlCuerpo.Controls.Add(Me.pnlCapturaSuperior)
        Me.pnlCuerpo.Controls.Add(Me.btnEliminar)
        Me.pnlCuerpo.Controls.Add(Me.btnGuardar)
        Me.pnlCuerpo.Controls.Add(Me.spEmbarques)
        Me.pnlCuerpo.Location = New System.Drawing.Point(3, 77)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(1028, 490)
        Me.pnlCuerpo.TabIndex = 9
        '
        'pnlDocumentos
        '
        Me.pnlDocumentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.pnlDocumentos.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDocumentos.Controls.Add(Me.btnPrecos)
        Me.pnlDocumentos.Controls.Add(Me.btnBitacoraSellos)
        Me.pnlDocumentos.Controls.Add(Me.btnCartaResponsiva)
        Me.pnlDocumentos.Controls.Add(Me.btnDistribucionCarga)
        Me.pnlDocumentos.Controls.Add(Me.btnRemision)
        Me.pnlDocumentos.Controls.Add(Me.btnManifiesto)
        Me.pnlDocumentos.Location = New System.Drawing.Point(409, 0)
        Me.pnlDocumentos.Name = "pnlDocumentos"
        Me.pnlDocumentos.Size = New System.Drawing.Size(285, 490)
        Me.pnlDocumentos.TabIndex = 25
        Me.pnlDocumentos.Visible = False
        '
        'btnPrecos
        '
        Me.btnPrecos.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrecos.BackColor = System.Drawing.Color.White
        Me.btnPrecos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrecos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPrecos.FlatAppearance.BorderSize = 0
        Me.btnPrecos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnPrecos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrecos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrecos.Location = New System.Drawing.Point(13, 340)
        Me.btnPrecos.Name = "btnPrecos"
        Me.btnPrecos.Size = New System.Drawing.Size(258, 41)
        Me.btnPrecos.TabIndex = 5
        Me.btnPrecos.Text = "PRECOS"
        Me.btnPrecos.UseVisualStyleBackColor = False
        '
        'btnBitacoraSellos
        '
        Me.btnBitacoraSellos.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBitacoraSellos.BackColor = System.Drawing.Color.White
        Me.btnBitacoraSellos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBitacoraSellos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBitacoraSellos.FlatAppearance.BorderSize = 0
        Me.btnBitacoraSellos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnBitacoraSellos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBitacoraSellos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBitacoraSellos.Location = New System.Drawing.Point(13, 293)
        Me.btnBitacoraSellos.Name = "btnBitacoraSellos"
        Me.btnBitacoraSellos.Size = New System.Drawing.Size(258, 41)
        Me.btnBitacoraSellos.TabIndex = 4
        Me.btnBitacoraSellos.Text = "BITÁCORA DE SELLOS"
        Me.btnBitacoraSellos.UseVisualStyleBackColor = False
        '
        'btnCartaResponsiva
        '
        Me.btnCartaResponsiva.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCartaResponsiva.BackColor = System.Drawing.Color.White
        Me.btnCartaResponsiva.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCartaResponsiva.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCartaResponsiva.FlatAppearance.BorderSize = 0
        Me.btnCartaResponsiva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnCartaResponsiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCartaResponsiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCartaResponsiva.Location = New System.Drawing.Point(13, 246)
        Me.btnCartaResponsiva.Name = "btnCartaResponsiva"
        Me.btnCartaResponsiva.Size = New System.Drawing.Size(258, 41)
        Me.btnCartaResponsiva.TabIndex = 3
        Me.btnCartaResponsiva.Text = "CARTA RESPONSIVA"
        Me.btnCartaResponsiva.UseVisualStyleBackColor = False
        '
        'btnDistribucionCarga
        '
        Me.btnDistribucionCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDistribucionCarga.BackColor = System.Drawing.Color.White
        Me.btnDistribucionCarga.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDistribucionCarga.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDistribucionCarga.FlatAppearance.BorderSize = 0
        Me.btnDistribucionCarga.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnDistribucionCarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDistribucionCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDistribucionCarga.Location = New System.Drawing.Point(13, 199)
        Me.btnDistribucionCarga.Name = "btnDistribucionCarga"
        Me.btnDistribucionCarga.Size = New System.Drawing.Size(258, 41)
        Me.btnDistribucionCarga.TabIndex = 2
        Me.btnDistribucionCarga.Text = "DISTRIBUCIÓN DE CARGA"
        Me.btnDistribucionCarga.UseVisualStyleBackColor = False
        '
        'btnRemision
        '
        Me.btnRemision.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemision.BackColor = System.Drawing.Color.White
        Me.btnRemision.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemision.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnRemision.FlatAppearance.BorderSize = 0
        Me.btnRemision.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnRemision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemision.Location = New System.Drawing.Point(13, 152)
        Me.btnRemision.Name = "btnRemision"
        Me.btnRemision.Size = New System.Drawing.Size(258, 41)
        Me.btnRemision.TabIndex = 1
        Me.btnRemision.Text = "REMISIÓN"
        Me.btnRemision.UseVisualStyleBackColor = False
        '
        'btnManifiesto
        '
        Me.btnManifiesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnManifiesto.BackColor = System.Drawing.Color.White
        Me.btnManifiesto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnManifiesto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnManifiesto.FlatAppearance.BorderSize = 0
        Me.btnManifiesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnManifiesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManifiesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManifiesto.Location = New System.Drawing.Point(13, 105)
        Me.btnManifiesto.Name = "btnManifiesto"
        Me.btnManifiesto.Size = New System.Drawing.Size(258, 41)
        Me.btnManifiesto.TabIndex = 0
        Me.btnManifiesto.Text = "MANIFIESTO"
        Me.btnManifiesto.UseVisualStyleBackColor = False
        '
        'pnlCatalogos
        '
        Me.pnlCatalogos.Controls.Add(Me.spCatalogos)
        Me.pnlCatalogos.Location = New System.Drawing.Point(410, 0)
        Me.pnlCatalogos.Name = "pnlCatalogos"
        Me.pnlCatalogos.Size = New System.Drawing.Size(260, 80)
        Me.pnlCatalogos.TabIndex = 24
        Me.pnlCatalogos.Visible = False
        '
        'spCatalogos
        '
        Me.spCatalogos.AccessibleDescription = ""
        Me.spCatalogos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.spCatalogos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spCatalogos.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spCatalogos.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer6.ArrowColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer6.ArrowHoveredColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer6.ArrowSelectedColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer6.ButtonBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer6.ButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer6.ButtonHoveredBackgroundColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer6.ButtonHoveredBorderColor = System.Drawing.Color.Black
        EnhancedScrollBarRenderer6.ButtonSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer6.ButtonSelectedBorderColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer6.TrackBarBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer6.TrackBarSelectedBackgroundColor = System.Drawing.Color.DarkSlateBlue
        Me.spCatalogos.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer6
        Me.spCatalogos.HorizontalScrollBar.TabIndex = 10
        Me.spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.spCatalogos.Location = New System.Drawing.Point(0, 0)
        Me.spCatalogos.Name = "spCatalogos"
        NamedStyle7.ForeColor = System.Drawing.Color.White
        NamedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle7.Locked = False
        NamedStyle7.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle8.BackColor = System.Drawing.Color.Gainsboro
        NamedStyle8.CellType = GeneralCellType3
        NamedStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle8.Locked = False
        NamedStyle8.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle8.Renderer = GeneralCellType3
        NamedStyle9.BackColor = System.Drawing.Color.DarkSlateBlue
        NamedStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle9.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle9.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle9.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle10.BackColor = System.Drawing.Color.DarkSlateBlue
        NamedStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle10.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle10.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle10.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle11.BackColor = System.Drawing.Color.MidnightBlue
        NamedStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle11.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle11.NoteIndicatorColor = System.Drawing.Color.Red
        EnhancedCornerRenderer2.ActiveBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedCornerRenderer2.GridLineColor = System.Drawing.Color.Empty
        EnhancedCornerRenderer2.NormalBackgroundColor = System.Drawing.Color.MidnightBlue
        NamedStyle11.Renderer = EnhancedCornerRenderer2
        NamedStyle11.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        NamedStyle12.CellType = GeneralCellType4
        NamedStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle12.Locked = False
        NamedStyle12.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle12.Renderer = GeneralCellType4
        Me.spCatalogos.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle7, NamedStyle8, NamedStyle9, NamedStyle10, NamedStyle11, NamedStyle12})
        Me.spCatalogos.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spCatalogos_Sheet1})
        Me.spCatalogos.Size = New System.Drawing.Size(260, 80)
        SpreadSkin2.ColumnFooterDefaultStyle = NamedStyle9
        SpreadSkin2.ColumnHeaderDefaultStyle = NamedStyle9
        SpreadSkin2.CornerDefaultStyle = NamedStyle11
        SpreadSkin2.DefaultStyle = NamedStyle12
        SpreadSkin2.FocusRenderer = EnhancedFocusIndicatorRenderer2
        EnhancedInterfaceRenderer2.ArrowColorEnabled = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer2.GrayAreaColor = System.Drawing.Color.LightSlateGray
        EnhancedInterfaceRenderer2.RangeGroupBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer2.RangeGroupButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer2.RangeGroupLineColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer2.ScrollBoxBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedInterfaceRenderer2.SheetTabBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer2.SheetTabLowerActiveColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer2.SheetTabLowerNormalColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer2.SheetTabUpperActiveColor = System.Drawing.Color.LightGray
        EnhancedInterfaceRenderer2.SheetTabUpperNormalColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer2.SplitBarBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer2.SplitBarDarkColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer2.SplitBarLightColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer2.SplitBoxBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer2.SplitBoxBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer2.TabStripBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedInterfaceRenderer2.TabStripButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer2.TabStripButtonFlatStyle = System.Windows.Forms.FlatStyle.Flat
        EnhancedInterfaceRenderer2.TabStripButtonLowerActiveColor = System.Drawing.Color.DarkSlateBlue
        EnhancedInterfaceRenderer2.TabStripButtonLowerNormalColor = System.Drawing.Color.MidnightBlue
        EnhancedInterfaceRenderer2.TabStripButtonLowerPressedColor = System.Drawing.Color.DimGray
        EnhancedInterfaceRenderer2.TabStripButtonUpperActiveColor = System.Drawing.Color.DarkGray
        EnhancedInterfaceRenderer2.TabStripButtonUpperNormalColor = System.Drawing.Color.SlateBlue
        EnhancedInterfaceRenderer2.TabStripButtonUpperPressedColor = System.Drawing.Color.DarkSlateBlue
        SpreadSkin2.InterfaceRenderer = EnhancedInterfaceRenderer2
        SpreadSkin2.Name = "MidnightPersonalizado"
        SpreadSkin2.RowHeaderDefaultStyle = NamedStyle10
        EnhancedScrollBarRenderer7.ArrowColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer7.ArrowHoveredColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer7.ArrowSelectedColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer7.ButtonBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer7.ButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer7.ButtonHoveredBackgroundColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer7.ButtonHoveredBorderColor = System.Drawing.Color.Black
        EnhancedScrollBarRenderer7.ButtonSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer7.ButtonSelectedBorderColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer7.TrackBarBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer7.TrackBarSelectedBackgroundColor = System.Drawing.Color.DarkSlateBlue
        SpreadSkin2.ScrollBarRenderer = EnhancedScrollBarRenderer7
        SpreadSkin2.SelectionRenderer = New FarPoint.Win.Spread.GradientSelectionRenderer(System.Drawing.Color.MidnightBlue, System.Drawing.Color.MidnightBlue, System.Drawing.Drawing2D.LinearGradientMode.Horizontal, 80)
        Me.spCatalogos.Skin = SpreadSkin2
        Me.spCatalogos.TabIndex = 22
        Me.spCatalogos.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spCatalogos.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer8.ArrowColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer8.ArrowHoveredColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer8.ArrowSelectedColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer8.ButtonBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer8.ButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer8.ButtonHoveredBackgroundColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer8.ButtonHoveredBorderColor = System.Drawing.Color.Black
        EnhancedScrollBarRenderer8.ButtonSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer8.ButtonSelectedBorderColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer8.TrackBarBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer8.TrackBarSelectedBackgroundColor = System.Drawing.Color.DarkSlateBlue
        Me.spCatalogos.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer8
        Me.spCatalogos.VerticalScrollBar.TabIndex = 11
        Me.spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
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
        'pnlCapturaSuperior
        '
        Me.pnlCapturaSuperior.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlCapturaSuperior.AutoScroll = True
        Me.pnlCapturaSuperior.BackColor = System.Drawing.Color.White
        Me.pnlCapturaSuperior.Controls.Add(Me.btnMostrarOcultar)
        Me.pnlCapturaSuperior.Controls.Add(Me.rbtnExportacion)
        Me.pnlCapturaSuperior.Controls.Add(Me.rbtnNacional)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtGuiaCaades)
        Me.pnlCapturaSuperior.Controls.Add(Me.lblGuiaCaades)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtFactura)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label25)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtSello8)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label24)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtSello7)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label22)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtSello6)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label23)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtSello5)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label21)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtSello4)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label20)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtSello3)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label19)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtSello2)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label18)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtSello1)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label17)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtHoraPrecos)
        Me.pnlCapturaSuperior.Controls.Add(Me.lblHoraPrecos)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtPrecioFlete)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label15)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtTermografo)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label14)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtTemperatura)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label13)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbDocumentadores)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label12)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbAduanasUsa)
        Me.pnlCapturaSuperior.Controls.Add(Me.lblAduanaUsa)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbAduanasMex)
        Me.pnlCapturaSuperior.Controls.Add(Me.lblAduanaMex)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbCajasTrailers)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label9)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbChoferes)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label7)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbTrailers)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label6)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbLineasTransportes)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label5)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbClientes)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label4)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbEmbarcadores)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label8)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtHora)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label1)
        Me.pnlCapturaSuperior.Controls.Add(Me.btnIdSiguiente)
        Me.pnlCapturaSuperior.Controls.Add(Me.btnIdAnterior)
        Me.pnlCapturaSuperior.Controls.Add(Me.chkConservarDatos)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtId)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label3)
        Me.pnlCapturaSuperior.Controls.Add(Me.dtpFecha)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label2)
        Me.pnlCapturaSuperior.Location = New System.Drawing.Point(0, 0)
        Me.pnlCapturaSuperior.Name = "pnlCapturaSuperior"
        Me.pnlCapturaSuperior.Size = New System.Drawing.Size(400, 490)
        Me.pnlCapturaSuperior.TabIndex = 23
        '
        'btnMostrarOcultar
        '
        Me.btnMostrarOcultar.BackColor = System.Drawing.Color.White
        Me.btnMostrarOcultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMostrarOcultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMostrarOcultar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnMostrarOcultar.FlatAppearance.BorderSize = 3
        Me.btnMostrarOcultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnMostrarOcultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMostrarOcultar.ForeColor = System.Drawing.Color.Black
        Me.btnMostrarOcultar.Location = New System.Drawing.Point(337, 1)
        Me.btnMostrarOcultar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMostrarOcultar.Name = "btnMostrarOcultar"
        Me.btnMostrarOcultar.Size = New System.Drawing.Size(40, 40)
        Me.btnMostrarOcultar.TabIndex = 76
        Me.btnMostrarOcultar.UseVisualStyleBackColor = False
        '
        'rbtnExportacion
        '
        Me.rbtnExportacion.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnExportacion.AutoSize = True
        Me.rbtnExportacion.BackColor = System.Drawing.Color.Transparent
        Me.rbtnExportacion.Checked = True
        Me.rbtnExportacion.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnExportacion.FlatAppearance.BorderSize = 2
        Me.rbtnExportacion.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnExportacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnExportacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnExportacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnExportacion.ForeColor = System.Drawing.Color.Black
        Me.rbtnExportacion.Location = New System.Drawing.Point(4, 4)
        Me.rbtnExportacion.Name = "rbtnExportacion"
        Me.rbtnExportacion.Size = New System.Drawing.Size(141, 32)
        Me.rbtnExportacion.TabIndex = 75
        Me.rbtnExportacion.TabStop = True
        Me.rbtnExportacion.Text = "EXPORTACIÓN"
        Me.rbtnExportacion.UseVisualStyleBackColor = False
        '
        'rbtnNacional
        '
        Me.rbtnNacional.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnNacional.AutoSize = True
        Me.rbtnNacional.BackColor = System.Drawing.Color.Transparent
        Me.rbtnNacional.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnNacional.FlatAppearance.BorderSize = 2
        Me.rbtnNacional.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnNacional.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnNacional.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnNacional.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnNacional.ForeColor = System.Drawing.Color.Black
        Me.rbtnNacional.Location = New System.Drawing.Point(148, 4)
        Me.rbtnNacional.Name = "rbtnNacional"
        Me.rbtnNacional.Size = New System.Drawing.Size(104, 32)
        Me.rbtnNacional.TabIndex = 74
        Me.rbtnNacional.Text = "NACIONAL"
        Me.rbtnNacional.UseVisualStyleBackColor = False
        '
        'txtGuiaCaades
        '
        Me.txtGuiaCaades.BackColor = System.Drawing.Color.White
        Me.txtGuiaCaades.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuiaCaades.ForeColor = System.Drawing.Color.Black
        Me.txtGuiaCaades.Location = New System.Drawing.Point(144, 870)
        Me.txtGuiaCaades.MaxLength = 15
        Me.txtGuiaCaades.Name = "txtGuiaCaades"
        Me.txtGuiaCaades.Size = New System.Drawing.Size(238, 26)
        Me.txtGuiaCaades.TabIndex = 73
        '
        'lblGuiaCaades
        '
        Me.lblGuiaCaades.AutoSize = True
        Me.lblGuiaCaades.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuiaCaades.Location = New System.Drawing.Point(23, 874)
        Me.lblGuiaCaades.Name = "lblGuiaCaades"
        Me.lblGuiaCaades.Size = New System.Drawing.Size(123, 18)
        Me.lblGuiaCaades.TabIndex = 72
        Me.lblGuiaCaades.Text = "GUIA CAADES:"
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.Color.White
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.ForeColor = System.Drawing.Color.Black
        Me.txtFactura.Location = New System.Drawing.Point(144, 838)
        Me.txtFactura.MaxLength = 15
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(238, 26)
        Me.txtFactura.TabIndex = 71
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(45, 842)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(101, 18)
        Me.Label25.TabIndex = 70
        Me.Label25.Text = "FACTURA: *"
        '
        'txtSello8
        '
        Me.txtSello8.BackColor = System.Drawing.Color.White
        Me.txtSello8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSello8.ForeColor = System.Drawing.Color.Black
        Me.txtSello8.Location = New System.Drawing.Point(144, 806)
        Me.txtSello8.MaxLength = 13
        Me.txtSello8.Name = "txtSello8"
        Me.txtSello8.Size = New System.Drawing.Size(238, 26)
        Me.txtSello8.TabIndex = 69
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(66, 810)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 18)
        Me.Label24.TabIndex = 68
        Me.Label24.Text = "SELLO 8:"
        '
        'txtSello7
        '
        Me.txtSello7.BackColor = System.Drawing.Color.White
        Me.txtSello7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSello7.ForeColor = System.Drawing.Color.Black
        Me.txtSello7.Location = New System.Drawing.Point(144, 774)
        Me.txtSello7.MaxLength = 13
        Me.txtSello7.Name = "txtSello7"
        Me.txtSello7.Size = New System.Drawing.Size(238, 26)
        Me.txtSello7.TabIndex = 67
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(66, 778)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 18)
        Me.Label22.TabIndex = 66
        Me.Label22.Text = "SELLO 7:"
        '
        'txtSello6
        '
        Me.txtSello6.BackColor = System.Drawing.Color.White
        Me.txtSello6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSello6.ForeColor = System.Drawing.Color.Black
        Me.txtSello6.Location = New System.Drawing.Point(144, 742)
        Me.txtSello6.MaxLength = 13
        Me.txtSello6.Name = "txtSello6"
        Me.txtSello6.Size = New System.Drawing.Size(238, 26)
        Me.txtSello6.TabIndex = 65
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(66, 746)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 18)
        Me.Label23.TabIndex = 64
        Me.Label23.Text = "SELLO 6:"
        '
        'txtSello5
        '
        Me.txtSello5.BackColor = System.Drawing.Color.White
        Me.txtSello5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSello5.ForeColor = System.Drawing.Color.Black
        Me.txtSello5.Location = New System.Drawing.Point(144, 710)
        Me.txtSello5.MaxLength = 13
        Me.txtSello5.Name = "txtSello5"
        Me.txtSello5.Size = New System.Drawing.Size(238, 26)
        Me.txtSello5.TabIndex = 63
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(66, 714)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 18)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "SELLO 5:"
        '
        'txtSello4
        '
        Me.txtSello4.BackColor = System.Drawing.Color.White
        Me.txtSello4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSello4.ForeColor = System.Drawing.Color.Black
        Me.txtSello4.Location = New System.Drawing.Point(144, 678)
        Me.txtSello4.MaxLength = 13
        Me.txtSello4.Name = "txtSello4"
        Me.txtSello4.Size = New System.Drawing.Size(238, 26)
        Me.txtSello4.TabIndex = 61
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(66, 682)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 18)
        Me.Label20.TabIndex = 60
        Me.Label20.Text = "SELLO 4:"
        '
        'txtSello3
        '
        Me.txtSello3.BackColor = System.Drawing.Color.White
        Me.txtSello3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSello3.ForeColor = System.Drawing.Color.Black
        Me.txtSello3.Location = New System.Drawing.Point(144, 646)
        Me.txtSello3.MaxLength = 13
        Me.txtSello3.Name = "txtSello3"
        Me.txtSello3.Size = New System.Drawing.Size(238, 26)
        Me.txtSello3.TabIndex = 59
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(66, 650)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 18)
        Me.Label19.TabIndex = 58
        Me.Label19.Text = "SELLO 3:"
        '
        'txtSello2
        '
        Me.txtSello2.BackColor = System.Drawing.Color.White
        Me.txtSello2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSello2.ForeColor = System.Drawing.Color.Black
        Me.txtSello2.Location = New System.Drawing.Point(144, 614)
        Me.txtSello2.MaxLength = 13
        Me.txtSello2.Name = "txtSello2"
        Me.txtSello2.Size = New System.Drawing.Size(238, 26)
        Me.txtSello2.TabIndex = 57
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(66, 618)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 18)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "SELLO 2:"
        '
        'txtSello1
        '
        Me.txtSello1.BackColor = System.Drawing.Color.White
        Me.txtSello1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSello1.ForeColor = System.Drawing.Color.Black
        Me.txtSello1.Location = New System.Drawing.Point(144, 582)
        Me.txtSello1.MaxLength = 13
        Me.txtSello1.Name = "txtSello1"
        Me.txtSello1.Size = New System.Drawing.Size(238, 26)
        Me.txtSello1.TabIndex = 55
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(54, 586)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 18)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "SELLO 1: *"
        '
        'txtHoraPrecos
        '
        Me.txtHoraPrecos.BackColor = System.Drawing.Color.White
        Me.txtHoraPrecos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoraPrecos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraPrecos.Location = New System.Drawing.Point(144, 550)
        Me.txtHoraPrecos.Mask = "00:00"
        Me.txtHoraPrecos.Name = "txtHoraPrecos"
        Me.txtHoraPrecos.Size = New System.Drawing.Size(47, 26)
        Me.txtHoraPrecos.TabIndex = 52
        Me.txtHoraPrecos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHoraPrecos.ValidatingType = GetType(Date)
        '
        'lblHoraPrecos
        '
        Me.lblHoraPrecos.AutoSize = True
        Me.lblHoraPrecos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraPrecos.Location = New System.Drawing.Point(-1, 554)
        Me.lblHoraPrecos.Name = "lblHoraPrecos"
        Me.lblHoraPrecos.Size = New System.Drawing.Size(147, 18)
        Me.lblHoraPrecos.TabIndex = 53
        Me.lblHoraPrecos.Text = "HORA PRECOS: *"
        '
        'txtPrecioFlete
        '
        Me.txtPrecioFlete.BackColor = System.Drawing.Color.White
        Me.txtPrecioFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioFlete.ForeColor = System.Drawing.Color.Black
        Me.txtPrecioFlete.Location = New System.Drawing.Point(144, 518)
        Me.txtPrecioFlete.MaxLength = 6
        Me.txtPrecioFlete.Name = "txtPrecioFlete"
        Me.txtPrecioFlete.Size = New System.Drawing.Size(122, 26)
        Me.txtPrecioFlete.TabIndex = 51
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(2, 522)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 18)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "PRECIO FLETE: *"
        '
        'txtTermografo
        '
        Me.txtTermografo.BackColor = System.Drawing.Color.White
        Me.txtTermografo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTermografo.ForeColor = System.Drawing.Color.Black
        Me.txtTermografo.Location = New System.Drawing.Point(144, 486)
        Me.txtTermografo.MaxLength = 13
        Me.txtTermografo.Name = "txtTermografo"
        Me.txtTermografo.Size = New System.Drawing.Size(238, 26)
        Me.txtTermografo.TabIndex = 49
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 490)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(143, 18)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "TERMOGRAFO: *"
        '
        'txtTemperatura
        '
        Me.txtTemperatura.BackColor = System.Drawing.Color.White
        Me.txtTemperatura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemperatura.ForeColor = System.Drawing.Color.Black
        Me.txtTemperatura.Location = New System.Drawing.Point(144, 454)
        Me.txtTemperatura.MaxLength = 3
        Me.txtTemperatura.Name = "txtTemperatura"
        Me.txtTemperatura.Size = New System.Drawing.Size(62, 26)
        Me.txtTemperatura.TabIndex = 47
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(-2, 458)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(148, 18)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "TEMPERATURA: *"
        '
        'cbDocumentadores
        '
        Me.cbDocumentadores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbDocumentadores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbDocumentadores.BackColor = System.Drawing.Color.White
        Me.cbDocumentadores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbDocumentadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDocumentadores.ForeColor = System.Drawing.Color.Black
        Me.cbDocumentadores.FormattingEnabled = True
        Me.cbDocumentadores.Location = New System.Drawing.Point(166, 420)
        Me.cbDocumentadores.Name = "cbDocumentadores"
        Me.cbDocumentadores.Size = New System.Drawing.Size(216, 28)
        Me.cbDocumentadores.TabIndex = 45
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(0, 425)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(168, 18)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "DOCUMENTADOR: *"
        '
        'cbAduanasUsa
        '
        Me.cbAduanasUsa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAduanasUsa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAduanasUsa.BackColor = System.Drawing.Color.White
        Me.cbAduanasUsa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbAduanasUsa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAduanasUsa.ForeColor = System.Drawing.Color.Black
        Me.cbAduanasUsa.FormattingEnabled = True
        Me.cbAduanasUsa.Location = New System.Drawing.Point(144, 386)
        Me.cbAduanasUsa.Name = "cbAduanasUsa"
        Me.cbAduanasUsa.Size = New System.Drawing.Size(238, 28)
        Me.cbAduanasUsa.TabIndex = 43
        '
        'lblAduanaUsa
        '
        Me.lblAduanaUsa.AutoSize = True
        Me.lblAduanaUsa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAduanaUsa.Location = New System.Drawing.Point(17, 391)
        Me.lblAduanaUsa.Name = "lblAduanaUsa"
        Me.lblAduanaUsa.Size = New System.Drawing.Size(129, 18)
        Me.lblAduanaUsa.TabIndex = 42
        Me.lblAduanaUsa.Text = "ADUANA USA: *"
        '
        'cbAduanasMex
        '
        Me.cbAduanasMex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAduanasMex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAduanasMex.BackColor = System.Drawing.Color.White
        Me.cbAduanasMex.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbAduanasMex.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAduanasMex.ForeColor = System.Drawing.Color.Black
        Me.cbAduanasMex.FormattingEnabled = True
        Me.cbAduanasMex.Location = New System.Drawing.Point(144, 352)
        Me.cbAduanasMex.Name = "cbAduanasMex"
        Me.cbAduanasMex.Size = New System.Drawing.Size(238, 28)
        Me.cbAduanasMex.TabIndex = 41
        '
        'lblAduanaMex
        '
        Me.lblAduanaMex.AutoSize = True
        Me.lblAduanaMex.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAduanaMex.Location = New System.Drawing.Point(14, 357)
        Me.lblAduanaMex.Name = "lblAduanaMex"
        Me.lblAduanaMex.Size = New System.Drawing.Size(132, 18)
        Me.lblAduanaMex.TabIndex = 40
        Me.lblAduanaMex.Text = "ADUANA MEX: *"
        '
        'cbCajasTrailers
        '
        Me.cbCajasTrailers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCajasTrailers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCajasTrailers.BackColor = System.Drawing.Color.White
        Me.cbCajasTrailers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbCajasTrailers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCajasTrailers.ForeColor = System.Drawing.Color.Black
        Me.cbCajasTrailers.FormattingEnabled = True
        Me.cbCajasTrailers.Location = New System.Drawing.Point(144, 284)
        Me.cbCajasTrailers.Name = "cbCajasTrailers"
        Me.cbCajasTrailers.Size = New System.Drawing.Size(238, 28)
        Me.cbCajasTrailers.TabIndex = 39
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(80, 289)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 18)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "CAJA: *"
        '
        'cbChoferes
        '
        Me.cbChoferes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbChoferes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbChoferes.BackColor = System.Drawing.Color.White
        Me.cbChoferes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbChoferes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbChoferes.ForeColor = System.Drawing.Color.Black
        Me.cbChoferes.FormattingEnabled = True
        Me.cbChoferes.Location = New System.Drawing.Point(144, 318)
        Me.cbChoferes.Name = "cbChoferes"
        Me.cbChoferes.Size = New System.Drawing.Size(238, 28)
        Me.cbChoferes.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 323)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 18)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "CHOFER: *"
        '
        'cbTrailers
        '
        Me.cbTrailers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTrailers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTrailers.BackColor = System.Drawing.Color.White
        Me.cbTrailers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbTrailers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTrailers.ForeColor = System.Drawing.Color.Black
        Me.cbTrailers.FormattingEnabled = True
        Me.cbTrailers.Location = New System.Drawing.Point(144, 250)
        Me.cbTrailers.Name = "cbTrailers"
        Me.cbTrailers.Size = New System.Drawing.Size(238, 28)
        Me.cbTrailers.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(53, 255)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 18)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "TRAILER: *"
        '
        'cbLineasTransportes
        '
        Me.cbLineasTransportes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbLineasTransportes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbLineasTransportes.BackColor = System.Drawing.Color.White
        Me.cbLineasTransportes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbLineasTransportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLineasTransportes.ForeColor = System.Drawing.Color.Black
        Me.cbLineasTransportes.FormattingEnabled = True
        Me.cbLineasTransportes.Location = New System.Drawing.Point(144, 216)
        Me.cbLineasTransportes.Name = "cbLineasTransportes"
        Me.cbLineasTransportes.Size = New System.Drawing.Size(238, 28)
        Me.cbLineasTransportes.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(75, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 18)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "LINEA: *"
        '
        'cbClientes
        '
        Me.cbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbClientes.BackColor = System.Drawing.Color.White
        Me.cbClientes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbClientes.ForeColor = System.Drawing.Color.Black
        Me.cbClientes.FormattingEnabled = True
        Me.cbClientes.Location = New System.Drawing.Point(144, 182)
        Me.cbClientes.Name = "cbClientes"
        Me.cbClientes.Size = New System.Drawing.Size(238, 28)
        Me.cbClientes.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(52, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 18)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "CLIENTE: *"
        '
        'cbEmbarcadores
        '
        Me.cbEmbarcadores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbEmbarcadores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbEmbarcadores.BackColor = System.Drawing.Color.White
        Me.cbEmbarcadores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbEmbarcadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEmbarcadores.ForeColor = System.Drawing.Color.Black
        Me.cbEmbarcadores.FormattingEnabled = True
        Me.cbEmbarcadores.Location = New System.Drawing.Point(144, 148)
        Me.cbEmbarcadores.Name = "cbEmbarcadores"
        Me.cbEmbarcadores.Size = New System.Drawing.Size(238, 28)
        Me.cbEmbarcadores.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(142, 18)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "EMBARCADOR: *"
        '
        'txtHora
        '
        Me.txtHora.BackColor = System.Drawing.Color.White
        Me.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Location = New System.Drawing.Point(82, 111)
        Me.txtHora.Mask = "00:00"
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(47, 26)
        Me.txtHora.TabIndex = 22
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHora.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "HORA: *"
        '
        'btnIdSiguiente
        '
        Me.btnIdSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIdSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIdSiguiente.Location = New System.Drawing.Point(127, 43)
        Me.btnIdSiguiente.Name = "btnIdSiguiente"
        Me.btnIdSiguiente.Size = New System.Drawing.Size(25, 28)
        Me.btnIdSiguiente.TabIndex = 21
        Me.btnIdSiguiente.Text = ">"
        Me.btnIdSiguiente.UseVisualStyleBackColor = True
        '
        'btnIdAnterior
        '
        Me.btnIdAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIdAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIdAnterior.Location = New System.Drawing.Point(103, 43)
        Me.btnIdAnterior.Name = "btnIdAnterior"
        Me.btnIdAnterior.Size = New System.Drawing.Size(25, 28)
        Me.btnIdAnterior.TabIndex = 20
        Me.btnIdAnterior.Text = "<"
        Me.btnIdAnterior.UseVisualStyleBackColor = True
        '
        'chkConservarDatos
        '
        Me.chkConservarDatos.AutoSize = True
        Me.chkConservarDatos.Checked = True
        Me.chkConservarDatos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConservarDatos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkConservarDatos.ForeColor = System.Drawing.Color.Green
        Me.chkConservarDatos.Location = New System.Drawing.Point(158, 43)
        Me.chkConservarDatos.Name = "chkConservarDatos"
        Me.chkConservarDatos.Size = New System.Drawing.Size(177, 28)
        Me.chkConservarDatos.TabIndex = 18
        Me.chkConservarDatos.Text = "Conservar Datos?"
        Me.chkConservarDatos.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.White
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.ForeColor = System.Drawing.Color.Black
        Me.txtId.Location = New System.Drawing.Point(52, 44)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(50, 26)
        Me.txtId.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "NO: *"
        '
        'dtpFecha
        '
        Me.dtpFecha.CalendarForeColor = System.Drawing.Color.Black
        Me.dtpFecha.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtpFecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Location = New System.Drawing.Point(82, 79)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(300, 26)
        Me.dtpFecha.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "FECHA: *"
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
        Me.btnEliminar.Location = New System.Drawing.Point(903, 426)
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
        Me.btnGuardar.Location = New System.Drawing.Point(964, 426)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 60)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'spEmbarques
        '
        Me.spEmbarques.AccessibleDescription = ""
        Me.spEmbarques.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spEmbarques.BackColor = System.Drawing.Color.White
        Me.spEmbarques.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spEmbarques.HorizontalScrollBar.Name = ""
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
        Me.spEmbarques.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.spEmbarques.HorizontalScrollBar.TabIndex = 0
        Me.spEmbarques.Location = New System.Drawing.Point(406, 0)
        Me.spEmbarques.Name = "spEmbarques"
        Me.spEmbarques.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spEmbarques_Sheet1})
        Me.spEmbarques.Size = New System.Drawing.Size(621, 489)
        Me.spEmbarques.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spEmbarques.TabIndex = 0
        Me.spEmbarques.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spEmbarques.VerticalScrollBar.Name = ""
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
        Me.spEmbarques.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
        Me.spEmbarques.VerticalScrollBar.TabIndex = 11
        '
        'spEmbarques_Sheet1
        '
        Me.spEmbarques_Sheet1.Reset()
        spEmbarques_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spEmbarques_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spEmbarques_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spEmbarques_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spEmbarques_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spEmbarques_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spEmbarques_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spEmbarques_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spEmbarques_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spEmbarques_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spEmbarques_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spEmbarques_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spEmbarques_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'pnlPie
        '
        Me.pnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPie.BackColor = System.Drawing.Color.Black
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.btnGenerarDocumentos)
        Me.pnlPie.Controls.Add(Me.btnAyuda)
        Me.pnlPie.Controls.Add(Me.lblDescripcionTooltip)
        Me.pnlPie.Controls.Add(Me.btnSalir)
        Me.pnlPie.ForeColor = System.Drawing.Color.White
        Me.pnlPie.Location = New System.Drawing.Point(0, 570)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1034, 60)
        Me.pnlPie.TabIndex = 8
        '
        'btnGenerarDocumentos
        '
        Me.btnGenerarDocumentos.BackColor = System.Drawing.Color.White
        Me.btnGenerarDocumentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGenerarDocumentos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerarDocumentos.Enabled = False
        Me.btnGenerarDocumentos.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGenerarDocumentos.FlatAppearance.BorderSize = 3
        Me.btnGenerarDocumentos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnGenerarDocumentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarDocumentos.ForeColor = System.Drawing.Color.Black
        Me.btnGenerarDocumentos.Image = CType(resources.GetObject("btnGenerarDocumentos.Image"), System.Drawing.Image)
        Me.btnGenerarDocumentos.Location = New System.Drawing.Point(63, 0)
        Me.btnGenerarDocumentos.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGenerarDocumentos.Name = "btnGenerarDocumentos"
        Me.btnGenerarDocumentos.Size = New System.Drawing.Size(60, 60)
        Me.btnGenerarDocumentos.TabIndex = 26
        Me.btnGenerarDocumentos.UseVisualStyleBackColor = False
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
        Me.lblDescripcionTooltip.Location = New System.Drawing.Point(157, 17)
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
        Me.pnlEncabezado.BackColor = System.Drawing.Color.Black
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
        Me.Text = "Empaque y Embarques - Embarques"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        Me.pnlDocumentos.ResumeLayout(False)
        Me.pnlCatalogos.ResumeLayout(False)
        CType(Me.spCatalogos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spCatalogos_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCapturaSuperior.ResumeLayout(False)
        Me.pnlCapturaSuperior.PerformLayout()
        CType(Me.spEmbarques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spEmbarques_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents spEmbarques As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spEmbarques_Sheet1 As FarPoint.Win.Spread.SheetView
    Private WithEvents lblEncabezadoArea As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoUsuario As System.Windows.Forms.Label
    Private WithEvents btnEliminar As System.Windows.Forms.Button
    Private WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblDescripcionTooltip As System.Windows.Forms.Label
    Private WithEvents spCatalogos As FarPoint.Win.Spread.FpSpread
    Private WithEvents spCatalogos_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents temporizador As System.Windows.Forms.Timer
    Private WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents pnlCapturaSuperior As System.Windows.Forms.Panel
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkConservarDatos As System.Windows.Forms.CheckBox
    Friend WithEvents pnlCatalogos As System.Windows.Forms.Panel
    Friend WithEvents btnIdAnterior As System.Windows.Forms.Button
    Friend WithEvents btnIdSiguiente As System.Windows.Forms.Button
    Friend WithEvents txtHora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbEmbarcadores As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents btnGenerarDocumentos As System.Windows.Forms.Button
    Friend WithEvents cbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbTrailers As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbLineasTransportes As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbChoferes As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbCajasTrailers As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbAduanasMex As System.Windows.Forms.ComboBox
    Friend WithEvents lblAduanaMex As System.Windows.Forms.Label
    Friend WithEvents cbAduanasUsa As System.Windows.Forms.ComboBox
    Friend WithEvents lblAduanaUsa As System.Windows.Forms.Label
    Friend WithEvents cbDocumentadores As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTemperatura As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTermografo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioFlete As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSello3 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSello2 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSello1 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtHoraPrecos As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblHoraPrecos As System.Windows.Forms.Label
    Friend WithEvents txtSello4 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSello5 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtSello8 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtSello7 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtSello6 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtGuiaCaades As System.Windows.Forms.TextBox
    Friend WithEvents lblGuiaCaades As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Private WithEvents rbtnExportacion As System.Windows.Forms.RadioButton
    Private WithEvents rbtnNacional As System.Windows.Forms.RadioButton
    Private WithEvents btnMostrarOcultar As System.Windows.Forms.Button
    Friend WithEvents pnlDocumentos As System.Windows.Forms.Panel
    Friend WithEvents btnManifiesto As System.Windows.Forms.Button
    Friend WithEvents btnRemision As System.Windows.Forms.Button
    Friend WithEvents btnDistribucionCarga As System.Windows.Forms.Button
    Friend WithEvents btnCartaResponsiva As System.Windows.Forms.Button
    Friend WithEvents btnBitacoraSellos As System.Windows.Forms.Button
    Friend WithEvents btnPrecos As System.Windows.Forms.Button
End Class
