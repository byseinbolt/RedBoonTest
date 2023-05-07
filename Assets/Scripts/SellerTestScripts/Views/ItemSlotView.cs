using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SellerTestScripts.Views
{
    public class ItemSlotView : MonoBehaviour, IBeginDragHandler, IDragHandler,
        IEndDragHandler
    {
        public static bool IsDragging { get; private set; }

        [SerializeField] 
        private Image _itemImage;
    
        private GridLayoutGroup _gridLayoutGroup;
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;
        private Transform _defaultParent;
    
        public void Initialize(Sprite itemView)
        {
            _itemImage.sprite = itemView;
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        
            _gridLayoutGroup = GetComponentInParent<GridLayoutGroup>();
            _canvas = GetComponentInParent<Canvas>();
        
            _defaultParent = _rectTransform.parent;
        }

        public void ReturnSlot()
        {
            _defaultParent.SetParent(_gridLayoutGroup.transform);
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _gridLayoutGroup.enabled = false;
            var parentTransform = _rectTransform.parent;
            parentTransform.SetParent(_canvas.transform);

            _canvasGroup.blocksRaycasts = false;
            IsDragging = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta/_canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = Vector3.zero;
            ReturnSlot();
            _canvasGroup.blocksRaycasts = true;
            IsDragging = false;
        }
    }
}