using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.UI 
{
    public class BulletsLeftIndicator : MonoBehaviour
    {
        [SerializeField] private GameObject _chicken;

        [SerializeField] private TMP_Text _showBulletsLeftText;

        CharacterInventory _chickenInventory;

        private Charger _charger;

        void Awake()
        {
            CheckIfAnySerializedFieldObjectIsMissing();

            SetInventory();
        }

        void OnEnable()
        {            
            _chickenInventory.OnEquippedItemSelected += SetCharger;
        }

        void OnDisable()
        {
            if (_chickenInventory != null) 
            {
                _chickenInventory.OnEquippedItemSelected -= SetCharger;
            }
        }

        void OnDestroy()
        {
            if (_charger != null) 
            {
                _charger.OnAmmoChanged -= UpdateBulletsLeftText;
            }            
        }

        private void SetCharger() 
        {
            if (_chickenInventory.EquippedItem is Firearm)
            {
                _charger = ((Firearm)_chickenInventory.EquippedItem).Charger;
            }

            _charger.OnAmmoChanged += UpdateBulletsLeftText;

            UpdateBulletsLeftText();
        }

        private void UpdateBulletsLeftText()
        {            
            _showBulletsLeftText.text = "Bullets Left: " + _charger.ChargerAmmo;
        }

        private void CheckIfAnySerializedFieldObjectIsMissing() 
        {
            if (ObjectIsNull(_chicken) || ObjectIsNull(_showBulletsLeftText))
            {
                Debug.LogError("Missing referenced objects, deleting script!");

                Destroy(this);
            }
        }

        private void SetInventory() 
        {
            _chickenInventory = _chicken.GetComponent<CharacterInventory>();

            if (ObjectIsNull(_chickenInventory))
            {
                Debug.LogError("Missing inventory in chicken, deleting script!");

                Destroy(this);
            }
        }

        private bool ObjectIsNull(Object @object) 
        {
            return @object == null;
        }
    }
}