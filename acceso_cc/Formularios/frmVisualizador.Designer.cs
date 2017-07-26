namespace acceso_cc.Formularios
{
    partial class frmVisualizador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizador));
            this.crvVisualizador = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvVisualizador
            // 
            this.crvVisualizador.ActiveViewIndex = -1;
            this.crvVisualizador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVisualizador.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVisualizador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVisualizador.Location = new System.Drawing.Point(0, 0);
            this.crvVisualizador.Name = "crvVisualizador";
            this.crvVisualizador.Size = new System.Drawing.Size(973, 626);
            this.crvVisualizador.TabIndex = 0;
            // 
            // frmVisualizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 626);
            this.Controls.Add(this.crvVisualizador);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVisualizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizador";
            this.Load += new System.EventHandler(this.frmVisualizador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVisualizador;
    }
}