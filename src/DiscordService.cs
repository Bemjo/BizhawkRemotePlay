using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Nito.AsyncEx;


namespace BizhawkRemotePlay
{
    public class DiscordService : ServiceBase
    {
        private DiscordSocketClient discordClient;
        public string Token = string.Empty;
        public HashSet<ulong> listenChannels = new HashSet<ulong>();
        AsyncContextThread contextThread = new AsyncContextThread();



        public DiscordService(IRemotePlayer player) : base(player)
        {
            discordClient = new DiscordSocketClient(new DiscordSocketConfig()
            {
                GatewayIntents = Discord.GatewayIntents.AllUnprivileged |
                                Discord.GatewayIntents.MessageContent
            });

            discordClient.Log += discordClient_Log;
            discordClient.Connected += discordClient_Connected;
            discordClient.Disconnected += discordClient_Disconnected;
            discordClient.MessageReceived += discordClient_MessageReceived;
        }



        ~DiscordService()
        {
            discordClient.Connected -= discordClient_Connected;
            discordClient.MessageReceived -= discordClient_MessageReceived;
            discordClient.Disconnected -= discordClient_Disconnected;
            Disconnect();
        }



        private Task discordClient_Log(Discord.LogMessage message)
        {
            if (message.Exception is Exception ex)
            {
                Utility.WriteLine(ex);
            }
            else
            {
                Utility.WriteLine($"[General/{message.Severity}] {message}");
            }

            return Task.CompletedTask;
        }



        private Task discordClient_MessageReceived(SocketMessage message)
        {
            if (listenChannels.Contains(message.Channel.Id))
            {
                string content = message.CleanContent;
                Utility.WriteLine(content);
                ProcessMessage("discord", message.Author.GlobalName, content);
            }

            return Task.CompletedTask;
        }



        private Task discordClient_Disconnected(Exception arg)
        {
            _OnDisconnected();
            return Task.CompletedTask;
        }



        private Task discordClient_Connected()
        {
            _OnConnected();
            return Task.CompletedTask;
        }



        public void ListenToChannel(ulong id)
        {
            listenChannels.Add(id);
        }

        

        public void IgnoreChannel(ulong id)
        {
            listenChannels.Remove(id);
        }



        public override bool Connect()
        {
            if (Token.Length <= 0)
            {
                return false;
            }

            contextThread.Factory.Run(async Task () =>
            {
                await discordClient.LoginAsync(Discord.TokenType.Bot, Token);
                await discordClient.StartAsync();
            });

            return true;
        }



        public override void Disconnect()
        {
            contextThread.Factory.Run(async Task () =>
            {
                await discordClient.LogoutAsync();
                await discordClient.StopAsync();
            });
        }
    }
}
