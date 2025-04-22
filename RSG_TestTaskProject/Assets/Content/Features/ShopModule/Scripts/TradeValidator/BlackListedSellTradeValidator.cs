using System.Collections.Generic;
using Content.Features.PlayerBalanceModule.Scripts;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ShopModule.Scripts
{
    /// <summary>
    /// Used with Decorator design pattern.
    /// </summary>
    public class BlackListedSellTradeValidator : ITradeValidator
    {
        private readonly BlackListItemsConfiguration _blackListItemsConfiguration;
        private readonly TradeValidator _tradeValidator;

        public BlackListedSellTradeValidator(BlackListItemsConfiguration blackListItemsConfiguration, TradeValidator tradeValidator)
        {
            _blackListItemsConfiguration = blackListItemsConfiguration;
            _tradeValidator = tradeValidator;
        }

        public bool CanBuyItem(ItemType itemType, IPlayerBalanceService playerBalanceService)
        {
            return _tradeValidator.CanBuyItem(itemType, playerBalanceService);
        }

        public bool CanSellItem(ItemType itemType)
        {
            return !IsInBlackList(itemType);
        }

        public IEnumerable<Item> GetSellableItemTypes(IStorage storage)
        {
            foreach (var item in storage.GetAllItems())
            {
                if(CanSellItem(item.ItemType))
                    yield return item;
            }
        }

        private bool IsInBlackList(ItemType itemType)
        {
            return _blackListItemsConfiguration.BlackListItems.Contains(itemType);
        }
    }
}