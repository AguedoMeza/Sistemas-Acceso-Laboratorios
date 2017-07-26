namespace acceso_cc.Formularios
{
    partial class frmExtensionActualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtensionActualizar));
            this.gpbInformacion = new System.Windows.Forms.GroupBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.brnCancelar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.mskTelefono = new System.Windows.Forms.MaskedTextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.rtbDireccion = new System.Windows.Forms.RichTextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gpbInformacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbInformacion
            // 
            this.gpbInformacion.Controls.Add(this.txtCorreo);
            this.gpbInformacion.Controls.Add(this.brnCancelar);
            this.gpbInformacion.Controls.Add(this.btnActualizar);
            this.gpbInformacion.Controls.Add(this.lblCorreo);
            this.gpbInformacion.Controls.Add(this.mskTelefono);
            this.gpbInformacion.Controls.Add(this.lblTelefono);
            this.gpbInformacion.Controls.Add(this.rtbDireccion);
            this.gpbInformacion.Controls.Add(this.lblDireccion);
            this.gpbInformacion.Controls.Add(this.txtNombre);
            this.gpbInformacion.Controls.Add(this.lblNombre);
            this.gpbInformacion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpbInformacion.Location = new System.Drawing.Point(26, 12);
            this.gpbInformacion.Name = "gpbInformacion";
            this.gpbInformacion.Size = new System.Drawing.Size(764, 168);
            this.gpbInformacion.TabIndex = 1;
            this.gpbInformacion.TabStop = false;
            this.gpbInformacion.Text = "Información";
            // 
            // txtCorreo
            // 
            this.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtCorreo.Location = new System.Drawing.Point(447, 76);
            this.txtCorreo.MaxLength = 25;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(168, 20);
            this.txtCorreo.TabIndex = 10;
            // 
            // brnCancelar
            // 
            this.brnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("brnCancelar.BackgroundImage")));
            this.brnCancelar.FlatAppearance.BorderSize = 0;
            this.brnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.brnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.brnCancelar.Location = new System.Drawing.Point(581, 113);
            this.brnCancelar.Name = "brnCancelar";
            this.brnCancelar.Size = new System.Drawing.Size(159, 53);
            this.brnCancelar.TabIndex = 9;
            this.brnCancelar.UseVisualStyleBackColor = true;
            this.brnCancelar.Click += new System.EventHandler(this.brnCancelar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.BackgroundImage")));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnActualizar.Location = new System.Drawing.Point(427, 115);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(159, 51);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(390, 80);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(41, 13);
            this.lblCorreo.TabIndex = 6;
            this.lblCorreo.Text = "Correo:";
            // 
            // mskTelefono
            // 
            this.mskTelefono.Location = new System.Drawing.Point(68, 80);
            this.mskTelefono.Mask = "(999)000-0000";
            this.mskTelefono.Name = "mskTelefono";
            this.mskTelefono.Size = new System.Drawing.Size(168, 20);
            this.mskTelefono.TabIndex = 5;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(15, 83);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // rtbDireccion
            // 
            this.rtbDireccion.Location = new System.Drawing.Point(447, 26);
            this.rtbDireccion.MaxLength = 80;
            this.rtbDireccion.Name = "rtbDireccion";
            this.rtbDireccion.Size = new System.Drawing.Size(293, 36);
            this.rtbDireccion.TabIndex = 3;
            this.rtbDireccion.Text = "";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(387, 38);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(68, 35);
            this.txtNombre.MaxLength = 25;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(168, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(15, 38);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // frmExtensionActualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(817, 198);
            this.Controls.Add(this.gpbInformacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExtensionActualizar";
            this.Text = "Actualizar ";
            this.Load += new System.EventHandler(this.frmExtensionActualizar_Load);
            this.gpbInformacion.ResumeLayout(false);
            this.gpbInformacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbInformacion;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button brnCancelar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.MaskedTextBox mskTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.RichTextBox rtbDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;

    }
}