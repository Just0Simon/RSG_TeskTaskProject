using System;
using Zenject;

namespace Content.Features.HealthModule.Scripts
{
    public class HealthBarPresenter : IDisposable
    {
        private readonly IHealthState _modelState;
        private readonly IHealthBarView _view;

        public HealthBarPresenter(
            [Inject(Id = HealthConstants.PLAYER_HEALTH_KEY)] IHealthState modelState, 
            IHealthBarView view)
        {
            _modelState = modelState;
            _view = view;

            _modelState.OnHealthChanged += OnPlayerHealthChanged;
            _view.UpdateHealthBar(_modelState.Health, _modelState.MaxHealth);
        }

        private void OnPlayerHealthChanged(HealthChangedEventArgs args)
        {
            _view.UpdateHealthBar(args.CurrentHealth, args.MaxHealth);
        }
        
        public void Dispose()
        {
            _modelState.OnHealthChanged -= OnPlayerHealthChanged;
        }
    }
}