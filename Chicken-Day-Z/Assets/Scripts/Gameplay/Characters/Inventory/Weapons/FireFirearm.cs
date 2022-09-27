using UnityEngine;


using ChickenDayZ.General;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class FireFirearm
    {
        private ProjectileMovement[] _projectiles;

        private GameObject _character;

        private Timer _timer;

        private Charger _charger;

        private Canyon _canyon;

        private Camera _camera;

        public FireFirearm(GameObject projectilePrefab, Charger charger, Canyon canyon, GameObject character)
        {
            _character = character;

            _charger = charger;

            _canyon = canyon;

            _timer = new Timer(_canyon.FireRate);

            _projectiles = new ProjectileMovement[_charger.ChargerMaxAmmo / 2];            

            for (short i = 0; i < _projectiles.Length; i++) 
            {
                _projectiles[i] = GameObject.Instantiate<GameObject>(projectilePrefab).GetComponent<ProjectileMovement>();

                _projectiles[i].SetProjectile(canyon.BulletMoveSpeed, canyon.Range);

                _projectiles[i].gameObject.SetActive(false);
            }
        }

        public void ActivateProjectile() 
        {
            if (_timer.TimerFinished && !_charger.IsEmpty) 
            {
                for (short i = 0; i < _projectiles.Length; i++)
                {
                    if (!_projectiles[i].gameObject.activeSelf) 
                    {
                        _projectiles[i].gameObject.SetActive(true);

                        _projectiles[i].gameObject.transform.position = _character.transform.position;

                        _projectiles[i].Direction = CalculateProjectileDirection(_character.transform.position);

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

        private Vector3 CalculateProjectileDirection(Vector3 playerPosition) 
        {
            if (_camera == null) 
            {
                _camera = Camera.main;
            }

            Vector3 direction = _camera.ScreenToWorldPoint(Input.mousePosition) - playerPosition;

            direction.z = 0f;

            Vector3 normalizedDirection = Vector3.Normalize(direction);

            return normalizedDirection;
        }
    }
}