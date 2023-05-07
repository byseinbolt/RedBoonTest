using SimpleEventBus.Events;
using UnityEngine;

namespace SellerTestScripts.Events
{
    public class PointerEnteredItemEvent : EventBase
    {
        public Sprite ItemView { get; }
        public string ItemName { get; }
        public float Amount { get; }
        public float Price { get; }

        public PointerEnteredItemEvent(Sprite itemView, string itemName, float price)
        {
            ItemView = itemView;
            ItemName = itemName;
            Price = price;
        }
    }
}