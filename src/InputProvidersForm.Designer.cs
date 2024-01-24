namespace BizhawkRemotePlay
{
    partial class InputProvidersForm
    {
        /// <summary>
        private System.ComponentModel.IContainer components = null;

        /// Required designer variable.
        /// </summary>
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
            this.tabControlServices = new System.Windows.Forms.TabControl();
            this.tabPageTwitch = new System.Windows.Forms.TabPage();
            this.labelOAuth = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxOAuth = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.checkBox_AutoConnectTwitch = new System.Windows.Forms.CheckBox();
            this.button_ConnectTwitch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LeaveChannel = new System.Windows.Forms.Button();
            this.button_JoinChannel = new System.Windows.Forms.Button();
            this.textBox_TwitchChannel = new System.Windows.Forms.TextBox();
            this.listBox_JoinedChannels = new System.Windows.Forms.ListBox();
            this.tabPageDiscord = new System.Windows.Forms.TabPage();
            this.textBoxDiscordToken = new System.Windows.Forms.TextBox();
            this.labelDiscordToken = new System.Windows.Forms.Label();
            this.checkBox_AutoConnectDiscord = new System.Windows.Forms.CheckBox();
            this.button_DiscordLeave = new System.Windows.Forms.Button();
            this.listBox_DiscordChannels = new System.Windows.Forms.ListBox();
            this.textBox_DiscordChannelID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_DiscordListen = new System.Windows.Forms.Button();
            this.button_ConnectDiscord = new System.Windows.Forms.Button();
            this.tabControlServices.SuspendLayout();
            this.tabPageTwitch.SuspendLayout();
            this.tabPageDiscord.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlServices
            // 
            this.tabControlServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlServices.Controls.Add(this.tabPageTwitch);
            this.tabControlServices.Controls.Add(this.tabPageDiscord);
            this.tabControlServices.Location = new System.Drawing.Point(12, 12);
            this.tabControlServices.Name = "tabControlServices";
            this.tabControlServices.SelectedIndex = 0;
            this.tabControlServices.Size = new System.Drawing.Size(221, 399);
            this.tabControlServices.TabIndex = 0;
            // 
            // tabPageTwitch
            // 
            this.tabPageTwitch.Controls.Add(this.labelOAuth);
            this.tabPageTwitch.Controls.Add(this.labelName);
            this.tabPageTwitch.Controls.Add(this.textBoxOAuth);
            this.tabPageTwitch.Controls.Add(this.textBoxUsername);
            this.tabPageTwitch.Controls.Add(this.checkBox_AutoConnectTwitch);
            this.tabPageTwitch.Controls.Add(this.button_ConnectTwitch);
            this.tabPageTwitch.Controls.Add(this.label1);
            this.tabPageTwitch.Controls.Add(this.button_LeaveChannel);
            this.tabPageTwitch.Controls.Add(this.button_JoinChannel);
            this.tabPageTwitch.Controls.Add(this.textBox_TwitchChannel);
            this.tabPageTwitch.Controls.Add(this.listBox_JoinedChannels);
            this.tabPageTwitch.Location = new System.Drawing.Point(4, 22);
            this.tabPageTwitch.Name = "tabPageTwitch";
            this.tabPageTwitch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTwitch.Size = new System.Drawing.Size(213, 373);
            this.tabPageTwitch.TabIndex = 0;
            this.tabPageTwitch.Text = "Twitch";
            this.tabPageTwitch.UseVisualStyleBackColor = true;
            // 
            // labelOAuth
            // 
            this.labelOAuth.AutoSize = true;
            this.labelOAuth.Location = new System.Drawing.Point(3, 37);
            this.labelOAuth.Name = "labelOAuth";
            this.labelOAuth.Size = new System.Drawing.Size(40, 13);
            this.labelOAuth.TabIndex = 12;
            this.labelOAuth.Text = "OAuth:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 10);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 11;
            this.labelName.Text = "Name:";
            // 
            // textBoxOAuth
            // 
            this.textBoxOAuth.Location = new System.Drawing.Point(47, 34);
            this.textBoxOAuth.Name = "textBoxOAuth";
            this.textBoxOAuth.PasswordChar = '*';
            this.textBoxOAuth.Size = new System.Drawing.Size(160, 20);
            this.textBoxOAuth.TabIndex = 10;
            this.textBoxOAuth.TextChanged += new System.EventHandler(this.textBoxOAuth_TextChanged);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(47, 7);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(160, 20);
            this.textBoxUsername.TabIndex = 9;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // checkBox_AutoConnectTwitch
            // 
            this.checkBox_AutoConnectTwitch.AutoSize = true;
            this.checkBox_AutoConnectTwitch.Location = new System.Drawing.Point(6, 61);
            this.checkBox_AutoConnectTwitch.Name = "checkBox_AutoConnectTwitch";
            this.checkBox_AutoConnectTwitch.Size = new System.Drawing.Size(133, 17);
            this.checkBox_AutoConnectTwitch.TabIndex = 8;
            this.checkBox_AutoConnectTwitch.Text = "Auto Connect on Load";
            this.checkBox_AutoConnectTwitch.UseVisualStyleBackColor = true;
            this.checkBox_AutoConnectTwitch.CheckedChanged += new System.EventHandler(this.checkBox_AutoConnectTwitch_CheckedChanged);
            // 
            // button_ConnectTwitch
            // 
            this.button_ConnectTwitch.Location = new System.Drawing.Point(6, 81);
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
            this.label1.Location = new System.Drawing.Point(6, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Channel to join";
            // 
            // button_LeaveChannel
            // 
            this.button_LeaveChannel.Location = new System.Drawing.Point(6, 344);
            this.button_LeaveChannel.Name = "button_LeaveChannel";
            this.button_LeaveChannel.Size = new System.Drawing.Size(201, 23);
            this.button_LeaveChannel.TabIndex = 6;
            this.button_LeaveChannel.Text = "Leave Channels";
            this.button_LeaveChannel.UseVisualStyleBackColor = true;
            this.button_LeaveChannel.Click += new System.EventHandler(this.button_LeaveChannel_Click);
            // 
            // button_JoinChannel
            // 
            this.button_JoinChannel.Location = new System.Drawing.Point(6, 149);
            this.button_JoinChannel.Name = "button_JoinChannel";
            this.button_JoinChannel.Size = new System.Drawing.Size(201, 23);
            this.button_JoinChannel.TabIndex = 3;
            this.button_JoinChannel.Text = "Join Channel";
            this.button_JoinChannel.UseVisualStyleBackColor = true;
            this.button_JoinChannel.Click += new System.EventHandler(this.button_JoinChannel_Click);
            // 
            // textBox_TwitchChannel
            // 
            this.textBox_TwitchChannel.Location = new System.Drawing.Point(6, 123);
            this.textBox_TwitchChannel.Name = "textBox_TwitchChannel";
            this.textBox_TwitchChannel.Size = new System.Drawing.Size(201, 20);
            this.textBox_TwitchChannel.TabIndex = 1;
            // 
            // listBox_JoinedChannels
            // 
            this.listBox_JoinedChannels.FormattingEnabled = true;
            this.listBox_JoinedChannels.Location = new System.Drawing.Point(6, 178);
            this.listBox_JoinedChannels.Name = "listBox_JoinedChannels";
            this.listBox_JoinedChannels.ScrollAlwaysVisible = true;
            this.listBox_JoinedChannels.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_JoinedChannels.Size = new System.Drawing.Size(201, 160);
            this.listBox_JoinedChannels.Sorted = true;
            this.listBox_JoinedChannels.TabIndex = 0;
            // 
            // tabPageDiscord
            // 
            this.tabPageDiscord.Controls.Add(this.textBoxDiscordToken);
            this.tabPageDiscord.Controls.Add(this.labelDiscordToken);
            this.tabPageDiscord.Controls.Add(this.checkBox_AutoConnectDiscord);
            this.tabPageDiscord.Controls.Add(this.button_DiscordLeave);
            this.tabPageDiscord.Controls.Add(this.listBox_DiscordChannels);
            this.tabPageDiscord.Controls.Add(this.textBox_DiscordChannelID);
            this.tabPageDiscord.Controls.Add(this.label3);
            this.tabPageDiscord.Controls.Add(this.button_DiscordListen);
            this.tabPageDiscord.Controls.Add(this.button_ConnectDiscord);
            this.tabPageDiscord.Location = new System.Drawing.Point(4, 22);
            this.tabPageDiscord.Name = "tabPageDiscord";
            this.tabPageDiscord.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiscord.Size = new System.Drawing.Size(213, 373);
            this.tabPageDiscord.TabIndex = 1;
            this.tabPageDiscord.Text = "Discord";
            this.tabPageDiscord.UseVisualStyleBackColor = true;
            // 
            // textBoxDiscordToken
            // 
            this.textBoxDiscordToken.Location = new System.Drawing.Point(6, 19);
            this.textBoxDiscordToken.Name = "textBoxDiscordToken";
            this.textBoxDiscordToken.PasswordChar = '*';
            this.textBoxDiscordToken.Size = new System.Drawing.Size(201, 20);
            this.textBoxDiscordToken.TabIndex = 8;
            this.textBoxDiscordToken.TextChanged += new System.EventHandler(this.textBoxDiscordToken_TextChanged);
            // 
            // labelDiscordToken
            // 
            this.labelDiscordToken.AutoSize = true;
            this.labelDiscordToken.Location = new System.Drawing.Point(3, 3);
            this.labelDiscordToken.Name = "labelDiscordToken";
            this.labelDiscordToken.Size = new System.Drawing.Size(96, 13);
            this.labelDiscordToken.TabIndex = 7;
            this.labelDiscordToken.Text = "Discord Bot Token";
            // 
            // checkBox_AutoConnectDiscord
            // 
            this.checkBox_AutoConnectDiscord.AutoSize = true;
            this.checkBox_AutoConnectDiscord.Location = new System.Drawing.Point(6, 45);
            this.checkBox_AutoConnectDiscord.Name = "checkBox_AutoConnectDiscord";
            this.checkBox_AutoConnectDiscord.Size = new System.Drawing.Size(133, 17);
            this.checkBox_AutoConnectDiscord.TabIndex = 6;
            this.checkBox_AutoConnectDiscord.Text = "Auto Connect on Load";
            this.checkBox_AutoConnectDiscord.UseVisualStyleBackColor = true;
            this.checkBox_AutoConnectDiscord.CheckedChanged += new System.EventHandler(this.checkBox_AutoConnectDiscord_CheckedChanged);
            // 
            // button_DiscordLeave
            // 
            this.button_DiscordLeave.Location = new System.Drawing.Point(6, 344);
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
            this.listBox_DiscordChannels.Location = new System.Drawing.Point(6, 165);
            this.listBox_DiscordChannels.Name = "listBox_DiscordChannels";
            this.listBox_DiscordChannels.ScrollAlwaysVisible = true;
            this.listBox_DiscordChannels.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_DiscordChannels.Size = new System.Drawing.Size(201, 173);
            this.listBox_DiscordChannels.TabIndex = 4;
            // 
            // textBox_DiscordChannelID
            // 
            this.textBox_DiscordChannelID.Location = new System.Drawing.Point(6, 110);
            this.textBox_DiscordChannelID.Name = "textBox_DiscordChannelID";
            this.textBox_DiscordChannelID.Size = new System.Drawing.Size(201, 20);
            this.textBox_DiscordChannelID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Channel ID";
            // 
            // button_DiscordListen
            // 
            this.button_DiscordListen.Location = new System.Drawing.Point(6, 136);
            this.button_DiscordListen.Name = "button_DiscordListen";
            this.button_DiscordListen.Size = new System.Drawing.Size(201, 23);
            this.button_DiscordListen.TabIndex = 1;
            this.button_DiscordListen.Text = "Listen to Channel";
            this.button_DiscordListen.UseVisualStyleBackColor = true;
            this.button_DiscordListen.Click += new System.EventHandler(this.button_DiscordListen_Click);
            // 
            // button_ConnectDiscord
            // 
            this.button_ConnectDiscord.Location = new System.Drawing.Point(6, 68);
            this.button_ConnectDiscord.Name = "button_ConnectDiscord";
            this.button_ConnectDiscord.Size = new System.Drawing.Size(201, 23);
            this.button_ConnectDiscord.TabIndex = 0;
            this.button_ConnectDiscord.Text = "Connect";
            this.button_ConnectDiscord.UseVisualStyleBackColor = true;
            this.button_ConnectDiscord.Click += new System.EventHandler(this.button_ConnectDiscord_Click);
            // 
            // InputProvidersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 423);
            this.Controls.Add(this.tabControlServices);
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
            this.tabControlServices.ResumeLayout(false);
            this.tabPageTwitch.ResumeLayout(false);
            this.tabPageTwitch.PerformLayout();
            this.tabPageDiscord.ResumeLayout(false);
            this.tabPageDiscord.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlServices;
        private System.Windows.Forms.TabPage tabPageTwitch;
        private System.Windows.Forms.TabPage tabPageDiscord;
        private System.Windows.Forms.ListBox listBox_JoinedChannels;
        private System.Windows.Forms.TextBox textBox_TwitchChannel;
        private System.Windows.Forms.Button button_JoinChannel;
        private System.Windows.Forms.Button button_ConnectTwitch;
        private System.Windows.Forms.Button button_LeaveChannel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ConnectDiscord;
        private System.Windows.Forms.TextBox textBox_DiscordChannelID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_DiscordListen;
        private System.Windows.Forms.Button button_DiscordLeave;
        private System.Windows.Forms.ListBox listBox_DiscordChannels;
        private System.Windows.Forms.CheckBox checkBox_AutoConnectDiscord;
        private System.Windows.Forms.CheckBox checkBox_AutoConnectTwitch;
        private System.Windows.Forms.Label labelOAuth;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxOAuth;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxDiscordToken;
        private System.Windows.Forms.Label labelDiscordToken;
    }
}