using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.BuildingObjects 
{
    public abstract class BuildingObject : MainObject
    {
        private BuildingObjectTypeEnum _buildingObjectType;

        public BuildingObjectTypeEnum BuildingObjectType 
        {
            get 
            {
                return _buildingObjectType;
            }
        }

        protected BuildingObject(BuildingObjectTypeEnum buildingObjectType) : base(MainObjectTypeEnum.BUILDING)
        {
            _buildingObjectType = buildingObjectType;
        }
    }
}