using System;

using ChickenDayZ.Gameplay.MainObjects.Interfaces;

namespace ChickenDayZ.Gameplay.StatsScripts
{
    public class FirearmCharger : IObjectRessetable
    {
        public event Action OnCurrentAmmoChanged;        
        
        private short _currentAmmo;       

        private short _capacity;        

        private float _reloadTime;

        public short CurrentAmmo
        {
            set 
            {
                _currentAmmo = value;

                if (_currentAmmo < 0) 
                {
                    _currentAmmo = 0;
                }

                OnCurrentAmmoChanged?.Invoke();
            }
            get
            {
                return _currentAmmo;
            }
        }       

        public short Capacity
        {
            set 
            {
                _capacity = value;                
            }            
            get
            {
                return _capacity;
            }
        }        

        public float ReloadTime
        {
            set 
            {
                _reloadTime = value;               
            }
            get
            {
                return _reloadTime;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return _currentAmmo <= 0;
            }
        }

        public bool NeedToCharge
        {
            get
            {
                return _currentAmmo < Capacity;
            }
        }

        public FirearmCharger()
        {
            _currentAmmo = 0;            

            _capacity = 0;           

            _reloadTime = 0f;
        }        

        public void RefillCharger()
        {
            _currentAmmo = _capacity;           
        }      

        public void GameplayResset()
        {
            _currentAmmo = _capacity;
        }

        public void RoundResset()
        {
            
        }
    }
}