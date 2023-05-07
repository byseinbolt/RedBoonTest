using SellerTestScripts.Events;
using SellerTestScripts.Models;
using SellerTestScripts.Services.Interfaces;
using SellerTestScripts.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SellerTestScripts.Controllers
{
    public class ItemController : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField]
        private ItemSlotView _itemSlotView;

        private ItemModel _itemModel;
        private IBalanceService _balanceService;
        private IRecalculationService _recalculationService;

        public void Initialize(ItemModel itemModel)
        {
            _itemModel = itemModel;
            _itemSlotView.Initialize(_itemModel.View);
            _balanceService = ServiceLocator.Instance.Get<IBalanceService>();
            _recalculationService = ServiceLocator.Instance.Get<IRecalculationService>();
        }

        public void PurchaseItem()
        {
            _balanceService.Pay(_itemModel.Price);
            _itemModel.Price = _recalculationService.RecalculateSellingPrice(_itemModel.Price, true);
            gameObject.tag = GlobalConstants.ITEM_PLAYER_TAG;
        }

        public void SellItem()
        {
            _balanceService.Receive(_itemModel.Price);
            _itemModel.Price = _recalculationService.RecalculateSellingPrice(_itemModel.Price, false);
            gameObject.tag = GlobalConstants.ITEM_SELLER_TAG;
        }

        public bool IsItemAffordable()
        {
            return _balanceService.HasEnoughMoney(_itemModel.Price);
        }

        public void UpdateData()
        {
            _itemSlotView.ReturnSlot();
            _itemSlotView.Initialize(_itemModel.View);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (ItemSlotView.IsDragging)
            {
                return;
            }

            EventStreams.Game.Publish(
                new PointerEnteredItemEvent(_itemModel.View, _itemModel.Name, _itemModel.Price));
        }
    }
}