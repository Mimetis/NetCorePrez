namespace _4
{
    partial class Form1
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
            this.btnLaunch = new System.Windows.Forms.Button();
            this.radRadialGauge1 = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFilesLength = new System.Windows.Forms.Label();
            this.radialGaugeArc1 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc2 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeNeedle1 = new Telerik.WinControls.UI.Gauges.RadialGaugeNeedle();
            this.txtDirName = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radRadialGauge1)).BeginInit();
            this.radRadialGauge1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(394, 397);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(394, 41);
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "Lancer";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.button1_Click);
            // 
            // radRadialGauge1
            // 
            this.radRadialGauge1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radRadialGauge1.BackColor = System.Drawing.Color.White;
            this.radRadialGauge1.CausesValidation = false;
            this.radRadialGauge1.Controls.Add(this.lblDuration);
            this.radRadialGauge1.Controls.Add(this.label2);
            this.radRadialGauge1.Controls.Add(this.label1);
            this.radRadialGauge1.Controls.Add(this.lblFilesLength);
            this.radRadialGauge1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc1,
            this.radialGaugeArc2,
            this.radialGaugeNeedle1});
            this.radRadialGauge1.Location = new System.Drawing.Point(12, 56);
            this.radRadialGauge1.Name = "radRadialGauge1";
            this.radRadialGauge1.Size = new System.Drawing.Size(776, 335);
            this.radRadialGauge1.StartAngle = 180D;
            this.radRadialGauge1.SweepAngle = 180D;
            this.radRadialGauge1.TabIndex = 6;
            this.radRadialGauge1.Text = "radRadialGauge1";
            this.radRadialGauge1.Value = 0F;
            this.radRadialGauge1.ValueChanged += new System.EventHandler(this.radRadialGauge1_ValueChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(451, 265);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(25, 25);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Durée:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de fichiers :";
            // 
            // lblFilesLength
            // 
            this.lblFilesLength.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFilesLength.AutoSize = true;
            this.lblFilesLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesLength.Location = new System.Drawing.Point(451, 228);
            this.lblFilesLength.Name = "lblFilesLength";
            this.lblFilesLength.Size = new System.Drawing.Size(25, 25);
            this.lblFilesLength.TabIndex = 0;
            this.lblFilesLength.Text = "0";
            // 
            // radialGaugeArc1
            // 
            this.radialGaugeArc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(190)))), ((int)(((byte)(79)))));
            this.radialGaugeArc1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(191)))), ((int)(((byte)(80)))));
            this.radialGaugeArc1.BindEndRange = true;
            this.radialGaugeArc1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc1.Name = "radialGaugeArc1";
            this.radialGaugeArc1.RangeEnd = 0D;
            this.radialGaugeArc1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc1.UseCompatibleTextRendering = false;
            this.radialGaugeArc1.Width = 40D;
            // 
            // radialGaugeArc2
            // 
            this.radialGaugeArc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.radialGaugeArc2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.radialGaugeArc2.BindStartRange = true;
            this.radialGaugeArc2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc2.Name = "radialGaugeArc2";
            this.radialGaugeArc2.RangeEnd = 100D;
            this.radialGaugeArc2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc2.UseCompatibleTextRendering = false;
            this.radialGaugeArc2.Width = 40D;
            // 
            // radialGaugeNeedle1
            // 
            this.radialGaugeNeedle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.radialGaugeNeedle1.BackLenghtPercentage = 0D;
            this.radialGaugeNeedle1.BindValue = true;
            this.radialGaugeNeedle1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeNeedle1.InnerPointRadiusPercentage = 0D;
            this.radialGaugeNeedle1.LenghtPercentage = 94D;
            this.radialGaugeNeedle1.Name = "radialGaugeNeedle1";
            this.radialGaugeNeedle1.Text = "dedede";
            this.radialGaugeNeedle1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeNeedle1.Thickness = 5D;
            this.radialGaugeNeedle1.UseCompatibleTextRendering = false;
            this.radialGaugeNeedle1.Value = 0F;
            // 
            // txtDirName
            // 
            this.txtDirName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirName.Location = new System.Drawing.Point(12, 12);
            this.txtDirName.Name = "txtDirName";
            this.txtDirName.Size = new System.Drawing.Size(661, 38);
            this.txtDirName.TabIndex = 7;
            this.txtDirName.Text = "C:\\PROJECTS";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(679, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(109, 38);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(12, 401);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 33);
            this.lblVersion.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtDirName);
            this.Controls.Add(this.radRadialGauge1);
            this.Controls.Add(this.btnLaunch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radRadialGauge1)).EndInit();
            this.radRadialGauge1.ResumeLayout(false);
            this.radRadialGauge1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaunch;
        private Telerik.WinControls.UI.Gauges.RadRadialGauge radRadialGauge1;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc1;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc2;
        private Telerik.WinControls.UI.Gauges.RadialGaugeNeedle radialGaugeNeedle1;
        private System.Windows.Forms.Label lblFilesLength;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblVersion;
    }
}

