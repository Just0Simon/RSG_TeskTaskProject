namespace Content.Features.PlayerBalanceModule.Scripts
{
    public interface IPlayerBalanceService
    {
        public bool CanAfford(int cost);
        
        public void Add(int value);
        
        public void Remove(int value);
    }
}