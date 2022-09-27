using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.Gameplay.Characters.Inventory
{
    public class CharacterInventory : MonoBehaviour, IResettable
    {
        [SerializeField] private InventoryItemEnum _initialInventoryItem;

        private IInventoryItem _equippedItem;

        public IInventoryItem EquippedItem 
        {
            get 
            {
                return _equippedItem; 
            }
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;
        }

        private void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetObject;
        }

        void Awake()
        {
            SetEquippedItem(_initialInventoryItem);
        }

        public void ResetObject()
        {
            SetEquippedItem(_initialInventoryItem);
        }

        private void SetEquippedItem(InventoryItemEnum inventoryItem) 
        {
            switch (inventoryItem)
            {
                case InventoryItemEnum.FIREARM:

                    //Tengo que tener otro switch y otro enum para el tipo concreto de firearm
                    _equippedItem = new Firearm(Resources.Load<GameObject>("Bullet"), new Charger(30, 1.5f), new Canyon(0.5f, 15, 0.7f, 3.2f, 1), gameObject);
                    break;
                default:
                    break;
            }
        }     
    }
}