using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.ScripObjctsConfig 
{
    [CreateAssetMenu(fileName = "Instantiation Config", menuName = "ScriptableObjects/Main Object/Creation")]
    public class MainObjectInstantiationConfig : ScriptableObject
    {
        [Range(1, 100)] public short Count;

        //public MainObjectsIdsEnum MainObjectId;
    }
}