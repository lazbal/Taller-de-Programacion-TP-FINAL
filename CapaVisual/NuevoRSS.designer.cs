namespace CapaVisual
{
    partial class NuevoRSS
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
            this.tbURL = new System.Windows.Forms.TextBox();
            this.dgDatos = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.sbStatusRSS = new System.Windows.Forms.StatusStrip();
            this.bgWorkerRSS = new System.ComponentModel.BackgroundWorker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.colTítulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // tbURL
            // 
            this.tbURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbURL.Location = new System.Drawing.Point(0, 12);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(501, 20);
            this.tbURL.TabIndex = 0;
            this.tbURL.Text = "URL del feed";
            this.tbURL.TextChanged += new System.EventHandler(this.tbURL_TextChanged);
            // 
            // dgDatos
            // 
            this.dgDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTítulo,
            this.colDescripcion});
            this.dgDatos.Location = new System.Drawing.Point(0, 38);
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.ReadOnly = true;
            this.dgDatos.Size = new System.Drawing.Size(417, 247);
            this.dgDatos.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(422, 38);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(79, 32);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // sbStatusRSS
            // 
            this.sbStatusRSS.Location = new System.Drawing.Point(0, 290);
            this.sbStatusRSS.Name = "sbStatusRSS";
            this.sbStatusRSS.Size = new System.Drawing.Size(501, 22);
            this.sbStatusRSS.TabIndex = 7;
            this.sbStatusRSS.Text = "sbStatusRSS";
            // 
            // bgWorkerRSS
            // 
            this.bgWorkerRSS.WorkerSupportsCancellation = true;
            this.bgWorkerRSS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerRSS_DoWork);
            this.bgWorkerRSS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerRSS_RunWorkerCompleted);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(423, 77);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 32);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(422, 39);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(79, 32);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Visible = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // colTítulo
            // 
            this.colTítulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTítulo.HeaderText = "Título";
            this.colTítulo.Name = "colTítulo";
            this.colTítulo.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // NuevoRSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 312);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.sbStatusRSS);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgDatos);
            this.Controls.Add(this.tbURL);
            this.Name = "NuevoRSS";
            this.Text = "Nuevo RSS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NuevoRSS_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.DataGridView dgDatos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.StatusStrip sbStatusRSS;
        private System.ComponentModel.BackgroundWorker bgWorkerRSS;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTítulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
    }
}

