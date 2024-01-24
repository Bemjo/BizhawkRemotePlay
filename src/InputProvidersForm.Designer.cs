namespace BizhawkRemotePlay
{
    partial class InputProvidersForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox_AutoConnectTwitch = new System.Windows.Forms.CheckBox();
            this.button_ConnectTwitch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LeaveChannel = new System.Windows.Forms.Button();
            this.button_JoinChannel = new System.Windows.Forms.Button();
            this.textBox_TwitchChannel = new System.Windows.Forms.TextBox();
            this.listBox_JoinedChannels = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox_AutoConnectDiscord = new System.Windows.Forms.CheckBox();
            this.button_DiscordLeave = new System.Windows.Forms.Button();
            this.listBox_DiscordChannels = new System.Windows.Forms.ListBox();
            this.textBox_DiscordChannelID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_DiscordListen = new System.Windows.Forms.Button();
            this.button_ConnectDiscord = new System.Windows.Forms.Button();
            this.button_TwitchAuthFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_KeysFilePath = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(221, 344);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox_AutoConnectTwitch);
            this.tabPage1.Controls.Add(this.button_ConnectTwitch);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button_LeaveChannel);
            this.tabPage1.Controls.Add(this.button_JoinChannel);
            this.tabPage1.Controls.Add(this.textBox_TwitchChannel);
            this.tabPage1.Controls.Add(this.listBox_JoinedChannels);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(213, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Twitch";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox_AutoConnectTwitch
            // 
            this.checkBox_AutoConnectTwitch.AutoSize = true;
            this.checkBox_AutoConnectTwitch.Location = new System.Drawing.Point(6, 6);
            this.checkBox_AutoConnectTwitch.Name = "checkBox_AutoConnectTwitch";
            this.checkBox_AutoConnectTwitch.Size = new System.Drawing.Size(133, 17);
            this.checkBox_AutoConnectTwitch.TabIndex = 8;
            this.checkBox_AutoConnectTwitch.Text = "Auto Connect on Load";
            this.checkBox_AutoConnectTwitch.UseVisualStyleBackColor = true;
            this.checkBox_AutoConnectTwitch.CheckedChanged += new System.EventHandler(this.checkBox_AutoConnectTwitch_CheckedChanged);
            // 
            // button_ConnectTwitch
            // 
            this.button_ConnectTwitch.Location = new System.Drawing.Point(6, 26);
            this.button_ConnectTwitch.Name = "button_ConnectTwitch";
            this.button_ConnectTwitch.Size = new System.Drawing.Size(201, 23);
            this.button_ConnectTwitch.TabIndex = 2;
            this.button_ConnectTwitch.Text = "Connect";
            this.button_ConnectTwitch.UseVisualStyleBackColor = true;
            this.button_ConnectTwitch.Click += new System.EventHandler(this.button_ConnectTwitch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Channel to join";
            // 
            // button_LeaveChannel
            // 
            this.button_LeaveChannel.Location = new System.Drawing.Point(6, 289);
            this.button_LeaveChannel.Name = "button_LeaveChannel";
            this.button_LeaveChannel.Size = new System.Drawing.Size(201, 23);
            this.button_LeaveChannel.TabIndex = 6;
            this.button_LeaveChannel.Text = "Leave Channels";
            this.button_LeaveChannel.UseVisualStyleBackColor = true;
            this.button_LeaveChannel.Click += new System.EventHandler(this.button_LeaveChannel_Click);
            // 
            // button_JoinChannel
            // 
            this.button_JoinChannel.Location = new System.Drawing.Point(6, 94);
            this.button_JoinChannel.Name = "button_JoinChannel";
            this.button_JoinChannel.Size = new System.Drawing.Size(201, 23);
            this.button_JoinChannel.TabIndex = 3;
            this.button_JoinChannel.Text = "Join Channel";
            this.button_JoinChannel.UseVisualStyleBackColor = true;
            this.button_JoinChannel.Click += new System.EventHandler(this.button_JoinChannel_Click);
            // 
            // textBox_TwitchChannel
            // 
            this.textBox_TwitchChannel.Location = new System.Drawing.Point(6, 68);
            this.textBox_TwitchChannel.Name = "textBox_TwitchChannel";
            this.textBox_TwitchChannel.Size = new System.Drawing.Size(201, 20);
            this.textBox_TwitchChannel.TabIndex = 1;
            // 
            // listBox_JoinedChannels
            // 
            this.listBox_JoinedChannels.FormattingEnabled = true;
            this.listBox_JoinedChannels.Location = new System.Drawing.Point(6, 123);
            this.listBox_JoinedChannels.Name = "listBox_JoinedChannels";
            this.listBox_JoinedChannels.ScrollAlwaysVisible = true;
            this.listBox_JoinedChannels.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_JoinedChannels.Size = new System.Drawing.Size(201, 160);
            this.listBox_JoinedChannels.Sorted = true;
            this.listBox_JoinedChannels.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox_AutoConnectDiscord);
            this.tabPage2.Controls.Add(this.button_DiscordLeave);
            this.tabPage2.Controls.Add(this.listBox_DiscordChannels);
            this.tabPage2.Controls.Add(this.textBox_DiscordChannelID);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button_DiscordListen);
            this.tabPage2.Controls.Add(this.button_ConnectDiscord);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(213, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Discord";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox_AutoConnectDiscord
            // 
            this.checkBox_AutoConnectDiscord.AutoSize = true;
            this.checkBox_AutoConnectDiscord.Location = new System.Drawing.Point(6, 6);
            this.checkBox_AutoConnectDiscord.Name = "checkBox_AutoConnectDiscord";
            this.checkBox_AutoConnectDiscord.Size = new System.Drawing.Size(133, 17);
            this.checkBox_AutoConnectDiscord.TabIndex = 6;
            this.checkBox_AutoConnectDiscord.Text = "Auto Connect on Load";
            this.checkBox_AutoConnectDiscord.UseVisualStyleBackColor = true;
            this.checkBox_AutoConnectDiscord.CheckedChanged += new System.EventHandler(this.checkBox_AutoConnectDiscord_CheckedChanged);
            // 
            // button_DiscordLeave
            // 
            this.button_DiscordLeave.Location = new System.Drawing.Point(6, 289);
            this.button_DiscordLeave.Name = "button_DiscordLeave";
            this.button_DiscordLeave.Size = new System.Drawing.Size(201, 23);
            this.button_DiscordLeave.TabIndex = 5;
            this.button_DiscordLeave.Text = "Ignore Channels";
            this.button_DiscordLeave.UseVisualStyleBackColor = true;
            this.button_DiscordLeave.Click += new System.EventHandler(this.button_DiscordLeave_Click);
            // 
            // listBox_DiscordChannels
            // 
            this.listBox_DiscordChannels.FormattingEnabled = true;
            this.listBox_DiscordChannels.Location = new System.Drawing.Point(6, 123);
            this.listBox_DiscordChannels.Name = "listBox_DiscordChannels";
            this.listBox_DiscordChannels.ScrollAlwaysVisible = true;
            this.listBox_DiscordChannels.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_DiscordChannels.Size = new System.Drawing.Size(201, 160);
            this.listBox_DiscordChannels.TabIndex = 4;
            // 
            // textBox_DiscordChannelID
            // 
            this.textBox_DiscordChannelID.Location = new System.Drawing.Point(6, 68);
            this.textBox_DiscordChannelID.Name = "textBox_DiscordChannelID";
            this.textBox_DiscordChannelID.Size = new System.Drawing.Size(201, 20);
            this.textBox_DiscordChannelID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Channel ID";
            // 
            // button_DiscordListen
            // 
            this.button_DiscordListen.Location = new System.Drawing.Point(6, 94);
            this.button_DiscordListen.Name = "button_DiscordListen";
            this.button_DiscordListen.Size = new System.Drawing.Size(201, 23);
            this.button_DiscordListen.TabIndex = 1;
            this.button_DiscordListen.Text = "Listen to Channel";
            this.button_DiscordListen.UseVisualStyleBackColor = true;
            this.button_DiscordListen.Click += new System.EventHandler(this.button_DiscordListen_Click);
            // 
            // button_ConnectDiscord
            // 
            this.button_ConnectDiscord.Location = new System.Drawing.Point(6, 26);
            this.button_ConnectDiscord.Name = "button_ConnectDiscord";
            this.button_ConnectDiscord.Size = new System.Drawing.Size(201, 23);
            this.button_ConnectDiscord.TabIndex = 0;
            this.button_ConnectDiscord.Text = "Connect";
            this.button_ConnectDiscord.UseVisualStyleBackColor = true;
            this.button_ConnectDiscord.Click += new System.EventHandler(this.button_ConnectDiscord_Click);
            // 
            // button_TwitchAuthFile
            // 
            this.button_TwitchAuthFile.Location = new System.Drawing.Point(12, 12);
            this.button_TwitchAuthFile.Name = "button_TwitchAuthFile";
            this.button_TwitchAuthFile.Size = new System.Drawing.Size(221, 23);
            this.button_TwitchAuthFile.TabIndex = 4;
            this.button_TwitchAuthFile.Text = "Find Auth Keys File";
            this.button_TwitchAuthFile.UseVisualStyleBackColor = true;
            this.button_TwitchAuthFile.Click += new System.EventHandler(this.button_TwitchAuthFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "File:";
            // 
            // textBox_KeysFilePath
            // 
            this.textBox_KeysFilePath.Location = new System.Drawing.Point(45, 41);
            this.textBox_KeysFilePath.Name = "textBox_KeysFilePath";
            this.textBox_KeysFilePath.Size = new System.Drawing.Size(188, 20);
            this.textBox_KeysFilePath.TabIndex = 9;
            // 
            // InputProvidersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 423);
            this.Controls.Add(this.textBox_KeysFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_TwitchAuthFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputProvidersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Input Providers";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputProvidersForm_FormClosing);
            this.Shown += new System.EventHandler(this.InputProvidersForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox_JoinedChannels;
        private System.Windows.Forms.TextBox textBox_TwitchChannel;
        private System.Windows.Forms.Button button_JoinChannel;
        private System.Windows.Forms.Button button_ConnectTwitch;
        private System.Windows.Forms.Button button_TwitchAuthFile;
        private System.Windows.Forms.Button button_LeaveChannel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ConnectDiscord;
        private System.Windows.Forms.TextBox textBox_KeysFilePath;
        private System.Windows.Forms.TextBox textBox_DiscordChannelID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_DiscordListen;
        private System.Windows.Forms.Button button_DiscordLeave;
        private System.Windows.Forms.ListBox listBox_DiscordChannels;
        private System.Windows.Forms.CheckBox checkBox_AutoConnectDiscord;
        private System.Windows.Forms.CheckBox checkBox_AutoConnectTwitch;
    }
}