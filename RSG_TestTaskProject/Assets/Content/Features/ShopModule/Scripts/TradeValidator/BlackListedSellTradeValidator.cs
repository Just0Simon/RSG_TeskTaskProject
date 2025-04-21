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
        private readonly List<ItemType> _blackListSellItemTypes;
        private readonly TradeValidator _tradeValidator;

        public BlackListedSellTradeValidator(List<ItemType> blackListSellItemTypes, TradeValidator tradeValidator)
        {
            _blackListSellItemTypes = blackListSellItemTypes;
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
            return _blackListSellItemTypes.Contains(itemType);
        }
    }
}