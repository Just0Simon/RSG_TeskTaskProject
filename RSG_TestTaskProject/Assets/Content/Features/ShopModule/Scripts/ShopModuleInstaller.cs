using Core.AssetLoaderModule.Core.Scripts;
using Global.Scripts.Generated;
using Zenject;

namespace Content.Features.ShopModule.Scripts
{
    public class ShopModuleInstaller : Installer<ShopModuleInstaller>
    {
        public override void InstallBindings()
        {
            var addressableAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            var blackListedItemsConfiguration = addressableAssetLoaderService.LoadAsset<BlackListItemsConfiguration>(Address.Configurations.SellBlackListItemsConfiguration_Default);

            Container.Bind<BlackListItemsConfiguration>()
                .FromScriptableObject(blackListedItemsConfiguration)
                .AsSingle()
                .NonLazy();

            Container.Bind<ITradeLogger>()
                .To<UnityTradeLogger>()
                .AsSingle();
            
            Container.Bind<TradeValidator>()
                .ToSelf()
                .AsTransient();
            
            Container.Bind<ITradeValidator>()
                .To<BlackListedSellTradeValidator>()
                .AsTransient();

            Container.Bind<IItemSeller>()
                .To<ItemSeller>()
                .AsTransient();

            Container.Bind<IItemBuyer>()
                .To<ItemBuyer>()
                .AsTransient();
            
            Container.Bind<ITrader>()
                .To<Trader>()
                .AsSingle();
        }
    }
}