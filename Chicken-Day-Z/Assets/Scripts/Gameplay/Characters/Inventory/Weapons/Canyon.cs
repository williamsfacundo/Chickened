namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class Canyon
    {
        private float _fireRate;

        private float _damage;

        private float _bulletMoveSpeed;

        private float _range;

        private short _fireCapacity;

        public float FireRate
        {
            get
            {
                return _fireRate;
            }
        }

        public float Damage
        {
            get
            {
                return _damage;
            }
        }

        public float BulletMoveSpeed 
        {
            get 
            {
                return _bulletMoveSpeed;
            }
        }

        public float Range 
        {
            get 
            {
                return _range;
            }
        }

        public short FireCapacity
        {
            get
            {
                return _fireCapacity;
            }
        }

        public Canyon(float fireRate, float damage, float bulletMoveSpeed, float range, short fireCapacity)
        {
            _fireRate = fireRate;

            _damage = damage;

            _bulletMoveSpeed = bulletMoveSpeed;

            _range = range;

            _fireCapacity = fireCapacity;
        }
    }
}