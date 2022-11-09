using UnityEngine;

using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class FireFirearm : IResettable
    {
        private ProjectileMovement[] _projectiles;

        private GameObject _character;

        private ReloadFirearm _reloadFirearm;

        private Timer _timer;

        private Charger _charger;

        private Canyon _canyon;

        private Camera _camera;

        public FireFirearm(GameObject projectilePrefab, Charger charger, Canyon canyon, GameObject character, ReloadFirearm reloadFirearm)
        {
            _character = character;

            _reloadFirearm = reloadFirearm;

            _charger = charger;

            _canyon = canyon;

            _timer = new Timer(_canyon.FireRate);            

            _projectiles = new ProjectileMovement[_charger.ChargerMaxAmmo / 2];

            InstanciateProjectiles(projectilePrefab);
        }

        public void ActivateProjectile(GameObject gameObject) 
        {
            if (_timer.TimerFinished && !_charger.IsEmpty && !_reloadFirearm.IsReloading) 
            {
                for (short i = 0; i < _projectiles.Length; i++)
                {
                    if (!_projectiles[i].gameObject.activeSelf) 
                    {
                        _projectiles[i].GetComponent<ProjectileImpact>().ProjectileImpacted = false; 

                        _projectiles[i].gameObject.SetActive(true);

                        _projectiles[i].gameObject.transform.position = _character.transform.position;

                        _projectiles[i].Direction = CalculateProjectileDirection(_character.transform.position);

                        _timer.ResetTimer();

                        AkSoundEngine.PostEvent("Play_Pistol_LV1", gameObject);                                      

                        _charger.DecreaseCharger(_canyon.FireCapacity);                        

                        break;
                    }                                        
                }
            }

            if (_charger.IsEmpty) 
            {
                _reloadFirearm.ReloadCharger(gameObject);
            }
        }

        public void FireFirearmCoolDown() 
        {
            _timer.DecreaseTimer();
        }

        public void DestroyBullets() 
        {

            if (_projectiles != null) 
            {
                for (short i = 0; i < _projectiles.Length; i++)
                {
                    GameObject.Destroy(_projectiles[i].gameObject);
                }
            }            
        }

        private Vector3 CalculateProjectileDirection(Vector3 playerPosition) 
        {
            SetCamera();

            Vector3 direction = _camera.ScreenToWorldPoint(Input.mousePosition) - playerPosition;

            direction.z = 0f;

            Vector3 normalizedDirection = Vector3.Normalize(direction);

            return normalizedDirection;
        }

        private void SetCamera() 
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }
        }

        private void InstanciateProjectiles(GameObject projectilePrefab) 
        {
            for (short i = 0; i < _projectiles.Length; i++)
            {
                _projectiles[i] = GameObject.Instantiate<GameObject>(projectilePrefab).GetComponent<ProjectileMovement>();

                _projectiles[i].SetProjectile(_canyon.BulletMoveSpeed, _canyon.Range);

                _projectiles[i].gameObject.SetActive(false);
            }
        }
        
        private void DesactivateProjectiles() 
        {
            for (short i = 0; i < _projectiles.Length; i++)
            {
                _projectiles[i].gameObject.SetActive(false);
            }
        }

        public void ResetObject()
        {
            DesactivateProjectiles();

            _timer.ResetTimer();
        }
    }
}