using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{
    public class FastZombieObject : ZombieObject
    {
        private FastZombieObject() : base(ZombieObjectTypeEnum.FAST)
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
            return MainObjectsIds.FastZombieId;
        }
    }
}