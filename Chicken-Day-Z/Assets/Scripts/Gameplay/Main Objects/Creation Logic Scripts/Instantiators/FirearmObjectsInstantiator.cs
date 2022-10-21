using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.CombatItem;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators 
{
    public class FirearmObjectsInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _firearmObjectsPrefabs;        

        public bool SetFirearmObjectsInstantiator()
        {
            bool settingSuccessful = AllPrefabsHaveFirearmObjects();

            if (!settingSuccessful)
            {
                Debug.LogError("Set all FirearmObject prefabs correctly to continue!");
            }

            return settingSuccessful;
        }

        public GameObject InstantiateFirearmObject(FirearmObjectTypeEnum firearmObjectType)
        {
            GameObject auxContainer = GetCorrectPrefab(firearmObjectType);

            if (auxContainer == null)
            {
                Debug.LogError("Failed to instantiate FirearmObject!");

                return null;
            }

            return Instantiate(auxContainer);
        }

        private GameObject GetCorrectPrefab(FirearmObjectTypeEnum firearmObjectType)
        {
            for (short i = 0; i < _firearmObjectsPrefabs.Length; i++)
            {
                if (_firearmObjectsPrefabs[i].GetComponent<FirearmObject>().FirearmObjectType == firearmObjectType)
                {
                    return _firearmObjectsPrefabs[i];
                }
            }

            Debug.LogError("FirearmObjectType doesnt match any FirearmObject type in prefabs, a new one must be added!");

            return null;
        }

        private bool AllPrefabsHaveFirearmObjects()
        {
            FirearmObject auxContainer;            

            bool allPrefabsHaveMainObjects = true;

            for (short i = 0; i < _firearmObjectsPrefabs.Length; i++)
            {
                auxContainer = _firearmObjectsPrefabs[i].GetComponent<FirearmObject>();

                if (auxContainer == null)
                {
                    Debug.LogError("Prefab number " + (i + 1) + " doesnt contain a FirearmObject!");

                    if (allPrefabsHaveMainObjects)
                    {
                        allPrefabsHaveMainObjects = false;
                    }
                }
            }

            return allPrefabsHaveMainObjects;
        }
    }
}