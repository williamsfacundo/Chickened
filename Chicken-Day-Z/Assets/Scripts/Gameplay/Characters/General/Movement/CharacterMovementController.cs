using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Characters.Chicken.Movement;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Characters.Chicken.Movement.Input;
using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.Gameplay.Characters.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovementController : MonoBehaviour, IResettable
    {
        [SerializeField] private MoveMechanics _moveMechanicEnum; 

        [SerializeField] private float _characterInitialMoveSpeed; 
        
        private IMoves _moveMechanic;

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetObject;
        }

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

        public void ResetObject()
        {
            _moveMechanic.ResetObject();
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