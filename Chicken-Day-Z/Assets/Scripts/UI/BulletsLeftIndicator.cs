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

        private const short SerializeFieldObjectsCount = 2;

        void Awake()
        {
            DestroyScriptIfAnySerializedFieldObjectIsMissing();

            SetInventory();
        }        

        void OnEnable()
        {
            if (_chickenInventory != null) 
            {
                _chickenInventory.OnEquippedItemSelected += SetCharger;
            }
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

        private void SetInventory()
        {
            _chickenInventory = _chicken.GetComponent<CharacterInventory>();

            if (_chickenInventory == null)
            {
                Debug.LogError("Missing inventory in chicken, deleting script!");

                Destroy(this);
            }
        }

        private void SetCharger() 
        {
            if (_chickenInventory.EquippedItem is Firearm)
            {
                _charger = ((Firearm)_chickenInventory.EquippedItem).Charger;

                _charger.OnAmmoChanged += UpdateBulletsLeftText;

                UpdateBulletsLeftText();
            }                      
        }

        private void UpdateBulletsLeftText()
        {            
            _showBulletsLeftText.text = _charger.ChargerAmmo + " / " + _charger.ChargerMaxAmmo;
        }

        private void DestroyScriptIfAnySerializedFieldObjectIsMissing() 
        {
            Object[] objects = new Object[SerializeFieldObjectsCount];

            objects[0] = _chicken;
            objects[1] = _showBulletsLeftText;

            if (ObjectFunctions.IsNullObjectInArray(objects))
            {
                Debug.LogError("Missing referenced objects, deleting script!");

                Destroy(this);
            }
        }                
    }
}