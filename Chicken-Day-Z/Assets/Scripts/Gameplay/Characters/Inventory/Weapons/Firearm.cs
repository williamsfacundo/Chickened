using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons
{
    public class Firearm : IWeapon
    {
        private Charger _charger;

        private Canyon _canyon;

        private FireFirearm _fireFirearmMechanic;        

        public FireFirearm FireFirearmMechanic
        {
            get
            {
                return _fireFirearmMechanic;
            }
        }

        public Firearm(Charger charger, Canyon canyon)
        {
            _charger = charger;
            
            _canyon = canyon;

           _fireFirearmMechanic = new FireFirearm();
        }

        public InventoryItemEnum GetInventoryItemType() 
        {
            return InventoryItemEnum.FIREARM;
        }

        public string GetWeaponID() 
        {
            return "firearm";
        }
    }
}