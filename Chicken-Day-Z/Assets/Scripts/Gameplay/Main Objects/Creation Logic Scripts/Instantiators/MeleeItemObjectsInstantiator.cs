using UnityEngine;

//using ChickenDayZ.Gameplay.MainObjects.DamageItem;
//using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators
{
    public class MeleeItemObjectsInstantiator : MonoBehaviour
    {       
        /*[SerializeField] private GameObject[] _meleeItemObjectsPrefabs;

        public bool SetMeleeItemObjectsInstantiator()
        {
            bool settingSuccessful = AllPrefabsHaveMeleeItemObjects();

            if (!settingSuccessful)
            {
                Debug.LogError("Set all MeleeItemObject prefabs correctly to continue!");
            }

            return settingSuccessful;
        }

        public GameObject InstantiateMeleeItemObject(MeleeItemObjectTypeEnum meleeItemObjectType)
        {
            GameObject auxContainer = GetCorrectPrefab(meleeItemObjectType);

            if (auxContainer == null)
            {
                Debug.LogError("Failed to instantiate MeleeItemObject!");

                return null;
            }

            return Instantiate(auxContainer);
        }

        private GameObject GetCorrectPrefab(MeleeItemObjectTypeEnum meleeItemObjectType)
        {
            for (short i = 0; i < _meleeItemObjectsPrefabs.Length; i++)
            {
                if (_meleeItemObjectsPrefabs[i].GetComponent<MeleeItemObject>().MeleeItemObjectType == meleeItemObjectType)
                {
                    return _meleeItemObjectsPrefabs[i];
                }
            }

            Debug.LogError("MeleeItemObjectType doesnt match any MeleeItemObject type in prefabs, a new one must be added!");

            return null;
        }

        private bool AllPrefabsHaveMeleeItemObjects()
        {
            MeleeItemObject auxContainer;

            bool allPrefabsHaveMeleeItemObjects = true;

            for (short i = 0; i < _meleeItemObjectsPrefabs.Length; i++)
            {
                auxContainer = _meleeItemObjectsPrefabs[i].GetComponent<MeleeItemObject>();

                if (auxContainer == null)
                {
                    Debug.LogError("Prefab number " + (i + 1) + " doesnt contain a MeleeItemObject!");

                    if (allPrefabsHaveMeleeItemObjects)
                    {
                        allPrefabsHaveMeleeItemObjects = false;
                    }
                }
            }

            return allPrefabsHaveMeleeItemObjects;
        }*/
    }
}