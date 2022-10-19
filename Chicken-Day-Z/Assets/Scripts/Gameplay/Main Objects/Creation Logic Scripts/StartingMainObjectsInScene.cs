using UnityEngine;
using System.Collections.Generic;

using ChickenDayZ.Gameplay.MainObjects;
using ChickenDayZ.Gameplay.ScripObjctsConfig;

namespace ChickenDayZ.Gameplay.Logic
{
    public class StartingMainObjectsInScene
    {
        private MainObjectInstantiationConfig[] _mainObjectCreationConfigs;

        public StartingMainObjectsInScene()
        {
            _mainObjectCreationConfigs = null;
        }

        public StartingMainObjectsInScene(MainObjectInstantiationConfig[] mainObjectCreationConfig) 
        {
            _mainObjectCreationConfigs = mainObjectCreationConfig;
        }

        public List<MainObject> GetMainObjects()
        {
            MainObject[] mainObjectsInScene = FindMainObjects();

            MainObject[] mainObjectsCreated = InstanciateMainObjects(_mainObjectCreationConfigs);

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
            MainObject[] _mainObjects = GameObject.FindObjectsOfType<MainObject>();

            return _mainObjects;
        }

        private MainObject[] InstanciateMainObjects(MainObjectInstantiationConfig[] _mainObjectConfigs)
        {
            if (_mainObjectConfigs == null)
            {
                return null;
            }

            short amountOfMainObjects = 0;
            
            GameObject prefab;

            for (short i = 0; i < _mainObjectConfigs.Length; i++) 
            {
                prefab = _mainObjectConfigs[i].Prefab;

                if (prefab.GetComponent<MainObject>() != null) 
                {
                    amountOfMainObjects += _mainObjectConfigs[i].Count;
                }
                else 
                {
                    Debug.Log("Prefab given doesnt have a MainObject Script!");
                }                
            }

            if (amountOfMainObjects == 0) 
            {
                return null;
            }

            MainObject[] _mainObjects = new MainObject[amountOfMainObjects];

            GameObject gameObject;

            for (short i = 0; i < _mainObjectConfigs.Length; i++)
            {
                prefab = _mainObjectConfigs[i].Prefab;

                if (prefab.GetComponent<MainObject>() != null)
                {
                    for (short v = 0; v < _mainObjectConfigs[i].Count; v++)
                    {
                        gameObject = GameObject.Instantiate(prefab);

                        _mainObjects[v] = gameObject.GetComponent<MainObject>();
                    }                   
                }                
            }

            return _mainObjects;
        }       
    }
}