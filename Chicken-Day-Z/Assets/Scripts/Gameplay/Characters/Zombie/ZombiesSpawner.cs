using System;
using UnityEngine;

using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.MainObjects.PowerUp;
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
        
        [SerializeField] [Range(1, 45)] private float _timeBeforeRoundStarts;       

        [SerializeField] private float _minNextZombieSpawnTime; 

        [SerializeField] private float _maxNextZombieSpawnTime; 
                                                                
        [SerializeField] private short _initialRoundZombiesToKill;        

        [SerializeField] private short _maxNormalZombies;

        [SerializeField] private short _maxFastZombies;
        
        [SerializeField] private short _maxFatZombies;

        private GameObject[] _normalZombies;

        private GameObject[] _fastZombies;

        private GameObject[] _fatZombies;

        public event Action OnRoundChanged;

        public event Action OnTimerBeforeRoundStartsChanged;

        private Timer _timerBeforeRoundStarts;

        private Timer _timerForNextZombie;       

        private const short MaxPercentagesValue = 100;

        private const short InitialRound = 1;        

        private short _round;

        private short _zombiesLeftToKill;

        public short Round 
        {
            set 
            {
                _round = value;

                OnRoundChanged?.Invoke();
            }
            get 
            {
                return _round;
            }
        }

        public Timer TimerBeforeRoundStarts 
        {            
            get 
            {
                return _timerBeforeRoundStarts;
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
            GameplayResetter.OnGameplayReset -= ResetObject;            
        }

        private void Start()
        {
            SetZombieObjects();

            _timerBeforeRoundStarts = new Timer(_timeBeforeRoundStarts);

            _timerBeforeRoundStarts.CountDown = 0f;

            OnTimerBeforeRoundStartsChanged?.Invoke();

            _timerForNextZombie = new Timer(UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime));

            Round = InitialRound;                        

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

                OnTimerBeforeRoundStartsChanged?.Invoke();
            }            
        }

        public void ResetObject()
        {
            _timerBeforeRoundStarts.CountDown = 0f;

            OnTimerBeforeRoundStartsChanged?.Invoke();

            _timerForNextZombie.Time = UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime);

            _timerForNextZombie.ResetTimer();

            Round = InitialRound;            

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
            }

            for (short i = 0; i < _fastZombies.Length; i++)
            {
                _fastZombies[i] = Instantiate(_fastZombie);

                _fastZombies[i].SetActive(false);                
            }

            for (short i = 0; i < _fatZombies.Length; i++)
            {
                _fatZombies[i] = Instantiate(_fatZombie);

                _fatZombies[i].SetActive(false);                
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

                zombie.GetComponent<ObjectHealth>().ResetCurrentHealth();

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
            else 
            {
                _timerForNextZombie.Time = UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime);
            }
        }

        private GameObject GetRandomZombie() 
        {
            int random = UnityEngine.Random.Range(1, 100);

            Debug.Log(random);

            if (random > 1 && random < _zombieSpawnPercentages[0])
            {
                for (short v = 0; v < _normalZombies.Length; v++)
                {
                    if (!_normalZombies[v].activeSelf)
                    {
                        return _normalZombies[v];
                    }
                }
            }
            else if (random > _zombieSpawnPercentages[0] && random < _zombieSpawnPercentages[0] + _zombieSpawnPercentages[1])
            {
                for (short v = 0; v < _fastZombies.Length; v++)
                {
                    if (!_fastZombies[v].activeSelf)
                    {
                        return _fastZombies[v];
                    }
                }
            }
            else if (random > _zombieSpawnPercentages[0] + _zombieSpawnPercentages[1] && random < _zombieSpawnPercentages[1] + _zombieSpawnPercentages[2])
            {
                for (short v = 0; v < _fatZombies.Length; v++)
                {
                    if (!_fatZombies[v].activeSelf)
                    {
                        return _fatZombies[v];
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
            Round += 1;            

            _zombiesLeftToKill = (short)(_initialRoundZombiesToKill * Round);

            _timerBeforeRoundStarts.ResetTimer();

            OnTimerBeforeRoundStartsChanged?.Invoke();

            _timerForNextZombie.Time = UnityEngine.Random.Range(_minNextZombieSpawnTime, _maxNextZombieSpawnTime);

            _timerForNextZombie.ResetTimer();

            PowerUpObject.PowerUpAvailable = true;
        }
    }
}