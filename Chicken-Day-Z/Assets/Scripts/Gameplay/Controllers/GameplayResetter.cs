using System;
using UnityEngine;

namespace ChickenDayZ.Gameplay.Controllers 
{
    public class GameplayResetter : MonoBehaviour
    {
        public static event Action OnGameplayReset;

        private void ResetGameplay()
        {
            if (OnGameplayReset != null) 
            {     
                OnGameplayReset.Invoke();
            }
        }
    }
}