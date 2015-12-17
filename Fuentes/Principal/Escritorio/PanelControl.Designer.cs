namespace Escritorio
{
    partial class PanelControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelControl));
            this.panelContenido = new System.Windows.Forms.Panel();
            this.cbEmpresas = new System.Windows.Forms.ComboBox();
            this.spAdministrar = new FarPoint.Win.Spread.FpSpread();
            this.spAdministrar_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.rbtnProgramas = new System.Windows.Forms.RadioButton();
            this.rbtnEmpresas = new System.Windows.Forms.RadioButton();
            this.rbtnUsuarios = new System.Windows.Forms.RadioButton();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelContenido.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelContenido.BackgroundImage")));
            this.panelContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelContenido.Controls.Add(this.cbEmpresas);
            this.panelContenido.Controls.Add(this.spAdministrar);
            this.panelContenido.Controls.Add(this.rbtnProgramas);
            this.panelContenido.Controls.Add(this.rbtnEmpresas);
            this.panelContenido.Controls.Add(this.rbtnUsuarios);
            this.panelContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelContenido.Location = new System.Drawing.Point(0, 1);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1055, 370);
            this.panelContenido.TabIndex = 2;
            // 
            // cbEmpresas
            // 
            this.cbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresas.FormattingEnabled = true;
            this.cbEmpresas.Location = new System.Drawing.Point(12, 124);
            this.cbEmpresas.Name = "cbEmpresas";
            this.cbEmpresas.Size = new System.Drawing.Size(161, 28);
            this.cbEmpresas.TabIndex = 4;
            this.cbEmpresas.Visible = false;
            this.cbEmpresas.SelectedIndexChanged += new System.EventHandler(this.cbEmpresas_SelectedIndexChanged);
            // 
            // spAdministrar
            // 
            this.spAdministrar.AccessibleDescription = "";
            this.spAdministrar.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spAdministrar.Location = new System.Drawing.Point(179, 11);
            this.spAdministrar.Name = "spAdministrar";
            this.spAdministrar.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spAdministrar_Sheet1});
            this.spAdministrar.Size = new System.Drawing.Size(865, 344);
            this.spAdministrar.TabIndex = 3;
            this.spAdministrar.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spAdministrar.Visible = false;
            this.spAdministrar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spAdministrar_KeyDown);
            // 
            // spAdministrar_Sheet1
            // 
            this.spAdministrar_Sheet1.Reset();
            spAdministrar_Sheet1.SheetName = "Sheet1";
            // 
            // rbtnProgramas
            // 
            this.rbtnProgramas.AutoSize = true;
            this.rbtnProgramas.ForeColor = System.Drawing.Color.White;
            this.rbtnProgramas.Location = new System.Drawing.Point(12, 79);
            this.rbtnProgramas.Name = "rbtnProgramas";
            this.rbtnProgramas.Size = new System.Drawing.Size(119, 28);
            this.rbtnProgramas.TabIndex = 2;
            this.rbtnProgramas.TabStop = true;
            this.rbtnProgramas.Text = "Programas";
            this.rbtnProgramas.UseVisualStyleBackColor = true;
            // 
            // rbtnEmpresas
            // 
            this.rbtnEmpresas.AutoSize = true;
            this.rbtnEmpresas.ForeColor = System.Drawing.Color.White;
            this.rbtnEmpresas.Location = new System.Drawing.Point(12, 45);
            this.rbtnEmpresas.Name = "rbtnEmpresas";
            this.rbtnEmpresas.Size = new System.Drawing.Size(113, 28);
            this.rbtnEmpresas.TabIndex = 1;
            this.rbtnEmpresas.TabStop = true;
            this.rbtnEmpresas.Text = "Empresas";
            this.rbtnEmpresas.UseVisualStyleBackColor = true;
            this.rbtnEmpresas.CheckedChanged += new System.EventHandler(this.rbtnEmpresas_CheckedChanged);
            // 
            // rbtnUsuarios
            // 
            this.rbtnUsuarios.AutoSize = true;
            this.rbtnUsuarios.ForeColor = System.Drawing.Color.White;
            this.rbtnUsuarios.Location = new System.Drawing.Point(12, 11);
            this.rbtnUsuarios.Name = "rbtnUsuarios";
            this.rbtnUsuarios.Size = new System.Drawing.Size(101, 28);
            this.rbtnUsuarios.TabIndex = 0;
            this.rbtnUsuarios.TabStop = true;
            this.rbtnUsuarios.Text = "Usuarios";
            this.rbtnUsuarios.UseVisualStyleBackColor = true;
            this.rbtnUsuarios.CheckedChanged += new System.EventHandler(this.rbtnUsuarios_CheckedChanged);
            // 
            // PanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 368);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PanelControl";
            this.Text = "Panel de Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PanelControl_FormClosed);
            this.Load += new System.EventHandler(this.PanelControl_Load);
            this.Shown += new System.EventHandler(this.PanelControl_Shown);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAdministrar_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private FarPoint.Win.Spread.FpSpread spAdministrar;
        private FarPoint.Win.Spread.SheetView spAdministrar_Sheet1;
        private System.Windows.Forms.RadioButton rbtnProgramas;
        private System.Windows.Forms.RadioButton rbtnEmpresas;
        private System.Windows.Forms.RadioButton rbtnUsuarios;
        private System.Windows.Forms.ComboBox cbEmpresas;
    }
}