using System.Collections.Generic;
using UnityEngine;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic
{
    public class MainObjectsDefiner : MonoBehaviour
    {
        //Pasarle los scriptable objects correspondientes

        public void DefineMainObjects(List<MainObject> mainObjects) 
        {
            for (short i = 0; i < mainObjects.Count; i++)
            {
                DefineMainObject(mainObjects[i]);
            }
        }    
        
        private void DefineMainObject(MainObject mainObject) 
        {
            
        }
    }
}