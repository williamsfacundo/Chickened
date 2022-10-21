using System;
using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic
{    
    [RequireComponent(typeof(MainObjectsInstantiatorManager), 
        typeof(StartingMainObjectsInScene), typeof(MainObjectInstancesHolder))]
    [RequireComponent(typeof(MainObjectsDefiner))]
    public class GameplayMainObjectsManager : MonoBehaviour
    {
        private MainObjectsInstantiatorManager _mainObjectsInstantiator;

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
            _mainObjectsInstantiator = GetComponent<MainObjectsInstantiatorManager>();

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

            //Antes de definir a los main objects abria que notificar que estos fueron creados
            //Para que asi los objetos de la UI y capaz otros mas se pongan como observadores de
            //sus variables y cuando se definan estos sean notificados de los cambios que se van a realizar en las mismas

            _mainObjectsDefiner.DefineMainObjects(_mainObjectInstancesHolder.MainObjects);

            OnZombiesCreated?.Invoke();
        }        
    }
}