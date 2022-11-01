using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Spawn
{
    public class PlayerSpawnPosition : MonoBehaviour, IResettable
    {
        private Vector3 _playersSpawnPosition;        
        
        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetObject;
        }        

        void Start()
        {
            SetPlayerPosition();
        }        

        public void ResetObject()
        {
            SetPlayerPosition();
        }        
        
        private void SetPlayerPosition() 
        {
            _playersSpawnPosition = gameObject.transform.position;
        }        
    }
}