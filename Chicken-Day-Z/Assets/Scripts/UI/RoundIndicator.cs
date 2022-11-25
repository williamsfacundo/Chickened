using UnityEngine;
using TMPro;

using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.UI 
{
    public class RoundIndicator : MonoBehaviour
    {
        [SerializeField] private ZombiesSpawner _zombiesSpawner;
        
        [SerializeField] private TMP_Text _showRoundText;

        [SerializeField] [Range(1f, 5f)] private float _timeForTextToBanish;

        private Timer _timerToBanishText;

        private void Awake()
        {
            _timerToBanishText = new Timer(_timeForTextToBanish);

            if (_zombiesSpawner == null) 
            {
                Debug.LogError("Assing a zombie spawner!");
            }
        }                               

        void OnEnable()
        {
            if (_zombiesSpawner != null) 
            {
                _zombiesSpawner.OnRoundChanged += ShowRoundText;
            }
        }

        void OnDisable()
        {
            if (_zombiesSpawner != null)
            {
                _zombiesSpawner.OnRoundChanged -= ShowRoundText;
            }
        }

        void Update()
        {
            if (!_timerToBanishText.TimerFinished) 
            {
                _timerToBanishText.DecreaseTimer();

                if (_timerToBanishText.TimerFinished) 
                {
                    HideRoundText();
                }
            }
        }        

        private void ShowRoundText() 
        {
            _showRoundText.text = _zombiesSpawner.Round.ToString();

            _timerToBanishText.ResetTimer();
        }

        private void HideRoundText() 
        {
            _showRoundText.text = string.Empty;
        }
    }
}