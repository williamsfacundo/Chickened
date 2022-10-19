using UnityEngine;

namespace ChickenDayZ.Gameplay.MainObjects.Logic
{    
    [RequireComponent(typeof(MainObjectsInstantiator), 
        typeof(StartingMainObjectsInScene), typeof(MainObjectInstancesHolder))]
    [RequireComponent(typeof(MainObjectsDefiner))]
    public class GameplayMainObjectsManager : MonoBehaviour
    {
        private MainObjectsInstantiator mainObjectsInstantiator;
        private StartingMainObjectsInScene startingMainObjectsInScene;
        private MainObjectInstancesHolder mainObjectInstancesHolder;
        private MainObjectsDefiner mainObjectsDefiner;

        void Start()
        {
            bool objectsFound = FindNecessaryScriptsForCreatingMainObjects();

            if (objectsFound) 
            {
                CreatMainObjects();
            }

            Destroy(this);
        }

        bool FindNecessaryScriptsForCreatingMainObjects() 
        {
            mainObjectsInstantiator = FindObjectOfType<MainObjectsInstantiator>();

            if (mainObjectsInstantiator == null) 
            {
                Debug.LogError("Cant find MainObjectsInstantiator in scene!");

                return false;
            }
            
            startingMainObjectsInScene = FindObjectOfType<StartingMainObjectsInScene>();

            if (startingMainObjectsInScene == null)
            {
                Debug.LogError("Cant find StartingMainObjectsInScene in scene!");

                return false;
            }

            mainObjectInstancesHolder = FindObjectOfType<MainObjectInstancesHolder>();

            if (mainObjectInstancesHolder == null)
            {
                Debug.LogError("Cant find MainObjectInstancesHolder in scene!");

                return false;
            }

            mainObjectsDefiner = FindObjectOfType<MainObjectsDefiner>();

            if (mainObjectsDefiner == null)
            {
                Debug.LogError("Cant find MainObjectsDefiner in scene!");

                return false;
            }

            return true;
        }

        void CreatMainObjects() 
        {
            bool mainObjectsInstantiatorCreated = mainObjectsInstantiator.SetMainObjectsInstantiator();

            if (!mainObjectsInstantiatorCreated) 
            {
                return;
            }

            mainObjectInstancesHolder.SetMainObjects(startingMainObjectsInScene.GetMainObjects());

            mainObjectsDefiner.DefineMainObjects(mainObjectInstancesHolder.MainObjects);
        }        
    }
}