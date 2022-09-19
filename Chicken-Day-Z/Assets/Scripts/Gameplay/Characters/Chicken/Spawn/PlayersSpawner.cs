using UnityEngine;
using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Spawn
{
    public class PlayersSpawner : MonoBehaviour, IResettable
    {
        [SerializeField] private GameObject[] _playersPrefabs;

        [SerializeField] private GameObject[] _playersSpawnPositions;

        private const short MaxPlayers = 2;

        private static short _initialAmountOfPlayers = 1; 

        private GameObject[] _players;                

        void Awake()
        {
            InstanciatePlayers();

            SetPlayersPositions();            
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
            }
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