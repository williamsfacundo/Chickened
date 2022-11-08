using UnityEngine;
using ChickenDayZ.Gameplay.MainObjects.PowerUp;

namespace ChickenDayZ.Animations 
{    
    [RequireComponent(typeof(PowerUpObject), typeof(Animator))]
    public class ChestPlayAnimation : MonoBehaviour
    {
        private Animator _animator;

        private PowerUpObject _powerUpObject;                 

        void Awake()
        {
            _animator = GetComponent<Animator>();

            _powerUpObject = GetComponent<PowerUpObject>();            
        }

        void Start()
        {
            _powerUpObject.OnPowerUpInteracted += SetAnimation;
        }

        void OnDestroy()
        {
            _powerUpObject.OnPowerUpInteracted -= SetAnimation;
        }

        private void SetAnimation()
        {
            if (PowerUpObject.PowerUpAvailable && !_powerUpObject.IsChestBlocked) 
            {
                _animator.SetTrigger("Opened");
            }
            else 
            {
                _animator.SetTrigger("Blocked");
            }            
        }        
    }
}