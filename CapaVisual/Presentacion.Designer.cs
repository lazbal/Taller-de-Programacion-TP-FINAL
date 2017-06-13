namespace CapaVisual
{
    partial class Presentacion
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
            this.pbCampaña = new System.Windows.Forms.PictureBox();
            this.tbBanner = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCampaña)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCampaña
            // 
            this.pbCampaña.InitialImage = null;
            this.pbCampaña.Location = new System.Drawing.Point(3, 2);
            this.pbCampaña.Name = "pbCampaña";
            this.pbCampaña.Size = new System.Drawing.Size(662, 300);
            this.pbCampaña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCampaña.TabIndex = 0;
            this.pbCampaña.TabStop = false;
            // 
            // tbBanner
            // 
            this.tbBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBanner.BackColor = System.Drawing.SystemColors.InfoText;
            this.tbBanner.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBanner.Font = new System.Drawing.Font("Corbel", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBanner.ForeColor = System.Drawing.Color.Gold;
            this.tbBanner.Location = new System.Drawing.Point(0, 301);
            this.tbBanner.Name = "tbBanner";
            this.tbBanner.ReadOnly = true;
            this.tbBanner.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbBanner.Size = new System.Drawing.Size(666, 40);
            this.tbBanner.TabIndex = 1;
            // 
            // Presentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 341);
            this.Controls.Add(this.tbBanner);
            this.Controls.Add(this.pbCampaña);
            this.Name = "Presentacion";
            this.Text = "Presentacion";
            ((System.ComponentModel.ISupportInitialize)(this.pbCampaña)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCampaña;
        private System.Windows.Forms.TextBox tbBanner;
    }
}