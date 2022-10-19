using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CombatItem 
{
    public class MeleeWeaponObject : CombatItemObject
    {
        public MeleeWeaponObject() : base(CombatItemObjectTypeEnum.MELEE_WEAPON)
        {

        }

        public override void GameplayResset()
        {
            
        }

        public override void RoundResset()
        {
            
        }

        public override string GetId()
        {
            return MainObjectsIds.MeleeWeapon;
        }
    }
}