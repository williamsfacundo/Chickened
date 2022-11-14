using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Buildings
{
    [RequireComponent(typeof(ObjectHealth))]
    public class EggObject : BuildingObject 
    {
        private ObjectHealth _objectHealth;

        public static event Action<Transform> OnEggObject;

        void Awake()
        {
            _objectHealth = GetComponent<ObjectHealth>();
        }

        void Start()
        {
            OnEggObject?.Invoke(transform);            
        }

        void OnEnable()
        {
            _objectHealth.OnHealthReachedZero += GameplayResetter.ResetGameplay;

            GameplayResetter.OnGameplayReset += _objectHealth.ResetCurrentHealth;
        }

        void OnDisable()
        {
            _objectHealth.OnHealthReachedZero -= GameplayResetter.ResetGameplay;

            GameplayResetter.OnGameplayReset -= _objectHealth.ResetCurrentHealth;
        }

        private EggObject() : base(BuildingObjectTypeEnum.EGG)
        {

        }       
    }
}