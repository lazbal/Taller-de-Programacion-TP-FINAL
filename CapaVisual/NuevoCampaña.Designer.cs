namespace CapaVisual
{
    partial class NuevoCampaña
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
            this.lvImagenes = new System.Windows.Forms.ListView();
            this.abrirImagenes = new System.Windows.Forms.OpenFileDialog();
            this.bAgregarImágenes = new System.Windows.Forms.Button();
            this.numHH = new System.Windows.Forms.NumericUpDown();
            this.numMM = new System.Windows.Forms.NumericUpDown();
            this.bQuitarImagenes = new System.Windows.Forms.Button();
            this.labelTiempoxImagen = new System.Windows.Forms.Label();
            this.bTMS = new System.Windows.Forms.Button();
            this.numSS = new System.Windows.Forms.NumericUpDown();
            this.gbCampaña = new System.Windows.Forms.GroupBox();
            this.btnHorariosOcupados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSS)).BeginInit();
            this.gbCampaña.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Size = new System.Drawing.Size(197, 114);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(683, 12);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(602, 12);
            // 
            // lvImagenes
            // 
            this.lvImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvImagenes.Location = new System.Drawing.Point(460, 51);
            this.lvImagenes.Name = "lvImagenes";
            this.lvImagenes.ShowItemToolTips = true;
            this.lvImagenes.Size = new System.Drawing.Size(310, 261);
            this.lvImagenes.TabIndex = 8;
            this.lvImagenes.UseCompatibleStateImageBehavior = false;
            this.lvImagenes.DoubleClick += new System.EventHandler(this.LvImagenes_DoubleClick);
            // 
            // abrirImagenes
            // 
            this.abrirImagenes.FileName = "abrirImagenes";
            this.abrirImagenes.Multiselect = true;
            // 
            // bAgregarImágenes
            // 
            this.bAgregarImágenes.Location = new System.Drawing.Point(239, 56);
            this.bAgregarImágenes.Name = "bAgregarImágenes";
            this.bAgregarImágenes.Size = new System.Drawing.Size(92, 36);
            this.bAgregarImágenes.TabIndex = 7;
            this.bAgregarImágenes.Text = "Agregar Imágenes";
            this.bAgregarImágenes.UseVisualStyleBackColor = true;
            this.bAgregarImágenes.Click += new System.EventHandler(this.BAgregarImagenes_Click);
            // 
            // numHH
            // 
            this.numHH.Location = new System.Drawing.Point(164, 26);
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
            this.numMM.Location = new System.Drawing.Point(213, 26);
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
            // bQuitarImagenes
            // 
            this.bQuitarImagenes.Location = new System.Drawing.Point(341, 56);
            this.bQuitarImagenes.Name = "bQuitarImagenes";
            this.bQuitarImagenes.Size = new System.Drawing.Size(92, 36);
            this.bQuitarImagenes.TabIndex = 9;
            this.bQuitarImagenes.Text = "Quitar Imágenes Seleccionadas";
            this.bQuitarImagenes.UseVisualStyleBackColor = true;
            this.bQuitarImagenes.Click += new System.EventHandler(this.BQuitarImagenes_Click);
            // 
            // labelTiempoxImagen
            // 
            this.labelTiempoxImagen.AutoSize = true;
            this.labelTiempoxImagen.Location = new System.Drawing.Point(3, 28);
            this.labelTiempoxImagen.Name = "labelTiempoxImagen";
            this.labelTiempoxImagen.Size = new System.Drawing.Size(155, 13);
            this.labelTiempoxImagen.TabIndex = 16;
            this.labelTiempoxImagen.Text = "Tiempo Por Imágen: (hh:mm:ss)";
            // 
            // bTMS
            // 
            this.bTMS.Location = new System.Drawing.Point(6, 56);
            this.bTMS.Name = "bTMS";
            this.bTMS.Size = new System.Drawing.Size(219, 36);
            this.bTMS.TabIndex = 20;
            this.bTMS.Text = "Tiempo Máximo Sugerido";
            this.bTMS.UseVisualStyleBackColor = true;
            this.bTMS.Click += new System.EventHandler(this.BTMS_Click);
            // 
            // numSS
            // 
            this.numSS.Location = new System.Drawing.Point(262, 26);
            this.numSS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numSS.Name = "numSS";
            this.numSS.Size = new System.Drawing.Size(43, 20);
            this.numSS.TabIndex = 21;
            this.numSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbCampaña
            // 
            this.gbCampaña.Controls.Add(this.numSS);
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
            // btnHorariosOcupados
            // 
            this.btnHorariosOcupados.Location = new System.Drawing.Point(254, 165);
            this.btnHorariosOcupados.Name = "btnHorariosOcupados";
            this.btnHorariosOcupados.Size = new System.Drawing.Size(200, 36);
            this.btnHorariosOcupados.TabIndex = 27;
            this.btnHorariosOcupados.Text = "Horarios Ocupados";
            this.btnHorariosOcupados.UseVisualStyleBackColor = true;
            this.btnHorariosOcupados.Click += new System.EventHandler(this.BtnHorariosOcupados_Click);
            // 
            // NuevoCampaña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(770, 318);
            this.ControlBox = false;
            this.Controls.Add(this.btnHorariosOcupados);
            this.Controls.Add(this.lvImagenes);
            this.Controls.Add(this.gbCampaña);
            this.Name = "NuevoCampaña";
            this.Text = "Nueva Campaña";
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.gbCampaña, 0);
            this.Controls.SetChildIndex(this.lvImagenes, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.tbNombre, 0);
            this.Controls.SetChildIndex(this.tbDescripcion, 0);
            this.Controls.SetChildIndex(this.btnHorariosOcupados, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSS)).EndInit();
            this.gbCampaña.ResumeLayout(false);
            this.gbCampaña.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvImagenes;
        private System.Windows.Forms.OpenFileDialog abrirImagenes;
        private System.Windows.Forms.Button bAgregarImágenes;
        private System.Windows.Forms.NumericUpDown numHH;
        private System.Windows.Forms.NumericUpDown numMM;
        private System.Windows.Forms.Button bQuitarImagenes;
        private System.Windows.Forms.Label labelTiempoxImagen;
        private System.Windows.Forms.Button bTMS;
        private System.Windows.Forms.NumericUpDown numSS;
        private System.Windows.Forms.GroupBox gbCampaña;
        private System.Windows.Forms.Button btnHorariosOcupados;
    }
}
