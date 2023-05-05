using System;
using Services.Interfaces;

namespace Services
{
    public class BalanceService : IBalanceService
    {
        public event Action<float> BalanceChanged;
        public float Balance { get; private set; }

        public BalanceService(float balance)
        {
            Balance = balance;
        }
        
        public void Pay(float amount)
        {
            Balance -= amount;
            BalanceChanged?.Invoke(Balance);
        }

        public void Receive(float amount)
        {
            Balance += amount;
            BalanceChanged?.Invoke(Balance);
        }

        public bool HasEnoughMoney(float amount)
        {
            return Balance >= amount;
        }
    }
}