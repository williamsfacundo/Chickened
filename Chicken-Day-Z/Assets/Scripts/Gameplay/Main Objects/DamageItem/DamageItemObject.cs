using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects 
{
    public abstract class DamageItemObject : MainObject
    {
        private DamageItemObjectTypeEnum _damageItemObjectType;

        public DamageItemObjectTypeEnum DamageItemObjectType 
        {
            get 
            {
                return _damageItemObjectType;
            }
        }

        protected DamageItemObject(DamageItemObjectTypeEnum damageItemObjectType) : base(MainObjectTypeEnum.DAMAGE_ITEM)
        {
            _damageItemObjectType = damageItemObjectType;
        }
    }
}