namespace Escritorio
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.pnlEmpresas = new System.Windows.Forms.Panel();
            this.spTarima = new FarPoint.Win.Spread.FpSpread();
            this.spTarima_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlEmpresas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTarima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTarima_Sheet1)).BeginInit();
            this.panelOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEmpresas
            // 
            this.pnlEmpresas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlEmpresas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlEmpresas.Controls.Add(this.panelOpciones);
            this.pnlEmpresas.Controls.Add(this.spTarima);
            this.pnlEmpresas.Location = new System.Drawing.Point(2, 2);
            this.pnlEmpresas.Name = "pnlEmpresas";
            this.pnlEmpresas.Size = new System.Drawing.Size(1032, 409);
            this.pnlEmpresas.TabIndex = 2;
            // 
            // spTarima
            // 
            this.spTarima.AccessibleDescription = "";
            this.spTarima.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spTarima.Location = new System.Drawing.Point(12, 13);
            this.spTarima.Name = "spTarima";
            this.spTarima.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spTarima_Sheet1});
            this.spTarima.Size = new System.Drawing.Size(1007, 329);
            this.spTarima.TabIndex = 1;
            this.spTarima.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spTarima.DialogKey += new FarPoint.Win.Spread.DialogKeyEventHandler(this.spTarima_DialogKey);
            this.spTarima.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spTarimas_KeyDown);
            // 
            // spTarima_Sheet1
            // 
            this.spTarima_Sheet1.Reset();
            spTarima_Sheet1.SheetName = "Sheet1";
            // 
            // panelOpciones
            // 
            this.panelOpciones.BackColor = System.Drawing.Color.White;
            this.panelOpciones.Controls.Add(this.btnGuardar);
            this.panelOpciones.Location = new System.Drawing.Point(0, 348);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(1032, 61);
            this.panelOpciones.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(959, 1);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(60, 60);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 411);
            this.Controls.Add(this.pnlEmpresas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.Text = "Tarimas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.pnlEmpresas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spTarima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTarima_Sheet1)).EndInit();
            this.panelOpciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEmpresas;
        private FarPoint.Win.Spread.FpSpread spTarima;
        private FarPoint.Win.Spread.SheetView spTarima_Sheet1;
        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.Button btnGuardar;
    }
}