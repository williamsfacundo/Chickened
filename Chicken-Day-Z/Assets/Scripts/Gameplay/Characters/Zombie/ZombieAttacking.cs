    using UnityEngine;

using ChickenDayZ.Gameplay.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{   
    public class ZombieAttacking : MonoBehaviour
    {       
        [SerializeField] private float _initialDamage;

        [SerializeField] private float _attackCooldownTime;

        private ZombieTarget _target;

        private ObjectHealth _targetHealth;

        private float _damage;

        private float _attackCooldownTimer;

        private bool _inAttackMode;

        void Awake()
        {
            _target = gameObject.GetComponent<ZombieTarget>();
        }

        void OnEnable()
        {
            _target.OnTargetChanged += UpdateTargetHealth;
        }

        void OnDisable()
        {
            _target.OnTargetChanged -= UpdateTargetHealth;
        }

        void Start()
        {
            _damage = _initialDamage;

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
            if (_target.IsZombieCollidingWithTarget && _attackCooldownTimer <= 0f)
            {
                _inAttackMode = true;
            }
        }

        private void AttackTargetIfIsInAttackMode()
        {
            if (_inAttackMode)
            {
                _targetHealth.ReceiveDamage(_damage);

                _attackCooldownTimer = _attackCooldownTime;

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
            _targetHealth = _target.Target.GetComponent<ObjectHealth>();

            _attackCooldownTimer = 0f;
        }
    }
}
