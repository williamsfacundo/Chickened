using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.DamageItem
{
    public class MeleeItemObject : DamageItemObject
    {
        private MeleeItemObject() : base(DamageItemObjectTypeEnum.MELEE_ITEM) 
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
            return MainObjectsIds.MeleeItemId;
        }
    }
}