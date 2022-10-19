using System.Collections.Generic;

using ChickenDayZ.Gameplay.MainObjects;
using ChickenDayZ.Gameplay.MainObjects.Interfaces;

namespace ChickenDayZ.Gameplay.Logic
{   
    public class MainObjectInstancesHolder : IObjectRessetable
    {
        private List<MainObject> _mainObjects;        

        public MainObjectInstancesHolder(List<MainObject> mainObjects) 
        {
            SetMainObjects(mainObjects);
        }

        public void GameplayResset()
        {
            for (short i = 0; i < _mainObjects.Count; i++)
            {
                _mainObjects[i].GameplayResset();
            }
        }

        public void RoundResset()
        {
            for (short i = 0; i < _mainObjects.Count; i++)
            {
                _mainObjects[i].RoundResset();
            }
        }

        private void SetMainObjects(List<MainObject> mainObjects) 
        {
            _mainObjects = new List<MainObject>();

            for (short i = 0; i < mainObjects.Count; i++)
            {
                _mainObjects.Add(mainObjects[i]);
            }
        }                
    }
}