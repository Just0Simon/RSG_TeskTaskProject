using Content.Features.StorageModule.Scripts;
using Content.Global.Scripts.Injection;
using Zenject;

namespace Content.Features.InventoryModule.Scripts
{
    public class InventoryPresenter
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IInventoryView _inventoryView;

        public InventoryPresenter([Inject(Id = InjectIdConstants.PLAYER_ID)] IInventoryModel inventoryModel, IInventoryView inventoryView)
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