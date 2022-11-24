using TMPro;
using UnityEngine;
using UnityEngine.UI;

using ChickenDayZ.Gameplay.MainObjects.PowerUp;

namespace ChickenDayZ.Gameplay.Chests
{
    public class UpdateBlockedTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _blockedTimerText;

        [SerializeField] private Image _marcoImage;        

        private PowerUpObject _powerUpObject;

        void Awake()
        {
            _powerUpObject = GetComponent<PowerUpObject>();
        }

        void Start()
        {
            _blockedTimerText.text = " ";

            _marcoImage.gameObject.SetActive(false);            

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

                _marcoImage.gameObject.SetActive(false);
            }
            else
            {
                _blockedTimerText.text = (int)_powerUpObject.GetBlockedChestTimerCountDown() + "";

                _marcoImage.gameObject.SetActive(true);
            }
        }
    }
}