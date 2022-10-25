using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{   
    public class ZombieObject : CharacterObject
    {
        [SerializeField] private ZombieObjectTypeEnum _defineZombieType;

        private ZombieObjectTypeEnum _zombieType;

        private static short _zombiesTotalInstances = 0;
        
        private static short _zombiesActiveInstances = 0;

        public ZombieObjectTypeEnum ZombieType 
        {
            get 
            {
                return _zombieType;
            }
        }

        public static short ZombiesTotalInstances 
        {
            get 
            {
                return _zombiesTotalInstances;
            }
        }

        public static short ZombiesActiveInstances 
        {
            get
            {
                return _zombiesActiveInstances;
            }
        }

        void Awake()
        {
            _zombieType =_defineZombieType;

            _zombiesTotalInstances += 1;
        }

        void OnEnable()
        {
            _zombiesActiveInstances += 1;
        }

        void OnDisable()
        {
            _zombiesActiveInstances -= 1;
        }

        void OnDestroy()
        {
            _zombiesTotalInstances -= 1;
        }

        private ZombieObject() : base(CharacterObjectTypeEnum.ZOMBIE)
        {
            
        }

        public override void GameplayResset()
        {

        }

        public override void RoundResset()
        {

        }
    }
}