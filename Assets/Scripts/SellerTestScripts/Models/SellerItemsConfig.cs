using UnityEngine;

namespace Models
{
   [CreateAssetMenu(menuName = "SellerItemsConfig", fileName = "SellerItemsConfig")]
   public class SellerItemsConfig : ScriptableObject
   {
      public ConfigItemModel[] ConfigItems => _configItems;

      public PlayerBalanceModel PlayerBalanceModel => _playerBalanceModel;
   
      [SerializeField]
      private ConfigItemModel[] _configItems;

      [SerializeField]
      private PlayerBalanceModel _playerBalanceModel;
   }
}