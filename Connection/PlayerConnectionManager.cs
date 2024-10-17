using System.Collections.Generic;
using UnityEngine;

namespace Anarchy.Connection
{
    public class PlayerConnectionManager : MonoBehaviour, IPlayerConnectionManager
    {
        private HashSet<string> connectedPlayers = new HashSet<string>(); // Using HashSet for unique player IDs

        public void ConnectPlayer(string playerId)
        {
            connectedPlayers.Add(playerId);
            Debug.Log($"Player {playerId} connected.");
        }

        public void DisconnectPlayer(string playerId)
        {
            connectedPlayers.Remove(playerId);
            Debug.Log($"Player {playerId} disconnected.");
        }

        public IEnumerable<string> GetConnectedPlayers() // Implement the method
        {
            return connectedPlayers;
        }
    }
}