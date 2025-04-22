namespace Content.Features.PlayerBalanceModule.Scripts
{
    public class PlayerCoinsBalanceService : IPlayerBalanceService
    {
        private readonly PlayerBalanceModel _model;

        public PlayerCoinsBalanceService(PlayerBalanceModel model)
        {
            _model = model;
        }
        
        public bool CanAfford(int cost)
        {
            return _model.Balance >= cost;
        }

        public void Add(int value)
        {
            _model.Add(value);
        }

        public void Remove(int value)
        {
            _model.Remove(value);
        }
    }
}