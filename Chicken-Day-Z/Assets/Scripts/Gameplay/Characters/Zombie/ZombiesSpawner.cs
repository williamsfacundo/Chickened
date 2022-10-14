using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Characters.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{
    public class ZombiesSpawner : MonoBehaviour, IResettable
    {
        [SerializeField] private GameObject[] _zombiePrefabs;        

        [SerializeField] private GameObject[] _spawnPoints;

        [SerializeField] private GameObject _eggBase;

        [SerializeField] [Range(1, 100)] private short[] _zombieSpawnPercentages; //In total must reached 100
        
        [SerializeField] private float _timeBeforeRoundStarts;

        [SerializeField] private float _minNextZombieSpawnTime; //Each round this number decreases

        [SerializeField] private float _maxNextZombieSpawnTime; //Each round this number decreases

        [SerializeField] [Range(1, 100)] private short[] _maxZombiesPerType;

        [SerializeField] [Range(1, 100)] private short _nextRoundSpawnTimesDecreasePercentage; //How much the numbers above will decrease

        [SerializeField] private short _initialZombiesToSpawned;

        public event Action OnRoundChanged;

        private const short MaxPercentagesValue = 100;

        private const short InitialRound = 1;

        private const short NullIndex = -1;

        private GameObject[] _zombieInstances;

        private GameObject _chicken;

        private Timer _timerBeforeRoundStarts;

        private Timer _timerForNextZombie;       

        private short _round;

        private short _zombiesLeftToSpawn;

        public short Round 
        {
            get 
            {
                return _round;
            }
        }

        void Awake()
        {            
            CreateZombiesArrayWithZombiesInstantiated(_zombiePrefabs, _maxZombiesPerType);
            
            _timerBeforeRoundStarts = new Timer(_timeBeforeRoundStarts);

            _timerForNextZombie = new Timer(UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime));                        
        }

        private void Start()
        {
            _round = InitialRound;

            OnRoundChanged?.Invoke();

            _zombiesLeftToSpawn = _initialZombiesToSpawned;

            _chicken = FindObjectOfType<ChickenHealth>().gameObject;

            CheckIfPercentagesAreRight();

            CheckIfArraySizesAreEqual();
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;
        }        

        void Update() 
        {
            if (_timerBeforeRoundStarts.TimerFinished) 
            {
                if (_zombiesLeftToSpawn > 0) 
                {
                    _timerForNextZombie.DecreaseTimer();

                    if (_timerForNextZombie.TimerFinished)
                    {
                        ActivateRandomZombie();                        
                    }
                }
                else if (ZombieHealth.ZombiesActiveInstances <= 0) 
                {
                    //Funcion next round que setea lo necesario para la siguiente ronda
                    NextRound();
                }                
            }
            else 
            {
                _timerBeforeRoundStarts.DecreaseTimer();
            }            
        }

        public void ResetObject()
        {
            _timerBeforeRoundStarts.ResetTimer();

            _timerForNextZombie.Time = UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime);

            _timerForNextZombie.ResetTimer();

            _round = InitialRound;

            OnRoundChanged?.Invoke();

            _zombiesLeftToSpawn = _initialZombiesToSpawned;

            for (short i = 0; i < _zombieInstances.Length; i++) 
            {
                _zombieInstances[i].SetActive(false);
            }
        }

        private void CheckIfPercentagesAreRight()
        {
            short percentagesSumed = 0;

            for (short i = 0; i < _zombieSpawnPercentages.Length; i++)
            {
                percentagesSumed += _zombieSpawnPercentages[i];
            }

            if (percentagesSumed != MaxPercentagesValue)
            {
                Debug.LogError("The sum of the spawn percentages must be exactly 100!");

                Destroy(gameObject);
            }
        }

        private void CheckIfArraySizesAreEqual() 
        {
            if (_zombiePrefabs.Length != _zombieSpawnPercentages.Length || _zombiePrefabs.Length != _maxZombiesPerType.Length) 
            {
                Debug.LogError("All array sizes must be equal except for the spawn points array!");

                Destroy(gameObject);                
            }
        }

        private void CreateZombiesArrayWithZombiesInstantiated(GameObject[] prefabs, short[] maxZombiesPerType)
        {
            if (prefabs.Length == maxZombiesPerType.Length)
            {
                short dynamicSize = 0;
                short index = 0;
                short maxZombies = 0;

                for (short i = 0; i < maxZombiesPerType.Length; i++)
                {
                    maxZombies += maxZombiesPerType[i];
                }

                _zombieInstances = new GameObject[maxZombies];

                for (short i = 0; i < prefabs.Length; i++)
                {
                    dynamicSize += maxZombiesPerType[i];

                    for (short v = index; v < dynamicSize; v++)
                    {
                        _zombieInstances[v] = Instantiate(prefabs[i], transform.position, Quaternion.identity);

                        _zombieInstances[v].SetActive(false);
                    }

                    index = dynamicSize;
                }
            }
            else
            {
                Debug.LogError("Not posible to create zombies if arrays sizes dont match!");

                Destroy(gameObject);
            }
        }

        private void ActivateRandomZombie() 
        {
            short zombieTypeIndex = GetRandomZombieType();

            if (zombieTypeIndex != NullIndex) 
            {
                short startingIndex = 0;

                short endOfIndex = 0;

                for (short i = 0; i < zombieTypeIndex; i++) 
                {
                    startingIndex += _maxZombiesPerType[i];
                }   

                for (short i = 0; i <= zombieTypeIndex; i++)
                {
                    endOfIndex += _maxZombiesPerType[i];
                }

                if (startingIndex != 0) 
                {
                    startingIndex -= 1;
                }                

                for (short i = startingIndex; i < endOfIndex; i++) //Aca no se tiene en cuenta el echo de que puede llegar al final y no haber instancias desactivadas 
                {
                    if (_zombieInstances[i].activeSelf == false) 
                    {
                        _zombieInstances[i].GetComponent<ZombieHealth>().ResetObject();
                        
                        _zombieInstances[i].transform.position = GetRandomSpawnPosition();

                        int aux = UnityEngine.Random.Range(1, 3);

                        switch (aux) 
                        {
                            case 1:

                                //_zombieInstances[i].GetComponent<ZombieMovement>().Target = _chicken;
                                break;

                            case 2:
                                //_zombieInstances[i].GetComponent<ZombieMovement>().Target = _eggBase;
                                break;
                        }
                        
                        _zombieInstances[i].SetActive(true);

                        _zombiesLeftToSpawn -= 1;

                        _timerForNextZombie.Time = UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime);

                        _timerForNextZombie.ResetTimer();

                        break;
                    }                   
                }                
            }
            else 
            {
                Debug.LogError("Error getting zombie random array position in index");
            }
        }

        private short GetRandomZombieType() 
        {
            int random = UnityEngine.Random.Range(1, MaxPercentagesValue + 1);           

            short min = 0;

            short max = 0;            

            for (short i = 0; i < _zombieSpawnPercentages.Length; i++) 
            {
                max += _zombieSpawnPercentages[i];

                if (random > min && random <= max) 
                {
                    return i;
                }

                min += _zombieSpawnPercentages[i];
            }

            return NullIndex;
        }        

        private Vector3 GetRandomSpawnPosition()
        {
            int random = UnityEngine.Random.Range(0, _spawnPoints.Length);
            
            return _spawnPoints[random].transform.position;
        }

        private void NextRound() 
        {
            _round += 1;

            OnRoundChanged?.Invoke();

            _zombiesLeftToSpawn = (short)(_initialZombiesToSpawned * _round);

            _timerBeforeRoundStarts.ResetTimer();

            _timerForNextZombie.Time = UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime);

            _timerForNextZombie.ResetTimer();            
        }
    }
}