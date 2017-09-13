namespace APP_Admin
{
    partial class frmPresentacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPresentacion));
            this.pbImgPre = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tempoPre = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgPre)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImgPre
            // 
            this.pbImgPre.Image = ((System.Drawing.Image)(resources.GetObject("pbImgPre.Image")));
            this.pbImgPre.Location = new System.Drawing.Point(119, 69);
            this.pbImgPre.Name = "pbImgPre";
            this.pbImgPre.Size = new System.Drawing.Size(427, 314);
            this.pbImgPre.TabIndex = 0;
            this.pbImgPre.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(211)))), ((int)(((byte)(193)))));
            this.panel1.Controls.Add(this.pbImgPre);
            this.panel1.Location = new System.Drawing.Point(195, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 441);
            this.panel1.TabIndex = 1;
            // 
            // tempoPre
            // 
            this.tempoPre.Enabled = true;
            this.tempoPre.Interval = 3500;
            this.tempoPre.Tick += new System.EventHandler(this.tempoPre_Tick);
            // 
            // frmPresentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(239)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(1056, 647);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPresentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPresentacion";
            ((System.ComponentModel.ISupportInitialize)(this.pbImgPre)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImgPre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tempoPre;
    }
}