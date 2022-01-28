
namespace LPSView
{
    partial class ConfigForm
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
            this.textBoxHostname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonConnectDatabase = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonManualQuery = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownStation3Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStation3X = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStation2Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStation2X = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStation1Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStation1X = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.labelDataCollected = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxAlgoOutput = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation3Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation3X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation1X)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxHostname
            // 
            this.textBoxHostname.Location = new System.Drawing.Point(6, 21);
            this.textBoxHostname.Name = "textBoxHostname";
            this.textBoxHostname.Size = new System.Drawing.Size(188, 22);
            this.textBoxHostname.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonConnectDatabase);
            this.groupBox1.Controls.Add(this.textBoxHostname);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database forbindelse";
            // 
            // buttonConnectDatabase
            // 
            this.buttonConnectDatabase.Location = new System.Drawing.Point(6, 49);
            this.buttonConnectDatabase.Name = "buttonConnectDatabase";
            this.buttonConnectDatabase.Size = new System.Drawing.Size(188, 33);
            this.buttonConnectDatabase.TabIndex = 1;
            this.buttonConnectDatabase.Text = "Forbind";
            this.buttonConnectDatabase.UseVisualStyleBackColor = true;
            this.buttonConnectDatabase.Click += new System.EventHandler(this.buttonConnectDatabase_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonManualQuery);
            this.groupBox2.Location = new System.Drawing.Point(229, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 66);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database test";
            // 
            // buttonManualQuery
            // 
            this.buttonManualQuery.Location = new System.Drawing.Point(6, 21);
            this.buttonManualQuery.Name = "buttonManualQuery";
            this.buttonManualQuery.Size = new System.Drawing.Size(177, 34);
            this.buttonManualQuery.TabIndex = 0;
            this.buttonManualQuery.Text = "Manuel query";
            this.buttonManualQuery.UseVisualStyleBackColor = true;
            this.buttonManualQuery.Click += new System.EventHandler(this.buttonManualQuery_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownStation3Y);
            this.groupBox3.Controls.Add(this.numericUpDownStation3X);
            this.groupBox3.Controls.Add(this.numericUpDownStation2Y);
            this.groupBox3.Controls.Add(this.numericUpDownStation2X);
            this.groupBox3.Controls.Add(this.numericUpDownStation1Y);
            this.groupBox3.Controls.Add(this.numericUpDownStation1X);
            this.groupBox3.Location = new System.Drawing.Point(12, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 227);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Station placering";
            // 
            // numericUpDownStation3Y
            // 
            this.numericUpDownStation3Y.Location = new System.Drawing.Point(6, 161);
            this.numericUpDownStation3Y.Name = "numericUpDownStation3Y";
            this.numericUpDownStation3Y.Size = new System.Drawing.Size(188, 22);
            this.numericUpDownStation3Y.TabIndex = 5;
            // 
            // numericUpDownStation3X
            // 
            this.numericUpDownStation3X.Location = new System.Drawing.Point(6, 133);
            this.numericUpDownStation3X.Name = "numericUpDownStation3X";
            this.numericUpDownStation3X.Size = new System.Drawing.Size(188, 22);
            this.numericUpDownStation3X.TabIndex = 4;
            // 
            // numericUpDownStation2Y
            // 
            this.numericUpDownStation2Y.Location = new System.Drawing.Point(6, 105);
            this.numericUpDownStation2Y.Name = "numericUpDownStation2Y";
            this.numericUpDownStation2Y.Size = new System.Drawing.Size(188, 22);
            this.numericUpDownStation2Y.TabIndex = 3;
            // 
            // numericUpDownStation2X
            // 
            this.numericUpDownStation2X.Location = new System.Drawing.Point(6, 77);
            this.numericUpDownStation2X.Name = "numericUpDownStation2X";
            this.numericUpDownStation2X.Size = new System.Drawing.Size(188, 22);
            this.numericUpDownStation2X.TabIndex = 2;
            // 
            // numericUpDownStation1Y
            // 
            this.numericUpDownStation1Y.Location = new System.Drawing.Point(6, 49);
            this.numericUpDownStation1Y.Name = "numericUpDownStation1Y";
            this.numericUpDownStation1Y.Size = new System.Drawing.Size(188, 22);
            this.numericUpDownStation1Y.TabIndex = 1;
            // 
            // numericUpDownStation1X
            // 
            this.numericUpDownStation1X.Location = new System.Drawing.Point(6, 21);
            this.numericUpDownStation1X.Name = "numericUpDownStation1X";
            this.numericUpDownStation1X.Size = new System.Drawing.Size(188, 22);
            this.numericUpDownStation1X.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBoxAlgoOutput);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.buttonCalculate);
            this.groupBox4.Controls.Add(this.labelDataCollected);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(229, 84);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(189, 251);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gemt data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Algoritme:";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(9, 54);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(174, 27);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Beregn";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // labelDataCollected
            // 
            this.labelDataCollected.AutoSize = true;
            this.labelDataCollected.Location = new System.Drawing.Point(100, 24);
            this.labelDataCollected.Name = "labelDataCollected";
            this.labelDataCollected.Size = new System.Drawing.Size(46, 17);
            this.labelDataCollected.TabIndex = 1;
            this.labelDataCollected.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data samlet:";
            // 
            // richTextBoxAlgoOutput
            // 
            this.richTextBoxAlgoOutput.Location = new System.Drawing.Point(6, 104);
            this.richTextBoxAlgoOutput.Name = "richTextBoxAlgoOutput";
            this.richTextBoxAlgoOutput.Size = new System.Drawing.Size(177, 141);
            this.richTextBoxAlgoOutput.TabIndex = 4;
            this.richTextBoxAlgoOutput.Text = "";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 347);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation3Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation3X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStation1X)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHostname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonConnectDatabase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonManualQuery;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownStation3Y;
        private System.Windows.Forms.NumericUpDown numericUpDownStation3X;
        private System.Windows.Forms.NumericUpDown numericUpDownStation2Y;
        private System.Windows.Forms.NumericUpDown numericUpDownStation2X;
        private System.Windows.Forms.NumericUpDown numericUpDownStation1Y;
        private System.Windows.Forms.NumericUpDown numericUpDownStation1X;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelDataCollected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.RichTextBox richTextBoxAlgoOutput;
    }
}