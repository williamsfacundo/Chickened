using UnityEngine;

namespace ChickenDayZ.Animations 
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimationsManager : MonoBehaviour
    {
        private Animator _animator;

        private string _currentAnimationName;       

        void Awake()
        {
            _animator = GetComponent<Animator>();            
        }       

        public void ChangeAnimation(string newAnimation) 
        {
            if (_currentAnimationName != null) 
            {
                if (_currentAnimationName == newAnimation)
                {
                    return;
                }
            }            
            
            _currentAnimationName = newAnimation;

            PlayAnimation();
        }        

        private void PlayAnimation() 
        {
            _animator.Play(_currentAnimationName);            
        }    
    }    
}