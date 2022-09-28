using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.Gameplay.Characters.Inventory
{
    public class CharacterInventory : MonoBehaviour, IResettable
    {
        [SerializeField] private FirearmStats _firearmStats;

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

        void OnDisable()
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

                    switch (_firearmStats.FirearmType)
                    {
                        case FirearmTypeEnum.RIFLE:
                            
                            _equippedItem = new Firearm(_firearmStats.ProjectilePrefab,
                                new Charger(_firearmStats.ChargerMaxAmmo, _firearmStats.ReloadTime),
                                new Canyon(_firearmStats.FireRate, _firearmStats.Damage, _firearmStats.BulletMoveSpeed, _firearmStats.Range, _firearmStats.FireCapacity),
                                gameObject);

                            break;
                        default:
                            break;
                    }                    
                    
                    break;
                default:
                    break;
            }
        }     
    }
}