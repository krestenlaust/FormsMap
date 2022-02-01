
namespace LPSView
{
    partial class StationConfigPrompt
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownStationID = new System.Windows.Forms.NumericUpDown();
            this.labelStationName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownLocationX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLocationY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocationX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocationY)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Station navn: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Station ID:";
            // 
            // numericUpDownStationID
            // 
            this.numericUpDownStationID.Location = new System.Drawing.Point(107, 42);
            this.numericUpDownStationID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownStationID.Name = "numericUpDownStationID";
            this.numericUpDownStationID.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownStationID.TabIndex = 2;
            // 
            // labelStationName
            // 
            this.labelStationName.AutoSize = true;
            this.labelStationName.Location = new System.Drawing.Point(104, 13);
            this.labelStationName.Name = "labelStationName";
            this.labelStationName.Size = new System.Drawing.Size(46, 17);
            this.labelStationName.TabIndex = 3;
            this.labelStationName.Text = "label3";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(144, 113);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(121, 32);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Gem";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(12, 113);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 32);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Annuller";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Location:";
            // 
            // numericUpDownLocationX
            // 
            this.numericUpDownLocationX.Location = new System.Drawing.Point(107, 77);
            this.numericUpDownLocationX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownLocationX.Name = "numericUpDownLocationX";
            this.numericUpDownLocationX.Size = new System.Drawing.Size(77, 22);
            this.numericUpDownLocationX.TabIndex = 7;
            // 
            // numericUpDownLocationY
            // 
            this.numericUpDownLocationY.Location = new System.Drawing.Point(190, 77);
            this.numericUpDownLocationY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownLocationY.Name = "numericUpDownLocationY";
            this.numericUpDownLocationY.Size = new System.Drawing.Size(77, 22);
            this.numericUpDownLocationY.TabIndex = 8;
            // 
            // StationConfigPrompt
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(277, 157);
            this.Controls.Add(this.numericUpDownLocationY);
            this.Controls.Add(this.numericUpDownLocationX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelStationName);
            this.Controls.Add(this.numericUpDownStationID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "StationConfigPrompt";
            this.Text = "l";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocationX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLocationY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownStationID;
        private System.Windows.Forms.Label labelStationName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownLocationX;
        private System.Windows.Forms.NumericUpDown numericUpDownLocationY;
    }
}