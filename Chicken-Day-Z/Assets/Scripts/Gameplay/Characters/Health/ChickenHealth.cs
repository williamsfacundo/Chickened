using ChickenDayZ.Gameplay.Controllers;

namespace ChickenDayZ.Gameplay.Characters.Health 
{
    public class ChickenHealth : ObjectHealth
    {
        public override void HealthReachedZero() 
        {
            GameplayResetter.ResetGameplay();
        }        
    }
}