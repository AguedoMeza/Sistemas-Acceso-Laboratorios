namespace acceso_cc.Formularios
{
    partial class frmEntradas_Salidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntradas_Salidas));
            this.gpbDocentes = new System.Windows.Forms.GroupBox();
            this.dgvInformacion = new System.Windows.Forms.DataGridView();
            this.cboExtension = new System.Windows.Forms.ComboBox();
            this.gpbPeriodo = new System.Windows.Forms.GroupBox();
            this.lblCE = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboCiclo = new System.Windows.Forms.ComboBox();
            this.gpbGrupo = new System.Windows.Forms.GroupBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cboTurno = new System.Windows.Forms.ComboBox();
            this.lblTetra = new System.Windows.Forms.Label();
            this.lblSiglas = new System.Windows.Forms.Label();
            this.lbltipoCarrera = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.cboLGrupo = new System.Windows.Forms.ComboBox();
            this.cboTetra = new System.Windows.Forms.ComboBox();
            this.cboSiglas = new System.Windows.Forms.ComboBox();
            this.cboTipoCarrera = new System.Windows.Forms.ComboBox();
            this.gpbLaboratorio = new System.Windows.Forms.GroupBox();
            this.cboLaboratorios = new System.Windows.Forms.ComboBox();
            this.gpbFecha = new System.Windows.Forms.GroupBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.gpbDocenteSelec = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblExtension = new System.Windows.Forms.Label();
            this.lblDocente = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvRegistroES = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEcxel = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.gpbDocentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).BeginInit();
            this.gpbPeriodo.SuspendLayout();
            this.gpbGrupo.SuspendLayout();
            this.gpbLaboratorio.SuspendLayout();
            this.gpbFecha.SuspendLayout();
            this.gpbDocenteSelec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroES)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbDocentes
            // 
            this.gpbDocentes.Controls.Add(this.dgvInformacion);
            this.gpbDocentes.Controls.Add(this.cboExtension);
            this.gpbDocentes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbDocentes.Location = new System.Drawing.Point(12, 12);
            this.gpbDocentes.Name = "gpbDocentes";
            this.gpbDocentes.Size = new System.Drawing.Size(621, 223);
            this.gpbDocentes.TabIndex = 0;
            this.gpbDocentes.TabStop = false;
            this.gpbDocentes.Text = "Información de Docentes";
            // 
            // dgvInformacion
            // 
            this.dgvInformacion.AllowUserToAddRows = false;
            this.dgvInformacion.AllowUserToDeleteRows = false;
            this.dgvInformacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvInformacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInformacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInformacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInformacion.Location = new System.Drawing.Point(133, 12);
            this.dgvInformacion.Name = "dgvInformacion";
            this.dgvInformacion.Size = new System.Drawing.Size(482, 205);
            this.dgvInformacion.TabIndex = 30;
            this.dgvInformacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInformacion_CellClick);
            this.dgvInformacion.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInformacion_CellMouseMove);
            // 
            // cboExtension
            // 
            this.cboExtension.FormattingEnabled = true;
            this.cboExtension.Location = new System.Drawing.Point(6, 83);
            this.cboExtension.Name = "cboExtension";
            this.cboExtension.Size = new System.Drawing.Size(121, 21);
            this.cboExtension.TabIndex = 0;
            this.cboExtension.SelectedIndexChanged += new System.EventHandler(this.cboExtension_SelectedIndexChanged);
            // 
            // gpbPeriodo
            // 
            this.gpbPeriodo.Controls.Add(this.lblCE);
            this.gpbPeriodo.Controls.Add(this.lblYear);
            this.gpbPeriodo.Controls.Add(this.cboYear);
            this.gpbPeriodo.Controls.Add(this.cboCiclo);
            this.gpbPeriodo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbPeriodo.Location = new System.Drawing.Point(12, 253);
            this.gpbPeriodo.Name = "gpbPeriodo";
            this.gpbPeriodo.Size = new System.Drawing.Size(237, 69);
            this.gpbPeriodo.TabIndex = 31;
            this.gpbPeriodo.TabStop = false;
            this.gpbPeriodo.Text = "Periodo";
            // 
            // lblCE
            // 
            this.lblCE.AutoSize = true;
            this.lblCE.Location = new System.Drawing.Point(16, 26);
            this.lblCE.Name = "lblCE";
            this.lblCE.Size = new System.Drawing.Size(68, 13);
            this.lblCE.TabIndex = 13;
            this.lblCE.Text = "Ciclo Escolar";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(149, 26);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(26, 13);
            this.lblYear.TabIndex = 12;
            this.lblYear.Text = "Año";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(133, 42);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(86, 21);
            this.cboYear.TabIndex = 1;
            this.cboYear.Text = "2016";
            // 
            // cboCiclo
            // 
            this.cboCiclo.FormattingEnabled = true;
            this.cboCiclo.Location = new System.Drawing.Point(6, 42);
            this.cboCiclo.Name = "cboCiclo";
            this.cboCiclo.Size = new System.Drawing.Size(121, 21);
            this.cboCiclo.TabIndex = 0;
            this.cboCiclo.Text = "Ene - Abr";
            // 
            // gpbGrupo
            // 
            this.gpbGrupo.Controls.Add(this.lblTurno);
            this.gpbGrupo.Controls.Add(this.cboTurno);
            this.gpbGrupo.Controls.Add(this.lblTetra);
            this.gpbGrupo.Controls.Add(this.lblSiglas);
            this.gpbGrupo.Controls.Add(this.lbltipoCarrera);
            this.gpbGrupo.Controls.Add(this.lblGrupo);
            this.gpbGrupo.Controls.Add(this.cboLGrupo);
            this.gpbGrupo.Controls.Add(this.cboTetra);
            this.gpbGrupo.Controls.Add(this.cboSiglas);
            this.gpbGrupo.Controls.Add(this.cboTipoCarrera);
            this.gpbGrupo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbGrupo.Location = new System.Drawing.Point(428, 253);
            this.gpbGrupo.Name = "gpbGrupo";
            this.gpbGrupo.Size = new System.Drawing.Size(548, 75);
            this.gpbGrupo.TabIndex = 32;
            this.gpbGrupo.TabStop = false;
            this.gpbGrupo.Text = "Grupo - Carrera";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(424, 32);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(35, 13);
            this.lblTurno.TabIndex = 12;
            this.lblTurno.Text = "Turno";
            // 
            // cboTurno
            // 
            this.cboTurno.FormattingEnabled = true;
            this.cboTurno.Items.AddRange(new object[] {
            "Matutino",
            "Vespertino",
            "Sabatino"});
            this.cboTurno.Location = new System.Drawing.Point(418, 49);
            this.cboTurno.Name = "cboTurno";
            this.cboTurno.Size = new System.Drawing.Size(86, 21);
            this.cboTurno.TabIndex = 13;
            // 
            // lblTetra
            // 
            this.lblTetra.AutoSize = true;
            this.lblTetra.Location = new System.Drawing.Point(258, 32);
            this.lblTetra.Name = "lblTetra";
            this.lblTetra.Size = new System.Drawing.Size(63, 13);
            this.lblTetra.TabIndex = 11;
            this.lblTetra.Text = "Tetramestre";
            // 
            // lblSiglas
            // 
            this.lblSiglas.AutoSize = true;
            this.lblSiglas.Location = new System.Drawing.Point(190, 29);
            this.lblSiglas.Name = "lblSiglas";
            this.lblSiglas.Size = new System.Drawing.Size(35, 13);
            this.lblSiglas.TabIndex = 10;
            this.lblSiglas.Text = "Siglas";
            // 
            // lbltipoCarrera
            // 
            this.lbltipoCarrera.AutoSize = true;
            this.lbltipoCarrera.Location = new System.Drawing.Point(45, 31);
            this.lbltipoCarrera.Name = "lbltipoCarrera";
            this.lbltipoCarrera.Size = new System.Drawing.Size(31, 13);
            this.lbltipoCarrera.TabIndex = 9;
            this.lbltipoCarrera.Text = "Nivel";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(339, 31);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(36, 13);
            this.lblGrupo.TabIndex = 2;
            this.lblGrupo.Text = "Grupo";
            // 
            // cboLGrupo
            // 
            this.cboLGrupo.FormattingEnabled = true;
            this.cboLGrupo.Location = new System.Drawing.Point(333, 48);
            this.cboLGrupo.Name = "cboLGrupo";
            this.cboLGrupo.Size = new System.Drawing.Size(49, 21);
            this.cboLGrupo.TabIndex = 5;
            // 
            // cboTetra
            // 
            this.cboTetra.FormattingEnabled = true;
            this.cboTetra.Location = new System.Drawing.Point(258, 48);
            this.cboTetra.Name = "cboTetra";
            this.cboTetra.Size = new System.Drawing.Size(60, 21);
            this.cboTetra.TabIndex = 4;
            // 
            // cboSiglas
            // 
            this.cboSiglas.FormattingEnabled = true;
            this.cboSiglas.Location = new System.Drawing.Point(165, 48);
            this.cboSiglas.Name = "cboSiglas";
            this.cboSiglas.Size = new System.Drawing.Size(76, 21);
            this.cboSiglas.TabIndex = 3;
            // 
            // cboTipoCarrera
            // 
            this.cboTipoCarrera.FormattingEnabled = true;
            this.cboTipoCarrera.Location = new System.Drawing.Point(19, 48);
            this.cboTipoCarrera.Name = "cboTipoCarrera";
            this.cboTipoCarrera.Size = new System.Drawing.Size(88, 21);
            this.cboTipoCarrera.TabIndex = 2;
            // 
            // gpbLaboratorio
            // 
            this.gpbLaboratorio.Controls.Add(this.cboLaboratorios);
            this.gpbLaboratorio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbLaboratorio.Location = new System.Drawing.Point(12, 349);
            this.gpbLaboratorio.Name = "gpbLaboratorio";
            this.gpbLaboratorio.Size = new System.Drawing.Size(140, 51);
            this.gpbLaboratorio.TabIndex = 32;
            this.gpbLaboratorio.TabStop = false;
            this.gpbLaboratorio.Text = "Laboratorio";
            // 
            // cboLaboratorios
            // 
            this.cboLaboratorios.FormattingEnabled = true;
            this.cboLaboratorios.Location = new System.Drawing.Point(6, 19);
            this.cboLaboratorios.Name = "cboLaboratorios";
            this.cboLaboratorios.Size = new System.Drawing.Size(121, 21);
            this.cboLaboratorios.TabIndex = 0;
            this.cboLaboratorios.SelectedIndexChanged += new System.EventHandler(this.cboLaboratorios_SelectedIndexChanged);
            // 
            // gpbFecha
            // 
            this.gpbFecha.Controls.Add(this.dateTimePicker3);
            this.gpbFecha.Controls.Add(this.dateTimePicker2);
            this.gpbFecha.Controls.Add(this.dateTimePicker1);
            this.gpbFecha.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbFecha.Location = new System.Drawing.Point(158, 349);
            this.gpbFecha.Name = "gpbFecha";
            this.gpbFecha.Size = new System.Drawing.Size(631, 79);
            this.gpbFecha.TabIndex = 32;
            this.gpbFecha.TabStop = false;
            this.gpbFecha.Text = "Fecha - Hora";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker3.Location = new System.Drawing.Point(407, 40);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.ShowUpDown = true;
            this.dateTimePicker3.Size = new System.Drawing.Size(117, 20);
            this.dateTimePicker3.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(283, 40);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(113, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(205, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.FormatChanged += new System.EventHandler(this.dateTimePicker1_FormatChanged);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // gpbDocenteSelec
            // 
            this.gpbDocenteSelec.Controls.Add(this.label1);
            this.gpbDocenteSelec.Controls.Add(this.label2);
            this.gpbDocenteSelec.Controls.Add(this.label3);
            this.gpbDocenteSelec.Controls.Add(this.lblClave);
            this.gpbDocenteSelec.Controls.Add(this.lblExtension);
            this.gpbDocenteSelec.Controls.Add(this.lblDocente);
            this.gpbDocenteSelec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbDocenteSelec.Location = new System.Drawing.Point(704, 12);
            this.gpbDocenteSelec.Name = "gpbDocenteSelec";
            this.gpbDocenteSelec.Size = new System.Drawing.Size(228, 223);
            this.gpbDocenteSelec.TabIndex = 33;
            this.gpbDocenteSelec.TabStop = false;
            this.gpbDocenteSelec.Text = "Información Docente Seleccionado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Clave: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Extensión: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Docente: ";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(80, 81);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(0, 13);
            this.lblClave.TabIndex = 2;
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(77, 53);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(0, 13);
            this.lblExtension.TabIndex = 1;
            // 
            // lblDocente
            // 
            this.lblDocente.AutoSize = true;
            this.lblDocente.Location = new System.Drawing.Point(77, 30);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(0, 13);
            this.lblDocente.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.BackgroundImage")));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(817, 357);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(159, 52);
            this.btnGuardar.TabIndex = 34;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvRegistroES
            // 
            this.dgvRegistroES.AllowUserToAddRows = false;
            this.dgvRegistroES.AllowUserToDeleteRows = false;
            this.dgvRegistroES.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistroES.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegistroES.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRegistroES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroES.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRegistroES.Location = new System.Drawing.Point(5, 468);
            this.dgvRegistroES.Name = "dgvRegistroES";
            this.dgvRegistroES.Size = new System.Drawing.Size(971, 203);
            this.dgvRegistroES.TabIndex = 31;
            this.dgvRegistroES.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistroES_CellClick);
            this.dgvRegistroES.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRegistroES_CellMouseClick);
            this.dgvRegistroES.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRegistroES_CellMouseMove);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(941, 761);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(130, 23);
            this.btnExcel.TabIndex = 35;
            this.btnExcel.Text = "Generar Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(109, 434);
            this.txtBuscar.MaxLength = 25;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(622, 29);
            this.txtBuscar.TabIndex = 36;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(817, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 52);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Buscar";
            // 
            // btnEcxel
            // 
            this.btnEcxel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEcxel.BackgroundImage")));
            this.btnEcxel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEcxel.FlatAppearance.BorderSize = 0;
            this.btnEcxel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEcxel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEcxel.Location = new System.Drawing.Point(0, 680);
            this.btnEcxel.Name = "btnEcxel";
            this.btnEcxel.Size = new System.Drawing.Size(152, 52);
            this.btnEcxel.TabIndex = 39;
            this.btnEcxel.UseVisualStyleBackColor = true;
            this.btnEcxel.Click += new System.EventHandler(this.btnEcxel_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReporte.BackgroundImage")));
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Location = new System.Drawing.Point(817, 680);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(155, 52);
            this.btnReporte.TabIndex = 40;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(63, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Buscar";
            // 
            // frmEntradas_Salidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(979, 741);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnEcxel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dgvRegistroES);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gpbDocenteSelec);
            this.Controls.Add(this.gpbFecha);
            this.Controls.Add(this.gpbLaboratorio);
            this.Controls.Add(this.gpbGrupo);
            this.Controls.Add(this.gpbPeriodo);
            this.Controls.Add(this.gpbDocentes);
            this.MaximizeBox = false;
            this.Name = "frmEntradas_Salidas";
            this.Text = "Entradas y Salidas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntradas_Salidas_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEntradas_Salidas_FormClosed);
            this.Load += new System.EventHandler(this.frmEntradas_Salidas_Load);
            this.gpbDocentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).EndInit();
            this.gpbPeriodo.ResumeLayout(false);
            this.gpbPeriodo.PerformLayout();
            this.gpbGrupo.ResumeLayout(false);
            this.gpbGrupo.PerformLayout();
            this.gpbLaboratorio.ResumeLayout(false);
            this.gpbFecha.ResumeLayout(false);
            this.gpbDocenteSelec.ResumeLayout(false);
            this.gpbDocenteSelec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroES)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDocentes;
        private System.Windows.Forms.ComboBox cboExtension;
        private System.Windows.Forms.DataGridView dgvInformacion;
        private System.Windows.Forms.GroupBox gpbPeriodo;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboCiclo;
        private System.Windows.Forms.GroupBox gpbGrupo;
        private System.Windows.Forms.ComboBox cboLGrupo;
        private System.Windows.Forms.ComboBox cboTetra;
        private System.Windows.Forms.ComboBox cboSiglas;
        private System.Windows.Forms.ComboBox cboTipoCarrera;
        private System.Windows.Forms.GroupBox gpbLaboratorio;
        private System.Windows.Forms.ComboBox cboLaboratorios;
        private System.Windows.Forms.GroupBox gpbFecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox gpbDocenteSelec;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lbltipoCarrera;
        private System.Windows.Forms.Label lblSiglas;
        private System.Windows.Forms.Label lblTetra;
        private System.Windows.Forms.Label lblCE;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox cboTurno;
        private System.Windows.Forms.DataGridView dgvRegistroES;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEcxel;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Label label5;
    }
}