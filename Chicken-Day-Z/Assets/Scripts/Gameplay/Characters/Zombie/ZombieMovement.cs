using System;
using UnityEngine;

using ChickenDayZ.Gameplay.EggBase;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ZombieMovement : MonoBehaviour
    {
        [SerializeField] private float _zombieMoveVelocity;

        private GameObject _target;

        private Rigidbody2D _rb2D;

        private bool _isZombieCollidingWithTarget;

        public event Action OnTargetChanged;  

        public GameObject Target
        {
            set 
            {
                _target = value;

                OnTargetChanged?.Invoke();
            }
            get
            {
                return _target;
            }
        }

        public bool IsZombieCollidingWithTarget
        {
            get
            {
                return _isZombieCollidingWithTarget;
            }
        }

        void Awake()
        {
            _target = FindObjectOfType<EggBaseHealth>().gameObject;

            _rb2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _isZombieCollidingWithTarget = false;

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

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Base")
            {
                _isZombieCollidingWithTarget = true;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.tag == "Base")
            {
                _isZombieCollidingWithTarget = false;
            }
        }

        private void MoveTowardsTheTarget()
        {
            if (!_isZombieCollidingWithTarget)
            {
                _rb2D.MovePosition(gameObject.transform.position +
                    CalculateDirectionToMoveTowardsTheTarget() * Time.deltaTime * _zombieMoveVelocity);
            }
        }

        private Vector3 CalculateDirectionToMoveTowardsTheTarget()
        {
            return Vector3.Normalize(_target.gameObject.transform.position - gameObject.transform.position);
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