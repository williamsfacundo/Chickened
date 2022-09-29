using UnityEngine;

using TMPro;

using ChickenDayZ.Gameplay.Characters.Chicken.Score;

namespace ChickenDayZ.UI 
{
    public class ShowChickenScoreText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        private ChickenScore _chickenScore;

        void Start()
        {
            _chickenScore = FindObjectOfType<ChickenScore>();
        }

        void Update()
        {
            UpdateScoreText();            
        }

        private void UpdateScoreText()
        {
            _scoreText.text = "Chicken score: " + _chickenScore.Score;
        }
    }
}