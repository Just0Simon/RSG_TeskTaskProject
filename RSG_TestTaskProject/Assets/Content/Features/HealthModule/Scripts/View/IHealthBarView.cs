namespace Content.Features.HealthModule.Scripts
{
    public interface IHealthBarView
    {
        void UpdateHealthBar(float currentHealth, float maxHealth);
    }
}