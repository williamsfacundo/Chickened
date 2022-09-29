using UnityEngine;

using TMPro;
using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.Characters.Health;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.UI 
{
    public class BulletsLeftIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showBulletsLeftText;
        
        private CharacterInventory _characterInventory;

        private void Start()
        {
            _characterInventory = FindObjectOfType<ChickenHealth>().gameObject.GetComponent<CharacterInventory>();
        }

        private void Update()
        {
            UpdateBulletsLeftText();
        }

        private void UpdateBulletsLeftText()
        {            
            _showBulletsLeftText.text = "Bullets Left: " + ((Firearm)_characterInventory.EquippedItem).Charger.ChargerAmmo;
        }
    }
}