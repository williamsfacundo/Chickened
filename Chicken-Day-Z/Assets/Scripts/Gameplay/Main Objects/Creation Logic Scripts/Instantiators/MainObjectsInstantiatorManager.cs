using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic.Instantiators
{
    [RequireComponent(typeof(FirearmObjectsInstantiator), 
        typeof(BuildingObjectsInstantiator), typeof(MeleeWeaponObjectsInstantiator))]
    [RequireComponent(typeof(HealthPowerUpObjectsInstantiator), typeof(MeleeItemObjectsInstantiator),
        typeof(ChickenObjectsInstantiator))]
    [RequireComponent(typeof(ZombieObjectsInstantiator), typeof(ProjectileObjectsInstantiator), 
        typeof(GunPowerUpObjectsInstantiator))]
    public class MainObjectsInstantiatorManager : MonoBehaviour
    {
        private FirearmObjectsInstantiator _firearmObjectsInstantiator;

        private BuildingObjectsInstantiator _buildingObjectsInstantiator;

        private MeleeWeaponObjectsInstantiator _meleeWeaponObjectsInstantiator;

        private HealthPowerUpObjectsInstantiator _healthPowerUpObjectsInstantiator;

        private MeleeItemObjectsInstantiator _meleeItemObjectsInstantiator;

        private ChickenObjectsInstantiator _chickenObjectsInstantiator;

        private ZombieObjectsInstantiator _zombieObjectsInstantiator;

        private ProjectileObjectsInstantiator _projectileObjectsInstantiator;

        private GunPowerUpObjectsInstantiator _gunPowerUpObjectsInstantiator;

        void Awake()
        {
            _firearmObjectsInstantiator = GetComponent<FirearmObjectsInstantiator>();

            _buildingObjectsInstantiator = GetComponent<BuildingObjectsInstantiator>();

            _meleeWeaponObjectsInstantiator = GetComponent<MeleeWeaponObjectsInstantiator>();

            _healthPowerUpObjectsInstantiator = GetComponent<HealthPowerUpObjectsInstantiator>();

            _meleeItemObjectsInstantiator = GetComponent<MeleeItemObjectsInstantiator>();

            _zombieObjectsInstantiator = GetComponent<ZombieObjectsInstantiator>();

            _projectileObjectsInstantiator = GetComponent<ProjectileObjectsInstantiator>();

            _gunPowerUpObjectsInstantiator = GetComponent<GunPowerUpObjectsInstantiator>();
        }

        public bool SetMainObjectsInstantiator() 
        {
            return true;         
        }        

        public GameObject InstantiateFirearmObject(FirearmObjectTypeEnum firearmObjectType)
        {
            return _firearmObjectsInstantiator.InstantiateFirearmObject(firearmObjectType);                                    
        }

        public GameObject InstantiateBuildingObject(BuildingObjectTypeEnum buildingObjectType)
        {
            return _buildingObjectsInstantiator.InstantiateBuildingObject(buildingObjectType);
        }

        public GameObject InstantiateMeleeWeaponObject(MeleeWeaponItemObjectTypeEnum meleeWeaponItemObjectType)
        {
            return _meleeWeaponObjectsInstantiator.InstantiateMeleeWeaponObject(meleeWeaponItemObjectType);
        }

        public GameObject InstantiateHealthPowerUpObject(HealthPowerUpObjectTypeEnum healthPowerUpObjectType)
        {
            return _healthPowerUpObjectsInstantiator.InstantiateHealthPowerUpObject(healthPowerUpObjectType);
        }

        public GameObject InstantiateGunPowerUpObject()
        {
            return _gunPowerUpObjectsInstantiator.InstantiateGunPowerUpObject();
        }

        public GameObject InstantiateProjectileObject(ProjectileObjectTypeEnum projectileObjectType)
        {
            return _projectileObjectsInstantiator.InstantiateProjectileObject(projectileObjectType);
        }

        public GameObject InstantiateZombieObject(ZombieObjectTypeEnum zombieObjectType)
        {
            return _zombieObjectsInstantiator.InstantiateZombieObject(zombieObjectType);
        }

        public GameObject InstantiatePlayerObject(PlayerObjectTypeEnum playerObjectType)
        {
            return _chickenObjectsInstantiator.InstantiateChickenObject(playerObjectType);
        }

        public GameObject InstantiateMeleeItemObject(MeleeItemObjectTypeEnum meleeItemObjectType)
        {
            return _meleeItemObjectsInstantiator.InstantiateMeleeItemObject(meleeItemObjectType);
        }
    }       
}