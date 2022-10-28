using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects 
{
    public abstract class MainObject : MonoBehaviour 
    {
        private MainObjectTypeEnum _mainObjectType;               

        public MainObjectTypeEnum MainObjectType
        {
            get 
            {
                return _mainObjectType;
            }
        }             

        protected MainObject(MainObjectTypeEnum mainObjectType) 
        {
            _mainObjectType = mainObjectType;                       
        }                       
    }
}