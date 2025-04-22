using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.PlayerBalanceModule.Scripts
{
    public class PlayerBalanceModuleInstaller : Installer<PlayerBalanceModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerBalanceModel>()
                .ToSelf()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<IPlayerBalanceService>()
                .To<PlayerCoinsBalanceService>()
                .AsSingle()
                .NonLazy();
            
            var addressableAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            var playerBalanceViewPrefab = addressableAssetLoaderService.LoadAsset<GameObject>(Address.Prefabs.PlayerBalanceView);

            Container.Bind<IPlayerBalanceView>()
                .To<PlayerBalanceView>()
                .FromComponentInNewPrefab(playerBalanceViewPrefab)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<PlayerBalancePresenter>()
                .ToSelf()
                .AsSingle()
                .NonLazy();
        }
    }
}