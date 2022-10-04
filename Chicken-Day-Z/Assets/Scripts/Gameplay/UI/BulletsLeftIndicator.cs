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
        
        private Charger _charger;

        private void Start()
        {            
            _charger = ((Firearm)FindObjectOfType<ChickenHealth>().gameObject.GetComponent<CharacterInventory>().EquippedItem).Charger;

            _charger.OnAmmoChanged += UpdateBulletsLeftText;

            UpdateBulletsLeftText();
        }

        void OnDestroy()
        {
            _charger.OnAmmoChanged -= UpdateBulletsLeftText;
        }

        private void UpdateBulletsLeftText()
        {            
            _showBulletsLeftText.text = "Bullets Left: " + _charger.ChargerAmmo;
        }
    }
}