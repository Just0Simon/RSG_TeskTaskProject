using Content.Features.StorageModule.Scripts;

namespace Content.Features.ShopModule.Scripts
{
    public interface ITrader : ITradeValidator, IItemBuyer, IItemSeller
    {
        int SellAllItems(IStorage storage);
    }
}