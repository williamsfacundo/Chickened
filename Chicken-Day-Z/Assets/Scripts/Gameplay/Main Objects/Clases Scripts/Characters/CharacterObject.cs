using ChickenDayZ.Gameplay.StatsScripts;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{    
    public abstract class CharacterObject : MainObject
    {
        private ObjectHealthStats _health;
        
        private CharacterObjectInventory _characterInventory;

        private CharacterObjectTypeEnum _characterObjectType;

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

        public CharacterObjectTypeEnum CharacterObjectType 
        {
            get 
            {
                return _characterObjectType;
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