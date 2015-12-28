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
            this.pnlEmpresas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTarima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTarima_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEmpresas
            // 
            this.pnlEmpresas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlEmpresas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
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
            this.spTarima.Size = new System.Drawing.Size(1007, 384);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEmpresas;
        private FarPoint.Win.Spread.FpSpread spTarima;
        private FarPoint.Win.Spread.SheetView spTarima_Sheet1;
    }
}