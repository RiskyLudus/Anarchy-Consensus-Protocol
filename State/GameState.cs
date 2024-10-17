// Riza "Risky" Resnick

using UnityEngine;
using System.Collections.Generic;

namespace Anarchy.State
{
    [System.Serializable]
    public class GameState
    {
        public List<PlayerState> playerStates = new List<PlayerState>();
    }
}