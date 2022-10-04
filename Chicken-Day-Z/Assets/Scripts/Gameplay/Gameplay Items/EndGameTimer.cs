using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.General;

namespace ChickenDayZ.GameplayItems 
{
    public class EndGameTimer : MonoBehaviour
    {        
        [SerializeField] private float _gameplayDuration;       
        
        private Timer _endGameTimer;

        public float Timer 
        {
            get 
            {
                return _endGameTimer.CountDown;
            }
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetTimer;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetTimer;
        }

        void Awake()
        {
            _endGameTimer = new Timer(_gameplayDuration);
        }       

        void Update()
        {
            EndGame();
        }        

        private void EndGame()
        {
            _endGameTimer.DecreaseTimer();

            if (_endGameTimer.CountDown <= 0f)
            {
                GameplayResetter.ResetGameplay();               
            }
        }

        private void ResetTimer() 
        {
            _endGameTimer.ResetTimer();
        }
    }
}