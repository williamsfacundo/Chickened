using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Health;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class ProjectileImpact : MonoBehaviour
    {
        private float _damage;

        public float Damage 
        {
            set 
            {
                _damage = value;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ObjectHealth objectHealth = collision.gameObject.GetComponent<ObjectHealth>();

            if (objectHealth != null) 
            {
                objectHealth.ReceiveDamage(_damage);
            }

            gameObject.SetActive(false);
        }
    }
}