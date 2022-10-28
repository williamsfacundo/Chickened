using UnityEngine;

//using ChickenDayZ.Gameplay.MainObjects.PowerUp;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators 
{
    public class GunPowerUpObjectsInstantiator : MonoBehaviour
    {
        /*[SerializeField] private GameObject _gunPowerUpPrefabs;

        public bool SetGunPowerUpObjectObjectsInstantiator()
        {
            bool settingSuccessful = PrefabHasGunPowerUpObject();

            if (!settingSuccessful)
            {
                Debug.LogError("Set all GunPowerUpObject prefabs correctly to continue!");
            }

            return settingSuccessful;
        }

        public GameObject InstantiateGunPowerUpObject()
        {
            if (_gunPowerUpPrefabs == null)
            {
                Debug.LogError("Failed to instantiate GunPowerUpObject!");

                return null;
            }

            return Instantiate(_gunPowerUpPrefabs);
        }        

        private bool PrefabHasGunPowerUpObject()
        {
            GunPowerUpObject auxContainer = _gunPowerUpPrefabs.GetComponent<GunPowerUpObject>();

            if (auxContainer == null)
            {
                Debug.LogError("Prefab doesnt contain a GunPowerUpObject!");

                return false;
            }

            return true;
        }*/
    }
}