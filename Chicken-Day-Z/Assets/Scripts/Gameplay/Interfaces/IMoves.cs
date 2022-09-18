using UnityEngine;

namespace ChickenDayZ.Gameplay.Interfaces 
{
    interface IMoves
    {
        void Move(GameObject gameObject);

        Vector3 CalculateMoveDirection();
    }
}