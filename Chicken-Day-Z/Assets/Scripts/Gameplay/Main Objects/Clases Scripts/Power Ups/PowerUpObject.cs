using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public abstract class PowerUpObject : MainObject
    {
        private PowerUpObjectTypeEnum _powerUpObjectType;

        public PowerUpObjectTypeEnum PowerUpObjectType
        {
            get 
            {
                return _powerUpObjectType;
            }
        }

        protected PowerUpObject(PowerUpObjectTypeEnum powerUpObjectType) : base(MainObjectTypeEnum.POWER_UP) 
        {
            _powerUpObjectType = powerUpObjectType;
        }
    }
}