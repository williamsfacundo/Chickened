namespace ChickenDayZ.Gameplay.Interfaces 
{
    public interface IMoves : IResettable
    {
        void Move();

        void CalculateMoveDirection();

        bool IsMoving();
    }
}