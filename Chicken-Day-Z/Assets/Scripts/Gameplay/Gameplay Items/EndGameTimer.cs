using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.GameplayItems 
{
    public class EndGameTimer : MonoBehaviour
    {        
        [SerializeField] private float _gameplayDuration;       

        private float _endGameTimer; //In order not to repeat so many times timer creat a class timer

        public float Timer 
        {
            get 
            {
                return _endGameTimer;
            }
        }

        void Start()
        {
            ResetTimer();
        }

        void Update()
        {
            EndGame();
        }        

        private void EndGame()
        {
            _endGameTimer -= Time.deltaTime;

            if (_endGameTimer <= 0f)
            {
                GameplayResetter.ResetGameplay();               
            }
        }

        private void ResetTimer() 
        {
            _endGameTimer = _gameplayDuration;
        }
    }
}