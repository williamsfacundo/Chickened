using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{    
    public class ProjectileMovement : MonoBehaviour
    {
        private Vector3 _direction;

        private Vector3 _moveValue;

        private float _moveSpeed;

        private float _range;       

        void FixedUpdate()
        {
            CalculateMoveValue();

            MoveProjectile();

            DecreaseRange();

            DestroyProjectileWhenRangeAchieved();
        }

        public void SetProjectile(Vector3 direction, float moveSpeed, float range) 
        {
            _direction = direction;

            _moveSpeed = moveSpeed;

            _range = range;

            _moveValue = Vector3.zero;
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
                Destroy(gameObject);
            }
        }
    }
}