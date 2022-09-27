using UnityEngine;

using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.Gameplay.Characters.Inventory.ItemActions 
{    
    [RequireComponent(typeof(CharacterInventory))]
    public class CharacterItemActionController : MonoBehaviour
    {
        [SerializeField] private ItemActionTypeEnum _actionType;

        private IItemAction _itemAction; //Porque no hacer que este script tome multiples acciones        

        private bool _executeAction;

        public bool ExecuteAction 
        {
            set 
            {
                _executeAction = value;
            }
        }        

        void Awake()
        {
            SetActionType();            
        }

        private void Start()
        {
            _executeAction = false;
        }

        void Update()
        {
            if (_executeAction) 
            {
                _itemAction?.DoAction();

                _executeAction = false;
            }

            _itemAction?.ActionCoolDown();
        }

        private void SetActionType() 
        {
            CharacterInventory characterInventory = GetComponent<CharacterInventory>();

            switch (_actionType)
            {
                case ItemActionTypeEnum.FIRE_FIREARM:                    

                    if (characterInventory.EquippedItem is Firearm) 
                    {
                        _itemAction = new CharacterFireFirearmAction(((Firearm)characterInventory.EquippedItem).FireFirearmMechanic);
                    }
                    
                    break;

                case ItemActionTypeEnum.RELOAD_FIREARM:                    

                    if (characterInventory.EquippedItem is Firearm)
                    {
                        _itemAction = new CharacterReloadFirearmAction(((Firearm)characterInventory.EquippedItem).ReloadFirearmMechanic);
                    }

                    break;
                default:
                    break;
            }
        }
    }
}