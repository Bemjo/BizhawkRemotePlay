using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BizhawkRemotePlay
{
    public partial class InputProvidersForm : Form
    {
        enum ConnectionState
        {
            Disconnected,
            Connected,
            Connecting
        }



        private TwitchService? twitchService = null;
        private DiscordService? discordService = null;
        private BizhawkRemotePlay _player;

        private ConnectionState connectedToDiscord = ConnectionState.Disconnected;
        private ConnectionState connectedToTwitch = ConnectionState.Disconnected;



        public InputProvidersForm(BizhawkRemotePlay player, IService[] services)
        {
            InitializeComponent();
            _player = player;

            checkBox_AutoConnectTwitch.Checked = _player.ConfigFile.AutoLoginTwitch;
            checkBox_AutoConnectDiscord.Checked = _player.ConfigFile.AutoLoginDiscord;

            foreach (IService service in services)
            {
                if (service != null)
                {
                    if (service is TwitchService ts)
                    {
                        SetTwitchService(ts);
                        textBoxUsername.Text = _player.ConfigFile.TwitchUsername;
                        textBoxOAuth.Text = _player.ConfigFile.TwitchToken;
                    }
                    else if (service is DiscordService ds)
                    {
                        SetDiscordService(ds);
                        textBoxDiscordToken.Text = _player.ConfigFile.DiscordToken;
                    }
                }
            }
        }



        public void InitializeConnections()
        {
            if (_player != null)
            {
                if (_player.ConfigFile.AutoLoginTwitch)
                {
                    ConnectToTwitch();
                }

                if (_player.ConfigFile.AutoLoginDiscord)
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

            foreach (string channel in _player.ConfigFile.TwitchChannels)
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

            Utility.WriteLine("Disconnected from Twitch");
            connectedToTwitch = ConnectionState.Disconnected;
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

            Utility.WriteLine("Connected to twitch");
            connectedToTwitch = ConnectionState.Connected;
        }



        public void SetDiscordService(DiscordService service)
        {
            discordService = service;
            discordService.OnConnected += DiscordService_OnConnected;
            discordService.OnDisconnected += DiscordService_OnDisconnected;

            foreach (string channel in _player.ConfigFile.DiscordChannels)
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

            Utility.WriteLine("Disconnected from Discord");
            connectedToDiscord = ConnectionState.Disconnected;
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

            Utility.WriteLine("Connected to Discord");
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
            if (connectedToTwitch == ConnectionState.Disconnected)
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
                twitchService.Username = textBoxUsername.Text;
                twitchService.OAuth = textBoxOAuth.Text;

                if (twitchService.Connect())
                {
                    if (Visible)
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            button_ConnectTwitch.Text = "Connecting...";
                            button_ConnectTwitch.Enabled = false;

                        }));
                    }

                    Utility.WriteLine("Connecting to Twitch...");
                    connectedToTwitch = ConnectionState.Connecting;
                }
            }
        }



        private void ConnectToDiscord()
        {
            if (discordService != null && !Disposing)
            {
                discordService.Token = textBoxDiscordToken.Text;

                if (discordService.Connect())
                {
                    if (Visible)
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            button_ConnectDiscord.Text = "Connecting...";
                            button_ConnectDiscord.Enabled = false;
                        }));
                    }

                    Utility.WriteLine("Connecting to Discord...");
                    connectedToDiscord = ConnectionState.Connecting;
                }
            }
        }



        private void button_JoinChannel_Click(object sender, EventArgs e)
        {
            string channel = textBox_TwitchChannel.Text;

            JoinChannel(channel);
        }



        private void JoinChannel(string channel, bool addToChannels = true)
        {
            if (channel.Length <= 3)
            {
                return;
            }

            string chanLow = channel.ToLower();

            // Exit if we've already joined this channel
            foreach (var item in listBox_JoinedChannels.Items)
            {
                if (listBox_JoinedChannels.GetItemText(item).ToLower().CompareTo(chanLow) == 0)
                {
                    return;
                }
            }

            Utility.WriteLine($"Twitch joining Channel: {channel}");

            listBox_JoinedChannels.Items.Add(channel);
            twitchService?.JoinChannel(channel);

            if (addToChannels)
            {
                _player.ConfigFile.TwitchChannels.Add(channel);
            }
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
            Utility.WriteLine($"Twitch Leaving Channel: {channel}");

            listBox_JoinedChannels.Items.Remove(channel);
            twitchService?.LeaveChannel(channel);
            _player.ConfigFile.TwitchChannels.Remove(channel);
        }



        private void button_ConnectDiscord_Click(object sender, EventArgs e)
        {
            if (connectedToDiscord == ConnectionState.Disconnected)
            {
                ConnectToDiscord();
            }
            else if (discordService != null)
            {
                button_ConnectDiscord.Enabled = false;
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
                _player.ConfigFile.DiscordChannels.Remove(channel);
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
                    {
                        _player.ConfigFile.DiscordChannels.Add(channel);
                    }
                }
            }
            catch
            { }
        }



        private void checkBox_AutoConnectTwitch_CheckedChanged(object sender, EventArgs e)
        {
            _player.ConfigFile.AutoLoginTwitch = checkBox_AutoConnectTwitch.Checked;
        }



        private void checkBox_AutoConnectDiscord_CheckedChanged(object sender, EventArgs e)
        {
            _player.ConfigFile.AutoLoginDiscord = checkBox_AutoConnectDiscord.Checked;
        }



        private string GetButtonString(ConnectionState state)
        {
            switch (state)
            {
                case ConnectionState.Connected:
                    return "Disconnect";
                case ConnectionState.Disconnected:
                    return "Connect";
                case ConnectionState.Connecting:
                    return "Connecting...";
            }

            return string.Empty;
        }



        private void InputProvidersForm_Shown(object sender, EventArgs e)
        {
            button_ConnectDiscord.Text = GetButtonString(connectedToDiscord);
            button_ConnectTwitch.Text = GetButtonString(connectedToTwitch);

            button_ConnectDiscord.Enabled = connectedToDiscord != ConnectionState.Connecting;
            button_ConnectTwitch.Enabled = connectedToTwitch != ConnectionState.Connecting;
        }



        private void textBoxDiscordToken_TextChanged(object sender, EventArgs e)
        {
            _player.ConfigFile.DiscordToken = textBoxDiscordToken.Text;
        }



        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            _player.ConfigFile.TwitchUsername = textBoxUsername.Text;
        }



        private void textBoxOAuth_TextChanged(object sender, EventArgs e)
        {
            _player.ConfigFile.TwitchToken = textBoxOAuth.Text;
        }
    }
}
