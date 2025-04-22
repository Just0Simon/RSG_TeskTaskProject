using Content.Features.AIModule.Scripts.Entity;
using Content.Features.InventoryModule.Scripts;

namespace Content.Features.StorageModule.Scripts
{
    public class WeightEntityStorageFactory : IEntityStorageFactory
    {
        private readonly IInventoryModelProvider _inventoryModelProvider;
        private readonly WeightStorageConfiguration _weightStorageConfiguration;
        
        public WeightEntityStorageFactory(IInventoryModelProvider inventoryModelProvider, WeightStorageConfiguration weightStorageConfiguration)
        {
            _inventoryModelProvider = inventoryModelProvider;
            _weightStorageConfiguration = weightStorageConfiguration;
        }

        public IStorage GetStorage(EntityType entityType)
        {
            return new WeightStorage(_inventoryModelProvider.GetModelForEntity(entityType), _weightStorageConfiguration.MaxWeight);
        }
    }
}