using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;
using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Buildings;

[RequireComponent(typeof(NavMeshAgent))]
public class ControlAgents : MonoBehaviour
{
    private Transform _target;

    private NavMeshAgent _agent;
    
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }    

    void Start()
    {
        EggObject.OnEggObject += SetDestinationTarget; 

        _agent.updateRotation = false;

        _agent.updateUpAxis = false;
    }

    void OnDestroy()
    {
        EggObject.OnEggObject -= SetDestinationTarget;
    }

    void Update()
    {
        _agent.SetDestination(_target.position);        
    }

    void SetDestinationTarget(Transform _transform) 
    {
        _target = _transform;
    }
}
