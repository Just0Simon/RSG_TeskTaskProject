using System;
using Zenject;

namespace Content.Features.HealthModule.Scripts
{
    public class HealthBarPresenter : IDisposable
    {
        private readonly IHealthModel _model;
        private readonly IHealthBarView _view;

        public HealthBarPresenter(
            [Inject(Id = HealthConstants.PLAYER_HEALTH_KEY)] IHealthModel model, 
            IHealthBarView view)
        {
            _model = model;
            _view = view;

            _model.OnHealthChanged += OnPlayerHealthChanged;
            _view.UpdateHealthBar(_model.Health, _model.MaxHealth);
        }

        private void OnPlayerHealthChanged(HealthChangedEventArgs args)
        {
            _view.UpdateHealthBar(args.CurrentHealth, args.MaxHealth);
        }
        
        public void Dispose()
        {
            _model.OnHealthChanged -= OnPlayerHealthChanged;
        }
    }
}