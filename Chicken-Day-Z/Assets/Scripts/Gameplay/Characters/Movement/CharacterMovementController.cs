using System;
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
        [SerializeField] private MoveMechanicsEnum _moveMechanicEnum;

        [SerializeField] private float _characterInitialMoveSpeed;

        public event Action OnCharacterChangedMoveState;

        public bool _lastState;

        private IMoves _moveMechanic;

        public IMoves MoveMechanic 
        {
            get 
            {
                return _moveMechanic;
            }
        }

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

            _lastState = _moveMechanic.IsMoving();
        }        

        void Update()
        {
            CalculateDirectionFuntionCall();

            MoveStateChanged();
        }

        void FixedUpdate()
        {
            MoveFuntionCall();
        }

        public void ResetObject()
        {
            _moveMechanic.ResetObject();

            _lastState = _moveMechanic.IsMoving();
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
                case MoveMechanicsEnum.PLAYER_ONE:

                    _moveMechanic = new ChickenMovement(new KeyboardMovementInput(new AxisMovement("Horizontal", "Vertical")),
                        gameObject.GetComponent<Rigidbody2D>(), _characterInitialMoveSpeed);

                    break;
                default:
                    break;
            }
        }

        private void MoveStateChanged() 
        {
            if (_lastState != _moveMechanic.IsMoving()) 
            {
                OnCharacterChangedMoveState?.Invoke();

                _lastState = _moveMechanic.IsMoving();
            }            
        }
    }
}