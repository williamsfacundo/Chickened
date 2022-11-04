using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.Gameplay.Characters.Inventory
{
    public class CharacterInventory : MonoBehaviour, IResettable
    {
        [SerializeField] private SpriteRenderer _firearmSpriteRenderer;

        [SerializeField] private FirearmStats _initialFirearmStats;

        private FirearmStats _firearmStats;        

        public event Action OnEquippedItemSelected;

        private IInventoryItem _equippedItem;

        public SpriteRenderer FirearmSpriteRenderer
        {
            get 
            {
                return _firearmSpriteRenderer;
            }
        }

        public FirearmStats FirearmStats 
        {
            set 
            {
                _firearmStats = value;

                SetEquippedItem();
            }
            get 
            {
                return _firearmStats;
            }
        }

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

        void Start()
        {
            FirearmStats = _initialFirearmStats;
        }

        public void ResetObject()
        {
            if (FirearmStats != _initialFirearmStats) 
            {
                FirearmStats = _initialFirearmStats;
            }
            else 
            {
                _equippedItem.ResetObject();
            }
            
        }

        private void SetEquippedItem() 
        {
            if (_equippedItem != null) 
            {
                ((Firearm)_equippedItem).FireFirearmMechanic.DestroyBullets();
            }

            _equippedItem = new Firearm(_firearmStats.ProjectilePrefab,
                                new Charger(_firearmStats.ChargerMaxAmmo, _firearmStats.ReloadTime),
                                new Canyon(_firearmStats.FireRate, _firearmStats.Damage,
                                _firearmStats.BulletMoveSpeed, _firearmStats.Range, _firearmStats.FireCapacity),
                                gameObject);

            _firearmSpriteRenderer.sprite = _firearmStats._sprite;

            OnEquippedItemSelected?.Invoke();
        }     
    }
}