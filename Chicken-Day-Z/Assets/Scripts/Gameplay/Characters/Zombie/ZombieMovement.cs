using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{    
    public class ZombieMovement : MonoBehaviour
    {
        [SerializeField] private float _zombieMoveVelocity;        

        private Rigidbody2D _rb2D;

        private ZombieTarget _zombieTarget;

        void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();

            _zombieTarget = GetComponent<ZombieTarget>();
        }

        private void Start()
        {
            _rb2D.velocity = Vector2.zero;
        }

        void LateUpdate()
        {
            CounterRigidBody2DForces();
        }

        void FixedUpdate()
        {
            MoveTowardsTheTarget();
        }        

        private void MoveTowardsTheTarget()
        {
            if (!_zombieTarget.IsZombieCollidingWithTarget && _zombieTarget.Target != null)
            {
                _rb2D.MovePosition(gameObject.transform.position +
                    _zombieTarget.CalculateDirectionToMoveTowardsTheTarget() * Time.deltaTime * _zombieMoveVelocity);
            }
        }        

        private void CounterRigidBody2DForces()
        {
            if (_rb2D.velocity != Vector2.zero)
            {
                _rb2D.velocity = Vector2.zero;
            }
        }
    }
}