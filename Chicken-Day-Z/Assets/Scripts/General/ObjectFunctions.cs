using UnityEngine;

public static class ObjectFunctions
{
    public static bool IsNullObjectInArray(Object[] objects) 
    {
        for (short i = 0; i < objects.Length; i++) 
        {
            if (objects[i] == null) 
            {
                return true;
            }
        }

        return false;
    }
}
