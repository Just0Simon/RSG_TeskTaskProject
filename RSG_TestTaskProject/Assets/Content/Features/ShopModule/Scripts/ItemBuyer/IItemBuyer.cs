using System.Collections.Generic;
using Content.Features.PlayerBalanceModule.Scripts;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ShopModule.Scripts
{
    public interface IItemBuyer
    {
        Item BuyItem(ItemType itemType, IStorage storage, IPlayerBalanceService playerBalanceService);
        IEnumerable<Item> BuyItems(IEnumerable<ItemType> itemTypes, IStorage storage, IPlayerBalanceService playerBalanceService);
    }
}