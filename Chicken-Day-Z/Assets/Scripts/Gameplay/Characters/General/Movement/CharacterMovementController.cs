using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Characters.Chicken.Movement;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Characters.Chicken.Movement.Input;

namespace ChickenDayZ.Gameplay.Characters.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovementController : MonoBehaviour
    {
        [SerializeField] private MoveMechanics _moveMechanicEnum; 

        [SerializeField] private float _characterInitialMoveSpeed; 
        
        private IMoves _moveMechanic;

        private void Awake()
        {
            SelectMoveMechanic();
        }

        void Update()
        {
            CalculateDirectionFuntionCall();
        }

        void FixedUpdate()
        {
            MoveFuntionCall();
        }

        private void MoveFuntionCall() 
        {
            if (_moveMechanic != null) 
            {
                _moveMechanic.Move();
            }
            else 
            {
                Debug.Log("Move mechanic is missing!");
            }
        }

        private void CalculateDirectionFuntionCall()
        {
            if (_moveMechanic != null)
            {
                _moveMechanic.CalculateMoveDirection();
            }
            else
            {
                Debug.Log("Move mechanic is missing!");
            }
        }

        private void SelectMoveMechanic() 
        {
            switch (_moveMechanicEnum) 
            {
                case MoveMechanics.PLAYER_ONE:                    

                    _moveMechanic = new ChickenMovement(new KeyboardMovementInput(new AxisMovement("Horizontal", "Vertical")), 
                        gameObject.GetComponent<Rigidbody2D>(), _characterInitialMoveSpeed);

                    break;
                default:
                    break;
            }
        }
    }
}