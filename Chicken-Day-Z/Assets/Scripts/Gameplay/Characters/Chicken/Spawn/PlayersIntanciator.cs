using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Chicken.Spawn
{
    public class PlayersIntanciator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _playersPrefabs;

        [SerializeField] private GameObject[] _playersSpawnPositions;

        private const short MaxPlayers = 2;

        private static short _initialAmountOfPlayers = 1; 

        private GameObject[] _players;

        public static short InitialAmountOfPlayers 
        {
            set 
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
        }

        private void Awake()
        {
            InstanciatePlayers();

            SetPlayersPositions();
        }

        private void InstanciatePlayers() 
        {
            _players = new GameObject[_playersSpawnPositions.Length];

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