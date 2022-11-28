using TMPro;
using UnityEngine;
using UnityEngine.UI;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.UI 
{
    public class StartingRoundIndicator : MonoBehaviour
    {
        [SerializeField] private Image _chestIndicator;

        [SerializeField] private ZombiesSpawner _zombiesSpawner;

        [SerializeField] private TMP_Text _showStartingRoundText;

        [SerializeField] private RoundFrameAnimation _roundFrameAnimation;

        private bool _roundAnimationFinished;

        private void Awake()
        {            
            if (_zombiesSpawner == null)
            {
                Debug.LogError("Assing a zombie spawner!");
            }

            _roundFrameAnimation = GetComponent<RoundFrameAnimation>();
        }

        void Start()
        {
            _chestIndicator.gameObject.SetActive(false);

            _showStartingRoundText.text = string.Empty;

            _roundAnimationFinished = false;            

            _roundFrameAnimation.OnFinishedAnimation += ShowText;

            _zombiesSpawner.OnTimerBeforeRoundStartsChanged += UpdateText;

            GameplayResetter.OnGameplayReset += CantShowText;
        }      

        void OnDestroy() 
        {
            _zombiesSpawner.OnTimerBeforeRoundStartsChanged -= UpdateText;
            
            _roundFrameAnimation.OnFinishedAnimation -= ShowText;

            GameplayResetter.OnGameplayReset += CantShowText;
        }

        private void UpdateText()
        {
            if (_zombiesSpawner.TimerBeforeRoundStarts.CountDown != 0f) 
            {
                if (_roundAnimationFinished) 
                {
                    _chestIndicator.gameObject.SetActive(true);
                
                    _showStartingRoundText.text = "ROUND STARTS IN " + (short)_zombiesSpawner.TimerBeforeRoundStarts.CountDown;
                }                
            }
            else 
            {
                _chestIndicator.gameObject.SetActive(false);

                _showStartingRoundText.text = string.Empty;

                _roundAnimationFinished = false;
            }
        } 
        
        private void ShowText() 
        {
            if (_zombiesSpawner.Round != 1) 
            {
                _roundAnimationFinished = true;
            }
        }

        private void CantShowText() 
        {
            _roundAnimationFinished = false;
        }
    }
}