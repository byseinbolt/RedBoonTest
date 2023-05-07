using SellerTestScripts.Models;

namespace SellerTestScripts.Services.Interfaces
{
    public interface IConfigurationService : IService
    {
        public ItemModel[] GetItemModels(ItemModel[] itemModels = null);
    }
}