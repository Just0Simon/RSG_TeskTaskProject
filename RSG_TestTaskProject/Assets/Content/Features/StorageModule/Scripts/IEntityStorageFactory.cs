using Content.Features.AIModule.Scripts.Entity;

namespace Content.Features.StorageModule.Scripts {
    public interface IEntityStorageFactory {
        public IStorage GetStorage(EntityType entityType);
    }
}