// Riza "Risky" Resnick

using UnityEngine;
using Anarchy.State;
using Anarchy.Connection;

namespace Anarchy.Networking
{
    public class NetworkingManager : MonoBehaviour, INetworkManager
    {
        private IGameStateManager gameStateManager;
        private IPlayerConnectionManager playerConnectionManager;

        public void Initialize(IGameStateManager stateManager, IPlayerConnectionManager connMgr)
        {
            gameStateManager = stateManager;
            playerConnectionManager = connMgr;
            // Initialize networking and start listening for connections
        }

        public void SendUpdate(PlayerState playerState)
        {
            string jsonData = JsonUtility.ToJson(playerState); // Serialize to JSON
            // Send jsonData over the network
            NotifyPlayers(); // Notify players of the state update
        }

        public void OnPlayerStateReceived(PlayerState playerState) // Ensure method signature matches
        {
            gameStateManager.ApplyUpdate(playerState);
            // Handle received state updates from other players
            NotifyPlayers(); // Notify players after applying the update
        }

        public GameState GetCurrentGameState()
        {
            return gameStateManager.GetCurrentState(); // Implement this in IGameStateManager
        }

        public void SendGameStateToPlayer(string playerId, GameState gameState)
        {
            string jsonData = JsonUtility.ToJson(gameState); // Serialize to JSON
            // Logic to send serialized data to the specific player
        }

        public void NotifyPlayers()
        {
            // Notify all connected players about the state change
            foreach (var playerId in playerConnectionManager.GetConnectedPlayers())
            {
                // Logic to send a notification to each player
                Debug.Log($"Notifying player {playerId} of game state changes.");
                var gameState = gameStateManager.GetCurrentState();
                SendGameStateToPlayer(playerId, gameState);
            }
        }
    }
}
