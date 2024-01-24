using System;
using System.Linq;
using System.Windows.Forms;

namespace BizhawkRemotePlay
{
    public partial class InputProvidersForm : Form
    {
        enum ConnectionState
        {
            NotConnected,
            Connected,
            Connecting
        }

        private TwitchService? twitchService = null;
        private DiscordService? discordService = null;
        private BizhawkRemotePlay _player;

        private ConnectionState connectedToDiscord = ConnectionState.NotConnected;
        private ConnectionState connectedToTwitch = ConnectionState.NotConnected;

        public InputProvidersForm(BizhawkRemotePlay player, IService[] services)
        {
            InitializeComponent();
            _player = player;
            textBox_KeysFilePath.Text = _player.configFile.KeysFilePath;
            checkBox_AutoConnectTwitch.Checked = _player.configFile.AutoLoginTwitch;
            checkBox_AutoConnectDiscord.Checked = _player.configFile.AutoLoginDiscord;

            foreach (IService service in services)
            {
                if (service != null)
                {
                    if (service is TwitchService ts)
                    {
                        SetTwitchService(ts);
                    }
                    else if (service is DiscordService ds)
                    {
                        SetDiscordService(ds);
                    }
                }
            }
        }



        public void InitializeConnections()
        {
            if (_player != null)
            {
                if (_player.configFile.AutoLoginTwitch)
                {
                    ConnectToTwitch();
                }

                if (_player.configFile.AutoLoginDiscord)
                {
                    ConnectToDiscord();
                }
            }
        }



        public void SetTwitchService(TwitchService service)
        {
            twitchService = service;
            twitchService.OnConnected += TwitchService_OnConnected;
            twitchService.OnDisconnected += TwitchService_OnDisconnected;

            foreach (string channel in _player.configFile.TwitchChannels)
            {
                JoinChannel(channel, false);
            }
        }



        private void TwitchService_OnDisconnected()
        {
            if (Visible)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    button_ConnectTwitch.Enabled = true;
                    button_ConnectTwitch.Text = "Connect";
                }));
            }

            connectedToTwitch = ConnectionState.NotConnected;
        }



        private void TwitchService_OnConnected()
        {
            if (Visible)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    button_ConnectTwitch.Enabled = true;
                    button_ConnectTwitch.Text = "Disconnect";
                }));
            }

            connectedToTwitch = ConnectionState.Connected;
        }



        public void SetDiscordService(DiscordService service)
        {
            discordService = service;
            discordService.OnConnected += DiscordService_OnConnected;
            discordService.OnDisconnected += DiscordService_OnDisconnected;

            foreach (string channel in _player.configFile.DiscordChannels)
            {
                Discord_Listen(channel, false);
            }
        }



        private void DiscordService_OnDisconnected()
        {
            if (Visible)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    button_ConnectDiscord.Enabled = true;
                    button_ConnectDiscord.Text = "Connect";
                }));
            }

            connectedToDiscord = ConnectionState.NotConnected;
        }



        private void DiscordService_OnConnected()
        {
            if (Visible)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    button_ConnectDiscord.Enabled = true;
                    button_ConnectDiscord.Text = "Disconnect";
                }));
            }

            connectedToDiscord = ConnectionState.Connected;
        }



        private void InputProvidersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }



        private void button_ConnectTwitch_Click(object sender, EventArgs e)
        {
            if (connectedToTwitch == ConnectionState.NotConnected)
            {
                ConnectToTwitch();
            }
            else if (twitchService != null)
            {
                button_ConnectTwitch.Enabled = false;
                twitchService.Disconnect();
            }
        }



        private void ConnectToTwitch()
        {
            if (twitchService != null && !Disposing)
            {
                if (Visible)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        button_ConnectTwitch.Text = "Connecting...";
                        button_ConnectTwitch.Enabled = false;

                    }));
                }
                twitchService.Connect();
                connectedToTwitch = ConnectionState.Connecting;
            }
        }



        private void ConnectToDiscord()
        {
            if (discordService != null && !Disposing)
            {
                if (Visible)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        button_ConnectDiscord.Text = "Connecting...";
                        button_ConnectDiscord.Enabled = false;
                    }));
                }
                //discordService.ConnectAsync().Wait();
                discordService.Connect();
                connectedToDiscord = ConnectionState.Connecting;
            }
        }



        private void button_JoinChannel_Click(object sender, EventArgs e)
        {
            var channel = textBox_TwitchChannel.Text;

            JoinChannel(channel);
        }



        private void JoinChannel(string channel, bool addToChannels = true)
        {
            var chanLow = channel.ToLower();

            // Exit if we've already joined this channel
            foreach (var item in listBox_JoinedChannels.Items)
            {
                if (listBox_JoinedChannels.GetItemText(item).ToLower().CompareTo(chanLow) == 0)
                {
                    return;
                }
            }

            listBox_JoinedChannels.Items.Add(channel);
            twitchService?.JoinChannel(channel);
            if (addToChannels)
                _player.configFile.TwitchChannels.Add(channel);
        }



        private void button_LeaveChannel_Click(object sender, EventArgs e)
        {
            string[] channels = listBox_JoinedChannels.SelectedItems.OfType<string>().ToArray();

            foreach (string channel in channels)
            {
                LeaveChannel(channel);
            }
        }



        private void LeaveChannel(string channel)
        {
            listBox_JoinedChannels.Items.Remove(channel);
            twitchService?.LeaveChannel(channel);
            _player.configFile.TwitchChannels.Remove(channel);
        }



        private void button_ConnectDiscord_Click(object sender, EventArgs e)
        {
            if (connectedToDiscord == ConnectionState.NotConnected)
            {
                ConnectToDiscord();
            }
            else if (discordService != null)
            {
                button_ConnectDiscord.Enabled = false;
                //discordService.DisconnectAsync().Wait();
                discordService.Disconnect();
            }
        }



        private void button_DiscordLeave_Click(object sender, EventArgs e)
        {
            string[] items = listBox_DiscordChannels.SelectedItems.OfType<string>().ToArray();

            foreach (var item in items)
            {
                Discord_Leave(item);
            }
        }



        private void Discord_Leave(string channel)
        {
            try
            {
                ulong id = ulong.Parse(channel);
                listBox_DiscordChannels.Items.Remove(channel);
                discordService?.IgnoreChannel(id);
                _player.configFile.DiscordChannels.Remove(channel);
            }
            catch
            { }
        }



        private void button_DiscordListen_Click(object sender, EventArgs e)
        {
            string idStr = textBox_DiscordChannelID.Text;

            Discord_Listen(idStr);
        }



        private void Discord_Listen(string channel, bool addToChannels = true)
        {
            try
            {
                ulong id = Convert.ToUInt64(channel);
                if (id > 0 && !listBox_DiscordChannels.Items.Contains(channel))
                {
                    listBox_DiscordChannels.Items.Add(channel);
                    discordService?.ListenToChannel(id);
                    if (addToChannels)
                        _player.configFile.DiscordChannels.Add(channel);
                }
            }
            catch
            { }
        }



        private void checkBox_AutoConnectTwitch_CheckedChanged(object sender, EventArgs e)
        {
            _player.configFile.AutoLoginTwitch = checkBox_AutoConnectTwitch.Checked;
        }



        private void checkBox_AutoConnectDiscord_CheckedChanged(object sender, EventArgs e)
        {
            _player.configFile.AutoLoginDiscord = checkBox_AutoConnectDiscord.Checked;
        }



        private void button_TwitchAuthFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    _player.configFile.KeysFilePath = fileName;
                    textBox_KeysFilePath.Text = fileName;

                    _player.ReloadKeys();
                }
            }
        }


        private string GetButtonString(ConnectionState state)
        {
            switch (state)
            {
                case ConnectionState.Connected:
                    return "Disconnect";
                case ConnectionState.NotConnected:
                    return "Connect";
            }

            return "Connecting...";
        }



        private void InputProvidersForm_Shown(object sender, EventArgs e)
        {
            button_ConnectDiscord.Text = GetButtonString(connectedToDiscord);
            button_ConnectTwitch.Text = GetButtonString(connectedToTwitch);

            button_ConnectDiscord.Enabled = connectedToDiscord != ConnectionState.Connecting;
            button_ConnectTwitch.Enabled = connectedToTwitch != ConnectionState.Connecting;
        }
    }
}
