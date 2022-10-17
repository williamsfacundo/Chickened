using ChickenDayZ.Gameplay.StatsScripts;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{    
    public abstract class CharacterObject : MainObject
    {
        private ObjectHealth _health;

        private CharacterObjectTypeEnum _characterObjectType;

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
        }        
    }
}