using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{    
    public class ProjectileMovement : MonoBehaviour
    {
        private Vector3 _direction;

        private Vector3 _moveValue;

        private float _moveSpeed;

        private float _initialRange;

        private float _range;

        public Vector3 Direction 
        {
            set 
            {
                _direction = value;
            }
        }

        private void OnEnable()
        {
            _range = _initialRange;
        }

        void FixedUpdate()
        {
            CalculateMoveValue();

            MoveProjectile();

            DecreaseRange();

            DestroyProjectileWhenRangeAchieved();
        }

        public void SetProjectile(float moveSpeed, float range) 
        {
            _direction = Vector3.zero;

            _moveValue = Vector3.zero;

            _moveSpeed = moveSpeed;

            _initialRange = range;

            _range = range;
        }

        private void CalculateMoveValue()
        {
            _moveValue = _direction * _moveSpeed * Time.deltaTime;
        }

        private void MoveProjectile() 
        {
            transform.position += _moveValue;
        }        

        private void DecreaseRange() 
        {
            _range -= _moveValue.magnitude;
        }

        private void DestroyProjectileWhenRangeAchieved() 
        {
            if (_range <= 0f) 
            {
                gameObject.SetActive(false);                 
            }
        }
    }
}