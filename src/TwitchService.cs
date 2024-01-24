using System;
using System.Collections.Generic;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Models;



namespace BizhawkRemotePlay
{
    public class TwitchService : ServiceBase
    {
        private TwitchClient twitch_client;

        private HashSet<string> channels = new HashSet<string>();
        private ServiceKeys keys;



        public TwitchService(IRemotePlayer player, ServiceKeys keys) : base(player)
        {
            twitch_client = new TwitchClient(new WebSocketClient(new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30),
                ClientType = TwitchLib.Communication.Enums.ClientType.Chat
            }));

            twitch_client.OnLog += Twitch_client_OnLog;
            twitch_client.OnMessageReceived += Client_OnMessageReceived;
            twitch_client.OnWhisperReceived += Client_OnWhisperReceived;
            twitch_client.OnConnected += Twitch_client_OnConnected;
            twitch_client.OnDisconnected += Twitch_client_OnDisconnected;
            twitch_client.OnConnectionError += Twitch_client_OnConnectionError;
            this.keys = keys;
        }



        ~TwitchService()
        {
            Disconnect();
        }



        public override void Connect()
        {
            if (twitch_client == null)
                return;

            twitch_client.Initialize(new ConnectionCredentials(keys.TwitchUsername, keys.TwitchToken));
            twitch_client.AutoReListenOnException = true;
            twitch_client.Connect();
        }



        public override void Disconnect()
        {
            if (twitch_client == null)
                return;

            twitch_client.AutoReListenOnException = false;

            try
            {
                twitch_client.Disconnect();
            }
            catch (Exception ex)
            {
                Utility.WriteLine($"Twitch disconnect exception: {ex.Message}");
            }
        }



        public void JoinChannel(string channel)
        {
            var channel_name = channel.ToLower();

            if (channels.Add(channel_name) && twitch_client.IsConnected)
            {
                twitch_client.JoinChannel(channel_name);
            }
        }



        public void LeaveChannel(string channel)
        {
            var channel_name = channel.ToLower();
            
            if (channels.Remove(channel_name) && twitch_client.IsConnected)
            {
                twitch_client.LeaveChannel(channel_name);
            }
        }



        private void Twitch_client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime}: {e.BotUsername} - {e.Data}");
        }



        private void Twitch_client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"Twitch connection error: {e.Error}");
        }



        private void Twitch_client_OnDisconnected(object sender, OnDisconnectedEventArgs e)
        {
            _OnDisconnected();
        }



        private void Twitch_client_OnConnected(object sender, OnConnectedArgs e)
        {
            foreach (string channel in channels)
            {
                twitch_client.JoinChannel(channel);
            }

            _OnConnected();
        }



        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            ProcessMessage(e.WhisperMessage.Message);
        }



        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            ProcessMessage(e.ChatMessage.Message);
        }
    }
}
