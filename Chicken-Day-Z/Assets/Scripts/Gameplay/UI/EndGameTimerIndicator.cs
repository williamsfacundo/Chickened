using UnityEngine;
using TMPro;
using ChickenDayZ.GameplayItems;

namespace ChickenDayZ.UI 
{
    public class EndGameTimerIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showEndGameTimerText;
    
        private EndGameTimer _endGameTimer;

        private short _timer;

        private void Awake()
        {
            _endGameTimer = FindObjectOfType<EndGameTimer>();
        }

        private void LateUpdate()
        {
            UpdateEndGameTimerText();
        }

        private void UpdateEndGameTimerText() 
        {
            _timer = (short)_endGameTimer.Timer;

            _showEndGameTimerText.text = _timer.ToString();
        }
    }
}