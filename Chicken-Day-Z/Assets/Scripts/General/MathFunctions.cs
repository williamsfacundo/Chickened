using UnityEngine;

namespace ChickenDayZ.General 
{
    public static class MathFunctions
    {
        public static float AngleBetweenTwoPositions(Vector3 pos1, Vector3 pos2)
        {            
            Vector3 direction = pos2 - pos1;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;            

            return angle;
        }
    }

    /*
     public static float AngleBetweenTwoPositions(GameObject currentObject, )
        {
            Camera camera = Camera.main;

            Vector3 ourPos = gameObject.transform.position;

            Vector3 targetPos = camera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 direction = targetPos - ourPos;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;            

            return angle;
        }
     */
}