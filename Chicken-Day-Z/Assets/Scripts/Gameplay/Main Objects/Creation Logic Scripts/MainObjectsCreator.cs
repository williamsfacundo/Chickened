using System;
using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects;

namespace ChickenDayZ.Gameplay.Logic 
{
    public class MainObjectsCreator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _mainObjectsPrefabs;

        private MainObject _mainObjects; 

        public event Action OnInitMainObjects;

        private void Awake()
        {
            //HaveTwoPrefabsTheSameId();
        }

        public GameObject GetMainObject(string id)
        {
            switch (id) 
            {
                case MainObjectsIds.EggId:

                    //return Instantiate<>;
                    
                case MainObjectsIds.TreeId:

                    //return;

                case MainObjectsIds.WallId:

                    //return;

                case MainObjectsIds.ChickenId:

                    //return;

                case MainObjectsIds.NormalZombieId:

                    //return;

                case MainObjectsIds.FastZombieId:

                    //return;

                case MainObjectsIds.FatZombieId:

                    //return;

                case MainObjectsIds.ProjectileItemId:

                    //return;

                case MainObjectsIds.MeleeItemId:

                    //return;

                case MainObjectsIds.FirearmItemId:

                    //return;

                case MainObjectsIds.MeleeWeapon:

                    //return;

                default:

                    Debug.Log("Id doesnt match any MainObject!");

                    return null;                    
            }            
        }  
        
        private void InitMainObjectsCreator() 
        {

        }

        private GameObject GetCorrectPrefab(string id) 
        {
            for (short i = 0; i < _mainObjectsPrefabs.Length; i++) 
            {
                /*if (_mainObjectsPrefabs.GetId() == id) 
                {
                    return _mainObjectsPrefabs[i];
                }*/
            }

            Debug.Log("There is no prefab with that id!");

            return null;
        }

        private void CheckIfTwoPrefabsHaveTheSameId() 
        {
            bool twoPrefabsHaveTheSameId = false;

            for (short i = 0; i < _mainObjectsPrefabs.Length; i++) 
            {
                for (short v = 0; v < _mainObjectsPrefabs.Length; v++) 
                {
                    if (i != v) 
                    {
                        /*if (_mainObjectsPrefabs[i].GetID = _mainObjectsPrefabs[v].GetId()) 
                        {
                            twoPrefabsHaveTheSameId = true;
                        }*/
                    }
                }
            }

            if (!twoPrefabsHaveTheSameId) 
            {
                OnInitMainObjects?.Invoke();
            }
        } 
    }
}