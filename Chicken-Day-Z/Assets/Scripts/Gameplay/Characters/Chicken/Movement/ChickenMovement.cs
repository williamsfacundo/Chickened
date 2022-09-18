using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Movement;
using ChickenDayZ.Gameplay.Characters.Chicken.Movement.Input;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Movement 
{
    public class ChickenMovement : CharacterMovement
    {        
        private MovementInputDetectionMechanic _movementInput;       

        public ChickenMovement(MovementInputDetectionMechanic movementInput, Rigidbody2D objectRigidbody2D, float moveSpeed) 
            : base(objectRigidbody2D, moveSpeed) 
        {
            _movementInput = movementInput;           
        }

        public override void Move()
        {            
            ObjectRigidbody2D.MovePosition(ObjectRigidbody2D.position + MoveDirection * MoveSpeed * Time.deltaTime);           
        }

        public override void CalculateMoveDirection()
        {
            MoveDirection = _movementInput.GetDirectionOnInputDetection();            
        }        
    }
}