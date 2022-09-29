using ChickenDayZ.General;

using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Gameplay.Characters.Inventory.Weapons 
{
    public class ReloadFirearm : IResettable
    {
        private Timer _timer;

        private Charger _charger;

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
        }

        public void ReloadCharger() 
        {
            if (_timer.TimerFinished) 
            {
                _charger.RefillCharger();

                _timer.ResetTimer();                
            }              
        }

        public void ReloadCooldown() 
        {
            _timer.DecreaseTimer();
        }

        public void ResetObject()
        {
            _timer.CountDown = 0f;
        }
    }
}