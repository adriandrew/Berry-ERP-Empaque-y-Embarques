namespace Escritorio
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
            this.spCatalogo = new FarPoint.Win.Spread.FpSpread();
            this.spCatalogo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.spCatalogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCatalogo_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spCatalogo
            // 
            this.spCatalogo.AccessibleDescription = "";
            this.spCatalogo.Location = new System.Drawing.Point(13, 13);
            this.spCatalogo.Name = "spCatalogo";
            this.spCatalogo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spCatalogo_Sheet1});
            this.spCatalogo.Size = new System.Drawing.Size(1100, 287);
            this.spCatalogo.TabIndex = 0;
            this.spCatalogo.DialogKey += new FarPoint.Win.Spread.DialogKeyEventHandler(this.spCatalogo_DialogKey);
            this.spCatalogo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spCatalogo_KeyDown);
            // 
            // spCatalogo_Sheet1
            // 
            this.spCatalogo_Sheet1.Reset();
            spCatalogo_Sheet1.SheetName = "Sheet1";
            // 
            // Catalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 312);
            this.Controls.Add(this.spCatalogo);
            this.Name = "Catalogos";
            this.Text = "Catálogos";
            this.Load += new System.EventHandler(this.Catalogos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spCatalogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCatalogo_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread spCatalogo;
        private FarPoint.Win.Spread.SheetView spCatalogo_Sheet1;

    }
}