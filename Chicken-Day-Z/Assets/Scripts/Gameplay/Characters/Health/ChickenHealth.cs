using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.Health 
{
    public class ChickenHealth : ObjectHealth
    {
        public override CharacterTypeEnum GetCharacterType()
        {
            return CharacterTypeEnum.CHICKEN;
        }

        public override void HealthReachedZero() 
        {
            GameplayResetter.ResetGameplay();            
        }        


    }
}