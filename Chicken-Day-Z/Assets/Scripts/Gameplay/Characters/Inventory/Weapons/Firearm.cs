using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons
{
    public class Firearm : Weapon
    {
        private FireFirearm _fireFirearmMechanic;
        
        public FireFirearm FireFirearmMechanic
        {
            get 
            {
                return _fireFirearmMechanic;
            }
        }

        public Firearm(float attackCooldownTime, float attackDamage) 
            : base(attackCooldownTime, attackDamage)
        {
            _fireFirearmMechanic = new FireFirearm();
        }

        public override InventoryItemEnum GetInventoryItemType() 
        {
            return InventoryItemEnum.FIREARM;
        }
    }
}