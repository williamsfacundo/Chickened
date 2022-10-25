using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.PowerUp;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators 
{
    public class HealthPowerUpObjectsInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _healthPowerUpPrefabs;

        public bool SetHealthPowerUpObjectsInstantiator()
        {
            bool settingSuccessful = AllPrefabsHaveHealthPowerUpObjects();

            if (!settingSuccessful)
            {
                Debug.LogError("Set all HealthPowerUpObject prefabs correctly to continue!");
            }

            return settingSuccessful;
        }

        public GameObject InstantiateHealthPowerUpObject(HealthPowerUpObjectTypeEnum healthPowerUpObjectTypeEnum)
        {
            GameObject auxContainer = GetCorrectPrefab(healthPowerUpObjectTypeEnum);

            if (auxContainer == null)
            {
                Debug.LogError("Failed to instantiate HealthPowerUpObject!");

                return null;
            }

            return Instantiate(auxContainer);
        }

        private GameObject GetCorrectPrefab(HealthPowerUpObjectTypeEnum healthPowerUpObjectTypeEnum)
        {
            for (short i = 0; i < _healthPowerUpPrefabs.Length; i++)
            {
                if (_healthPowerUpPrefabs[i].GetComponent<HealthPowerUpObject>().HealthPowerUpObjectTypeEnum == healthPowerUpObjectTypeEnum)
                {
                    return _healthPowerUpPrefabs[i];
                }
            }

            Debug.LogError("HealthPowerUpObjectType doesnt match any HealthPowerUpObject type in prefabs, a new one must be added!");

            return null;
        }

        private bool AllPrefabsHaveHealthPowerUpObjects()
        {
            HealthPowerUpObject auxContainer;

            bool allPrefabsHaveHealthPowerUpObject = true;

            for (short i = 0; i < _healthPowerUpPrefabs.Length; i++)
            {
                auxContainer = _healthPowerUpPrefabs[i].GetComponent<HealthPowerUpObject>();

                if (auxContainer == null)
                {
                    Debug.LogError("Prefab number " + (i + 1) + " doesnt contain a HealthPowerUpObject!");

                    if (allPrefabsHaveHealthPowerUpObject)
                    {
                        allPrefabsHaveHealthPowerUpObject = false;
                    }
                }
            }

            return allPrefabsHaveHealthPowerUpObject;
        }
    }
}