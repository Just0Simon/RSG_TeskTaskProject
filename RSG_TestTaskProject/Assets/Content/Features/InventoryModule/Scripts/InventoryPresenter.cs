using Content.Features.StorageModule.Scripts;

namespace Content.Features.InventoryModule.Scripts
{
    public class InventoryPresenter
    {
        private IInventoryModel _inventoryModel;
        private IInventoryView _inventoryView;

        public InventoryPresenter(IInventoryModel inventoryModel, IInventoryView inventoryView)
        {
            _inventoryModel = inventoryModel;
            _inventoryView = inventoryView;
            
            SubscribeToModel();
        }

        private void SubscribeToModel()
        {
            _inventoryModel.ItemAdded += OnItemAdded;
            _inventoryModel.ItemRemoved += OnItemRemoved;
        }

        private void UnsubscribeFromModel()
        {
            _inventoryModel.ItemAdded -= OnItemAdded;
            _inventoryModel.ItemRemoved -= OnItemRemoved;
        }
        
        private void OnItemAdded(Item item)
        {
            UpdateItemsCount();
        }

        private void OnItemRemoved(Item item)
        {
            UpdateItemsCount();
        }

        private void UpdateItemsCount()
        {
            _inventoryView.UpdateItemsCount(_inventoryModel.ItemsCount);
        }
    }
}