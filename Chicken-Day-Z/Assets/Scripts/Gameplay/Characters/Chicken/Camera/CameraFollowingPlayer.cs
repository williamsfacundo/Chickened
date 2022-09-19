using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Movement;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Camera 
{
    public class CameraFollowingPlayer : MonoBehaviour
    {
        private CharacterMovementController[] _characterMovementController;

        private GameObject _player;

        private short _playerIndex;

        private Vector3 _offset;

        public short PlayerIndex 
        {
            set 
            {
                _playerIndex = value;
            }
        }

        private void Awake()
        {
            _characterMovementController = FindObjectsOfType<CharacterMovementController>();

            _player = _characterMovementController[_playerIndex].gameObject;

            _characterMovementController = null;

            _offset = new Vector3(0f, 0f, 10f);
        }

        void LateUpdate()
        {
            gameObject.transform.position = _player.transform.position - _offset;                        
        }
    }
}