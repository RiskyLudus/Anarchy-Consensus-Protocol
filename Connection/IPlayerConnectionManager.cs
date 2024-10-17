// Riza "Risky" Resnick

using System.Collections.Generic;

namespace Anarchy.Connection
{
    public interface IPlayerConnectionManager
    {
        void ConnectPlayer(string playerId);
        void DisconnectPlayer(string playerId);
        IEnumerable<string> GetConnectedPlayers(); // Add this method
    }
}