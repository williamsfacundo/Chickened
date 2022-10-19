using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Logic
{
    public class MainObjectsInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _mainObjectsPrefabs;

        private MainObject[] _mainObjects;        

        public bool SetMainObjectsInstantiator() 
        {
            bool settingSuccessful;

            settingSuccessful = AllPrefabsHaveMainObjects();

            if (!settingSuccessful) 
            {
                return settingSuccessful;
            }

            settingSuccessful = AllMainObjectsIdsAreDifferent();            

            return settingSuccessful;
        }        

        public GameObject InstantiateMainObject(MainObjectsIdsEnum id)
        {
            return Instantiate(GetCorrectPrefab(id));                                    
        }          

        public GameObject GetCorrectPrefab(MainObjectsIdsEnum id) 
        {
            for (short i = 0; i < _mainObjects.Length; i++) 
            {
                if (_mainObjects[i].Id == id) 
                {
                    return _mainObjectsPrefabs[i];
                }
            }

            Debug.Log("Id doesnt match any MainObjects!");

            return null;
        }

        private bool AllMainObjectsIdsAreDifferent() 
        {
            for (short i = 0; i < _mainObjectsPrefabs.Length; i++) 
            {
                for (short v = 0; v < _mainObjectsPrefabs.Length; v++) 
                {
                    if (i != v) 
                    {
                        if (_mainObjects[i].Id == _mainObjects[v].Id) 
                        {
                            Debug.LogError("MainObject " + (i + 1) + " and MainObject " + (v + 1) + " have same id!");

                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool AllPrefabsHaveMainObjects()
        {
            MainObject auxContainer = null;

            _mainObjects = new MainObject[_mainObjectsPrefabs.Length];

            for (short i = 0; i < _mainObjects.Length; i++)
            {
                auxContainer = _mainObjectsPrefabs[i].GetComponent<MainObject>();

                if (auxContainer != null)
                {
                    _mainObjects[i] = auxContainer;
                }
                else
                {
                    Debug.LogError("Prefab number " + (i + 1) + " doesnt contain a MainObject!");

                    return false;
                }
            }

            return true;
        }        
    }
}