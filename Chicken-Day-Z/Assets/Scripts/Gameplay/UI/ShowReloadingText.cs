using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.Characters.Health;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;
using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.UI 
{
    public class ShowReloadingText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _reloadingText;

        private const string _reloadingMeassege = "(RELOADING)";

        private ReloadFirearm _reloadFirearm;

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += FindReloader;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset += FindReloader;
        }

        void Start()
        {
            FindReloader();
        }

        private void Update()
        {
            if (_reloadFirearm.IsReloading) 
            {
                ShowReloadingMeassege();
            }
            else 
            {
                HideReloadingMeassege();
            }           
        }

        private void ShowReloadingMeassege() 
        {
            _reloadingText.text = _reloadingMeassege;
        }

        private void HideReloadingMeassege()
        {
            _reloadingText.text = " ";
        }

        void FindReloader() 
        {
            _reloadFirearm = ((Firearm)FindObjectOfType<ChickenHealth>().gameObject.GetComponent<CharacterInventory>().EquippedItem).ReloadFirearmMechanic;
        }
    }
}