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
            this.spTarimas = new FarPoint.Win.Spread.FpSpread();
            this.spTarimas_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlEmpresas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTarimas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTarimas_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEmpresas
            // 
            this.pnlEmpresas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlEmpresas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlEmpresas.BackgroundImage")));
            this.pnlEmpresas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlEmpresas.Controls.Add(this.spTarimas);
            this.pnlEmpresas.Location = new System.Drawing.Point(0, -1);
            this.pnlEmpresas.Name = "pnlEmpresas";
            this.pnlEmpresas.Size = new System.Drawing.Size(1032, 405);
            this.pnlEmpresas.TabIndex = 1;
            // 
            // spTarimas
            // 
            this.spTarimas.AccessibleDescription = "";
            this.spTarimas.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spTarimas.Location = new System.Drawing.Point(12, 13);
            this.spTarimas.Name = "spTarimas";
            this.spTarimas.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spTarimas_Sheet1});
            this.spTarimas.Size = new System.Drawing.Size(1007, 378);
            this.spTarimas.TabIndex = 1;
            this.spTarimas.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spTarimas_Sheet1
            // 
            this.spTarimas_Sheet1.Reset();
            spTarimas_Sheet1.SheetName = "Sheet1";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1033, 402);
            this.Controls.Add(this.pnlEmpresas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.Text = "Tarimas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.Load += new System.EventHandler(this.Empresas_Load);
            this.pnlEmpresas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spTarimas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTarimas_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEmpresas;
        private FarPoint.Win.Spread.FpSpread spTarimas;
        private FarPoint.Win.Spread.SheetView spTarimas_Sheet1;
    }
}