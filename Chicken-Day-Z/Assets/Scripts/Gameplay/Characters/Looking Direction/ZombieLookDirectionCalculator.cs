using UnityEngine;

using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.Gameplay.Characters.LookingDirection 
{
    public class ZombieLookDirectionCalculator : CharacterLookDirectionCalculator
    {
        private ZombiesMovementIA _zombiesMovementIA;

        private Animator _animator;

        void Awake()
        {
            _zombiesMovementIA = GetComponent<ZombiesMovementIA>();

            _animator = GetComponent<Animator>();
        }

        public override void CalculateCharacterLookDirection()
        {
            TargetPosition = _zombiesMovementIA.Target.position;

            Angle = MathFunctions.AngleBetweenTwoPositions(gameObject.transform.position, TargetPosition);

            if (Angle > 0 && Angle < 60)
            {
                SetDirection(CharacterLookDirectionEnum.BACK_RIGHT, 0);                
            }
            else if (Angle > 61 && Angle < 120)
            {
                SetDirection(CharacterLookDirectionEnum.BACK, 4);                
            }
            else if (Angle > 121 && Angle < 180)
            {
                SetDirection(CharacterLookDirectionEnum.BACK_LEFT, 1);                
            }
            else if (Angle > -180 && Angle < -120)
            {
                SetDirection(CharacterLookDirectionEnum.FRONT_LEFT, 3);                
            }
            else if (Angle > -119 && Angle < -61)
            {
                SetDirection(CharacterLookDirectionEnum.FRONT, 5);                
            }
            else
            {
                SetDirection(CharacterLookDirectionEnum.FRONT_RIGHT, 2);                
            }
        }

        private void SetDirection(CharacterLookDirectionEnum direction, int animatorDirection) 
        {
            CharacterLookDirection = direction;

            _animator.SetInteger("Direction", animatorDirection);
        }
    }
}