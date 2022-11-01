using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.MainObjects.Characters;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class ProjectileImpact : MonoBehaviour
    {
        private float _damage = 10;        

        public float Damage 
        {
            set 
            {
                _damage = value;
            }
        }        

        private void Start()
        {            
            _damage = 10f;  
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ZombieObject zombieObject = collision.gameObject.GetComponent<ZombieObject>();

            if (zombieObject != null) 
            {
                ObjectHealth objectHealth = zombieObject.gameObject.GetComponent<ObjectHealth>();

                objectHealth.ReceiveDamage(_damage);

                gameObject.SetActive(false);
            }
            else 
            {
                if (collision.gameObject.tag != "Player") 
                {
                    gameObject.SetActive(false);
                }
            }                      
        }
    }
}