using Content.Features.ItemEffectsModule.Scripts.Input;
using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.ItemEffectsModule.Scripts
{
    public class ItemEffectsModuleInstaller : Installer<ItemEffectsModuleInstaller>
    {
        public override void InstallBindings()
        {
            var addressableAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            
            BindActiveItemsView(addressableAssetLoaderService);

            BindHealPotionsView(addressableAssetLoaderService);
            
            BindActiveItemConfiguration(addressableAssetLoaderService);

            BindEffectsConfigurationsCollection(addressableAssetLoaderService);

            BindActiveItemsInputListener();

            BindEffectApplicator();

            BindEffectsFactory();

            BindPresenters();
        }

        private void BindPresenters()
        {
            Container.Bind<ActiveItemsPresenter>()
                .ToSelf()
                .AsSingle()
                .NonLazy();

            Container.Bind<HealPotionsPresenter>()
                .ToSelf()
                .AsSingle()
                .NonLazy();
        }

        private void BindEffectsFactory()
        {
            Container.Bind<IEffectsFactory>()
                .To<EffectsFactory>()
                .AsSingle();

            Container.Bind<IEffectsTypeFactory>()
                .To<EffectsTypeFactory>()
                .AsSingle();
        }

        private void BindEffectApplicator()
        {
            Container.Bind<EffectApplicator>()
                .ToSelf()
                .AsSingle();
        }

        private void BindActiveItemsInputListener()
        {
            Container.BindInterfacesTo<ActiveItemsInputListener>()
                .AsSingle();
        }

        private void BindEffectsConfigurationsCollection(IAddressablesAssetLoaderService addressableAssetLoaderService)
        {
            var effectsConfigurationsCollection =
                addressableAssetLoaderService.LoadAsset<EffectsConfigurationsCollection>(Address.Configurations.EffectsConfigurationsCollection_Default);
            Container.Bind<EffectsConfigurationsCollection>()
                .FromScriptableObject(effectsConfigurationsCollection)
                .AsSingle().NonLazy();
        }

        private void BindActiveItemConfiguration(IAddressablesAssetLoaderService addressableAssetLoaderService)
        {
            var activeItemsConfiguration = 
                addressableAssetLoaderService.LoadAsset<ActiveItemsConfiguration>(Address.Configurations.ActiveItemsConfiguration_Default);
            Container.Bind<ActiveItemsConfiguration>()
                .FromScriptableObject(activeItemsConfiguration)
                .AsSingle()
                .NonLazy();
        }

        private void BindHealPotionsView(IAddressablesAssetLoaderService addressableAssetLoaderService)
        {
            var healthPotionViewPrefab = addressableAssetLoaderService.LoadAsset<GameObject>(Address.Prefabs.HealPotionsView);
            Container.Bind<HealPotionsView>()
                .ToSelf()
                .FromComponentInNewPrefab(healthPotionViewPrefab)
                .AsSingle()
                .NonLazy();
        }

        private void BindActiveItemsView(IAddressablesAssetLoaderService addressableAssetLoaderService)
        {
            var activeItemsViewPrefab = addressableAssetLoaderService.LoadAsset<GameObject>(Address.Prefabs.ActiveItemsView);

            Container.Bind<IActiveItemsView>()
                .To<ActiveItemsView>()
                .FromComponentInNewPrefab(activeItemsViewPrefab)
                .AsSingle()
                .NonLazy();
        }
    }
}