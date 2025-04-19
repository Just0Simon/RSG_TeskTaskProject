using Zenject;

namespace Content.Features.InventoryModule.Scripts
{
    public class InventoryModuleInstaller : Installer<InventoryModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IInventoryModel>()
                .To<PlayerInventoryModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}