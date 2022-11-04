using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Score
{
    public class ChickenScore : MonoBehaviour
    {
        private float _score;

        public event Action  OnScoreChanged;

        public float Score 
        {
            set 
            {
                _score = value;

                OnScoreChanged?.Invoke();
            }
            get 
            {
                return _score;
            }
        }        

        private void Start()
        {
            ResetScore();
        }

        public void ResetScore() 
        {
            Score = 0;            
        }                
    }
}