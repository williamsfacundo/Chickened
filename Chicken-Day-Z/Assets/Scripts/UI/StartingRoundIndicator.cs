using UnityEngine;
using TMPro;

using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.UI 
{
    public class StartingRoundIndicator : MonoBehaviour
    {
        [SerializeField] private ZombiesSpawner _zombiesSpawner;

        [SerializeField] private TMP_Text _showStartingRoundText;

        [SerializeField] private TMP_Text _showStartingRoundText2;

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
                _showStartingRoundText.text = "ROUND STARTS IN " + (short)_zombiesSpawner.TimerBeforeRoundStarts.CountDown;

                _showStartingRoundText2.text = "GO FIND A POWER UP press E when touching chest";
            }
            else 
            {
                _showStartingRoundText.text = " ";
                _showStartingRoundText2.text = " ";
            }
        }
    }
}