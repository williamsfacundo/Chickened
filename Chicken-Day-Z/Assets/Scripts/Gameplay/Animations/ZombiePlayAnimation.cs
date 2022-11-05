using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Characters.LookingDirection;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.Animations 
{
    [RequireComponent(typeof(CharacterAnimationsManager),
        typeof(ZombieLookDirectionCalculator))]
    public class ZombiePlayAnimation : MonoBehaviour
    {
        [SerializeField] private string[] _moveAnimationsNames;

        [SerializeField] private string _notMovingAnimation;

        private CharacterLookDirectionCalculator _characterLookDirectionCalculator;

        private CharacterAnimationsManager _characterAnimationsManager;

        //private CharacterMovementController _characterMovementController;

        private IMoves _characterMovement;

        void Awake()
        {
            _characterAnimationsManager = GetComponent<CharacterAnimationsManager>();

            _characterLookDirectionCalculator = GetComponent<ZombieLookDirectionCalculator>();

            //_characterMovementController = GetComponent<CharacterMovementController>();
        }
        
        void Start()
        {
            //_characterMovement = _characterMovementController.MoveMechanic;
        }
        void OnEnable()
        {
            _characterLookDirectionCalculator.OnCharacterLookDirectionChanged += SetAnimation;

            //_characterMovementController.OnCharacterChangedMoveState += SetAnimation;
        }

        void OnDisable()
        {
            _characterLookDirectionCalculator.OnCharacterLookDirectionChanged -= SetAnimation;

            //_characterMovementController.OnCharacterChangedMoveState -= SetAnimation;
        }

        void SetAnimation()
        {
            _characterAnimationsManager.ChangeAnimation(AnimationSelector());
        }

        string AnimationSelector()
        {
            switch (_characterLookDirectionCalculator.CharacterLookDirection)
            {
                case CharacterLookDirectionEnum.BACK_RIGHT:

                    return GetAnimation(0);
                case CharacterLookDirectionEnum.BACK:

                    return GetAnimation(1);
                case CharacterLookDirectionEnum.BACK_LEFT:

                    return GetAnimation(2);
                case CharacterLookDirectionEnum.FRONT_LEFT:

                    return GetAnimation(3);
                case CharacterLookDirectionEnum.FRONT:

                    return GetAnimation(4);
                case CharacterLookDirectionEnum.FRONT_RIGHT:

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
                return _notMovingAnimation;
            }                        
        }
    }
}