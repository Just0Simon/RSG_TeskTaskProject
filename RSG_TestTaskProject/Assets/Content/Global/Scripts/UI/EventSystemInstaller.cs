using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Content.Global.Scripts.UI
{
    public class EventSystemInstaller : Installer<EventSystemInstaller>
    {
        public override void InstallBindings()
        {
            var addressableAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            var eventSystemPrefab = addressableAssetLoaderService.LoadAsset<GameObject>(Address.Prefabs.EventSystem);

            Container.Bind<EventSystem>()
                .FromComponentInNewPrefab(eventSystemPrefab)
                .AsSingle()
                .NonLazy();
        }
    }
}