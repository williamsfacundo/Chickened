using UnityEngine;

namespace ChickenDayZ.Gameplay.ScripObjctsConfig 
{
    [CreateAssetMenu(fileName = "Instantiation Config", menuName = "ScriptableObjects/Main Object/Creation")]
    public class MainObjectInstantiationConfig : ScriptableObject
    {
        public short Count;

        public GameObject Prefab;
    }
}