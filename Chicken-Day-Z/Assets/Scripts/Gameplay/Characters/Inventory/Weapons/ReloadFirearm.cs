using System;
using UnityEngine;

using ChickenDayZ.General;

using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class ReloadFirearm : IResettable
    {
        private Timer _timer;

        private Charger _charger;

        public bool _watingToReload;

        public event Action OnStartReloading;

        public event Action OnFinishedReloading;

        public event Action OnTimerCountDownChanged;

        public bool IsReloading 
        {
            get 
            {
                return !_timer.TimerFinished;
            }
        }

        public float TimerCountDown 
        {
            get 
            {
                return _timer.CountDown;
            }
        }

        public ReloadFirearm(Charger charger) 
        {
            _charger = charger;

            _timer = new Timer(_charger.ReloadTime);

            _timer.CountDown = 0f;

            OnTimerCountDownChanged?.Invoke();

            _watingToReload = false;
        }

        public void ReloadCharger(GameObject gameObject) 
        {
            if (_timer.TimerFinished && _charger.NeedToCharge) 
            {
                _watingToReload = true;

                _timer.ResetTimer();

                OnTimerCountDownChanged?.Invoke();

                OnStartReloading?.Invoke();

                AkSoundEngine.PostEvent("Play_Pistol_Reload_LV1", gameObject);
            }            
        }

        public void ReloadCooldown() 
        {
            _timer.DecreaseTimer();

            OnTimerCountDownChanged?.Invoke();

            if (_watingToReload && _timer.TimerFinished)
            {
                _charger.RefillCharger();

                _watingToReload = false;

                OnFinishedReloading?.Invoke();
            }
        }

        public void ResetObject()
        {
            _timer.CountDown = 0f;

            OnTimerCountDownChanged?.Invoke();

            _watingToReload = false;
        }
    }
}