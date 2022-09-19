using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.Attack 
{
    public class CharacterAttackMechanic : MonoBehaviour
    {
        [SerializeField] private AttackMechanicEnum _attackType;

        private IAttacks _attackMechanic;

        private void Awake()
        {
            SelectAttackMechanic();
        }

        void Update()
        {
            _attackMechanic.Attack();
        }

        private void SelectAttackMechanic() 
        {
            switch (_attackType)
            {
                case AttackMechanicEnum.CHICKEN_MELEE:


                    break;
                default:
                    break;
            }
        }
    }
}