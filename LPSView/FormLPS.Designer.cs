
namespace LPSView
{
    partial class FormLPSView
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
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("MacBook Air Pro Mega");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Lenovo-2jwk");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Enheder", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Lytter110Dør");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Lytter110Bagved");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Lytter110Foran");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Stationer", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            this.buttonConfigure = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRemoveDevices = new System.Windows.Forms.Button();
            this.buttonSaveStations = new System.Windows.Forms.Button();
            this.buttonRefreshData = new System.Windows.Forms.Button();
            this.buttonStopDataPull = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonPointerCreateStation = new System.Windows.Forms.RadioButton();
            this.radioButtonPointer = new System.Windows.Forms.RadioButton();
            this.formsMap1 = new FormsMapController.FormsMap();
            this.timerPullData = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonRemoveStations = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConfigure
            // 
            this.buttonConfigure.Location = new System.Drawing.Point(9, 21);
            this.buttonConfigure.Name = "buttonConfigure";
            this.buttonConfigure.Size = new System.Drawing.Size(97, 33);
            this.buttonConfigure.TabIndex = 1;
            this.buttonConfigure.Text = "Konfigurer";
            this.buttonConfigure.UseVisualStyleBackColor = true;
            this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode8.Name = "Node2";
            treeNode8.Text = "MacBook Air Pro Mega";
            treeNode9.Name = "Node3";
            treeNode9.Text = "Lenovo-2jwk";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Enheder";
            treeNode11.Name = "Node4";
            treeNode11.Text = "Lytter110Dør";
            treeNode12.Name = "Node5";
            treeNode12.Text = "Lytter110Bagved";
            treeNode13.Name = "Node6";
            treeNode13.Text = "Lytter110Foran";
            treeNode14.Name = "Node1";
            treeNode14.Text = "Stationer";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode14});
            this.treeView1.Size = new System.Drawing.Size(207, 247);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 207;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.formsMap1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeView1);
            this.splitContainer2.Size = new System.Drawing.Size(207, 450);
            this.splitContainer2.SplitterDistance = 199;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRemoveStations);
            this.groupBox1.Controls.Add(this.buttonRemoveDevices);
            this.groupBox1.Controls.Add(this.buttonSaveStations);
            this.groupBox1.Controls.Add(this.buttonRefreshData);
            this.groupBox1.Controls.Add(this.buttonStopDataPull);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.buttonConfigure);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Værktøjer";
            // 
            // buttonRemoveDevices
            // 
            this.buttonRemoveDevices.Location = new System.Drawing.Point(9, 89);
            this.buttonRemoveDevices.Name = "buttonRemoveDevices";
            this.buttonRemoveDevices.Size = new System.Drawing.Size(96, 23);
            this.buttonRemoveDevices.TabIndex = 5;
            this.buttonRemoveDevices.Text = "Fjern alle";
            this.buttonRemoveDevices.UseVisualStyleBackColor = true;
            this.buttonRemoveDevices.Click += new System.EventHandler(this.buttonRemoveDevices_Click);
            // 
            // buttonSaveStations
            // 
            this.buttonSaveStations.Location = new System.Drawing.Point(112, 60);
            this.buttonSaveStations.Name = "buttonSaveStations";
            this.buttonSaveStations.Size = new System.Drawing.Size(89, 32);
            this.buttonSaveStations.TabIndex = 4;
            this.buttonSaveStations.Text = "Gem stationer";
            this.buttonSaveStations.UseVisualStyleBackColor = true;
            this.buttonSaveStations.Click += new System.EventHandler(this.buttonSaveStations_Click);
            // 
            // buttonRefreshData
            // 
            this.buttonRefreshData.Location = new System.Drawing.Point(112, 21);
            this.buttonRefreshData.Name = "buttonRefreshData";
            this.buttonRefreshData.Size = new System.Drawing.Size(89, 33);
            this.buttonRefreshData.TabIndex = 3;
            this.buttonRefreshData.Text = "Start";
            this.buttonRefreshData.UseVisualStyleBackColor = true;
            this.buttonRefreshData.Click += new System.EventHandler(this.buttonStartDataPull_Click);
            // 
            // buttonStopDataPull
            // 
            this.buttonStopDataPull.Location = new System.Drawing.Point(9, 60);
            this.buttonStopDataPull.Name = "buttonStopDataPull";
            this.buttonStopDataPull.Size = new System.Drawing.Size(97, 32);
            this.buttonStopDataPull.TabIndex = 2;
            this.buttonStopDataPull.Text = "Stop";
            this.buttonStopDataPull.UseVisualStyleBackColor = true;
            this.buttonStopDataPull.Click += new System.EventHandler(this.buttonStopDataPull_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButtonPointerCreateStation);
            this.groupBox2.Controls.Add(this.radioButtonPointer);
            this.groupBox2.Location = new System.Drawing.Point(3, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 78);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mus indstilling";
            // 
            // radioButtonPointerCreateStation
            // 
            this.radioButtonPointerCreateStation.AutoSize = true;
            this.radioButtonPointerCreateStation.Location = new System.Drawing.Point(6, 48);
            this.radioButtonPointerCreateStation.Name = "radioButtonPointerCreateStation";
            this.radioButtonPointerCreateStation.Size = new System.Drawing.Size(112, 21);
            this.radioButtonPointerCreateStation.TabIndex = 1;
            this.radioButtonPointerCreateStation.TabStop = true;
            this.radioButtonPointerCreateStation.Text = "Opret aflytter";
            this.radioButtonPointerCreateStation.UseVisualStyleBackColor = true;
            // 
            // radioButtonPointer
            // 
            this.radioButtonPointer.AutoSize = true;
            this.radioButtonPointer.Location = new System.Drawing.Point(6, 21);
            this.radioButtonPointer.Name = "radioButtonPointer";
            this.radioButtonPointer.Size = new System.Drawing.Size(73, 21);
            this.radioButtonPointer.TabIndex = 0;
            this.radioButtonPointer.TabStop = true;
            this.radioButtonPointer.Text = "Markør";
            this.radioButtonPointer.UseVisualStyleBackColor = true;
            // 
            // formsMap1
            // 
            this.formsMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsMap1.Location = new System.Drawing.Point(0, 0);
            this.formsMap1.MapImage = global::LPSView.Properties.Resources._1D81B833202C4B2ABA6EF0CD161CB763_1_1_1;
            this.formsMap1.Name = "formsMap1";
            this.formsMap1.Pan = new System.Drawing.Point(1000, 700);
            this.formsMap1.PixelsPerGridUnitRatio = 9.1617F;
            this.formsMap1.ShowGridZoomThreshold = 1.5F;
            this.formsMap1.Size = new System.Drawing.Size(589, 450);
            this.formsMap1.TabIndex = 0;
            this.formsMap1.ZoomFactor = 2F;
            // 
            // timerPullData
            // 
            this.timerPullData.Interval = 1000;
            this.timerPullData.Tick += new System.EventHandler(this.timerPullData_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // buttonRemoveStations
            // 
            this.buttonRemoveStations.Location = new System.Drawing.Point(109, 89);
            this.buttonRemoveStations.Name = "buttonRemoveStations";
            this.buttonRemoveStations.Size = new System.Drawing.Size(96, 23);
            this.buttonRemoveStations.TabIndex = 6;
            this.buttonRemoveStations.Text = "Slet";
            this.buttonRemoveStations.UseVisualStyleBackColor = true;
            this.buttonRemoveStations.Click += new System.EventHandler(this.buttonRemoveStations_Click);
            // 
            // FormLPSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormLPSView";
            this.Text = "Learnmark Positioning System";
            this.Load += new System.EventHandler(this.FormLPSView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormsMapController.FormsMap formsMap1;
        private System.Windows.Forms.Button buttonConfigure;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonPointerCreateStation;
        private System.Windows.Forms.RadioButton radioButtonPointer;
        private System.Windows.Forms.Button buttonStopDataPull;
        private System.Windows.Forms.Button buttonRefreshData;
        private System.Windows.Forms.Button buttonSaveStations;
        private System.Windows.Forms.Timer timerPullData;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button buttonRemoveDevices;
        private System.Windows.Forms.Button buttonRemoveStations;
    }
}

