using UnityEngine;

//using ChickenDayZ.Gameplay.MainObjects.Characters;
//using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators
{
    public class ZombieObjectsInstantiator : MonoBehaviour
    {
        /*[SerializeField] private GameObject[] _zombieObjectsPrefabs;

        public bool SetZombieObjectsInstantiator()
        {
            bool settingSuccessful = AllPrefabsHaveZombieObjects();

            if (!settingSuccessful)
            {
                Debug.LogError("Set all ZombieObject prefabs correctly to continue!");
            }

            return settingSuccessful;
        }

        public GameObject InstantiateZombieObject(ZombieObjectTypeEnum zombieObjectType)
        {
            GameObject auxContainer = GetCorrectPrefab(zombieObjectType);

            if (auxContainer == null)
            {
                Debug.LogError("Failed to instantiate ZombieObject!");

                return null;
            }

            return Instantiate(auxContainer);
        }

        private GameObject GetCorrectPrefab(ZombieObjectTypeEnum zombieObjectType)
        {
            for (short i = 0; i < _zombieObjectsPrefabs.Length; i++)
            {
                if (_zombieObjectsPrefabs[i].GetComponent<ZombieObject>().ZombieType == zombieObjectType)
                {
                    return _zombieObjectsPrefabs[i];
                }
            }

            Debug.LogError("ZombieObjectType doesnt match any ZombieObject type in prefabs, a new one must be added!");

            return null;
        }

        private bool AllPrefabsHaveZombieObjects()
        {
            ZombieObject auxContainer;

            bool allPrefabsHaveZombieObjects = true;

            for (short i = 0; i < _zombieObjectsPrefabs.Length; i++)
            {
                auxContainer = _zombieObjectsPrefabs[i].GetComponent<ZombieObject>();

                if (auxContainer == null)
                {
                    Debug.LogError("Prefab number " + (i + 1) + " doesnt contain a ZombieObject!");

                    if (allPrefabsHaveZombieObjects)
                    {
                        allPrefabsHaveZombieObjects = false;
                    }
                }
            }

            return allPrefabsHaveZombieObjects;
        }*/
    }
}