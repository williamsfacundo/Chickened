using UnityEngine;

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
            if (UnityEngine.Input.GetMouseButton(_fireMouseButton))
            {
                if (_itemActionController != null)
                {
                    _itemActionController.ExecuteAction = true;                    
                }
            }
        }
    }
}