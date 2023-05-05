using Models;

namespace Services.Interfaces
{
    public interface IConfigurationService : IService
    {
        public ItemModel[] GetItemModels(ItemModel[] itemModels = null);
    }
}