using UnityEngine;

using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects 
{
    public abstract class mainObjects : MonoBehaviour
    {
        [SerializeField] private CharacterTypeEnum _characterType;

        public CharacterTypeEnum CharacterType 
        {           
            get 
            {
                return _characterType;
            }
        }
    }
}