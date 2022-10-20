using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{   

    public class ZombieObject : CharacterObject
    {
        [SerializeField] private ZombieObjectTypeEnum _zombieType;

        public ZombieObjectTypeEnum ZombieType 
        {
            get 
            {
                return _zombieType;
            }
        }

        public static short ZombiesTotalInstances = 0;
        
        public static short ZombiesActiveInstances = 0;

        void OnEnable()
        {
            ZombiesActiveInstances += 1;
        }

        void OnDisable()
        {
            ZombiesActiveInstances -= 1;
        }

        private ZombieObject()
        {
            ZombiesTotalInstances += 1;
        }

        public override void GameplayResset()
        {

        }

        public override void RoundResset()
        {

        }
    }
}