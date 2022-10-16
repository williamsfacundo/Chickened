using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.LookingDirection 
{
    public abstract class CharacterLookDirectionCalculator : MonoBehaviour
    {
        private CharacterLookDirectionEnum _characterCurrentLookDirection;

        private CharacterLookDirectionEnum _characterOldLookDirection;

        public event Action OnCharacterLookDirectionChanged;

        private Camera _camera;

        private Vector3 _targetPosition;

        private float _angle;

        public CharacterLookDirectionEnum CharacterLookDirection
        {
            set
            {
                _characterCurrentLookDirection = value;
            }
            get
            {
                return _characterCurrentLookDirection;
            }
        }

        public Camera Camera
        {
            get
            {
                return _camera;
            }
        }
        public Vector3 TargetPosition
        {
            set
            {
                _targetPosition = value;
            }
            get
            {
                return _targetPosition;
            }
        }

        public float Angle
        {
            set 
            {
                _angle = value;
            }
            get 
            {
                return _angle;
            }
        }

        void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            CalculateCharacterLookDirection();

            CharacterDirectionChanged();
        }

        public abstract void CalculateCharacterLookDirection();

        private void CharacterDirectionChanged()
        {
            if (_characterOldLookDirection != _characterCurrentLookDirection)
            {
                OnCharacterLookDirectionChanged?.Invoke();

                _characterOldLookDirection = _characterCurrentLookDirection;
            }
        }
    }
}
