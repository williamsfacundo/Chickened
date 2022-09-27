using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.Gameplay.Characters.Inventory.ItemActions 
{
    public class CharacterReloadFirearmAction : IItemAction
    {
        private ReloadFirearm _reloadFirearmMechanic;

        public CharacterReloadFirearmAction(ReloadFirearm reloadFirearmMechanic) 
        {
            _reloadFirearmMechanic = reloadFirearmMechanic;
        }

        public void DoAction()
        {
            _reloadFirearmMechanic.ReloadCharger();
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