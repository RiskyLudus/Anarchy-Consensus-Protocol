using System.Collections;
using Anarchy.Connection;
using Anarchy.Networking;
using Anarchy.State;
using UnityEngine;

namespace Anarchy
{
    public class Anarchy : MonoBehaviour
    {
        private IGameStateManager gameStateManager;
        private IPlayerConnectionManager playerConnectionManager;
        private INetworkManager networkingManager;

        private void Awake()
        {
            // Set up managers
            gameStateManager = gameObject.AddComponent<GameStateManager>();
            playerConnectionManager = gameObject.AddComponent<PlayerConnectionManager>();
            networkingManager = gameObject.AddComponent<NetworkingManager>();

            // Initialize networking manager with references
            (networkingManager as NetworkingManager).Initialize(gameStateManager, playerConnectionManager);

            // Example of setting an initial game state
            GameState initialState = new GameState(); // You need to define how to initialize this
            gameStateManager.SetInitialState(initialState);
        }

        private void Start()
        {
            // Connect players (this is just a placeholder for actual connection logic)
            ConnectPlayer("Player1");
            ConnectPlayer("Player2");

            // Start the heartbeat monitoring coroutine
            StartCoroutine(HeartbeatCoroutine());
        }

        private void ConnectPlayer(string playerId)
        {
            playerConnectionManager.ConnectPlayer(playerId);
            // Here you might also want to send the initial state to the new player
            PlayerState newPlayerState = new PlayerState(playerId); // Assuming PlayerState has a constructor
            networkingManager.SendUpdate(newPlayerState);
        }

        private IEnumerator HeartbeatCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f); // Adjust frequency as needed
                // Logic to send heartbeat or check for disconnected players
                foreach (var playerId in playerConnectionManager.GetConnectedPlayers())
                {
                    // Check player connection and send heartbeat update
                }
            }
        }

        public void UpdatePlayerState(PlayerState playerState)
        {
            // Update player state and notify others
            gameStateManager.ApplyUpdate(playerState);
            networkingManager.SendUpdate(playerState);
        }
    }
}
