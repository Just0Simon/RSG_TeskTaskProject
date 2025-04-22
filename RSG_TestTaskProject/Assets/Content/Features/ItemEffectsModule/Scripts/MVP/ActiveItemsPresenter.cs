using System;
using System.Collections.Generic;
using System.Linq;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.InventoryModule.Scripts;
using Content.Features.ItemEffectsModule.Scripts.Input;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public class ActiveItemsPresenter : IDisposable
    {
        private const int MAX_ACTIVE_ITEMS = 9;
        private const ItemType ILLIGAL_ITEM_TYPE = ItemType.Potion;
        
        private readonly IInventoryModel _inventoryModel;
        private readonly IActiveItemsView _activeItemsView;
        private readonly IActiveItemsInputListener _activeItemsInputListener;
        private readonly EffectApplicator _effectApplicator;

        private readonly Dictionary<int, Item> _activeItemsMap = new Dictionary<int, Item>();
        
        public ActiveItemsPresenter(IInventoryModelProvider inventoryModelProvider, IActiveItemsView activeItemsView, IActiveItemsInputListener activeItemsInputListener, EffectApplicator effectApplicator)
        {
            _inventoryModel = inventoryModelProvider.GetModelForEntity(EntityType.Player);
            _activeItemsView = activeItemsView;
            _activeItemsInputListener = activeItemsInputListener;
            _effectApplicator = effectApplicator;

            _inventoryModel.ItemAdded += OnItemAddedToStorage;
            _inventoryModel.ItemRemoved += OnItemRemovedFromStorage;
            
            _activeItemsInputListener.OnActiveItemNumberPressed += OnActiveItemNumberPressed;
            _activeItemsView.OnActiveItemClicked += OnActiveItemNumberPressed;
            
            _activeItemsView.Setup(MAX_ACTIVE_ITEMS);
            
            InitializeInventoryItems();
        }

        private void OnActiveItemNumberPressed(int activeItemNumber)
        {
            ActiveAndRemoveItem(activeItemNumber);
        }

        private void InitializeInventoryItems()
        {
            foreach (var item in _inventoryModel.Items)
            {
                OnItemAddedToStorage(item);
            }
        }

        private void ActiveAndRemoveItem(int activeItemNumber)
        {
            if (_activeItemsMap.TryGetValue(activeItemNumber, out var item))
            {
                _effectApplicator.ApplyEffectOfType(item.EffectType, out bool consumeItem);
                if(consumeItem)
                    _inventoryModel.RemoveItem(item);
            }
        }
        
        private void AddNewActiveItem(Item item)
        {
            if(item.ItemType == ILLIGAL_ITEM_TYPE)
                return;
            
            var newActiveItemNumber = _activeItemsMap.Count + 1;
            _activeItemsMap.Add(newActiveItemNumber, item);
            _activeItemsView.SetActiveItem(newActiveItemNumber, item.Icon);
        }

        private void RemoveActiveItem(Item item)
        {
            if (_activeItemsMap.ContainsValue(item))
            {
                var key = _activeItemsMap.First(x => x.Value == item).Key;
                _activeItemsView.RemoveActiveItem(key);
                _activeItemsMap.Remove(key);
            }
        }
        
        private void OnItemAddedToStorage(Item item)
        {
            AddNewActiveItem(item);
        }

        private void OnItemRemovedFromStorage(Item item)
        {
            RemoveActiveItem(item);
        }

        public void Dispose()
        {
            _inventoryModel.ItemAdded -= OnItemAddedToStorage;
            _inventoryModel.ItemRemoved -= OnItemRemovedFromStorage;
            
            _activeItemsInputListener.OnActiveItemNumberPressed -= OnActiveItemNumberPressed;
            _activeItemsView.OnActiveItemClicked -= OnActiveItemNumberPressed;
        }
    }
}