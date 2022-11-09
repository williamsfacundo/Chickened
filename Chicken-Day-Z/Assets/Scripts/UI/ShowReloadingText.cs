using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.UI
{
    public class ShowReloadingText : MonoBehaviour
    {       
        [SerializeField] private TMP_Text _reloadingText;

        [SerializeField] private CharacterInventory _chickenInventory;        
        
        [SerializeField] private string _reloadingMeassege;        
        
        private ReloadFirearm _reloadFirearm;

        void Start()
        {
            HideReloadingMessage();            
        }

        void OnEnable()
        {
            _chickenInventory.OnEquippedItemSelected += SetChickenReloadMechanic;

            GameplayResetter.OnGameplayReset += HideReloadingMessage;
        }

        void OnDisable()
        {
            _chickenInventory.OnEquippedItemSelected -= SetChickenReloadMechanic;

            GameplayResetter.OnGameplayReset -= HideReloadingMessage;
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
            _reloadingText.text = " ";
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
    }
}