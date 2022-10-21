using ChickenDayZ.Gameplay.StatsScripts;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{    
    public abstract class CharacterObject : MainObject
    {
        private CharacterObjectTypeEnum _characterObjectType;        

        private ObjectHealthStats _health;
        
        private CharacterObjectInventory _characterInventory;

        public CharacterObjectTypeEnum CharacterObjectType
        {
            get
            {
                return _characterObjectType;
            }
        }

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

        protected CharacterObject(CharacterObjectTypeEnum characterObjectType) : base(MainObjectTypeEnum.CHARACTER)
        {
            _characterObjectType = characterObjectType;

            _health = new ObjectHealthStats();

            _characterInventory = new CharacterObjectInventory();
        }        
    }
}