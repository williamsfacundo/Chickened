using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.MainObjects.Characters;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class ProjectileImpact : MonoBehaviour
    {
        private CharacterInventory _characterInventory;

        private Firearm _chickenFirearm;

        private float _damage;

        private bool _projectileImpacted;

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

        public bool ProjectileImpacted 
        {
            set 
            {
                _projectileImpacted = value;
            }
            get 
            {
                return _projectileImpacted;
            }
        }

        void Awake()
        {
            _characterInventory = FindObjectOfType<ChickenObject>().GetComponent<CharacterInventory>();            
        }

        private void Start()
        {
            UpdateDamage();

            ProjectileImpacted = false; 
        }        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_projectileImpacted) 
            {
                ZombieObject zombieObject = collision.gameObject.GetComponent<ZombieObject>();

                if (zombieObject != null)
                {
                    ObjectHealth objectHealth = zombieObject.gameObject.GetComponent<ObjectHealth>();

                    objectHealth.ReceiveDamage(_damage);

                    AkSoundEngine.PostEvent("Play_Zombies_Impact", gameObject);

                    gameObject.SetActive(false);

                    _projectileImpacted = true;
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

        private void UpdateDamage() 
        {
            _chickenFirearm = (Firearm)_characterInventory.EquippedItem;

            _damage = _chickenFirearm.Canyon.Damage;
        }
    }
}