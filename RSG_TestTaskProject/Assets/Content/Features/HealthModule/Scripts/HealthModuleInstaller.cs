using Content.Features.AIModule.Scripts.Entity;
using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.HealthModule.Scripts
{
    public class HealthModuleInstaller : Installer<HealthModuleInstaller>
    {
        public override void InstallBindings()
        {
            BindPlayerHealthModel();

            BindPlayerHealthBarViewAndPresenter();

            BindEntityHealthProvider();
        }

        private void BindPlayerHealthModel()
        {
            var entityDataService = Container.Resolve<IEntityDataService>();
            var playerData = entityDataService.GetEntityData(EntityType.Player);
            float playerStartHealth = playerData.StartHealth;

            Container.BindInterfacesTo<EntityHealthModel>()
                .AsSingle()
                .WithConcreteId(HealthConstants.PLAYER_HEALTH_KEY)
                .WithArguments(playerStartHealth)
                .NonLazy();
        }

        private void BindPlayerHealthBarViewAndPresenter()
        {
            var addressablesAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            var healthBarPrefab = addressablesAssetLoaderService.LoadAsset<GameObject>(Address.Prefabs.HealthBarView);
            
            Container.Bind<IHealthBarView>()
                .To<HealthBarView>()
                .FromComponentInNewPrefab(healthBarPrefab)
                .AsSingle()
                .NonLazy();
            
            
            Container.Bind<HealthBarPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindEntityHealthProvider()
        {
            Container.Bind<IEntityHealthModelProvider>()
                .To<StandardEntityHealthModelProvider>()
                .AsSingle()
                .NonLazy();
        }
    }
}