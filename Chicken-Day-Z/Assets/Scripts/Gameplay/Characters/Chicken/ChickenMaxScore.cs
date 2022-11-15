using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Score 
{
    [RequireComponent(typeof(ChickenScore))]
    public class ChickenMaxScore : MonoBehaviour
    {
        private ChickenScore _chickenScore;

        public static event Action<int> OnMaxScoreProcessed;

        private int _maxScore;

        private const string ScoreKey = "MaxScore";

        public int MaxScore 
        {
            get 
            {
                return _maxScore;
            }
        }

        void Awake()
        {
            _chickenScore = GetComponent<ChickenScore>();
        }

        void Start()
        {               
            _maxScore = PlayerPrefs.GetInt(ScoreKey, 0);

            ScenesManager.OnGameplayToEndGame += UpdateMaxScore;
        }

        void OnDestroy()
        {
            ScenesManager.OnGameplayToEndGame -= UpdateMaxScore;
        }

        private void UpdateMaxScore() 
        {
            if (_maxScore < _chickenScore.Score) 
            {
                _maxScore = (int)_chickenScore.Score;

                PlayerPrefs.SetInt(ScoreKey, _maxScore);
            }
            
            OnMaxScoreProcessed?.Invoke(_maxScore);
        }
    }
}