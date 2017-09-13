namespace APP_Admin
{
    partial class frmZona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZona));
            this.tstZona = new System.Windows.Forms.ToolStrip();
            this.tsbZBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZUpd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZSave = new System.Windows.Forms.ToolStripButton();
            this.gbDatoZona = new System.Windows.Forms.GroupBox();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.lblDpto = new System.Windows.Forms.Label();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.lblAcron = new System.Windows.Forms.Label();
            this.txtAcron = new System.Windows.Forms.TextBox();
            this.errorZ = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbServ = new System.Windows.Forms.GroupBox();
            this.lblLetra = new System.Windows.Forms.Label();
            this.lbl3letras = new System.Windows.Forms.Label();
            this.txtNomOficial = new System.Windows.Forms.TextBox();
            this.lblNomOficial = new System.Windows.Forms.Label();
            this.txtHab = new System.Windows.Forms.TextBox();
            this.lblCantHab = new System.Windows.Forms.Label();
            this.tstZona.SuspendLayout();
            this.gbDatoZona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorZ)).BeginInit();
            this.gbServ.SuspendLayout();
            this.SuspendLayout();
            // 
            // tstZona
            // 
            this.tstZona.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.tstZona.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbZBuscar,
            this.toolStripSeparator1,
            this.tsbZAdd,
            this.toolStripSeparator2,
            this.tsbZDel,
            this.toolStripSeparator3,
            this.tsbZUpd,
            this.toolStripSeparator4,
            this.tsbZSave});
            this.tstZona.Location = new System.Drawing.Point(0, 0);
            this.tstZona.Name = "tstZona";
            this.tstZona.Size = new System.Drawing.Size(1296, 32);
            this.tstZona.TabIndex = 0;
            // 
            // tsbZBuscar
            // 
            this.tsbZBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZBuscar.Image = ((System.Drawing.Image)(resources.GetObject("tsbZBuscar.Image")));
            this.tsbZBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZBuscar.Name = "tsbZBuscar";
            this.tsbZBuscar.Size = new System.Drawing.Size(29, 29);
            this.tsbZBuscar.Text = "Buscar Zona";
            this.tsbZBuscar.ToolTipText = "Utilice este botó para buscar una Zona en el Sistema";
            this.tsbZBuscar.Click += new System.EventHandler(this.tsbZBuscar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbZAdd
            // 
            this.tsbZAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbZAdd.Image")));
            this.tsbZAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZAdd.Name = "tsbZAdd";
            this.tsbZAdd.Size = new System.Drawing.Size(29, 29);
            this.tsbZAdd.Text = "Agregar Zona";
            this.tsbZAdd.ToolTipText = "Utilice este botón para agregar una Zona al Sistema";
            this.tsbZAdd.Click += new System.EventHandler(this.tsbZAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbZDel
            // 
            this.tsbZDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbZDel.Image")));
            this.tsbZDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZDel.Name = "tsbZDel";
            this.tsbZDel.Size = new System.Drawing.Size(29, 29);
            this.tsbZDel.Text = "Eliminar una Zona";
            this.tsbZDel.ToolTipText = "Utilice este botón para eliminar una Zona del Sistema ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbZUpd
            // 
            this.tsbZUpd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZUpd.Image = ((System.Drawing.Image)(resources.GetObject("tsbZUpd.Image")));
            this.tsbZUpd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZUpd.Name = "tsbZUpd";
            this.tsbZUpd.Size = new System.Drawing.Size(29, 29);
            this.tsbZUpd.Text = "Actualizar Zona";
            this.tsbZUpd.ToolTipText = "Utilice este botón para acturalizar los datos de una Zona";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbZSave
            // 
            this.tsbZSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbZSave.Image")));
            this.tsbZSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZSave.Name = "tsbZSave";
            this.tsbZSave.Size = new System.Drawing.Size(29, 29);
            this.tsbZSave.Text = "Guardar Cambios";
            this.tsbZSave.ToolTipText = "Guarda y confirma los cambios realizados en una Zona";
            // 
            // gbDatoZona
            // 
            this.gbDatoZona.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(239)))), ((int)(((byte)(223)))));
            this.gbDatoZona.Controls.Add(this.txtHab);
            this.gbDatoZona.Controls.Add(this.lblCantHab);
            this.gbDatoZona.Controls.Add(this.txtNomOficial);
            this.gbDatoZona.Controls.Add(this.lblNomOficial);
            this.gbDatoZona.Controls.Add(this.lbl3letras);
            this.gbDatoZona.Controls.Add(this.lblLetra);
            this.gbDatoZona.Controls.Add(this.txtAcron);
            this.gbDatoZona.Controls.Add(this.lblAcron);
            this.gbDatoZona.Controls.Add(this.lblDpto);
            this.gbDatoZona.Controls.Add(this.txtDpto);
            this.gbDatoZona.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatoZona.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.gbDatoZona.Location = new System.Drawing.Point(13, 82);
            this.gbDatoZona.Name = "gbDatoZona";
            this.gbDatoZona.Size = new System.Drawing.Size(653, 418);
            this.gbDatoZona.TabIndex = 1;
            this.gbDatoZona.TabStop = false;
            this.gbDatoZona.Text = "Identificación de Zona";
            // 
            // txtDpto
            // 
            this.txtDpto.Location = new System.Drawing.Point(334, 48);
            this.txtDpto.Name = "txtDpto";
            this.txtDpto.Size = new System.Drawing.Size(287, 31);
            this.txtDpto.TabIndex = 0;
            this.txtDpto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDpto
            // 
            this.lblDpto.AutoSize = true;
            this.lblDpto.Location = new System.Drawing.Point(18, 56);
            this.lblDpto.Name = "lblDpto";
            this.lblDpto.Size = new System.Drawing.Size(230, 23);
            this.lblDpto.TabIndex = 1;
            this.lblDpto.Text = "Identificador Depto.";
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AllowUserToOrderColumns = true;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Location = new System.Drawing.Point(6, 34);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowTemplate.Height = 24;
            this.dgvServicios.Size = new System.Drawing.Size(568, 378);
            this.dgvServicios.TabIndex = 0;
            // 
            // lblAcron
            // 
            this.lblAcron.AutoSize = true;
            this.lblAcron.Location = new System.Drawing.Point(18, 142);
            this.lblAcron.Name = "lblAcron";
            this.lblAcron.Size = new System.Drawing.Size(241, 23);
            this.lblAcron.TabIndex = 2;
            this.lblAcron.Text = "Acrónimo para la Zona";
            // 
            // txtAcron
            // 
            this.txtAcron.Location = new System.Drawing.Point(334, 134);
            this.txtAcron.Name = "txtAcron";
            this.txtAcron.Size = new System.Drawing.Size(287, 31);
            this.txtAcron.TabIndex = 3;
            this.txtAcron.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorZ
            // 
            this.errorZ.ContainerControl = this;
            // 
            // gbServ
            // 
            this.gbServ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(239)))), ((int)(((byte)(223)))));
            this.gbServ.Controls.Add(this.dgvServicios);
            this.gbServ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbServ.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.gbServ.Location = new System.Drawing.Point(700, 82);
            this.gbServ.Name = "gbServ";
            this.gbServ.Size = new System.Drawing.Size(580, 418);
            this.gbServ.TabIndex = 3;
            this.gbServ.TabStop = false;
            this.gbServ.Text = "Servicios Asociados";
            // 
            // lblLetra
            // 
            this.lblLetra.AutoSize = true;
            this.lblLetra.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetra.Location = new System.Drawing.Point(342, 82);
            this.lblLetra.Name = "lblLetra";
            this.lblLetra.Size = new System.Drawing.Size(224, 18);
            this.lblLetra.TabIndex = 4;
            this.lblLetra.Text = "Se identifica con una letra";
            // 
            // lbl3letras
            // 
            this.lbl3letras.AutoSize = true;
            this.lbl3letras.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3letras.Location = new System.Drawing.Point(339, 168);
            this.lbl3letras.Name = "lbl3letras";
            this.lbl3letras.Size = new System.Drawing.Size(240, 18);
            this.lbl3letras.TabIndex = 5;
            this.lbl3letras.Text = "Se identifica con tres letras";
            // 
            // txtNomOficial
            // 
            this.txtNomOficial.Location = new System.Drawing.Point(334, 226);
            this.txtNomOficial.Name = "txtNomOficial";
            this.txtNomOficial.Size = new System.Drawing.Size(287, 31);
            this.txtNomOficial.TabIndex = 7;
            this.txtNomOficial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNomOficial
            // 
            this.lblNomOficial.AutoSize = true;
            this.lblNomOficial.Location = new System.Drawing.Point(18, 234);
            this.lblNomOficial.Name = "lblNomOficial";
            this.lblNomOficial.Size = new System.Drawing.Size(285, 23);
            this.lblNomOficial.TabIndex = 6;
            this.lblNomOficial.Text = "Nombre Oficial de la Zona";
            // 
            // txtHab
            // 
            this.txtHab.Location = new System.Drawing.Point(334, 320);
            this.txtHab.Name = "txtHab";
            this.txtHab.Size = new System.Drawing.Size(287, 31);
            this.txtHab.TabIndex = 10;
            this.txtHab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCantHab
            // 
            this.lblCantHab.AutoSize = true;
            this.lblCantHab.Location = new System.Drawing.Point(18, 328);
            this.lblCantHab.Name = "lblCantHab";
            this.lblCantHab.Size = new System.Drawing.Size(252, 23);
            this.lblCantHab.TabIndex = 9;
            this.lblCantHab.Text = "Cantidad de Habitantes";
            // 
            // frmZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(211)))), ((int)(((byte)(193)))));
            this.ClientSize = new System.Drawing.Size(1296, 531);
            this.Controls.Add(this.gbServ);
            this.Controls.Add(this.gbDatoZona);
            this.Controls.Add(this.tstZona);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmZona";
            this.Text = "Sistema Gestión de Zonas";
            this.Load += new System.EventHandler(this.frmZona_Load);
            this.tstZona.ResumeLayout(false);
            this.tstZona.PerformLayout();
            this.gbDatoZona.ResumeLayout(false);
            this.gbDatoZona.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorZ)).EndInit();
            this.gbServ.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tstZona;
        private System.Windows.Forms.ToolStripButton tsbZBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbZAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbZDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbZUpd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbZSave;
        private System.Windows.Forms.GroupBox gbDatoZona;
        private System.Windows.Forms.TextBox txtAcron;
        private System.Windows.Forms.Label lblAcron;
        private System.Windows.Forms.Label lblDpto;
        private System.Windows.Forms.TextBox txtDpto;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.ErrorProvider errorZ;
        private System.Windows.Forms.GroupBox gbServ;
        private System.Windows.Forms.Label lbl3letras;
        private System.Windows.Forms.Label lblLetra;
        private System.Windows.Forms.TextBox txtHab;
        private System.Windows.Forms.Label lblCantHab;
        private System.Windows.Forms.TextBox txtNomOficial;
        private System.Windows.Forms.Label lblNomOficial;
    }
}