using System;

namespace Services.Interfaces
{
    public interface IBalanceService : IService
    {
        public event Action<float> BalanceChanged;
        public float Balance { get;}
        public void Pay(float amount);
        public void Receive(float amount);
        public bool HasEnoughMoney(float amount);
    }
}