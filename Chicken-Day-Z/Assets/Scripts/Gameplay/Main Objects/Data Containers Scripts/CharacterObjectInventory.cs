using System;

using ChickenDayZ.Gameplay.MainObjects.CombatItem;

namespace ChickenDayZ.Gameplay.StatsScripts
{
    public class CharacterObjectInventory
    {
        private CombatItemObject _inHandObject;

        public event Action OnHandObjectChanged;

        public CombatItemObject InHandObject 
        {
            set 
            {
                _inHandObject = value;

                OnHandObjectChanged.Invoke();
            }
            get 
            {
                return _inHandObject;
            }
        }
    }
}