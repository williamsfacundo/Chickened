using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Interfaces 
{   
    public interface IInventoryItem : IResettable
    {
        InventoryItemEnum GetInventoryItemType();
    }    
}