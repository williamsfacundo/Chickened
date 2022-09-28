using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Characters.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{
    public class ZombiesSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _normalZombiePrefab;

        [SerializeField] private GameObject _fatZombiePrefab;

        [SerializeField] private GameObject _fastZombiePrefab;        

        [SerializeField] private GameObject[] _spawnPoints;

        [SerializeField] private float _minSpawnTime;

        [SerializeField] private float _maxSpawnTime;

        [SerializeField] private short _initialZombieMaxInstances;

        private ZombieHealth[] _zombieInstances;

        private float _newZombieSpawnTimer;

        void Start()
        {
            SetRandomSpawnTimer();

            _zombieInstances = new ZombieHealth[_initialZombieMaxInstances];
        }

        void Update()
        {
            DecreaseNewZombieSpawnTimer();

            InstanciateZombieIfTimerReachedZero();
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetZombiesSpawner;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset += ResetZombiesSpawner;
        }

        private void ResetZombiesSpawner()
        {
            SetRandomSpawnTimer();

            DestroyZombiesInScene();
        }

        private void DestroyZombiesInScene()
        {
            for (short i = 0; i < _zombieInstances.Length; i++)
            {
                if (_zombieInstances[i] != null)
                {
                    _zombieInstances[i].DeactivateZombie();
                }
            }
        }

        private void SetRandomSpawnTimer()
        {
            _newZombieSpawnTimer = Random.Range(_minSpawnTime, _maxSpawnTime);
        }

        private void DecreaseNewZombieSpawnTimer()
        {
            if (_newZombieSpawnTimer > 0f && AreLessZombiesThanAllowed())
            {
                _newZombieSpawnTimer -= Time.deltaTime;

                if (_newZombieSpawnTimer < 0f)
                {
                    _newZombieSpawnTimer = 0f;
                }
            }
        }

        private void InstanciateZombieIfTimerReachedZero()
        {
            short aux = 0;

            if (_newZombieSpawnTimer == 0f)
            {
                Vector3 spawnPosition = GetRandomSpawnPoint();

                int random = Random.Range(1, 6);

                switch (random) 
                {
                    case 1:

                        aux = InstanciateZombie(_fastZombiePrefab, spawnPosition);

                        _zombieInstances[aux].gameObject.GetComponent<ZombieMovement>().Target = FindObjectOfType<ChickenHealth>().gameObject;

                        break;
                    case 2:

                        aux = InstanciateZombie(_fatZombiePrefab, spawnPosition);

                        _zombieInstances[aux].gameObject.GetComponent<ZombieMovement>().Target = FindObjectOfType<ChickenHealth>().gameObject;

                        break;
                    default:

                        InstanciateZombie(_normalZombiePrefab, spawnPosition);

                        break;                    
                }                

                SetRandomSpawnTimer();
            }
        }

        private Vector3 GetRandomSpawnPoint()
        {
            int random = Random.Range(0, _spawnPoints.Length);

            return _spawnPoints[random].transform.position;
        }

        private short InstanciateZombie(GameObject zombie, Vector3 position)
        {
            short index = GetZombieInstancesNullIndex();

            _zombieInstances[index] = Instantiate(zombie, position, Quaternion.identity).GetComponent<ZombieHealth>();

            return index;
        }

        private short GetZombieInstancesNullIndex()
        {
            short index = 0;

            for (short i = 0; i < _zombieInstances.Length; i++)
            {
                if (_zombieInstances[i] == null)
                {
                    return i;
                }
            }

            return index;
        }

        private bool AreLessZombiesThanAllowed()
        {
            return ZombieHealth.ZombiesInstances < _initialZombieMaxInstances;
        }
    }
}