using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.CombatItem;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators 
{
    public class MeleeWeaponObjectsInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _meleeWeaponObjectPrefabs;        

        public bool SetMeleeWeaponObjectInstantiator()
        {
            bool settingSuccessful = AllPrefabsHaveMeleeWeaponObject();

            if (!settingSuccessful)
            {
                Debug.LogError("Set all MeleeWeaponObject prefabs correctly to continue!");
            }

            return settingSuccessful;
        }

        public GameObject InstantiateMeleeWeaponObject(MeleeWeaponItemObjectTypeEnum meleeWeaponItemObjectType)
        {
            GameObject auxContainer = GetCorrectPrefab(meleeWeaponItemObjectType);

            if (auxContainer == null)
            {
                Debug.LogError("Fasiled to instantiate MeleeWeaponObject!");

                return null;
            }

            return Instantiate(auxContainer);
        }

        private GameObject GetCorrectPrefab(MeleeWeaponItemObjectTypeEnum meleeWeaponItemObjectType)
        {
            for (short i = 0; i < _meleeWeaponObjectPrefabs.Length; i++)
            {
                if (_meleeWeaponObjectPrefabs[i].GetComponent<MeleeWeaponObject>().MeleeWeaponItemObjectType == meleeWeaponItemObjectType)
                {
                    return _meleeWeaponObjectPrefabs[i];
                }
            }

            Debug.LogError("MeleeWeaponObject doesnt match any MeleeWeaponObject type in prefabs, a new one must be added!");

            return null;
        }

        private bool AllPrefabsHaveMeleeWeaponObject()
        {
            MeleeWeaponObject auxContainer;            

            bool allPrefabsHaveMainObjects = true;

            for (short i = 0; i < _meleeWeaponObjectPrefabs.Length; i++)
            {
                auxContainer = _meleeWeaponObjectPrefabs[i].GetComponent<MeleeWeaponObject>();

                if (auxContainer == null)
                {
                    Debug.LogError("Prefab number " + (i + 1) + " doesnt contain a MeleeWeaponObject!");

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