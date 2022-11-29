using UnityEngine;
using ChickenDayZ.Gameplay.MainObjects.PowerUp;

namespace ChickenDayZ.Animations 
{    
    [RequireComponent(typeof(PowerUpObject), typeof(Animator))]
    public class ChestPlayAnimation : MonoBehaviour
    {
        private Animator _animator;                       

        void Awake()
        {
            _animator = GetComponent<Animator>();                        
        }

        public void SetAnimation(string animationName) 
        {
            _animator.SetTrigger(animationName);
        }
    }
}