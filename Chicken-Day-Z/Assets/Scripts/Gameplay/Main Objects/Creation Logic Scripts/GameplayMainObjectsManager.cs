//using System;
using UnityEngine;

//using ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic
{    
    //[RequireComponent(typeof(MainObjectsInstantiatorManager), 
    //    typeof(StartingMainObjectsInScene), typeof(MainObjectInstancesHolder))]    
    public class GameplayMainObjectsManager : MonoBehaviour
    {
        /*private MainObjectsInstantiatorManager _mainObjectsInstantiator;

        private StartingMainObjectsInScene _startingMainObjectsInScene;

        private MainObjectInstancesHolder _mainObjectInstancesHolder;        

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
            _mainObjectsInstantiator = GetComponent<MainObjectsInstantiatorManager>();

            _startingMainObjectsInScene = GetComponent<StartingMainObjectsInScene>();

            _mainObjectInstancesHolder = GetComponent<MainObjectInstancesHolder>();            

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

            OnZombiesCreated?.Invoke();
        }*/        
    }
}