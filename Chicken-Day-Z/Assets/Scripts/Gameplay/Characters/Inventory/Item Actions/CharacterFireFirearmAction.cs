using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;
using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.Inventory.ItemActions 
{
    public class CharacterFireFirearmAction : IItemAction
    {      
        private FireFirearm _fireFirearm;

        public CharacterFireFirearmAction(FireFirearm fireFirearm)
        {
            _fireFirearm = fireFirearm;
        }

        public void DoAction()
        {
            _fireFirearm.InstanciateProjectile();                        
        }
        
        public void ActionCoolDown() 
        {
            _fireFirearm.FireFirearmCoolDown();                                    
        }

        public ItemActionTypeEnum GetItemActionType()
        {
            return ItemActionTypeEnum.FIRE_FIREARM;
        }
    }    
}