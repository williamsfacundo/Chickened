using ChickenDayZ.Gameplay.StatsScripts;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{    
    public abstract class CharacterObject : MainObject
    {
        private ObjectHealthStats _health;
        
        private CharacterObjectInventory _characterInventory;        

        public ObjectHealthStats Health
        {            
            get
            {
                return _health;
            }
        }

        public CharacterObjectInventory CharacterInventory 
        {            
            get 
            {
                return _characterInventory;
            }
        }               

        protected CharacterObject()
        {
            _health = new ObjectHealthStats();

            _characterInventory = new CharacterObjectInventory();
        }        
    }
}