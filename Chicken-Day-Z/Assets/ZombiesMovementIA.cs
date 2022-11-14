using UnityEngine;
using UnityEngine.AI;

using ChickenDayZ.Gameplay.MainObjects.Buildings;
using ChickenDayZ.Gameplay.MainObjects.Characters;

namespace ChickenDayZ.Gameplay.Characters.Zombie 
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ZombiesMovementIA : MonoBehaviour
    {
        private const int MaxTargets = 2;

        private Transform[] _targets;

        private NavMeshAgent _agent;

        private int _currentTargetIndex;

        public Transform Target 
        {
            get 
            {
                return _targets[_currentTargetIndex];
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
        }

        void OnDestroy()
        {
            EggObject.OnEggObject -= SetDestinationTarget;

            ChickenObject.OnChickenObject -= SetDestinationTarget;
        }

        void Update()
        {
            _agent.SetDestination(_targets[_currentTargetIndex].position);
        }       

        public void SetRandomTarget() 
        {
            _currentTargetIndex = Random.Range(0, MaxTargets);
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