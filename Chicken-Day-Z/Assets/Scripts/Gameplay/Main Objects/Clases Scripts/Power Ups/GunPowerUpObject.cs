using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public class GunPowerUpObject : PowerUpObject
    {
        [SerializeField] private FirearmStats[] _firearmStats;

        [SerializeField] private CharacterInventory _characterInventory;

        private GunPowerUpObject() : base(PowerUpObjectTypeEnum.GUN)
        {

        }

        void Start()
        {
            PowerUpLevel = 0;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.transform.tag == "Player" && Input.GetKeyDown(_usePowerUpInput))
            {
                CallOnPowerUpInteracted();
                
                UsePowerUp();
            }
        }                

        protected override void UsePowerUp()
        {
            if (PowerUpAvailable)
            {
                if (PowerUpLevel < _firearmStats.Length) 
                {
                    _characterInventory.FirearmStats = _firearmStats[PowerUpLevel];

                    PowerUpLevel += 1;
                
                    PowerUpAvailable = false;
                }
            }
        }
    }
}