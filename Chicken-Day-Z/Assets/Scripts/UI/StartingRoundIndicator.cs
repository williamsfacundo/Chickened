using TMPro;
using UnityEngine;
using UnityEngine.UI;

using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.UI 
{
    public class StartingRoundIndicator : MonoBehaviour
    {
        [SerializeField] private Image _chestIndicator;

        [SerializeField] private ZombiesSpawner _zombiesSpawner;

        [SerializeField] private TMP_Text _showStartingRoundText;        

        private void Awake()
        {            
            if (_zombiesSpawner == null)
            {
                Debug.LogError("Assing a zombie spawner!");
            }
        }

        void OnEnable()
        {
            _zombiesSpawner.OnTimerBeforeRoundStartsChanged += UpdateText;
        }

        void OnDisable()
        {
            _zombiesSpawner.OnTimerBeforeRoundStartsChanged -= UpdateText;
        }

        private void UpdateText()
        {
            if (_zombiesSpawner.TimerBeforeRoundStarts.CountDown != 0f) 
            {
                _chestIndicator.gameObject.SetActive(true);
                
                _showStartingRoundText.text = "ROUND STARTS IN " + (short)_zombiesSpawner.TimerBeforeRoundStarts.CountDown;
            }
            else 
            {
                _chestIndicator.gameObject.SetActive(false);

                _showStartingRoundText.text = " ";                
            }
        }
    }
}