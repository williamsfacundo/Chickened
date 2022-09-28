using ChickenDayZ.Gameplay.Characters.Health;
using ChickenDayZ.Gameplay.Enumerators;
using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.Gameplay.EggBase 
{
    public class EggBaseHealth : ObjectHealth
    {
        public override void HealthReachedZero()
        {
            GameplayResetter.ResetGameplay();                                                
        }

        public override CharacterTypeEnum GetCharacterType()
        {
            return CharacterTypeEnum.EGG_BASE;
        }
    }
}