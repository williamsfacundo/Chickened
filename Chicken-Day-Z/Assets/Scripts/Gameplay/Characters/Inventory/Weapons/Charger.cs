namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class Charger
    {
        private short _chargerAmmo;

        private short _chargerMaxAmmo;

        private float _reloadTime;

        public float ReloadTime 
        {
            get 
            {
                return _reloadTime;
            }
        }

        public bool IsEmpty 
        {
            get 
            {
                return _chargerAmmo <= 0;
            }
        }                

        public Charger(short chargerMaxAmmo, float reloadTime) 
        {
            _chargerAmmo = chargerMaxAmmo;

            _chargerMaxAmmo = chargerMaxAmmo;

            _reloadTime = reloadTime;
        }

        public void DecreaseCharger(short value) 
        {
            _chargerAmmo -= value;
        }

        public void RefillCharger() 
        {
            _chargerAmmo = _chargerMaxAmmo;
        }
    }
}