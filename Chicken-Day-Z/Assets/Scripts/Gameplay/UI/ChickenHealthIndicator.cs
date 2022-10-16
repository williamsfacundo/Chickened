using UnityEngine;

using TMPro;
using ChickenDayZ.Gameplay.Health;

namespace ChickenDayZ.UI 
{
    public class ChickenHealthIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showChickenHealthText;

        //private ChickenHealth _chickenHealth;

        void Start()
        {
            //_chickenHealth = FindObjectOfType<ChickenHealth>();

            //_chickenHealth.OnHealthChanged += UpdateChickenHealthText;

            UpdateChickenHealthText();
        }

        void OnDestroy()
        {
            //_chickenHealth.OnHealthChanged -= UpdateChickenHealthText;
        }

        private void UpdateChickenHealthText() 
        {
            //_showChickenHealthText.text = "Chicken Health: " + _chickenHealth.Health;
        }
    }
}