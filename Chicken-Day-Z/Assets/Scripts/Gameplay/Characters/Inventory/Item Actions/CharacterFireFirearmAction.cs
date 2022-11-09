using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;
using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.Inventory.ItemActions 
{
    public class CharacterFireFirearmAction : IItemAction
    {      
        private FireFirearm _fireFirearm;

        private GameObject _gameObject;

        public CharacterFireFirearmAction(FireFirearm fireFirearm, GameObject gameObject)
        {
            _fireFirearm = fireFirearm;

            _gameObject = gameObject;
        }

        public void DoAction()
        {
            _fireFirearm.ActivateProjectile(_gameObject);                        
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