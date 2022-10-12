using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Chicken.Score;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Characters.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie 
{
    public class ZombieHealth : ObjectHealth //tengo que activar o desactivar los zombies
    {
        [SerializeField] private float _pointsGivenWhenDie;
        
        private ChickenScore _chickenScore;             
        
        public static short ZombiesActiveInstances = 0;

        void OnEnable()
        {
            ZombiesActiveInstances++;
        }

        void OnDisable()
        {
            ZombiesActiveInstances--;
        }

        void Awake()
        {
            _chickenScore = FindObjectOfType<ChickenScore>();           
        }

        void Start()
        {
            ResetObject();            
        }

        public override void HealthReachedZero()
        {
            _chickenScore?.AddScore(_pointsGivenWhenDie);

            gameObject.SetActive(false);
        }

        public override CharacterTypeEnum GetCharacterType()
        {
            return CharacterTypeEnum.ZOMBIE;
        }        
    }
}