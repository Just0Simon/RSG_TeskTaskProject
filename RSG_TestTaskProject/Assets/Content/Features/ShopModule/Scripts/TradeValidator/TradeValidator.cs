using System.Collections.Generic;
using Content.Features.PlayerBalanceModule.Scripts;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ShopModule.Scripts
{
    public class TradeValidator : ITradeValidator
    {
        private readonly ItemsConfiguration _itemsConfiguration;

        public TradeValidator(ItemsConfiguration itemsConfiguration)
        {
            _itemsConfiguration = itemsConfiguration;
        }
        
        public bool CanBuyItem(ItemType itemType, IPlayerBalanceService playerBalanceService)
        {
            return playerBalanceService.CanAfford(_itemsConfiguration.GetItemConfiguration(itemType).BuyPrice);
        }

        public bool CanSellItem(ItemType itemType)
        {
            return _itemsConfiguration.ContainsConfigurationOfType(itemType);
        }

        public IEnumerable<Item> GetSellableItemTypes(IStorage storage)
        {
            foreach (var item in storage.GetAllItems())
            {
                yield return item;
            }
        }
    }
}