using UnityEngine;

using ChickenDayZ.Gameplay.Characters.Health;

namespace ChickenDayZ.Lightning 
{
    public class LightFollowsPlayer : MonoBehaviour
    {
        private GameObject _chicken;

        void Start()
        {
            _chicken = FindObjectOfType<ChickenHealth>().gameObject;      
        }

        void LateUpdate()
        {
            transform.position = _chicken.transform.position;
        }
    }
}