using UnityEngine;

using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons
{
    public class Firearm : IInventoryItem
    {
        private Charger _charger;

        private Canyon _canyon;

        private FireFirearm _fireFirearmMechanic;

        private ReloadFirearm _reloadFirearmMechanic;

        public FireFirearm FireFirearmMechanic
        {
            get
            {
                return _fireFirearmMechanic;
            }
        }

        public ReloadFirearm ReloadFirearmMechanic 
        {
            get 
            {
                return _reloadFirearmMechanic;
            }
        }

        public Charger Charger 
        {
            get
            {
                return _charger;
            }
        }

        public Canyon Canyon 
        {
            get 
            {
                return _canyon;
            }
        }

        public Firearm(GameObject projectilePrefab, Charger charger, Canyon canyon, GameObject character, GameObject handWeapon)
        {
            _charger = charger;
            
            _canyon = canyon;

            _reloadFirearmMechanic = new ReloadFirearm(_charger);

            _fireFirearmMechanic = new FireFirearm(projectilePrefab, _charger, _canyon, character, _reloadFirearmMechanic, handWeapon);            
        }        

        public InventoryItemEnum GetInventoryItemType() 
        {
            return InventoryItemEnum.FIREARM;
        }

        public void ResetObject()
        {
            _charger.ResetObject();

            _fireFirearmMechanic.ResetObject();

            _reloadFirearmMechanic.ResetObject();
        }
    }
}