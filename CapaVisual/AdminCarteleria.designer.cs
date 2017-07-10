namespace CapaVisual
{
    partial class AdminCarteleria
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
            this.btnNuevaCampaña = new System.Windows.Forms.Button();
            this.btnPresentacion = new System.Windows.Forms.Button();
            this.btnListarCampañas = new System.Windows.Forms.Button();
            this.btnListarBanners = new System.Windows.Forms.Button();
            this.btnNuevoBanner = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNuevaCampaña
            // 
            this.btnNuevaCampaña.Location = new System.Drawing.Point(118, 12);
            this.btnNuevaCampaña.Name = "btnNuevaCampaña";
            this.btnNuevaCampaña.Size = new System.Drawing.Size(100, 100);
            this.btnNuevaCampaña.TabIndex = 0;
            this.btnNuevaCampaña.Text = "Crear Nueva Campaña";
            this.btnNuevaCampaña.UseVisualStyleBackColor = true;
            this.btnNuevaCampaña.Click += new System.EventHandler(this.btnNuevaCampaña_Click);
            // 
            // btnPresentacion
            // 
            this.btnPresentacion.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPresentacion.Location = new System.Drawing.Point(12, 12);
            this.btnPresentacion.Name = "btnPresentacion";
            this.btnPresentacion.Size = new System.Drawing.Size(100, 205);
            this.btnPresentacion.TabIndex = 1;
            this.btnPresentacion.Text = "Iniciar Presentación";
            this.btnPresentacion.UseVisualStyleBackColor = false;
            this.btnPresentacion.Click += new System.EventHandler(this.btnPresentacion_Click);
            // 
            // btnListarCampañas
            // 
            this.btnListarCampañas.Location = new System.Drawing.Point(224, 12);
            this.btnListarCampañas.Name = "btnListarCampañas";
            this.btnListarCampañas.Size = new System.Drawing.Size(100, 100);
            this.btnListarCampañas.TabIndex = 2;
            this.btnListarCampañas.Text = "Listar Campañas Existentes";
            this.btnListarCampañas.UseVisualStyleBackColor = true;
            this.btnListarCampañas.Click += new System.EventHandler(this.btnListarCampañas_Click);
            // 
            // btnListarBanners
            // 
            this.btnListarBanners.Location = new System.Drawing.Point(224, 118);
            this.btnListarBanners.Name = "btnListarBanners";
            this.btnListarBanners.Size = new System.Drawing.Size(100, 100);
            this.btnListarBanners.TabIndex = 4;
            this.btnListarBanners.Text = "Listar Banners Existentes";
            this.btnListarBanners.UseVisualStyleBackColor = true;
            this.btnListarBanners.Click += new System.EventHandler(this.btnListarBanners_Click);
            // 
            // btnNuevoBanner
            // 
            this.btnNuevoBanner.Location = new System.Drawing.Point(118, 118);
            this.btnNuevoBanner.Name = "btnNuevoBanner";
            this.btnNuevoBanner.Size = new System.Drawing.Size(100, 100);
            this.btnNuevoBanner.TabIndex = 3;
            this.btnNuevoBanner.Text = "Crear Nuevo Banner";
            this.btnNuevoBanner.UseVisualStyleBackColor = true;
            this.btnNuevoBanner.Click += new System.EventHandler(this.btnNuevoBanner_Click);
            // 
            // AdminCarteleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 229);
            this.Controls.Add(this.btnListarBanners);
            this.Controls.Add(this.btnNuevoBanner);
            this.Controls.Add(this.btnListarCampañas);
            this.Controls.Add(this.btnPresentacion);
            this.Controls.Add(this.btnNuevaCampaña);
            this.Name = "AdminCarteleria";
            this.Text = "AdminCampañasBanner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevaCampaña;
        private System.Windows.Forms.Button btnPresentacion;
        private System.Windows.Forms.Button btnListarCampañas;
        private System.Windows.Forms.Button btnListarBanners;
        private System.Windows.Forms.Button btnNuevoBanner;
    }
}