using TMPro;
using UnityEngine;

namespace Content.Features.InventoryModule.Scripts
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField]
        private TMP_Text _itemCountText;
        
        public void UpdateItemsCount(int itemsCount)
        {
            _itemCountText.text = itemsCount.ToString();
        }
    }
}