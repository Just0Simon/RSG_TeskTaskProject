using System;
using System.Collections.Generic;
using UnityEngine;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public class ActiveItemsView : MonoBehaviour, IActiveItemsView
    {
        public event Action<int> OnActiveItemClicked; 
        
        private Dictionary<int, ActiveItemView> _activeItemsViews = new Dictionary<int, ActiveItemView>();

        [SerializeField]
        private ActiveItemView _potionActiveItemView;
        
        [SerializeField]
        private ActiveItemView _activeItemViewPrefab;

        [SerializeField]
        private Transform _activeItemsContainer;
        private int _maxActiveItemsCount;
        
        public void Setup(int maxActiveItemsCount)
        {
            _maxActiveItemsCount = maxActiveItemsCount;
            InstantiateActiveItems();
        }
        
        public void SetActiveItem(int activeItemNumber, Sprite itemIcon)
        {
            if (_activeItemsViews.TryGetValue(activeItemNumber, out var activeItemView))
            {
                activeItemView.SetItem(itemIcon);
            }
            else
            {
                Debug.LogError($"Given number is out of range. [NUM:{activeItemNumber}]");
            }
        }

        public void RemoveActiveItem(int number)
        {
            if (_activeItemsViews.TryGetValue(number, out var activeItemView))
            {
                activeItemView.ClearItem();
            }
        }
        
        private void ActiveItemClicked(int number)
        {
            OnActiveItemClicked?.Invoke(number);
        }

        private void InstantiateActiveItems()
        {
            for (int i = 0; i < _maxActiveItemsCount; i++)
            {
                var activeItemView = Instantiate(_activeItemViewPrefab, _activeItemsContainer);
                var activeItemNumber = i + 1;
                
                activeItemView.SetItemNumber(activeItemNumber);
                activeItemView.ClearItem();
                activeItemView.OnClicked += ActiveItemClicked;
                
                _activeItemsViews[activeItemNumber] = activeItemView;
            }
        }
    }
}