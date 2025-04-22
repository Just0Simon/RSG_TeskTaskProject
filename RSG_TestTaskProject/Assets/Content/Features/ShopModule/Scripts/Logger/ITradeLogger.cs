using Content.Features.StorageModule.Scripts;

namespace Content.Features.ShopModule.Scripts
{
    public interface ITradeLogger
    {
        public void LogBuy(ItemType item, int price);
        public void LogSell(ItemType item, int price);
        public void LogWarning(string message);
    }
}