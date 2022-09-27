namespace ChickenDayZ.Gameplay.Interfaces 
{
    public interface IDamageable
    {
        public void ReceiveDamage(float value);

        public void HealthReachedZero();
    }
}