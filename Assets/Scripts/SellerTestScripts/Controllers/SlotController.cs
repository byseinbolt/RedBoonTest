using UnityEngine;
using UnityEngine.EventSystems;

namespace SellerTestScripts.Controllers
{
    public class SlotController : MonoBehaviour, IDropHandler
    {
        private string _previousSlotTag;
        
        public void OnDrop(PointerEventData eventData)
        {
            var otherObject = eventData.pointerDrag;
            
            if (otherObject.TryGetComponent<ItemController>(out var itemController))
            {
                _previousSlotTag = otherObject.transform.parent.tag;

                if (IsSellerItem(itemController)) return;
                if (IsNotAffordable(itemController)) return;
                PutInSlot(otherObject);

                var isPlayerSlot = CompareTag(_previousSlotTag);
                if (isPlayerSlot)
                {
                    itemController.UpdateData();
                    return;
                }
                
                itemController.UpdateData();
                var isNeedToBuy = itemController.CompareTag(GlobalConstants.ITEM_SELLER_TAG);
                if (isNeedToBuy)
                {
                    itemController.PurchaseItem();
                }
                else
                {
                    itemController.SellItem();
                }
            }
        }
        
        private void PutInSlot(GameObject otherObject)
        {
            otherObject.transform.SetParent(transform);
            otherObject.transform.localPosition = Vector3.zero;
        }

        private bool IsNotAffordable(ItemController itemController)
        {
            return itemController.CompareTag(GlobalConstants.ITEM_SELLER_TAG) && !itemController.IsItemAffordable();
        }

        private bool IsSellerItem(ItemController itemController)
        {
            return itemController.CompareTag(GlobalConstants.ITEM_SELLER_TAG) && CompareTag(_previousSlotTag);
        }
    }
}