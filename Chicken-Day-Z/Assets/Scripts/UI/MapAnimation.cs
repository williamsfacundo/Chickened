using UnityEngine;
using UnityEngine.UI;

using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Characters.Zombie;

namespace ChickenDayZ.UI 
{
    public class MapAnimation : MonoBehaviour
    {
        [SerializeField] private ZombiesSpawner _zombiesSpawner;

        [SerializeField] private Image _frameImage;

        [SerializeField] private Sprite[] _frameSpritesArray;

        [SerializeField] private Sprite _nonAnimationSprite;

        [SerializeField] private float _animationSpeed;

        private Timer _animationTimer;

        private int _spriteIndex;

        void Start()
        {
            _animationTimer = new Timer(_animationSpeed);
            
            ResetAnimation();
        }

        void Update()
        {
            if (!_zombiesSpawner.TimerBeforeRoundStarts.TimerFinished && _zombiesSpawner.Round != 1)
            {
                if (_animationTimer.TimerFinished)
                {
                    UpdateAnimation();

                    _animationTimer.ResetTimer();
                }

                _animationTimer.DecreaseTimer();
            }
            else if (_frameImage.sprite != _nonAnimationSprite)
            {
                _frameImage.sprite = _nonAnimationSprite;
            }
        }

        public void ResetAnimation()
        {
            _spriteIndex = 0;

            _animationTimer.ResetTimer();
        }        

        private void UpdateAnimation()
        {
            if (_spriteIndex >= _frameSpritesArray.Length)
            {
                ResetAnimation();                
            }

            _frameImage.sprite = _frameSpritesArray[_spriteIndex];

            _spriteIndex += 1;            
        }
    }
}