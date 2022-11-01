using System;

namespace ChickenDayZ.Gameplay.Controllers 
{
    public static class GameplayResetter
    {
        public static event Action OnGameplayReset;

        public static event Action OnRoundReset;

        public static void ResetGameplay()
        {
            OnGameplayReset?.Invoke();
        }

        public static void ResetRound()
        {
            OnRoundReset?.Invoke();
        }
    }
}