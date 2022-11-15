namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class Canyon
    {
        private float _fireRate;

        private float _damage;

        private float _bulletMoveSpeed;

        private float _range;        

        private bool _isShotGun;

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

        public bool IsShotGun 
        {
            get 
            {
                return _isShotGun;
            }
        }

        public Canyon(float fireRate, float damage, float bulletMoveSpeed, float range, bool isShotGun)
        {
            _fireRate = fireRate;

            _damage = damage;

            _bulletMoveSpeed = bulletMoveSpeed;

            _range = range;

            _isShotGun = isShotGun;
        }
    }
}