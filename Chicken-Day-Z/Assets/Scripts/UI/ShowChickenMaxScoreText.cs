using UnityEngine;

using TMPro;

using ChickenDayZ.Gameplay.Characters.Chicken.Score;

namespace ChickenDayZ.UI 
{    
    public class ShowChickenMaxScoreText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _maxScoreText;        

        void Start()
        {
            ChickenMaxScore.OnMaxScoreProcessed += UpdateMaxScoreText;
        }

        void OnDestroy()
        {
            ChickenMaxScore.OnMaxScoreProcessed -= UpdateMaxScoreText;
        }

        private void UpdateMaxScoreText(int maxScore)
        {
            _maxScoreText.text = maxScore.ToString();
        }
    }
}