using UnityEngine;


using ChickenDayZ.General;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class FireFirearm
    {
        private GameObject[] _projectiles;

        private Timer _timer;

        private Charger _charger;

        private Canyon _canyon;

        public FireFirearm(GameObject projectilePrefab, Charger charger, Canyon canyon)
        {
            _charger = charger;

            _canyon = canyon;

            _timer = new Timer(_canyon.FireRate);

            _projectiles = new GameObject[_charger.ChargerMaxAmmo];

            for (short i = 0; i < _projectiles.Length; i++) 
            {
                _projectiles[i] = GameObject.Instantiate<GameObject>(projectilePrefab);

                _projectiles[i].SetActive(false);
            }
        }

        public void ActivateProjectile() 
        {
            if (_timer.TimerFinished && !_charger.IsEmpty) 
            {
                for (short i = 0; i < _projectiles.Length; i++)
                {
                    if (!_projectiles[i].activeSelf) 
                    {
                        _projectiles[i].SetActive(true);

                        _timer.ResetTimer();

                        _charger.DecreaseCharger(_canyon.FireCapacity);

                        break;
                    }                                        
                }
            }           
        }

        public void FireFirearmCoolDown() 
        {
            _timer.DecreaseTimer();
        }
    }
}