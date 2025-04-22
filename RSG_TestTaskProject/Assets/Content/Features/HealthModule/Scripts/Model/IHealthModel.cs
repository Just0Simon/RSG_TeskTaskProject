namespace Content.Features.HealthModule.Scripts
{
    public interface IHealthModel : IHealthState
    {
        public void TakeDamage(float damage);
        
        public void Heal(float heal);
    }
}