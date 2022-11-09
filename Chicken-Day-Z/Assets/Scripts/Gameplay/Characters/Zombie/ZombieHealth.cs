using UnityEngine;

using ChickenDayZ.Gameplay.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{
    public class ZombieHealth : ObjectHealth
    {
        protected override void PlayDeathSound() 
        {
            AkSoundEngine.PostEvent("Play_Zombies_Die", gameObject);
        }        
    }
}