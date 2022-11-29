using UnityEngine;

using ChickenDayZ.Animations;
using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public class GunPowerUpObject : PowerUpObject
    {
        [SerializeField] private FirearmStats[] _firearmStats;

        [SerializeField] private CharacterInventory _characterInventory;

        private ChestPlayAnimation _chestAnimation;

        private static short _powerUpLevel;

        private GunPowerUpObject() : base(PowerUpObjectTypeEnum.GUN)
        {

        }

        void Awake()
        {
            _chestAnimation = GetComponent<ChestPlayAnimation>();
        }        

        protected override void UsePowerUp()
        {
            if (PowerUpAvailable && !IsChestBlocked && _powerUpLevel < MaxLevel)
            {
                _characterInventory.FirearmStats = _firearmStats[_powerUpLevel];

                _powerUpLevel += 1;

                PowerUpAvailable = false;

                IsChestBlocked = true;

                _chestAnimation.SetAnimation("Opened");
            }
            else 
            {
                _chestAnimation.SetAnimation("Blocked");
            }
        }

        protected override void ResetPowerUpLevel() 
        {
            _powerUpLevel = 0;
        }
    }
}