using ChickenDayZ.Gameplay.StatsScripts;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.BuildingObjects
{
    public class EggObject : BuildingObject
    {
        private ObjectHealth _health;

        public ObjectHealth Health 
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

        private EggObject() : base(BuildingObjectTypeEnum.EGG)
        {
                        
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