using UnityEngine;

using ChickenDayZ.Gameplay.ScripObjctsConfig;
using ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic
{    
    public class StartingMainObjectsInScene : MonoBehaviour
    {        
        [SerializeField] private MainObjectInstantiationConfig[] _mainObjectCreationConfigs;

        private MainObjectsInstantiatorManager _mainObjectsInstantiator;       

        void Awake()
        {
            _mainObjectsInstantiator = GetComponent<MainObjectsInstantiatorManager>();
        }

        public GameObject[] GetMainObjects()
        {
            GameObject[] mainObjectsInScene = FindMainObjects();

            GameObject[] mainObjectsCreated = InstanciateMainObjects();

            if (mainObjectsInScene == null && mainObjectsCreated == null) 
            {
                return null;
            }

            GameObject[] mainObjects = new GameObject[mainObjectsInScene.Length + mainObjectsCreated.Length];

            short index = 0;

            if (mainObjectsInScene != null)
            {
                for (short i = index; i < mainObjectsInScene.Length; i++)
                {
                    mainObjects[i] = mainObjectsInScene[i];

                    index++;
                }
            }

            if (mainObjectsCreated != null)
            {
                for (short i = index; i < mainObjectsCreated.Length; i++)
                {
                    mainObjects[i] = mainObjectsCreated[i];

                    index++;
                }
            }

            return mainObjects;
        }

        private GameObject[] FindMainObjects()
        {
            MainObject[] mainObjects = FindObjectsOfType<MainObject>();

            if (mainObjects == null) 
            {
                return null;
            }

            GameObject[] gameObjects = new GameObject[mainObjects.Length];

            for (short i = 0; i < gameObjects.Length; i++) 
            {
                gameObjects[i] = mainObjects[i].gameObject;
            }            

            return gameObjects;
        }

        private GameObject[] InstanciateMainObjects()
        {

            if (_mainObjectCreationConfigs == null)
            {
                return null;
            }            

            GameObject prefab = null;

            GameObject[] gameObject;

            short amountOfMainObjects = 0;
            

            for (short i = 0; i < _mainObjectCreationConfigs.Length; i++) 
            {
                amountOfMainObjects += _mainObjectCreationConfigs[i].Count;
            }

            gameObject = new GameObject[amountOfMainObjects];

            short index = 0;

            for (short i = 0; i < _mainObjectCreationConfigs.Length; i++)
            {
                //prefab = _mainObjectsInstantiator.GetCorrectPrefab(_mainObjectCreationConfigs[i].MainObjectId);

                if (prefab != null) 
                {
                    for (short v = 0; v < _mainObjectCreationConfigs[i].Count; v++)
                    {
                        gameObject[index] = Instantiate(prefab);

                        index++;
                    }
                }                
            }

            return gameObject;
        }       
    }
}