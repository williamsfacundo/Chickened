using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{
    public class NormalZombieObject : ZombieObject
    {
        private NormalZombieObject() : base(ZombieObjectTypeEnum.NORMAL)
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
            return MainObjectsIds.NormalZombieId;
        }
    }
}