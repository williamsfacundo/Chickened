using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Inventory.ItemActions;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Input 
{
    public class ChickenReloadInput : MonoBehaviour
    {
        [SerializeField] private CharacterItemActionController _itemActionController;

        [SerializeField] private KeyCode _reloadKey;

        void Update()
        {
            ReloadInput();
        }

        private void ReloadInput()
        {
            if (UnityEngine.Input.GetKeyDown(_reloadKey))
            {
                if (_itemActionController != null)
                {
                    _itemActionController.ExecuteAction = true;                    
                }
            }
        }
    }
}