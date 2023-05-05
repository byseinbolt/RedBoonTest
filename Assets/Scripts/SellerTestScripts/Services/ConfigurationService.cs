using Models;
using Services.Interfaces;

namespace Services
{
    public class ConfigurationService : IConfigurationService
    {
        private ItemModel[] _itemModels;
        private readonly SellerItemsConfig _sellerItemsConfig;
        public ConfigurationService(SellerItemsConfig config)
        {
            _sellerItemsConfig = config;
        }
        
        public ItemModel[] GetItemModels(ItemModel[] itemModels = null)
        {
            if (itemModels == null)
            {
                return CreateItemModels();
            }

            _itemModels = itemModels;
            return _itemModels;
        }
        
        private ItemModel[] CreateItemModels()
        {
            _itemModels = new ItemModel[_sellerItemsConfig.ConfigItems.Length];
        
            for (var i = 0; i < _itemModels.Length; i++)
            {
                var configItemModel = _sellerItemsConfig.ConfigItems[i];
                var name = configItemModel.Name;
                var price = configItemModel.Price;
                var view = configItemModel.View;
                var itemModel = new ItemModel(name, price, view);
                _itemModels[i] = itemModel;
            }

            return _itemModels;
        }
    }
}