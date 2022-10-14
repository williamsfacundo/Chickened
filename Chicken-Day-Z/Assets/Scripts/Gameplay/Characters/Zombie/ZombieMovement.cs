using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ZombieMovement : MonoBehaviour
    {
        [SerializeField] private float _zombieMoveVelocity;        

        private Rigidbody2D _rb2D;        

        void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rb2D.velocity = Vector2.zero;
        }

        void Update()
        {
            CounterRigidBody2DForces();
        }

        void FixedUpdate()
        {
            MoveTowardsTheTarget();
        }        

        private void MoveTowardsTheTarget()
        {
            /*if (!_isZombieCollidingWithTarget)
            {
                _rb2D.MovePosition(gameObject.transform.position +
                    CalculateDirectionToMoveTowardsTheTarget() * Time.deltaTime * _zombieMoveVelocity);
            }*/
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