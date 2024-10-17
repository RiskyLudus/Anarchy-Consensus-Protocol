// Riza "Risky" Resnick

using System.Collections.Generic;
using UnityEngine;

namespace Anarchy.Czars
{
    public class CzarManager : MonoBehaviour, ICzarManager
    {
        private Dictionary<string, string> czarAssignments = new Dictionary<string, string>(); // shardId -> playerId

        public void AssignCzar(string playerId)
        {
            // Logic to assign a Czar for a shard
        }

        public void ReassignCzar(string playerId)
        {
            // Logic to reassign a Czar if the current one disconnects
        }
    }
}