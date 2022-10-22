using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Buildings;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators 
{
    public class BuildingObjectsInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _buildingObjectsPrefabs;
        
        public bool SetBuildingObjectsInstantiator()
        {
            bool settingSuccessful = AllPrefabsHaveBuildingObjects();

            if (!settingSuccessful)
            {
                Debug.LogError("Set all BuildingObject prefabs correctly to continue!");
            }

            return settingSuccessful;
        }

        public GameObject InstantiateBuildingObject(BuildingObjectTypeEnum buildingObjectType)
        {
            GameObject auxContainer = GetCorrectPrefab(buildingObjectType);

            if (auxContainer == null)
            {
                Debug.LogError("Failed to instantiate BuildingObject!");

                return null;
            }

            return Instantiate(auxContainer);
        }

        private GameObject GetCorrectPrefab(BuildingObjectTypeEnum buildingObjectType)
        {
            for (short i = 0; i < _buildingObjectsPrefabs.Length; i++)
            {
                if (_buildingObjectsPrefabs[i].GetComponent<BuildingObject>().BuildingObjectType == buildingObjectType)
                {
                    return _buildingObjectsPrefabs[i];
                }
            }

            Debug.LogError("BuildingObject doesnt match any BuildingObject type in prefabs, a new one must be added!");

            return null;
        }

        private bool AllPrefabsHaveBuildingObjects()
        {
            BuildingObject auxContainer;            

            bool allPrefabsHaveMainObjects = true;

            for (short i = 0; i < _buildingObjectsPrefabs.Length; i++)
            {
                auxContainer = _buildingObjectsPrefabs[i].GetComponent<BuildingObject>();

                if (auxContainer == null)
                {
                    Debug.LogError("Prefab number " + (i + 1) + " doesnt contain a BuildingObject!");

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