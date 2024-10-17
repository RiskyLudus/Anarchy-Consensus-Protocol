// Riza "Risky" Resnick

using Anarchy.Connection;
using Anarchy.State;

namespace Anarchy.Networking
{
    public interface INetworkManager
    {
        void Initialize(IGameStateManager stateManager, IPlayerConnectionManager connMgr);
        void SendUpdate(PlayerState playerState);
        void OnPlayerStateReceived(PlayerState playerState); // Ensure this matches
        GameState GetCurrentGameState();
        void SendGameStateToPlayer(string playerId, GameState gameState);
        void NotifyPlayers();
    }
}