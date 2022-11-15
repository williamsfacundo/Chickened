using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.MainObjects.PowerUp;

namespace ChickenDayZ.Gameplay.MainObjects.Buildings 
{
    public class UpdateBlockedTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _blockedTimerText;    

        private PowerUpObject _powerUpObject;

        void Awake()
        {
            _powerUpObject = GetComponent<PowerUpObject>();
        }

        void Start()
        {
            _blockedTimerText.text = " ";

            _powerUpObject.OnBlockedChestTimerChanged += UpdateBlockedTimerText;
        }

        void OnDestroy()
        {
            _powerUpObject.OnBlockedChestTimerChanged -= UpdateBlockedTimerText;
        }

        private void UpdateBlockedTimerText()
        {
            if (_powerUpObject.GetBlockedChestTimerCountDown() <= 0f)
            {
                _blockedTimerText.text = " ";
            }
            else
            {
                _blockedTimerText.text = (int)_powerUpObject.GetBlockedChestTimerCountDown() + "";
            }
        }
    }
}