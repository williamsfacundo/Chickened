using UnityEngine;

using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;
using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.Gameplay.Characters.Inventory.ItemActions 
{    
    [RequireComponent(typeof(CharacterInventory))]
    public class CharacterItemActionController : MonoBehaviour, IResettable
    {
        [SerializeField] private ItemActionTypeEnum _actionType;

        CharacterInventory _characterInventory;

        private IItemAction _itemAction;        

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
            _characterInventory = GetComponent<CharacterInventory>();                       
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;

            _characterInventory.OnEquippedItemSelected += SetActionType;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetObject;

            _characterInventory.OnEquippedItemSelected -= SetActionType;
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
            switch (_actionType)
            {
                case ItemActionTypeEnum.FIRE_FIREARM:                    

                    if (_characterInventory.EquippedItem is Firearm) 
                    {
                        _itemAction = new CharacterFireFirearmAction(((Firearm)_characterInventory.EquippedItem).FireFirearmMechanic);
                    }
                    
                    break;

                case ItemActionTypeEnum.RELOAD_FIREARM:                    

                    if (_characterInventory.EquippedItem is Firearm)
                    {
                        _itemAction = new CharacterReloadFirearmAction(((Firearm)_characterInventory.EquippedItem).ReloadFirearmMechanic);
                    }

                    break;
                default:
                    break;
            }
        }

        public void ResetObject()
        {
            _executeAction = false;            
        }
    }
}