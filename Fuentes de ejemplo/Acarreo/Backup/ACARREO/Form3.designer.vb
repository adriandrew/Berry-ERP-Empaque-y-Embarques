<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim NumberCellType1 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.sp1 = New FarPoint.Win.Spread.FpSpread
        Me.sp1_Sheet1 = New FarPoint.Win.Spread.SheetView
        CType(Me.sp1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sp1_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sp1
        '
        Me.sp1.AccessibleDescription = "sp1, Sheet1, Row 0, Column 0, "
        Me.sp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sp1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sp1.Location = New System.Drawing.Point(18, 12)
        Me.sp1.Name = "sp1"
        Me.sp1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sp1_Sheet1})
        Me.sp1.Size = New System.Drawing.Size(360, 304)
        Me.sp1.TabIndex = 0
        '
        'sp1_Sheet1
        '
        Me.sp1_Sheet1.Reset()
        sp1_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.sp1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.sp1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "No."
        Me.sp1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "NOMBRE"
        NumberCellType1.DecimalPlaces = 0
        NumberCellType1.MaximumValue = 10000000
        NumberCellType1.MinimumValue = -10000000
        Me.sp1_Sheet1.Columns.Get(0).CellType = NumberCellType1
        Me.sp1_Sheet1.Columns.Get(0).Label = "No."
        Me.sp1_Sheet1.Columns.Get(0).Width = 41.0!
        Me.sp1_Sheet1.Columns.Get(1).CellType = TextCellType1
        Me.sp1_Sheet1.Columns.Get(1).Label = "NOMBRE"
        Me.sp1_Sheet1.Columns.Get(1).Width = 263.0!
        Me.sp1_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.sp1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 333)
        Me.Controls.Add(Me.sp1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.Text = "Grupos de Producto"
        Me.TopMost = True
        CType(Me.sp1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sp1_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sp1 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sp1_Sheet1 As FarPoint.Win.Spread.SheetView
End Class
