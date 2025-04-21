using System.Collections.Generic;
using System.Linq;
using Content.Features.PlayerBalanceModule.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.ShopModule.Scripts
{
    public class Trader : MonoBehaviour, ITrader
    {
        private ITradeValidator _tradeValidator;
        private IItemSeller _itemSeller;
        private IItemBuyer _itemBuyer;

        [Inject]
        public void InjectDependencies(ITradeValidator validator, IItemSeller seller, IItemBuyer buyer)
        {
            _tradeValidator = validator;
            _itemSeller = seller;
            _itemBuyer = buyer;
        }
        
        public bool CanBuyItem(ItemType itemType, IPlayerBalanceService playerBalanceService)
        {
            return _tradeValidator.CanBuyItem(itemType, playerBalanceService);
        }

        public bool CanSellItem(ItemType itemType)
        {
            return _tradeValidator.CanSellItem(itemType);
        }

        public int SellAllItems(IStorage storage)
        {
            var itemsToSell = GetSellableItemTypes(storage);
            return SellItems(itemsToSell.ToList(), storage);
        }
        
        public int SellItem(Item item, IStorage storage)
        {
            return _itemSeller.SellItem(item, storage);
        }

        public int SellItems(List<Item> items, IStorage storage)
        {
            int totalEarned = 0;
            foreach (var item in items)
            {
                totalEarned += SellItem(item, storage);
            }
            return totalEarned;
        }

        public Item BuyItem(ItemType itemType, IStorage storage, IPlayerBalanceService playerBalanceService)
        {
            return _itemBuyer.BuyItem(itemType, storage, playerBalanceService);
        }

        public IEnumerable<Item> BuyItems(IEnumerable<ItemType> itemTypes, IStorage storage, IPlayerBalanceService playerBalanceService)
        {
            return _itemBuyer.BuyItems(itemTypes, storage, playerBalanceService);
        }

        public IEnumerable<Item> GetSellableItemTypes(IStorage storage)
        {
            return _tradeValidator.GetSellableItemTypes(storage);
        }
    }
}