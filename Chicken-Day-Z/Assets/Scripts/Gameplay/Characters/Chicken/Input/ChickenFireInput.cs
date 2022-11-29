using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Inventory.ItemActions;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Input 
{
    public class ChickenFireInput : MonoBehaviour
    {
        [SerializeField] private CharacterItemActionController _itemActionController;

        [SerializeField] [Range(0, 2)] private int _fireMouseButton;

        void Update()
        {
            FireInput();
        }

        private void FireInput()
        {
            if (UnityEngine.Input.GetMouseButtonDown(_fireMouseButton) && ScenesManager.InGameplay)
            {
                if (_itemActionController != null)
                {
                    _itemActionController.ExecuteAction = true;                    
                }
            }
        }
    }
}