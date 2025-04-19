using System;
using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.InventoryModule.Scripts
{
    public interface IInventoryModel
    {
        event Action<Item> ItemAdded;
        event Action<Item> ItemRemoved;
        
        int ItemsCount { get; }
        IReadOnlyList<Item> Items { get; }
        
        void AddItem(Item item);
        
        void RemoveItem(Item item);
        
        bool ContainsItem(Item item);
        
        void ClearItems();
    }
}