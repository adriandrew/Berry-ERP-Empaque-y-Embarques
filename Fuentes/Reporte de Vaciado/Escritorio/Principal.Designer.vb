﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim EnhancedScrollBarRenderer5 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer6 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlCuerpo = New System.Windows.Forms.Panel()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.rbtnVaciado = New System.Windows.Forms.RadioButton()
        Me.rbtnSaldos = New System.Windows.Forms.RadioButton()
        Me.spParaClonar = New FarPoint.Win.Spread.FpSpread()
        Me.spParaClonar_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.gbMasOpciones = New System.Windows.Forms.GroupBox()
        Me.rbtnSinMovimientos = New System.Windows.Forms.RadioButton()
        Me.rbtnConMovimientos = New System.Windows.Forms.RadioButton()
        Me.rbtnTodos = New System.Windows.Forms.RadioButton()
        Me.gbFechas = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.gbOpciones = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbProductor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbVariedad = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbChofer = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbProducto = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbLote = New System.Windows.Forms.ComboBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.spReporte = New FarPoint.Win.Spread.FpSpread()
        Me.spReporte_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.btnExportarPdf = New System.Windows.Forms.Button()
        Me.lblLeyendaParcial = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblDescripcionTooltip = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezadoArea = New System.Windows.Forms.Label()
        Me.lblEncabezadoUsuario = New System.Windows.Forms.Label()
        Me.lblEncabezadoEmpresa = New System.Windows.Forms.Label()
        Me.lblEncabezadoPrograma = New System.Windows.Forms.Label()
        Me.temporizador = New System.Windows.Forms.Timer(Me.components)
        Me.impresor = New System.Windows.Forms.PrintDialog()
        Me.pnlContenido.SuspendLayout()
        Me.pnlCuerpo.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        CType(Me.spParaClonar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spParaClonar_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.gbMasOpciones.SuspendLayout()
        Me.gbFechas.SuspendLayout()
        Me.gbOpciones.SuspendLayout()
        CType(Me.spReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spReporte_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlContenido.BackgroundImage = Global.ReporteVaciado.My.Resources.Resources.Logo3
        Me.pnlContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlContenido.Controls.Add(Me.pnlCuerpo)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Controls.Add(Me.pnlEncabezado)
        Me.pnlContenido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlContenido.Location = New System.Drawing.Point(2, 1)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(1035, 633)
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
        Me.pnlCuerpo.Controls.Add(Me.spParaClonar)
        Me.pnlCuerpo.Controls.Add(Me.pnlFiltros)
        Me.pnlCuerpo.Controls.Add(Me.spReporte)
        Me.pnlCuerpo.Location = New System.Drawing.Point(0, 77)
        Me.pnlCuerpo.Name = "pnlCuerpo"
        Me.pnlCuerpo.Size = New System.Drawing.Size(1035, 494)
        Me.pnlCuerpo.TabIndex = 9
        '
        'pnlMenu
        '
        Me.pnlMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMenu.BackColor = System.Drawing.Color.MintCream
        Me.pnlMenu.Controls.Add(Me.rbtnVaciado)
        Me.pnlMenu.Controls.Add(Me.rbtnSaldos)
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(1035, 40)
        Me.pnlMenu.TabIndex = 35
        '
        'rbtnVaciado
        '
        Me.rbtnVaciado.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnVaciado.AutoSize = True
        Me.rbtnVaciado.BackColor = System.Drawing.Color.Transparent
        Me.rbtnVaciado.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnVaciado.FlatAppearance.BorderSize = 2
        Me.rbtnVaciado.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnVaciado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnVaciado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnVaciado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnVaciado.ForeColor = System.Drawing.Color.Black
        Me.rbtnVaciado.Location = New System.Drawing.Point(7, 3)
        Me.rbtnVaciado.Name = "rbtnVaciado"
        Me.rbtnVaciado.Size = New System.Drawing.Size(93, 32)
        Me.rbtnVaciado.TabIndex = 3
        Me.rbtnVaciado.TabStop = True
        Me.rbtnVaciado.Text = "VACIADO"
        Me.rbtnVaciado.UseVisualStyleBackColor = False
        '
        'rbtnSaldos
        '
        Me.rbtnSaldos.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtnSaldos.AutoSize = True
        Me.rbtnSaldos.BackColor = System.Drawing.Color.Transparent
        Me.rbtnSaldos.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.rbtnSaldos.FlatAppearance.BorderSize = 2
        Me.rbtnSaldos.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumAquamarine
        Me.rbtnSaldos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise
        Me.rbtnSaldos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtnSaldos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSaldos.ForeColor = System.Drawing.Color.Black
        Me.rbtnSaldos.Location = New System.Drawing.Point(105, 3)
        Me.rbtnSaldos.Name = "rbtnSaldos"
        Me.rbtnSaldos.Size = New System.Drawing.Size(88, 32)
        Me.rbtnSaldos.TabIndex = 2
        Me.rbtnSaldos.TabStop = True
        Me.rbtnSaldos.Text = "SALDOS"
        Me.rbtnSaldos.UseVisualStyleBackColor = False
        '
        'spParaClonar
        '
        Me.spParaClonar.AccessibleDescription = ""
        Me.spParaClonar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spParaClonar.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spParaClonar.HorizontalScrollBar.Name = ""
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
        Me.spParaClonar.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer5
        Me.spParaClonar.HorizontalScrollBar.TabIndex = 2
        Me.spParaClonar.Location = New System.Drawing.Point(357, 396)
        Me.spParaClonar.Name = "spParaClonar"
        Me.spParaClonar.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spParaClonar_Sheet1})
        Me.spParaClonar.Size = New System.Drawing.Size(148, 94)
        Me.spParaClonar.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spParaClonar.TabIndex = 33
        Me.spParaClonar.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spParaClonar.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer6.ArrowColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer6.ArrowHoveredColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer6.ArrowSelectedColor = System.Drawing.Color.DarkSlateGray
        EnhancedScrollBarRenderer6.ButtonBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer6.ButtonBorderColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer6.ButtonHoveredBackgroundColor = System.Drawing.Color.SlateGray
        EnhancedScrollBarRenderer6.ButtonHoveredBorderColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer6.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkGray
        EnhancedScrollBarRenderer6.ButtonSelectedBorderColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer6.TrackBarBackgroundColor = System.Drawing.Color.CadetBlue
        EnhancedScrollBarRenderer6.TrackBarSelectedBackgroundColor = System.Drawing.Color.SlateGray
        Me.spParaClonar.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer6
        Me.spParaClonar.VerticalScrollBar.TabIndex = 3
        Me.spParaClonar.Visible = False
        '
        'spParaClonar_Sheet1
        '
        Me.spParaClonar_Sheet1.Reset()
        spParaClonar_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spParaClonar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spParaClonar_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spParaClonar_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spParaClonar_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spParaClonar_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spParaClonar_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spParaClonar_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spParaClonar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlFiltros.AutoScroll = True
        Me.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.gbMasOpciones)
        Me.pnlFiltros.Controls.Add(Me.gbFechas)
        Me.pnlFiltros.Controls.Add(Me.gbOpciones)
        Me.pnlFiltros.Controls.Add(Me.btnGenerar)
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 41)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(355, 453)
        Me.pnlFiltros.TabIndex = 22
        '
        'gbMasOpciones
        '
        Me.gbMasOpciones.BackColor = System.Drawing.Color.Transparent
        Me.gbMasOpciones.Controls.Add(Me.rbtnSinMovimientos)
        Me.gbMasOpciones.Controls.Add(Me.rbtnConMovimientos)
        Me.gbMasOpciones.Controls.Add(Me.rbtnTodos)
        Me.gbMasOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMasOpciones.ForeColor = System.Drawing.Color.White
        Me.gbMasOpciones.Location = New System.Drawing.Point(4, 262)
        Me.gbMasOpciones.Name = "gbMasOpciones"
        Me.gbMasOpciones.Size = New System.Drawing.Size(345, 110)
        Me.gbMasOpciones.TabIndex = 18
        Me.gbMasOpciones.TabStop = False
        Me.gbMasOpciones.Text = "MAS OPCIONES"
        '
        'rbtnSinMovimientos
        '
        Me.rbtnSinMovimientos.AutoSize = True
        Me.rbtnSinMovimientos.Location = New System.Drawing.Point(8, 80)
        Me.rbtnSinMovimientos.Name = "rbtnSinMovimientos"
        Me.rbtnSinMovimientos.Size = New System.Drawing.Size(186, 24)
        Me.rbtnSinMovimientos.TabIndex = 2
        Me.rbtnSinMovimientos.Text = "SIN MOVIMIENTOS"
        Me.rbtnSinMovimientos.UseVisualStyleBackColor = True
        '
        'rbtnConMovimientos
        '
        Me.rbtnConMovimientos.AutoSize = True
        Me.rbtnConMovimientos.Location = New System.Drawing.Point(8, 53)
        Me.rbtnConMovimientos.Name = "rbtnConMovimientos"
        Me.rbtnConMovimientos.Size = New System.Drawing.Size(193, 24)
        Me.rbtnConMovimientos.TabIndex = 1
        Me.rbtnConMovimientos.Text = "CON MOVIMIENTOS"
        Me.rbtnConMovimientos.UseVisualStyleBackColor = True
        '
        'rbtnTodos
        '
        Me.rbtnTodos.AutoSize = True
        Me.rbtnTodos.Checked = True
        Me.rbtnTodos.Location = New System.Drawing.Point(7, 26)
        Me.rbtnTodos.Name = "rbtnTodos"
        Me.rbtnTodos.Size = New System.Drawing.Size(76, 24)
        Me.rbtnTodos.TabIndex = 0
        Me.rbtnTodos.TabStop = True
        Me.rbtnTodos.Text = "TODO"
        Me.rbtnTodos.UseVisualStyleBackColor = True
        '
        'gbFechas
        '
        Me.gbFechas.BackColor = System.Drawing.Color.Transparent
        Me.gbFechas.Controls.Add(Me.Label6)
        Me.gbFechas.Controls.Add(Me.chkFecha)
        Me.gbFechas.Controls.Add(Me.dtpFechaFinal)
        Me.gbFechas.Controls.Add(Me.dtpFecha)
        Me.gbFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFechas.ForeColor = System.Drawing.Color.White
        Me.gbFechas.Location = New System.Drawing.Point(4, 5)
        Me.gbFechas.Name = "gbFechas"
        Me.gbFechas.Size = New System.Drawing.Size(345, 64)
        Me.gbFechas.TabIndex = 17
        Me.gbFechas.TabStop = False
        Me.gbFechas.Text = "RANGO DE FECHAS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(280, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Aplicar?"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'chkFecha
        '
        Me.chkFecha.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFecha.Checked = True
        Me.chkFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkFecha.FlatAppearance.BorderSize = 2
        Me.chkFecha.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen
        Me.chkFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFecha.ForeColor = System.Drawing.Color.White
        Me.chkFecha.Location = New System.Drawing.Point(283, 27)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(45, 25)
        Me.chkFecha.TabIndex = 20
        Me.chkFecha.Text = "SI"
        Me.chkFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFecha.UseVisualStyleBackColor = True
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(149, 27)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(130, 26)
        Me.dtpFechaFinal.TabIndex = 17
        '
        'dtpFecha
        '
        Me.dtpFecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(16, 27)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(130, 26)
        Me.dtpFecha.TabIndex = 0
        '
        'gbOpciones
        '
        Me.gbOpciones.BackColor = System.Drawing.Color.Transparent
        Me.gbOpciones.Controls.Add(Me.Label3)
        Me.gbOpciones.Controls.Add(Me.cbProductor)
        Me.gbOpciones.Controls.Add(Me.Label1)
        Me.gbOpciones.Controls.Add(Me.cbVariedad)
        Me.gbOpciones.Controls.Add(Me.Label2)
        Me.gbOpciones.Controls.Add(Me.cbChofer)
        Me.gbOpciones.Controls.Add(Me.Label11)
        Me.gbOpciones.Controls.Add(Me.cbProducto)
        Me.gbOpciones.Controls.Add(Me.Label10)
        Me.gbOpciones.Controls.Add(Me.cbLote)
        Me.gbOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.ForeColor = System.Drawing.Color.White
        Me.gbOpciones.Location = New System.Drawing.Point(4, 75)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(345, 182)
        Me.gbOpciones.TabIndex = 15
        Me.gbOpciones.TabStop = False
        Me.gbOpciones.Text = "OPCIONES"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(4, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 18)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "PRODUCTOR:"
        '
        'cbProductor
        '
        Me.cbProductor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProductor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProductor.BackColor = System.Drawing.Color.White
        Me.cbProductor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbProductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProductor.FormattingEnabled = True
        Me.cbProductor.Location = New System.Drawing.Point(124, 27)
        Me.cbProductor.Name = "cbProductor"
        Me.cbProductor.Size = New System.Drawing.Size(215, 28)
        Me.cbProductor.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 18)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "VARIEDAD:"
        '
        'cbVariedad
        '
        Me.cbVariedad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbVariedad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbVariedad.BackColor = System.Drawing.Color.White
        Me.cbVariedad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbVariedad.Enabled = False
        Me.cbVariedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVariedad.FormattingEnabled = True
        Me.cbVariedad.Location = New System.Drawing.Point(124, 143)
        Me.cbVariedad.Name = "cbVariedad"
        Me.cbVariedad.Size = New System.Drawing.Size(215, 28)
        Me.cbVariedad.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 18)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "CHOFER:"
        '
        'cbChofer
        '
        Me.cbChofer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbChofer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbChofer.BackColor = System.Drawing.Color.White
        Me.cbChofer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbChofer.FormattingEnabled = True
        Me.cbChofer.Location = New System.Drawing.Point(124, 85)
        Me.cbChofer.Name = "cbChofer"
        Me.cbChofer.Size = New System.Drawing.Size(215, 28)
        Me.cbChofer.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(5, 117)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 18)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "PRODUCTO:"
        '
        'cbProducto
        '
        Me.cbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProducto.BackColor = System.Drawing.Color.White
        Me.cbProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProducto.FormattingEnabled = True
        Me.cbProducto.Location = New System.Drawing.Point(124, 114)
        Me.cbProducto.Name = "cbProducto"
        Me.cbProducto.Size = New System.Drawing.Size(215, 28)
        Me.cbProducto.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(5, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 18)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "LOTE:"
        '
        'cbLote
        '
        Me.cbLote.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbLote.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbLote.BackColor = System.Drawing.Color.White
        Me.cbLote.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLote.FormattingEnabled = True
        Me.cbLote.Location = New System.Drawing.Point(124, 56)
        Me.cbLote.Name = "cbLote"
        Me.cbLote.Size = New System.Drawing.Size(215, 28)
        Me.cbLote.TabIndex = 10
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.White
        Me.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGenerar.FlatAppearance.BorderSize = 3
        Me.btnGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.Black
        Me.btnGenerar.Location = New System.Drawing.Point(200, 378)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(146, 55)
        Me.btnGenerar.TabIndex = 10
        Me.btnGenerar.Text = "GENERAR"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'spReporte
        '
        Me.spReporte.AccessibleDescription = ""
        Me.spReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spReporte.BackColor = System.Drawing.Color.White
        Me.spReporte.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spReporte.HorizontalScrollBar.Name = ""
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
        Me.spReporte.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.spReporte.HorizontalScrollBar.TabIndex = 0
        Me.spReporte.Location = New System.Drawing.Point(357, 41)
        Me.spReporte.Name = "spReporte"
        Me.spReporte.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.spReporte_Sheet1})
        Me.spReporte.Size = New System.Drawing.Size(677, 453)
        Me.spReporte.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        Me.spReporte.TabIndex = 3
        Me.spReporte.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.spReporte.VerticalScrollBar.Name = ""
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
        Me.spReporte.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
        Me.spReporte.VerticalScrollBar.TabIndex = 1
        Me.spReporte.Visible = False
        '
        'spReporte_Sheet1
        '
        Me.spReporte_Sheet1.Reset()
        spReporte_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.spReporte_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.spReporte_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spReporte_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerSeashell"
        Me.spReporte_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSeashell"
        Me.spReporte_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSeashell"
        Me.spReporte_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.spReporte_Sheet1.SheetCornerStyle.Parent = "CornerSeashell"
        Me.spReporte_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'pnlPie
        '
        Me.pnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPie.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPie.Controls.Add(Me.btnAyuda)
        Me.pnlPie.Controls.Add(Me.btnExportarPdf)
        Me.pnlPie.Controls.Add(Me.lblLeyendaParcial)
        Me.pnlPie.Controls.Add(Me.btnExportarExcel)
        Me.pnlPie.Controls.Add(Me.btnImprimir)
        Me.pnlPie.Controls.Add(Me.lblDescripcionTooltip)
        Me.pnlPie.Controls.Add(Me.btnSalir)
        Me.pnlPie.ForeColor = System.Drawing.Color.White
        Me.pnlPie.Location = New System.Drawing.Point(0, 573)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1035, 60)
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
        Me.btnAyuda.TabIndex = 54
        Me.btnAyuda.UseVisualStyleBackColor = False
        '
        'btnExportarPdf
        '
        Me.btnExportarPdf.BackColor = System.Drawing.Color.White
        Me.btnExportarPdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarPdf.Enabled = False
        Me.btnExportarPdf.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnExportarPdf.FlatAppearance.BorderSize = 3
        Me.btnExportarPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportarPdf.Image = CType(resources.GetObject("btnExportarPdf.Image"), System.Drawing.Image)
        Me.btnExportarPdf.Location = New System.Drawing.Point(179, 0)
        Me.btnExportarPdf.Name = "btnExportarPdf"
        Me.btnExportarPdf.Size = New System.Drawing.Size(60, 60)
        Me.btnExportarPdf.TabIndex = 53
        Me.btnExportarPdf.UseVisualStyleBackColor = False
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
        Me.lblLeyendaParcial.TabIndex = 52
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackColor = System.Drawing.Color.White
        Me.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarExcel.Enabled = False
        Me.btnExportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnExportarExcel.FlatAppearance.BorderSize = 3
        Me.btnExportarExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportarExcel.Image = CType(resources.GetObject("btnExportarExcel.Image"), System.Drawing.Image)
        Me.btnExportarExcel.Location = New System.Drawing.Point(120, 0)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(60, 60)
        Me.btnExportarExcel.TabIndex = 50
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.White
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnImprimir.FlatAppearance.BorderSize = 3
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(61, 0)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(60, 60)
        Me.btnImprimir.TabIndex = 51
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblDescripcionTooltip
        '
        Me.lblDescripcionTooltip.AutoSize = True
        Me.lblDescripcionTooltip.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDescripcionTooltip.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionTooltip.ForeColor = System.Drawing.Color.White
        Me.lblDescripcionTooltip.Location = New System.Drawing.Point(254, 15)
        Me.lblDescripcionTooltip.Name = "lblDescripcionTooltip"
        Me.lblDescripcionTooltip.Size = New System.Drawing.Size(0, 31)
        Me.lblDescripcionTooltip.TabIndex = 3
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
        Me.btnSalir.Location = New System.Drawing.Point(973, 0)
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
        Me.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.pnlEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoArea)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoUsuario)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoEmpresa)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoPrograma)
        Me.pnlEncabezado.ForeColor = System.Drawing.Color.White
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1035, 75)
        Me.pnlEncabezado.TabIndex = 7
        '
        'lblEncabezadoArea
        '
        Me.lblEncabezadoArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEncabezadoArea.AutoSize = True
        Me.lblEncabezadoArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoArea.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoArea.Location = New System.Drawing.Point(600, 0)
        Me.lblEncabezadoArea.Name = "lblEncabezadoArea"
        Me.lblEncabezadoArea.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoArea.TabIndex = 3
        '
        'lblEncabezadoUsuario
        '
        Me.lblEncabezadoUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEncabezadoUsuario.AutoSize = True
        Me.lblEncabezadoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoUsuario.ForeColor = System.Drawing.Color.White
        Me.lblEncabezadoUsuario.Location = New System.Drawing.Point(600, 35)
        Me.lblEncabezadoUsuario.Name = "lblEncabezadoUsuario"
        Me.lblEncabezadoUsuario.Size = New System.Drawing.Size(0, 33)
        Me.lblEncabezadoUsuario.TabIndex = 2
        '
        'lblEncabezadoEmpresa
        '
        Me.lblEncabezadoEmpresa.AutoSize = True
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
        'impresor
        '
        Me.impresor.UseEXDialog = True
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 635)
        Me.Controls.Add(Me.pnlContenido)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Principal"
        Me.Text = "Empaque y Embarques - Reporte de Vaciado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlCuerpo.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        CType(Me.spParaClonar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spParaClonar_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.gbMasOpciones.ResumeLayout(False)
        Me.gbMasOpciones.PerformLayout()
        Me.gbFechas.ResumeLayout(False)
        Me.gbFechas.PerformLayout()
        Me.gbOpciones.ResumeLayout(False)
        Me.gbOpciones.PerformLayout()
        CType(Me.spReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spReporte_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblDescripcionTooltip As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoUsuario As System.Windows.Forms.Label
    Private WithEvents lblEncabezadoArea As System.Windows.Forms.Label
    Friend WithEvents spReporte As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spReporte_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents gbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbVariedad As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbChofer As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbLote As System.Windows.Forms.ComboBox
    Friend WithEvents gbFechas As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkFecha As System.Windows.Forms.CheckBox
    Friend WithEvents temporizador As System.Windows.Forms.Timer
    Friend WithEvents btnExportarPdf As System.Windows.Forms.Button
    Friend WithEvents lblLeyendaParcial As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents impresor As System.Windows.Forms.PrintDialog
    Friend WithEvents spParaClonar As FarPoint.Win.Spread.FpSpread
    Friend WithEvents spParaClonar_Sheet1 As FarPoint.Win.Spread.SheetView
    Private WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents pnlMenu As System.Windows.Forms.Panel
    Private WithEvents rbtnVaciado As System.Windows.Forms.RadioButton
    Private WithEvents rbtnSaldos As System.Windows.Forms.RadioButton
    Friend WithEvents gbMasOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnSinMovimientos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnConMovimientos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbProductor As System.Windows.Forms.ComboBox
End Class
