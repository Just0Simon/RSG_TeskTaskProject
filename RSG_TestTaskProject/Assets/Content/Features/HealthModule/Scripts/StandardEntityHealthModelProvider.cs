using Content.Features.AIModule.Scripts.Entity;
using Content.Global.Scripts.Injection;
using Zenject;

namespace Content.Features.HealthModule.Scripts
{
    public class StandardEntityHealthModelProvider : IEntityHealthModelProvider
    {
        private readonly IEntityDataService _entityDataService;
        private readonly IHealthModel _playerHealthModel;

        public StandardEntityHealthModelProvider(IEntityDataService entityDataService, 
            [Inject(Id = InjectIdConstants.PLAYER_ID)] IHealthModel entityHealthModel)
        {
            _playerHealthModel = entityHealthModel;
            _entityDataService = entityDataService;
        }

        public IHealthModel ProvideHealthForEntityType(EntityType entityType)
        {
            switch (entityType)
            {
                case EntityType.Player:
                    return _playerHealthModel;
                default:
                    return new EntityHealthModel(_entityDataService.GetEntityData(entityType).StartHealth);
            }
        }
    }
}