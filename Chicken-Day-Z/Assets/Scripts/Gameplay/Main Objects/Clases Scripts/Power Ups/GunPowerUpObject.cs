using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public class GunPowerUpObject : PowerUpObject
    {
        [SerializeField] private FirearmStats[] _firearmStats;        

        private GunPowerUpObject() : base(PowerUpObjectTypeEnum.GUN)
        {

        }

        void OnCollisionStay(Collision collision)
        {
            Debug.Log("Collision");

            if (collision.transform.tag == "Player" && Input.GetKeyDown(_usePowerUpInput))
            {
                UsePowerUp();
            }
        }

        protected override void UsePowerUp()
        {
            if (PowerUpAvailable)
            {
                

                PowerUpAvailable = false;
            }
        }
    }
}