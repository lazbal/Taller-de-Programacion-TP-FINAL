namespace CapaVisual
{
    partial class NuevoElementoCarteleria
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
            this.bAgregarImágenes = new System.Windows.Forms.Button();
            this.lvImagenes = new System.Windows.Forms.ListView();
            this.abrirImagenes = new System.Windows.Forms.OpenFileDialog();
            this.bQuitarImagenes = new System.Windows.Forms.Button();
            this.labelTiempoxImagen = new System.Windows.Forms.Label();
            this.numHH = new System.Windows.Forms.NumericUpDown();
            this.numMM = new System.Windows.Forms.NumericUpDown();
            this.bTMS = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbCampaña = new System.Windows.Forms.GroupBox();
            this.gbBanner = new System.Windows.Forms.GroupBox();
            this.btnSeleccionarFuenteRSS = new System.Windows.Forms.Button();
            this.tbBanner = new System.Windows.Forms.TextBox();
            this.cbTipoBanner = new System.Windows.Forms.ComboBox();
            this.btnHorariosOcupados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMM)).BeginInit();
            this.gbCampaña.SuspendLayout();
            this.gbBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Size = new System.Drawing.Size(197, 114);
            // 
            // bAgregarImágenes
            // 
            this.bAgregarImágenes.Location = new System.Drawing.Point(239, 56);
            this.bAgregarImágenes.Name = "bAgregarImágenes";
            this.bAgregarImágenes.Size = new System.Drawing.Size(92, 36);
            this.bAgregarImágenes.TabIndex = 7;
            this.bAgregarImágenes.Text = "Agregar Imágenes";
            this.bAgregarImágenes.UseVisualStyleBackColor = true;
            this.bAgregarImágenes.Click += new System.EventHandler(this.bAgregarImagenes_Click);
            // 
            // lvImagenes
            // 
            this.lvImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvImagenes.Location = new System.Drawing.Point(460, 51);
            this.lvImagenes.Name = "lvImagenes";
            this.lvImagenes.ShowItemToolTips = true;
            this.lvImagenes.Size = new System.Drawing.Size(293, 346);
            this.lvImagenes.TabIndex = 8;
            this.lvImagenes.UseCompatibleStateImageBehavior = false;
            this.lvImagenes.DoubleClick += new System.EventHandler(this.lvImagenes_DoubleClick);
            // 
            // abrirImagenes
            // 
            this.abrirImagenes.FileName = "abrirImagenes";
            this.abrirImagenes.Multiselect = true;
            // 
            // bQuitarImagenes
            // 
            this.bQuitarImagenes.Location = new System.Drawing.Point(341, 56);
            this.bQuitarImagenes.Name = "bQuitarImagenes";
            this.bQuitarImagenes.Size = new System.Drawing.Size(92, 36);
            this.bQuitarImagenes.TabIndex = 9;
            this.bQuitarImagenes.Text = "Quitar Imágenes Seleccionadas";
            this.bQuitarImagenes.UseVisualStyleBackColor = true;
            this.bQuitarImagenes.Click += new System.EventHandler(this.bQuitarImagenes_Click);
            // 
            // labelTiempoxImagen
            // 
            this.labelTiempoxImagen.AutoSize = true;
            this.labelTiempoxImagen.Location = new System.Drawing.Point(3, 28);
            this.labelTiempoxImagen.Name = "labelTiempoxImagen";
            this.labelTiempoxImagen.Size = new System.Drawing.Size(142, 13);
            this.labelTiempoxImagen.TabIndex = 16;
            this.labelTiempoxImagen.Text = "Tiempo Por Imágen: (hh:mm)";
            // 
            // numHH
            // 
            this.numHH.Location = new System.Drawing.Point(154, 26);
            this.numHH.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numHH.Name = "numHH";
            this.numHH.Size = new System.Drawing.Size(43, 20);
            this.numHH.TabIndex = 18;
            this.numHH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numMM
            // 
            this.numMM.Location = new System.Drawing.Point(203, 26);
            this.numMM.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMM.Name = "numMM";
            this.numMM.Size = new System.Drawing.Size(43, 20);
            this.numMM.TabIndex = 19;
            this.numMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bTMS
            // 
            this.bTMS.Location = new System.Drawing.Point(6, 56);
            this.bTMS.Name = "bTMS";
            this.bTMS.Size = new System.Drawing.Size(219, 36);
            this.bTMS.TabIndex = 20;
            this.bTMS.Text = "Tiempo Máximo Sugerido";
            this.bTMS.UseVisualStyleBackColor = true;
            this.bTMS.Click += new System.EventHandler(this.bTMS_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(585, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 33);
            this.btnAceptar.TabIndex = 21;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(666, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 33);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbCampaña
            // 
            this.gbCampaña.Controls.Add(this.bTMS);
            this.gbCampaña.Controls.Add(this.labelTiempoxImagen);
            this.gbCampaña.Controls.Add(this.bQuitarImagenes);
            this.gbCampaña.Controls.Add(this.numMM);
            this.gbCampaña.Controls.Add(this.numHH);
            this.gbCampaña.Controls.Add(this.bAgregarImágenes);
            this.gbCampaña.Location = new System.Drawing.Point(15, 214);
            this.gbCampaña.Name = "gbCampaña";
            this.gbCampaña.Size = new System.Drawing.Size(439, 99);
            this.gbCampaña.TabIndex = 23;
            this.gbCampaña.TabStop = false;
            this.gbCampaña.Text = "Campaña";
            // 
            // gbBanner
            // 
            this.gbBanner.Controls.Add(this.btnSeleccionarFuenteRSS);
            this.gbBanner.Controls.Add(this.tbBanner);
            this.gbBanner.Controls.Add(this.cbTipoBanner);
            this.gbBanner.Location = new System.Drawing.Point(15, 315);
            this.gbBanner.Name = "gbBanner";
            this.gbBanner.Size = new System.Drawing.Size(439, 83);
            this.gbBanner.TabIndex = 24;
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
            this.cbTipoBanner.SelectedValueChanged += new System.EventHandler(this.cbTipoBanner_SelectedValueChanged);
            // 
            // btnHorariosOcupados
            // 
            this.btnHorariosOcupados.Location = new System.Drawing.Point(254, 165);
            this.btnHorariosOcupados.Name = "btnHorariosOcupados";
            this.btnHorariosOcupados.Size = new System.Drawing.Size(200, 36);
            this.btnHorariosOcupados.TabIndex = 25;
            this.btnHorariosOcupados.Text = "Horarios Disponibles";
            this.btnHorariosOcupados.UseVisualStyleBackColor = true;
            this.btnHorariosOcupados.Click += new System.EventHandler(this.btnHorariosOcupados_Click);
            // 
            // NuevoElementoCarteleria
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(753, 403);
            this.Controls.Add(this.btnHorariosOcupados);
            this.Controls.Add(this.gbBanner);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lvImagenes);
            this.Controls.Add(this.gbCampaña);
            this.Name = "NuevoElementoCarteleria";
            this.Text = "Nuevo Cartel";
            this.Controls.SetChildIndex(this.gbCampaña, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.tbNombre, 0);
            this.Controls.SetChildIndex(this.tbDescripcion, 0);
            this.Controls.SetChildIndex(this.lvImagenes, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.gbBanner, 0);
            this.Controls.SetChildIndex(this.btnHorariosOcupados, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMM)).EndInit();
            this.gbCampaña.ResumeLayout(false);
            this.gbCampaña.PerformLayout();
            this.gbBanner.ResumeLayout(false);
            this.gbBanner.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAgregarImágenes;
        private System.Windows.Forms.ListView lvImagenes;
        private System.Windows.Forms.OpenFileDialog abrirImagenes;
        private System.Windows.Forms.Button bQuitarImagenes;
        private System.Windows.Forms.Label labelTiempoxImagen;
        private System.Windows.Forms.NumericUpDown numHH;
        private System.Windows.Forms.NumericUpDown numMM;
        private System.Windows.Forms.Button bTMS;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbCampaña;
        private System.Windows.Forms.GroupBox gbBanner;
        private System.Windows.Forms.TextBox tbBanner;
        private System.Windows.Forms.ComboBox cbTipoBanner;
        private System.Windows.Forms.Button btnSeleccionarFuenteRSS;
        private System.Windows.Forms.Button btnHorariosOcupados;
    }
}
