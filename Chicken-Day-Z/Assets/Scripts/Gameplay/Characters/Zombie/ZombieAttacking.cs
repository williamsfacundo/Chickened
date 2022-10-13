    using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{
    [RequireComponent(typeof(ZombieMovement))]
    public class ZombieAttacking : MonoBehaviour //For now it only attacks the base
    {
        [SerializeField] private float _zombieInitialDamage;

        [SerializeField] private float _zombieAttackCooldownTime;

        private ZombieMovement _zombieMovement;

        private ObjectHealth _objectHealth;

        private float _zombieDamage;

        private float _attackCooldownTimer;

        private bool _inAttackMode;

        void Awake()
        {
            _zombieMovement = gameObject.GetComponent<ZombieMovement>();
        }

        void OnEnable()
        {
            _zombieMovement.OnTargetChanged += UpdateTargetHealth;
        }

        void OnDisable()
        {
            _zombieMovement.OnTargetChanged += UpdateTargetHealth;
        }

        void Start()
        {
            UpdateTargetHealth();

            _zombieDamage = _zombieInitialDamage;

            _attackCooldownTimer = 0f;

            _inAttackMode = false;
        }

        void Update()
        {
            EnterAttackModeIfZombieIsInTarget();

            AttackTargetIfIsInAttackMode();

            DecreaseCooldownTimerIfZombieHasAttacked();
        }

        private void EnterAttackModeIfZombieIsInTarget()
        {
            if (_zombieMovement.IsZombieCollidingWithTarget && _attackCooldownTimer <= 0f)
            {
                _inAttackMode = true;
            }
        }

        private void AttackTargetIfIsInAttackMode()
        {
            if (_inAttackMode)
            {
                _objectHealth.ReceiveDamage(_zombieDamage);

                _attackCooldownTimer = _zombieAttackCooldownTime;

                _inAttackMode = false;
            }
        }

        private void DecreaseCooldownTimerIfZombieHasAttacked()
        {
            if (_attackCooldownTimer > 0f)
            {
                _attackCooldownTimer -= Time.deltaTime;

                if (_attackCooldownTimer < 0f)
                {
                    _attackCooldownTimer = 0f;
                }
            }
        }        

        private void UpdateTargetHealth() 
        {
            _objectHealth = _zombieMovement.Target.GetComponent<ObjectHealth>();
        }
    }
}
