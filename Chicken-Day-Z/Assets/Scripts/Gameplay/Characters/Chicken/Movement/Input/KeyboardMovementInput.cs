using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Movement.Input
{
    public class KeyboardMovementInput : MovementInputDetectionMechanic
    {
        private AxisMovement _movementAxis;

        public KeyboardMovementInput(AxisMovement movementAxis) 
        {
            _movementAxis = movementAxis;
        }

        public override Vector2 GetDirectionOnInputDetection() 
        { 
            return new Vector2(_movementAxis.GetHorizontalInputDetection(), 
                _movementAxis.GetVerticalInputDetection());
        }
    }
}