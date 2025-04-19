using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
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
            
            IAddressablesAssetLoaderService addressablesAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();

            var inventoryViewPrefab = addressablesAssetLoaderService.LoadAsset<GameObject>(Address.Prefabs.InventoryView);
            Container.Bind<IInventoryView>()
                .To<InventoryView>()
                .FromComponentInNewPrefab(inventoryViewPrefab)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<InventoryPresenter>()
                .ToSelf()
                .AsSingle()
                .NonLazy();
        }
    }
}