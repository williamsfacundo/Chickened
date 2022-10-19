using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.BuildingObjects
{
    public class TreeObject : BuildingObject
    {
        private TreeObject() : base(BuildingObjectTypeEnum.TREE)
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
            return MainObjectsIds.TreeId;
        }
    }
}