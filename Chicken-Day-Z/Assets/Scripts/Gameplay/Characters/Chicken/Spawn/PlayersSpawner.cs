using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Chicken.Camera;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Spawn
{
    public class PlayersSpawner : MonoBehaviour, IResettable
    {
        [SerializeField] private GameObject[] _playersPrefabs;

        [SerializeField] private GameObject[] _playersSpawnPositions;

        [SerializeField] private GameObject _cameraPrefab;
       
        public static event Action<GameObject> OnPlayersInstantiated;

        private const short MaxPlayers = 2;

        private static short _initialAmountOfPlayers = 1; 

        private GameObject[] _players;

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetObject;
        }

        void Awake()
        {
            InstanciatePlayers();

            SetPlayersPositions();                       
        }

        void Start()
        {
            OnPlayersInstantiated?.Invoke(_players[0]);
        }

        public static void SetInitialAmountOfPlayers(short value)
        {
            if (value > MaxPlayers)
            {
                _initialAmountOfPlayers = MaxPlayers;
            }
            else if (value <= 0)
            {
                _initialAmountOfPlayers = 1;
            }
            else
            {
                _initialAmountOfPlayers = value;
            }
        }

        public void ResetObject()
        {
            SetPlayersPositions();
        }

        private void InstanciatePlayers() 
        {
            _players = new GameObject[_initialAmountOfPlayers];

            for (short i = 0; i < _players.Length; i++)
            {
                _players[i] = Instantiate(_playersPrefabs[i], _playersSpawnPositions[i].transform.position,
                    Quaternion.identity);

                InstanciateCamera(i);
            }
        }

        private void InstanciateCamera(short index) 
        {
            GameObject auxCamera = Instantiate(_cameraPrefab);

            CameraFollowingPlayer auxScript = auxCamera.GetComponent<CameraFollowingPlayer>();

            auxScript.PlayerIndex = index;
        }
        
        private void SetPlayersPositions() 
        {
            for (short i = 0; i < _players.Length; i++)
            {
                _players[i].transform.position = _playersSpawnPositions[i].transform.position;
            }
        }        
    }
}