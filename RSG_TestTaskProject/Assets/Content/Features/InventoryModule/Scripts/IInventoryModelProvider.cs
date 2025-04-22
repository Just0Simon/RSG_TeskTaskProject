using Content.Features.AIModule.Scripts.Entity;

namespace Content.Features.InventoryModule.Scripts
{
    public interface IInventoryModelProvider
    {
        public IInventoryModel GetModelForEntity(EntityType entityType);
    }
}