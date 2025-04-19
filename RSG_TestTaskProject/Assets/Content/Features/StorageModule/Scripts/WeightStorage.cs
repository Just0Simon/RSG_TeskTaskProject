using System;
using System.Collections.Generic;
using System.Linq;

namespace Content.Features.StorageModule.Scripts
{
    public class WeightStorage : IWeightStorage
    {
        private List<Item> _items = new List<Item>();

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;
        public event Action<WeightChangedEventArgs> OnWeightChanged;
        
        public float CurrentWeight { get; private set; }
        public float MaxWeight { get; private set; }

        public WeightStorage(float maxWeight)
        {
            MaxWeight = maxWeight;
        }
        
        public List<Item> GetAllItems() =>
            _items.ToList();

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
            if(_items.Contains(item))
                return;
        
            _items.Add(item);
            CurrentWeight += item.Weight;
            OnItemAdded?.Invoke(item);
            InvokeWeightChangedEvent();
        }

        public void AddItems(List<Item> items) {
            foreach (Item item in items)
                AddItem(item);
        }

        public void RemoveItem(Item item) {
            if(_items.Contains(item) is false)
                return;

            _items.Remove(item);
            CurrentWeight += item.Weight;
            OnItemRemoved?.Invoke(item);
            InvokeWeightChangedEvent();
        }

        public void RemoveItems(List<Item> items) {
            foreach (Item item in items)
                RemoveItem(item);
        }

        public void RemoveAllItems() {
            foreach (Item item in _items)
                RemoveItem(item);
        }

        private void InvokeWeightChangedEvent()
        {
            OnWeightChanged?.Invoke(new WeightChangedEventArgs() { CurrentWeight = CurrentWeight, MaxWeight = MaxWeight });
        }
    }
}