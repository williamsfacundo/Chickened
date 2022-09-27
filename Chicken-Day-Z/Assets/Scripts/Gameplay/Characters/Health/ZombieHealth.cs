using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Chicken.Score;

namespace ChickenDayZ.Gameplay.Characters.Health 
{
    public class ZombieHealth : ObjectHealth
    {
        [SerializeField] private float _pointsGivenWhenDie;
        
        private ChickenScore _chickenScore;        

        void Awake()
        {
            _chickenScore = FindObjectOfType<ChickenScore>();
        }

        public override void HealthReachedZero()
        {
            _chickenScore?.AddScore(_pointsGivenWhenDie);
        }
    }
}