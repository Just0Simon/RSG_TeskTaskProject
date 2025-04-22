using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public class ActiveItemView : MonoBehaviour
    {
        private static readonly Color OPAQUE_COLOR = Color.white;
        private static readonly Color TRANSPARENT_COLOR = new Color32(255, 255, 255, 0);
        
        public event Action<int> OnClicked;
        
        [SerializeField]
        private Image _itemImage;

        [SerializeField]
        private TMP_Text _itemNumberText;
        
        [SerializeField]
        private Button _itemButton;

        private int _itemNumber;
        
        private void Awake()
        {
            _itemButton.onClick.AddListener(OnItemClicked);
        }

        public void SetItem(Sprite itemSprite)
        {
            _itemImage.sprite = itemSprite;
            _itemImage.color = OPAQUE_COLOR;
        }

        public void SetItemNumber(int itemNumber)
        {
            _itemNumber = itemNumber;
            _itemNumberText.text = itemNumber.ToString();
        }

        public void ClearItem()
        {
            _itemImage.sprite = null;
            _itemImage.color = TRANSPARENT_COLOR;
        }
        
        private void OnItemClicked()
        {
            OnClicked?.Invoke(_itemNumber);
        }

        private void OnDestroy()
        {
            _itemButton.onClick.RemoveAllListeners();
        }
    }
}