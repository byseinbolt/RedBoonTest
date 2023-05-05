namespace Services.Interfaces
{
    public interface IRecalculationService : IService
    {
        public float RecalculateSellingPrice(float price, bool isBought);
    }
}