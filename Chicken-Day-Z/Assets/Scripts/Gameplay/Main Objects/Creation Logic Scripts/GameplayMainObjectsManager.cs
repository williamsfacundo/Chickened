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
            mainObjectsInstantiator = GetComponent<MainObjectsInstantiator>();
            startingMainObjectsInScene = GetComponent<StartingMainObjectsInScene>();
            mainObjectInstancesHolder = GetComponent<MainObjectInstancesHolder>();
            mainObjectsDefiner = GetComponent<MainObjectsDefiner>();

            CreateMainObjects();
        }        

        private void CreateMainObjects() 
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