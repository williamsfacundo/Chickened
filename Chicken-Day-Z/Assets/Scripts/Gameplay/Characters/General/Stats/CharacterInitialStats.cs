using UnityEngine;

namespace ChickenDayZ.Gameplay.Characters.Stats 
{
    [CreateAssetMenu(fileName = "Initial Stats", menuName = "Character Initial Stats")]
    public class CharacterInitialStats : ScriptableObject
    {
        public float MoveSpeed;       
    }
}