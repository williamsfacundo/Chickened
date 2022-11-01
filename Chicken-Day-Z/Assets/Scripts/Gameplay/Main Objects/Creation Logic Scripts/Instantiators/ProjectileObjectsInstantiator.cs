using UnityEngine;

//using ChickenDayZ.Gameplay.MainObjects.DamageItem;
//using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators
{
    public class ProjectileObjectsInstantiator : MonoBehaviour
    {        
        /*[SerializeField] private GameObject[] _projectileObjectsPrefabs;

        public bool SetProjectileObjectsInstantiator()
        {
            bool settingSuccessful = AllPrefabsHaveProjectileObjects();

            if (!settingSuccessful)
            {
                Debug.LogError("Set all ProjectileObject prefabs correctly to continue!");
            }

            return settingSuccessful;
        }

        public GameObject InstantiateProjectileObject(ProjectileObjectTypeEnum projectileObjectType)
        {
            GameObject auxContainer = GetCorrectPrefab(projectileObjectType);

            if (auxContainer == null)
            {
                Debug.LogError("Failed to instantiate ProjectileObject!");

                return null;
            }

            return Instantiate(auxContainer);
        }

        private GameObject GetCorrectPrefab(ProjectileObjectTypeEnum projectileObjectType)
        {
            for (short i = 0; i < _projectileObjectsPrefabs.Length; i++)
            {
                if (_projectileObjectsPrefabs[i].GetComponent<ProjectileObject>().ProjectileObjectType == projectileObjectType)
                {
                    return _projectileObjectsPrefabs[i];
                }
            }

            Debug.LogError("ProjectileObjectType doesnt match any ProjectileObject type in prefabs, a new one must be added!");

            return null;
        }

        private bool AllPrefabsHaveProjectileObjects()
        {
            ProjectileObject auxContainer;

            bool allPrefabsHaveProjectileObject = true;

            for (short i = 0; i < _projectileObjectsPrefabs.Length; i++)
            {
                auxContainer = _projectileObjectsPrefabs[i].GetComponent<ProjectileObject>();

                if (auxContainer == null)
                {
                    Debug.LogError("Prefab number " + (i + 1) + " doesnt contain a ProjectileObject!");

                    if (allPrefabsHaveProjectileObject)
                    {
                        allPrefabsHaveProjectileObject = false;
                    }
                }
            }

            return allPrefabsHaveProjectileObject;
        }*/
    }
}