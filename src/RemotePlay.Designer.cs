
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
            this.radio_Chaos = new System.Windows.Forms.RadioButton();
            this.radio_Queue = new System.Windows.Forms.RadioButton();
            this.btn_RemoveAlias = new System.Windows.Forms.Button();
            this.nud_maximumActionTime = new System.Windows.Forms.NumericUpDown();
            this.nud_maximumRepititions = new System.Windows.Forms.NumericUpDown();
            this.nud_pressFramesDefault = new System.Windows.Forms.NumericUpDown();
            this.nud_RepDelay = new System.Windows.Forms.NumericUpDown();
            this.nud_holdFramesDefault = new System.Windows.Forms.NumericUpDown();
            this.btn_ClearBuffer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_QueueSize = new System.Windows.Forms.NumericUpDown();
            this.timeLabelSequenceDelay = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nud_sequenceDelay = new System.Windows.Forms.NumericUpDown();
            this.timeLabelRepeitionDelay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timeLabelHoldFrames = new System.Windows.Forms.Label();
            this.timeLabelPressFrames = new System.Windows.Forms.Label();
            this.timeLabelMaxActFrames = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_Button = new System.Windows.Forms.ComboBox();
            this.buttonAddAlias = new System.Windows.Forms.Button();
            this.tbox_ButtonAlias = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Services = new System.Windows.Forms.Button();
            this.list_Aliases = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.list_Inputs = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_System = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maximumActionTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maximumRepititions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pressFramesDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RepDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_holdFramesDefault)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_QueueSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sequenceDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // radio_Chaos
            // 
            this.radio_Chaos.AutoSize = true;
            this.radio_Chaos.Checked = true;
            this.radio_Chaos.Location = new System.Drawing.Point(9, 165);
            this.radio_Chaos.Name = "radio_Chaos";
            this.radio_Chaos.Size = new System.Drawing.Size(85, 17);
            this.radio_Chaos.TabIndex = 37;
            this.radio_Chaos.TabStop = true;
            this.radio_Chaos.Text = "Chaos Mode";
            this.toolTip1.SetToolTip(this.radio_Chaos, "Incoming inputs are input immediately, and can interrupt other inputs sequences t" +
        "hat are already queued for execution.");
            this.radio_Chaos.UseVisualStyleBackColor = true;
            // 
            // radio_Queue
            // 
            this.radio_Queue.AutoSize = true;
            this.radio_Queue.Location = new System.Drawing.Point(100, 165);
            this.radio_Queue.Name = "radio_Queue";
            this.radio_Queue.Size = new System.Drawing.Size(89, 17);
            this.radio_Queue.TabIndex = 38;
            this.radio_Queue.Text = "Queue Inputs";
            this.toolTip1.SetToolTip(this.radio_Queue, "Queues incoming inputs AFTER all existing sequences that are already waiting, if " +
        "there\'s still room in the queue.");
            this.radio_Queue.UseVisualStyleBackColor = true;
            // 
            // btn_RemoveAlias
            // 
            this.btn_RemoveAlias.Location = new System.Drawing.Point(12, 538);
            this.btn_RemoveAlias.Name = "btn_RemoveAlias";
            this.btn_RemoveAlias.Size = new System.Drawing.Size(119, 23);
            this.btn_RemoveAlias.TabIndex = 42;
            this.btn_RemoveAlias.Text = "Remove Alias";
            this.toolTip1.SetToolTip(this.btn_RemoveAlias, "Select one or more entries from the list to the right, and click this to remove t" +
        "hem.");
            this.btn_RemoveAlias.UseVisualStyleBackColor = true;
            this.btn_RemoveAlias.Click += new System.EventHandler(this.btn_RemoveAlias_Click);
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
            this.toolTip1.SetToolTip(this.nud_maximumActionTime, "The maximum number of frames an entered command is allowed to run for. Any comman" +
        "d that will exist for more than this value is truncated and ignored.");
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
            this.toolTip1.SetToolTip(this.nud_maximumRepititions, "The maximum number of times a button is allowed to repeat in a single command, ca" +
        "n be used to limit abuse.");
            this.nud_maximumRepititions.Value = new decimal(new int[] {
            60,
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
            this.toolTip1.SetToolTip(this.nud_pressFramesDefault, "How many frames a button Press lasts for. A Press is used when the button is Lowe" +
        "rcase.");
            this.nud_pressFramesDefault.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_pressFramesDefault.ValueChanged += new System.EventHandler(this.pressFramesDefault_ValueChanged);
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
            this.toolTip1.SetToolTip(this.nud_RepDelay, "The delay in frames between each button repitition press.");
            this.nud_RepDelay.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nud_RepDelay.ValueChanged += new System.EventHandler(this.nud_RepDelay_ValueChanged);
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
            this.toolTip1.SetToolTip(this.nud_holdFramesDefault, "How many frames a Hold action lasts for. A Hold action is used when the first let" +
        "ter of a button is Capitalized.");
            this.nud_holdFramesDefault.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nud_holdFramesDefault.ValueChanged += new System.EventHandler(this.holdFramesDefault_ValueChanged);
            // 
            // btn_ClearBuffer
            // 
            this.btn_ClearBuffer.Location = new System.Drawing.Point(13, 353);
            this.btn_ClearBuffer.Name = "btn_ClearBuffer";
            this.btn_ClearBuffer.Size = new System.Drawing.Size(118, 23);
            this.btn_ClearBuffer.TabIndex = 47;
            this.btn_ClearBuffer.Text = "Clear Input Buffer";
            this.toolTip1.SetToolTip(this.btn_ClearBuffer, "Clears any pending inputs, and the input queue. Use this if you want to stop what" +
        "ever\'s going on, or if it feels like incoming inputs are NOT being processed any" +
        "more.");
            this.btn_ClearBuffer.UseVisualStyleBackColor = true;
            this.btn_ClearBuffer.Click += new System.EventHandler(this.btn_ClearBuffer_Click);
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
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nud_QueueSize);
            this.groupBox1.Controls.Add(this.radio_Queue);
            this.groupBox1.Controls.Add(this.radio_Chaos);
            this.groupBox1.Controls.Add(this.timeLabelSequenceDelay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nud_sequenceDelay);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 188);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Queue Size";
            // 
            // nud_QueueSize
            // 
            this.nud_QueueSize.Location = new System.Drawing.Point(195, 165);
            this.nud_QueueSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_QueueSize.Name = "nud_QueueSize";
            this.nud_QueueSize.Size = new System.Drawing.Size(80, 20);
            this.nud_QueueSize.TabIndex = 39;
            this.nud_QueueSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_QueueSize.ValueChanged += new System.EventHandler(this.nud_QueueSize_ValueChanged);
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
            10,
            0,
            0,
            0});
            this.nud_sequenceDelay.ValueChanged += new System.EventHandler(this.sequenceDelay_ValueChanged);
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
            // cbox_Button
            // 
            this.cbox_Button.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Button.Enabled = false;
            this.cbox_Button.FormattingEnabled = true;
            this.cbox_Button.Location = new System.Drawing.Point(12, 439);
            this.cbox_Button.Name = "cbox_Button";
            this.cbox_Button.Size = new System.Drawing.Size(119, 21);
            this.cbox_Button.TabIndex = 27;
            // 
            // buttonAddAlias
            // 
            this.buttonAddAlias.Location = new System.Drawing.Point(12, 509);
            this.buttonAddAlias.Name = "buttonAddAlias";
            this.buttonAddAlias.Size = new System.Drawing.Size(119, 23);
            this.buttonAddAlias.TabIndex = 29;
            this.buttonAddAlias.Text = "Add Alias";
            this.buttonAddAlias.UseVisualStyleBackColor = true;
            this.buttonAddAlias.Click += new System.EventHandler(this.buttonAddAlias_Click);
            // 
            // tbox_ButtonAlias
            // 
            this.tbox_ButtonAlias.Location = new System.Drawing.Point(12, 483);
            this.tbox_ButtonAlias.Name = "tbox_ButtonAlias";
            this.tbox_ButtonAlias.Size = new System.Drawing.Size(119, 20);
            this.tbox_ButtonAlias.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Last Inputs";
            // 
            // button_Services
            // 
            this.button_Services.Location = new System.Drawing.Point(9, 12);
            this.button_Services.Name = "button_Services";
            this.button_Services.Size = new System.Drawing.Size(359, 23);
            this.button_Services.TabIndex = 39;
            this.button_Services.Text = "Services";
            this.button_Services.UseVisualStyleBackColor = true;
            this.button_Services.Click += new System.EventHandler(this.button_Services_Click);
            // 
            // list_Aliases
            // 
            this.list_Aliases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.list_Aliases.FullRowSelect = true;
            this.list_Aliases.GridLines = true;
            this.list_Aliases.HideSelection = false;
            this.list_Aliases.Location = new System.Drawing.Point(137, 349);
            this.list_Aliases.Name = "list_Aliases";
            this.list_Aliases.Size = new System.Drawing.Size(231, 212);
            this.list_Aliases.TabIndex = 40;
            this.list_Aliases.UseCompatibleStateImageBehavior = false;
            this.list_Aliases.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Alias";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Button";
            // 
            // list_Inputs
            // 
            this.list_Inputs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.list_Inputs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list_Inputs.HideSelection = false;
            this.list_Inputs.Location = new System.Drawing.Point(12, 57);
            this.list_Inputs.MultiSelect = false;
            this.list_Inputs.Name = "list_Inputs";
            this.list_Inputs.Size = new System.Drawing.Size(356, 95);
            this.list_Inputs.TabIndex = 41;
            this.list_Inputs.UseCompatibleStateImageBehavior = false;
            this.list_Inputs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Service";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sender";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Command";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 423);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "System Button";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 467);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Custom Alias";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 380);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "System:";
            // 
            // label_System
            // 
            this.label_System.AutoSize = true;
            this.label_System.Location = new System.Drawing.Point(62, 380);
            this.label_System.Name = "label_System";
            this.label_System.Size = new System.Drawing.Size(33, 13);
            this.label_System.TabIndex = 46;
            this.label_System.Text = "None";
            // 
            // BizhawkRemotePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 573);
            this.Controls.Add(this.btn_ClearBuffer);
            this.Controls.Add(this.label_System);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_RemoveAlias);
            this.Controls.Add(this.list_Inputs);
            this.Controls.Add(this.list_Aliases);
            this.Controls.Add(this.button_Services);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbox_ButtonAlias);
            this.Controls.Add(this.buttonAddAlias);
            this.Controls.Add(this.cbox_Button);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "BizhawkRemotePlay";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BizhawkRemotePlay_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nud_maximumActionTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maximumRepititions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pressFramesDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RepDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_holdFramesDefault)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_QueueSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sequenceDelay)).EndInit();
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
        private System.Windows.Forms.ComboBox cbox_Button;
        private System.Windows.Forms.Button buttonAddAlias;
        private System.Windows.Forms.TextBox tbox_ButtonAlias;
        private System.Windows.Forms.Label timeLabelRepeitionDelay;
        private System.Windows.Forms.NumericUpDown nud_RepDelay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label timeLabelSequenceDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_sequenceDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Services;
        private System.Windows.Forms.RadioButton radio_Queue;
        private System.Windows.Forms.RadioButton radio_Chaos;
        private System.Windows.Forms.NumericUpDown nud_QueueSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView list_Aliases;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView list_Inputs;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btn_RemoveAlias;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_System;
        private System.Windows.Forms.Button btn_ClearBuffer;
    }
}