using TwitchMonitor.IRC.Types;

namespace TwitchMonitor.IRC.Interfaces
{
    public interface IMessageRelay
    {
        void SendMessage(string message, IrcMessageType type);
    }
}
