using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Chicken.Score;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Characters.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie 
{
    public class ZombieHealth : ObjectHealth
    {
        [SerializeField] private float _pointsGivenWhenDie;
        
        private ChickenScore _chickenScore;             
        
        public static short ZombiesInstances = 0; 

        void Awake()
        {
            _chickenScore = FindObjectOfType<ChickenScore>();           
        }

        private void Start()
        {
            ZombiesInstances++;
        }

        public override void HealthReachedZero()
        {
            _chickenScore?.AddScore(_pointsGivenWhenDie);

            DeactivateZombie();
        }

        public override CharacterTypeEnum GetCharacterType()
        {
            return CharacterTypeEnum.ZOMBIE;
        }

        public void DeactivateZombie() 
        {
            Destroy(gameObject);

            ZombiesInstances--;
        }
    }
}