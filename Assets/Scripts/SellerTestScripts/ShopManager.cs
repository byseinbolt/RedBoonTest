using Models;
using Services;
using Services.Interfaces;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private SellerItemsConfig _config;

    [SerializeField]
    private ItemsSpawner _itemsSpawner;
    
    private void Awake()
    {
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.Register<IConfigurationService>(new ConfigurationService(_config));
        serviceLocator.Register<IRecalculationService>(new RecalculationService());
        serviceLocator.Register<IBalanceService>(new BalanceService(_config.PlayerBalanceModel.Balance));
        
    }

    private void Start()
    {
        ShowItems();
    }

    private void ShowItems()
    {
        var configService = ServiceLocator.Instance.Get<IConfigurationService>();
        var itemModels = configService.GetItemModels();
        foreach (var itemModel in itemModels)
        {
            var item = _itemsSpawner.SpawnItem();
            item.Initialize(itemModel);
        }
    }
}