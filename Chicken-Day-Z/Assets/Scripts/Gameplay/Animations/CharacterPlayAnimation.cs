using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Movement;
using ChickenDayZ.Gameplay.Characters.Chicken.Movement;

namespace ChickenDayZ.Animations 
{
    [RequireComponent(typeof(CharacterAnimationsManager), typeof(CharacterLookDirectionCalculator))]
    public class CharacterPlayAnimation : MonoBehaviour
    {
        [SerializeField] private string[] _idleAnimationsNames;

        [SerializeField] private string[] _moveAnimationsNames;

        private CharacterLookDirectionCalculator _characterLookDirectionCalculator;

        private CharacterAnimationsManager _characterAnimationsManager;        

        private CharacterMovementController _characterMovementController;

        private ChickenMovement _chickenMovement;

        void Awake()
        {
            _characterAnimationsManager = GetComponent<CharacterAnimationsManager>();

            _characterLookDirectionCalculator = GetComponent<CharacterLookDirectionCalculator>();

            _characterMovementController = GetComponent<CharacterMovementController>();

            _chickenMovement = (ChickenMovement)_characterMovementController.MoveMechanic;
        }

        void OnEnable()
        {
            _characterLookDirectionCalculator.OnCharacterLookDirectionChanged += SetAnimation;

            _characterMovementController.OnCharacterChangedMoveState += SetAnimation;
        }

        void OnDisable()
        {
            _characterLookDirectionCalculator.OnCharacterLookDirectionChanged -= SetAnimation;

            _characterMovementController.OnCharacterChangedMoveState -= SetAnimation;
        }                     

        void SetAnimation()
        {
            _characterAnimationsManager.ChangeAnimation(GetTheCorrectAnimation());
        }

        string GetTheCorrectAnimation() 
        {
            switch (_characterLookDirectionCalculator.CharacterLookDirection)
            {
                case CharacterLookDirection.BACK_RIGHT:

                    if (_chickenMovement.IsMoving()) 
                    {
                        return _moveAnimationsNames[0];
                    }
                    else 
                    {
                        return _idleAnimationsNames[0];
                    }                    
                    
                case CharacterLookDirection.BACK:

                    if (_chickenMovement.IsMoving())
                    {
                        return _moveAnimationsNames[1];
                    }
                    else
                    {
                        return _idleAnimationsNames[1];
                    }                    
                    
                case CharacterLookDirection.BACK_LEFT:

                    if (_chickenMovement.IsMoving())
                    {
                        return _moveAnimationsNames[2];
                    }
                    else
                    {
                        return _idleAnimationsNames[2];
                    }                                        
                    
                case CharacterLookDirection.FRONT_LEFT:

                    if (_chickenMovement.IsMoving())
                    {
                        return _moveAnimationsNames[3];
                    }
                    else
                    {
                        return _idleAnimationsNames[3];
                    }                   
                    
                case CharacterLookDirection.FRONT:

                    if (_chickenMovement.IsMoving())
                    {
                        return _moveAnimationsNames[4];
                    }
                    else
                    {
                        return _idleAnimationsNames[4];
                    }

                case CharacterLookDirection.FRONT_RIGHT:

                    if (_chickenMovement.IsMoving())
                    {
                        return _moveAnimationsNames[5];
                    }
                    else
                    {
                        return _idleAnimationsNames[5];
                    }

                default:

                    if (_chickenMovement.IsMoving())
                    {
                        return _moveAnimationsNames[0];
                    }
                    else
                    {
                        return _idleAnimationsNames[0];
                    }
            }           
        }
    }
}