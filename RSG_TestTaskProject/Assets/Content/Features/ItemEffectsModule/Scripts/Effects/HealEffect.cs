using Content.Features.HealthModule.Scripts;
using Zenject;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public class HealEffect : Effect
    {
        private readonly IHealthModel _healthModel;
        
        private float _healAmount;
        
        public HealEffect(
            [Inject(Id=HealthConstants.PLAYER_HEALTH_KEY)] IHealthModel healthModel)
        {
            _healthModel = healthModel;
        }
        
        public override void Apply()
        {
            _healthModel.Heal(_healAmount);
        }

        public void SetHealAmount(float healAmount)
        {
            _healAmount = healAmount;
        }
    }
}