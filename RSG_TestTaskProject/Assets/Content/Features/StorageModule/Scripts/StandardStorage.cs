using System;
using System.Collections.Generic;
using System.Linq;
using Content.Features.InventoryModule.Scripts;

namespace Content.Features.StorageModule.Scripts {
    public class StandardStorage : IStorage
    {
        private IInventoryModel _inventoryModel;
        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;

        public StandardStorage(IInventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;
        }
        
        public List<Item> GetAllItems() =>
            _inventoryModel.Items.ToList();

        public bool CanAddItem(Item item)
        {
            return true;
        }

        public bool CanAddItems(List<Item> items)
        {
            return true;
        }
        
        public void AddItem(Item item) {
            if(_inventoryModel.ContainsItem(item))
                return;
        
            _inventoryModel.AddItem(item);
            OnItemAdded?.Invoke(item);
        }

        public void AddItems(List<Item> items) {
            foreach (Item item in items)
                AddItem(item);
        }

        public void RemoveItem(Item item) {
            if(_inventoryModel.ContainsItem(item) is false)
                return;

            _inventoryModel.RemoveItem(item);
            OnItemRemoved?.Invoke(item);
        }

        public void RemoveItems(List<Item> items) {
            foreach (Item item in items)
                RemoveItem(item);
        }

        public void RemoveAllItems() {
            foreach (Item item in _inventoryModel.Items)
                RemoveItem(item);
        }
    }
}