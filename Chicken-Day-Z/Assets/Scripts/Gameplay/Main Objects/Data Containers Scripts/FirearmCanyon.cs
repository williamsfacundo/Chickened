namespace ChickenDayZ.Gameplay.StatsScripts 
{
    public class FirearmCanyon
    {
        private float _fireRate;

        private float _damage;

        private float _bulletMoveSpeed;

        private float _range;

        private short _fireCapacity;

        public float FireRate
        {
            set 
            {
                _fireRate = value;
            }
            get
            {
                return _fireRate;
            }
        }

        public float Damage
        {
            set 
            {
                _damage = value;
            }
            get
            {
                return _damage;
            }
        }

        public float BulletMoveSpeed
        {
            set 
            {
                _bulletMoveSpeed = value;
            }
            get
            {
                return _bulletMoveSpeed;
            }
        }

        public float Range
        {
            set 
            {
                _range = value;
            }
            get
            {
                return _range;
            }
        }

        public short FireCapacity
        {
            set 
            {
                _fireCapacity = value;
            }
            get
            {
                return _fireCapacity;
            }
        } 

        public FirearmCanyon() 
        {
            _fireRate = 0f;

            _damage = 0f;

            _bulletMoveSpeed = 0f;

            _range = 0f;

            _fireCapacity = 0;
        }        
    }
}