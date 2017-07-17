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
        Dim EnhancedScrollBarRenderer10 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Dim EnhancedScrollBarRenderer8 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer9 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer4 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer5 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        Me.pnlCatalogos = New System.Windows.Forms.Panel()
        Me.spCatalogos = New FarPoint.Win.Spread.FpSpread()
        Me.spCatalogos_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlCapturaSuperior = New System.Windows.Forms.Panel()
        Me.cbChoferesCampos = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbVariedades = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnIdSiguiente = New System.Windows.Forms.Button()
        Me.btnIdAnterior = New System.Windows.Forms.Button()
        Me.chkConservarDatos = New System.Windows.Forms.CheckBox()
        Me.cbLotes = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbProductos = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.spRecepcion = New FarPoint.Win.Spread.FpSpread()
        Me.spRecepcion_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.spTotales = New FarPoint.Win.Spread.FpSpread()
        Me.spTotales_Sheet1 = New FarPoint.Win.Spread.SheetView()
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
        Me.pnlCatalogos.SuspendLayout()
        CType(Me.spCatalogos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spCatalogos_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCapturaSuperior.SuspendLayout()
        CType(Me.spRecepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spRecepcion_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spTotales_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlContenido.BackgroundImage = Global.Recepcion.My.Resources.Resources.Logo3
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
        Me.pnlCuerpo.Controls.Add(Me.pnlCatalogos)
        Me.pnlCuerpo.Controls.Add(Me.pnlCapturaSuperior)
        Me.pnlCuerpo.Controls.Add(Me.btnEliminar)
        Me.pnlCuerpo.Controls.Add(Me.btnGuardar)
        Me.pnlCuerpo.Controls.Add(Me.spRecepcion)
        Me.pnlCuerpo.Controls.Add(Me.spTotales)
        Me.pnlCuerpo.Location = New System.Drawing.Point(3, 77)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(1028, 490)
        Me.pnlCuerpo.TabIndex = 9
        '
        'pnlCatalogos
        '
        Me.pnlCatalogos.Controls.Add(Me.spCatalogos)
        Me.pnlCatalogos.Location = New System.Drawing.Point(0, 73)
        Me.pnlCatalogos.Name = "pnlCatalogos"
        Me.pnlCatalogos.Size = New System.Drawing.Size(260, 150)
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
        Me.spCatalogos.Size = New System.Drawing.Size(260, 150)
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
        EnhancedScrollBarRenderer10.ArrowColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer10.ArrowHoveredColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer10.ArrowSelectedColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer10.ButtonBackgroundColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer10.ButtonBorderColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer10.ButtonHoveredBackgroundColor = System.Drawing.Color.MidnightBlue
        EnhancedScrollBarRenderer10.ButtonHoveredBorderColor = System.Drawing.Color.Black
        EnhancedScrollBarRenderer10.ButtonSelectedBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer10.ButtonSelectedBorderColor = System.Drawing.Color.DarkSlateBlue
        EnhancedScrollBarRenderer10.TrackBarBackgroundColor = System.Drawing.Color.SteelBlue
        EnhancedScrollBarRenderer10.TrackBarSelectedBackgroundColor = System.Drawing.Color.DarkSlateBlue
        Me.spCatalogos.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer10
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
        Me.pnlCapturaSuperior.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCapturaSuperior.BackColor = System.Drawing.Color.White
        Me.pnlCapturaSuperior.Controls.Add(Me.cbChoferesCampos)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label7)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbVariedades)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label4)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtHora)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label1)
        Me.pnlCapturaSuperior.Controls.Add(Me.btnIdSiguiente)
        Me.pnlCapturaSuperior.Controls.Add(Me.btnIdAnterior)
        Me.pnlCapturaSuperior.Controls.Add(Me.chkConservarDatos)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbLotes)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label6)
        Me.pnlCapturaSuperior.Controls.Add(Me.cbProductos)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label5)
        Me.pnlCapturaSuperior.Controls.Add(Me.txtId)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label3)
        Me.pnlCapturaSuperior.Controls.Add(Me.dtpFecha)
        Me.pnlCapturaSuperior.Controls.Add(Me.Label2)
        Me.pnlCapturaSuperior.Location = New System.Drawing.Point(0, 0)
        Me.pnlCapturaSuperior.Name = "pnlCapturaSuperior"
        Me.pnlCapturaSuperior.Size = New System.Drawing.Size(1028, 71)
        Me.pnlCapturaSuperior.TabIndex = 23
        '
        'cbChoferesCampos
        '
        Me.cbChoferesCampos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbChoferesCampos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbChoferesCampos.BackColor = System.Drawing.Color.White
        Me.cbChoferesCampos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbChoferesCampos.ForeColor = System.Drawing.Color.Black
        Me.cbChoferesCampos.FormattingEnabled = True
        Me.cbChoferesCampos.Location = New System.Drawing.Point(291, 38)
        Me.cbChoferesCampos.Name = "cbChoferesCampos"
        Me.cbChoferesCampos.Size = New System.Drawing.Size(145, 28)
        Me.cbChoferesCampos.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(213, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Chofer: *"
        '
        'cbVariedades
        '
        Me.cbVariedades.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbVariedades.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbVariedades.BackColor = System.Drawing.Color.White
        Me.cbVariedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVariedades.ForeColor = System.Drawing.Color.Black
        Me.cbVariedades.FormattingEnabled = True
        Me.cbVariedades.Location = New System.Drawing.Point(834, 38)
        Me.cbVariedades.Name = "cbVariedades"
        Me.cbVariedades.Size = New System.Drawing.Size(198, 28)
        Me.cbVariedades.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(738, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 20)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Variedad: *"
        '
        'txtHora
        '
        Me.txtHora.BackColor = System.Drawing.Color.White
        Me.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Location = New System.Drawing.Point(597, 6)
        Me.txtHora.Mask = "00:00"
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(47, 26)
        Me.txtHora.TabIndex = 22
        Me.txtHora.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(533, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Hora: *"
        '
        'btnIdSiguiente
        '
        Me.btnIdSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIdSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIdSiguiente.Location = New System.Drawing.Point(124, 5)
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
        Me.btnIdAnterior.Location = New System.Drawing.Point(100, 5)
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
        Me.chkConservarDatos.Location = New System.Drawing.Point(650, 7)
        Me.chkConservarDatos.Name = "chkConservarDatos"
        Me.chkConservarDatos.Size = New System.Drawing.Size(177, 28)
        Me.chkConservarDatos.TabIndex = 18
        Me.chkConservarDatos.Text = "Conservar Datos?"
        Me.chkConservarDatos.UseVisualStyleBackColor = True
        '
        'cbLotes
        '
        Me.cbLotes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbLotes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbLotes.BackColor = System.Drawing.Color.White
        Me.cbLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLotes.ForeColor = System.Drawing.Color.Black
        Me.cbLotes.FormattingEnabled = True
        Me.cbLotes.Location = New System.Drawing.Point(64, 38)
        Me.cbLotes.Name = "cbLotes"
        Me.cbLotes.Size = New System.Drawing.Size(145, 28)
        Me.cbLotes.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Lote: *"
        '
        'cbProductos
        '
        Me.cbProductos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProductos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProductos.BackColor = System.Drawing.Color.White
        Me.cbProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProductos.ForeColor = System.Drawing.Color.Black
        Me.cbProductos.FormattingEnabled = True
        Me.cbProductos.Location = New System.Drawing.Point(536, 38)
        Me.cbProductos.Name = "cbProductos"
        Me.cbProductos.Size = New System.Drawing.Size(198, 28)
        Me.cbProductos.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(440, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Producto: *"
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.White
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.ForeColor = System.Drawing.Color.Black
        Me.txtId.Location = New System.Drawing.Point(49, 6)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(50, 26)
        Me.txtId.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "No: *"
        '
        'dtpFecha
        '
        Me.dtpFecha.CalendarForeColor = System.Drawing.Color.Black
        Me.dtpFecha.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtpFecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Location = New System.Drawing.Point(228, 6)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(300, 26)
        Me.dtpFecha.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(154, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha: *"
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackColor = System.Drawing.Color.White
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEliminar.FlatAppearance.BorderSize = 3
        Me.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(903, 430)
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
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGuardar.FlatAppearance.BorderSize = 3
        Me.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(964, 430)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 60)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'spRecepcion
        '
        Me.spRecepcion.AccessibleDescription = ""
        Me.spRecepcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spRecepcion.BackColor = System.Drawing.Color.White
        Me.spRecepcion.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spRecepcion.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer8.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer8.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer8.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer8.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer8.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer8.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer8.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer8.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer8.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer8.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer8.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spRecepcion.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer8
        Me.spRecepcion.HorizontalScrollBar.TabIndex = 10
        Me.spRecepcion.Location = New System.Drawing.Point(0, 73)
        Me.spRecepcion.Name = "spRecepcion"
        Me.spRecepcion.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spRecepcion_Sheet1})
        Me.spRecepcion.Size = New System.Drawing.Size(1028, 392)
        Me.spRecepcion.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spRecepcion.TabIndex = 0
        Me.spRecepcion.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spRecepcion.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer9.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer9.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer9.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer9.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer9.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer9.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer9.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer9.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer9.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer9.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer9.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spRecepcion.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer9
        Me.spRecepcion.VerticalScrollBar.TabIndex = 11
        '
        'spRecepcion_Sheet1
        '
        Me.spRecepcion_Sheet1.Reset()
        spRecepcion_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spRecepcion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spRecepcion_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spRecepcion_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spRecepcion_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spRecepcion_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spRecepcion_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spRecepcion_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spRecepcion_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spRecepcion_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spRecepcion_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spRecepcion_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spRecepcion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'spTotales
        '
        Me.spTotales.AccessibleDescription = ""
        Me.spTotales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spTotales.BackColor = System.Drawing.Color.White
        Me.spTotales.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spTotales.HorizontalScrollBar.Name = ""
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
        Me.spTotales.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer4
        Me.spTotales.HorizontalScrollBar.TabIndex = 10
        Me.spTotales.Location = New System.Drawing.Point(0, 465)
        Me.spTotales.Name = "spTotales"
        Me.spTotales.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spTotales_Sheet1})
        Me.spTotales.Size = New System.Drawing.Size(1028, 23)
        Me.spTotales.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spTotales.TabIndex = 25
        Me.spTotales.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spTotales.VerticalScrollBar.Name = ""
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
        Me.spTotales.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer5
        Me.spTotales.VerticalScrollBar.TabIndex = 11
        '
        'spTotales_Sheet1
        '
        Me.spTotales_Sheet1.Reset()
        spTotales_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spTotales_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spTotales_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spTotales_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spTotales_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spTotales_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spTotales_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spTotales_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spTotales_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spTotales_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spTotales_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spTotales_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spTotales_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'pnlPie
        '
        Me.pnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPie.BackColor = System.Drawing.Color.Black
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.btnAyuda)
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
        Me.Text = "Empaque y Embarques - Recepción"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        Me.pnlCatalogos.ResumeLayout(False)
        CType(Me.spCatalogos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spCatalogos_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCapturaSuperior.ResumeLayout(False)
        Me.pnlCapturaSuperior.PerformLayout()
        CType(Me.spRecepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spRecepcion_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spTotales_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents spRecepcion As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spRecepcion_Sheet1 As FarPoint.Win.Spread.SheetView
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbProductos As System.Windows.Forms.ComboBox
    Friend WithEvents cbLotes As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkConservarDatos As System.Windows.Forms.CheckBox
    Friend WithEvents pnlCatalogos As System.Windows.Forms.Panel
    Friend WithEvents btnIdAnterior As System.Windows.Forms.Button
    Friend WithEvents btnIdSiguiente As System.Windows.Forms.Button
    Friend WithEvents txtHora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbVariedades As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbChoferesCampos As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents spTotales As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spTotales_Sheet1 As FarPoint.Win.Spread.SheetView
End Class
