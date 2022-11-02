using System;
using UnityEngine;

using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.MainObjects.Characters;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{
    public class ZombiesSpawner : MonoBehaviour, IResettable
    {
        [SerializeField] private GameObject[] _spawnPoints;

        [SerializeField] private GameObject _eggBase;

        [SerializeField] private GameObject _chicken;

        [SerializeField] private GameObject _normalZombie;

        [SerializeField] private GameObject _fastZombie;

        [SerializeField] private GameObject _fatZombie;

        [SerializeField] [Range(1, 100)] private short[] _zombieSpawnPercentages; //In total must reached 100, guardar esta info en el zombie
        
        [SerializeField] private float _timeBeforeRoundStarts;

        [SerializeField] private float _minNextZombieSpawnTime; 

        [SerializeField] private float _maxNextZombieSpawnTime; 
                                                                
        [SerializeField] private short _initialRoundZombiesToKill;

        [SerializeField] [Range(1, 100)] private short _nextRoundSpawnTimesDecreasePercentage;

        [SerializeField] private short _maxNormalZombies;

        [SerializeField] private short _maxFastZombies;
        
        [SerializeField] private short _maxFatZombies;

        private GameObject[] _normalZombies;

        private GameObject[] _fastZombies;

        private GameObject[] _fatZombies;

        public event Action OnRoundChanged;

        private Timer _timerBeforeRoundStarts;

        private Timer _timerForNextZombie;       

        private const short MaxPercentagesValue = 100;

        private const short InitialRound = 1;        

        private short _round;

        private short _zombiesLeftToKill;

        public short Round 
        {
            get 
            {
                return _round;
            }
        }

        void Awake()
        {
            if (_eggBase == null)
            {
                Debug.LogError("EggBase cant be null!");

                Destroy(this);
            }

            if (_chicken == null)
            {
                Debug.LogError("Chicken cant be null!");

                Destroy(this);
            }

            if (_normalZombie == null)
            {
                Debug.LogError("Normal Zombie cant be null!");

                Destroy(this);
            }

            if (_fastZombie == null)
            {
                Debug.LogError("Fast Zombie cant be null!");

                Destroy(this);
            }

            if (_fatZombie == null)
            {
                Debug.LogError("Fat Zombie cant be null!");

                Destroy(this);
            }
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;            
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;            
        }

        private void Start()
        {
            SetZombieObjects();

            _timerBeforeRoundStarts = new Timer(_timeBeforeRoundStarts);

            _timerForNextZombie = new Timer(UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime));

            _round = InitialRound;            

            OnRoundChanged?.Invoke();            

            _zombiesLeftToKill = _initialRoundZombiesToKill;                       

            CheckIfPercentagesAreRight();            
        }        

        void Update() 
        {
            if (_timerBeforeRoundStarts.TimerFinished) 
            {
                if (_zombiesLeftToKill > 0) 
                {
                    _timerForNextZombie.DecreaseTimer();

                    if (_timerForNextZombie.TimerFinished)
                    {
                        ActivateRandomZombie();                        
                    }
                }
                else if (ZombieObject.ZombiesActiveInstances <= 0) 
                {                    
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

            _zombiesLeftToKill = _initialRoundZombiesToKill;            

            for (short i = 0; i < _normalZombies.Length; i++) 
            {
                _normalZombies[i].SetActive(false);
            }

            for (short i = 0; i < _fastZombies.Length; i++)
            {
                _fastZombies[i].SetActive(false);
            }

            for (short i = 0; i < _fatZombies.Length; i++)
            {
                _fatZombies[i].SetActive(false);
            }
        }

        private void SetZombieObjects()
        {
            _normalZombies = new GameObject[_maxNormalZombies];

            _fastZombies = new GameObject[_maxFastZombies];

            _fatZombies = new GameObject[_maxFatZombies];

            for (short i = 0; i < _normalZombies.Length; i++) 
            {
                _normalZombies[i] = Instantiate(_normalZombie);

                _normalZombies[i].SetActive(false);

                _normalZombies[i].GetComponent<ZombieTarget>().Target = _eggBase;
            }

            for (short i = 0; i < _fastZombies.Length; i++)
            {
                _fastZombies[i] = Instantiate(_fastZombie);

                _normalZombies[i].SetActive(false);

                _normalZombies[i].GetComponent<ZombieTarget>().Target = _eggBase;
            }

            for (short i = 0; i < _fatZombies.Length; i++)
            {
                _fatZombies[i] = Instantiate(_fatZombie);

                _normalZombies[i].SetActive(false);

                _normalZombies[i].GetComponent<ZombieTarget>().Target = _eggBase;
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

        private void ActivateRandomZombie() 
        {
            GameObject zombie = GetRandomZombie();

            if (zombie != null) 
            {
                zombie.gameObject.SetActive(true);

                _zombiesLeftToKill -= 1;

                _timerForNextZombie.Time = UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime);                

                zombie.transform.position = GetRandomSpawnPosition();

                zombie.GetComponent<ObjectHealth>().ResetObject();

                int aux = UnityEngine.Random.Range(1, 3);

                switch (aux)
                {
                    case 1:

                        zombie.GetComponent<ZombieTarget>().Target = _chicken;
                        break;

                    case 2:
                        zombie.GetComponent<ZombieTarget>().Target = _eggBase;
                        break;
                }
            }            
        }

        private GameObject GetRandomZombie() 
        {
            int random;            

            for (short i = 0; i < 100; i++) 
            {
                random = UnityEngine.Random.Range(1, 100);

                if (random > 1 && random < _zombieSpawnPercentages[0]) 
                {
                    for (short v = 0; v < _normalZombies.Length; i++) 
                    {
                        if (!_normalZombies[v].activeSelf) 
                        {
                            return _normalZombies[v];
                        }
                    }
                }
                else if (random > _zombieSpawnPercentages[0] && random < _zombieSpawnPercentages[0] + _zombieSpawnPercentages[1]) 
                {
                    for (short v = 0; v < _fastZombies.Length; i++)
                    {
                        if (!_fastZombies[v].activeSelf)
                        {
                            return _fastZombies[v];
                        }
                    }
                }
                else if (random > _zombieSpawnPercentages[0] + _zombieSpawnPercentages[1] && random < _zombieSpawnPercentages[1] + _zombieSpawnPercentages[2]) 
                {
                    for (short v = 0; v < _fatZombies.Length; i++)
                    {
                        if (!_fatZombies[v].activeSelf)
                        {
                            return _fatZombies[v];
                        }
                    }
                }               
            }            

            return null;
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

            _zombiesLeftToKill = (short)(_initialRoundZombiesToKill * _round);

            _timerBeforeRoundStarts.ResetTimer();

            _timerForNextZombie.Time = UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime);

            _timerForNextZombie.ResetTimer();            
        }
    }
}