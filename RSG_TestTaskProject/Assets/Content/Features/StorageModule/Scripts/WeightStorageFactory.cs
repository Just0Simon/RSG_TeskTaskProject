using Content.Features.InventoryModule.Scripts;

namespace Content.Features.StorageModule.Scripts
{
    public class WeightStorageFactory : IStorageFactory
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly WeightStorageConfiguration _weightStorageConfiguration;
        
        public WeightStorageFactory(IInventoryModel inventoryModel, WeightStorageConfiguration weightStorageConfiguration)
        {
            _inventoryModel = inventoryModel;
            _weightStorageConfiguration = weightStorageConfiguration;
        }

        public IStorage GetStorage()
        {
            return new WeightStorage(_inventoryModel, _weightStorageConfiguration.MaxWeight);
        }
    }
}