using System;
using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.InventoryModule.Scripts
{
    public class PlayerInventoryModel : IInventoryModel
    {
        public event Action<Item> ItemAdded;
        public event Action<Item> ItemRemoved;
        
        public int ItemsCount => _items.Count;
        public IReadOnlyList<Item> Items => _items.AsReadOnly();

        private List<Item> _items = new List<Item>();

        public void AddItem(Item item)
        {
            _items.Add(item);
            ItemAdded?.Invoke(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
            ItemRemoved?.Invoke(item);
        }

        public bool ContainsItem(Item item)
        {
            return _items.Contains(item);
        }

        public void ClearItems()
        {
            _items.Clear();
        }
    }
}