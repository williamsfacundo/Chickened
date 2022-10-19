using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.BuildingObjects
{
    public class WallObject : BuildingObject
    {        
        private WallObject() : base(BuildingObjectTypeEnum.WALL)
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
            return MainObjectsIds.WallId;
        }
    }
}