using System.Collections.Generic;
using Content.Features.PlayerBalanceModule.Scripts;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ShopModule.Scripts
{
    public interface ITradeValidator
    {
        bool CanBuyItem(ItemType itemType, IPlayerBalanceService playerBalanceService);
        bool CanSellItem(ItemType itemType);
        
        IEnumerable<Item> GetSellableItemTypes(IStorage storage);
    }
}