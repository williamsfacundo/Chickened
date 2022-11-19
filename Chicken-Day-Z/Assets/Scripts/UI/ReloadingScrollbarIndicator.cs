using TMPro;
using UnityEngine;
using UnityEngine.UI;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.UI
{
    public class ReloadingScrollbarIndicator : MonoBehaviour
    {       
        [SerializeField] private Scrollbar _reloadingScrollbar;       

        [SerializeField] private CharacterInventory _chickenInventory;              
        
        private ReloadFirearm _reloadFirearm;       

        void Awake()
        {
            HideReloadingScrollbar();

            _chickenInventory.OnEquippedItemSelected += SetChickenReloadMechanic;

            GameplayResetter.OnGameplayReset += HideReloadingScrollbar;
        }        

        void Update()
        {
            UpdateScrollbar();
        }

        void OnDestroy()
        {
            _chickenInventory.OnEquippedItemSelected -= SetChickenReloadMechanic;

            GameplayResetter.OnGameplayReset -= HideReloadingScrollbar;

            if (_reloadFirearm != null)
            {
                _reloadFirearm.OnStartReloading -= ShowReloadingScrollbar;

                _reloadFirearm.OnFinishedReloading -= HideReloadingScrollbar;                
            }
        }

        private void ShowReloadingScrollbar()
        {
            _reloadingScrollbar.gameObject.SetActive(true);

            _reloadingScrollbar.value = 1f;
        }

        private void HideReloadingScrollbar()
        {
            _reloadingScrollbar.gameObject.SetActive(false);
        }               

        private void SetChickenReloadMechanic()
        {           
            if (_chickenInventory.EquippedItem is Firearm)
            {
                Firearm firearm = ((Firearm)_chickenInventory.EquippedItem);

                _reloadFirearm = firearm.ReloadFirearmMechanic;                

                _reloadFirearm.OnStartReloading += ShowReloadingScrollbar;

                _reloadFirearm.OnFinishedReloading += HideReloadingScrollbar;
            }
        } 
        
        private void UpdateScrollbar() 
        {
            if (_reloadingScrollbar.gameObject.activeSelf) 
            {
                _reloadingScrollbar.value = Mathf.Clamp01(_reloadFirearm.TimerCountDown);                
            }
        }
    }
}