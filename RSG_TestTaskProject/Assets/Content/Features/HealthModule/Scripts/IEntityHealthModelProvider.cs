using Content.Features.AIModule.Scripts.Entity;

namespace Content.Features.HealthModule.Scripts
{
    public interface IEntityHealthModelProvider
    {
        public IHealthModel ProvideHealthForEntityType(EntityType entityType);
    }
}