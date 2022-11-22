using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Buildings;

namespace ChickenDayZ.Gameplay.Health 
{
    public class SetSpriteBasedOnEggHealth : MonoBehaviour
    {
        [SerializeField] private Sprite _mySprite;

        [SerializeField] private Sprite[] _healthSprites;

        private ObjectHealth _eggHealth;

        private void Awake()
        {
            _eggHealth = FindObjectOfType<EggObject>().GetComponent<ObjectHealth>();

            _eggHealth.OnCurrentHealthChanged += UpdateHealthSprite;

            _eggHealth.OnMaxHealthChanged += UpdateHealthSprite;
        }

        void OnDestroy()
        {
            _eggHealth.OnCurrentHealthChanged -= UpdateHealthSprite;

            _eggHealth.OnMaxHealthChanged -= UpdateHealthSprite;
        }

        void UpdateHealthSprite() 
        {
            int index = _healthSprites.Length - 1;

            float dividedHealth = _eggHealth.MaxHealth / _healthSprites.Length;

            float currentHealthAcumulation = 0f;

            float lastHealthAcumulation = 0f;

            for (short i = 0; i < _healthSprites.Length; i++) 
            {
                currentHealthAcumulation += dividedHealth;

                if (_eggHealth.CurrentHealth >= lastHealthAcumulation && _eggHealth.CurrentHealth <= lastHealthAcumulation) 
                {
                    index = i;

                    break;
                }

                lastHealthAcumulation = currentHealthAcumulation;
            }
            
            _mySprite = _healthSprites[index];
        }
    }

}