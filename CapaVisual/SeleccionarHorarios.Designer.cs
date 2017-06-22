namespace CapaVisual
{
    partial class SeleccionarHorarios
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
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLunes = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDomingo = new System.Windows.Forms.CheckBox();
            this.cbSabado = new System.Windows.Forms.CheckBox();
            this.cbViernes = new System.Windows.Forms.CheckBox();
            this.cbJueves = new System.Windows.Forms.CheckBox();
            this.cbMiercoles = new System.Windows.Forms.CheckBox();
            this.cbMartes = new System.Windows.Forms.CheckBox();
            this.tableHorarios = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDomingoFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDomingoInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpSabadoFin = new System.Windows.Forms.DateTimePicker();
            this.dtpSabadoInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpViernesFin = new System.Windows.Forms.DateTimePicker();
            this.dtpViernesInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpJuevesFin = new System.Windows.Forms.DateTimePicker();
            this.dtpMiercolesFin = new System.Windows.Forms.DateTimePicker();
            this.dtpMartesInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpMartesFin = new System.Windows.Forms.DateTimePicker();
            this.dtpMiercolesInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpJuevesInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpLunesInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpLunesFin = new System.Windows.Forms.DateTimePicker();
            this.tableHorarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(16, 211);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 3;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.Location = new System.Drawing.Point(162, 211);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 4;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(113, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Hora Inicio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbLunes
            // 
            this.cbLunes.AutoSize = true;
            this.cbLunes.Location = new System.Drawing.Point(13, 28);
            this.cbLunes.Name = "cbLunes";
            this.cbLunes.Size = new System.Drawing.Size(55, 17);
            this.cbLunes.TabIndex = 24;
            this.cbLunes.Text = "Lunes";
            this.cbLunes.UseVisualStyleBackColor = true;
            this.cbLunes.CheckedChanged += new System.EventHandler(this.cbLunes_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(192, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Hora Fin";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Día de Semana";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDomingo
            // 
            this.cbDomingo.AutoSize = true;
            this.cbDomingo.Location = new System.Drawing.Point(13, 172);
            this.cbDomingo.Name = "cbDomingo";
            this.cbDomingo.Size = new System.Drawing.Size(68, 17);
            this.cbDomingo.TabIndex = 10;
            this.cbDomingo.Text = "Domingo";
            this.cbDomingo.UseVisualStyleBackColor = true;
            this.cbDomingo.CheckedChanged += new System.EventHandler(this.cbDomingo_CheckedChanged);
            // 
            // cbSabado
            // 
            this.cbSabado.AutoSize = true;
            this.cbSabado.Location = new System.Drawing.Point(13, 148);
            this.cbSabado.Name = "cbSabado";
            this.cbSabado.Size = new System.Drawing.Size(63, 17);
            this.cbSabado.TabIndex = 9;
            this.cbSabado.Text = "Sábado";
            this.cbSabado.UseVisualStyleBackColor = true;
            this.cbSabado.CheckedChanged += new System.EventHandler(this.cbSabado_CheckedChanged);
            // 
            // cbViernes
            // 
            this.cbViernes.AutoSize = true;
            this.cbViernes.Location = new System.Drawing.Point(13, 124);
            this.cbViernes.Name = "cbViernes";
            this.cbViernes.Size = new System.Drawing.Size(61, 17);
            this.cbViernes.TabIndex = 8;
            this.cbViernes.Text = "Viernes";
            this.cbViernes.UseVisualStyleBackColor = true;
            this.cbViernes.CheckedChanged += new System.EventHandler(this.cbViernes_CheckedChanged);
            // 
            // cbJueves
            // 
            this.cbJueves.AutoSize = true;
            this.cbJueves.Location = new System.Drawing.Point(13, 100);
            this.cbJueves.Name = "cbJueves";
            this.cbJueves.Size = new System.Drawing.Size(60, 17);
            this.cbJueves.TabIndex = 7;
            this.cbJueves.Text = "Jueves";
            this.cbJueves.UseVisualStyleBackColor = true;
            this.cbJueves.CheckedChanged += new System.EventHandler(this.cbJueves_CheckedChanged);
            // 
            // cbMiercoles
            // 
            this.cbMiercoles.AutoSize = true;
            this.cbMiercoles.Location = new System.Drawing.Point(13, 76);
            this.cbMiercoles.Name = "cbMiercoles";
            this.cbMiercoles.Size = new System.Drawing.Size(71, 17);
            this.cbMiercoles.TabIndex = 6;
            this.cbMiercoles.Text = "Miércoles";
            this.cbMiercoles.UseVisualStyleBackColor = true;
            this.cbMiercoles.CheckedChanged += new System.EventHandler(this.cbMiercoles_CheckedChanged);
            // 
            // cbMartes
            // 
            this.cbMartes.AutoSize = true;
            this.cbMartes.Location = new System.Drawing.Point(13, 52);
            this.cbMartes.Name = "cbMartes";
            this.cbMartes.Size = new System.Drawing.Size(58, 17);
            this.cbMartes.TabIndex = 3;
            this.cbMartes.Text = "Martes";
            this.cbMartes.UseVisualStyleBackColor = true;
            this.cbMartes.CheckedChanged += new System.EventHandler(this.cbMartes_CheckedChanged);
            // 
            // tableHorarios
            // 
            this.tableHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableHorarios.ColumnCount = 6;
            this.tableHorarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableHorarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableHorarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableHorarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableHorarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableHorarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableHorarios.Controls.Add(this.dtpDomingoFin, 4, 7);
            this.tableHorarios.Controls.Add(this.dtpDomingoInicio, 2, 7);
            this.tableHorarios.Controls.Add(this.dtpSabadoFin, 4, 6);
            this.tableHorarios.Controls.Add(this.dtpSabadoInicio, 2, 6);
            this.tableHorarios.Controls.Add(this.dtpViernesFin, 4, 5);
            this.tableHorarios.Controls.Add(this.dtpViernesInicio, 2, 5);
            this.tableHorarios.Controls.Add(this.dtpJuevesFin, 4, 4);
            this.tableHorarios.Controls.Add(this.dtpMiercolesFin, 4, 3);
            this.tableHorarios.Controls.Add(this.cbMartes, 1, 2);
            this.tableHorarios.Controls.Add(this.dtpMartesInicio, 2, 2);
            this.tableHorarios.Controls.Add(this.dtpMartesFin, 4, 2);
            this.tableHorarios.Controls.Add(this.cbMiercoles, 1, 3);
            this.tableHorarios.Controls.Add(this.cbJueves, 1, 4);
            this.tableHorarios.Controls.Add(this.cbViernes, 1, 5);
            this.tableHorarios.Controls.Add(this.cbSabado, 1, 6);
            this.tableHorarios.Controls.Add(this.cbDomingo, 1, 7);
            this.tableHorarios.Controls.Add(this.dtpMiercolesInicio, 2, 3);
            this.tableHorarios.Controls.Add(this.dtpJuevesInicio, 2, 4);
            this.tableHorarios.Controls.Add(this.label1, 1, 0);
            this.tableHorarios.Controls.Add(this.label2, 2, 0);
            this.tableHorarios.Controls.Add(this.label3, 4, 0);
            this.tableHorarios.Controls.Add(this.cbLunes, 1, 1);
            this.tableHorarios.Controls.Add(this.dtpLunesInicio, 2, 1);
            this.tableHorarios.Controls.Add(this.dtpLunesFin, 4, 1);
            this.tableHorarios.Location = new System.Drawing.Point(0, 0);
            this.tableHorarios.Name = "tableHorarios";
            this.tableHorarios.RowCount = 8;
            this.tableHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
            this.tableHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.tableHorarios.Size = new System.Drawing.Size(271, 200);
            this.tableHorarios.TabIndex = 2;
            // 
            // dtpDomingoFin
            // 
            this.dtpDomingoFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDomingoFin.CustomFormat = "HH:mm";
            this.dtpDomingoFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpDomingoFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDomingoFin.Location = new System.Drawing.Point(192, 172);
            this.dtpDomingoFin.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpDomingoFin.Name = "dtpDomingoFin";
            this.dtpDomingoFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDomingoFin.ShowUpDown = true;
            this.dtpDomingoFin.Size = new System.Drawing.Size(63, 20);
            this.dtpDomingoFin.TabIndex = 23;
            this.dtpDomingoFin.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDomingoFin.Visible = false;
            // 
            // dtpDomingoInicio
            // 
            this.dtpDomingoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDomingoInicio.CustomFormat = "HH:mm";
            this.dtpDomingoInicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpDomingoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDomingoInicio.Location = new System.Drawing.Point(113, 172);
            this.dtpDomingoInicio.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpDomingoInicio.Name = "dtpDomingoInicio";
            this.dtpDomingoInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDomingoInicio.ShowUpDown = true;
            this.dtpDomingoInicio.Size = new System.Drawing.Size(63, 20);
            this.dtpDomingoInicio.TabIndex = 22;
            this.dtpDomingoInicio.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDomingoInicio.Visible = false;
            // 
            // dtpSabadoFin
            // 
            this.dtpSabadoFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSabadoFin.CustomFormat = "HH:mm";
            this.dtpSabadoFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpSabadoFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSabadoFin.Location = new System.Drawing.Point(192, 148);
            this.dtpSabadoFin.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpSabadoFin.Name = "dtpSabadoFin";
            this.dtpSabadoFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpSabadoFin.ShowUpDown = true;
            this.dtpSabadoFin.Size = new System.Drawing.Size(63, 20);
            this.dtpSabadoFin.TabIndex = 21;
            this.dtpSabadoFin.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpSabadoFin.Visible = false;
            // 
            // dtpSabadoInicio
            // 
            this.dtpSabadoInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSabadoInicio.CustomFormat = "HH:mm";
            this.dtpSabadoInicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpSabadoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSabadoInicio.Location = new System.Drawing.Point(113, 148);
            this.dtpSabadoInicio.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpSabadoInicio.Name = "dtpSabadoInicio";
            this.dtpSabadoInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpSabadoInicio.ShowUpDown = true;
            this.dtpSabadoInicio.Size = new System.Drawing.Size(63, 20);
            this.dtpSabadoInicio.TabIndex = 20;
            this.dtpSabadoInicio.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpSabadoInicio.Visible = false;
            // 
            // dtpViernesFin
            // 
            this.dtpViernesFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpViernesFin.CustomFormat = "HH:mm";
            this.dtpViernesFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpViernesFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpViernesFin.Location = new System.Drawing.Point(192, 124);
            this.dtpViernesFin.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpViernesFin.Name = "dtpViernesFin";
            this.dtpViernesFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpViernesFin.ShowUpDown = true;
            this.dtpViernesFin.Size = new System.Drawing.Size(63, 20);
            this.dtpViernesFin.TabIndex = 19;
            this.dtpViernesFin.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpViernesFin.Visible = false;
            // 
            // dtpViernesInicio
            // 
            this.dtpViernesInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpViernesInicio.CustomFormat = "HH:mm";
            this.dtpViernesInicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpViernesInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpViernesInicio.Location = new System.Drawing.Point(113, 124);
            this.dtpViernesInicio.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpViernesInicio.Name = "dtpViernesInicio";
            this.dtpViernesInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpViernesInicio.ShowUpDown = true;
            this.dtpViernesInicio.Size = new System.Drawing.Size(63, 20);
            this.dtpViernesInicio.TabIndex = 18;
            this.dtpViernesInicio.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpViernesInicio.Visible = false;
            // 
            // dtpJuevesFin
            // 
            this.dtpJuevesFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpJuevesFin.CustomFormat = "HH:mm";
            this.dtpJuevesFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpJuevesFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJuevesFin.Location = new System.Drawing.Point(192, 100);
            this.dtpJuevesFin.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpJuevesFin.Name = "dtpJuevesFin";
            this.dtpJuevesFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpJuevesFin.ShowUpDown = true;
            this.dtpJuevesFin.Size = new System.Drawing.Size(63, 20);
            this.dtpJuevesFin.TabIndex = 17;
            this.dtpJuevesFin.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpJuevesFin.Visible = false;
            // 
            // dtpMiercolesFin
            // 
            this.dtpMiercolesFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpMiercolesFin.CustomFormat = "HH:mm";
            this.dtpMiercolesFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpMiercolesFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMiercolesFin.Location = new System.Drawing.Point(192, 76);
            this.dtpMiercolesFin.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpMiercolesFin.Name = "dtpMiercolesFin";
            this.dtpMiercolesFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpMiercolesFin.ShowUpDown = true;
            this.dtpMiercolesFin.Size = new System.Drawing.Size(63, 20);
            this.dtpMiercolesFin.TabIndex = 16;
            this.dtpMiercolesFin.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpMiercolesFin.Visible = false;
            // 
            // dtpMartesInicio
            // 
            this.dtpMartesInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpMartesInicio.CustomFormat = "HH:mm";
            this.dtpMartesInicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpMartesInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMartesInicio.Location = new System.Drawing.Point(113, 52);
            this.dtpMartesInicio.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpMartesInicio.Name = "dtpMartesInicio";
            this.dtpMartesInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpMartesInicio.ShowUpDown = true;
            this.dtpMartesInicio.Size = new System.Drawing.Size(63, 20);
            this.dtpMartesInicio.TabIndex = 4;
            this.dtpMartesInicio.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpMartesInicio.Visible = false;
            // 
            // dtpMartesFin
            // 
            this.dtpMartesFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpMartesFin.CustomFormat = "HH:mm";
            this.dtpMartesFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpMartesFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMartesFin.Location = new System.Drawing.Point(192, 52);
            this.dtpMartesFin.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpMartesFin.Name = "dtpMartesFin";
            this.dtpMartesFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpMartesFin.ShowUpDown = true;
            this.dtpMartesFin.Size = new System.Drawing.Size(63, 20);
            this.dtpMartesFin.TabIndex = 5;
            this.dtpMartesFin.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpMartesFin.Visible = false;
            // 
            // dtpMiercolesInicio
            // 
            this.dtpMiercolesInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpMiercolesInicio.CustomFormat = "HH:mm";
            this.dtpMiercolesInicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpMiercolesInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMiercolesInicio.Location = new System.Drawing.Point(113, 76);
            this.dtpMiercolesInicio.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpMiercolesInicio.Name = "dtpMiercolesInicio";
            this.dtpMiercolesInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpMiercolesInicio.ShowUpDown = true;
            this.dtpMiercolesInicio.Size = new System.Drawing.Size(63, 20);
            this.dtpMiercolesInicio.TabIndex = 11;
            this.dtpMiercolesInicio.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpMiercolesInicio.Visible = false;
            // 
            // dtpJuevesInicio
            // 
            this.dtpJuevesInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpJuevesInicio.CustomFormat = "HH:mm";
            this.dtpJuevesInicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpJuevesInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJuevesInicio.Location = new System.Drawing.Point(113, 100);
            this.dtpJuevesInicio.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpJuevesInicio.Name = "dtpJuevesInicio";
            this.dtpJuevesInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpJuevesInicio.ShowUpDown = true;
            this.dtpJuevesInicio.Size = new System.Drawing.Size(63, 20);
            this.dtpJuevesInicio.TabIndex = 12;
            this.dtpJuevesInicio.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpJuevesInicio.Visible = false;
            // 
            // dtpLunesInicio
            // 
            this.dtpLunesInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpLunesInicio.CustomFormat = "HH:mm";
            this.dtpLunesInicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpLunesInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLunesInicio.Location = new System.Drawing.Point(113, 28);
            this.dtpLunesInicio.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpLunesInicio.Name = "dtpLunesInicio";
            this.dtpLunesInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpLunesInicio.ShowUpDown = true;
            this.dtpLunesInicio.Size = new System.Drawing.Size(63, 20);
            this.dtpLunesInicio.TabIndex = 25;
            this.dtpLunesInicio.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLunesInicio.Visible = false;
            // 
            // dtpLunesFin
            // 
            this.dtpLunesFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpLunesFin.CustomFormat = "HH:mm";
            this.dtpLunesFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpLunesFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLunesFin.Location = new System.Drawing.Point(192, 28);
            this.dtpLunesFin.MaxDate = new System.DateTime(1753, 1, 2, 0, 0, 0, 0);
            this.dtpLunesFin.Name = "dtpLunesFin";
            this.dtpLunesFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpLunesFin.ShowUpDown = true;
            this.dtpLunesFin.Size = new System.Drawing.Size(63, 20);
            this.dtpLunesFin.TabIndex = 26;
            this.dtpLunesFin.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLunesFin.Visible = false;
            // 
            // SeleccionarHorarios
            // 
            this.AcceptButton = this.bAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(271, 241);
            this.ControlBox = false;
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.tableHorarios);
            this.MaximizeBox = false;
            this.Name = "SeleccionarHorarios";
            this.Text = "Seleccionar Horarios";
            this.tableHorarios.ResumeLayout(false);
            this.tableHorarios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbLunes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbDomingo;
        private System.Windows.Forms.CheckBox cbSabado;
        private System.Windows.Forms.CheckBox cbViernes;
        private System.Windows.Forms.CheckBox cbJueves;
        private System.Windows.Forms.CheckBox cbMiercoles;
        private System.Windows.Forms.CheckBox cbMartes;
        private System.Windows.Forms.TableLayoutPanel tableHorarios;
        private System.Windows.Forms.DateTimePicker dtpDomingoFin;
        private System.Windows.Forms.DateTimePicker dtpDomingoInicio;
        private System.Windows.Forms.DateTimePicker dtpSabadoFin;
        private System.Windows.Forms.DateTimePicker dtpSabadoInicio;
        private System.Windows.Forms.DateTimePicker dtpViernesFin;
        private System.Windows.Forms.DateTimePicker dtpViernesInicio;
        private System.Windows.Forms.DateTimePicker dtpJuevesFin;
        private System.Windows.Forms.DateTimePicker dtpMiercolesFin;
        private System.Windows.Forms.DateTimePicker dtpMartesInicio;
        private System.Windows.Forms.DateTimePicker dtpMartesFin;
        private System.Windows.Forms.DateTimePicker dtpMiercolesInicio;
        private System.Windows.Forms.DateTimePicker dtpJuevesInicio;
        private System.Windows.Forms.DateTimePicker dtpLunesInicio;
        private System.Windows.Forms.DateTimePicker dtpLunesFin;
    }
}