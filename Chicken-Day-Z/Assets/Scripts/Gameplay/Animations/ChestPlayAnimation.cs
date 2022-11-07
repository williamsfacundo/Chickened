using UnityEngine;
using ChickenDayZ.Gameplay.MainObjects.PowerUp;

namespace ChickenDayZ.Animations 
{
    [RequireComponent(typeof(AnimationsManager))]
    public class ChestPlayAnimation : MonoBehaviour
    {
        [SerializeField] private PowerUpObject _powerUpObject;        

        [SerializeField] private string _openChestAnimationNames;

        [SerializeField] private string _closedChestAnimationsNames;

        private AnimationsManager _chestAnimationsManager;

        void Awake()
        {
            _chestAnimationsManager = GetComponent<AnimationsManager>();
        }

        void OnEnable()
        {
            _powerUpObject.OnPowerUpInteracted += SetAnimation;
        }

        void OnDisable()
        {
            _powerUpObject.OnPowerUpInteracted -= SetAnimation;
        }

        private void SetAnimation()
        {
            _chestAnimationsManager.ChangeAnimation(GetAnimation());
        }

        private string GetAnimation()
        {
            if (PowerUpObject.PowerUpAvailable) 
            {
                return _openChestAnimationNames;
            }
            else 
            {
                return _closedChestAnimationsNames;
            }            
        }
    }
}