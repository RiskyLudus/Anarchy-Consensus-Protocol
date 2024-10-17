using System;
using System.Collections.Generic;
using Anarchy.Networking;
using UnityEngine;

namespace Anarchy.State
{
    public class GameStateManager : MonoBehaviour, IGameStateManager
    {
        private GameState currentGameState;

        public void SetInitialState(GameState initialState)
        {
            currentGameState = initialState;
        }

        public void ApplyUpdate(PlayerState playerState)
        {
            // Example logic to update the game state based on the player's state
            if (playerState != null)
            {
                // Update the current game state based on playerState data
                // For example, update scores or positions
                Debug.Log($"Updating state for player: {playerState.playerId}");
                // Your update logic here
            }
        }

        public GameState GetCurrentState()
        {
            return currentGameState;
        }
    }
}