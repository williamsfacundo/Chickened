using System;
using UnityEngine;
using UnityEngine.UI;

using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.UI
{
    public class RoundFrameAnimation : MonoBehaviour
    {
        [SerializeField] private ZombiesSpawner _zombiesSpawner;

        [SerializeField] private Image _frameImage;

        [SerializeField] private Sprite[] _frameSpritesArray;

        [SerializeField] private float _animationSpeed;

        [SerializeField] private int _showTextIndex;

        [SerializeField] private int _hideTextIndex;

        public event Action<string> OnShowTextIndex;
        
        public event Action OnHideTextIndex;             
        
        public event Action OnFinishedAnimation;

        private Timer _animationTimer;
        
        private int _spriteIndex;

        private bool _animating;

        public bool Animating 
        {
            get 
            {
                return _animating;
            }
        }

        private void Awake()
        {
            if (_zombiesSpawner == null)
            {
                Debug.LogError("Assing a zombie spawner!");
            }

            if (_zombiesSpawner != null)
            {
                _zombiesSpawner.OnRoundChanged += StartAnimation;
            }

            GameplayResetter.OnGameplayReset += StopAnimation;

            StopAnimation();
        }        

        void Update()
        {
            if (_animating) 
            {
                if (_animationTimer.TimerFinished) 
                {
                    UpdateAnimation();

                    _animationTimer.ResetTimer();
                }               

                _animationTimer.DecreaseTimer();
            }            
        }

        void OnDestroy()
        {
            if (_zombiesSpawner != null)
            {
                _zombiesSpawner.OnRoundChanged -= StartAnimation;                
            }

            GameplayResetter.OnGameplayReset -= StopAnimation;
        }

        public void StartAnimation()
        {
            _animating = true;

            _spriteIndex = 0;

            _frameImage.gameObject.SetActive(true);

            if (_animationTimer == null) 
            {
                _animationTimer = new Timer(_animationSpeed);
            }
            else 
            {
                _animationTimer.ResetTimer();
            }
        }

        private void StopAnimation()
        {
            _animating = false;

            _frameImage.gameObject.SetActive(false);
        }

        private void UpdateAnimation()
        {
            if (_spriteIndex >= _frameSpritesArray.Length)
            {
                OnFinishedAnimation?.Invoke();

                StopAnimation();

                return;
            }
                        
            _frameImage.sprite = _frameSpritesArray[_spriteIndex];
            
            _spriteIndex += 1;
            
            if (_spriteIndex == _showTextIndex) 
            {
                OnShowTextIndex?.Invoke(_zombiesSpawner.Round.ToString());
            }
            else if (_spriteIndex == _hideTextIndex) 
            {
                OnHideTextIndex?.Invoke();
            }                       
        }
    }
}