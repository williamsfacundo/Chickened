using UnityEngine;

using TMPro;
using ChickenDayZ.Gameplay.Characters.Health;

namespace ChickenDayZ.UI 
{
    public class ChickenHealthIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showChickenHealthText;

        private ChickenHealth _chickenHealth;

        void Start()
        {
            _chickenHealth = FindObjectOfType<ChickenHealth>();
        }

        void Update()
        {
            UpdateChickenHealthText();            
        }

        private void UpdateChickenHealthText() 
        {
            _showChickenHealthText.text = "Chicken Health: " + _chickenHealth.Health;
        }
    }
}