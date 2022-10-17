using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects 
{
    public abstract class ZombieObject : CharacterObject
    {
        private ZombieObjectTypeEnum _zombieObjectType;

        public ZombieObjectTypeEnum ZombieObjectType
        {
            get 
            {
                return _zombieObjectType;
            }
        }

        protected ZombieObject(ZombieObjectTypeEnum zombieObjectType) : base(CharacterObjectTypeEnum.ZOMBIE) 
        {
            _zombieObjectType = zombieObjectType;
        }        
    }
}