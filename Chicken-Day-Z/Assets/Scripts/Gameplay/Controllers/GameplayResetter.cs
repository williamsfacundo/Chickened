using System;

namespace ChickenDayZ.Gameplay.Controllers 
{
    public static class GameplayResetter
    {
        public static event Action OnGameplayReset;

        public static void ResetGameplay()
        {
            if (OnGameplayReset != null) 
            {     
                OnGameplayReset.Invoke();
            }
        }
    }
}