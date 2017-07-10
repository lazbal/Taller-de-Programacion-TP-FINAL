namespace CapaVisual
{
    partial class Nuevo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lFechaInicio = new System.Windows.Forms.Label();
            this.lFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.bSeleccionarHorarios = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lFechaInicio
            // 
            this.lFechaInicio.AutoSize = true;
            this.lFechaInicio.Location = new System.Drawing.Point(251, 18);
            this.lFechaInicio.Name = "lFechaInicio";
            this.lFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lFechaInicio.TabIndex = 2;
            this.lFechaInicio.Text = "Fecha Inicio:";
            // 
            // lFechaFin
            // 
            this.lFechaFin.AutoSize = true;
            this.lFechaFin.Location = new System.Drawing.Point(251, 71);
            this.lFechaFin.Name = "lFechaFin";
            this.lFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lFechaFin.TabIndex = 3;
            this.lFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(254, 34);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 4;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(254, 87);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 5;
            // 
            // bSeleccionarHorarios
            // 
            this.bSeleccionarHorarios.Location = new System.Drawing.Point(254, 122);
            this.bSeleccionarHorarios.Name = "bSeleccionarHorarios";
            this.bSeleccionarHorarios.Size = new System.Drawing.Size(200, 36);
            this.bSeleccionarHorarios.TabIndex = 6;
            this.bSeleccionarHorarios.Text = "Seleccionar Horarios";
            this.bSeleccionarHorarios.UseVisualStyleBackColor = true;
            this.bSeleccionarHorarios.Click += new System.EventHandler(this.bSeleccionarHorarios_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 18);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre:";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(15, 34);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(197, 20);
            this.tbNombre.TabIndex = 8;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(15, 87);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(197, 113);
            this.tbDescripcion.TabIndex = 10;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 71);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 9;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // Nuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 211);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.bSeleccionarHorarios);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lFechaFin);
            this.Controls.Add(this.lFechaInicio);
            this.Name = "Nuevo";
            this.Text = "Nuevo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lFechaInicio;
        private System.Windows.Forms.Label lFechaFin;
        protected System.Windows.Forms.DateTimePicker dtpFechaInicio;
        protected System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button bSeleccionarHorarios;
        private System.Windows.Forms.Label lblNombre;
        protected System.Windows.Forms.TextBox tbNombre;
        protected System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
    }
}

