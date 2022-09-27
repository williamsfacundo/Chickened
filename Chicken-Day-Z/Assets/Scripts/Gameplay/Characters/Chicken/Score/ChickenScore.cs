using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Score
{
    public class ChickenScore : MonoBehaviour
    {
        private float _score;

        public float Score 
        {
            get 
            {
                return _score;
            }
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetScore;                        
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetScore;
        }

        private void Start()
        {
            ResetScore();
        }
        public void ResetScore() 
        {
            _score = 0;
        }

        public void AddScore(float value) 
        {
            _score += value;
        }        
    }
}