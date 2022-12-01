using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Zombie;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{   
    [RequireComponent(typeof(ZombieAttacking), typeof(ZombieHealth), typeof(ZombiesMovementIA))]
    [RequireComponent(typeof(Animator), typeof(ZombiesColliders))]
    public class ZombieObject : CharacterObject
    {
        [SerializeField] [Range(50, 150)] private short _scoreGivenWhenKilled;

        [SerializeField] private ZombieObjectTypeEnum _defineZombieType;

        private ChickenObject _chickenObject;

        private ZombieHealth _zombieHealth;

        private ZombiesMovementIA _zombiesMovementIA;

        private ZombieAttacking _zombieAttacking;

        private ZombiesColliders _zombiesColliders;

        private Animator _animator;
        
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
            _chickenObject = FindObjectOfType<ChickenObject>();

            _zombieHealth = GetComponent<ZombieHealth>();

            _animator = GetComponent<Animator>();

            _zombiesMovementIA = GetComponent<ZombiesMovementIA>();

            _zombieAttacking = GetComponent<ZombieAttacking>();

            _zombiesColliders = GetComponent<ZombiesColliders>();

            _zombieType =_defineZombieType;

            _zombiesTotalInstances += 1;
        }

        void OnEnable()
        {
            _zombieHealth.OnHealthReachedZero += DeactivateZombie;

            _zombieHealth.OnHealthReachedZero += AddScoreToPlayer;

            _zombiesActiveInstances += 1;
        }

        void OnDisable()
        {
            _zombieHealth.OnHealthReachedZero -= DeactivateZombie;

            _zombieHealth.OnHealthReachedZero -= AddScoreToPlayer;

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
            _animator.SetBool("IsDeath", true);

            _zombiesMovementIA.IsDead = true;

            _zombieAttacking.Damage = 0.0f;

            _zombiesColliders.DisableColliders();
        }

        void AddScoreToPlayer() 
        {
            if (_chickenObject != null) 
            {
                _chickenObject.ChickenScore.Score += _scoreGivenWhenKilled;
            }
        }
    }
}