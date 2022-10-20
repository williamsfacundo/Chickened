using System;
using UnityEngine;

namespace ChickenDayZ.Gameplay.MainObjects.Logic
{    
    [RequireComponent(typeof(MainObjectsInstantiator), 
        typeof(StartingMainObjectsInScene), typeof(MainObjectInstancesHolder))]
    [RequireComponent(typeof(MainObjectsDefiner))]
    public class GameplayMainObjectsManager : MonoBehaviour
    {
        private MainObjectsInstantiator _mainObjectsInstantiator;

        private StartingMainObjectsInScene _startingMainObjectsInScene;

        private MainObjectInstancesHolder _mainObjectInstancesHolder;

        private MainObjectsDefiner _mainObjectsDefiner;

        public event Action OnZombiesCreated;

        public MainObjectInstancesHolder MainObjectInstancesHolder 
        {
            get 
            {
                return _mainObjectInstancesHolder; 
            }
        }

        void Start()
        {
            _mainObjectsInstantiator = GetComponent<MainObjectsInstantiator>();

            _startingMainObjectsInScene = GetComponent<StartingMainObjectsInScene>();

            _mainObjectInstancesHolder = GetComponent<MainObjectInstancesHolder>();

            _mainObjectsDefiner = GetComponent<MainObjectsDefiner>();

            CreateMainObjects();
        }        

        private void CreateMainObjects() 
        {
            bool mainObjectsInstantiatorCreated = _mainObjectsInstantiator.SetMainObjectsInstantiator();

            if (!mainObjectsInstantiatorCreated) 
            {
                return;
            }

            _mainObjectInstancesHolder.SetMainObjects(_startingMainObjectsInScene.GetMainObjects());

            _mainObjectsDefiner.DefineMainObjects(_mainObjectInstancesHolder.MainObjects);

            OnZombiesCreated?.Invoke();
        }        
    }
}