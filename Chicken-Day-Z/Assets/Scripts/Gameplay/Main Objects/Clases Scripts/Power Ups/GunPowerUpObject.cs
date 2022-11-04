using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public class GunPowerUpObject : PowerUpObject
    {
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