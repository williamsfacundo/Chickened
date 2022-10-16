using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class ProjectileImpact : MonoBehaviour
    {
        private float _damage;

        private CharacterTypeEnum _targetType;

        public float Damage 
        {
            set 
            {
                _damage = value;
            }
        }

        public CharacterTypeEnum TargetType
        {
            set
            {
                _targetType = value;
            }
        }

        private void Start()
        {
            _targetType = CharacterTypeEnum.ZOMBIE;
            _damage = 10f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ObjectHealth objectHealth = collision.gameObject.GetComponent<ObjectHealth>();

            if (objectHealth != null) 
            {
                /*if (objectHealth.GetCharacterType() == _targetType) 
                {
                    objectHealth.ReceiveDamage(_damage);                    
                }

                if (objectHealth.GetCharacterType() != CharacterTypeEnum.CHICKEN) 
                {
                    gameObject.SetActive(false);
                }*/
            }
            else 
            {
                gameObject.SetActive(false);
            }            
        }
    }
}