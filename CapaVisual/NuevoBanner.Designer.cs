namespace CapaVisual
{
    partial class NuevoBanner
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
            this.btnSeleccionarFuenteRSS = new System.Windows.Forms.Button();
            this.tbEstatico = new System.Windows.Forms.TextBox();
            this.lblEstatico = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSeleccionarFuenteRSS
            // 
            this.btnSeleccionarFuenteRSS.Location = new System.Drawing.Point(515, 18);
            this.btnSeleccionarFuenteRSS.Name = "btnSeleccionarFuenteRSS";
            this.btnSeleccionarFuenteRSS.Size = new System.Drawing.Size(195, 36);
            this.btnSeleccionarFuenteRSS.TabIndex = 7;
            this.btnSeleccionarFuenteRSS.Text = "Seleccionar Fuente RSS";
            this.btnSeleccionarFuenteRSS.UseVisualStyleBackColor = true;
            this.btnSeleccionarFuenteRSS.Visible = false;
            this.btnSeleccionarFuenteRSS.Click += new System.EventHandler(this.btnSeleccionarFuenteRSS_Click);
            // 
            // tbEstatico
            // 
            this.tbEstatico.AcceptsReturn = true;
            this.tbEstatico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEstatico.Location = new System.Drawing.Point(515, 87);
            this.tbEstatico.Multiline = true;
            this.tbEstatico.Name = "tbEstatico";
            this.tbEstatico.Size = new System.Drawing.Size(195, 125);
            this.tbEstatico.TabIndex = 10;
            // 
            // lblEstatico
            // 
            this.lblEstatico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstatico.AutoSize = true;
            this.lblEstatico.Location = new System.Drawing.Point(512, 18);
            this.lblEstatico.Name = "lblEstatico";
            this.lblEstatico.Size = new System.Drawing.Size(83, 13);
            this.lblEstatico.TabIndex = 11;
            this.lblEstatico.Text = "Texto a mostrar:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(254, 189);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(379, 189);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // NuevoBanner
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(720, 231);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblEstatico);
            this.Controls.Add(this.tbEstatico);
            this.Controls.Add(this.btnSeleccionarFuenteRSS);
            this.Name = "NuevoBanner";
            this.Text = "Nuevo Banner";
            this.Load += new System.EventHandler(this.NuevoBanner_Load);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.tbNombre, 0);
            this.Controls.SetChildIndex(this.tbDescripcion, 0);
            this.Controls.SetChildIndex(this.btnSeleccionarFuenteRSS, 0);
            this.Controls.SetChildIndex(this.tbEstatico, 0);
            this.Controls.SetChildIndex(this.lblEstatico, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeleccionarFuenteRSS;
        private System.Windows.Forms.TextBox tbEstatico;
        private System.Windows.Forms.Label lblEstatico;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
