using UnityEngine;
using System.Collections.Generic;

using ChickenDayZ.Gameplay.BehaviourScripts;
using ChickenDayZ.Gameplay.MainObjects.Interfaces;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;
using ChickenDayZ.Gameplay.BehaviourScripts.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects 
{
    public abstract class MainObject : MonoBehaviour, IObjectRessetable 
    {
        [SerializeField] private MainObjectsIdsEnum _id;

        private List<BehaviourScript> _behaviourScripts;        

        public MainObjectsIdsEnum Id 
        {
            get 
            {
                return _id;
            }
        }             

        protected MainObject() 
        {
            _behaviourScripts = new List<BehaviourScript>();            
        }       

        public abstract void GameplayResset();

        public abstract void RoundResset();        

        public void AddBehaviourScript(BehaviourScript behaviourScript)
        { 
            bool isBehaviourScriptInList = IsBehaviourScriptInList(behaviourScript.BehaviourScriptType);

            if (!isBehaviourScriptInList) 
            {
                _behaviourScripts.Add(behaviourScript);
            }
            else 
            {
                Debug.Log("BehaviourScript already in BehaviourScript list, thera cant be to similar BehaviourScripts!");
            }
        }

        public void RemovedBehaviourScript(BehaviourScript behaviourScript)
        {
            bool isBehaviourScriptInList = IsBehaviourScriptInList(behaviourScript);

            if (isBehaviourScriptInList) 
            {
                _behaviourScripts.Remove(behaviourScript);
            }
            else 
            {
                Debug.Log("Cant remove the BehaviourScript because in wasnt found in BehaviourScript list!");
            }
        }

        public BehaviourScript GetBehaviourScript(BehaviourScriptTypeEnum behaviourScriptType) 
        {
            for (short i = 0; i < _behaviourScripts.Count; i++) 
            {
                if (_behaviourScripts[i].BehaviourScriptType == behaviourScriptType) 
                {
                    return _behaviourScripts[i];
                }
            }

            return null;
        }

        private bool IsBehaviourScriptInList(BehaviourScript behaviourScript) 
        {
            for (short i = 0; i < _behaviourScripts.Count; i++)
            {
                if (_behaviourScripts[i] == behaviourScript)
                { 
                    return true;
                }
            }

            return false;
        }        

        private bool IsBehaviourScriptInList(BehaviourScriptTypeEnum behaviourScriptType)
        {
            for (short i = 0; i < _behaviourScripts.Count; i++)
            {
                if (_behaviourScripts[i].BehaviourScriptType == behaviourScriptType)
                {
                    return true;
                }
            }

            return false;
        }
    }
}