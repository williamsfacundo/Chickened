using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.Health;

namespace ChickenDayZ.UI 
{
    public class BaseHealthIndicator : MonoBehaviour
    {
        [SerializeField] private ObjectHealth _baseHealth;

        [SerializeField] private TMP_Text _showBaseHealthText;        
        
        void Awake()
        {
            _baseHealth.OnCurrentHealthChanged += UpdateBaseHealthText;            
        }

        void OnDestroy()
        {
            _baseHealth.OnCurrentHealthChanged -= UpdateBaseHealthText;
        }

        void Start()
        {
            UpdateBaseHealthText();
        }        

        private void UpdateBaseHealthText()
        {
            _showBaseHealthText.text = "Base Health: " + _baseHealth.CurrentHealth;
        }
    }
}