using Content.Features.InventoryModule.Scripts;

namespace Content.Features.StorageModule.Scripts {
    public class StorageFactory : IStorageFactory {
        private readonly IInventoryModel _inventoryModel;

        public StorageFactory(IInventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;

        }
        
        public IStorage GetStorage() =>
            new StandardStorage(_inventoryModel);
    }
}