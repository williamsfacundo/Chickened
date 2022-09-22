using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Interfaces
{
    public interface IItemAction
    {
        void DoAction();

        void ActionCoolDown();

        ItemActionTypeEnum GetItemActionType(); 
    }    
}