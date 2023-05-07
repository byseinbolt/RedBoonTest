using System;
using System.Globalization;
using SellerTestScripts.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SellerTestScripts.Views
{
    public class ItemInfoView : MonoBehaviour
    {
        [SerializeField] 
        private Image _itemImage;
    
        [SerializeField]
        private TextMeshProUGUI _nameLabel;
    
        [SerializeField]
        private TextMeshProUGUI _priceLabel;
    
        private IDisposable _subscription;

        private void Awake()
        {
            _subscription = EventStreams.Game.Subscribe<PointerEnteredItemEvent>(ShowItemInfo);
        }

        private void ShowItemInfo(PointerEnteredItemEvent eventData)
        {
            _itemImage.sprite = eventData.ItemView;
            _nameLabel.text = eventData.ItemName;
            _priceLabel.text = $"Price: {eventData.Price.ToString(CultureInfo.InvariantCulture)}";
        }
    
        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}