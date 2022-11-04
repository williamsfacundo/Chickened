using System;
using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Zombie 
{
    public class ZombieTarget : MonoBehaviour
    {
        public event Action OnTargetChanged;
        
        private GameObject _target;

        private bool _isZombieCollidingWithTarget;        

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

        void Start()
        {
            _isZombieCollidingWithTarget = false;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Base" || collision.transform.tag == "Player")
            {
                _isZombieCollidingWithTarget = true;

                if (Target != collision.gameObject) 
                {
                    Target = collision.gameObject;
                }
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject == Target.gameObject)
            {
                _isZombieCollidingWithTarget = false;
            }
        }

        public Vector3 CalculateDirectionToMoveTowardsTheTarget()
        {
            if (_target == null) 
            {
                return Vector3.zero;
            }

            return Vector3.Normalize(_target.gameObject.transform.position - gameObject.transform.position);
        }       
    }
}