using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.Characters.Health;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;

namespace ChickenDayZ.UI 
{
    public class ShowReloadingText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _reloadingText;

        private const string _reloadingMeassege = "(RELOADING)";

        private ReloadFirearm _reloadFirearm;

        private void Start()
        {
            _reloadFirearm = ((Firearm)FindObjectOfType<ChickenHealth>().gameObject.GetComponent<CharacterInventory>().EquippedItem).ReloadFirearmMechanic;
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

        void ShowReloadingMeassege() 
        {
            _reloadingText.text = _reloadingMeassege;
        }

        void HideReloadingMeassege()
        {
            _reloadingText.text = " ";
        }
    }
}