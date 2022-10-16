using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.UI
{
    public class ShowReloadingText : MonoBehaviour
    {
        [SerializeField] private GameObject _chicken;
        
        [SerializeField] private TMP_Text _reloadingText;

        [SerializeField] private string _reloadingMeassege;

        [SerializeField] private string _waitingReloadMeassege;

        private CharacterInventory _chickenInventory;        
        
        private ReloadFirearm _reloadFirearm;

        private const short SerializeFieldObjectsCount = 2;

        void Awake()
        {
            DestroyScriptIfAnySerializedFieldObjectIsMissing();

            SetCharacterInventory();
        }

        void OnEnable()
        {
            if (_chickenInventory != null) 
            {
                _chickenInventory.OnEquippedItemSelected += SetChickenReloadMechanic;
            }
        }

        void OnDisable()
        {
            if (_chickenInventory != null) 
            {
                _chickenInventory.OnEquippedItemSelected -= SetChickenReloadMechanic;
            }            
        }

        void Start()
        {
            _reloadingText.text = _waitingReloadMeassege;            
        }

        void OnDestroy()
        {
            if (_reloadFirearm != null)
            {
                _reloadFirearm.OnStartReloading -= ShowReloadingMessage;

                _reloadFirearm.OnFinishedReloading -= HideReloadingMessage;
            }
        }

        private void ShowReloadingMessage()
        {
            _reloadingText.text = _reloadingMeassege;
        }

        private void HideReloadingMessage()
        {
            _reloadingText.text = _waitingReloadMeassege;
        }

        private void SetCharacterInventory() 
        {            
            _chickenInventory = _chicken.GetComponent<CharacterInventory>();

            if (_chickenInventory == null) 
            {
                Debug.LogError("Chicken has no inventory, deleting script!");

                Destroy(this);                
            }
        }       

        private void SetChickenReloadMechanic()
        {           
            if (_chickenInventory.EquippedItem is Firearm)
            {
                Firearm firearm = ((Firearm)_chickenInventory.EquippedItem);

                _reloadFirearm = firearm.ReloadFirearmMechanic;                

                _reloadFirearm.OnStartReloading += ShowReloadingMessage;

                _reloadFirearm.OnFinishedReloading += HideReloadingMessage;
            }
        }

        private void DestroyScriptIfAnySerializedFieldObjectIsMissing()
        {
            Object[] objects = new Object[SerializeFieldObjectsCount];

            objects[0] = _chicken;
            objects[1] = _reloadingText;

            if (ObjectFunctions.IsNullObjectInArray(objects))
            {
                Debug.LogError("Missing referenced objects, deleting script!");

                Destroy(this);
            }
        }
    }
}