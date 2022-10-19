using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CombatItem
{
    public abstract class CombatItemObject : MainObject
    {
        private CombatItemObjectTypeEnum _combatItemObjectType;

        public CombatItemObjectTypeEnum CombatItemObjectType 
        {
            get 
            {
                return _combatItemObjectType;
            }
        }

        protected CombatItemObject(CombatItemObjectTypeEnum combatItemObjectType) : base(MainObjectTypeEnum.COMBAT_ITEM)
        {
            _combatItemObjectType = combatItemObjectType;
        }       
    }
}