using Content.Features.AIModule.Scripts.Entity;
using Content.Features.InventoryModule.Scripts;

namespace Content.Features.StorageModule.Scripts {
    public class EntityStorageFactory : IEntityStorageFactory {
        private readonly IInventoryModelProvider _inventoryModelProvider;

        public EntityStorageFactory(IInventoryModelProvider inventoryModelProvider)
        {
            _inventoryModelProvider = inventoryModelProvider;

        }
        
        public IStorage GetStorage(EntityType entityType) =>
            new StandardStorage(_inventoryModelProvider.GetModelForEntity(entityType));
    }
}