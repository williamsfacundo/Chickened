using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Movement;
using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Animations
{
    [RequireComponent(typeof(CharacterAnimationsManager), 
        typeof(CharacterLookDirectionCalculator), typeof(CharacterMovementController))]
    public class CharacterPlayAnimation : MonoBehaviour
    {
        [SerializeField] private string[] _idleAnimationsNames;

        [SerializeField] private string[] _moveAnimationsNames;

        private CharacterLookDirectionCalculator _characterLookDirectionCalculator;

        private CharacterAnimationsManager _characterAnimationsManager;        

        private CharacterMovementController _characterMovementController;

        private IMoves _characterMovement;

        void Awake()
        {
            _characterAnimationsManager = GetComponent<CharacterAnimationsManager>();

            _characterLookDirectionCalculator = GetComponent<CharacterLookDirectionCalculator>();

            _characterMovementController = GetComponent<CharacterMovementController>();            
        }

        void Start()
        {
            _characterMovement = _characterMovementController.MoveMechanic;
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
            _characterAnimationsManager.ChangeAnimation(AnimationSelector());
        }

        string AnimationSelector() 
        {
            switch (_characterLookDirectionCalculator.CharacterLookDirection)
            {
                case CharacterLookDirection.BACK_RIGHT:

                    return GetAnimation(0);
                case CharacterLookDirection.BACK:

                    return GetAnimation(1);
                case CharacterLookDirection.BACK_LEFT:

                    return GetAnimation(2);
                case CharacterLookDirection.FRONT_LEFT:

                    return GetAnimation(3);
                case CharacterLookDirection.FRONT:

                    return GetAnimation(4);
                case CharacterLookDirection.FRONT_RIGHT:

                    return GetAnimation(5);
                default:

                    return GetAnimation(0);                    
            }            
        }

        private string GetAnimation(short index) 
        {
            if (_characterMovement.IsMoving())
            {
                return _moveAnimationsNames[index];
            }
            else
            {
                return _idleAnimationsNames[index];
            }
        }
    }
}