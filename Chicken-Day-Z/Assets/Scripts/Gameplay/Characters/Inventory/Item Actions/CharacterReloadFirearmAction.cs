using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.Gameplay.Characters.Inventory.ItemActions 
{
    public class CharacterReloadFirearmAction : IItemAction
    {
        private ReloadFirearm _reloadFirearmMechanic;

        private GameObject _gameObject;

        public CharacterReloadFirearmAction(ReloadFirearm reloadFirearmMechanic, GameObject gameObject) 
        {
            _reloadFirearmMechanic = reloadFirearmMechanic;

            _gameObject = gameObject;            
        }

        public void DoAction()
        {
            _reloadFirearmMechanic.ReloadCharger(_gameObject);
        }

        public void ActionCoolDown()
        {
            _reloadFirearmMechanic.ReloadCooldown();
        }

        public ItemActionTypeEnum GetItemActionType()
        {
            return ItemActionTypeEnum.RELOAD_FIREARM;
        }
    }
}