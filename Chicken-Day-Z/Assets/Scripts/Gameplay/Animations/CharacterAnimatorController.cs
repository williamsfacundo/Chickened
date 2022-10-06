using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Movement;

namespace ChickenDayZ.Animations 
{
    public class CharacterAnimatorController : MonoBehaviour
    {
        private Animator _animator;

        private CharacterMovement _characterMovement;

        void Awake()
        {
            _animator = GetComponent<Animator>();

            _characterMovement = GetComponent<CharacterMovement>();
        }

        void Start()
        {
            _animator.SetInteger("Idle", GetDirectionWhereCharacterShouldLook());
        }
        
        void Update()
        {
            if (_characterMovement.ObjectRigidbody2D.velocity != Vector2.zero) 
            {
                _animator.SetInteger("Idle", GetDirectionWhereCharacterShouldLook());
            }
        }

        int GetDirectionWhereCharacterShouldLook() 
        {
            return 0;
        }
    }
}