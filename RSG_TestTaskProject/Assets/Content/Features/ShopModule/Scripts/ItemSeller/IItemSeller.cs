using System.Collections.Generic;
using Content.Features.StorageModule.Scripts;

namespace Content.Features.ShopModule.Scripts
{
    public interface IItemSeller
    {
        int SellItem(Item item, IStorage storage);
        int SellItems(List<Item> items, IStorage storage);
    }
}