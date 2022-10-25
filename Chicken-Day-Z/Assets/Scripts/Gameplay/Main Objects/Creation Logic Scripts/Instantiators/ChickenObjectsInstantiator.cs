using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Characters;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators
{
    public class ChickenObjectsInstantiator : MonoBehaviour
    {       
        [SerializeField] private GameObject[] _chickenObjectsPrefabs;

        public bool SetChickenObjectsInstantiator()
        {
            bool settingSuccessful = AllPrefabsHaveChickenObjects();

            if (!settingSuccessful)
            {
                Debug.LogError("Set all ChickenObject prefabs correctly to continue!");
            }

            return settingSuccessful;
        }

        public GameObject InstantiateChickenObject(PlayerObjectTypeEnum playerObjectTypeEnum)
        {
            GameObject auxContainer = GetCorrectPrefab(playerObjectTypeEnum);

            if (auxContainer == null)
            {
                Debug.LogError("Failed to instantiate ChickenObject!");

                return null;
            }

            return Instantiate(auxContainer);
        }

        private GameObject GetCorrectPrefab(PlayerObjectTypeEnum playerObjectTypeEnum)
        {
            for (short i = 0; i < _chickenObjectsPrefabs.Length; i++)
            {
                if (_chickenObjectsPrefabs[i].GetComponent<ChickenObject>().PlayersObjectTypeEnum == playerObjectTypeEnum)
                {
                    return _chickenObjectsPrefabs[i];
                }
            }

            Debug.LogError("ChickenObjectType doesnt match any ChickenObject type in prefabs, a new one must be added!");

            return null;
        }

        private bool AllPrefabsHaveChickenObjects()
        {
            ChickenObject auxContainer;

            bool allPrefabsHaveChickenObject = true;

            for (short i = 0; i < _chickenObjectsPrefabs.Length; i++)
            {
                auxContainer = _chickenObjectsPrefabs[i].GetComponent<ChickenObject>();

                if (auxContainer == null)
                {
                    Debug.LogError("Prefab number " + (i + 1) + " doesnt contain a ChickenObject!");

                    if (allPrefabsHaveChickenObject)
                    {
                        allPrefabsHaveChickenObject = false;
                    }
                }
            }

            return allPrefabsHaveChickenObject;
        }
    }
}