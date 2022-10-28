using UnityEngine;
//using System.Collections.Generic;

//using ChickenDayZ.Gameplay.Controllers;
//using ChickenDayZ.Gameplay.MainObjects.Interfaces;

namespace ChickenDayZ.Gameplay.MainObjects.CreationLogic
{   
    public class MainObjectInstancesHolder : MonoBehaviour//, IObjectRessetable
    {
        /*private List<MainObject> _mainObjects;

        public List<MainObject> MainObjects 
        {
            get
            {
                return _mainObjects;
            }            
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += GameplayResset;

            GameplayResetter.OnRoundReset += RoundResset;
        }

        void OnDisable() 
        {
            GameplayResetter.OnGameplayReset -= GameplayResset;

            GameplayResetter.OnRoundReset -= RoundResset;
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

        public void SetMainObjects(List<MainObject> mainObjects) 
        {
            _mainObjects = new List<MainObject>();

            for (short i = 0; i < mainObjects.Count; i++)
            {
                _mainObjects.Add(mainObjects[i]);
            }
        }

        public void SetMainObjects(GameObject[] mainObjects)
        {
            _mainObjects = new List<MainObject>();

            for (short i = 0; i < mainObjects.Length; i++)
            {
                _mainObjects.Add(mainObjects[i].GetComponent<MainObject>());
            }                        
        }*/
    }
}