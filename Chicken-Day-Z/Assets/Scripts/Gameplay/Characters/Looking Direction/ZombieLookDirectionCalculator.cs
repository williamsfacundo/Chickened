using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.Gameplay.Characters.LookingDirection 
{
    public class ZombieLookDirectionCalculator : CharacterLookDirectionCalculator
    {
        private ZombiesMovementIA _zombiesMovementIA;        

        void Awake()
        {
            _zombiesMovementIA = GetComponent<ZombiesMovementIA>();
        }

        public override void CalculateCharacterLookDirection()
        {
            TargetPosition = _zombiesMovementIA.Target.position;

            Angle = MathFunctions.AngleBetweenTwoPositions(gameObject.transform.position, TargetPosition);

            if (Angle > 0 && Angle < 60)
            {
                CharacterLookDirection = CharacterLookDirectionEnum.BACK_RIGHT;
            }
            else if (Angle > 61 && Angle < 120)
            {
                CharacterLookDirection = CharacterLookDirectionEnum.BACK;
            }
            else if (Angle > 121 && Angle < 180)
            {
                CharacterLookDirection = CharacterLookDirectionEnum.BACK_LEFT;
            }
            else if (Angle > -180 && Angle < -120)
            {
                CharacterLookDirection = CharacterLookDirectionEnum.FRONT_LEFT;
            }
            else if (Angle > -119 && Angle < -61)
            {
                CharacterLookDirection = CharacterLookDirectionEnum.FRONT;
            }
            else
            {
                CharacterLookDirection = CharacterLookDirectionEnum.FRONT_RIGHT;
            }
        }
    }
}