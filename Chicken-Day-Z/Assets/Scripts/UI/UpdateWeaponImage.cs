using UnityEngine;
using UnityEngine.UI;

using ChickenDayZ.Gameplay.Characters.Inventory;

namespace ChickenDayZ.UI 
{
    public class UpdateWeaponImage : MonoBehaviour
    {
        [SerializeField] private CharacterInventory _characterInventory;

        [SerializeField] private Image _weaponImage;

        void OnEnable()
        {
            _characterInventory.OnEquippedItemSelected += UpdateImage;
        }

        void OnDisable()
        {
            _characterInventory.OnEquippedItemSelected -= UpdateImage;
        }

        private void UpdateImage()
        {
            _weaponImage.sprite = _characterInventory.FirearmSpriteRenderer.sprite;
        }
    }
}