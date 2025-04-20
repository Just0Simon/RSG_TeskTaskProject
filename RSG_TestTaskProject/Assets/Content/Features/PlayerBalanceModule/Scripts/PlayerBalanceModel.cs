using System;

namespace Content.Features.PlayerBalanceModule.Scripts
{
    public class PlayerBalanceModel
    {
        public event Action<int> PlayerBalanceChanged;
        
        public int Balance { get; private set; }

        public void Add(int amount)
        {
            Balance += amount;
            PlayerBalanceChanged?.Invoke(Balance);
        }

        public void Remove(int amount)
        {
            Balance -= amount;
            PlayerBalanceChanged?.Invoke(Balance);
        }

        private void InvokePlayerBalanceChanged()
        {
            PlayerBalanceChanged?.Invoke(Balance);
        }
    }
}