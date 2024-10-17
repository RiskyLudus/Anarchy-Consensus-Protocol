using System;
using UnityEngine;

namespace Anarchy.State
{
    [Serializable]
    public class PlayerState
    {
        public string playerId;
        public Vector3 position; // Example field, adjust as necessary
        public Quaternion rotation; // Example field, adjust as necessary
        // Add other fields as needed

        public PlayerState(string playerId, Vector3 position, Quaternion rotation)
        {
            this.playerId = playerId;
            this.position = position;
            this.rotation = rotation;
        }

        public PlayerState(string playerId)
        {
            this.playerId = playerId;
            this.position = Vector3.zero;
            this.rotation = Quaternion.identity;
        }
    }
}