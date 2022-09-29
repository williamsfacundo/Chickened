using ChickenDayZ.General;

using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class ReloadFirearm : IResettable
    {
        private Timer _timer;

        private Charger _charger;

        public bool _watingToReload;

        public bool IsReloading 
        {
            get 
            {
                return !_timer.TimerFinished;
            }
        }

        public ReloadFirearm(Charger charger) 
        {
            _charger = charger;

            _timer = new Timer(_charger.ReloadTime);

            _timer.CountDown = 0f;

            _watingToReload = false;
        }

        public void ReloadCharger() 
        {
            if (_timer.TimerFinished && _charger.NeedToCharge) 
            {
                _watingToReload = true;

                _timer.ResetTimer();                
            }            
        }

        public void ReloadCooldown() 
        {
            _timer.DecreaseTimer();

            if (_watingToReload && _timer.TimerFinished)
            {
                _charger.RefillCharger();

                _watingToReload = false;
            }
        }

        public void ResetObject()
        {
            _timer.CountDown = 0f;

            _watingToReload = false;
        }
    }
}