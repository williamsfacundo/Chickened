using UnityEngine;

using ChickenDayZ.Gameplay.BehaviourScripts.Enumerators;

namespace ChickenDayZ.Gameplay.BehaviourScripts
{
    public abstract class BehaviourScript : MonoBehaviour
    {
        private BehaviourScriptTypeEnum _behaviourScriptType;

        public BehaviourScriptTypeEnum BehaviourScriptType
        {
            get
            {
                return _behaviourScriptType;
            }
        }

        public BehaviourScript(BehaviourScriptTypeEnum behaviourScriptType)
        {
            _behaviourScriptType = behaviourScriptType;
        }
    }
}