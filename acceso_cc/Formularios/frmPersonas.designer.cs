namespace acceso_cc.Formularios
{
    partial class frmPersonas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonas));
            this.gpbInformacion = new System.Windows.Forms.GroupBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.mskTelefono = new System.Windows.Forms.MaskedTextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.rdbHombre = new System.Windows.Forms.RadioButton();
            this.rdbMujer = new System.Windows.Forms.RadioButton();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtApMaterno = new System.Windows.Forms.TextBox();
            this.lblApMaterno = new System.Windows.Forms.Label();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            this.lblApPaterno = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gpbDomicilio = new System.Windows.Forms.GroupBox();
            this.cbxMunicipio = new System.Windows.Forms.ComboBox();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.mskCP = new System.Windows.Forms.MaskedTextBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.lblColonia = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvInformacion = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.lblExtension = new System.Windows.Forms.Label();
            this.cbxExtension = new System.Windows.Forms.ComboBox();
            this.gpbInformacion.SuspendLayout();
            this.gpbDomicilio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbInformacion
            // 
            this.gpbInformacion.BackColor = System.Drawing.Color.Transparent;
            this.gpbInformacion.Controls.Add(this.txtCorreo);
            this.gpbInformacion.Controls.Add(this.lblCorreo);
            this.gpbInformacion.Controls.Add(this.dtpFechaNacimiento);
            this.gpbInformacion.Controls.Add(this.mskTelefono);
            this.gpbInformacion.Controls.Add(this.lblTelefono);
            this.gpbInformacion.Controls.Add(this.rdbHombre);
            this.gpbInformacion.Controls.Add(this.rdbMujer);
            this.gpbInformacion.Controls.Add(this.lblSexo);
            this.gpbInformacion.Controls.Add(this.lblFechaNacimiento);
            this.gpbInformacion.Controls.Add(this.txtApMaterno);
            this.gpbInformacion.Controls.Add(this.lblApMaterno);
            this.gpbInformacion.Controls.Add(this.txtApPaterno);
            this.gpbInformacion.Controls.Add(this.lblApPaterno);
            this.gpbInformacion.Controls.Add(this.txtNombre);
            this.gpbInformacion.Controls.Add(this.lblNombre);
            this.gpbInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbInformacion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpbInformacion.Location = new System.Drawing.Point(12, 49);
            this.gpbInformacion.Name = "gpbInformacion";
            this.gpbInformacion.Size = new System.Drawing.Size(925, 141);
            this.gpbInformacion.TabIndex = 0;
            this.gpbInformacion.TabStop = false;
            this.gpbInformacion.Text = "Información Personal";
            this.gpbInformacion.Enter += new System.EventHandler(this.gpbInformacion_Enter);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(694, 95);
            this.txtCorreo.MaxLength = 25;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(211, 20);
            this.txtCorreo.TabIndex = 15;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(647, 95);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(41, 13);
            this.lblCorreo.TabIndex = 14;
            this.lblCorreo.Text = "Correo:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.CustomFormat = "yyyy-MM-dd";
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(130, 95);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(118, 20);
            this.dtpFechaNacimiento.TabIndex = 8;
            this.dtpFechaNacimiento.ValueChanged += new System.EventHandler(this.dtpFechaNacimiento_ValueChanged);
            // 
            // mskTelefono
            // 
            this.mskTelefono.Location = new System.Drawing.Point(486, 95);
            this.mskTelefono.Mask = "(999)000-0000";
            this.mskTelefono.Name = "mskTelefono";
            this.mskTelefono.Size = new System.Drawing.Size(137, 20);
            this.mskTelefono.TabIndex = 13;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(428, 95);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 12;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // rdbHombre
            // 
            this.rdbHombre.AutoSize = true;
            this.rdbHombre.Location = new System.Drawing.Point(325, 105);
            this.rdbHombre.Name = "rdbHombre";
            this.rdbHombre.Size = new System.Drawing.Size(62, 17);
            this.rdbHombre.TabIndex = 11;
            this.rdbHombre.TabStop = true;
            this.rdbHombre.Text = "Hombre";
            this.rdbHombre.UseVisualStyleBackColor = true;
            // 
            // rdbMujer
            // 
            this.rdbMujer.AutoSize = true;
            this.rdbMujer.Location = new System.Drawing.Point(325, 82);
            this.rdbMujer.Name = "rdbMujer";
            this.rdbMujer.Size = new System.Drawing.Size(51, 17);
            this.rdbMujer.TabIndex = 10;
            this.rdbMujer.TabStop = true;
            this.rdbMujer.Text = "Mujer";
            this.rdbMujer.UseVisualStyleBackColor = true;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(276, 95);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(34, 13);
            this.lblSexo.TabIndex = 9;
            this.lblSexo.Text = "Sexo:";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(15, 95);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(109, 13);
            this.lblFechaNacimiento.TabIndex = 7;
            this.lblFechaNacimiento.Text = "Fecha de nacimiento:";
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.Location = new System.Drawing.Point(654, 37);
            this.txtApMaterno.MaxLength = 25;
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(168, 20);
            this.txtApMaterno.TabIndex = 6;
            // 
            // lblApMaterno
            // 
            this.lblApMaterno.AutoSize = true;
            this.lblApMaterno.Location = new System.Drawing.Point(560, 40);
            this.lblApMaterno.Name = "lblApMaterno";
            this.lblApMaterno.Size = new System.Drawing.Size(88, 13);
            this.lblApMaterno.TabIndex = 5;
            this.lblApMaterno.Text = "Apellido materno:";
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.Location = new System.Drawing.Point(365, 37);
            this.txtApPaterno.MaxLength = 25;
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(168, 20);
            this.txtApPaterno.TabIndex = 4;
            // 
            // lblApPaterno
            // 
            this.lblApPaterno.AutoSize = true;
            this.lblApPaterno.Location = new System.Drawing.Point(264, 40);
            this.lblApPaterno.Name = "lblApPaterno";
            this.lblApPaterno.Size = new System.Drawing.Size(86, 13);
            this.lblApPaterno.TabIndex = 3;
            this.lblApPaterno.Text = "Apellido paterno:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(68, 37);
            this.txtNombre.MaxLength = 25;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(168, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(15, 37);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // gpbDomicilio
            // 
            this.gpbDomicilio.BackColor = System.Drawing.Color.Transparent;
            this.gpbDomicilio.Controls.Add(this.cbxMunicipio);
            this.gpbDomicilio.Controls.Add(this.cbxEstado);
            this.gpbDomicilio.Controls.Add(this.txtNumero);
            this.gpbDomicilio.Controls.Add(this.btnCancelar);
            this.gpbDomicilio.Controls.Add(this.btnAgregar);
            this.gpbDomicilio.Controls.Add(this.mskCP);
            this.gpbDomicilio.Controls.Add(this.lblCP);
            this.gpbDomicilio.Controls.Add(this.lblNum);
            this.gpbDomicilio.Controls.Add(this.txtCalle);
            this.gpbDomicilio.Controls.Add(this.lblCalle);
            this.gpbDomicilio.Controls.Add(this.txtColonia);
            this.gpbDomicilio.Controls.Add(this.lblColonia);
            this.gpbDomicilio.Controls.Add(this.lblMunicipio);
            this.gpbDomicilio.Controls.Add(this.lblEstado);
            this.gpbDomicilio.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpbDomicilio.Location = new System.Drawing.Point(12, 196);
            this.gpbDomicilio.Name = "gpbDomicilio";
            this.gpbDomicilio.Size = new System.Drawing.Size(925, 144);
            this.gpbDomicilio.TabIndex = 1;
            this.gpbDomicilio.TabStop = false;
            this.gpbDomicilio.Text = "Domicilio";
            this.gpbDomicilio.Enter += new System.EventHandler(this.gpbDomicilio_Enter);
            // 
            // cbxMunicipio
            // 
            this.cbxMunicipio.FormattingEnabled = true;
            this.cbxMunicipio.Location = new System.Drawing.Point(299, 26);
            this.cbxMunicipio.Name = "cbxMunicipio";
            this.cbxMunicipio.Size = new System.Drawing.Size(154, 21);
            this.cbxMunicipio.TabIndex = 19;
            // 
            // cbxEstado
            // 
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Location = new System.Drawing.Point(64, 25);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(154, 21);
            this.cbxEstado.TabIndex = 17;
            this.cbxEstado.SelectedIndexChanged += new System.EventHandler(this.cbxEstado_SelectedIndexChanged);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(84, 76);
            this.txtNumero.MaxLength = 25;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(119, 20);
            this.txtNumero.TabIndex = 25;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Location = new System.Drawing.Point(762, 86);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(158, 52);
            this.btnCancelar.TabIndex = 29;
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
            this.btnAgregar.Location = new System.Drawing.Point(611, 86);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(155, 53);
            this.btnAgregar.TabIndex = 28;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // mskCP
            // 
            this.mskCP.Location = new System.Drawing.Point(279, 79);
            this.mskCP.Mask = "00000";
            this.mskCP.Name = "mskCP";
            this.mskCP.Size = new System.Drawing.Size(110, 20);
            this.mskCP.TabIndex = 27;
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Location = new System.Drawing.Point(238, 86);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(27, 13);
            this.lblCP.TabIndex = 26;
            this.lblCP.Text = "C.P:";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(15, 76);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(63, 13);
            this.lblNum.TabIndex = 24;
            this.lblNum.Text = "Numero (#):";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(727, 29);
            this.txtCalle.MaxLength = 25;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(168, 20);
            this.txtCalle.TabIndex = 23;
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(694, 29);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(33, 13);
            this.lblCalle.TabIndex = 22;
            this.lblCalle.Text = "Calle:";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(520, 26);
            this.txtColonia.MaxLength = 25;
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(168, 20);
            this.txtColonia.TabIndex = 21;
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Location = new System.Drawing.Point(473, 29);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(45, 13);
            this.lblColonia.TabIndex = 20;
            this.lblColonia.Text = "Colonia:";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(238, 29);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(55, 13);
            this.lblMunicipio.TabIndex = 18;
            this.lblMunicipio.Text = "Municipio:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(15, 29);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 16;
            this.lblEstado.Text = "Estado:";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Location = new System.Drawing.Point(12, 358);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.TabIndex = 30;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(61, 355);
            this.txtBuscar.MaxLength = 25;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(876, 20);
            this.txtBuscar.TabIndex = 31;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dgvInformacion
            // 
            this.dgvInformacion.AllowUserToAddRows = false;
            this.dgvInformacion.AllowUserToDeleteRows = false;
            this.dgvInformacion.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInformacion.Location = new System.Drawing.Point(12, 381);
            this.dgvInformacion.Name = "dgvInformacion";
            this.dgvInformacion.Size = new System.Drawing.Size(925, 264);
            this.dgvInformacion.TabIndex = 32;
            this.dgvInformacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInformacion_CellClick_1);
            this.dgvInformacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInformacion_CellContentClick);
            this.dgvInformacion.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInformacion_CellMouseMove_1);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.BackgroundImage")));
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(623, 654);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(159, 50);
            this.btnExcel.TabIndex = 33;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.Transparent;
            this.btnReporte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReporte.BackgroundImage")));
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Location = new System.Drawing.Point(774, 653);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(150, 50);
            this.btnReporte.TabIndex = 34;
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.BackColor = System.Drawing.Color.Transparent;
            this.lblExtension.ForeColor = System.Drawing.Color.White;
            this.lblExtension.Location = new System.Drawing.Point(602, 25);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(59, 13);
            this.lblExtension.TabIndex = 37;
            this.lblExtension.Text = "Extensión: ";
            // 
            // cbxExtension
            // 
            this.cbxExtension.FormattingEnabled = true;
            this.cbxExtension.Location = new System.Drawing.Point(667, 22);
            this.cbxExtension.Name = "cbxExtension";
            this.cbxExtension.Size = new System.Drawing.Size(121, 21);
            this.cbxExtension.TabIndex = 1;
            this.cbxExtension.SelectedIndexChanged += new System.EventHandler(this.cbxExtension_SelectedIndexChanged);
            // 
            // frmPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(949, 711);
            this.Controls.Add(this.cbxExtension);
            this.Controls.Add(this.lblExtension);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dgvInformacion);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.gpbDomicilio);
            this.Controls.Add(this.gpbInformacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.frmPersonas_Load);
            this.gpbInformacion.ResumeLayout(false);
            this.gpbInformacion.PerformLayout();
            this.gpbDomicilio.ResumeLayout(false);
            this.gpbDomicilio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbInformacion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApPaterno;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.TextBox txtApMaterno;
        private System.Windows.Forms.Label lblApMaterno;
        private System.Windows.Forms.TextBox txtApPaterno;
        private System.Windows.Forms.RadioButton rdbHombre;
        private System.Windows.Forms.RadioButton rdbMujer;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.GroupBox gpbDomicilio;
        private System.Windows.Forms.MaskedTextBox mskTelefono;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.MaskedTextBox mskCP;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvInformacion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.ComboBox cbxMunicipio;
        private System.Windows.Forms.ComboBox cbxEstado;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.ComboBox cbxExtension;
    }
}