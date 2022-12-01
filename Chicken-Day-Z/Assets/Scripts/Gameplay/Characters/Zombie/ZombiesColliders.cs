using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Zombie 
{
    public class ZombiesColliders : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D[] _colliders;

        void Start()
        {
            for (short i = 0; i < _colliders.Length; i++) 
            {
                _colliders[i].enabled = true;
            }
        }

        public void EnableColliders() 
        {
            SetColliders(true);
        }

        public void DisableColliders()
        {
            SetColliders(false);
        }

        private void SetColliders(bool enable) 
        {
            for (short i = 0; i < _colliders.Length; i++)
            {
                _colliders[i].enabled = enable;
            }
        }
    }
}