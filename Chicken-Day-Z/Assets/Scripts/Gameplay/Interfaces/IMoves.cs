namespace ChickenDayZ.Gameplay.Interfaces 
{
    interface IMoves : IResettable
    {
        void Move();

        void CalculateMoveDirection();
    }
}