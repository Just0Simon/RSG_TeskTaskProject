using System;

namespace Content.Features.PlayerBalanceModule.Scripts
{
    public class PlayerBalancePresenter : IDisposable
    {
        private PlayerBalanceModel _model;
        private IPlayerBalanceView _view;

        public PlayerBalancePresenter(PlayerBalanceModel model, IPlayerBalanceView view)
        {
            _model = model;
            _view = view;
            
            SubscribeToModelAndUpdateBalance();
        }

        public void SubscribeToModelAndUpdateBalance()
        {
            _model.PlayerBalanceChanged += OnPlayerBalanceChanged;
            _view.UpdateBalance(_model.Balance);
        }

        private void OnPlayerBalanceChanged(int newBalance)
        {
            _view.UpdateBalance(newBalance);
        }

        public void Dispose()
        {
            _model.PlayerBalanceChanged -= OnPlayerBalanceChanged;
        }
    }
}