using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.ShopModule.Scripts
{
    public class UnityTradeLogger : ITradeLogger
    {
        public void LogBuy(ItemType itemType, int price)
        {
            Debug.Log($"Bought item {itemType} for {price}");
        }

        public void LogSell(ItemType itemType, int price)
        {
            Debug.Log($"Sold item {itemType} for {price}");
        }
        public void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }
    }
}