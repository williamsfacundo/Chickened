using UnityEngine;

using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons
{
    [CreateAssetMenu(fileName = "FirearmStats", menuName = "Weapons/Firearm")]
    public class FirearmStats : ScriptableObject
    {
        public FirearmTypeEnum FirearmType;

        public Sprite _sprite;

        public GameObject ProjectilePrefab;

        public short ChargerMaxAmmo;

        public float ReloadTime;

        public float FireRate;
        
        public float Damage;

        public float BulletMoveSpeed;

        public float Range;

        public bool IsShotGun;        
    }
}