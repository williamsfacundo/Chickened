using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Gameplay.Characters.Movement
{
    public abstract class CharacterMovement : IMoves
    {
        private Rigidbody2D _objectRigidbody2D;

        private Vector2 _moveDirection;

        private float _moveSpeed;

        public Rigidbody2D ObjectRigidbody2D
        {
            get
            {
                return _objectRigidbody2D;
            }
        }

        public Vector2 MoveDirection
        {
            set
            {
                _moveDirection = value;
            }
            get
            {
                return _moveDirection;
            }
        }

        public float MoveSpeed
        {
            set
            {
                _moveSpeed = value;
            }
            get
            {
                return _moveSpeed;
            }
        }

        public CharacterMovement(Rigidbody2D objectRigidbody2D, float moveSpeed)
        {
            _objectRigidbody2D = objectRigidbody2D;

            _moveDirection = Vector2.zero;

            _moveSpeed = moveSpeed;
        }

        public void ResetObject()
        {
            _moveDirection = Vector2.zero;
        }

        public abstract void CalculateMoveDirection();

        public abstract void Move();
    }
}