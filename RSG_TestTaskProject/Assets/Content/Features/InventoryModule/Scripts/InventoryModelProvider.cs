using Content.Features.AIModule.Scripts.Entity;
using Content.Global.Scripts.Injection;
using Zenject;

namespace Content.Features.InventoryModule.Scripts
{
    public class InventoryModelProvider: IInventoryModelProvider
    {
        private readonly IInventoryModel _generalInventoryModel;
        private readonly IInventoryModel _playerInventoryModel;

        public InventoryModelProvider(IInventoryModel generalInventoryModel, [Inject(Id = InjectIdConstants.PLAYER_ID)] IInventoryModel playerInventoryModel)
        {
            _generalInventoryModel = generalInventoryModel;
            _playerInventoryModel = playerInventoryModel;

        }
        
        public IInventoryModel GetModelForEntity(EntityType entityType)
        {
            return entityType switch {
                EntityType.Player => _playerInventoryModel,
                _ => _generalInventoryModel
            };
        }
    }
}