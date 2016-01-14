namespace Principal
{
    partial class Catalogos
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
            this.spCatalogos = new FarPoint.Win.Spread.FpSpread();
            this.spCatalogos_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.spCatalogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCatalogos_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spCatalogos
            // 
            this.spCatalogos.AccessibleDescription = "";
            this.spCatalogos.Location = new System.Drawing.Point(13, 13);
            this.spCatalogos.Name = "spCatalogos";
            this.spCatalogos.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spCatalogos_Sheet1});
            this.spCatalogos.Size = new System.Drawing.Size(600, 287);
            this.spCatalogos.TabIndex = 0;
            // 
            // spCatalogos_Sheet1
            // 
            this.spCatalogos_Sheet1.Reset();
            spCatalogos_Sheet1.SheetName = "Sheet1";
            // 
            // Catalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 312);
            this.Controls.Add(this.spCatalogos);
            this.Name = "Catalogos";
            this.Text = "Catálogos";
            this.Load += new System.EventHandler(this.Catalogos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spCatalogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCatalogos_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread spCatalogos;
        private FarPoint.Win.Spread.SheetView spCatalogos_Sheet1;

    }
}