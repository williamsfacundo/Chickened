using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.MainObjects.Characters;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class ProjectileImpact : MonoBehaviour
    {
        [SerializeField] private float _damage;        

        public float Damage 
        {
            set 
            {
                _damage = value;
            }
            get 
            {
                return _damage;
            }
        }        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ZombieObject zombieObject = collision.gameObject.GetComponent<ZombieObject>();

            if (zombieObject != null) 
            {
                ObjectHealth objectHealth = zombieObject.gameObject.GetComponent<ObjectHealth>();

                objectHealth.ReceiveDamage(_damage);

                AkSoundEngine.PostEvent("Play_Zombies_Impact", gameObject);
                
                gameObject.SetActive(false);
            }
            else 
            {
                if (collision.GetComponent<ChickenObject>() == null) 
                {
                    gameObject.SetActive(false);
                }
            }                      
        }
    }
}