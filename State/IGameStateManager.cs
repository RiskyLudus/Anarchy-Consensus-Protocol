// Riza "Risky" Resnick

using Anarchy.State;

namespace Anarchy.Networking
{
    public interface IGameStateManager
    {
        void SetInitialState(GameState initialState); // Add this line
        GameState GetCurrentState();
        void ApplyUpdate(PlayerState playerState);
    }
}