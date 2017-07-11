namespace CapaVisual
{
    partial class NuevoBanner
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
            this.gbBanner = new System.Windows.Forms.GroupBox();
            this.btnSeleccionarFuenteRSS = new System.Windows.Forms.Button();
            this.tbBanner = new System.Windows.Forms.TextBox();
            this.cbTipoBanner = new System.Windows.Forms.ComboBox();
            this.btnHorariosOcupados = new System.Windows.Forms.Button();
            this.gbBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBanner
            // 
            this.gbBanner.Controls.Add(this.btnSeleccionarFuenteRSS);
            this.gbBanner.Controls.Add(this.tbBanner);
            this.gbBanner.Controls.Add(this.cbTipoBanner);
            this.gbBanner.Location = new System.Drawing.Point(15, 206);
            this.gbBanner.Name = "gbBanner";
            this.gbBanner.Size = new System.Drawing.Size(439, 83);
            this.gbBanner.TabIndex = 25;
            this.gbBanner.TabStop = false;
            this.gbBanner.Text = "Banner";
            // 
            // btnSeleccionarFuenteRSS
            // 
            this.btnSeleccionarFuenteRSS.Location = new System.Drawing.Point(238, 12);
            this.btnSeleccionarFuenteRSS.Name = "btnSeleccionarFuenteRSS";
            this.btnSeleccionarFuenteRSS.Size = new System.Drawing.Size(195, 36);
            this.btnSeleccionarFuenteRSS.TabIndex = 8;
            this.btnSeleccionarFuenteRSS.Text = "Seleccionar Fuente RSS";
            this.btnSeleccionarFuenteRSS.UseVisualStyleBackColor = true;
            this.btnSeleccionarFuenteRSS.Visible = false;
            this.btnSeleccionarFuenteRSS.Click += new System.EventHandler(this.btnSeleccionarFuenteRSS_Click);
            // 
            // tbBanner
            // 
            this.tbBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBanner.Location = new System.Drawing.Point(6, 54);
            this.tbBanner.Name = "tbBanner";
            this.tbBanner.Size = new System.Drawing.Size(427, 20);
            this.tbBanner.TabIndex = 1;
            this.tbBanner.Text = "Seleccione el tipo de banner...";
            // 
            // cbTipoBanner
            // 
            this.cbTipoBanner.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbTipoBanner.FormattingEnabled = true;
            this.cbTipoBanner.Items.AddRange(new object[] {
            "Fuente RSS",
            "Banner Estático"});
            this.cbTipoBanner.Location = new System.Drawing.Point(6, 21);
            this.cbTipoBanner.Name = "cbTipoBanner";
            this.cbTipoBanner.Size = new System.Drawing.Size(219, 21);
            this.cbTipoBanner.TabIndex = 0;
            this.cbTipoBanner.Text = "Tipo de Banner";
            this.cbTipoBanner.SelectedIndexChanged += new System.EventHandler(this.cbTipoBanner_SelectedValueChanged);
            // 
            // btnHorariosOcupados
            // 
            this.btnHorariosOcupados.Location = new System.Drawing.Point(254, 164);
            this.btnHorariosOcupados.Name = "btnHorariosOcupados";
            this.btnHorariosOcupados.Size = new System.Drawing.Size(200, 36);
            this.btnHorariosOcupados.TabIndex = 26;
            this.btnHorariosOcupados.Text = "Horarios Ocupados";
            this.btnHorariosOcupados.UseVisualStyleBackColor = true;
            this.btnHorariosOcupados.Click += new System.EventHandler(this.btnHorariosOcupados_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(460, 55);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 33);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(460, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 33);
            this.btnAceptar.TabIndex = 27;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // NuevoBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 295);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnHorariosOcupados);
            this.Controls.Add(this.gbBanner);
            this.Name = "NuevoBanner";
            this.Text = "NuevoBanner";
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.tbNombre, 0);
            this.Controls.SetChildIndex(this.tbDescripcion, 0);
            this.Controls.SetChildIndex(this.gbBanner, 0);
            this.Controls.SetChildIndex(this.btnHorariosOcupados, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.gbBanner.ResumeLayout(false);
            this.gbBanner.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBanner;
        private System.Windows.Forms.Button btnSeleccionarFuenteRSS;
        private System.Windows.Forms.TextBox tbBanner;
        private System.Windows.Forms.ComboBox cbTipoBanner;
        private System.Windows.Forms.Button btnHorariosOcupados;
    }
}