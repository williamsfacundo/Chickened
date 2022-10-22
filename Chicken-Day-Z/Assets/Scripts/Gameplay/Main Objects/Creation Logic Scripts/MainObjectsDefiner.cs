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
            /*switch (mainObject.Id)
            {
                case Enumerators.MainObjectsIdsEnum.EGG:
                    break;
                case Enumerators.MainObjectsIdsEnum.TREE:
                    break;
                case Enumerators.MainObjectsIdsEnum.WALL:
                    break;
                case Enumerators.MainObjectsIdsEnum.CHICKEN:
                    break;
                case Enumerators.MainObjectsIdsEnum.NORMAL_ZOMBIE:
                    break;
                case Enumerators.MainObjectsIdsEnum.FAST_ZOMBIE:
                    break;
                case Enumerators.MainObjectsIdsEnum.FAT_ZOMBIE:
                    break;
                case Enumerators.MainObjectsIdsEnum.PROJECTILE:
                    break;
                case Enumerators.MainObjectsIdsEnum.MELEE_ITEM:
                    break;
                case Enumerators.MainObjectsIdsEnum.FIREARM:
                    break;
                case Enumerators.MainObjectsIdsEnum.MELEE_WEAPON:
                    break;
                default:
                    break;
            }*/
        }
    }
}