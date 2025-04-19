using System;
using System.Collections.Generic;
using System.Linq;
using Content.Features.InventoryModule.Scripts;
using UnityEngine;

namespace Content.Features.StorageModule.Scripts
{
    public class WeightStorage : IWeightStorage
    {
        private readonly IInventoryModel _inventoryModel;
        
        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;
        public event Action<WeightChangedEventArgs> OnWeightChanged;

        public float CurrentWeight { get; private set; }
        public float MaxWeight { get; }
        
        public WeightStorage(IInventoryModel inventoryModel, float maxWeight)
        {
            _inventoryModel = inventoryModel;
            LoadItemsWeights();
            MaxWeight = maxWeight;
        }
        
        public List<Item> GetAllItems() =>
            _inventoryModel.Items.ToList();

        public bool CanAddItem(Item item)
        {
            var tempWeight = CurrentWeight + item.Weight;
            return MaxWeight >= tempWeight;
        }

        public bool CanAddItems(List<Item> items)
        {
            var itemsWeightSum = items.Sum(x => x.Weight);
            var tempWeight = CurrentWeight + itemsWeightSum;

            return MaxWeight >= tempWeight;
        }
        
        public void AddItem(Item item) {
            if(_inventoryModel.ContainsItem(item))
                return;
        
            _inventoryModel.AddItem(item);
            CurrentWeight += item.Weight;
            OnItemAdded?.Invoke(item);
            InvokeWeightChangedEvent();
        }

        public void AddItems(List<Item> items) {
            foreach (Item item in items)
                AddItem(item);
        }

        public void RemoveItem(Item item) {
            if(_inventoryModel.ContainsItem(item) is false)
                return;

            _inventoryModel.RemoveItem(item);
            CurrentWeight -= item.Weight;
            OnItemRemoved?.Invoke(item);
            InvokeWeightChangedEvent();
        }

        public void RemoveItems(List<Item> items) {
            foreach (Item item in items)
                RemoveItem(item);
        }

        public void RemoveAllItems()
        {
            var items = _inventoryModel.Items;
            for (int i = items.Count - 1; i >= 0; i--)
            {
                RemoveItem(items[i]);
            }
            
            /*
            foreach (Item item in _inventoryModel.Items)
                RemoveItem(item);*/
        }
        
        private void InvokeWeightChangedEvent()
        {
            OnWeightChanged?.Invoke(new WeightChangedEventArgs() { CurrentWeight = CurrentWeight, MaxWeight = MaxWeight });
            Debug.Log($"Weight changed to {CurrentWeight}");
        }

        private void LoadItemsWeights()
        {
            CurrentWeight = _inventoryModel.Items.Sum(x => x.Weight);
        }
    }
}