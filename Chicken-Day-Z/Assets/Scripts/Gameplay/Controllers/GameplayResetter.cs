using System;
using UnityEngine;

namespace ChickenDayZ.Gameplay.Controllers 
{
    public class GameplayResetter : MonoBehaviour //No hace falta que sea MonoBehaviour, puede ser una clase static
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