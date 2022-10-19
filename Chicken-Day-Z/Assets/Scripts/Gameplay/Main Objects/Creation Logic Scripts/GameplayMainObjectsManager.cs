using System;
using UnityEngine;

using ChickenDayZ.Gameplay.ScripObjctsConfig;
using ChickenDayZ.Gameplay.MainObjects.Interfaces;

namespace ChickenDayZ.Gameplay.Logic 
{
    public class GameplayMainObjectsManager : MonoBehaviour, IObjectRessetable
    {
        [SerializeField] private MainObjectInstantiationConfig[] _mainObjectsCreationConfigs;        
        
        private MainObjectInstancesHolder _mainObjectInstancesHolder;

        public event Action OnMainObjectsInstantiated;

        void Start()
        {
            SetMainObjectInstancesHolder();

            //Hasta aca los objetos son cascarones sin vida y hay que darsela            
        }

        private void SetMainObjectInstancesHolder() 
        {
            StartingMainObjectsInScene _startingMainObjectsInScene = new StartingMainObjectsInScene(_mainObjectsCreationConfigs);            

            _mainObjectInstancesHolder = new MainObjectInstancesHolder(_startingMainObjectsInScene.GetMainObjects());

            OnMainObjectsInstantiated?.Invoke();
        }

        public void GameplayResset()
        {
            _mainObjectInstancesHolder.GameplayResset();
        }

        public void RoundResset()
        {
            _mainObjectInstancesHolder.RoundResset();
        }
    }
}