using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{    
    public abstract class CharacterObject : MainObject
    {
        private CharacterObjectTypeEnum _characterObjectType;       

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