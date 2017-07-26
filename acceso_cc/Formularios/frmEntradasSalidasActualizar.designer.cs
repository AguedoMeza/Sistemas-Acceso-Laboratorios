namespace acceso_cc.Formularios
{
    partial class frmEntradasSalidasActualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntradasSalidasActualizar));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gpbFechaHora = new System.Windows.Forms.GroupBox();
            this.lblHoraSalida = new System.Windows.Forms.Label();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.dtpHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.gpbLaboratorio = new System.Windows.Forms.GroupBox();
            this.cboLaboratorio = new System.Windows.Forms.ComboBox();
            this.gpbGrupo = new System.Windows.Forms.GroupBox();
            this.rdbSabatino = new System.Windows.Forms.RadioButton();
            this.rdbVespertino = new System.Windows.Forms.RadioButton();
            this.rdbMatutino = new System.Windows.Forms.RadioButton();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.cboTetra = new System.Windows.Forms.ComboBox();
            this.cboSiglas = new System.Windows.Forms.ComboBox();
            this.cboTipoCarrera = new System.Windows.Forms.ComboBox();
            this.gpbPeriodo = new System.Windows.Forms.GroupBox();
            this.cboPeriodoAño = new System.Windows.Forms.ComboBox();
            this.cboPeriodoMes = new System.Windows.Forms.ComboBox();
            this.gpbFechaHora.SuspendLayout();
            this.gpbLaboratorio.SuspendLayout();
            this.gpbGrupo.SuspendLayout();
            this.gpbPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(689, 265);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(149, 49);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.BackgroundImage")));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Location = new System.Drawing.Point(530, 266);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(160, 53);
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // gpbFechaHora
            // 
            this.gpbFechaHora.Controls.Add(this.lblHoraSalida);
            this.gpbFechaHora.Controls.Add(this.lblHoraEntrada);
            this.gpbFechaHora.Controls.Add(this.dtpHoraSalida);
            this.gpbFechaHora.Controls.Add(this.dtpHoraEntrada);
            this.gpbFechaHora.Controls.Add(this.dtpFecha);
            this.gpbFechaHora.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gpbFechaHora.Location = new System.Drawing.Point(175, 147);
            this.gpbFechaHora.Name = "gpbFechaHora";
            this.gpbFechaHora.Size = new System.Drawing.Size(435, 84);
            this.gpbFechaHora.TabIndex = 11;
            this.gpbFechaHora.TabStop = false;
            this.gpbFechaHora.Text = "Fecha-Hora";
            // 
            // lblHoraSalida
            // 
            this.lblHoraSalida.AutoSize = true;
            this.lblHoraSalida.Location = new System.Drawing.Point(326, 17);
            this.lblHoraSalida.Name = "lblHoraSalida";
            this.lblHoraSalida.Size = new System.Drawing.Size(75, 13);
            this.lblHoraSalida.TabIndex = 15;
            this.lblHoraSalida.Text = "Hora de salida";
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.AutoSize = true;
            this.lblHoraEntrada.Location = new System.Drawing.Point(189, 16);
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(84, 13);
            this.lblHoraEntrada.TabIndex = 14;
            this.lblHoraEntrada.Text = "Hora de entrada";
            // 
            // dtpHoraSalida
            // 
            this.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraSalida.Location = new System.Drawing.Point(314, 36);
            this.dtpHoraSalida.Name = "dtpHoraSalida";
            this.dtpHoraSalida.ShowUpDown = true;
            this.dtpHoraSalida.Size = new System.Drawing.Size(103, 20);
            this.dtpHoraSalida.TabIndex = 2;
            // 
            // dtpHoraEntrada
            // 
            this.dtpHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEntrada.Location = new System.Drawing.Point(184, 35);
            this.dtpHoraEntrada.Name = "dtpHoraEntrada";
            this.dtpHoraEntrada.ShowUpDown = true;
            this.dtpHoraEntrada.Size = new System.Drawing.Size(104, 20);
            this.dtpHoraEntrada.TabIndex = 1;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(30, 34);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(106, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // gpbLaboratorio
            // 
            this.gpbLaboratorio.Controls.Add(this.cboLaboratorio);
            this.gpbLaboratorio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gpbLaboratorio.Location = new System.Drawing.Point(11, 147);
            this.gpbLaboratorio.Name = "gpbLaboratorio";
            this.gpbLaboratorio.Size = new System.Drawing.Size(157, 84);
            this.gpbLaboratorio.TabIndex = 10;
            this.gpbLaboratorio.TabStop = false;
            this.gpbLaboratorio.Text = " Laboratorio";
            // 
            // cboLaboratorio
            // 
            this.cboLaboratorio.FormattingEnabled = true;
            this.cboLaboratorio.Location = new System.Drawing.Point(21, 33);
            this.cboLaboratorio.Name = "cboLaboratorio";
            this.cboLaboratorio.Size = new System.Drawing.Size(121, 21);
            this.cboLaboratorio.TabIndex = 0;
            // 
            // gpbGrupo
            // 
            this.gpbGrupo.Controls.Add(this.rdbSabatino);
            this.gpbGrupo.Controls.Add(this.rdbVespertino);
            this.gpbGrupo.Controls.Add(this.rdbMatutino);
            this.gpbGrupo.Controls.Add(this.cboGrupo);
            this.gpbGrupo.Controls.Add(this.cboTetra);
            this.gpbGrupo.Controls.Add(this.cboSiglas);
            this.gpbGrupo.Controls.Add(this.cboTipoCarrera);
            this.gpbGrupo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gpbGrupo.Location = new System.Drawing.Point(305, 43);
            this.gpbGrupo.Name = "gpbGrupo";
            this.gpbGrupo.Size = new System.Drawing.Size(542, 98);
            this.gpbGrupo.TabIndex = 9;
            this.gpbGrupo.TabStop = false;
            this.gpbGrupo.Text = "Grupo";
            // 
            // rdbSabatino
            // 
            this.rdbSabatino.AutoSize = true;
            this.rdbSabatino.Location = new System.Drawing.Point(451, 69);
            this.rdbSabatino.Name = "rdbSabatino";
            this.rdbSabatino.Size = new System.Drawing.Size(67, 17);
            this.rdbSabatino.TabIndex = 6;
            this.rdbSabatino.TabStop = true;
            this.rdbSabatino.Text = "Sabatino";
            this.rdbSabatino.UseVisualStyleBackColor = true;
            // 
            // rdbVespertino
            // 
            this.rdbVespertino.AutoSize = true;
            this.rdbVespertino.Location = new System.Drawing.Point(451, 45);
            this.rdbVespertino.Name = "rdbVespertino";
            this.rdbVespertino.Size = new System.Drawing.Size(75, 17);
            this.rdbVespertino.TabIndex = 5;
            this.rdbVespertino.TabStop = true;
            this.rdbVespertino.Text = "Vespertino";
            this.rdbVespertino.UseVisualStyleBackColor = true;
            // 
            // rdbMatutino
            // 
            this.rdbMatutino.AutoSize = true;
            this.rdbMatutino.Location = new System.Drawing.Point(451, 21);
            this.rdbMatutino.Name = "rdbMatutino";
            this.rdbMatutino.Size = new System.Drawing.Size(66, 17);
            this.rdbMatutino.TabIndex = 4;
            this.rdbMatutino.TabStop = true;
            this.rdbMatutino.Text = "Matutino";
            this.rdbMatutino.UseVisualStyleBackColor = true;
            // 
            // cboGrupo
            // 
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(357, 44);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(62, 21);
            this.cboGrupo.TabIndex = 3;
            // 
            // cboTetra
            // 
            this.cboTetra.FormattingEnabled = true;
            this.cboTetra.Location = new System.Drawing.Point(277, 43);
            this.cboTetra.Name = "cboTetra";
            this.cboTetra.Size = new System.Drawing.Size(64, 21);
            this.cboTetra.TabIndex = 2;
            // 
            // cboSiglas
            // 
            this.cboSiglas.FormattingEnabled = true;
            this.cboSiglas.Location = new System.Drawing.Point(165, 43);
            this.cboSiglas.Name = "cboSiglas";
            this.cboSiglas.Size = new System.Drawing.Size(98, 21);
            this.cboSiglas.TabIndex = 1;
            // 
            // cboTipoCarrera
            // 
            this.cboTipoCarrera.FormattingEnabled = true;
            this.cboTipoCarrera.Location = new System.Drawing.Point(33, 43);
            this.cboTipoCarrera.Name = "cboTipoCarrera";
            this.cboTipoCarrera.Size = new System.Drawing.Size(121, 21);
            this.cboTipoCarrera.TabIndex = 0;
            // 
            // gpbPeriodo
            // 
            this.gpbPeriodo.Controls.Add(this.cboPeriodoAño);
            this.gpbPeriodo.Controls.Add(this.cboPeriodoMes);
            this.gpbPeriodo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gpbPeriodo.Location = new System.Drawing.Point(11, 43);
            this.gpbPeriodo.Name = "gpbPeriodo";
            this.gpbPeriodo.Size = new System.Drawing.Size(275, 98);
            this.gpbPeriodo.TabIndex = 8;
            this.gpbPeriodo.TabStop = false;
            this.gpbPeriodo.Text = "Periodo";
            // 
            // cboPeriodoAño
            // 
            this.cboPeriodoAño.FormattingEnabled = true;
            this.cboPeriodoAño.Location = new System.Drawing.Point(164, 44);
            this.cboPeriodoAño.Name = "cboPeriodoAño";
            this.cboPeriodoAño.Size = new System.Drawing.Size(89, 21);
            this.cboPeriodoAño.TabIndex = 1;
            // 
            // cboPeriodoMes
            // 
            this.cboPeriodoMes.FormattingEnabled = true;
            this.cboPeriodoMes.Location = new System.Drawing.Point(21, 43);
            this.cboPeriodoMes.Name = "cboPeriodoMes";
            this.cboPeriodoMes.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodoMes.TabIndex = 0;
            // 
            // frmEntradasSalidasActualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(852, 331);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.gpbFechaHora);
            this.Controls.Add(this.gpbLaboratorio);
            this.Controls.Add(this.gpbGrupo);
            this.Controls.Add(this.gpbPeriodo);
            this.MinimizeBox = false;
            this.Name = "frmEntradasSalidasActualizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Registro";
            this.Load += new System.EventHandler(this.frmEntradasSalidasActualizar_Load);
            this.gpbFechaHora.ResumeLayout(false);
            this.gpbFechaHora.PerformLayout();
            this.gpbLaboratorio.ResumeLayout(false);
            this.gpbGrupo.ResumeLayout(false);
            this.gpbGrupo.PerformLayout();
            this.gpbPeriodo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox gpbFechaHora;
        private System.Windows.Forms.Label lblHoraSalida;
        private System.Windows.Forms.Label lblHoraEntrada;
        private System.Windows.Forms.DateTimePicker dtpHoraSalida;
        private System.Windows.Forms.DateTimePicker dtpHoraEntrada;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox gpbLaboratorio;
        private System.Windows.Forms.ComboBox cboLaboratorio;
        private System.Windows.Forms.GroupBox gpbGrupo;
        private System.Windows.Forms.RadioButton rdbSabatino;
        private System.Windows.Forms.RadioButton rdbVespertino;
        private System.Windows.Forms.RadioButton rdbMatutino;
        private System.Windows.Forms.ComboBox cboGrupo;
        private System.Windows.Forms.ComboBox cboTetra;
        private System.Windows.Forms.ComboBox cboSiglas;
        private System.Windows.Forms.ComboBox cboTipoCarrera;
        private System.Windows.Forms.GroupBox gpbPeriodo;
        private System.Windows.Forms.ComboBox cboPeriodoAño;
        private System.Windows.Forms.ComboBox cboPeriodoMes;
    }
}