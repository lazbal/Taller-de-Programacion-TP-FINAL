namespace CapaVisual
{
    partial class Buscar
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
            this.grillaBusqueda = new System.Windows.Forms.DataGridView();
            this.columnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cadenaBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBusqueda)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaBusqueda
            // 
            this.grillaBusqueda.AllowUserToAddRows = false;
            this.grillaBusqueda.AllowUserToDeleteRows = false;
            this.grillaBusqueda.AllowUserToOrderColumns = true;
            this.grillaBusqueda.AllowUserToResizeRows = false;
            this.grillaBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grillaBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnId});
            this.grillaBusqueda.Cursor = System.Windows.Forms.Cursors.Default;
            this.grillaBusqueda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grillaBusqueda.Location = new System.Drawing.Point(0, 53);
            this.grillaBusqueda.MultiSelect = false;
            this.grillaBusqueda.Name = "grillaBusqueda";
            this.grillaBusqueda.RowHeadersVisible = false;
            this.grillaBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaBusqueda.Size = new System.Drawing.Size(655, 234);
            this.grillaBusqueda.TabIndex = 4;
            this.grillaBusqueda.DoubleClick += new System.EventHandler(this.grillaBusqueda_DoubleClick);
            // 
            // columnId
            // 
            this.columnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnId.HeaderText = "ID";
            this.columnId.Name = "columnId";
            this.columnId.ReadOnly = true;
            this.columnId.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(3, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(52, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cadenaBuscar, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, -1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 54);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // cadenaBuscar
            // 
            this.cadenaBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cadenaBuscar.Location = new System.Drawing.Point(61, 17);
            this.cadenaBuscar.Name = "cadenaBuscar";
            this.cadenaBuscar.Size = new System.Drawing.Size(460, 20);
            this.cadenaBuscar.TabIndex = 4;
            this.cadenaBuscar.TextChanged += new System.EventHandler(this.cadenaBuscar_TextChanged);
            // 
            // Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 288);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.grillaBusqueda);
            this.Name = "Buscar";
            this.Text = "Buscar";
            ((System.ComponentModel.ISupportInitialize)(this.grillaBusqueda)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.DataGridView grillaBusqueda;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.TextBox cadenaBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnId;
    }
}