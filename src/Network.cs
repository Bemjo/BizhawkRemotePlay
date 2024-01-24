using System.Threading.Tasks;
using System.Net.WebSockets;
using System;

namespace BizhawkRemotePlay
{
    public class Network
    {
		private ClientWebSocket? socketConnection = null;
		private Task<WebSocketReceiveResult>? receiveTask = null;
        private Task? connectionTask = null;
		private string url = "";

        public delegate void OnMessage(string msg);
        public delegate void OnConnected();
        public delegate void OnDisconnected();

        public OnMessage OnReceivedMessage { get; } = delegate { };
        public OnConnected OnConnectedToServer { get; } = delegate { };
        public OnDisconnected OnDisconnectedFromServer { get; } = delegate { };



		private void Connect(string url)
        {
            OnConnectedToServer();
        }

		private void Disconnect()
        {
            OnDisconnectedFromServer();
        }



        public void CheckConnection()
        {
            if (socketConnection is null)
            {
                return;
            }

            // If we are trying to connect, monitor the status
            if (!(connectionTask is null))
            {
                // The task has completed, check if it succeeded or failed
                if (connectionTask.IsCompleted)
                {
                    connectionTask = null;

                    // The socket is not connecting or open, so... we failed?
                    if (socketConnection.State != WebSocketState.Connecting || socketConnection.State != WebSocketState.Open)
                    {
                        Disconnected("No Connection");
                    }
                    else
                    {
                        Connected();
                    }
                }
                else if (connectionTask.IsCanceled || connectionTask.IsFaulted)
                {
                    Console.WriteLine($"The connection was cancelled or encountered another fault");
                    Disconnected("Cancelled");
                    connectionTask = null;
                }
            }
            // we are either connected, or disconnected
            else
            {
                // We are connected
                if (socketConnection.State == WebSocketState.Open && !connected)
                {
                    Console.WriteLine($"We are connected to {urlText.Text}");
                    SendMessage($"{{\"connectId\":\"thejollybeardo\"}}");
                    Connected();
                    connected = true;
                }
                // we are disconnected
                else if (socketConnection.State != WebSocketState.Open && connected)
                {
                    Console.WriteLine("We have unexpectedly disconnected");

                    socketConnection.Dispose();
                    receiveTask = null;
                    socketConnection = null;
                    connected = false;

                    if (autoReconnect.Checked)
                    {
                        Connecting("Reconnecting...");
                        socketConnection = new ClientWebSocket();
                        connectionTask = socketConnection.ConnectAsync(new Uri($"ws://{urlText.Text}"), new System.Threading.CancellationToken());
                    }
                    else
                    {
                        Disconnected();
                    }
                }
            }
        }



        private void SendMessage(string msg)
        {
            if (!(socketConnection is null))
            {
                socketConnection.SendAsync(
                    new ArraySegment<byte>(System.Text.Encoding.ASCII.GetBytes(msg)),
                    WebSocketMessageType.Text,
                    true,
                    new System.Threading.CancellationToken());
            }
        }



        private void HandleMessage(string msg)
        {
            if (msg == "PING")
            {
#if DEBUG
                Console.WriteLine($"PING PONG");
#endif
                SendMessage("PONG");
            }
            // A Properly formatted command string is $XX:CMD
            // Where XX is the 2 character command to execute, and CMD is the actual command string
            else if (msg.StartsWith("$"))
            {
#if DEBUG
                Console.WriteLine($"Got Command Message");
#endif
                var i = msg.IndexOf(':');
                // We expect this to be in position 3
                if (i != 3)
                {
#if DEBUG
                    Console.WriteLine($"Invalid format for command. Expected i=3, but i={i}");
#endif
                    return;
                }

                var cmd = msg.Substring(1, i - 1);
                msg = msg.Substring(i + 1);

#if DEBUG
                Console.WriteLine($"Command: [{cmd}], Msg: [{msg}]");
#endif

                switch (cmd)
                {
                    // Status
                    case "ST":
                        string reply;
                        var gameInfo = APIs.GameInfo.GetGameInfo();

                        if (!(gameInfo is null))
                        {
                            reply = $"{{\"SYSTEM\":\"{gameInfo.System}\",\"GAME\":\"{gameInfo.Name}\"}}";
                        }
                        else
                        {
                            reply = $"{{\"SYSTEM\":\"None\",\"GAME\":\"None\"}}";
                        }

                        SendMessage(reply);
                        break;

                    // Buttons
                    case "BT":
                        var btns = new HashSet<string>(msg.Split(';'));

                        if (ValidateButtonString(msg, out List<ButtonSequence> sequence))
                        {
                            PressButtons(sequence);
                        }
                        break;

                    default:
                        Console.WriteLine($"Received Invalid command: [{cmd}] with message [{msg}");
                        break;
                }
            }
#if TRACE
            else
            {
                Console.WriteLine($"Received invalid string: [{msg}]");
            }
#endif
        }
    }
}
