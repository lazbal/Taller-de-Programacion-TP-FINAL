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
            this.btnNuevoCartel = new System.Windows.Forms.Button();
            this.btnPresentacion = new System.Windows.Forms.Button();
            this.btnListarCarteles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNuevoCartel
            // 
            this.btnNuevoCartel.Location = new System.Drawing.Point(118, 12);
            this.btnNuevoCartel.Name = "btnNuevoCartel";
            this.btnNuevoCartel.Size = new System.Drawing.Size(100, 100);
            this.btnNuevoCartel.TabIndex = 0;
            this.btnNuevoCartel.Text = "Crear Nuevo Cartel";
            this.btnNuevoCartel.UseVisualStyleBackColor = true;
            this.btnNuevoCartel.Click += new System.EventHandler(this.btnNuevoElemento_Click);
            // 
            // btnPresentacion
            // 
            this.btnPresentacion.Location = new System.Drawing.Point(12, 12);
            this.btnPresentacion.Name = "btnPresentacion";
            this.btnPresentacion.Size = new System.Drawing.Size(100, 100);
            this.btnPresentacion.TabIndex = 1;
            this.btnPresentacion.Text = "Iniciar Presentación";
            this.btnPresentacion.UseVisualStyleBackColor = true;
            this.btnPresentacion.Click += new System.EventHandler(this.btnPresentacion_Click);
            // 
            // btnListarCarteles
            // 
            this.btnListarCarteles.Location = new System.Drawing.Point(224, 12);
            this.btnListarCarteles.Name = "btnListarCarteles";
            this.btnListarCarteles.Size = new System.Drawing.Size(100, 100);
            this.btnListarCarteles.TabIndex = 2;
            this.btnListarCarteles.Text = "Listar Carteles Existentes";
            this.btnListarCarteles.UseVisualStyleBackColor = true;
            this.btnListarCarteles.Click += new System.EventHandler(this.btnListarCarteles_Click);
            // 
            // AdminCarteleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 124);
            this.Controls.Add(this.btnListarCarteles);
            this.Controls.Add(this.btnPresentacion);
            this.Controls.Add(this.btnNuevoCartel);
            this.Name = "AdminCarteleria";
            this.Text = "AdminCampañasBanner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoCartel;
        private System.Windows.Forms.Button btnPresentacion;
        private System.Windows.Forms.Button btnListarCarteles;
    }
}