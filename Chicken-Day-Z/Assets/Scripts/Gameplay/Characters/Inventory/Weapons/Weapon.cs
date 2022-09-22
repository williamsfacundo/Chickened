using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public abstract class Weapon : IInventoryItem
    {
        private Timer _attackCoolDownTimer;

        private float _attackDamage;

        public Timer AttackCoolDownTimer 
        {            
            get
            {
                return AttackCoolDownTimer;
            }
        }

        public float AttackDamage 
        {
            set 
            {
                _attackDamage = value;
            }
            get
            {
                return _attackDamage;
            }
        }

        public Weapon(float attackCooldownTime, float attackDamage) 
        {
            _attackCoolDownTimer = new Timer(attackCooldownTime);

            _attackDamage = attackDamage;            
        }

        public abstract InventoryItemEnum GetInventoryItemType();       
    }
}