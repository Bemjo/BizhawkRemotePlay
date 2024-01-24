using System.Threading.Tasks;

namespace BizhawkRemotePlay
{
    public delegate void ConnectionNotice();

    /// <summary>
    /// The public interface for a Service
    /// Handles connecting and disconnecting from the service
    /// </summary>
    public interface IService
    {
        bool Connect();
        void Disconnect();
    }



    /// <summary>
    /// The protected interface for a Service
    /// </summary>
    public abstract class ServiceBase : IService
    {
        /// <summary>
        /// Invoked
        /// </summary>
        public event ConnectionNotice? OnConnected;
        public event ConnectionNotice? OnDisconnected;

        private IRemotePlayer _player;

        protected ServiceBase(IRemotePlayer player)
        {
            _player = player;
        }


        /// <summary>
        /// Processes the message parsed by the service
        /// This must be called be the service implementation after parsing the message
        /// </summary>
        /// <param name="message"></param>
        protected void ProcessMessage(string message)
        {
            string prefix = _player.CommandPrefix(message);

            _player.HandleMessage($"{prefix}:{message}");
        }

        /// <summary>
        /// Synchronous Connection
        /// </summary>
        public virtual bool Connect() { return false; }

        /// <summary>
        /// Synchronos Disconnection
        /// </summary>
        public virtual void Disconnect() { }

        protected void _OnConnected() { OnConnected?.Invoke(); }
        protected void _OnDisconnected() { OnDisconnected?.Invoke(); }
    }
}
