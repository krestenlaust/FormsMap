
namespace LearnmarkMap
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxZoom = new System.Windows.Forms.GroupBox();
            this.numericUpDownZoomFactor = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxPan = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownPanY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPanX = new System.Windows.Forms.NumericUpDown();
            this.formsMap1 = new FormsMapController.FormsMap();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZoomFactor)).BeginInit();
            this.groupBoxPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPanY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPanX)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxZoom);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxPan);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.formsMap1);
            this.splitContainer1.Size = new System.Drawing.Size(916, 524);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBoxZoom
            // 
            this.groupBoxZoom.Controls.Add(this.numericUpDownZoomFactor);
            this.groupBoxZoom.Controls.Add(this.label3);
            this.groupBoxZoom.Location = new System.Drawing.Point(12, 117);
            this.groupBoxZoom.Name = "groupBoxZoom";
            this.groupBoxZoom.Size = new System.Drawing.Size(200, 74);
            this.groupBoxZoom.TabIndex = 2;
            this.groupBoxZoom.TabStop = false;
            this.groupBoxZoom.Text = "Zoom";
            // 
            // numericUpDownZoomFactor
            // 
            this.numericUpDownZoomFactor.DecimalPlaces = 1;
            this.numericUpDownZoomFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownZoomFactor.Location = new System.Drawing.Point(63, 31);
            this.numericUpDownZoomFactor.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownZoomFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownZoomFactor.Name = "numericUpDownZoomFactor";
            this.numericUpDownZoomFactor.Size = new System.Drawing.Size(131, 22);
            this.numericUpDownZoomFactor.TabIndex = 2;
            this.numericUpDownZoomFactor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownZoomFactor.ValueChanged += new System.EventHandler(this.numericUpDownZoomFactor_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Faktor";
            // 
            // groupBoxPan
            // 
            this.groupBoxPan.Controls.Add(this.label2);
            this.groupBoxPan.Controls.Add(this.numericUpDownPanY);
            this.groupBoxPan.Controls.Add(this.label1);
            this.groupBoxPan.Controls.Add(this.numericUpDownPanX);
            this.groupBoxPan.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPan.Name = "groupBoxPan";
            this.groupBoxPan.Size = new System.Drawing.Size(200, 99);
            this.groupBoxPan.TabIndex = 1;
            this.groupBoxPan.TabStop = false;
            this.groupBoxPan.Text = "Panorering";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // numericUpDownPanY
            // 
            this.numericUpDownPanY.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownPanY.Location = new System.Drawing.Point(29, 58);
            this.numericUpDownPanY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownPanY.Name = "numericUpDownPanY";
            this.numericUpDownPanY.Size = new System.Drawing.Size(165, 22);
            this.numericUpDownPanY.TabIndex = 1;
            this.numericUpDownPanY.ValueChanged += new System.EventHandler(this.numericUpDownPanY_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // numericUpDownPanX
            // 
            this.numericUpDownPanX.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownPanX.Location = new System.Drawing.Point(29, 30);
            this.numericUpDownPanX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownPanX.Name = "numericUpDownPanX";
            this.numericUpDownPanX.Size = new System.Drawing.Size(165, 22);
            this.numericUpDownPanX.TabIndex = 0;
            this.numericUpDownPanX.ValueChanged += new System.EventHandler(this.numericUpDownPanX_ValueChanged);
            // 
            // formsMap1
            // 
            this.formsMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsMap1.Location = new System.Drawing.Point(0, 0);
            this.formsMap1.MapImage = global::FormsMapDemo.Properties.Resources._1D81B833202C4B2ABA6EF0CD161CB763_1_1_1;
            this.formsMap1.Name = "formsMap1";
            this.formsMap1.Pan = new System.Drawing.Point(0, 0);
            this.formsMap1.Size = new System.Drawing.Size(655, 524);
            this.formsMap1.TabIndex = 0;
            this.formsMap1.ZoomFactor = 1F;
            this.formsMap1.PanChanged += new System.EventHandler(this.formsMap1_PanChanged);
            this.formsMap1.ZoomFactorChanged += new System.EventHandler(this.formsMap1_ZoomFactorChanged);
            this.formsMap1.Load += new System.EventHandler(this.formsMap1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 524);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxZoom.ResumeLayout(false);
            this.groupBoxZoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZoomFactor)).EndInit();
            this.groupBoxPan.ResumeLayout(false);
            this.groupBoxPan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPanY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPanX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxPan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPanX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownPanY;
        private System.Windows.Forms.GroupBox groupBoxZoom;
        private System.Windows.Forms.NumericUpDown numericUpDownZoomFactor;
        private System.Windows.Forms.Label label3;
        public FormsMapController.FormsMap formsMap1;
    }
}

