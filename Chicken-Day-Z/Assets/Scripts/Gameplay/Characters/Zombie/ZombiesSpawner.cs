using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Interfaces;

using ChickenDayZ.Gameplay.MainObjects.Logic;
using ChickenDayZ.Gameplay.MainObjects.Characters;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;
using ChickenDayZ.Gameplay.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{
    public class ZombiesSpawner : MonoBehaviour, IResettable
    {
        [SerializeField] private GameplayMainObjectsManager _gameplayMainObjectsManager;

        [SerializeField] private GameObject[] _spawnPoints;

        [SerializeField] private GameObject _eggBase;

        [SerializeField] private GameObject _chicken;

        [SerializeField] [Range(1, 100)] private short[] _zombieSpawnPercentages; //In total must reached 100, guardar esta info en el zombie
        
        [SerializeField] private float _timeBeforeRoundStarts;

        [SerializeField] private float _minNextZombieSpawnTime; //Each round this number decreases

        [SerializeField] private float _maxNextZombieSpawnTime; //Each round this number decreases
                                                                
        [SerializeField] private short _initialRoundZombiesToKill;

        [SerializeField] [Range(1, 100)] private short _nextRoundSpawnTimesDecreasePercentage; //How much the numbers above will decrease        

        private GameObject[] _zombieObjects;

        public event Action OnRoundChanged;

        private Timer _timerBeforeRoundStarts;

        private Timer _timerForNextZombie;       

        private const short MaxPercentagesValue = 100;

        private const short InitialRound = 1;

        private const short NullIndex = -1;

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
            if (_gameplayMainObjectsManager == null)
            {
                Debug.LogError("GameplayMainObjectsManager cant be null!");

                Destroy(this);
            }

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
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;

            _gameplayMainObjectsManager.OnZombiesCreated += SetZombieObjects;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;

            _gameplayMainObjectsManager.OnZombiesCreated -= SetZombieObjects;
        }

        private void Start()
        {
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

            for (short i = 0; i < _zombieObjects.Length; i++) 
            {
                _zombieObjects[i].SetActive(false);
            }
        }

        private void SetZombieObjects()
        {
            _zombieObjects = new GameObject[ZombieObject.ZombiesActiveInstances];

            for (short i = 0; i < _gameplayMainObjectsManager.MainObjectInstancesHolder.MainObjects.Count; i++)
            {
                if (_gameplayMainObjectsManager.MainObjectInstancesHolder.MainObjects[i] is ZombieObject)
                {
                    _zombieObjects[i] = _gameplayMainObjectsManager.MainObjectInstancesHolder.MainObjects[i].gameObject;
                }
            }

            for (short i = 0; i < _zombieObjects.Length; i++)
            {
                _zombieObjects[i].gameObject.SetActive(false);
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
                random = UnityEngine.Random.Range(1, ZombieObject.ZombiesTotalInstances);

                if (!_zombieObjects[random].activeSelf)
                {
                    return _zombieObjects[random];
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