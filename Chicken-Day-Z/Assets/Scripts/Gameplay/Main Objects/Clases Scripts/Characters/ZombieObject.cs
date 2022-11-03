using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.Characters.Zombie;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{   
    [RequireComponent(typeof(ZombieTarget), typeof(ZombieAttacking), typeof(ZombieMovement))]
    [RequireComponent(typeof(ObjectHealth))]
    public class ZombieObject : CharacterObject
    {
        [SerializeField] private ZombieObjectTypeEnum _defineZombieType;

        private ObjectHealth _objectHealth;
        
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
            _objectHealth = GetComponent<ObjectHealth>();

            _zombieType =_defineZombieType;

            _zombiesTotalInstances += 1;
        }

        void OnEnable()
        {
            _objectHealth.OnHealthReachedZero += DeactivateZombie;

            _zombiesActiveInstances += 1;
        }

        void OnDisable()
        {
            _objectHealth.OnHealthReachedZero -= DeactivateZombie;

            _zombiesActiveInstances -= 1;
        }

        void OnDestroy()
        {
            _zombiesTotalInstances -= 1;
        }

        private ZombieObject() : base(CharacterObjectTypeEnum.ZOMBIE)
        {
            
        }

        void DeactivateZombie() 
        {
            gameObject.SetActive(false);
        }
    }
}