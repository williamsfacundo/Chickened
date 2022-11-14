using UnityEngine;
using UnityEngine.AI;

using ChickenDayZ.Gameplay.MainObjects.Buildings;
using ChickenDayZ.Gameplay.MainObjects.Characters;

namespace ChickenDayZ.Gameplay.Characters.Zombie 
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody2D))]
    public class ZombiesMovementIA : MonoBehaviour
    {
        private const int MaxTargets = 2;

        private Transform[] _targets;

        private NavMeshAgent _agent;

        private Rigidbody2D _rb2D;

        private int _currentTargetIndex;

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

            _rb2D = GetComponent<Rigidbody2D>();

            _currentTargetIndex = 0;

            EggObject.OnEggObject += SetDestinationTarget;

            ChickenObject.OnChickenObject += SetDestinationTarget;
        }

        void Start()
        {
            _agent.updateRotation = false;

            _agent.updateUpAxis = false;

            _rb2D.velocity = Vector2.zero;
        }

        void OnDestroy()
        {
            EggObject.OnEggObject -= SetDestinationTarget;

            ChickenObject.OnChickenObject -= SetDestinationTarget;
        }

        void Update()
        {
            _agent.SetDestination(_targets[_currentTargetIndex].position);

            _rb2D.velocity = Vector2.zero;
        }       

        public void SetRandomTarget() 
        {
            _currentTargetIndex = Random.Range(0, MaxTargets);
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