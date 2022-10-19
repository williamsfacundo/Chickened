using ChickenDayZ.Gameplay.StatsScripts;

namespace ChickenDayZ.Gameplay.MainObjects.CombatItem 
{
    public class FirearmObject : CombatItemObject
    {
        private FirearmCharger _firearmCharger;

        private FirearmCanyon _firearmCanyon;

        public FirearmCharger FirearmCharger 
        {
            get 
            {
                return _firearmCharger;
            }
        }

        public FirearmCanyon FirearmCanyon 
        {
            get 
            {
                return _firearmCanyon;
            }
        }

        private FirearmObject()
        {
            _firearmCharger = new FirearmCharger();

            _firearmCanyon = new FirearmCanyon();
        }

        public override void GameplayResset()
        {
            _firearmCharger.GameplayResset();
        }

        public override void RoundResset()
        {
            
        }
    }
}