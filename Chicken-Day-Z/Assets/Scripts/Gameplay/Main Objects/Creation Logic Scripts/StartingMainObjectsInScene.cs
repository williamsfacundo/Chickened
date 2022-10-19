using UnityEngine;
using System.Collections.Generic;

using ChickenDayZ.Gameplay.ScripObjctsConfig;

namespace ChickenDayZ.Gameplay.MainObjects.Logic
{    
    public class StartingMainObjectsInScene : MonoBehaviour
    {        
        [SerializeField] private MainObjectInstantiationConfig[] _mainObjectCreationConfigs;

        private MainObjectsInstantiator _mainObjectsInstantiator;       

        void Awake()
        {
            _mainObjectsInstantiator = GetComponent<MainObjectsInstantiator>();
        }

        public List<MainObject> GetMainObjects()
        {
            MainObject[] mainObjectsInScene = FindMainObjects();

            MainObject[] mainObjectsCreated = InstanciateMainObjects();

            if (mainObjectsInScene == null && mainObjectsCreated == null) 
            {
                return null;
            }

            List<MainObject> mainObjects = new List<MainObject>();

            if (mainObjectsInScene != null) 
            {
                for (short i = 0; i < mainObjectsInScene.Length; i++)
                {
                    mainObjects.Add(mainObjectsInScene[i]);
                }
            }

            if (mainObjectsCreated != null) 
            {
                for (short i = 0; i < mainObjectsCreated.Length; i++)
                {
                    mainObjects.Add(mainObjectsCreated[i]);
                }
            }            

            return mainObjects;
        }

        private MainObject[] FindMainObjects()
        {
            MainObject[] _mainObjects = FindObjectsOfType<MainObject>();

            return _mainObjects;
        }

        private MainObject[] InstanciateMainObjects()
        {

            if (_mainObjectCreationConfigs == null)
            {
                return null;
            }

            MainObject[] _mainObjects;

            GameObject prefab;

            GameObject gameObject;

            short amountOfMainObjects = 0;
            

            for (short i = 0; i < _mainObjectCreationConfigs.Length; i++) 
            {
                amountOfMainObjects += _mainObjectCreationConfigs[i].Count;
            }

            _mainObjects = new MainObject[amountOfMainObjects];

            for (short i = 0; i < _mainObjectCreationConfigs.Length; i++)
            {
                prefab = _mainObjectsInstantiator.GetCorrectPrefab(_mainObjectCreationConfigs[i].MainObjectId);

                if (prefab != null) 
                {
                    for (short v = 0; v < _mainObjectCreationConfigs[i].Count; v++)
                    {
                        gameObject = Instantiate(prefab);

                        _mainObjects[v] = gameObject.GetComponent<MainObject>();
                    }
                }                
            }

            return _mainObjects;
        }       
    }
}