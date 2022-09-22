using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class FireFirearm
    {
        //Tener un gameObject projectil
        //Timer para el cooldown
        //Nocion de cuantas valas le quedan al cargador

        public FireFirearm() //Le pasamos el projectil como parametro 
        {

        }

        public void InstanciateProjectile() 
        {
            Debug.Log("Instanciate Projectile");
        }

        public void FireFirearmCoolDown() 
        {

        }
    }
}