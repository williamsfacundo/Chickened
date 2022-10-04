using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.Characters.Inventory;
using ChickenDayZ.Gameplay.Characters.Health;
using ChickenDayZ.Gameplay.Characters.Inventory.Weapons;
using ChickenDayZ.Gameplay.Characters.Chicken.Spawn;

namespace ChickenDayZ.UI 
{
    public class ShowReloadingText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _reloadingText;

        [SerializeField] private string _reloadingMeassege = "(RELOADING)";

        [SerializeField] private string _waitingReloadMeassege = "Reload (R)";

        private ReloadFirearm _reloadFirearm;

        private GameObject _chicken;

        Firearm auxFirearm;

        void OnEnable()
        {
            PlayersSpawner.OnPlayersInstantiated += FindChicken;            
        }

        void OnDisable()
        {
            PlayersSpawner.OnPlayersInstantiated -= FindChicken;            
        }        

        void OnDestroy()
        {
            if (_reloadFirearm != null) 
            {
                _reloadFirearm.OnStartReloading -= ShowReloadingMessage;

                _reloadFirearm.OnFinishedReloading -= HideReloadingMessage;
            }            
        }

        void Start()
        {
            _reloadingText.text = _waitingReloadMeassege;
        }

        private void ShowReloadingMessage() 
        {
            _reloadingText.text = _reloadingMeassege;
        }

        private void HideReloadingMessage()
        {
            _reloadingText.text = _waitingReloadMeassege;
        }

        private void FindChicken(GameObject chicken) 
        {
            _chicken = chicken;
            
            FindChickenFirearm();

            FindChickenReloadMechanic();
        }

        private void FindChickenFirearm() 
        {
            if (_chicken != null)
            {
                auxFirearm = ((Firearm)_chicken.GetComponent<CharacterInventory>().EquippedItem);               
            }            
        }

        private void FindChickenReloadMechanic() 
        {
            if (auxFirearm != null)
            {
                _reloadFirearm = auxFirearm.ReloadFirearmMechanic;

                _reloadFirearm.OnStartReloading += ShowReloadingMessage; //message

                _reloadFirearm.OnFinishedReloading += HideReloadingMessage;
            }
        }
    }
}