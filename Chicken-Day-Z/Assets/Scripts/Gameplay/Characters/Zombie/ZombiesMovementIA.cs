using System;
using UnityEngine;
using UnityEngine.AI;

using ChickenDayZ.Gameplay.MainObjects.Buildings;
using ChickenDayZ.Gameplay.MainObjects.Characters;

namespace ChickenDayZ.Gameplay.Characters.Zombie 
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody2D))]
    public class ZombiesMovementIA : MonoBehaviour
    {
        [SerializeField] private float _initialSpeed;
        
        private const int MaxTargets = 2;

        private Transform[] _targets;

        private NavMeshAgent _agent;

        public event Action OnZombieIsDead;

        public event Action OnZombieIsAlive;

        private int _currentTargetIndex;

        private bool _isDead;

        public bool IsDead 
        {
            set 
            {
                _isDead = value;

                if (value) 
                {
                    OnZombieIsDead?.Invoke();
                }
                else 
                {
                    OnZombieIsAlive?.Invoke();
                }
            }
        }

        public Transform Target 
        {            
            get 
            {
                return _targets[_currentTargetIndex];
            }
        }

        public NavMeshAgent Agent 
        {
            get 
            {
                return _agent;
            }
        }

        public int CurrentTargetIndex 
        {
            set 
            {
                if (value >= 0 && value < MaxTargets)
                {
                    _currentTargetIndex = value;
                }
            }
        }

        void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            _targets = new Transform[MaxTargets];            

            _currentTargetIndex = 0;

            EggObject.OnEggObject += SetDestinationTarget;

            ChickenObject.OnChickenObject += SetDestinationTarget;
        }

        void Start()
        {
            _agent.updateRotation = false;

            _agent.updateUpAxis = false;

            _agent.speed = _initialSpeed;

            

            IsDead = false;
        }

        void OnDestroy()
        {
            EggObject.OnEggObject -= SetDestinationTarget;

            ChickenObject.OnChickenObject -= SetDestinationTarget;
        }

        void Update()
        {
            _agent.SetDestination(_targets[_currentTargetIndex].position);            

            if (_isDead) 
            {
                if (Agent.speed != 0.0f)
                {
                    Agent.speed = 0.0f;
                }
            }
        }

        public void ResetZombieIA()
        {
            SetRandomTarget();

            IsDead = false;

            _agent.speed = _initialSpeed;
        }

        public int FindTargetIndex(Transform transform) 
        {
            for (short i = 0; i < _targets.Length; i++) 
            {
                if (transform.gameObject == _targets[i].gameObject) 
                {
                    return i;
                }
            }

            return -1;
        }

        private void SetRandomTarget() 
        {
            _currentTargetIndex = UnityEngine.Random.Range(0, MaxTargets);
        }

        private void SetDestinationTarget(Transform _transform)
        {
            if (_currentTargetIndex < MaxTargets) 
            {
                _targets[_currentTargetIndex] = _transform;

                _currentTargetIndex += 1;
            }
        }
    }
}