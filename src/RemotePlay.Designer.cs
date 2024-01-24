
namespace BizhawkRemotePlay
{
    partial class BizhawkRemotePlay
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.nud_maximumActionTime = new System.Windows.Forms.NumericUpDown();
            this.nud_maximumRepititions = new System.Windows.Forms.NumericUpDown();
            this.nud_pressFramesDefault = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeLabelSequenceDelay = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nud_sequenceDelay = new System.Windows.Forms.NumericUpDown();
            this.allowQueueSequence = new System.Windows.Forms.CheckBox();
            this.chaosModeEnabled = new System.Windows.Forms.CheckBox();
            this.timeLabelRepeitionDelay = new System.Windows.Forms.Label();
            this.nud_RepDelay = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.timeLabelHoldFrames = new System.Windows.Forms.Label();
            this.timeLabelPressFrames = new System.Windows.Forms.Label();
            this.nud_holdFramesDefault = new System.Windows.Forms.NumericUpDown();
            this.timeLabelMaxActFrames = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSystemButtons = new System.Windows.Forms.ComboBox();
            this.listBoxButtonAlias = new System.Windows.Forms.ListBox();
            this.buttonAddAlias = new System.Windows.Forms.Button();
            this.textBoxAlias = new System.Windows.Forms.TextBox();
            this.inputList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Services = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maximumActionTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maximumRepititions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pressFramesDefault)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sequenceDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RepDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_holdFramesDefault)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Max Repetitions";
            // 
            // nud_maximumActionTime
            // 
            this.nud_maximumActionTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_maximumActionTime.Location = new System.Drawing.Point(95, 14);
            this.nud_maximumActionTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud_maximumActionTime.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_maximumActionTime.Name = "nud_maximumActionTime";
            this.nud_maximumActionTime.Size = new System.Drawing.Size(83, 20);
            this.nud_maximumActionTime.TabIndex = 18;
            this.nud_maximumActionTime.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nud_maximumActionTime.ValueChanged += new System.EventHandler(this.maximumActionTime_ValueChanged);
            // 
            // nud_maximumRepititions
            // 
            this.nud_maximumRepititions.Location = new System.Drawing.Point(95, 117);
            this.nud_maximumRepititions.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_maximumRepititions.Name = "nud_maximumRepititions";
            this.nud_maximumRepititions.Size = new System.Drawing.Size(83, 20);
            this.nud_maximumRepititions.TabIndex = 20;
            this.nud_maximumRepititions.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_maximumRepititions.ValueChanged += new System.EventHandler(this.maximumRepititions_ValueChanged);
            // 
            // nud_pressFramesDefault
            // 
            this.nud_pressFramesDefault.Location = new System.Drawing.Point(95, 39);
            this.nud_pressFramesDefault.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_pressFramesDefault.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_pressFramesDefault.Name = "nud_pressFramesDefault";
            this.nud_pressFramesDefault.Size = new System.Drawing.Size(83, 20);
            this.nud_pressFramesDefault.TabIndex = 22;
            this.nud_pressFramesDefault.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_pressFramesDefault.ValueChanged += new System.EventHandler(this.pressFramesDefault_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Max Act Frames";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Press Frames";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeLabelSequenceDelay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nud_sequenceDelay);
            this.groupBox1.Controls.Add(this.allowQueueSequence);
            this.groupBox1.Controls.Add(this.chaosModeEnabled);
            this.groupBox1.Controls.Add(this.timeLabelRepeitionDelay);
            this.groupBox1.Controls.Add(this.nud_RepDelay);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.timeLabelHoldFrames);
            this.groupBox1.Controls.Add(this.timeLabelPressFrames);
            this.groupBox1.Controls.Add(this.nud_maximumRepititions);
            this.groupBox1.Controls.Add(this.nud_holdFramesDefault);
            this.groupBox1.Controls.Add(this.timeLabelMaxActFrames);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nud_pressFramesDefault);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nud_maximumActionTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 222);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // timeLabelSequenceDelay
            // 
            this.timeLabelSequenceDelay.AutoSize = true;
            this.timeLabelSequenceDelay.Location = new System.Drawing.Point(184, 145);
            this.timeLabelSequenceDelay.Name = "timeLabelSequenceDelay";
            this.timeLabelSequenceDelay.Size = new System.Drawing.Size(144, 13);
            this.timeLabelSequenceDelay.TabIndex = 36;
            this.timeLabelSequenceDelay.Text = "Sequence Delay Frame Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Sequence Delay";
            // 
            // nud_sequenceDelay
            // 
            this.nud_sequenceDelay.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_sequenceDelay.Location = new System.Drawing.Point(95, 143);
            this.nud_sequenceDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_sequenceDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_sequenceDelay.Name = "nud_sequenceDelay";
            this.nud_sequenceDelay.Size = new System.Drawing.Size(83, 20);
            this.nud_sequenceDelay.TabIndex = 34;
            this.nud_sequenceDelay.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_sequenceDelay.ValueChanged += new System.EventHandler(this.sequenceDelay_ValueChanged);
            // 
            // allowQueueSequence
            // 
            this.allowQueueSequence.AutoSize = true;
            this.allowQueueSequence.Checked = true;
            this.allowQueueSequence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowQueueSequence.Location = new System.Drawing.Point(95, 199);
            this.allowQueueSequence.Name = "allowQueueSequence";
            this.allowQueueSequence.Size = new System.Drawing.Size(115, 17);
            this.allowQueueSequence.TabIndex = 33;
            this.allowQueueSequence.Text = "Queue Sequences";
            this.allowQueueSequence.UseVisualStyleBackColor = true;
            // 
            // chaosModeEnabled
            // 
            this.chaosModeEnabled.AutoSize = true;
            this.chaosModeEnabled.Location = new System.Drawing.Point(9, 199);
            this.chaosModeEnabled.Name = "chaosModeEnabled";
            this.chaosModeEnabled.Size = new System.Drawing.Size(86, 17);
            this.chaosModeEnabled.TabIndex = 32;
            this.chaosModeEnabled.Text = "Chaos Mode";
            this.chaosModeEnabled.UseVisualStyleBackColor = true;
            // 
            // timeLabelRepeitionDelay
            // 
            this.timeLabelRepeitionDelay.AutoSize = true;
            this.timeLabelRepeitionDelay.Location = new System.Drawing.Point(184, 93);
            this.timeLabelRepeitionDelay.Name = "timeLabelRepeitionDelay";
            this.timeLabelRepeitionDelay.Size = new System.Drawing.Size(143, 13);
            this.timeLabelRepeitionDelay.TabIndex = 31;
            this.timeLabelRepeitionDelay.Text = "Repetition Delay Frame Time";
            // 
            // nud_RepDelay
            // 
            this.nud_RepDelay.Location = new System.Drawing.Point(95, 91);
            this.nud_RepDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_RepDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_RepDelay.Name = "nud_RepDelay";
            this.nud_RepDelay.Size = new System.Drawing.Size(83, 20);
            this.nud_RepDelay.TabIndex = 30;
            this.nud_RepDelay.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_RepDelay.ValueChanged += new System.EventHandler(this.nud_RepDelay_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Repetition Delay";
            // 
            // timeLabelHoldFrames
            // 
            this.timeLabelHoldFrames.AutoSize = true;
            this.timeLabelHoldFrames.Location = new System.Drawing.Point(184, 67);
            this.timeLabelHoldFrames.Name = "timeLabelHoldFrames";
            this.timeLabelHoldFrames.Size = new System.Drawing.Size(87, 13);
            this.timeLabelHoldFrames.TabIndex = 27;
            this.timeLabelHoldFrames.Text = "Hold Frame Time";
            // 
            // timeLabelPressFrames
            // 
            this.timeLabelPressFrames.AutoSize = true;
            this.timeLabelPressFrames.Location = new System.Drawing.Point(184, 41);
            this.timeLabelPressFrames.Name = "timeLabelPressFrames";
            this.timeLabelPressFrames.Size = new System.Drawing.Size(91, 13);
            this.timeLabelPressFrames.TabIndex = 28;
            this.timeLabelPressFrames.Text = "Press Frame Time";
            // 
            // nud_holdFramesDefault
            // 
            this.nud_holdFramesDefault.Location = new System.Drawing.Point(95, 65);
            this.nud_holdFramesDefault.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_holdFramesDefault.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_holdFramesDefault.Name = "nud_holdFramesDefault";
            this.nud_holdFramesDefault.Size = new System.Drawing.Size(83, 20);
            this.nud_holdFramesDefault.TabIndex = 27;
            this.nud_holdFramesDefault.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nud_holdFramesDefault.ValueChanged += new System.EventHandler(this.holdFramesDefault_ValueChanged);
            // 
            // timeLabelMaxActFrames
            // 
            this.timeLabelMaxActFrames.AutoSize = true;
            this.timeLabelMaxActFrames.Location = new System.Drawing.Point(184, 16);
            this.timeLabelMaxActFrames.Name = "timeLabelMaxActFrames";
            this.timeLabelMaxActFrames.Size = new System.Drawing.Size(104, 13);
            this.timeLabelMaxActFrames.TabIndex = 21;
            this.timeLabelMaxActFrames.Text = "Max Act Frame Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Hold Frames";
            // 
            // comboBoxSystemButtons
            // 
            this.comboBoxSystemButtons.FormattingEnabled = true;
            this.comboBoxSystemButtons.Location = new System.Drawing.Point(10, 362);
            this.comboBoxSystemButtons.Name = "comboBoxSystemButtons";
            this.comboBoxSystemButtons.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSystemButtons.TabIndex = 27;
            // 
            // listBoxButtonAlias
            // 
            this.listBoxButtonAlias.FormattingEnabled = true;
            this.listBoxButtonAlias.Location = new System.Drawing.Point(144, 362);
            this.listBoxButtonAlias.Name = "listBoxButtonAlias";
            this.listBoxButtonAlias.Size = new System.Drawing.Size(224, 212);
            this.listBoxButtonAlias.TabIndex = 28;
            // 
            // buttonAddAlias
            // 
            this.buttonAddAlias.Location = new System.Drawing.Point(9, 418);
            this.buttonAddAlias.Name = "buttonAddAlias";
            this.buttonAddAlias.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAlias.TabIndex = 29;
            this.buttonAddAlias.Text = "Add Alias";
            this.buttonAddAlias.UseVisualStyleBackColor = true;
            // 
            // textBoxAlias
            // 
            this.textBoxAlias.Location = new System.Drawing.Point(10, 389);
            this.textBoxAlias.Name = "textBoxAlias";
            this.textBoxAlias.Size = new System.Drawing.Size(120, 20);
            this.textBoxAlias.TabIndex = 30;
            // 
            // inputList
            // 
            this.inputList.FormattingEnabled = true;
            this.inputList.Location = new System.Drawing.Point(137, 25);
            this.inputList.Name = "inputList";
            this.inputList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.inputList.Size = new System.Drawing.Size(231, 95);
            this.inputList.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Last Inputs";
            // 
            // button_Services
            // 
            this.button_Services.Location = new System.Drawing.Point(12, 25);
            this.button_Services.Name = "button_Services";
            this.button_Services.Size = new System.Drawing.Size(116, 23);
            this.button_Services.TabIndex = 39;
            this.button_Services.Text = "Services";
            this.button_Services.UseVisualStyleBackColor = true;
            this.button_Services.Click += new System.EventHandler(this.button_Services_Click);
            // 
            // BizhawkRemotePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 582);
            this.Controls.Add(this.button_Services);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputList);
            this.Controls.Add(this.textBoxAlias);
            this.Controls.Add(this.buttonAddAlias);
            this.Controls.Add(this.listBoxButtonAlias);
            this.Controls.Add(this.comboBoxSystemButtons);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "BizhawkRemotePlay";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BizhawkRemotePlay_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nud_maximumActionTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maximumRepititions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pressFramesDefault)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sequenceDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RepDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_holdFramesDefault)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_maximumActionTime;
        private System.Windows.Forms.NumericUpDown nud_maximumRepititions;
        private System.Windows.Forms.NumericUpDown nud_pressFramesDefault;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label timeLabelHoldFrames;
        private System.Windows.Forms.Label timeLabelPressFrames;
        private System.Windows.Forms.NumericUpDown nud_holdFramesDefault;
        private System.Windows.Forms.Label timeLabelMaxActFrames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSystemButtons;
        private System.Windows.Forms.ListBox listBoxButtonAlias;
        private System.Windows.Forms.Button buttonAddAlias;
        private System.Windows.Forms.TextBox textBoxAlias;
        private System.Windows.Forms.Label timeLabelRepeitionDelay;
        private System.Windows.Forms.NumericUpDown nud_RepDelay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chaosModeEnabled;
        private System.Windows.Forms.CheckBox allowQueueSequence;
        private System.Windows.Forms.Label timeLabelSequenceDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_sequenceDelay;
        private System.Windows.Forms.ListBox inputList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Services;
    }
}