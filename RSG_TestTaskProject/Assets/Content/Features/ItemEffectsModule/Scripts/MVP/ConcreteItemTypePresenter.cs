using System;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.InventoryModule.Scripts;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public abstract class ConcreteItemTypePresenter : IDisposable
    {
        private readonly ItemType _concreteItemType;
        protected readonly IInventoryModel _inventoryModel;

        private int _healPotionsCount;
        
        public ConcreteItemTypePresenter(ItemType concreteItemType, IInventoryModelProvider inventoryModelProvider)
        {
            _concreteItemType = concreteItemType;
            _inventoryModel = inventoryModelProvider.GetModelForEntity(EntityType.Player);
            
            _inventoryModel.ItemAdded += OnItemAdded;
            _inventoryModel.ItemRemoved += OnItemRemoved;
        }

        private void OnItemAdded(Item item)
        {
            if(item.ItemType != _concreteItemType)
                return;

            AddItem(item);
        }

        private void OnItemRemoved(Item item)
        {
            if(item.ItemType != _concreteItemType)
                return;
            
            RemoveItem(item);
        }

        public abstract void AddItem(Item item);
        public abstract void RemoveItem(Item item);

        public virtual void Dispose()
        {
            _inventoryModel.ItemAdded -= OnItemAdded;
            _inventoryModel.ItemRemoved -= OnItemRemoved;
        }
    }
}