using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.General;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{   
    public class ZombieAttacking : MonoBehaviour
    {
        [SerializeField] [Range(1f, 20f)] private float _initialDamage;

        [SerializeField] [Range(1f, 4f)] private float _attackCooldownTime;        

        private float _damage;

        private Timer _attackCooldownTimer;

        void Start()
        {
            _damage = _initialDamage;

            //_attackCooldownTimer = new Timer(_attackCooldownTime);

            _attackCooldownTimer.CountDown = 0f;            
        }

        void Update()
        {
            DecreaseAtackCooldownTimer();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Base" || collision.transform.tag == "Player")
            {
                AttackTarget(collision.gameObject);
            }
        }

        public void ResetZombieAttacking() 
        {
            if (_attackCooldownTimer == null) 
            {
                _attackCooldownTimer = new Timer(_attackCooldownTime);

                _attackCooldownTimer.CountDown = 0f;
            }
            else 
            {
                _attackCooldownTimer.CountDown = 0f;
            }
        }

        private void AttackTarget(GameObject gameObject)
        {
            if (_attackCooldownTimer.TimerFinished) 
            {
                gameObject.GetComponent<ObjectHealth>().ReceiveDamage(_damage);

                _attackCooldownTimer.ResetTimer();
            }
        }

        private void DecreaseAtackCooldownTimer()
        {
            if (!_attackCooldownTimer.TimerFinished)
            {
                _attackCooldownTimer.DecreaseTimer();                
            }
        }        
    }
}
