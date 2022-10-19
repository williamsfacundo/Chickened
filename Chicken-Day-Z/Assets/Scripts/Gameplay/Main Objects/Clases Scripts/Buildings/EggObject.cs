using ChickenDayZ.Gameplay.StatsScripts;

namespace ChickenDayZ.Gameplay.MainObjects.BuildingObjects
{
    public class EggObject : BuildingObject
    {
        private ObjectHealthStats _health;

        public ObjectHealthStats Health 
        {
            set 
            {
                _health = value;
            }
            get 
            {
                return _health;
            }
        }        

        public override void GameplayResset()
        {
            _health.GameplayResset();
        }

        public override void RoundResset()
        {
            _health.RoundResset();
        }        
    }
}