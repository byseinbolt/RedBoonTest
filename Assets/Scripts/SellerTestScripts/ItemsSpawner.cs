using SellerTestScripts.Controllers;
using UnityEngine;

namespace SellerTestScripts
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField]
        private ItemController _itemPrefab;

        [SerializeField]
        private SlotController _slotControllerPrefab;

        [SerializeField]
        private RectTransform _spawnRoot;

        public ItemController SpawnItem()
        {
            var slot = Instantiate(_slotControllerPrefab, _spawnRoot);
            var item = Instantiate(_itemPrefab, slot.transform);
            
            return item;
        }
    }
}