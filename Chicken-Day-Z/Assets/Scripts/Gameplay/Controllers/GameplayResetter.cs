using System;

namespace ChickenDayZ.Gameplay.Controllers 
{
    public class GameplayResetter
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