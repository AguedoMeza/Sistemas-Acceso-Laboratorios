namespace acceso_cc.Formularios
{
    partial class frmDocentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocentes));
            this.dgvInformacionPersona = new System.Windows.Forms.DataGridView();
            this.dgvDocentes = new System.Windows.Forms.DataGridView();
            this.lblBuscarPersona = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscarPersona = new System.Windows.Forms.TextBox();
            this.txtBuscarDocente = new System.Windows.Forms.TextBox();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.gpbInformacion = new System.Windows.Forms.GroupBox();
            this.lblIdPersona = new System.Windows.Forms.Label();
            this.lblExtension = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.gpbBuscarPersona = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacionPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).BeginInit();
            this.gpbInformacion.SuspendLayout();
            this.gpbBuscarPersona.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInformacionPersona
            // 
            this.dgvInformacionPersona.AllowUserToAddRows = false;
            this.dgvInformacionPersona.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInformacionPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInformacionPersona.Location = new System.Drawing.Point(9, 50);
            this.dgvInformacionPersona.Name = "dgvInformacionPersona";
            this.dgvInformacionPersona.Size = new System.Drawing.Size(455, 161);
            this.dgvInformacionPersona.TabIndex = 2;
            this.dgvInformacionPersona.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInformacionPersona_CellClick);
            this.dgvInformacionPersona.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInformacionPersona_CellMouseMove);
            // 
            // dgvDocentes
            // 
            this.dgvDocentes.AllowUserToAddRows = false;
            this.dgvDocentes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocentes.Location = new System.Drawing.Point(99, 304);
            this.dgvDocentes.Name = "dgvDocentes";
            this.dgvDocentes.Size = new System.Drawing.Size(540, 193);
            this.dgvDocentes.TabIndex = 8;
            this.dgvDocentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocentes_CellClick);
            this.dgvDocentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocentes_CellContentClick);
            this.dgvDocentes.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocentes_CellMouseMove);
            // 
            // lblBuscarPersona
            // 
            this.lblBuscarPersona.AutoSize = true;
            this.lblBuscarPersona.Location = new System.Drawing.Point(6, 26);
            this.lblBuscarPersona.Name = "lblBuscarPersona";
            this.lblBuscarPersona.Size = new System.Drawing.Size(43, 13);
            this.lblBuscarPersona.TabIndex = 2;
            this.lblBuscarPersona.Text = "Buscar:";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblBuscar.Location = new System.Drawing.Point(50, 281);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.TabIndex = 6;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscarPersona
            // 
            this.txtBuscarPersona.Location = new System.Drawing.Point(53, 26);
            this.txtBuscarPersona.Name = "txtBuscarPersona";
            this.txtBuscarPersona.Size = new System.Drawing.Size(411, 20);
            this.txtBuscarPersona.TabIndex = 1;
            this.txtBuscarPersona.TextChanged += new System.EventHandler(this.txtBuscarPersona_TextChanged);
            // 
            // txtBuscarDocente
            // 
            this.txtBuscarDocente.Location = new System.Drawing.Point(99, 278);
            this.txtBuscarDocente.Name = "txtBuscarDocente";
            this.txtBuscarDocente.Size = new System.Drawing.Size(540, 20);
            this.txtBuscarDocente.TabIndex = 7;
            this.txtBuscarDocente.TextChanged += new System.EventHandler(this.txtBuscarDocente_TextChanged);
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.Transparent;
            this.btnReporte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReporte.BackgroundImage")));
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Location = new System.Drawing.Point(92, 503);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(160, 56);
            this.btnReporte.TabIndex = 9;
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.BackgroundImage")));
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(486, 503);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(153, 56);
            this.btnExcel.TabIndex = 10;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // gpbInformacion
            // 
            this.gpbInformacion.BackColor = System.Drawing.Color.Transparent;
            this.gpbInformacion.Controls.Add(this.lblIdPersona);
            this.gpbInformacion.Controls.Add(this.lblExtension);
            this.gpbInformacion.Controls.Add(this.lblNombreCompleto);
            this.gpbInformacion.Controls.Add(this.btnCancelar);
            this.gpbInformacion.Controls.Add(this.btnAgregar);
            this.gpbInformacion.Controls.Add(this.txtClave);
            this.gpbInformacion.Controls.Add(this.lblClave);
            this.gpbInformacion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpbInformacion.Location = new System.Drawing.Point(492, 29);
            this.gpbInformacion.Name = "gpbInformacion";
            this.gpbInformacion.Size = new System.Drawing.Size(338, 217);
            this.gpbInformacion.TabIndex = 36;
            this.gpbInformacion.TabStop = false;
            this.gpbInformacion.Text = "Información";
            // 
            // lblIdPersona
            // 
            this.lblIdPersona.AutoSize = true;
            this.lblIdPersona.Location = new System.Drawing.Point(174, 69);
            this.lblIdPersona.Name = "lblIdPersona";
            this.lblIdPersona.Size = new System.Drawing.Size(0, 13);
            this.lblIdPersona.TabIndex = 6;
            this.lblIdPersona.Visible = false;
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(24, 69);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(0, 13);
            this.lblExtension.TabIndex = 5;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Location = new System.Drawing.Point(24, 36);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(0, 13);
            this.lblNombreCompleto.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Location = new System.Drawing.Point(170, 164);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(162, 49);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregar.Location = new System.Drawing.Point(6, 164);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(158, 53);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(102, 127);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(88, 20);
            this.txtClave.TabIndex = 3;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.Location = new System.Drawing.Point(50, 130);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(46, 16);
            this.lblClave.TabIndex = 0;
            this.lblClave.Text = "Clave:";
            // 
            // gpbBuscarPersona
            // 
            this.gpbBuscarPersona.BackColor = System.Drawing.Color.Transparent;
            this.gpbBuscarPersona.Controls.Add(this.lblBuscarPersona);
            this.gpbBuscarPersona.Controls.Add(this.txtBuscarPersona);
            this.gpbBuscarPersona.Controls.Add(this.dgvInformacionPersona);
            this.gpbBuscarPersona.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpbBuscarPersona.Location = new System.Drawing.Point(12, 29);
            this.gpbBuscarPersona.Name = "gpbBuscarPersona";
            this.gpbBuscarPersona.Size = new System.Drawing.Size(474, 217);
            this.gpbBuscarPersona.TabIndex = 39;
            this.gpbBuscarPersona.TabStop = false;
            this.gpbBuscarPersona.Text = "Buscar Persona";
            this.gpbBuscarPersona.Enter += new System.EventHandler(this.gpbBuscarPersona_Enter);
            // 
            // frmDocentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(835, 557);
            this.Controls.Add(this.gpbBuscarPersona);
            this.Controls.Add(this.gpbInformacion);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.txtBuscarDocente);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.dgvDocentes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDocentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Docentes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDocentes_FormClosing);
            this.Load += new System.EventHandler(this.frmDocentes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacionPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes)).EndInit();
            this.gpbInformacion.ResumeLayout(false);
            this.gpbInformacion.PerformLayout();
            this.gpbBuscarPersona.ResumeLayout(false);
            this.gpbBuscarPersona.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInformacionPersona;
        private System.Windows.Forms.DataGridView dgvDocentes;
        private System.Windows.Forms.Label lblBuscarPersona;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscarPersona;
        private System.Windows.Forms.TextBox txtBuscarDocente;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.GroupBox gpbInformacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Label lblIdPersona;
        private System.Windows.Forms.GroupBox gpbBuscarPersona;
    }
}