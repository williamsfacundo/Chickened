using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.DamageItem
{
    public class ProjectileObject : DamageItemObject
    {
        private ProjectileObject() : base(DamageItemObjectTypeEnum.PROJECTILE) 
        {
            
        }

        public override void GameplayResset()
        {

        }

        public override string GetId()
        {
            return MainObjectsIds.ProjectileItemId;
        }

        public override void RoundResset()
        {

        }
    }
}